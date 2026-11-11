namespace Azure.AI.Projects
{
    public partial class AgentDataGenerationJobSource : Azure.AI.Projects.DataGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentDataGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentDataGenerationJobSource>
    {
        public AgentDataGenerationJobSource(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public override string Description { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentDataGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentDataGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentDataGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentDataGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentDataGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentDataGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentDataGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluatorGenerationJobSource : Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>
    {
        public AgentEvaluatorGenerationJobSource(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentEvaluatorGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentEvaluatorGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentEvaluatorGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFilterTraceSource : Azure.AI.Projects.TraceSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFilterTraceSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFilterTraceSource>
    {
        public AgentFilterTraceSource() { }
        public string AgentId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public Azure.AI.Projects.FilterStrategyType? FilterStrategy { get { throw null; } set { } }
        public int? MaxTraces { get { throw null; } set { } }
        public System.DateTimeOffset? StartsOn { get { throw null; } set { } }
        protected override Azure.AI.Projects.TraceSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.TraceSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentFilterTraceSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFilterTraceSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFilterTraceSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentFilterTraceSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFilterTraceSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFilterTraceSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFilterTraceSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgenticIdentityPreviewCredentials : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>
    {
        internal AgenticIdentityPreviewCredentials() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgenticIdentityPreviewCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgenticIdentityPreviewCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgenticIdentityPreviewCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsight : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsight>
    {
        internal AgentInsight() { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string Category { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.AI.Projects.AgentInsightDetails Details { get { throw null; } }
        public string Id { get { throw null; } }
        public string MonitorId { get { throw null; } }
        public Azure.AI.Projects.AgentInsightSeverity Severity { get { throw null; } }
        public Azure.AI.Projects.AgentInsightStatus Status { get { throw null; } }
        public string Title { get { throw null; } }
        public int TraceCount { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsight JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AgentInsight (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AgentInsight PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsight System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsight System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightDetails>
    {
        internal AgentInsightDetails() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.AgentInsightHighlightedTrace> HighlightedTraces { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.AgentInsightLinkedTrace> LinkedTraces { get { throw null; } }
        public Azure.AI.Projects.AgentInsightRecommendedAction RecommendedActions { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightEstimatedCost : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightEstimatedCost>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightEstimatedCost>
    {
        internal AgentInsightEstimatedCost() { }
        public double Amount { get { throw null; } }
        public string Currency { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightEstimatedCost JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightEstimatedCost PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightEstimatedCost System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightEstimatedCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightEstimatedCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightEstimatedCost System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightEstimatedCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightEstimatedCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightEstimatedCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightHighlightedTrace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightHighlightedTrace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightHighlightedTrace>
    {
        internal AgentInsightHighlightedTrace() { }
        public System.TimeSpan DurationMs { get { throw null; } }
        public string Summary { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public int? TotalTokens { get { throw null; } }
        public string TraceId { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightHighlightedTrace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightHighlightedTrace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightHighlightedTrace System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightHighlightedTrace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightHighlightedTrace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightHighlightedTrace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightHighlightedTrace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightHighlightedTrace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightHighlightedTrace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightLinkedTrace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightLinkedTrace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightLinkedTrace>
    {
        internal AgentInsightLinkedTrace() { }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public string TraceId { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightLinkedTrace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightLinkedTrace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightLinkedTrace System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightLinkedTrace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightLinkedTrace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightLinkedTrace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightLinkedTrace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightLinkedTrace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightLinkedTrace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightMonitor : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitor>
    {
        internal AgentInsightMonitor() { }
        public string AgentName { get { throw null; } }
        public Azure.AI.Projects.AgentInsightSummary AgentSummary { get { throw null; } }
        public bool Enabled { get { throw null; } }
        public Azure.AI.Projects.AgentInsightEstimatedCost EstimatedCost { get { throw null; } }
        public string Id { get { throw null; } }
        public string ModelDeploymentName { get { throw null; } }
        public System.DateTimeOffset? NextScheduledRunOn { get { throw null; } }
        public Azure.AI.Projects.AgentInsightPrioritiesRead Priorities { get { throw null; } }
        public double RunIntervalHours { get { throw null; } }
        public Azure.AI.Projects.AgentInsightSuspension Suspension { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightMonitor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AgentInsightMonitor (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AgentInsightMonitor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightMonitor System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightMonitor System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightMonitorListItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitorListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitorListItem>
    {
        internal AgentInsightMonitorListItem() { }
        public string AgentName { get { throw null; } }
        public bool Enabled { get { throw null; } }
        public Azure.AI.Projects.AgentInsightEstimatedCost EstimatedCost { get { throw null; } }
        public string Id { get { throw null; } }
        public string ModelDeploymentName { get { throw null; } }
        public System.DateTimeOffset? NextScheduledRunOn { get { throw null; } }
        public Azure.AI.Projects.AgentInsightPrioritiesRead Priorities { get { throw null; } }
        public double RunIntervalHours { get { throw null; } }
        public Azure.AI.Projects.AgentInsightSuspension Suspension { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightMonitorListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightMonitorListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightMonitorListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitorListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightMonitorListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightMonitorListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitorListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitorListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightMonitorListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightMonitors
    {
        protected AgentInsightMonitors() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CancelRun(string monitorId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightRun> CancelRun(string monitorId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CancelRunAsync(string monitorId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightRun>> CancelRunAsync(string monitorId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightMonitor> Create(string agentName, string modelDeploymentName, bool? enabled = default(bool?), double? runIntervalHours = default(double?), Azure.AI.Projects.AgentInsightPriorities priorities = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightMonitor>> CreateAsync(string agentName, string modelDeploymentName, bool? enabled = default(bool?), double? runIntervalHours = default(double?), Azure.AI.Projects.AgentInsightPriorities priorities = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult CreateRun(bool waitUntilCompleted, string monitorId, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult CreateRun(bool waitUntilCompleted, string monitorId, double? lookbackHours = default(double?), string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateRunAsync(bool waitUntilCompleted, string monitorId, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateRunAsync(bool waitUntilCompleted, string monitorId, double? lookbackHours = default(double?), string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightMonitor> Get(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AgentInsightMonitorListItem> GetAll(string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AgentInsightMonitorListItem> GetAllAsync(string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightMonitor>> GetAsync(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetInsight(string monitorId, string insightId, bool? includeDetails, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsight> GetInsight(string monitorId, string insightId, bool? includeDetails = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetInsightAsync(string monitorId, string insightId, bool? includeDetails, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsight>> GetInsightAsync(string monitorId, string insightId, bool? includeDetails = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AgentInsight> GetInsights(string monitorId, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Collections.Generic.IEnumerable<string> categories = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightSeverity> severities = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightStatus> statuses = null, bool? includeDetails = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetInsights(string monitorId, string after, string before, int? limit, string order, System.Collections.Generic.IEnumerable<string> categories, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightSeverity> severities, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightStatus> statuses, bool? includeDetails, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AgentInsight> GetInsightsAsync(string monitorId, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Collections.Generic.IEnumerable<string> categories = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightSeverity> severities = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightStatus> statuses = null, bool? includeDetails = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetInsightsAsync(string monitorId, string after, string before, int? limit, string order, System.Collections.Generic.IEnumerable<string> categories, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightSeverity> severities, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightStatus> statuses, bool? includeDetails, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult GetRun(string monitorId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightRun> GetRun(string monitorId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetRunAsync(string monitorId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AgentInsightRun>> GetRunAsync(string monitorId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AgentInsightRun> GetRuns(string monitorId, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), Azure.AI.Projects.ProjectsJobStatus? status = default(Azure.AI.Projects.ProjectsJobStatus?), Azure.AI.Projects.AgentInsightRunTrigger? trigger = default(Azure.AI.Projects.AgentInsightRunTrigger?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AgentInsightRun> GetRunsAsync(string monitorId, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), Azure.AI.Projects.ProjectsJobStatus? status = default(Azure.AI.Projects.ProjectsJobStatus?), Azure.AI.Projects.AgentInsightRunTrigger? trigger = default(Azure.AI.Projects.AgentInsightRunTrigger?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Reset(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Reset(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> ResetAsync(string monitorId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> ResetAsync(string monitorId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Update(string monitorId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAsync(string monitorId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateInsight(string monitorId, string insightId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateInsightAsync(string monitorId, string insightId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class AgentInsightPriorities : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPriorities>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPriorities>
    {
        public AgentInsightPriorities(System.Collections.Generic.IEnumerable<string> categories) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.AgentInsightPriorities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightPriorities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightPriorities System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPriorities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPriorities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightPriorities System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPriorities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPriorities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPriorities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightPrioritiesRead : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPrioritiesRead>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPrioritiesRead>
    {
        internal AgentInsightPrioritiesRead() { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public string Instructions { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightPrioritiesRead JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightPrioritiesRead PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightPrioritiesRead System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPrioritiesRead>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightPrioritiesRead>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightPrioritiesRead System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPrioritiesRead>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPrioritiesRead>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightPrioritiesRead>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentInsightPromptSurface : System.IEquatable<Azure.AI.Projects.AgentInsightPromptSurface>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentInsightPromptSurface(string value) { throw null; }
        public static Azure.AI.Projects.AgentInsightPromptSurface Instructions { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightPromptSurface Tool { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentInsightPromptSurface other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentInsightPromptSurface left, Azure.AI.Projects.AgentInsightPromptSurface right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightPromptSurface (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightPromptSurface? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentInsightPromptSurface left, Azure.AI.Projects.AgentInsightPromptSurface right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentInsightProposedFix : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFix>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFix>
    {
        internal AgentInsightProposedFix() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.AgentInsightProposedFixChange> Changes { get { throw null; } }
        public Azure.AI.Projects.AgentInsightProposedFixKind Kind { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightProposedFix JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightProposedFix PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightProposedFix System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFix>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFix>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightProposedFix System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFix>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFix>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFix>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightProposedFixChange : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFixChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFixChange>
    {
        internal AgentInsightProposedFixChange() { }
        public string Diff { get { throw null; } }
        public string Language { get { throw null; } }
        public System.BinaryData NewValue { get { throw null; } }
        public System.BinaryData OldValue { get { throw null; } }
        public string Path { get { throw null; } }
        public Azure.AI.Projects.AgentInsightPromptSurface? Surface { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightProposedFixChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightProposedFixChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightProposedFixChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFixChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightProposedFixChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightProposedFixChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFixChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFixChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightProposedFixChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentInsightProposedFixKind : System.IEquatable<Azure.AI.Projects.AgentInsightProposedFixKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentInsightProposedFixKind(string value) { throw null; }
        public static Azure.AI.Projects.AgentInsightProposedFixKind CodeChange { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightProposedFixKind PromptChange { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightProposedFixKind Prose { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentInsightProposedFixKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentInsightProposedFixKind left, Azure.AI.Projects.AgentInsightProposedFixKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightProposedFixKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightProposedFixKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentInsightProposedFixKind left, Azure.AI.Projects.AgentInsightProposedFixKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentInsightRecommendedAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRecommendedAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRecommendedAction>
    {
        internal AgentInsightRecommendedAction() { }
        public Azure.AI.Projects.AgentInsightProposedFix ProposedFix { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightRecommendedAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightRecommendedAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightRecommendedAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRecommendedAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRecommendedAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightRecommendedAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRecommendedAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRecommendedAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRecommendedAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRun>
    {
        internal AgentInsightRun() { }
        public string AgentName { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.AgentInsightRunInputs Inputs { get { throw null; } }
        public string ModelDeploymentName { get { throw null; } }
        public string MonitorId { get { throw null; } }
        public Azure.AI.Projects.AgentInsightRunResult Result { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public Azure.AI.Projects.ProjectsJobStatus Status { get { throw null; } }
        public Azure.AI.Projects.AgentInsightRunTrigger Trigger { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        public System.DateTimeOffset WindowEnd { get { throw null; } }
        public System.DateTimeOffset WindowStart { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AgentInsightRun (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AgentInsightRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightRunInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunInputs>
    {
        internal AgentInsightRunInputs() { }
        public double? LookbackHours { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightRunInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightRunInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightRunInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightRunInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightRunResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunResult>
    {
        internal AgentInsightRunResult() { }
        public int InsightsCreated { get { throw null; } }
        public int InsightsReopened { get { throw null; } }
        public int InsightsUpdated { get { throw null; } }
        public Azure.AI.Projects.AgentInsightTokenUsage TokenUsage { get { throw null; } }
        public int TracesAnalyzed { get { throw null; } }
        public int TracesInWindow { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightRunResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AgentInsightRunResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AgentInsightRunResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightRunResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightRunResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightRunResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightRunResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentInsightRunTrigger : System.IEquatable<Azure.AI.Projects.AgentInsightRunTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentInsightRunTrigger(string value) { throw null; }
        public static Azure.AI.Projects.AgentInsightRunTrigger OnDemand { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightRunTrigger Scheduled { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentInsightRunTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentInsightRunTrigger left, Azure.AI.Projects.AgentInsightRunTrigger right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightRunTrigger (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightRunTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentInsightRunTrigger left, Azure.AI.Projects.AgentInsightRunTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentInsightSeverity : System.IEquatable<Azure.AI.Projects.AgentInsightSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentInsightSeverity(string value) { throw null; }
        public static Azure.AI.Projects.AgentInsightSeverity High { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightSeverity Low { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightSeverity Medium { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentInsightSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentInsightSeverity left, Azure.AI.Projects.AgentInsightSeverity right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightSeverity (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentInsightSeverity left, Azure.AI.Projects.AgentInsightSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentInsightStatus : System.IEquatable<Azure.AI.Projects.AgentInsightStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentInsightStatus(string value) { throw null; }
        public static Azure.AI.Projects.AgentInsightStatus Active { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightStatus Ignored { get { throw null; } }
        public static Azure.AI.Projects.AgentInsightStatus Resolved { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentInsightStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentInsightStatus left, Azure.AI.Projects.AgentInsightStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentInsightStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentInsightStatus left, Azure.AI.Projects.AgentInsightStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentInsightSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSummary>
    {
        internal AgentInsightSummary() { }
        public string Markdown { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightSuspension : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSuspension>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSuspension>
    {
        internal AgentInsightSuspension() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public System.DateTimeOffset OccurredOn { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightSuspension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightSuspension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightSuspension System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSuspension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightSuspension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightSuspension System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSuspension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSuspension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightSuspension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInsightTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightTokenUsage>
    {
        internal AgentInsightTokenUsage() { }
        public int? CachedTokens { get { throw null; } }
        public int InputTokens { get { throw null; } }
        public int OutputTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.AgentInsightTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AgentInsightTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInsightTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInsightTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInsightTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInsightTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInvocationsApiDispatchPayload : Azure.AI.Projects.RoutineDispatchPayload, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>
    {
        public AgentInvocationsApiDispatchPayload(System.BinaryData input) { }
        public System.BinaryData Input { get { throw null; } }
        protected override Azure.AI.Projects.RoutineDispatchPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineDispatchPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInvocationsApiDispatchPayload System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInvocationsApiDispatchPayload System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiDispatchPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInvocationsApiRoutineAction : Azure.AI.Projects.RoutineAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>
    {
        public AgentInvocationsApiRoutineAction() { }
        public string AgentEndpointId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public System.BinaryData Input { get { throw null; } set { } }
        public string SessionId { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentInvocationsApiRoutineAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentInvocationsApiRoutineAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentInvocationsApiRoutineAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentResponsesApiDispatchPayload : Azure.AI.Projects.RoutineDispatchPayload, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>
    {
        public AgentResponsesApiDispatchPayload(System.BinaryData input) { }
        public System.BinaryData Input { get { throw null; } }
        protected override Azure.AI.Projects.RoutineDispatchPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineDispatchPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentResponsesApiDispatchPayload System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentResponsesApiDispatchPayload System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiDispatchPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentResponsesApiRoutineAction : Azure.AI.Projects.RoutineAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>
    {
        public AgentResponsesApiRoutineAction() { }
        public string AgentEndpointId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public string Conversation { get { throw null; } set { } }
        public System.BinaryData Input { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AgentResponsesApiRoutineAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentResponsesApiRoutineAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentResponsesApiRoutineAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectBlobReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>
    {
        internal AIProjectBlobReference() { }
        public System.Uri BlobUri { get { throw null; } }
        public Azure.AI.Projects.BlobReferenceSasCredential Credential { get { throw null; } }
        public string StorageAccountArmId { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectBlobReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectBlobReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectBlobReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectBlobReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectBlobReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectBlobReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectClient : System.ClientModel.Primitives.ClientConnectionProvider
    {
        protected AIProjectClient() : base (default(int)) { }
        public AIProjectClient(Azure.AI.Projects.AIProjectClientSettings settings) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) : base (default(int)) { }
        public AIProjectClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.AIProjectClientOptions options) : base (default(int)) { }
        public virtual Azure.AI.Projects.Agents.AgentAdministrationClient AgentAdministrationClient { get { throw null; } }
        public virtual Azure.AI.Projects.AgentInsightMonitors AgentInsightMonitors { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectConnectionsOperations Connections { get { throw null; } }
        public virtual Azure.AI.Projects.DataGenerationJobs DataGenerationJobs { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDatasetsOperations Datasets { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectDeploymentsOperations Deployments { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.EvaluationRules EvaluationRules { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomies EvaluationTaxonomies { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationJobs EvaluatorGenerationJobs { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.ProjectEvaluators Evaluators { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectIndexesOperations Indexes { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.ProjectInsights Insights { get { throw null; } }
        public virtual Azure.AI.Projects.Memory.AIProjectMemoryStores MemoryStores { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectModels Models { get { throw null; } }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Extensions.OpenAI.ProjectOpenAIClient ProjectOpenAIClient { get { throw null; } }
        public virtual Azure.AI.Projects.ProjectsRealtimeClient ProjectsRealtimeClient { get { throw null; } }
        public virtual Azure.AI.Projects.Evaluation.RedTeams RedTeams { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectRoutines Routines { get { throw null; } }
        public virtual Azure.AI.Projects.ProjectSchedules Schedules { get { throw null; } }
        public virtual Azure.AI.Projects.AIProjectTelemetry Telemetry { get { throw null; } }
        public virtual Azure.AI.Projects.Memory.AIProjectMemoryStores GetAIProjectMemoryStoresClient() { throw null; }
        public override System.Collections.Generic.IEnumerable<System.ClientModel.Primitives.ClientConnection> GetAllConnections() { throw null; }
        public override System.ClientModel.Primitives.ClientConnection GetConnection(string connectionId) { throw null; }
    }
    public partial class AIProjectClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V1) { }
        public string UserAgentApplicationId { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V1 = 2,
        }
    }
    public partial class AIProjectClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AIProjectClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class AIProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>
    {
        internal AIProjectConnection() { }
        public Azure.AI.Projects.AIProjectConnectionBaseCredential Credentials { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Target { get { throw null; } }
        public Azure.AI.Projects.ConnectionType Type { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectConnection (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionApiKeyCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>
    {
        internal AIProjectConnectionApiKeyCredential() { }
        public string ApiKey { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionApiKeyCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionApiKeyCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionApiKeyCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AIProjectConnectionBaseCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>
    {
        internal AIProjectConnectionBaseCredential() { }
        protected virtual Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionBaseCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionBaseCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionBaseCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionCustomCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>
    {
        internal AIProjectConnectionCustomCredential() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Keys { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionCustomCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionCustomCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionCustomCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionEntraIdCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>
    {
        internal AIProjectConnectionEntraIdCredential() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionEntraIdCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionEntraIdCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionEntraIdCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionSasCredential : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>
    {
        internal AIProjectConnectionSasCredential() { }
        public string SasToken { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectConnectionSasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectConnectionSasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectConnectionSasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectConnectionsOperations
    {
        protected AIProjectConnectionsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnection(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection> GetConnection(string connectionName, bool includeCredentials, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection> GetConnection(string connectionName, bool includeCredentials = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionAsync(string connectionName, bool includeCredentials, CancellationToken cancellationToken) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectConnection>> GetConnectionAsync(string connectionName, bool includeCredentials = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnections(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnections(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.CollectionResult GetConnections(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(ConnectionType? connectionType, bool? defaultConnection, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType, bool? defaultConnection, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectConnection> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool? defaultConnection = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetConnectionsAsync(string connectionType, bool? defaultConnection, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetConnectionsAsync(string connectionType, bool? defaultConnection, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual Azure.AI.Projects.AIProjectConnection GetDefaultConnection(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.AIProjectConnection> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType? connectionType = default(Azure.AI.Projects.ConnectionType?), bool includeCredentials = false) { throw null; }
    }
    public partial class AIProjectCosmosDBIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>
    {
        public AIProjectCosmosDBIndex() { }
        public AIProjectCosmosDBIndex(string connectionName, string databaseName, string containerName, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping) { }
        public string ConnectionName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectIndexFieldMapping FieldMapping { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectCosmosDBIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectCosmosDBIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectCosmosDBIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AIProjectDataset : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>
    {
        internal AIProjectDataset() { }
        public string ConnectionName { get { throw null; } set { } }
        public System.Uri DataUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public bool? IsReference { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectDataset (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectDatasetsOperations
    {
        protected AIProjectDatasetsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetCredentials(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential> GetCredentials(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetCredentialsAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential>> GetCredentialsAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetDataset(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDataset> GetDataset(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDatasetAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDataset>> GetDatasetAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasets(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetsAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDatasetVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDatasetVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDataset> GetDatasetVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult> PendingUpload(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult PendingUpload(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult>> PendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadConfiguration configuration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> PendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.FileDataset> UploadFile(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FileDataset>> UploadFileAsync(string name, string version, string filePath, string? connectionName = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.FolderDataset> UploadFolder(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.FolderDataset>> UploadFolderAsync(string name, string version, string folderPath, string? connectionName = null, System.Text.RegularExpressions.Regex? filePattern = null) { throw null; }
    }
    public abstract partial class AIProjectDeployment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>
    {
        internal AIProjectDeployment() { }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectDeployment (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectDeploymentsOperations
    {
        protected AIProjectDeploymentsOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult GetDeployment(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployment(string name, RequestOptions options) instead.")]
        public virtual System.ClientModel.ClientResult GetDeployment(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment> GetDeployment(string name, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment> GetDeployment(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, RequestOptions options) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetDeploymentAsync(string name, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentAsync(string name, CancellationToken cancellationToken) instead.")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment>> GetDeploymentAsync(string name, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectDeployment>> GetDeploymentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeployments(string modelPublisher, string modelName, Azure.AI.Projects.AIProjectDeploymentType? deploymentType, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeployments(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeployments(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.CollectionResult GetDeployments(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, AIProjectDeploymentType? deploymentType, CancellationToken cancellationToken) instead.")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeploymentsAsync(string modelPublisher, string modelName, Azure.AI.Projects.AIProjectDeploymentType? deploymentType, string clientRequestId, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectDeployment> GetDeploymentsAsync(string modelPublisher = null, string modelName = null, Azure.AI.Projects.AIProjectDeploymentType? deploymentType = default(Azure.AI.Projects.AIProjectDeploymentType?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as the clientRequestId parameter is not used. Please use GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, RequestOptions options) instead.")]
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDeploymentsAsync(string modelPublisher, string modelName, string deploymentType, string clientRequestId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AIProjectDeploymentType : System.IEquatable<Azure.AI.Projects.AIProjectDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AIProjectDeploymentType(string value) { throw null; }
        public static Azure.AI.Projects.AIProjectDeploymentType ModelDeployment { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AIProjectDeploymentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AIProjectDeploymentType left, Azure.AI.Projects.AIProjectDeploymentType right) { throw null; }
        public static implicit operator Azure.AI.Projects.AIProjectDeploymentType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.AIProjectDeploymentType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AIProjectDeploymentType left, Azure.AI.Projects.AIProjectDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AIProjectIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>
    {
        internal AIProjectIndex() { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.AIProjectIndex (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectIndexesOperations
    {
        protected AIProjectIndexesOperations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex> CreateOrUpdate(string name, string version, Azure.AI.Projects.AIProjectIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex>> CreateOrUpdateAsync(string name, string version, Azure.AI.Projects.AIProjectIndex index, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetIndex(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex> GetIndex(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetIndexAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.AIProjectIndex>> GetIndexAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexes(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexesAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetIndexVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetIndexVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.AIProjectIndex> GetIndexVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AIProjectIndexFieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>
    {
        public AIProjectIndexFieldMapping(System.Collections.Generic.IEnumerable<string> contentFields) { }
        public System.Collections.Generic.IList<string> ContentFields { get { throw null; } }
        public string FilepathField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> MetadataFields { get { throw null; } }
        public string TitleField { get { throw null; } set { } }
        public string UrlField { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFields { get { throw null; } }
        protected virtual Azure.AI.Projects.AIProjectIndexFieldMapping JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.AIProjectIndexFieldMapping PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AIProjectIndexFieldMapping System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AIProjectIndexFieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AIProjectIndexFieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AIProjectModels
    {
        protected AIProjectModels() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.CreateAsyncResult> CreateModelVersionRequest(string name, string version, Azure.AI.Projects.ModelVersion modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateModelVersionRequest(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.CreateAsyncResult>> CreateModelVersionRequestAsync(string name, string version, Azure.AI.Projects.ModelVersion modelVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateModelVersionRequestAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteModelVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteModelVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteModelVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteModelVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetLatestModelVersions(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.ModelVersion> GetLatestModelVersions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetLatestModelVersionsAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ModelVersion> GetLatestModelVersionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential> GetModelCredentials(string name, string version, Azure.AI.Projects.ModelCredentialRequest credentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetModelCredentials(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential>> GetModelCredentialsAsync(string name, string version, Azure.AI.Projects.ModelCredentialRequest credentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetModelCredentialsAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult GetModelVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ModelVersion> GetModelVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetModelVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ModelVersion>> GetModelVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetModelVersions(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.ModelVersion> GetModelVersions(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetModelVersionsAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ModelVersion> GetModelVersionsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ModelPendingUploadResult> StartModelPendingUpload(string name, string version, Azure.AI.Projects.ModelPendingUploadContent pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StartModelPendingUpload(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ModelPendingUploadResult>> StartModelPendingUploadAsync(string name, string version, Azure.AI.Projects.ModelPendingUploadContent pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartModelPendingUploadAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ModelVersion> UpdateModelVersion(string name, string version, Azure.AI.Projects.UpdateModelVersionOptions updateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateModelVersion(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ModelVersion>> UpdateModelVersionAsync(string name, string version, Azure.AI.Projects.UpdateModelVersionOptions updateOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateModelVersionAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Uri UploadModel(string path, string name, string version) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Uri> UploadModelAsync(string path, string name, string version) { throw null; }
    }
    public partial class AIProjectRoutines
    {
        protected AIProjectRoutines() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine> CreateOrUpdate(string name, Azure.AI.Projects.ProjectsRoutineOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine>> CreateOrUpdateAsync(string name, Azure.AI.Projects.ProjectsRoutineOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine> Disable(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine>> DisableAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DispatchRoutineResult> Dispatch(string name, Azure.AI.Projects.RoutineDispatchPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DispatchRoutineResult>> DispatchAsync(string name, Azure.AI.Projects.RoutineDispatchPayload payload = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine> Enable(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine>> EnableAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.ProjectsRoutine>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.RoutineRun> GetRoutineRuns(string routineName, string filter = null, int? limit = default(int?), string after = null, Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.RoutineRun> GetRoutineRunsAsync(string routineName, string filter = null, int? limit = default(int?), string after = null, Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.ProjectsRoutine> GetRoutines(int? limit = default(int?), string after = null, Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.ProjectsRoutine> GetRoutinesAsync(int? limit = default(int?), string after = null, Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AIProjectTelemetry
    {
        public AIProjectTelemetry(Azure.AI.Projects.AIProjectClient outerInstance) { }
        public string GetApplicationInsightsConnectionString() { throw null; }
        public System.Threading.Tasks.Task<string> GetApplicationInsightsConnectionStringAsync() { throw null; }
    }
    public partial class ArtifactProfile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ArtifactProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ArtifactProfile>
    {
        internal ArtifactProfile() { }
        public Azure.AI.Projects.FoundryModelArtifactProfileCategory Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.FoundryModelArtifactProfileSignal> Signals { get { throw null; } }
        protected virtual Azure.AI.Projects.ArtifactProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ArtifactProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ArtifactProfile System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ArtifactProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ArtifactProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ArtifactProfile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ArtifactProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ArtifactProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ArtifactProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIProjectsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsContext() { }
        public static Azure.AI.Projects.AzureAIProjectsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class AzureAIProjectsModelFactory
    {
        public static Azure.AI.Projects.Evaluation.AgentClusterInsightRequest AgentClusterInsightRequest(string agentName = null, Azure.AI.Projects.Evaluation.InsightModelConfiguration modelConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AgentClusterInsightResult AgentClusterInsightResult(Azure.AI.Projects.Evaluation.ClusterInsightResult clusterInsight = null) { throw null; }
        public static Azure.AI.Projects.AgentDataGenerationJobSource AgentDataGenerationJobSource(string description = null, string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.AgentEvaluatorGenerationJobSource AgentEvaluatorGenerationJobSource(string description = null, string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.AgentFilterTraceSource AgentFilterTraceSource(string agentId = null, string agentName = null, string agentVersion = null, System.DateTimeOffset? startsOn = default(System.DateTimeOffset?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), int? maxTraces = default(int?), Azure.AI.Projects.FilterStrategyType? filterStrategy = default(Azure.AI.Projects.FilterStrategyType?)) { throw null; }
        public static Azure.AI.Projects.AgenticIdentityPreviewCredentials AgenticIdentityPreviewCredentials() { throw null; }
        public static Azure.AI.Projects.AgentInsight AgentInsight(string id = null, string monitorId = null, string agentName = null, string agentVersion = null, string title = null, Azure.AI.Projects.AgentInsightSeverity severity = default(Azure.AI.Projects.AgentInsightSeverity), string category = null, Azure.AI.Projects.AgentInsightStatus status = default(Azure.AI.Projects.AgentInsightStatus), int traceCount = 0, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset), string description = null, Azure.AI.Projects.AgentInsightDetails details = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightDetails AgentInsightDetails(System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightHighlightedTrace> highlightedTraces = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightLinkedTrace> linkedTraces = null, Azure.AI.Projects.AgentInsightRecommendedAction recommendedActions = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightEstimatedCost AgentInsightEstimatedCost(double amount = 0) { throw null; }
        public static Azure.AI.Projects.AgentInsightHighlightedTrace AgentInsightHighlightedTrace(string traceId = null, string summary = null, System.TimeSpan durationMs = default(System.TimeSpan), int? totalTokens = default(int?), System.DateTimeOffset timestamp = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.AgentInsightLinkedTrace AgentInsightLinkedTrace(string traceId = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.AgentInsightMonitor AgentInsightMonitor(string id = null, string agentName = null, bool enabled = false, double runIntervalHours = 0, string modelDeploymentName = null, System.DateTimeOffset? nextScheduledRunOn = default(System.DateTimeOffset?), Azure.AI.Projects.AgentInsightEstimatedCost estimatedCost = null, Azure.AI.Projects.AgentInsightSuspension suspension = null, Azure.AI.Projects.AgentInsightSummary agentSummary = null, Azure.AI.Projects.AgentInsightPrioritiesRead priorities = null, System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.AgentInsightMonitorListItem AgentInsightMonitorListItem(string id = null, string agentName = null, bool enabled = false, double runIntervalHours = 0, string modelDeploymentName = null, System.DateTimeOffset? nextScheduledRunOn = default(System.DateTimeOffset?), Azure.AI.Projects.AgentInsightEstimatedCost estimatedCost = null, Azure.AI.Projects.AgentInsightSuspension suspension = null, Azure.AI.Projects.AgentInsightPrioritiesRead priorities = null, System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.AgentInsightPriorities AgentInsightPriorities(System.Collections.Generic.IEnumerable<string> categories = null, string instructions = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightPrioritiesRead AgentInsightPrioritiesRead(System.Collections.Generic.IEnumerable<string> categories = null, string instructions = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightProposedFix AgentInsightProposedFix(Azure.AI.Projects.AgentInsightProposedFixKind kind = default(Azure.AI.Projects.AgentInsightProposedFixKind), string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.AgentInsightProposedFixChange> changes = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightProposedFixChange AgentInsightProposedFixChange(string path = null, string language = null, string diff = null, Azure.AI.Projects.AgentInsightPromptSurface? surface = default(Azure.AI.Projects.AgentInsightPromptSurface?), string target = null, System.BinaryData oldValue = null, System.BinaryData newValue = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightRecommendedAction AgentInsightRecommendedAction(Azure.AI.Projects.AgentInsightProposedFix proposedFix = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightRunInputs AgentInsightRunInputs(double? lookbackHours = default(double?)) { throw null; }
        public static Azure.AI.Projects.AgentInsightRunResult AgentInsightRunResult(int tracesInWindow = 0, int tracesAnalyzed = 0, int insightsCreated = 0, int insightsUpdated = 0, int insightsReopened = 0, Azure.AI.Projects.AgentInsightTokenUsage tokenUsage = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightSummary AgentInsightSummary(string markdown = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightSuspension AgentInsightSuspension(string code = null, string message = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, System.BinaryData> details = null) { throw null; }
        public static Azure.AI.Projects.AgentInsightTokenUsage AgentInsightTokenUsage(int inputTokens = 0, int outputTokens = 0, int? cachedTokens = default(int?), int totalTokens = 0) { throw null; }
        public static Azure.AI.Projects.AgentInvocationsApiDispatchPayload AgentInvocationsApiDispatchPayload(System.BinaryData input = null) { throw null; }
        public static Azure.AI.Projects.AgentInvocationsApiRoutineAction AgentInvocationsApiRoutineAction(string agentName = null, string agentEndpointId = null, System.BinaryData input = null, string sessionId = null) { throw null; }
        public static Azure.AI.Projects.AgentResponsesApiDispatchPayload AgentResponsesApiDispatchPayload(System.BinaryData input = null) { throw null; }
        public static Azure.AI.Projects.AgentResponsesApiRoutineAction AgentResponsesApiRoutineAction(string agentName = null, string agentEndpointId = null, System.BinaryData input = null, string conversation = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AgentTaxonomyInput AgentTaxonomyInput(Azure.AI.Projects.Evaluation.EvaluationTarget target = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.RiskCategory> riskCategories = null) { throw null; }
        public static Azure.AI.Projects.AIProjectBlobReference AIProjectBlobReference(System.Uri blobUri = null, string storageAccountArmId = null, Azure.AI.Projects.BlobReferenceSasCredential credential = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnection AIProjectConnection(string name = null, string id = null, Azure.AI.Projects.ConnectionType type = default(Azure.AI.Projects.ConnectionType), string target = null, bool isDefault = false, Azure.AI.Projects.AIProjectConnectionBaseCredential credentials = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionApiKeyCredential AIProjectConnectionApiKeyCredential(string apiKey = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionBaseCredential AIProjectConnectionBaseCredential(string type = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionCustomCredential AIProjectConnectionCustomCredential(System.Collections.Generic.IReadOnlyDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionEntraIdCredential AIProjectConnectionEntraIdCredential() { throw null; }
        public static Azure.AI.Projects.AIProjectConnectionSasCredential AIProjectConnectionSasCredential(string sasToken = null) { throw null; }
        public static Azure.AI.Projects.AIProjectCosmosDBIndex AIProjectCosmosDBIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string databaseName = null, string containerName = null, Azure.AI.Projects.EmbeddingConfiguration embeddingConfiguration = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.AIProjectDataset AIProjectDataset(System.Uri dataUri = null, string type = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.AIProjectDeployment AIProjectDeployment(string type = null, string name = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndex AIProjectIndex(string type = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.AIProjectIndexFieldMapping AIProjectIndexFieldMapping(System.Collections.Generic.IEnumerable<string> contentFields = null, string filepathField = null, string titleField = null, string urlField = null, System.Collections.Generic.IEnumerable<string> vectorFields = null, System.Collections.Generic.IEnumerable<string> metadataFields = null) { throw null; }
        public static Azure.AI.Projects.ArtifactProfile ArtifactProfile(Azure.AI.Projects.FoundryModelArtifactProfileCategory category = default(Azure.AI.Projects.FoundryModelArtifactProfileCategory), System.Collections.Generic.IEnumerable<Azure.AI.Projects.FoundryModelArtifactProfileSignal> signals = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureAIAgentTarget AzureAIAgentTarget(string name = null, string version = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDescription> toolDescriptions = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureAIAgentTarget AzureAIAgentTarget(string name, string version, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDescription> toolDescriptions, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseTool> tools) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureAIModelTarget AzureAIModelTarget(string model = null, Azure.AI.Projects.Evaluation.ModelSamplingParams samplingParams = null) { throw null; }
        public static Azure.AI.Projects.AzureAISearchIndex AzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string connectionName = null, string indexName = null, Azure.AI.Projects.AIProjectIndexFieldMapping fieldMapping = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration AzureOpenAIModelConfiguration(string modelDeploymentName = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri = null) { throw null; }
        public static Azure.AI.Projects.BlobReferenceSasCredential BlobReferenceSasCredential(System.Uri sasUri, string type) { throw null; }
        public static Azure.AI.Projects.Evaluation.ChartCoordinate ChartCoordinate(int x = 0, int y = 0, int size = 0) { throw null; }
        public static Azure.AI.Projects.ChatCompletionTool ChatCompletionTool(Azure.AI.Projects.FunctionObject function = null) { throw null; }
        public static Azure.AI.Projects.Memory.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsightResult(Azure.AI.Projects.Evaluation.InsightSummary summary = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightCluster> clusters = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.ChartCoordinate> coordinates = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ClusterTokenUsage ClusterTokenUsage(int inputTokenUsage = 0, int outputTokenUsage = 0, int totalTokenUsage = 0) { throw null; }
        public static Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition CodeBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string codeText) { throw null; }
        public static Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition CodeBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, string codeText = null, string entryPoint = null, string imageTag = null, System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction ContinuousEvaluationRuleAction(string evalId, int? maxHourlyRuns) { throw null; }
        public static Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction ContinuousEvaluationRuleAction(string evalId = null, int? maxHourlyRuns = default(int?), double? samplingRate = default(double?)) { throw null; }
        public static Azure.AI.Projects.ConversationIdTraceSource ConversationIdTraceSource(System.Collections.Generic.IEnumerable<string> conversationIds = null) { throw null; }
        public static Azure.AI.Projects.ConversationsDataGenerationJobConfiguration ConversationsDataGenerationJobConfiguration(float? trainSplit = default(float?), int? maxSamples = default(int?), bool? redactPrivateContent = default(bool?), bool? generateTestCaseDescription = default(bool?), bool? generateTestCaseRubric = default(bool?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null) { throw null; }
        public static Azure.AI.Projects.CreateAsyncResult CreateAsyncResult(System.Uri location = null, System.Uri operationResult = null) { throw null; }
        public static Azure.AI.Projects.CreateChatCompletionRequestResponseFormat CreateChatCompletionRequestResponseFormat(string type = null) { throw null; }
        public static Azure.AI.Projects.CreateEvalCompletionsRunDataSource CreateEvalCompletionsRunDataSource(System.BinaryData inputMessages = null, Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams samplingParams = null, string model = null, System.BinaryData source = null) { throw null; }
        public static Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference CreateEvalCompletionsRunDataSourceInputMessagesItemReference(string itemReference = null) { throw null; }
        public static Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate CreateEvalCompletionsRunDataSourceInputMessagesTemplate(System.Collections.Generic.IEnumerable<System.BinaryData> template = null) { throw null; }
        public static Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams CreateEvalCompletionsRunDataSourceSamplingParams(Azure.AI.Projects.ReasoningEffort? reasoningEffort = default(Azure.AI.Projects.ReasoningEffort?), double? temperature = default(double?), long? maxCompletionTokens = default(long?), double? topP = default(double?), long? seed = default(long?), System.BinaryData responseFormat = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ChatCompletionTool> tools = null) { throw null; }
        public static Azure.AI.Projects.CreateEvalJsonlRunDataSource CreateEvalJsonlRunDataSource(System.BinaryData source = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.CronTrigger CronTrigger(string expression = null, string timeZone = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.CsvEvalRunDataSource CsvEvalRunDataSource(Azure.AI.Projects.EvalCsvFileIdSource source = null) { throw null; }
        public static Azure.AI.Projects.CustomRoutineTrigger CustomRoutineTrigger(string provider = null, string eventName = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule DailyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobConfiguration DataGenerationJobConfiguration(string type = null, float? trainSplit = default(float?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobInputs DataGenerationJobInputs(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources = null, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration = null, string scenario = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobOutput DataGenerationJobOutput(string type = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobResult DataGenerationJobResult(System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobOutput> outputs = null, int generatedSamples = 0, Azure.AI.Projects.DataGenerationTokenUsage tokenUsage = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationWarning> warnings = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobSource DataGenerationJobSource(string type = null, string description = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationModelOptions DataGenerationModelOptions(string model = null) { throw null; }
        public static Azure.AI.Projects.DataGenerationTokenUsage DataGenerationTokenUsage(long promptTokens = (long)0, long completionTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.DataGenerationWarning DataGenerationWarning(Azure.AI.Projects.DataGenerationWarningCode? code = default(Azure.AI.Projects.DataGenerationWarningCode?), string message = null) { throw null; }
        public static Azure.AI.Projects.DatasetCredential DatasetCredential(Azure.AI.Projects.AIProjectBlobReference blobReference = null) { throw null; }
        public static Azure.AI.Projects.DatasetDataGenerationJobOutput DatasetDataGenerationJobOutput(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.DatasetEvaluationRuleAction DatasetEvaluationRuleAction(string evalId = null, System.BinaryData source = null, Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel? evaluationLevel = default(Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel?)) { throw null; }
        public static Azure.AI.Projects.DatasetEvaluatorGenerationJobSource DatasetEvaluatorGenerationJobSource(string description = null, string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.DefinitionUpdatedDiagnosticChange DefinitionUpdatedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvaluatorFieldChange> fieldChanges = null) { throw null; }
        public static Azure.AI.Projects.Memory.DeleteMemoryStoreResponse DeleteMemoryStoreResponse(string name = null, bool isDeleted = false) { throw null; }
        public static Azure.AI.Projects.DimensionAddedDiagnosticChange DimensionAddedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, string dimensionId = null, Azure.AI.Projects.Evaluation.EvaluationsDimension after = null, System.Collections.Generic.IEnumerable<string> changedFields = null) { throw null; }
        public static Azure.AI.Projects.DimensionRemovedDiagnosticChange DimensionRemovedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, string dimensionId = null, Azure.AI.Projects.Evaluation.EvaluationsDimension before = null, System.Collections.Generic.IEnumerable<string> changedFields = null) { throw null; }
        public static Azure.AI.Projects.DimensionUpdatedDiagnosticChange DimensionUpdatedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, string dimensionId = null, Azure.AI.Projects.Evaluation.EvaluationsDimension before = null, Azure.AI.Projects.Evaluation.EvaluationsDimension after = null, System.Collections.Generic.IEnumerable<string> changedFields = null) { throw null; }
        public static Azure.AI.Projects.DispatchRoutineResult DispatchRoutineResult(string dispatchId = null, string actionCorrelationId = null, string taskId = null) { throw null; }
        public static Azure.AI.Projects.EmbeddingConfiguration EmbeddingConfiguration(string modelDeploymentName = null, string embeddingField = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition EndpointBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, string connectionName = null, Azure.AI.Projects.EndpointEvaluatorSchemaVersion? schemaVersion = default(Azure.AI.Projects.EndpointEvaluatorSchemaVersion?)) { throw null; }
        public static Azure.AI.Projects.EvalCsvFileIdSource EvalCsvFileIdSource(string id = null) { throw null; }
        public static Azure.AI.Projects.EvalItem EvalItem(Azure.AI.Projects.CreateEvalResponsesRunDataSourceInputMessagesTemplateTemplateRole role = Azure.AI.Projects.CreateEvalResponsesRunDataSourceInputMessagesTemplateTemplateRole.User, System.BinaryData content = null, Azure.AI.Projects.EvalItemType? type = default(Azure.AI.Projects.EvalItemType?)) { throw null; }
        public static Azure.AI.Projects.EvalJsonlFileContentSource EvalJsonlFileContentSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvalJsonlFileContentSourceContent> content = null) { throw null; }
        public static Azure.AI.Projects.EvalJsonlFileContentSourceContent EvalJsonlFileContentSourceContent(System.Collections.Generic.IDictionary<string, System.BinaryData> item = null, System.Collections.Generic.IDictionary<string, System.BinaryData> sample = null) { throw null; }
        public static Azure.AI.Projects.EvalJsonlFileIdSource EvalJsonlFileIdSource(string id = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalResult EvalResult(string name = null, string type = null, float score = 0f, bool isPassed = false) { throw null; }
        public static Azure.AI.Projects.EvalRunDataSource EvalRunDataSource(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultCompareItem EvalRunResultCompareItem(string treatmentRunId = null, Azure.AI.Projects.Evaluation.EvalRunResultSummary treatmentRunSummary = null, float deltaEstimate = 0f, float pValue = 0f, Azure.AI.Projects.TreatmentEffectType treatmentEffect = default(Azure.AI.Projects.TreatmentEffectType)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultComparison EvalRunResultComparison(string testingCriteria = null, string metricName = null, string evaluatorName = null, Azure.AI.Projects.Evaluation.EvalRunResultSummary baselineRunSummary = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem> compareItems = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvalRunResultSummary EvalRunResultSummary(string runId = null, int sampleCount = 0, float average = 0f, float standardDeviation = 0f) { throw null; }
        public static Azure.AI.Projects.EvalStoredCompletionsSource EvalStoredCompletionsSource(Azure.AI.Projects.Evaluation.ProjectsMetadata metadata = null, string model = null, long? createdAfter = default(long?), long? createdBefore = default(long?), long? limit = default(long?)) { throw null; }
        public static Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration EvaluationAzureStandardVoiceModelConfiguration(string name = null, float? temperature = default(float?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest EvaluationComparisonInsightRequest(string evalId = null, string baselineRunId = null, System.Collections.Generic.IEnumerable<string> treatmentRunIds = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult EvaluationComparisonInsightResult(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvalRunResultComparison> comparisons = null, string method = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationCredentialContent EvaluationCredentialContent(System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.EvaluationDataGenerationJobInputs EvaluationDataGenerationJobInputs(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources = null, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration = null, Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration outputConfiguration = null) { throw null; }
        public static Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration EvaluationDataGenerationJobOutputConfiguration(string name = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.AI.Projects.DataGenerationJobOutputWriteMode? writeMode = default(Azure.AI.Projects.DataGenerationJobOutputWriteMode?)) { throw null; }
        public static Azure.AI.Projects.EvaluationModelConfiguration EvaluationModelConfiguration(string model = null, Azure.AI.Projects.Evaluation.ModelSamplingParams samplingParams = null, Azure.AI.Projects.EvaluationVoiceModelConfiguration voiceModel = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationResultSample EvaluationResultSample(string id = null, System.Collections.Generic.IDictionary<string, System.BinaryData> features = null, System.Collections.Generic.IDictionary<string, System.BinaryData> correlationInfo = null, Azure.AI.Projects.Evaluation.EvalResult evaluationResult = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRule EvaluationRule(string id = null, string displayName = null, string description = null, Azure.AI.Projects.Evaluation.EvaluationRuleAction action = null, Azure.AI.Projects.Evaluation.EvaluationRuleFilter filter = null, Azure.AI.Projects.Evaluation.EvaluationRuleEventType eventType = default(Azure.AI.Projects.Evaluation.EvaluationRuleEventType), Azure.AI.Projects.Evaluation.ScheduleTrigger schedule = null, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? provisioningStatus = default(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus?), Azure.AI.Projects.ProjectsError error = null, bool enabled = false, System.Collections.Generic.IReadOnlyDictionary<string, string> systemData = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRule EvaluationRule(string id, string displayName, string description, Azure.AI.Projects.Evaluation.EvaluationRuleAction action, Azure.AI.Projects.Evaluation.EvaluationRuleFilter filter, Azure.AI.Projects.Evaluation.EvaluationRuleEventType eventType, bool enabled, System.Collections.Generic.IReadOnlyDictionary<string, string> systemData) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleAction EvaluationRuleAction(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleFilter EvaluationRuleFilter(string agentName = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest EvaluationRunClusterInsightRequest(string evalId = null, System.Collections.Generic.IEnumerable<string> runIds = null, Azure.AI.Projects.Evaluation.InsightModelConfiguration modelConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult EvaluationRunClusterInsightResult(Azure.AI.Projects.Evaluation.ClusterInsightResult clusterInsight = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationScheduleTask EvaluationScheduleTask(System.Collections.Generic.IDictionary<string, string> configuration = null, string evalId = null, System.BinaryData evalRun = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationsDimension EvaluationsDimension(string id = null, string description = null, bool? allowed = default(bool?), int? weight = default(int?), int? generatedWeight = default(int?), bool? isAlwaysApplicable = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationTarget EvaluationTarget(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationTaxonomy EvaluationTaxonomy(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput taxonomyInput = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomyCategory> taxonomyCategories = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput EvaluationTaxonomyInput(string type = null) { throw null; }
        public static Azure.AI.Projects.EvaluationVoiceModelConfiguration EvaluationVoiceModelConfiguration(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinition EvaluatorDefinition(string type = null, System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null) { throw null; }
        public static Azure.AI.Projects.EvaluatorDiagnostic EvaluatorDiagnostic(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, string type = null) { throw null; }
        public static Azure.AI.Projects.EvaluatorDiagnosticActor EvaluatorDiagnosticActor(string type = null, string id = null) { throw null; }
        public static Azure.AI.Projects.EvaluatorFieldChange EvaluatorFieldChange(string field = null, System.Collections.Generic.IDictionary<string, System.BinaryData> before = null, System.Collections.Generic.IDictionary<string, System.BinaryData> after = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts EvaluatorGenerationArtifacts(Azure.AI.Projects.VersionedDatasetReference reference = null, System.Collections.Generic.IEnumerable<string> datasetRowKinds = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs EvaluatorGenerationInputs(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource> sources = null, Azure.AI.Projects.EvaluatorGenerationCategory? category = default(Azure.AI.Projects.EvaluatorGenerationCategory?), string model = null, string evaluatorName = null, string evaluatorDisplayName = null, string description = null, Azure.AI.Projects.RubricScoring scoring = null, float? passThreshold = default(float?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluationsDimension> dimensions = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource EvaluatorGenerationJobSource(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage EvaluatorGenerationTokenUsage(long inputTokens = (long)0, long outputTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.EvaluatorHealthMetrics EvaluatorHealthMetrics(int nDimensions = 0, System.Collections.Generic.IEnumerable<string> dimensionIds = null, double? diversity = default(double?), double? coverage = default(double?), double negativeVsPositive = 0, double? overall = default(double?), Azure.AI.Projects.EvaluatorHealthConfidence confidence = default(Azure.AI.Projects.EvaluatorHealthConfidence), System.Collections.Generic.IEnumerable<System.Collections.Generic.IList<int>> redundantPairs = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetric EvaluatorMetric(Azure.AI.Projects.Evaluation.EvaluatorMetricType? type, Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? desirableDirection, float? minValue, float? maxValue, bool? isPrimary) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetric EvaluatorMetric(Azure.AI.Projects.Evaluation.EvaluatorMetricType? type = default(Azure.AI.Projects.Evaluation.EvaluatorMetricType?), Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? desirableDirection = default(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection?), float? minValue = default(float?), float? maxValue = default(float?), float? threshold = default(float?), bool? isPrimary = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorVersion EvaluatorVersion(string displayName, System.Collections.Generic.IDictionary<string, string> metadata, Azure.AI.Projects.EvaluatorType evaluatorType, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories, Azure.AI.Projects.Evaluation.EvaluatorDefinition definition, string createdBy, string createdAt, string modifiedAt, string id, string name, string version, string description, System.Collections.Generic.IDictionary<string, string> tags) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorVersion EvaluatorVersion(string displayName = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.EvaluatorType evaluatorType = default(Azure.AI.Projects.EvaluatorType), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel> supportedEvaluationLevels = null, Azure.AI.Projects.Evaluation.EvaluatorDefinition definition = null, Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts generationArtifacts = null, string generationJobId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.GenerationWarningType> warnings = null, string createdBy = null, string createdAt = null, string modifiedAt = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FileDataGenerationJobOutput FileDataGenerationJobOutput(string id = null, string filename = null) { throw null; }
        public static Azure.AI.Projects.FileDataGenerationJobSource FileDataGenerationJobSource(string description = null, string id = null) { throw null; }
        public static Azure.AI.Projects.FileDataset FileDataset(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FolderDataset FolderDataset(System.Uri dataUri = null, bool? isReference = default(bool?), string connectionName = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.FoundryModelWarning FoundryModelWarning(Azure.AI.Projects.FoundryModelWarningCode? code = default(Azure.AI.Projects.FoundryModelWarningCode?), string message = null) { throw null; }
        public static Azure.AI.Projects.FunctionObject FunctionObject(string description = null, string name = null, Azure.AI.Projects.FunctionParameters parameters = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Projects.FunctionParameters FunctionParameters(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.Projects.GitHubIssueRoutineTrigger GitHubIssueRoutineTrigger(string connectionId = null, string owner = null, string repository = null, Azure.AI.Projects.GitHubIssueEvent issueEvent = default(Azure.AI.Projects.GitHubIssueEvent)) { throw null; }
        public static Azure.AI.Projects.HealthComputedDiagnosticChange HealthComputedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, string generationJobId = null, Azure.AI.Projects.EvaluatorHealthMetrics health = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule HourlyRecurrenceSchedule() { throw null; }
        public static Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction HumanEvaluationPreviewRuleAction(string templateId = null) { throw null; }
        public static Azure.AI.Projects.InnerError InnerError(string code = null, Azure.AI.Projects.InnerError innererror = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightCluster InsightCluster(string id = null, string label = null, string suggestion = null, string suggestionTitle = null, string description = null, int weight = 0, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightCluster> subClusters = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.InsightSample> samples = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightModelConfiguration InsightModelConfiguration(string modelDeploymentName = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightRequest InsightRequest(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightResult InsightResult(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightSample InsightSample(string id = null, string type = null, System.Collections.Generic.IDictionary<string, System.BinaryData> features = null, System.Collections.Generic.IDictionary<string, System.BinaryData> correlationInfo = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightScheduleTask InsightScheduleTask(System.Collections.Generic.IDictionary<string, string> configuration = null, Azure.AI.Projects.Evaluation.ProjectsInsight insight = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightsMetadata InsightsMetadata(System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightSummary InsightSummary(int sampleCount = 0, int uniqueSubclusterCount = 0, int uniqueClusterCount = 0, string methodName = null, Azure.AI.Projects.Evaluation.ClusterTokenUsage usage = null) { throw null; }
        public static Azure.AI.Projects.ItemGenerationParams ItemGenerationParams(string type = null) { throw null; }
        public static Azure.AI.Projects.LoraConfig LoraConfig(int? rank = default(int?), int? alpha = default(int?), System.Collections.Generic.IEnumerable<string> targetModules = null, float? dropout = default(float?)) { throw null; }
        public static Azure.AI.Projects.ManagedAzureAISearchIndex ManagedAzureAISearchIndex(string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, string vectorStoreId = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryDeletionResult MemoryDeletionResult(string memoryId = null, bool deleted = false) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryItem MemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryOperation MemoryOperation(Azure.AI.Projects.Memory.MemoryOperationKind kind = default(Azure.AI.Projects.Memory.MemoryOperationKind), Azure.AI.Projects.Memory.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemorySearchItem MemorySearchItem(Azure.AI.Projects.Memory.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemorySearchOptions MemorySearchOptions(string scope = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items = null, string previousSearchId = null, Azure.AI.Extensions.OpenAI.MemorySearchResultOptions resultOptions = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStore MemoryStore(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string name = null, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.Memory.MemoryStoreDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition MemoryStoreDefaultDefinition(string chatModel = null, string embeddingModel = null, Azure.AI.Projects.Memory.MemoryStoreDefaultOptions options = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDefaultOptions MemoryStoreDefaultOptions(bool isUserProfileEnabled, string userProfileDetails, bool isChatSummaryEnabled) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDefaultOptions MemoryStoreDefaultOptions(bool isUserProfileEnabled = false, string userProfileDetails = null, bool isChatSummaryEnabled = false, bool? isProceduralMemoryEnabled = default(bool?), System.TimeSpan? defaultTtlSeconds = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDefinition MemoryStoreDefinition(string kind = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse MemoryStoreDeleteScopeResponse(string name = null, string scope = null, bool isDeleted = false) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreOperationUsage MemoryStoreOperationUsage(int embeddingTokens = 0, long inputTokens = (long)0, OpenAI.Responses.ResponseInputTokenUsageDetails inputTokensDetails = null, long outputTokens = (long)0, OpenAI.Responses.ResponseOutputTokenUsageDetails outputTokensDetails = null, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreSearchResponse MemoryStoreSearchResponse(string searchId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Memory.MemorySearchItem> memories = null, Azure.AI.Projects.Memory.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryUpdateOptions MemoryUpdateOptions(string scope = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items = null, string previousUpdateId = null, int? updateDelay = default(int?)) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryUpdateResultDetails MemoryUpdateResultDetails(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Memory.MemoryOperation> memoryOperations = null, Azure.AI.Projects.Memory.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Projects.ModelCredentialRequest ModelCredentialRequest(System.Uri blobUri = null) { throw null; }
        public static Azure.AI.Projects.ModelDeployment ModelDeployment(string name = null, string modelName = null, string modelVersion = null, string modelPublisher = null, System.Collections.Generic.IReadOnlyDictionary<string, string> capabilities = null, Azure.AI.Projects.ModelDeploymentSku sku = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelDeploymentSku ModelDeploymentSku(long capacity = (long)0, string family = null, string name = null, string size = null, string tier = null) { throw null; }
        public static Azure.AI.Projects.ModelPendingUploadContent ModelPendingUploadContent(string pendingUploadId = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.ModelPendingUploadResult ModelPendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference = null, string pendingUploadId = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ModelSamplingParams ModelSamplingParams(float temperature = 0f, float topP = 0f, int seed = 0, int maxCompletionTokens = 0) { throw null; }
        public static Azure.AI.Projects.ModelSourceData ModelSourceData(Azure.AI.Projects.FoundryModelSourceType? sourceType = default(Azure.AI.Projects.FoundryModelSourceType?), string jobId = null) { throw null; }
        public static Azure.AI.Projects.ModelVersion ModelVersion(System.Uri blobUri = null, Azure.AI.Projects.FoundryModelWeightType? weightType = default(Azure.AI.Projects.FoundryModelWeightType?), string baseModel = null, Azure.AI.Projects.ModelSourceData source = null, Azure.AI.Projects.LoraConfig loraConfig = null, Azure.AI.Projects.ArtifactProfile artifactProfile = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.FoundryModelWarning> warnings = null, string id = null, string name = null, string version = null, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule MonthlyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> daysOfMonth = null) { throw null; }
        public static Azure.AI.Projects.NoAuthenticationCredentials NoAuthenticationCredentials() { throw null; }
        public static Azure.AI.Projects.Evaluation.OneTimeTrigger OneTimeTrigger(System.DateTimeOffset triggerAt = default(System.DateTimeOffset), string timeZone = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId = null, string connectionName = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadConfiguration PendingUploadConfiguration(string pendingUploadId, string connectionName, Azure.AI.Projects.PendingUploadType pendingUploadType) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference = null, string pendingUploadId = null, string version = null) { throw null; }
        public static Azure.AI.Projects.PendingUploadResult PendingUploadResult(Azure.AI.Projects.AIProjectBlobReference blobReference, string pendingUploadId, string version, Azure.AI.Projects.PendingUploadType pendingUploadType) { throw null; }
        public static Azure.AI.Projects.ProceduralMemoryItem ProceduralMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Projects.ProjectsError ProjectsError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ProjectsError> details = null, Azure.AI.Projects.InnerError innererror = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsInsight ProjectsInsight(string id = null, Azure.AI.Projects.Evaluation.InsightsMetadata metadata = null, Azure.AI.Projects.Evaluation.OperationStatus state = default(Azure.AI.Projects.Evaluation.OperationStatus), string displayName = null, Azure.AI.Projects.Evaluation.InsightRequest request = null, Azure.AI.Projects.Evaluation.InsightResult result = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsMetadata ProjectsMetadata(System.Collections.Generic.IDictionary<string, string> additionalProperties = null) { throw null; }
        public static Azure.AI.Projects.ProjectsRoutine ProjectsRoutine(string name = null, string description = null, bool isEnabled = false, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.RoutineTrigger> triggers = null, Azure.AI.Projects.RoutineAction action = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsSchedule ProjectsSchedule(string id = null, string displayName = null, string description = null, bool enabled = false, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? provisioningStatus = default(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus?), Azure.AI.Projects.Evaluation.ScheduleTrigger trigger = null, Azure.AI.Projects.ProjectsScheduleTask task = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IReadOnlyDictionary<string, string> systemData = null) { throw null; }
        public static Azure.AI.Projects.ProjectsScheduleTask ProjectsScheduleTask(string type = null, System.Collections.Generic.IDictionary<string, string> configuration = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition PromptBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, string promptText = null) { throw null; }
        public static Azure.AI.Projects.PromptDataGenerationJobSource PromptDataGenerationJobSource(string description = null, string prompt = null) { throw null; }
        public static Azure.AI.Projects.PromptEvaluatorGenerationJobSource PromptEvaluatorGenerationJobSource(string description = null, string prompt = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.RecurrenceSchedule RecurrenceSchedule(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.RecurrenceTrigger RecurrenceTrigger(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string timeZone = null, int interval = 0, Azure.AI.Projects.Evaluation.RecurrenceSchedule schedule = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.RedTeam RedTeam(string name = null, string displayName = null, int? turnCount = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies = null, bool? isSimulationOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.RiskCategory> riskCategories = null, string applicationScenario = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string status = null, Azure.AI.Projects.Evaluation.TargetConfig target = null) { throw null; }
        public static Azure.AI.Projects.RedTeamItemGenerationParams RedTeamItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies = null, int numTurns = 0) { throw null; }
        public static Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams RedTeamSeedPromptsItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies = null, int numTurns = 0, Azure.AI.Projects.EvalJsonlFileContentSource source = null) { throw null; }
        public static Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams RedTeamTaxonomyItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies = null, int numTurns = 0, Azure.AI.Projects.EvalJsonlFileContentSource source = null) { throw null; }
        public static Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs ReinforcementFineTuningDataGenerationJobInputs(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources = null, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration = null, Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration outputConfiguration = null) { throw null; }
        public static Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration ReinforcementFineTuningDataGenerationJobOutputConfiguration(string name = null, Azure.AI.Projects.DataGenerationJobOutputWriteMode? writeMode = default(Azure.AI.Projects.DataGenerationJobOutputWriteMode?), string mergeFileId = null) { throw null; }
        public static Azure.AI.Projects.ResponseFormatJsonObject ResponseFormatJsonObject() { throw null; }
        public static Azure.AI.Projects.ResponseFormatJsonSchema ResponseFormatJsonSchema(Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema jsonSchema = null) { throw null; }
        public static Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema ResponseFormatJsonSchemaJsonSchema(string description = null, string name = null, object schema = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Projects.ResponseFormatText ResponseFormatText() { throw null; }
        public static Azure.AI.Projects.ResponseRetrievalItemGenerationParams ResponseRetrievalItemGenerationParams(int maxNumTurns = 0, System.Collections.Generic.IDictionary<string, string> dataMapping = null, System.BinaryData source = null) { throw null; }
        public static Azure.AI.Projects.RoutineAction RoutineAction(string type = null) { throw null; }
        public static Azure.AI.Projects.RoutineDispatchPayload RoutineDispatchPayload(string type = null) { throw null; }
        public static Azure.AI.Projects.RoutineRun RoutineRun(string id = null, System.BinaryData statusInternal = null, Azure.AI.Projects.RoutineRunPhase? phase = default(Azure.AI.Projects.RoutineRunPhase?), Azure.AI.Projects.RoutineTriggerKind? triggerType = default(Azure.AI.Projects.RoutineTriggerKind?), string triggerName = null, System.Collections.Generic.IDictionary<string, System.BinaryData> triggerEventPayload = null, Azure.AI.Projects.RoutineAttemptSource? attemptSource = default(Azure.AI.Projects.RoutineAttemptSource?), Azure.AI.Projects.RoutineActionKind? actionType = default(Azure.AI.Projects.RoutineActionKind?), string agentId = null, string agentEndpointId = null, string conversationId = null, string sessionId = null, System.DateTimeOffset? triggeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledFireOn = default(System.DateTimeOffset?), System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), string dispatchId = null, string actionCorrelationId = null, string responseId = null, string taskId = null, int? errorStatusCode = default(int?), string errorType = null, string errorMessage = null) { throw null; }
        public static Azure.AI.Projects.RoutineTrigger RoutineTrigger(string type = null) { throw null; }
        public static Azure.AI.Projects.RubricBasedEvaluatorDefinition RubricBasedEvaluatorDefinition(System.BinaryData initParameters = null, System.BinaryData dataSchema = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluationsDimension> dimensions = null, float? passThreshold = default(float?), Azure.AI.Projects.RubricScoring scoring = null) { throw null; }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarning RubricGenerationInputQualityWarning(Azure.AI.Projects.RubricGenerationInputQualityWarningCode code = default(Azure.AI.Projects.RubricGenerationInputQualityWarningCode), Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity severity = default(Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity), string message = null, Azure.AI.Projects.RubricGenerationInputQualityWarningSource source = default(Azure.AI.Projects.RubricGenerationInputQualityWarningSource), int? sourceIndex = default(int?)) { throw null; }
        public static Azure.AI.Projects.RubricScoring RubricScoring(Azure.AI.Projects.RubricScoringMode? mode = default(Azure.AI.Projects.RubricScoringMode?)) { throw null; }
        public static Azure.AI.Projects.ScheduleRoutineTrigger ScheduleRoutineTrigger(string cronExpression = null, string timeZone = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleRun ScheduleRun(string runId = null, string scheduleId = null, bool success = false, System.DateTimeOffset? triggerTime = default(System.DateTimeOffset?), string error = null, System.Collections.Generic.IReadOnlyDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleTrigger ScheduleTrigger(string type = null) { throw null; }
        public static Azure.AI.Projects.ServiceEvaluatorDiagnosticActor ServiceEvaluatorDiagnosticActor(string id = null) { throw null; }
        public static Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration SimpleQnADataGenerationJobConfiguration(float? trainSplit = default(float?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null, int maxSamples = 0, System.Collections.Generic.IEnumerable<Azure.AI.Projects.SimpleQnAFineTuningQuestionType> questionTypes = null) { throw null; }
        public static Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration SimulationSeedDataGenerationJobConfiguration(float? trainSplit = default(float?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null, int maxSamples = 0) { throw null; }
        public static Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs SupervisedFineTuningDataGenerationJobInputs(string name = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources = null, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration = null, Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration outputConfiguration = null) { throw null; }
        public static Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration SupervisedFineTuningDataGenerationJobOutputConfiguration(string name = null, Azure.AI.Projects.DataGenerationJobOutputWriteMode? writeMode = default(Azure.AI.Projects.DataGenerationJobOutputWriteMode?), string mergeFileId = null) { throw null; }
        public static Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams SyntheticDataGenerationItemGenerationParams(int samplesCount = 0, string prompt = null, string modelDeploymentName = null, string outputDatasetName = null, string outputDatasetId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvalJsonlFileIdSource> sources = null) { throw null; }
        public static Azure.AI.Projects.TargetCompletionEvalRunDataSource TargetCompletionEvalRunDataSource(Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference inputMessages = null, System.BinaryData source = null, Azure.AI.Projects.Evaluation.EvaluationTarget target = null, Azure.AI.Projects.ItemGenerationParams itemGenerationParams = null) { throw null; }
        public static Azure.AI.Projects.TargetCompletionItemGenerationParams TargetCompletionItemGenerationParams(int? maxConcurrency = default(int?)) { throw null; }
        public static Azure.AI.Projects.Evaluation.TargetConfig TargetConfig(string type = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.TaxonomyCategory TaxonomyCategory(string id = null, string name = null, string description = null, Azure.AI.Projects.Evaluation.RiskCategory riskCategory = default(Azure.AI.Projects.Evaluation.RiskCategory), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomySubCategory> subCategories = null, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.TaxonomySubCategory TaxonomySubCategory(string id = null, string name = null, string description = null, bool isEnabled = false, System.Collections.Generic.IDictionary<string, string> properties = null) { throw null; }
        public static Azure.AI.Projects.TimerRoutineTrigger TimerRoutineTrigger(System.DateTimeOffset? at = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.ToolDescription ToolDescription(string name = null, string description = null) { throw null; }
        public static Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration ToolUseFineTuningDataGenerationJobConfiguration(float? trainSplit = default(float?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null, int maxSamples = 0) { throw null; }
        public static Azure.AI.Projects.TraceEvaluationRuleAction TraceEvaluationRuleAction(string evalId = null, System.BinaryData source = null, Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel? evaluationLevel = default(Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel?)) { throw null; }
        public static Azure.AI.Projects.TraceIdTraceSource TraceIdTraceSource(System.Collections.Generic.IEnumerable<string> traceIds = null) { throw null; }
        public static Azure.AI.Projects.TracesDataGenerationJobConfiguration TracesDataGenerationJobConfiguration(float? trainSplit = default(float?), Azure.AI.Projects.DataGenerationModelOptions modelOptions = null, int? maxSamples = default(int?), bool? redactPrivateContent = default(bool?), bool? generateTestCaseRubric = default(bool?)) { throw null; }
        public static Azure.AI.Projects.TracesDataGenerationJobSource TracesDataGenerationJobSource(string description = null, string agentId = null, string agentName = null, string agentVersion = null, System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> traceIds = null) { throw null; }
        public static Azure.AI.Projects.TracesEvalRunDataSource TracesEvalRunDataSource(System.Collections.Generic.IEnumerable<string> traceIds = null, System.Collections.Generic.IEnumerable<string> conversationIds = null, string agentId = null, string agentName = null, int? lookbackHours = default(int?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), int? maxTraces = default(int?), System.TimeSpan? ingestionDelaySeconds = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Projects.TracesEvaluatorGenerationJobSource TracesEvaluatorGenerationJobSource(string description = null, string agentId = null, string agentName = null, string agentVersion = null, System.DateTimeOffset startsOn = default(System.DateTimeOffset), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> traceIds = null) { throw null; }
        public static Azure.AI.Projects.TraceSource TraceSource(string type = null) { throw null; }
        public static Azure.AI.Projects.TraceSourceEvalRunDataSource TraceSourceEvalRunDataSource(Azure.AI.Projects.TraceSource traceSource = null) { throw null; }
        public static Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource TraceSourcePreviewEvalRunDataSource(Azure.AI.Projects.TraceSource traceSource = null) { throw null; }
        public static Azure.AI.Projects.TracesPreviewEvalRunDataSource TracesPreviewEvalRunDataSource(System.Collections.Generic.IEnumerable<string> traceIds = null, System.Collections.Generic.IEnumerable<string> conversationIds = null, string agentId = null, string agentName = null, int? lookbackHours = default(int?), System.DateTimeOffset? endsOn = default(System.DateTimeOffset?), int? maxTraces = default(int?), System.TimeSpan? ingestionDelaySeconds = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Projects.UpdateModelVersionOptions UpdateModelVersionOptions(string description = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration UserConversationSimulationAudioEffectsConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Projects.UserConversationSimulationAudioEffect> effects = null, int? volumePercentage = default(int?)) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationConfiguration UserConversationSimulationConfiguration(int? maxNumTurns = default(int?), int? conversationRepetitions = default(int?), int? desiredNumTurns = default(int?), Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration audioEffects = null, Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration userBehavior = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationDefaultConfiguration UserConversationSimulationDefaultConfiguration(int? maxNumTurns = default(int?), int? conversationRepetitions = default(int?), int? desiredNumTurns = default(int?), Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration audioEffects = null, Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration userBehavior = null, bool? enableConversationDatasetGeneration = default(bool?), string outputConversationDatasetName = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration UserConversationSimulationDefaultInterruptionConfiguration() { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationEvalRunDataSource UserConversationSimulationEvalRunDataSource(System.BinaryData source = null, Azure.AI.Projects.Evaluation.EvaluationTarget target = null, Azure.AI.Projects.EvaluationModelConfiguration modelConfiguration = null, Azure.AI.Projects.UserConversationSimulationDefaultConfiguration defaultSimulationConfiguration = null, System.Collections.Generic.IDictionary<string, string> dataMapping = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource UserConversationSimulationInlineTestCasesSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.UserConversationSimulationTestCase> testCases = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration UserConversationSimulationInterruptionConfiguration(string type = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource UserConversationSimulationPreviewEvalRunDataSource(System.BinaryData source = null, Azure.AI.Projects.Evaluation.EvaluationTarget target = null, Azure.AI.Projects.EvaluationModelConfiguration modelConfiguration = null, Azure.AI.Projects.UserConversationSimulationDefaultConfiguration defaultSimulationConfiguration = null, System.Collections.Generic.IDictionary<string, string> dataMapping = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationTestCase UserConversationSimulationTestCase(string testCaseId = null, string testCaseCategory = null, string testCaseDescription = null, Azure.AI.Projects.UserConversationSimulationConfiguration simulationConfiguration = null) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration UserConversationSimulationUserBehaviorConfiguration(Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration interruption = null) { throw null; }
        public static Azure.AI.Projects.UserEvaluatorDiagnosticActor UserEvaluatorDiagnosticActor(string id = null) { throw null; }
        public static Azure.AI.Projects.Memory.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Projects.VersionCreatedDiagnosticChange VersionCreatedDiagnosticChange(string id = null, string evaluatorVersion = null, System.DateTimeOffset occurredOn = default(System.DateTimeOffset), Azure.AI.Projects.EvaluatorDiagnosticChangeType changeType = default(Azure.AI.Projects.EvaluatorDiagnosticChangeType), string explanation = null, Azure.AI.Projects.EvaluatorDiagnosticActor actor = null, string priorVersion = null, string generationJobId = null) { throw null; }
        public static Azure.AI.Projects.VersionedDatasetReference VersionedDatasetReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule WeeklyRecurrenceSchedule(System.Collections.Generic.IEnumerable<System.DayOfWeek> daysOfWeek = null) { throw null; }
    }
    public partial class AzureAISearchIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>
    {
        public AzureAISearchIndex() { }
        public AzureAISearchIndex(string connectionName, string indexName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.AIProjectIndexFieldMapping FieldMapping { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobReferenceSasCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>
    {
        internal BlobReferenceSasCredential() { }
        public System.Uri SasUri { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.BlobReferenceSasCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.BlobReferenceSasCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.BlobReferenceSasCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BlobReferenceSasCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BlobReferenceSasCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BlobReferenceSasCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatCompletionTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ChatCompletionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ChatCompletionTool>
    {
        public ChatCompletionTool(Azure.AI.Projects.FunctionObject function) { }
        public Azure.AI.Projects.FunctionObject Function { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.ChatCompletionTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ChatCompletionTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ChatCompletionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ChatCompletionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ChatCompletionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ChatCompletionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ChatCompletionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ChatCompletionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ChatCompletionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionType : System.IEquatable<Azure.AI.Projects.ConnectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionType(string value) { throw null; }
        public static Azure.AI.Projects.ConnectionType APIKey { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType ApplicationConfiguration { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType ApplicationInsights { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureAISearch { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureBlobStorage { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureOpenAI { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType AzureStorageAccount { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType CosmosDB { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType Custom { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType OpenAPI { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType RemoteA2A { get { throw null; } }
        public static Azure.AI.Projects.ConnectionType RemoteTool { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ConnectionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.ConnectionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ConnectionType left, Azure.AI.Projects.ConnectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConversationIdTraceSource : Azure.AI.Projects.TraceSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationIdTraceSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationIdTraceSource>
    {
        public ConversationIdTraceSource(System.Collections.Generic.IEnumerable<string> conversationIds) { }
        public System.Collections.Generic.IList<string> ConversationIds { get { throw null; } }
        protected override Azure.AI.Projects.TraceSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.TraceSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ConversationIdTraceSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationIdTraceSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationIdTraceSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConversationIdTraceSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationIdTraceSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationIdTraceSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationIdTraceSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationsDataGenerationJobConfiguration : Azure.AI.Projects.DataGenerationJobConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>
    {
        public ConversationsDataGenerationJobConfiguration() { }
        public bool? GenerateTestCaseDescription { get { throw null; } set { } }
        public bool? GenerateTestCaseRubric { get { throw null; } set { } }
        public int? MaxSamples { get { throw null; } set { } }
        public override Azure.AI.Projects.DataGenerationModelOptions ModelOptions { get { throw null; } set { } }
        public bool? RedactPrivateContent { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ConversationsDataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConversationsDataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConversationsDataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAsyncResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateAsyncResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateAsyncResult>
    {
        internal CreateAsyncResult() { }
        public System.Uri Location { get { throw null; } }
        public System.Uri OperationResult { get { throw null; } }
        protected virtual Azure.AI.Projects.CreateAsyncResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.CreateAsyncResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.CreateAsyncResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateAsyncResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateAsyncResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateAsyncResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateAsyncResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateAsyncResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateAsyncResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateAsyncResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CreateChatCompletionRequestResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>
    {
        internal CreateChatCompletionRequestResponseFormat() { }
        protected virtual Azure.AI.Projects.CreateChatCompletionRequestResponseFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateChatCompletionRequestResponseFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateChatCompletionRequestResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateChatCompletionRequestResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateChatCompletionRequestResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEvalCompletionsRunDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>
    {
        public CreateEvalCompletionsRunDataSource(System.BinaryData source) { }
        public System.BinaryData InputMessages { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams SamplingParams { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEvalCompletionsRunDataSourceInputMessagesItemReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>
    {
        public CreateEvalCompletionsRunDataSourceInputMessagesItemReference(string itemReference) { }
        public string ItemReference { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEvalCompletionsRunDataSourceInputMessagesTemplate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>
    {
        public CreateEvalCompletionsRunDataSourceInputMessagesTemplate(System.Collections.Generic.IEnumerable<System.BinaryData> template) { }
        public System.Collections.Generic.IList<System.BinaryData> Template { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEvalCompletionsRunDataSourceSamplingParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>
    {
        public CreateEvalCompletionsRunDataSourceSamplingParams() { }
        public long? MaxCompletionTokens { get { throw null; } set { } }
        public Azure.AI.Projects.ReasoningEffort? ReasoningEffort { get { throw null; } set { } }
        public System.BinaryData ResponseFormat { get { throw null; } set { } }
        public long? Seed { get { throw null; } set { } }
        public double? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.ChatCompletionTool> Tools { get { throw null; } }
        public double? TopP { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalCompletionsRunDataSourceSamplingParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateEvalJsonlRunDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>
    {
        public CreateEvalJsonlRunDataSource(System.BinaryData source) { }
        public System.BinaryData Source { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.CreateEvalJsonlRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.CreateEvalJsonlRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CreateEvalJsonlRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CreateEvalJsonlRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CreateEvalJsonlRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CreateEvalResponsesRunDataSourceInputMessagesTemplateTemplateRole
    {
        User = 0,
        Assistant = 1,
        System = 2,
        Developer = 3,
    }
    public partial class CsvEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CsvEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CsvEvalRunDataSource>
    {
        public CsvEvalRunDataSource(Azure.AI.Projects.EvalCsvFileIdSource source) { }
        public Azure.AI.Projects.EvalCsvFileIdSource Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CsvEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CsvEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CsvEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CsvEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CsvEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CsvEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CsvEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomRoutineTrigger : Azure.AI.Projects.RoutineTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomRoutineTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomRoutineTrigger>
    {
        public CustomRoutineTrigger(string provider, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters) { }
        public string EventName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string Provider { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.CustomRoutineTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomRoutineTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CustomRoutineTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CustomRoutineTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomRoutineTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomRoutineTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CustomRoutineTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataGenerationJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJob>
    {
        internal DataGenerationJob() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public Azure.AI.Projects.DataGenerationJobConfiguration GenerationConfiguration { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.DataGenerationJobResult Result { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.DataGenerationJobSource> Sources { get { throw null; } }
        public Azure.AI.Projects.ProjectsJobStatus Status { get { throw null; } }
        protected virtual Azure.AI.Projects.DataGenerationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DataGenerationJob (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DataGenerationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataGenerationJobConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobConfiguration>
    {
        internal DataGenerationJobConfiguration() { }
        public virtual Azure.AI.Projects.DataGenerationModelOptions ModelOptions { get { throw null; } set { } }
        public float? TrainSplit { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataGenerationJobInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobInputs>
    {
        internal DataGenerationJobInputs() { }
        public Azure.AI.Projects.DataGenerationJobConfiguration GenerationConfiguration { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.DataGenerationJobSource> Sources { get { throw null; } }
        protected virtual Azure.AI.Projects.DataGenerationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.DataGenerationJobInputs dataGenerationJobInputs) { throw null; }
        protected virtual Azure.AI.Projects.DataGenerationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataGenerationJobOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobOutput>
    {
        internal DataGenerationJobOutput() { }
        protected virtual Azure.AI.Projects.DataGenerationJobOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationJobOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJobOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJobOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataGenerationJobOutputWriteMode : System.IEquatable<Azure.AI.Projects.DataGenerationJobOutputWriteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataGenerationJobOutputWriteMode(string value) { throw null; }
        public static Azure.AI.Projects.DataGenerationJobOutputWriteMode Merge { get { throw null; } }
        public static Azure.AI.Projects.DataGenerationJobOutputWriteMode Overwrite { get { throw null; } }
        public bool Equals(Azure.AI.Projects.DataGenerationJobOutputWriteMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.DataGenerationJobOutputWriteMode left, Azure.AI.Projects.DataGenerationJobOutputWriteMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.DataGenerationJobOutputWriteMode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.DataGenerationJobOutputWriteMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.DataGenerationJobOutputWriteMode left, Azure.AI.Projects.DataGenerationJobOutputWriteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataGenerationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobResult>
    {
        internal DataGenerationJobResult() { }
        public int GeneratedSamples { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.DataGenerationJobOutput> Outputs { get { throw null; } }
        public Azure.AI.Projects.DataGenerationTokenUsage TokenUsage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.DataGenerationWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.Projects.DataGenerationJobResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DataGenerationJobResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DataGenerationJobResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationJobs
    {
        protected DataGenerationJobs() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob> Cancel(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob>> CancelAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob> Create(Azure.AI.Projects.DataGenerationJobInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, Azure.AI.Projects.DataGenerationJobInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob>> CreateAsync(Azure.AI.Projects.DataGenerationJobInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, Azure.AI.Projects.DataGenerationJobInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.DataGenerationJob> GetAll(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.DataGenerationJob> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DataGenerationJob>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class DataGenerationJobSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobSource>
    {
        internal DataGenerationJobSource() { }
        public virtual string Description { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.DataGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationModelOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationModelOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationModelOptions>
    {
        public DataGenerationModelOptions(string model) { }
        public string Model { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.DataGenerationModelOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationModelOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationModelOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationModelOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationModelOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationModelOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationModelOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationModelOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationModelOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationTokenUsage>
    {
        internal DataGenerationTokenUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.DataGenerationTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataGenerationWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationWarning>
    {
        internal DataGenerationWarning() { }
        public Azure.AI.Projects.DataGenerationWarningCode? Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.Projects.DataGenerationWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.DataGenerationWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DataGenerationWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DataGenerationWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DataGenerationWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DataGenerationWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataGenerationWarningCode : System.IEquatable<Azure.AI.Projects.DataGenerationWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataGenerationWarningCode(string value) { throw null; }
        public static Azure.AI.Projects.DataGenerationWarningCode TestCaseDescriptionGenerationIncomplete { get { throw null; } }
        public bool Equals(Azure.AI.Projects.DataGenerationWarningCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.DataGenerationWarningCode left, Azure.AI.Projects.DataGenerationWarningCode right) { throw null; }
        public static implicit operator Azure.AI.Projects.DataGenerationWarningCode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.DataGenerationWarningCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.DataGenerationWarningCode left, Azure.AI.Projects.DataGenerationWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatasetCredential : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>
    {
        internal DatasetCredential() { }
        public Azure.AI.Projects.AIProjectBlobReference BlobReference { get { throw null; } }
        protected virtual Azure.AI.Projects.DatasetCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DatasetCredential (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DatasetCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetCredential System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetCredential System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetDataGenerationJobOutput : Azure.AI.Projects.DataGenerationJobOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>
    {
        internal DatasetDataGenerationJobOutput() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJobOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetDataGenerationJobOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetDataGenerationJobOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetDataGenerationJobOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetEvaluationRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluationRuleAction>
    {
        public DatasetEvaluationRuleAction(string evalId, System.BinaryData source) { }
        public string EvalId { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel? EvaluationLevel { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetEvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetEvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatasetEvaluatorGenerationJobSource : Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>
    {
        public DatasetEvaluatorGenerationJobSource(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DatasetEvaluatorGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DatasetEvaluatorGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DatasetEvaluatorGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefinitionUpdatedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>
    {
        internal DefinitionUpdatedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.EvaluatorFieldChange> FieldChanges { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DefinitionUpdatedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DefinitionUpdatedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DefinitionUpdatedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DimensionAddedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>
    {
        internal DimensionAddedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationsDimension After { get { throw null; } }
        public System.Collections.Generic.IList<string> ChangedFields { get { throw null; } }
        public string DimensionId { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DimensionAddedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DimensionAddedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionAddedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DimensionRemovedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>
    {
        internal DimensionRemovedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationsDimension Before { get { throw null; } }
        public System.Collections.Generic.IList<string> ChangedFields { get { throw null; } }
        public string DimensionId { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DimensionRemovedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DimensionRemovedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionRemovedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DimensionUpdatedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>
    {
        internal DimensionUpdatedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationsDimension After { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationsDimension Before { get { throw null; } }
        public System.Collections.Generic.IList<string> ChangedFields { get { throw null; } }
        public string DimensionId { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DimensionUpdatedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DimensionUpdatedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DimensionUpdatedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DispatchRoutineResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DispatchRoutineResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DispatchRoutineResult>
    {
        public DispatchRoutineResult() { }
        public string ActionCorrelationId { get { throw null; } set { } }
        public string DispatchId { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.DispatchRoutineResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.DispatchRoutineResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.DispatchRoutineResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.DispatchRoutineResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DispatchRoutineResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.DispatchRoutineResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.DispatchRoutineResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DispatchRoutineResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DispatchRoutineResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.DispatchRoutineResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmbeddingConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>
    {
        public EmbeddingConfiguration(string modelDeploymentName, string embeddingField) { }
        public string EmbeddingField { get { throw null; } set { } }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.EmbeddingConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EmbeddingConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EmbeddingConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EmbeddingConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointEvaluatorSchemaVersion : System.IEquatable<Azure.AI.Projects.EndpointEvaluatorSchemaVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointEvaluatorSchemaVersion(string value) { throw null; }
        public static Azure.AI.Projects.EndpointEvaluatorSchemaVersion V001 { get { throw null; } }
        public static Azure.AI.Projects.EndpointEvaluatorSchemaVersion V002 { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EndpointEvaluatorSchemaVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EndpointEvaluatorSchemaVersion left, Azure.AI.Projects.EndpointEvaluatorSchemaVersion right) { throw null; }
        public static implicit operator Azure.AI.Projects.EndpointEvaluatorSchemaVersion (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EndpointEvaluatorSchemaVersion? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EndpointEvaluatorSchemaVersion left, Azure.AI.Projects.EndpointEvaluatorSchemaVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvalCsvFileIdSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalCsvFileIdSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalCsvFileIdSource>
    {
        public EvalCsvFileIdSource(string id) { }
        public string Id { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.EvalCsvFileIdSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalCsvFileIdSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalCsvFileIdSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalCsvFileIdSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalCsvFileIdSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalCsvFileIdSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalCsvFileIdSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalCsvFileIdSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalCsvFileIdSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalItem>
    {
        public EvalItem(Azure.AI.Projects.CreateEvalResponsesRunDataSourceInputMessagesTemplateTemplateRole role, System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.AI.Projects.CreateEvalResponsesRunDataSourceInputMessagesTemplateTemplateRole Role { get { throw null; } set { } }
        public Azure.AI.Projects.EvalItemType? Type { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.EvalItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvalItemType : System.IEquatable<Azure.AI.Projects.EvalItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvalItemType(string value) { throw null; }
        public static Azure.AI.Projects.EvalItemType Message { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvalItemType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvalItemType left, Azure.AI.Projects.EvalItemType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvalItemType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvalItemType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvalItemType left, Azure.AI.Projects.EvalItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvalJsonlFileContentSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSource>
    {
        public EvalJsonlFileContentSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvalJsonlFileContentSourceContent> content) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.EvalJsonlFileContentSourceContent> Content { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.EvalJsonlFileContentSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalJsonlFileContentSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalJsonlFileContentSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalJsonlFileContentSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalJsonlFileContentSourceContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>
    {
        public EvalJsonlFileContentSourceContent(System.Collections.Generic.IDictionary<string, System.BinaryData> item) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Item { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Sample { get { throw null; } }
        protected virtual Azure.AI.Projects.EvalJsonlFileContentSourceContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalJsonlFileContentSourceContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalJsonlFileContentSourceContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalJsonlFileContentSourceContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileContentSourceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalJsonlFileIdSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileIdSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileIdSource>
    {
        public EvalJsonlFileIdSource(string id) { }
        public string Id { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.EvalJsonlFileIdSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalJsonlFileIdSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalJsonlFileIdSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileIdSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalJsonlFileIdSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalJsonlFileIdSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileIdSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileIdSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalJsonlFileIdSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvalRunDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalRunDataSource>
    {
        internal EvalRunDataSource() { }
        protected virtual Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalStoredCompletionsSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalStoredCompletionsSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalStoredCompletionsSource>
    {
        public EvalStoredCompletionsSource() { }
        public long? CreatedAfter { get { throw null; } set { } }
        public long? CreatedBefore { get { throw null; } set { } }
        public long? Limit { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ProjectsMetadata Metadata { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.EvalStoredCompletionsSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvalStoredCompletionsSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvalStoredCompletionsSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalStoredCompletionsSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvalStoredCompletionsSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvalStoredCompletionsSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalStoredCompletionsSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalStoredCompletionsSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvalStoredCompletionsSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationAzureStandardVoiceModelConfiguration : Azure.AI.Projects.EvaluationVoiceModelConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>
    {
        public EvaluationAzureStandardVoiceModelConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvaluationVoiceModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluationVoiceModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationAzureStandardVoiceModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationDataGenerationJob : Azure.AI.Projects.DataGenerationJob, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJob>
    {
        internal EvaluationDataGenerationJob() { }
        public Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationDataGenerationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationDataGenerationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationDataGenerationJobInputs : Azure.AI.Projects.DataGenerationJobInputs, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>
    {
        public EvaluationDataGenerationJobInputs(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration) { }
        public Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationDataGenerationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationDataGenerationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationDataGenerationJobOutputConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>
    {
        public EvaluationDataGenerationJobOutputConfiguration() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.DataGenerationJobOutputWriteMode? WriteMode { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationDataGenerationJobOutputConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationModelConfiguration>
    {
        public EvaluationModelConfiguration(string model) { }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ModelSamplingParams SamplingParams { get { throw null; } set { } }
        public Azure.AI.Projects.EvaluationVoiceModelConfiguration VoiceModel { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.EvaluationModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluationModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationRuleActionType : System.IEquatable<Azure.AI.Projects.EvaluationRuleActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationRuleActionType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluationRuleActionType ContinuousEvaluation { get { throw null; } }
        public static Azure.AI.Projects.EvaluationRuleActionType DatasetEvaluation { get { throw null; } }
        public static Azure.AI.Projects.EvaluationRuleActionType HumanEvaluationPreview { get { throw null; } }
        public static Azure.AI.Projects.EvaluationRuleActionType TraceEvaluation { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluationRuleActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluationRuleActionType left, Azure.AI.Projects.EvaluationRuleActionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluationRuleActionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluationRuleActionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluationRuleActionType left, Azure.AI.Projects.EvaluationRuleActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EvaluationVoiceModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>
    {
        internal EvaluationVoiceModelConfiguration() { }
        protected virtual Azure.AI.Projects.EvaluationVoiceModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluationVoiceModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluationVoiceModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationVoiceModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationVoiceModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluatorDiagnostic : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnostic>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnostic>
    {
        internal EvaluatorDiagnostic() { }
        public Azure.AI.Projects.EvaluatorDiagnosticChangeType ChangeType { get { throw null; } }
        public string EvaluatorVersion { get { throw null; } }
        public string Explanation { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset OccurredOn { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluatorDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluatorDiagnosticActor : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnosticActor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnosticActor>
    {
        internal EvaluatorDiagnosticActor() { }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorDiagnosticActor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluatorDiagnosticActor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluatorDiagnosticActor System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnosticActor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorDiagnosticActor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorDiagnosticActor System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnosticActor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnosticActor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorDiagnosticActor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorDiagnosticChangeType : System.IEquatable<Azure.AI.Projects.EvaluatorDiagnosticChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorDiagnosticChangeType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType Generated { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType GenerationCompleted { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType HumanAdded { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType HumanCreated { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType HumanEdited { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType HumanRemoved { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType NotPresentInGeneratedRubric { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticChangeType Regenerated { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorDiagnosticChangeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorDiagnosticChangeType left, Azure.AI.Projects.EvaluatorDiagnosticChangeType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorDiagnosticChangeType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorDiagnosticChangeType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorDiagnosticChangeType left, Azure.AI.Projects.EvaluatorDiagnosticChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorDiagnosticType : System.IEquatable<Azure.AI.Projects.EvaluatorDiagnosticType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorDiagnosticType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorDiagnosticType DefinitionUpdated { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticType DimensionAdded { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticType DimensionRemoved { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticType DimensionUpdated { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticType HealthComputed { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorDiagnosticType VersionCreated { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorDiagnosticType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorDiagnosticType left, Azure.AI.Projects.EvaluatorDiagnosticType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorDiagnosticType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorDiagnosticType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorDiagnosticType left, Azure.AI.Projects.EvaluatorDiagnosticType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorFieldChange : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorFieldChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorFieldChange>
    {
        internal EvaluatorFieldChange() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> After { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Before { get { throw null; } }
        public string Field { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorFieldChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluatorFieldChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluatorFieldChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorFieldChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorFieldChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorFieldChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorFieldChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorFieldChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorFieldChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorGenerationCategory : System.IEquatable<Azure.AI.Projects.EvaluatorGenerationCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorGenerationCategory(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorGenerationCategory Quality { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorGenerationCategory Safety { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorGenerationCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorGenerationCategory left, Azure.AI.Projects.EvaluatorGenerationCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorGenerationCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorGenerationCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorGenerationCategory left, Azure.AI.Projects.EvaluatorGenerationCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorHealthConfidence : System.IEquatable<Azure.AI.Projects.EvaluatorHealthConfidence>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorHealthConfidence(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorHealthConfidence High { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorHealthConfidence Low { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorHealthConfidence Med { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorHealthConfidence other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorHealthConfidence left, Azure.AI.Projects.EvaluatorHealthConfidence right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorHealthConfidence (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorHealthConfidence? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorHealthConfidence left, Azure.AI.Projects.EvaluatorHealthConfidence right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorHealthMetrics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorHealthMetrics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorHealthMetrics>
    {
        internal EvaluatorHealthMetrics() { }
        public Azure.AI.Projects.EvaluatorHealthConfidence Confidence { get { throw null; } }
        public double? Coverage { get { throw null; } }
        public System.Collections.Generic.IList<string> DimensionIds { get { throw null; } }
        public double? Diversity { get { throw null; } }
        public int NDimensions { get { throw null; } }
        public double NegativeVsPositive { get { throw null; } }
        public double? Overall { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IList<int>> RedundantPairs { get { throw null; } }
        protected virtual Azure.AI.Projects.EvaluatorHealthMetrics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.EvaluatorHealthMetrics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.EvaluatorHealthMetrics System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorHealthMetrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorHealthMetrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorHealthMetrics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorHealthMetrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorHealthMetrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorHealthMetrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorType : System.IEquatable<Azure.AI.Projects.EvaluatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorType(string value) { throw null; }
        public static Azure.AI.Projects.EvaluatorType BuiltIn { get { throw null; } }
        public static Azure.AI.Projects.EvaluatorType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.EvaluatorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.EvaluatorType left, Azure.AI.Projects.EvaluatorType right) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.EvaluatorType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.EvaluatorType left, Azure.AI.Projects.EvaluatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileDataGenerationJobOutput : Azure.AI.Projects.DataGenerationJobOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobOutput>
    {
        internal FileDataGenerationJobOutput() { }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJobOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FileDataGenerationJobOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDataGenerationJobOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDataGenerationJobSource : Azure.AI.Projects.DataGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobSource>
    {
        public FileDataGenerationJobSource(string id) { }
        public string Id { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FileDataGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDataGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileDataset : Azure.AI.Projects.AIProjectDataset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>
    {
        public FileDataset() { }
        public FileDataset(System.Uri dataUri) { }
        protected override Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FileDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FilterStrategyType : System.IEquatable<Azure.AI.Projects.FilterStrategyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FilterStrategyType(string value) { throw null; }
        public static Azure.AI.Projects.FilterStrategyType RandomSampling { get { throw null; } }
        public static Azure.AI.Projects.FilterStrategyType SmartFiltering { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FilterStrategyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FilterStrategyType left, Azure.AI.Projects.FilterStrategyType right) { throw null; }
        public static implicit operator Azure.AI.Projects.FilterStrategyType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FilterStrategyType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FilterStrategyType left, Azure.AI.Projects.FilterStrategyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FolderDataset : Azure.AI.Projects.AIProjectDataset, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>
    {
        public FolderDataset() { }
        public FolderDataset(System.Uri dataUri) { }
        protected override Azure.AI.Projects.AIProjectDataset JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDataset PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FolderDataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FolderDataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FolderDataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FolderDataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FoundryFeaturesOptInKeys
    {
        EvaluationsV1Preview = 0,
        SchedulesV1Preview = 1,
        RedTeamsV1Preview = 2,
        InsightsV1Preview = 3,
        MemoryStoresV1Preview = 4,
        RoutinesV2Preview = 5,
        SkillsV1Preview = 6,
        DataGenerationJobsV1Preview = 7,
        ModelsV1Preview = 8,
        ModelRouterControlsV1Preview = 9,
        FinetuningSessionsV1Preview = 10,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FoundryModelArtifactProfileCategory : System.IEquatable<Azure.AI.Projects.FoundryModelArtifactProfileCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FoundryModelArtifactProfileCategory(string value) { throw null; }
        public static Azure.AI.Projects.FoundryModelArtifactProfileCategory DataOnly { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileCategory RuntimeDependent { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileCategory Unknown { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FoundryModelArtifactProfileCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FoundryModelArtifactProfileCategory left, Azure.AI.Projects.FoundryModelArtifactProfileCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelArtifactProfileCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelArtifactProfileCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FoundryModelArtifactProfileCategory left, Azure.AI.Projects.FoundryModelArtifactProfileCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FoundryModelArtifactProfileSignal : System.IEquatable<Azure.AI.Projects.FoundryModelArtifactProfileSignal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FoundryModelArtifactProfileSignal(string value) { throw null; }
        public static Azure.AI.Projects.FoundryModelArtifactProfileSignal CustomPythonCode { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileSignal DynamicOps { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileSignal NativeBinary { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileSignal PickleDeserialization { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelArtifactProfileSignal UnknownFormat { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FoundryModelArtifactProfileSignal other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FoundryModelArtifactProfileSignal left, Azure.AI.Projects.FoundryModelArtifactProfileSignal right) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelArtifactProfileSignal (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelArtifactProfileSignal? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FoundryModelArtifactProfileSignal left, Azure.AI.Projects.FoundryModelArtifactProfileSignal right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FoundryModelSourceType : System.IEquatable<Azure.AI.Projects.FoundryModelSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FoundryModelSourceType(string value) { throw null; }
        public static Azure.AI.Projects.FoundryModelSourceType LocalUpload { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelSourceType TrainingJob { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FoundryModelSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FoundryModelSourceType left, Azure.AI.Projects.FoundryModelSourceType right) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelSourceType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelSourceType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FoundryModelSourceType left, Azure.AI.Projects.FoundryModelSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FoundryModelWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FoundryModelWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FoundryModelWarning>
    {
        internal FoundryModelWarning() { }
        public Azure.AI.Projects.FoundryModelWarningCode? Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.Projects.FoundryModelWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.FoundryModelWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FoundryModelWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FoundryModelWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FoundryModelWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FoundryModelWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FoundryModelWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FoundryModelWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FoundryModelWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FoundryModelWarningCode : System.IEquatable<Azure.AI.Projects.FoundryModelWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FoundryModelWarningCode(string value) { throw null; }
        public static Azure.AI.Projects.FoundryModelWarningCode RuntimeDependentArtifact { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelWarningCode UnclassifiedArtifact { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FoundryModelWarningCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FoundryModelWarningCode left, Azure.AI.Projects.FoundryModelWarningCode right) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelWarningCode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelWarningCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FoundryModelWarningCode left, Azure.AI.Projects.FoundryModelWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FoundryModelWeightType : System.IEquatable<Azure.AI.Projects.FoundryModelWeightType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FoundryModelWeightType(string value) { throw null; }
        public static Azure.AI.Projects.FoundryModelWeightType DraftModel { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelWeightType FullWeight { get { throw null; } }
        public static Azure.AI.Projects.FoundryModelWeightType LoRA { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FoundryModelWeightType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FoundryModelWeightType left, Azure.AI.Projects.FoundryModelWeightType right) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelWeightType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.FoundryModelWeightType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FoundryModelWeightType left, Azure.AI.Projects.FoundryModelWeightType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionObject>
    {
        public FunctionObject(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.FunctionParameters Parameters { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.FunctionObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.FunctionObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FunctionObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FunctionObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionParameters>
    {
        public FunctionParameters() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.Projects.FunctionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.FunctionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.FunctionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FunctionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationWarningType : System.IEquatable<Azure.AI.Projects.GenerationWarningType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationWarningType(string value) { throw null; }
        public static Azure.AI.Projects.GenerationWarningType InputQuality { get { throw null; } }
        public bool Equals(Azure.AI.Projects.GenerationWarningType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.GenerationWarningType left, Azure.AI.Projects.GenerationWarningType right) { throw null; }
        public static implicit operator Azure.AI.Projects.GenerationWarningType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.GenerationWarningType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.GenerationWarningType left, Azure.AI.Projects.GenerationWarningType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GitHubIssueEvent : System.IEquatable<Azure.AI.Projects.GitHubIssueEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GitHubIssueEvent(string value) { throw null; }
        public static Azure.AI.Projects.GitHubIssueEvent Closed { get { throw null; } }
        public static Azure.AI.Projects.GitHubIssueEvent Opened { get { throw null; } }
        public bool Equals(Azure.AI.Projects.GitHubIssueEvent other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.GitHubIssueEvent left, Azure.AI.Projects.GitHubIssueEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.GitHubIssueEvent (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.GitHubIssueEvent? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.GitHubIssueEvent left, Azure.AI.Projects.GitHubIssueEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitHubIssueRoutineTrigger : Azure.AI.Projects.RoutineTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>
    {
        public GitHubIssueRoutineTrigger(string connectionId, string owner, string repository, Azure.AI.Projects.GitHubIssueEvent issueEvent) { }
        public string ConnectionId { get { throw null; } set { } }
        public Azure.AI.Projects.GitHubIssueEvent IssueEvent { get { throw null; } set { } }
        public string Owner { get { throw null; } set { } }
        public string Repository { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.GitHubIssueRoutineTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.GitHubIssueRoutineTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GitHubIssueRoutineTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthComputedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.HealthComputedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.HealthComputedDiagnosticChange>
    {
        internal HealthComputedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public string GenerationJobId { get { throw null; } }
        public Azure.AI.Projects.EvaluatorHealthMetrics Health { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.HealthComputedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.HealthComputedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.HealthComputedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.HealthComputedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.HealthComputedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.HealthComputedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.HealthComputedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InnerError>
    {
        internal InnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.Projects.InnerError Innererror { get { throw null; } }
        protected virtual Azure.AI.Projects.InnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.InnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.InnerError System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ItemGenerationParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ItemGenerationParams>
    {
        internal ItemGenerationParams() { }
        protected virtual Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoraConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.LoraConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.LoraConfig>
    {
        public LoraConfig() { }
        public int? Alpha { get { throw null; } set { } }
        public float? Dropout { get { throw null; } set { } }
        public int? Rank { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TargetModules { get { throw null; } }
        protected virtual Azure.AI.Projects.LoraConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.LoraConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.LoraConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.LoraConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.LoraConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.LoraConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.LoraConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.LoraConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.LoraConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedAzureAISearchIndex : Azure.AI.Projects.AIProjectIndex, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>
    {
        public ManagedAzureAISearchIndex() { }
        public ManagedAzureAISearchIndex(string vectorStoreId) { }
        public string VectorStoreId { get { throw null; } set { } }
        protected override Azure.AI.Projects.AIProjectIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ManagedAzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ManagedAzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelCredentialRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelCredentialRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelCredentialRequest>
    {
        public ModelCredentialRequest(System.Uri blobUri) { }
        public System.Uri BlobUri { get { throw null; } }
        protected virtual Azure.AI.Projects.ModelCredentialRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.ModelCredentialRequest modelCredentialRequest) { throw null; }
        protected virtual Azure.AI.Projects.ModelCredentialRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelCredentialRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelCredentialRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelCredentialRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelCredentialRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelCredentialRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelCredentialRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelCredentialRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeployment : Azure.AI.Projects.AIProjectDeployment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>
    {
        internal ModelDeployment() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Capabilities { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string ModelName { get { throw null; } }
        public string ModelPublisher { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public Azure.AI.Projects.ModelDeploymentSku Sku { get { throw null; } }
        protected override Azure.AI.Projects.AIProjectDeployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectDeployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeployment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelDeploymentSku : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>
    {
        internal ModelDeploymentSku() { }
        public long Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual Azure.AI.Projects.ModelDeploymentSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ModelDeploymentSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelDeploymentSku System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelDeploymentSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelDeploymentSku System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelDeploymentSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelPendingUploadContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadContent>
    {
        public ModelPendingUploadContent() { }
        public string ConnectionName { get { throw null; } set { } }
        public string PendingUploadId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ModelPendingUploadContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.ModelPendingUploadContent modelPendingUploadContent) { throw null; }
        protected virtual Azure.AI.Projects.ModelPendingUploadContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelPendingUploadContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelPendingUploadContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelPendingUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadResult>
    {
        internal ModelPendingUploadResult() { }
        public Azure.AI.Projects.AIProjectBlobReference BlobReference { get { throw null; } }
        public string PendingUploadId { get { throw null; } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.ModelPendingUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.ModelPendingUploadResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.ModelPendingUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelPendingUploadResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelPendingUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelPendingUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelPendingUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelSourceData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelSourceData>
    {
        public ModelSourceData() { }
        public string JobId { get { throw null; } set { } }
        public Azure.AI.Projects.FoundryModelSourceType? SourceType { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ModelSourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ModelSourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelSourceData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelSourceData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelVersion>
    {
        public ModelVersion(System.Uri blobUri) { }
        public Azure.AI.Projects.ArtifactProfile ArtifactProfile { get { throw null; } }
        public string BaseModel { get { throw null; } set { } }
        public System.Uri BlobUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.LoraConfig LoraConfig { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.ModelSourceData Source { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.FoundryModelWarning> Warnings { get { throw null; } }
        public Azure.AI.Projects.FoundryModelWeightType? WeightType { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ModelVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.ModelVersion (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.ModelVersion modelVersion) { throw null; }
        protected virtual Azure.AI.Projects.ModelVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ModelVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ModelVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ModelVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ModelVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NoAuthenticationCredentials : Azure.AI.Projects.AIProjectConnectionBaseCredential, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>
    {
        internal NoAuthenticationCredentials() { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.AIProjectConnectionBaseCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.NoAuthenticationCredentials System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.NoAuthenticationCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>
    {
        public PendingUploadConfiguration() { }
        public string ConnectionName { get { throw null; } set { } }
        public string PendingUploadId { get { throw null; } set { } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.PendingUploadConfiguration pendingUploadConfiguration) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PendingUploadResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>
    {
        internal PendingUploadResult() { }
        public Azure.AI.Projects.AIProjectBlobReference BlobReference { get { throw null; } }
        public string PendingUploadId { get { throw null; } }
        public Azure.AI.Projects.PendingUploadType PendingUploadType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.PendingUploadResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.PendingUploadResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.PendingUploadResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PendingUploadResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PendingUploadResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PendingUploadResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PendingUploadResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PendingUploadType : System.IEquatable<Azure.AI.Projects.PendingUploadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PendingUploadType(string value) { throw null; }
        public static Azure.AI.Projects.PendingUploadType BlobReference { get { throw null; } }
        public static Azure.AI.Projects.PendingUploadType None { get { throw null; } }
        public static Azure.AI.Projects.PendingUploadType TemporaryBlobReference { get { throw null; } }
        public bool Equals(Azure.AI.Projects.PendingUploadType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.PendingUploadType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.PendingUploadType left, Azure.AI.Projects.PendingUploadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProceduralMemoryItem : Azure.AI.Projects.Memory.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProceduralMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProceduralMemoryItem>
    {
        internal ProceduralMemoryItem() { }
        protected override Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ProceduralMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProceduralMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProceduralMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ProceduralMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProceduralMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProceduralMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProceduralMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectSchedules
    {
        protected ProjectSchedules() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> CreateOrUpdate(string id, Azure.AI.Projects.Evaluation.ProjectsSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string id, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule>> CreateOrUpdateAsync(string id, Azure.AI.Projects.Evaluation.ProjectsSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string id, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> GetAll(Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ProjectsSchedule> GetAllAsync(Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsSchedule>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetRun(string scheduleId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRun(string scheduleId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetRunAsync(string scheduleId, string runId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ScheduleRun>> GetRunAsync(string scheduleId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRuns(string id, Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetRuns(string id, string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ScheduleRun> GetRunsAsync(string id, Azure.AI.Projects.Evaluation.ScheduleTaskType? type = default(Azure.AI.Projects.Evaluation.ScheduleTaskType?), bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetRunsAsync(string id, string type, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    public partial class ProjectsError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsError>
    {
        internal ProjectsError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.ProjectsError> Details { get { throw null; } }
        public Azure.AI.Projects.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Projects.ProjectsError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ProjectsError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ProjectsError System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ProjectsError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectsJobStatus : System.IEquatable<Azure.AI.Projects.ProjectsJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectsJobStatus(string value) { throw null; }
        public static Azure.AI.Projects.ProjectsJobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.ProjectsJobStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.ProjectsJobStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.ProjectsJobStatus Queued { get { throw null; } }
        public static Azure.AI.Projects.ProjectsJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ProjectsJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ProjectsJobStatus left, Azure.AI.Projects.ProjectsJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.ProjectsJobStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.ProjectsJobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ProjectsJobStatus left, Azure.AI.Projects.ProjectsJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectsRealtimeClient : OpenAI.Realtime.RealtimeClient
    {
        protected ProjectsRealtimeClient() { }
        public override System.Threading.Tasks.Task<OpenAI.Realtime.RealtimeSessionClient> StartSessionAsync(string model, string intent, OpenAI.Realtime.RealtimeSessionClientOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectsRealtimeSessionClient : OpenAI.Realtime.RealtimeSessionClient
    {
        protected ProjectsRealtimeSessionClient() : base (default(System.ClientModel.ApiKeyCredential), default(System.Uri), default(string), default(string), default(OpenAI.Realtime.RealtimeClient)) { }
        protected override System.Threading.Tasks.Task ConnectAsync(string queryString = null, System.Collections.Generic.IDictionary<string, string> headers = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectsRealtimeSessionClientOptions : OpenAI.Realtime.RealtimeSessionClientOptions
    {
        public ProjectsRealtimeSessionClientOptions() { }
        public Azure.AI.Projects.Agents.VoiceAgentTransport? Transport { get { throw null; } set { } }
    }
    public partial class ProjectsRoutine : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsRoutine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsRoutine>
    {
        internal ProjectsRoutine() { }
        public Azure.AI.Projects.RoutineAction Action { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public bool IsEnabled { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.RoutineTrigger> Triggers { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.ProjectsRoutine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.ProjectsRoutine (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.ProjectsRoutine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ProjectsRoutine System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsRoutine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsRoutine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ProjectsRoutine System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsRoutine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsRoutine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsRoutine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsRoutineOptions
    {
        public ProjectsRoutineOptions(Azure.AI.Projects.RoutineAction action, string description = null, bool? enabled = default(bool?)) { }
        public Azure.AI.Projects.RoutineAction Action { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.Collections.Generic.Dictionary<string, Azure.AI.Projects.RoutineTrigger> Triggers { get { throw null; } }
    }
    public abstract partial class ProjectsScheduleTask : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>
    {
        internal ProjectsScheduleTask() { }
        public System.Collections.Generic.IDictionary<string, string> Configuration { get { throw null; } }
        protected virtual Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ProjectsScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ProjectsScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ProjectsScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ProjectsScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptDataGenerationJobSource : Azure.AI.Projects.DataGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptDataGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptDataGenerationJobSource>
    {
        public PromptDataGenerationJobSource(string prompt) { }
        public override string Description { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PromptDataGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptDataGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptDataGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PromptDataGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptDataGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptDataGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptDataGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptEvaluatorGenerationJobSource : Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>
    {
        public PromptEvaluatorGenerationJobSource(string prompt) { }
        public string Description { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.PromptEvaluatorGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.PromptEvaluatorGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.PromptEvaluatorGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasoningEffort : System.IEquatable<Azure.AI.Projects.ReasoningEffort>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasoningEffort(string value) { throw null; }
        public static Azure.AI.Projects.ReasoningEffort High { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort Low { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort Max { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort Medium { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort Minimal { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort None { get { throw null; } }
        public static Azure.AI.Projects.ReasoningEffort Xhigh { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ReasoningEffort other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ReasoningEffort left, Azure.AI.Projects.ReasoningEffort right) { throw null; }
        public static implicit operator Azure.AI.Projects.ReasoningEffort (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.ReasoningEffort? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ReasoningEffort left, Azure.AI.Projects.ReasoningEffort right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RedTeamItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamItemGenerationParams>
    {
        public RedTeamItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies, int numTurns) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.AttackStrategy> AttackStrategies { get { throw null; } }
        public int NumTurns { get { throw null; } set { } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RedTeamItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeamItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeamSeedPromptsItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>
    {
        public RedTeamSeedPromptsItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies, int numTurns, Azure.AI.Projects.EvalJsonlFileContentSource source) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.AttackStrategy> AttackStrategies { get { throw null; } }
        public int NumTurns { get { throw null; } set { } }
        public Azure.AI.Projects.EvalJsonlFileContentSource Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamSeedPromptsItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeamTaxonomyItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>
    {
        public RedTeamTaxonomyItemGenerationParams(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.AttackStrategy> attackStrategies, int numTurns, Azure.AI.Projects.EvalJsonlFileContentSource source) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.AttackStrategy> AttackStrategies { get { throw null; } }
        public int NumTurns { get { throw null; } set { } }
        public Azure.AI.Projects.EvalJsonlFileContentSource Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RedTeamTaxonomyItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReinforcementFineTuningDataGenerationJob : Azure.AI.Projects.DataGenerationJob, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>
    {
        internal ReinforcementFineTuningDataGenerationJob() { }
        public Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReinforcementFineTuningDataGenerationJobInputs : Azure.AI.Projects.DataGenerationJobInputs, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>
    {
        public ReinforcementFineTuningDataGenerationJobInputs(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration) { }
        public Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReinforcementFineTuningDataGenerationJobOutputConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>
    {
        public ReinforcementFineTuningDataGenerationJobOutputConfiguration(string name) { }
        public string MergeFileId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.DataGenerationJobOutputWriteMode? WriteMode { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ReinforcementFineTuningDataGenerationJobOutputConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonObject>
    {
        public ResponseFormatJsonObject() { }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.ResponseFormatJsonObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ResponseFormatJsonObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseFormatJsonObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchema : Azure.AI.Projects.CreateChatCompletionRequestResponseFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>
    {
        public ResponseFormatJsonSchema(Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema jsonSchema) { }
        public Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema JsonSchema { get { throw null; } set { } }
        protected override Azure.AI.Projects.CreateChatCompletionRequestResponseFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.CreateChatCompletionRequestResponseFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchemaJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>
    {
        public ResponseFormatJsonSchemaJsonSchema(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public object Schema { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatText : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatText>
    {
        public ResponseFormatText() { }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.ResponseFormatText JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ResponseFormatText PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseFormatText System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatText System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseRetrievalItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>
    {
        public ResponseRetrievalItemGenerationParams(int maxNumTurns, System.Collections.Generic.IDictionary<string, string> dataMapping, System.BinaryData source) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public int MaxNumTurns { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ResponseRetrievalItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseRetrievalItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseRetrievalItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RoutineAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineAction>
    {
        internal RoutineAction() { }
        protected virtual Azure.AI.Projects.RoutineAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RoutineAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RoutineAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RoutineAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutineActionKind : System.IEquatable<Azure.AI.Projects.RoutineActionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutineActionKind(string value) { throw null; }
        public static Azure.AI.Projects.RoutineActionKind InvokeAgentInvocationsApi { get { throw null; } }
        public static Azure.AI.Projects.RoutineActionKind InvokeAgentResponsesApi { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RoutineActionKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RoutineActionKind left, Azure.AI.Projects.RoutineActionKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineActionKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineActionKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RoutineActionKind left, Azure.AI.Projects.RoutineActionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutineAttemptSource : System.IEquatable<Azure.AI.Projects.RoutineAttemptSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutineAttemptSource(string value) { throw null; }
        public static Azure.AI.Projects.RoutineAttemptSource EventFire { get { throw null; } }
        public static Azure.AI.Projects.RoutineAttemptSource ManualDispatch { get { throw null; } }
        public static Azure.AI.Projects.RoutineAttemptSource QueuedDispatch { get { throw null; } }
        public static Azure.AI.Projects.RoutineAttemptSource ScheduleDelivery { get { throw null; } }
        public static Azure.AI.Projects.RoutineAttemptSource TimerDelivery { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RoutineAttemptSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RoutineAttemptSource left, Azure.AI.Projects.RoutineAttemptSource right) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineAttemptSource (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineAttemptSource? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RoutineAttemptSource left, Azure.AI.Projects.RoutineAttemptSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RoutineDispatchPayload : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineDispatchPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineDispatchPayload>
    {
        internal RoutineDispatchPayload() { }
        protected virtual Azure.AI.Projects.RoutineDispatchPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RoutineDispatchPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RoutineDispatchPayload System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineDispatchPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineDispatchPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RoutineDispatchPayload System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineDispatchPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineDispatchPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineDispatchPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoutineRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineRun>
    {
        internal RoutineRun() { }
        public string ActionCorrelationId { get { throw null; } }
        public Azure.AI.Projects.RoutineActionKind? ActionType { get { throw null; } }
        public string AgentEndpointId { get { throw null; } }
        public string AgentId { get { throw null; } }
        public Azure.AI.Projects.RoutineAttemptSource? AttemptSource { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public string DispatchId { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? ErrorStatusCode { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.RoutineRunPhase? Phase { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public System.DateTimeOffset? ScheduledFireOn { get { throw null; } }
        public string SessionId { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public string Status { get { throw null; } }
        public string TaskId { get { throw null; } }
        public System.DateTimeOffset? TriggeredOn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> TriggerEventPayload { get { throw null; } }
        public string TriggerName { get { throw null; } }
        public Azure.AI.Projects.RoutineTriggerKind? TriggerType { get { throw null; } }
        protected virtual Azure.AI.Projects.RoutineRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RoutineRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RoutineRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RoutineRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutineRunPhase : System.IEquatable<Azure.AI.Projects.RoutineRunPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutineRunPhase(string value) { throw null; }
        public static Azure.AI.Projects.RoutineRunPhase Completed { get { throw null; } }
        public static Azure.AI.Projects.RoutineRunPhase Dispatching { get { throw null; } }
        public static Azure.AI.Projects.RoutineRunPhase Failed { get { throw null; } }
        public static Azure.AI.Projects.RoutineRunPhase Queued { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RoutineRunPhase other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RoutineRunPhase left, Azure.AI.Projects.RoutineRunPhase right) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineRunPhase (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineRunPhase? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RoutineRunPhase left, Azure.AI.Projects.RoutineRunPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RoutineTrigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineTrigger>
    {
        internal RoutineTrigger() { }
        protected virtual Azure.AI.Projects.RoutineTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RoutineTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RoutineTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RoutineTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RoutineTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RoutineTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutineTriggerKind : System.IEquatable<Azure.AI.Projects.RoutineTriggerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutineTriggerKind(string value) { throw null; }
        public static Azure.AI.Projects.RoutineTriggerKind Custom { get { throw null; } }
        public static Azure.AI.Projects.RoutineTriggerKind GithubIssue { get { throw null; } }
        public static Azure.AI.Projects.RoutineTriggerKind Schedule { get { throw null; } }
        public static Azure.AI.Projects.RoutineTriggerKind Timer { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RoutineTriggerKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RoutineTriggerKind left, Azure.AI.Projects.RoutineTriggerKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineTriggerKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RoutineTriggerKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RoutineTriggerKind left, Azure.AI.Projects.RoutineTriggerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RubricBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>
    {
        public RubricBasedEvaluatorDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluationsDimension> dimensions) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluationsDimension> Dimensions { get { throw null; } }
        public float? PassThreshold { get { throw null; } set { } }
        public Azure.AI.Projects.RubricScoring Scoring { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RubricBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RubricBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RubricGenerationInputQualityWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>
    {
        internal RubricGenerationInputQualityWarning() { }
        public Azure.AI.Projects.RubricGenerationInputQualityWarningCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity Severity { get { throw null; } }
        public Azure.AI.Projects.RubricGenerationInputQualityWarningSource Source { get { throw null; } }
        public int? SourceIndex { get { throw null; } }
        protected virtual Azure.AI.Projects.RubricGenerationInputQualityWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RubricGenerationInputQualityWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RubricGenerationInputQualityWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RubricGenerationInputQualityWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricGenerationInputQualityWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RubricGenerationInputQualityWarningCode : System.IEquatable<Azure.AI.Projects.RubricGenerationInputQualityWarningCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RubricGenerationInputQualityWarningCode(string value) { throw null; }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode EmptyAgentInstructions { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode EmptyDatasetContent { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode EmptyPrompt { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode InsufficientTotalInput { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode LowTraceCount { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode ShortAgentInstructions { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode ShortDatasetContent { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningCode ShortPrompt { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RubricGenerationInputQualityWarningCode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RubricGenerationInputQualityWarningCode left, Azure.AI.Projects.RubricGenerationInputQualityWarningCode right) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningCode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningCode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RubricGenerationInputQualityWarningCode left, Azure.AI.Projects.RubricGenerationInputQualityWarningCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RubricGenerationInputQualityWarningSeverity : System.IEquatable<Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RubricGenerationInputQualityWarningSeverity(string value) { throw null; }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity Warning { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity left, Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity right) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity left, Azure.AI.Projects.RubricGenerationInputQualityWarningSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RubricGenerationInputQualityWarningSource : System.IEquatable<Azure.AI.Projects.RubricGenerationInputQualityWarningSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RubricGenerationInputQualityWarningSource(string value) { throw null; }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningSource Agent { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningSource Aggregate { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningSource Dataset { get { throw null; } }
        public static Azure.AI.Projects.RubricGenerationInputQualityWarningSource Prompt { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RubricGenerationInputQualityWarningSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RubricGenerationInputQualityWarningSource left, Azure.AI.Projects.RubricGenerationInputQualityWarningSource right) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningSource (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricGenerationInputQualityWarningSource? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RubricGenerationInputQualityWarningSource left, Azure.AI.Projects.RubricGenerationInputQualityWarningSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RubricScoring : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricScoring>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricScoring>
    {
        public RubricScoring() { }
        public Azure.AI.Projects.RubricScoringMode? Mode { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.RubricScoring JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.RubricScoring PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.RubricScoring System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricScoring>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RubricScoring>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RubricScoring System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricScoring>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricScoring>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RubricScoring>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RubricScoringMode : System.IEquatable<Azure.AI.Projects.RubricScoringMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RubricScoringMode(string value) { throw null; }
        public static Azure.AI.Projects.RubricScoringMode Boolean { get { throw null; } }
        public static Azure.AI.Projects.RubricScoringMode Likert { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RubricScoringMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RubricScoringMode left, Azure.AI.Projects.RubricScoringMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricScoringMode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.RubricScoringMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RubricScoringMode left, Azure.AI.Projects.RubricScoringMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleRoutineTrigger : Azure.AI.Projects.RoutineTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ScheduleRoutineTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ScheduleRoutineTrigger>
    {
        public ScheduleRoutineTrigger(string cronExpression, string timeZone) { }
        public string CronExpression { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ScheduleRoutineTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ScheduleRoutineTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ScheduleRoutineTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ScheduleRoutineTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ScheduleRoutineTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ScheduleRoutineTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ScheduleRoutineTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceEvaluatorDiagnosticActor : Azure.AI.Projects.EvaluatorDiagnosticActor, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>
    {
        internal ServiceEvaluatorDiagnosticActor() { }
        protected override Azure.AI.Projects.EvaluatorDiagnosticActor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnosticActor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ServiceEvaluatorDiagnosticActor System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ServiceEvaluatorDiagnosticActor System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ServiceEvaluatorDiagnosticActor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimpleQnADataGenerationJobConfiguration : Azure.AI.Projects.DataGenerationJobConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>
    {
        public SimpleQnADataGenerationJobConfiguration(int maxSamples) { }
        public int MaxSamples { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.SimpleQnAFineTuningQuestionType> QuestionTypes { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimpleQnADataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SimpleQnAFineTuningQuestionType : System.IEquatable<Azure.AI.Projects.SimpleQnAFineTuningQuestionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SimpleQnAFineTuningQuestionType(string value) { throw null; }
        public static Azure.AI.Projects.SimpleQnAFineTuningQuestionType LongAnswer { get { throw null; } }
        public static Azure.AI.Projects.SimpleQnAFineTuningQuestionType ShortAnswer { get { throw null; } }
        public bool Equals(Azure.AI.Projects.SimpleQnAFineTuningQuestionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.SimpleQnAFineTuningQuestionType left, Azure.AI.Projects.SimpleQnAFineTuningQuestionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.SimpleQnAFineTuningQuestionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.SimpleQnAFineTuningQuestionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.SimpleQnAFineTuningQuestionType left, Azure.AI.Projects.SimpleQnAFineTuningQuestionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SimulationSeedDataGenerationJobConfiguration : Azure.AI.Projects.DataGenerationJobConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>
    {
        public SimulationSeedDataGenerationJobConfiguration(int maxSamples) { }
        public int MaxSamples { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SimulationSeedDataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupervisedFineTuningDataGenerationJob : Azure.AI.Projects.DataGenerationJob, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>
    {
        internal SupervisedFineTuningDataGenerationJob() { }
        public Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupervisedFineTuningDataGenerationJobInputs : Azure.AI.Projects.DataGenerationJobInputs, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>
    {
        public SupervisedFineTuningDataGenerationJobInputs(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.DataGenerationJobSource> sources, Azure.AI.Projects.DataGenerationJobConfiguration generationConfiguration) { }
        public Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration OutputConfiguration { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupervisedFineTuningDataGenerationJobOutputConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>
    {
        public SupervisedFineTuningDataGenerationJobOutputConfiguration(string name) { }
        public string MergeFileId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.DataGenerationJobOutputWriteMode? WriteMode { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SupervisedFineTuningDataGenerationJobOutputConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SyntheticDataGenerationItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>
    {
        public SyntheticDataGenerationItemGenerationParams(int samplesCount, string modelDeploymentName, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvalJsonlFileIdSource> sources) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        public string OutputDatasetId { get { throw null; } }
        public string OutputDatasetName { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public int SamplesCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.EvalJsonlFileIdSource> Sources { get { throw null; } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SyntheticDataGenerationItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetCompletionEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>
    {
        public TargetCompletionEvalRunDataSource(System.BinaryData source, Azure.AI.Projects.Evaluation.EvaluationTarget target) { }
        public Azure.AI.Projects.CreateEvalCompletionsRunDataSourceInputMessagesItemReference InputMessages { get { throw null; } set { } }
        public Azure.AI.Projects.ItemGenerationParams ItemGenerationParams { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationTarget Target { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TargetCompletionEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TargetCompletionEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetCompletionItemGenerationParams : Azure.AI.Projects.ItemGenerationParams, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>
    {
        public TargetCompletionItemGenerationParams() { }
        public int? MaxConcurrency { get { throw null; } set { } }
        protected override Azure.AI.Projects.ItemGenerationParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ItemGenerationParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TargetCompletionItemGenerationParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TargetCompletionItemGenerationParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TargetCompletionItemGenerationParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TimerRoutineTrigger : Azure.AI.Projects.RoutineTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TimerRoutineTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TimerRoutineTrigger>
    {
        public TimerRoutineTrigger() { }
        public System.DateTimeOffset? At { get { throw null; } set { } }
        protected override Azure.AI.Projects.RoutineTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.RoutineTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TimerRoutineTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TimerRoutineTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TimerRoutineTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TimerRoutineTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TimerRoutineTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TimerRoutineTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TimerRoutineTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolDescription : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>
    {
        public ToolDescription() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.ToolDescription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.ToolDescription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ToolDescription System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolDescription System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolUseFineTuningDataGenerationJobConfiguration : Azure.AI.Projects.DataGenerationJobConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>
    {
        public ToolUseFineTuningDataGenerationJobConfiguration(int maxSamples) { }
        public int MaxSamples { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolUseFineTuningDataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TraceEvaluationRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceEvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceEvaluationRuleAction>
    {
        public TraceEvaluationRuleAction(string evalId, System.BinaryData source) { }
        public string EvalId { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel? EvaluationLevel { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TraceEvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceEvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceEvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TraceEvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceEvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceEvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceEvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TraceIdTraceSource : Azure.AI.Projects.TraceSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceIdTraceSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceIdTraceSource>
    {
        public TraceIdTraceSource(System.Collections.Generic.IEnumerable<string> traceIds) { }
        public System.Collections.Generic.IList<string> TraceIds { get { throw null; } }
        protected override Azure.AI.Projects.TraceSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.TraceSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TraceIdTraceSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceIdTraceSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceIdTraceSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TraceIdTraceSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceIdTraceSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceIdTraceSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceIdTraceSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TracesDataGenerationJobConfiguration : Azure.AI.Projects.DataGenerationJobConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>
    {
        public TracesDataGenerationJobConfiguration() { }
        public bool? GenerateTestCaseRubric { get { throw null; } set { } }
        public int? MaxSamples { get { throw null; } set { } }
        public bool? RedactPrivateContent { get { throw null; } set { } }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TracesDataGenerationJobConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TracesDataGenerationJobConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TracesDataGenerationJobSource : Azure.AI.Projects.DataGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobSource>
    {
        public TracesDataGenerationJobSource(System.DateTimeOffset startsOn) { }
        public string AgentId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public override string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TraceIds { get { throw null; } }
        protected override Azure.AI.Projects.DataGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.DataGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TracesDataGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesDataGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TracesDataGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesDataGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TracesEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvalRunDataSource>
    {
        public TracesEvalRunDataSource() { }
        public string AgentId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ConversationIds { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public System.TimeSpan? IngestionDelaySeconds { get { throw null; } set { } }
        public int? LookbackHours { get { throw null; } set { } }
        public int? MaxTraces { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TraceIds { get { throw null; } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TracesEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TracesEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TracesEvaluatorGenerationJobSource : Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>
    {
        public TracesEvaluatorGenerationJobSource(System.DateTimeOffset startsOn) { }
        public string AgentId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public System.DateTimeOffset StartsOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TraceIds { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TracesEvaluatorGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TracesEvaluatorGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesEvaluatorGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TraceSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSource>
    {
        internal TraceSource() { }
        protected virtual Azure.AI.Projects.TraceSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.TraceSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TraceSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TraceSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TraceSourceEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>
    {
        public TraceSourceEvalRunDataSource() { }
        public Azure.AI.Projects.TraceSource TraceSource { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TraceSourceEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TraceSourceEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourceEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TraceSourcePreviewEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>
    {
        public TraceSourcePreviewEvalRunDataSource() { }
        public Azure.AI.Projects.TraceSource TraceSource { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TraceSourcePreviewEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TracesPreviewEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>
    {
        public TracesPreviewEvalRunDataSource() { }
        public string AgentId { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ConversationIds { get { throw null; } }
        public System.DateTimeOffset? EndsOn { get { throw null; } set { } }
        public System.TimeSpan? IngestionDelaySeconds { get { throw null; } set { } }
        public int? LookbackHours { get { throw null; } set { } }
        public int? MaxTraces { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TraceIds { get { throw null; } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.TracesPreviewEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TracesPreviewEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TracesPreviewEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TreatmentEffectType : System.IEquatable<Azure.AI.Projects.TreatmentEffectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TreatmentEffectType(string value) { throw null; }
        public static Azure.AI.Projects.TreatmentEffectType Changed { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Degraded { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Improved { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType Inconclusive { get { throw null; } }
        public static Azure.AI.Projects.TreatmentEffectType TooFewSamples { get { throw null; } }
        public bool Equals(Azure.AI.Projects.TreatmentEffectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.TreatmentEffectType left, Azure.AI.Projects.TreatmentEffectType right) { throw null; }
        public static implicit operator Azure.AI.Projects.TreatmentEffectType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.TreatmentEffectType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.TreatmentEffectType left, Azure.AI.Projects.TreatmentEffectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateModelVersionOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateModelVersionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateModelVersionOptions>
    {
        public UpdateModelVersionOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.AI.Projects.UpdateModelVersionOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UpdateModelVersionOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UpdateModelVersionOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateModelVersionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateModelVersionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateModelVersionOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateModelVersionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateModelVersionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateModelVersionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserConversationSimulationAudioEffect : System.IEquatable<Azure.AI.Projects.UserConversationSimulationAudioEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserConversationSimulationAudioEffect(string value) { throw null; }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffect BackgroundTv { get { throw null; } }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffect CrowdChatter { get { throw null; } }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffect MetroStation { get { throw null; } }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffect StreetTraffic { get { throw null; } }
        public static Azure.AI.Projects.UserConversationSimulationAudioEffect TelephonicVoice { get { throw null; } }
        public bool Equals(Azure.AI.Projects.UserConversationSimulationAudioEffect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.UserConversationSimulationAudioEffect left, Azure.AI.Projects.UserConversationSimulationAudioEffect right) { throw null; }
        public static implicit operator Azure.AI.Projects.UserConversationSimulationAudioEffect (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.UserConversationSimulationAudioEffect? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.UserConversationSimulationAudioEffect left, Azure.AI.Projects.UserConversationSimulationAudioEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserConversationSimulationAudioEffectsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>
    {
        public UserConversationSimulationAudioEffectsConfiguration() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.UserConversationSimulationAudioEffect> Effects { get { throw null; } }
        public int? VolumePercentage { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationConfiguration>
    {
        public UserConversationSimulationConfiguration() { }
        public Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration AudioEffects { get { throw null; } set { } }
        public int? ConversationRepetitions { get { throw null; } set { } }
        public int? DesiredNumTurns { get { throw null; } set { } }
        public int? MaxNumTurns { get { throw null; } set { } }
        public Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration UserBehavior { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.UserConversationSimulationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationDefaultConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>
    {
        public UserConversationSimulationDefaultConfiguration() { }
        public Azure.AI.Projects.UserConversationSimulationAudioEffectsConfiguration AudioEffects { get { throw null; } set { } }
        public int? ConversationRepetitions { get { throw null; } set { } }
        public int? DesiredNumTurns { get { throw null; } set { } }
        public bool? EnableConversationDatasetGeneration { get { throw null; } set { } }
        public int? MaxNumTurns { get { throw null; } set { } }
        public string OutputConversationDatasetName { get { throw null; } set { } }
        public Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration UserBehavior { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.UserConversationSimulationDefaultConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationDefaultConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationDefaultConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationDefaultConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationDefaultInterruptionConfiguration : Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>
    {
        public UserConversationSimulationDefaultInterruptionConfiguration() { }
        protected override Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationDefaultInterruptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>
    {
        public UserConversationSimulationEvalRunDataSource(System.BinaryData source, Azure.AI.Projects.Evaluation.EvaluationTarget target, Azure.AI.Projects.EvaluationModelConfiguration modelConfiguration) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public Azure.AI.Projects.UserConversationSimulationDefaultConfiguration DefaultSimulationConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.EvaluationModelConfiguration ModelConfiguration { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationTarget Target { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationInlineTestCasesSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>
    {
        public UserConversationSimulationInlineTestCasesSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.UserConversationSimulationTestCase> testCases) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.UserConversationSimulationTestCase> TestCases { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInlineTestCasesSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class UserConversationSimulationInterruptionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>
    {
        internal UserConversationSimulationInterruptionConfiguration() { }
        protected virtual Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationPreviewEvalRunDataSource : Azure.AI.Projects.EvalRunDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>
    {
        public UserConversationSimulationPreviewEvalRunDataSource(System.BinaryData source, Azure.AI.Projects.Evaluation.EvaluationTarget target, Azure.AI.Projects.EvaluationModelConfiguration modelConfiguration) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public Azure.AI.Projects.UserConversationSimulationDefaultConfiguration DefaultSimulationConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.EvaluationModelConfiguration ModelConfiguration { get { throw null; } set { } }
        public System.BinaryData Source { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationTarget Target { get { throw null; } set { } }
        protected override Azure.AI.Projects.EvalRunDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvalRunDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationPreviewEvalRunDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationTestCase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationTestCase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationTestCase>
    {
        public UserConversationSimulationTestCase() { }
        public Azure.AI.Projects.UserConversationSimulationConfiguration SimulationConfiguration { get { throw null; } set { } }
        public string TestCaseCategory { get { throw null; } set { } }
        public string TestCaseDescription { get { throw null; } set { } }
        public string TestCaseId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.UserConversationSimulationTestCase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationTestCase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationTestCase System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationTestCase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationTestCase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationTestCase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationTestCase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationTestCase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationTestCase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationUserBehaviorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>
    {
        public UserConversationSimulationUserBehaviorConfiguration() { }
        public Azure.AI.Projects.UserConversationSimulationInterruptionConfiguration Interruption { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserConversationSimulationUserBehaviorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserEvaluatorDiagnosticActor : Azure.AI.Projects.EvaluatorDiagnosticActor, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>
    {
        internal UserEvaluatorDiagnosticActor() { }
        protected override Azure.AI.Projects.EvaluatorDiagnosticActor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnosticActor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.UserEvaluatorDiagnosticActor System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UserEvaluatorDiagnosticActor System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UserEvaluatorDiagnosticActor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionCreatedDiagnosticChange : Azure.AI.Projects.EvaluatorDiagnostic, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>
    {
        internal VersionCreatedDiagnosticChange() { }
        public Azure.AI.Projects.EvaluatorDiagnosticActor Actor { get { throw null; } }
        public string GenerationJobId { get { throw null; } }
        public string PriorVersion { get { throw null; } }
        protected override Azure.AI.Projects.EvaluatorDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.EvaluatorDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.VersionCreatedDiagnosticChange System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VersionCreatedDiagnosticChange System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionCreatedDiagnosticChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionedDatasetReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionedDatasetReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionedDatasetReference>
    {
        internal VersionedDatasetReference() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.VersionedDatasetReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.VersionedDatasetReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.VersionedDatasetReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionedDatasetReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VersionedDatasetReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VersionedDatasetReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionedDatasetReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionedDatasetReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VersionedDatasetReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.Projects.Evaluation
{
    public partial class AgentClusterInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>
    {
        public AgentClusterInsightRequest(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightModelConfiguration ModelConfiguration { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentClusterInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentClusterInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentClusterInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>
    {
        internal AgentClusterInsightResult() { }
        public Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsight { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTaxonomyInput : Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>
    {
        public AgentTaxonomyInput(Azure.AI.Projects.Evaluation.EvaluationTarget target, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.RiskCategory> riskCategories) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.RiskCategory> RiskCategories { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationTarget Target { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AgentTaxonomyInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AgentTaxonomyInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AgentTaxonomyInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AttackStrategy : System.IEquatable<Azure.AI.Projects.Evaluation.AttackStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AttackStrategy(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AnsiAttack { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AsciiArt { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy AsciiSmuggler { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Atbash { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Base64 { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Baseline { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Binary { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Caesar { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy CharacterSpace { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy CharacterSwap { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Crescendo { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Diacritic { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Difficult { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Easy { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Flip { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy IndirectJailbreak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Jailbreak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Leetspeak { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Moderate { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Morse { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy MultiTurn { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Rot13 { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy StringJoin { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy SuffixAppend { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Tense { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy UnicodeConfusable { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy UnicodeSubstitution { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.AttackStrategy Url { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.AttackStrategy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.AttackStrategy left, Azure.AI.Projects.Evaluation.AttackStrategy right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.AttackStrategy (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.AttackStrategy? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.AttackStrategy left, Azure.AI.Projects.Evaluation.AttackStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAIAgentTarget : Azure.AI.Projects.Evaluation.EvaluationTarget, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>
    {
        public AzureAIAgentTarget(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.ToolDescription> ToolDescriptions { get { throw null; } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureAIAgentTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureAIAgentTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIAgentTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIModelTarget : Azure.AI.Projects.Evaluation.EvaluationTarget, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>
    {
        public AzureAIModelTarget() { }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ModelSamplingParams SamplingParams { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureAIModelTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureAIModelTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureAIModelTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureOpenAIModelConfiguration : Azure.AI.Projects.Evaluation.TargetConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>
    {
        public AzureOpenAIModelConfiguration(string modelDeploymentName) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.AzureOpenAIModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChartCoordinate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>
    {
        internal ChartCoordinate() { }
        public int Size { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ChartCoordinate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ChartCoordinate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ChartCoordinate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ChartCoordinate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ChartCoordinate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterInsightResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>
    {
        internal ClusterInsightResult() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightCluster> Clusters { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.ChartCoordinate> Coordinates { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightSummary Summary { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ClusterInsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ClusterInsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClusterTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>
    {
        internal ClusterTokenUsage() { }
        public int InputTokenUsage { get { throw null; } }
        public int OutputTokenUsage { get { throw null; } }
        public int TotalTokenUsage { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ClusterTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ClusterTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ClusterTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ClusterTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ClusterTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>
    {
        public CodeBasedEvaluatorDefinition() { }
        public CodeBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string codeText) { }
        public CodeBasedEvaluatorDefinition(string codeText) { }
        public System.Uri BlobUri { get { throw null; } set { } }
        public string CodeText { get { throw null; } set { } }
        public string EntryPoint { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CodeBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContinuousEvaluationRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>
    {
        public ContinuousEvaluationRuleAction(string evalId) { }
        public string EvalId { get { throw null; } set { } }
        public int? MaxHourlyRuns { get { throw null; } set { } }
        public double? SamplingRate { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ContinuousEvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DailyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>
    {
        public DailyRecurrenceSchedule() { }
        public DailyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.DailyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>
    {
        public EndpointBasedEvaluatorDefinition(string connectionName) { }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.AI.Projects.EndpointEvaluatorSchemaVersion? SchemaVersion { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EndpointBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>
    {
        internal EvalResult() { }
        public bool IsPassed { get { throw null; } }
        public string Name { get { throw null; } }
        public float Score { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultCompareItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>
    {
        internal EvalRunResultCompareItem() { }
        public float DeltaEstimate { get { throw null; } }
        public float PValue { get { throw null; } }
        public Azure.AI.Projects.TreatmentEffectType TreatmentEffect { get { throw null; } }
        public string TreatmentRunId { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvalRunResultSummary TreatmentRunSummary { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultCompareItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultCompareItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultCompareItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultCompareItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultComparison : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>
    {
        internal EvalRunResultComparison() { }
        public Azure.AI.Projects.Evaluation.EvalRunResultSummary BaselineRunSummary { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvalRunResultCompareItem> CompareItems { get { throw null; } }
        public string EvaluatorName { get { throw null; } }
        public string MetricName { get { throw null; } }
        public string TestingCriteria { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultComparison JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultComparison PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultComparison System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultComparison System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultComparison>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvalRunResultSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>
    {
        internal EvalRunResultSummary() { }
        public float Average { get { throw null; } }
        public string RunId { get { throw null; } }
        public int SampleCount { get { throw null; } }
        public float StandardDeviation { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvalRunResultSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvalRunResultSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvalRunResultSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvalRunResultSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationComparisonInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>
    {
        public EvaluationComparisonInsightRequest(string evalId, string baselineRunId, System.Collections.Generic.IEnumerable<string> treatmentRunIds) { }
        public string BaselineRunId { get { throw null; } set { } }
        public string EvalId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> TreatmentRunIds { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationComparisonInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>
    {
        internal EvaluationComparisonInsightResult() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvalRunResultComparison> Comparisons { get { throw null; } }
        public string Method { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationComparisonInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>
    {
        public EvaluationCredentialContent(System.Uri blobUri) { }
        public System.Uri BlobUri { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluationCredentialContent evaluationCredentialContent) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationResultSample : Azure.AI.Projects.Evaluation.InsightSample, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>
    {
        internal EvaluationResultSample() { }
        public Azure.AI.Projects.Evaluation.EvalResult EvaluationResult { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightSample JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightSample PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationResultSample System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationResultSample System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationResultSample>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>
    {
        public EvaluationRule(Azure.AI.Projects.Evaluation.EvaluationRuleAction action, Azure.AI.Projects.Evaluation.EvaluationRuleEventType eventType, bool enabled) { }
        public Azure.AI.Projects.Evaluation.EvaluationRuleAction Action { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.AI.Projects.ProjectsError Error { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationRuleEventType EventType { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluationRuleFilter Filter { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ScheduleTrigger Schedule { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemData { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluationRule (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>
    {
        internal EvaluationRuleAction() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationRuleEventType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluationRuleEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationRuleEventType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleEventType Manual { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleEventType ResponseCompleted { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluationRuleEventType TimerTrigger { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluationRuleEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluationRuleEventType left, Azure.AI.Projects.Evaluation.EvaluationRuleEventType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluationRuleEventType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluationRuleEventType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluationRuleEventType left, Azure.AI.Projects.Evaluation.EvaluationRuleEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluationRuleFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>
    {
        public EvaluationRuleFilter(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationRuleFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRuleFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRuleFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRuleFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRules
    {
        protected EvaluationRules() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule> CreateOrUpdate(string id, Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateOrUpdate(string id, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule>> CreateOrUpdateAsync(string id, Azure.AI.Projects.Evaluation.EvaluationRule evaluationRule, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateOrUpdateAsync(string id, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule> Get(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluationRule> GetAll(Azure.AI.Projects.EvaluationRuleActionType? actionType = default(Azure.AI.Projects.EvaluationRuleActionType?), string agentName = null, bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string actionType, string agentName, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluationRule> GetAllAsync(Azure.AI.Projects.EvaluationRuleActionType? actionType = default(Azure.AI.Projects.EvaluationRuleActionType?), string agentName = null, bool? enabled = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string actionType, string agentName, bool? enabled, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationRule>> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EvaluationRunClusterInsightRequest : Azure.AI.Projects.Evaluation.InsightRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>
    {
        public EvaluationRunClusterInsightRequest(string evalId, System.Collections.Generic.IEnumerable<string> runIds) { }
        public string EvalId { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightModelConfiguration ModelConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RunIds { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationRunClusterInsightResult : Azure.AI.Projects.Evaluation.InsightResult, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>
    {
        internal EvaluationRunClusterInsightResult() { }
        public Azure.AI.Projects.Evaluation.ClusterInsightResult ClusterInsight { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationRunClusterInsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationScheduleTask : Azure.AI.Projects.ProjectsScheduleTask, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>
    {
        public EvaluationScheduleTask(string evalId, System.BinaryData evalRun) { }
        public string EvalId { get { throw null; } set { } }
        public System.BinaryData EvalRun { get { throw null; } set { } }
        protected override Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationsDimension : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>
    {
        public EvaluationsDimension(string id, string description) { }
        public EvaluationsDimension(string id, string description, int weight) { }
        public bool? Allowed { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public int? GeneratedWeight { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? IsAlwaysApplicable { get { throw null; } set { } }
        public int? Weight { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationsDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationsDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationsDimension System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationsDimension System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationsDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>
    {
        internal EvaluationTarget() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationTaxonomies
    {
        protected EvaluationTaxonomies() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> Create(string name, Azure.AI.Projects.Evaluation.EvaluationTaxonomy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>> CreateAsync(string name, Azure.AI.Projects.Evaluation.EvaluationTaxonomy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string inputName, string inputType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> GetAll(string inputName = null, string inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string inputName, string inputType, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy> GetAllAsync(string inputName = null, string inputType = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Update(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class EvaluationTaxonomy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>
    {
        public EvaluationTaxonomy(Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput taxonomyInput) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.TaxonomyCategory> TaxonomyCategories { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput TaxonomyInput { get { throw null; } set { } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluationTaxonomy (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluationTaxonomy evaluationTaxonomy) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationTaxonomyInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>
    {
        internal EvaluationTaxonomyInput() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluationTaxonomyInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorCategory : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorCategory(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Agents { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Quality { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorCategory Safety { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorCategory left, Azure.AI.Projects.Evaluation.EvaluatorCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorCategory left, Azure.AI.Projects.Evaluation.EvaluatorCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class EvaluatorDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>
    {
        internal EvaluatorDefinition() { }
        public System.BinaryData DataSchema { get { throw null; } set { } }
        public System.BinaryData InitParameters { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> Metrics { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorDefinitionType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorDefinitionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorDefinitionType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Code { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Endpoint { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType OpenaiGraders { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Prompt { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType PromptAndCode { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Rubric { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorDefinitionType Service { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType left, Azure.AI.Projects.Evaluation.EvaluatorDefinitionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorDefinitionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorDefinitionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorDefinitionType left, Azure.AI.Projects.Evaluation.EvaluatorDefinitionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorGenerationArtifacts : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>
    {
        internal EvaluatorGenerationArtifacts() { }
        public System.Collections.Generic.IList<string> DatasetRowKinds { get { throw null; } }
        public Azure.AI.Projects.VersionedDatasetReference Reference { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorGenerationInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>
    {
        public EvaluatorGenerationInputs(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource> sources, string evaluatorName) { }
        public EvaluatorGenerationInputs(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource> sources, string model, string evaluatorName) { }
        public Azure.AI.Projects.EvaluatorGenerationCategory? Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluationsDimension> Dimensions { get { throw null; } }
        public string EvaluatorDisplayName { get { throw null; } set { } }
        public string EvaluatorName { get { throw null; } }
        public string Model { get { throw null; } set { } }
        public float? PassThreshold { get { throw null; } set { } }
        public Azure.AI.Projects.RubricScoring Scoring { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource> Sources { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs evaluatorGenerationInputs) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorGenerationJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>
    {
        internal EvaluatorGenerationJob() { }
        public Azure.AI.Projects.EvaluatorGenerationCategory? Category { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.Evaluation.EvaluationsDimension> Dimensions { get { throw null; } }
        public string EvaluatorDescription { get { throw null; } }
        public string EvaluatorDisplayName { get { throw null; } }
        public string EvaluatorName { get { throw null; } }
        public System.DateTimeOffset? FinishedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RubricGenerationInputQualityWarning> InputQualityWarnings { get { throw null; } }
        public string Model { get { throw null; } }
        public float? PassThreshold { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluatorVersion Result { get { throw null; } }
        public Azure.AI.Projects.RubricScoring Scoring { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource> Sources { get { throw null; } }
        public Azure.AI.Projects.ProjectsJobStatus Status { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage Usage { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorGenerationJob FromClientResult(System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluatorGenerationJob (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorGenerationJobs
    {
        protected EvaluatorGenerationJobs() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult Cancel(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob> Cancel(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CancelAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>> CancelAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, Azure.AI.Projects.Evaluation.EvaluatorGenerationInputs job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob> GetAll(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorGenerationJob>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class EvaluatorGenerationJobSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>
    {
        internal EvaluatorGenerationJobSource() { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationJobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorGenerationTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>
    {
        internal EvaluatorGenerationTokenUsage() { }
        public long InputTokens { get { throw null; } }
        public long OutputTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorGenerationTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorMetric : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>
    {
        public EvaluatorMetric() { }
        public Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? DesirableDirection { get { throw null; } set { } }
        public bool? IsPrimary { get { throw null; } set { } }
        public float? MaxValue { get { throw null; } set { } }
        public float? MinValue { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluatorMetricType? Type { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorMetric JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorMetric PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorMetric System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorMetric System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorMetricDirection : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorMetricDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorMetricDirection(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Decrease { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Increase { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricDirection Neutral { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection left, Azure.AI.Projects.Evaluation.EvaluatorMetricDirection right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricDirection (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricDirection? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorMetricDirection left, Azure.AI.Projects.Evaluation.EvaluatorMetricDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluatorMetricType : System.IEquatable<Azure.AI.Projects.Evaluation.EvaluatorMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluatorMetricType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Boolean { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Continuous { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.EvaluatorMetricType Ordinal { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.EvaluatorMetricType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.EvaluatorMetricType left, Azure.AI.Projects.Evaluation.EvaluatorMetricType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.EvaluatorMetricType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.EvaluatorMetricType left, Azure.AI.Projects.Evaluation.EvaluatorMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatorVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>
    {
        public EvaluatorVersion(Azure.AI.Projects.EvaluatorType evaluatorType, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories, Azure.AI.Projects.Evaluation.EvaluatorDefinition definition) { }
        public EvaluatorVersion(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.EvaluatorCategory> categories) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.EvaluatorCategory> Categories { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.Projects.Evaluation.EvaluatorDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.AI.Projects.EvaluatorType EvaluatorType { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.EvaluatorGenerationArtifacts GenerationArtifacts { get { throw null; } }
        public string GenerationJobId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string ModifiedAt { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel> SupportedEvaluationLevels { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Version { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.GenerationWarningType> Warnings { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.EvaluatorVersion (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.EvaluatorVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.EvaluatorVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.EvaluatorVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.EvaluatorVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HourlyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>
    {
        public HourlyRecurrenceSchedule() { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HourlyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HumanEvaluationPreviewRuleAction : Azure.AI.Projects.Evaluation.EvaluationRuleAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>
    {
        public HumanEvaluationPreviewRuleAction(string templateId) { }
        public string TemplateId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluationRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.HumanEvaluationPreviewRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightCluster : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>
    {
        internal InsightCluster() { }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Label { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightSample> Samples { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.InsightCluster> SubClusters { get { throw null; } }
        public string Suggestion { get { throw null; } }
        public string SuggestionTitle { get { throw null; } }
        public int Weight { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightCluster JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightCluster PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightCluster System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightCluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightCluster System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightCluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>
    {
        public InsightModelConfiguration(string modelDeploymentName) { }
        public string ModelDeploymentName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.InsightModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>
    {
        internal InsightRequest() { }
        protected virtual Azure.AI.Projects.Evaluation.InsightRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>
    {
        internal InsightResult() { }
        protected virtual Azure.AI.Projects.Evaluation.InsightResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InsightSample : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>
    {
        internal InsightSample() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> CorrelationInfo { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Features { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightSample JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightSample PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightSample System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSample>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightSample System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSample>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightScheduleTask : Azure.AI.Projects.ProjectsScheduleTask, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>
    {
        public InsightScheduleTask(Azure.AI.Projects.Evaluation.ProjectsInsight insight) { }
        public Azure.AI.Projects.Evaluation.ProjectsInsight Insight { get { throw null; } set { } }
        protected override Azure.AI.Projects.ProjectsScheduleTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.ProjectsScheduleTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightScheduleTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightScheduleTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightScheduleTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>
    {
        internal InsightsMetadata() { }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightsMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightsMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InsightSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>
    {
        internal InsightSummary() { }
        public string MethodName { get { throw null; } }
        public int SampleCount { get { throw null; } }
        public int UniqueClusterCount { get { throw null; } }
        public int UniqueSubclusterCount { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ClusterTokenUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.InsightSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.InsightSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.InsightSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.InsightSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.InsightSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.InsightSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InsightType : System.IEquatable<Azure.AI.Projects.Evaluation.InsightType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InsightType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.InsightType AgentClusterInsight { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.InsightType EvaluationComparison { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.InsightType EvaluationRunClusterInsight { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.InsightType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.InsightType left, Azure.AI.Projects.Evaluation.InsightType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.InsightType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.InsightType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.InsightType left, Azure.AI.Projects.Evaluation.InsightType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListVersionsRequestType : System.IEquatable<Azure.AI.Projects.Evaluation.ListVersionsRequestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListVersionsRequestType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType All { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType BuiltIn { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ListVersionsRequestType Custom { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ListVersionsRequestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ListVersionsRequestType left, Azure.AI.Projects.Evaluation.ListVersionsRequestType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ListVersionsRequestType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ListVersionsRequestType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ListVersionsRequestType left, Azure.AI.Projects.Evaluation.ListVersionsRequestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelSamplingParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>
    {
        public ModelSamplingParams() { }
        public ModelSamplingParams(float temperature, float topP, int seed, int maxCompletionTokens) { }
        public int MaxCompletionTokens { get { throw null; } set { } }
        public int Seed { get { throw null; } set { } }
        public float Temperature { get { throw null; } set { } }
        public float TopP { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.ModelSamplingParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ModelSamplingParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ModelSamplingParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ModelSamplingParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ModelSamplingParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonthlyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>
    {
        public MonthlyRecurrenceSchedule(System.Collections.Generic.IEnumerable<int> daysOfMonth) { }
        public System.Collections.Generic.IList<int> DaysOfMonth { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.MonthlyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OneTimeTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>
    {
        public OneTimeTrigger(System.DateTimeOffset triggerAt) { }
        public string TimeZone { get { throw null; } set { } }
        public System.DateTimeOffset TriggerAt { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.OneTimeTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.OneTimeTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.OneTimeTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationStatus : System.IEquatable<Azure.AI.Projects.Evaluation.OperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationStatus(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.OperationStatus Canceled { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus NotStarted { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Running { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.OperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.OperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.OperationStatus left, Azure.AI.Projects.Evaluation.OperationStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.OperationStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.OperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.OperationStatus left, Azure.AI.Projects.Evaluation.OperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectEvaluators
    {
        protected ProjectEvaluators() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> CreateVersion(string name, Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion>> CreateVersionAsync(string name, Azure.AI.Projects.Evaluation.EvaluatorVersion evaluatorVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential> GetCredential(string name, string version, Azure.AI.Projects.Evaluation.EvaluationCredentialContent credentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.DatasetCredential>> GetCredentialAsync(string name, string version, Azure.AI.Projects.Evaluation.EvaluationCredentialContent credentialRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.EvaluatorDiagnostic> GetDiagnostics(string name, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string evaluatorVersion = null, string dimensionId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvaluatorDiagnosticType> type = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetDiagnostics(string name, string after, string before, int? limit, string order, System.DateTimeOffset? startTime, System.DateTimeOffset? endTime, string evaluatorVersion, string dimensionId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvaluatorDiagnosticType> type, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.EvaluatorDiagnostic> GetDiagnosticsAsync(string name, string after = null, string before = null, int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string evaluatorVersion = null, string dimensionId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvaluatorDiagnosticType> type = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetDiagnosticsAsync(string name, string after, string before, int? limit, string order, System.DateTimeOffset? startTime, System.DateTimeOffset? endTime, string evaluatorVersion, string dimensionId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.EvaluatorDiagnosticType> type, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetLatestVersions(Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetLatestVersions(string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetLatestVersionsAsync(Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetLatestVersionsAsync(string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult GetVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.EvaluatorVersion>> GetVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersions(string name, Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetVersions(string name, string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.EvaluatorVersion> GetVersionsAsync(string name, Azure.AI.Projects.Evaluation.ListVersionsRequestType? type = default(Azure.AI.Projects.Evaluation.ListVersionsRequestType?), int? limit = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetVersionsAsync(string name, string type, int? limit, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult> StartPendingUpload(string name, string version, Azure.AI.Projects.PendingUploadConfiguration pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.PendingUploadResult>> StartPendingUploadAsync(string name, string version, Azure.AI.Projects.PendingUploadConfiguration pendingUploadRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateVersion(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateVersionAsync(string name, string version, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class ProjectInsight
    {
        public ProjectInsight() { }
    }
    public partial class ProjectInsights
    {
        protected ProjectInsights() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight> Generate(Azure.AI.Projects.Evaluation.ProjectsInsight insight, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Generate(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight>> GenerateAsync(Azure.AI.Projects.Evaluation.ProjectsInsight insight, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GenerateAsync(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight> Get(string id, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string id, string foundryFeatures, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.ProjectsInsight> GetAll(Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), Azure.AI.Projects.Evaluation.InsightType? type = default(Azure.AI.Projects.Evaluation.InsightType?), string evalId = null, string runId = null, string agentName = null, bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(string foundryFeatures, string type, string evalId, string runId, string agentName, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.ProjectsInsight> GetAllAsync(Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), Azure.AI.Projects.Evaluation.InsightType? type = default(Azure.AI.Projects.Evaluation.InsightType?), string evalId = null, string runId = null, string agentName = null, bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(string foundryFeatures, string type, string evalId, string runId, string agentName, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.ProjectsInsight>> GetAsync(string id, Azure.AI.Projects.FoundryFeaturesOptInKeys? foundryFeatures = default(Azure.AI.Projects.FoundryFeaturesOptInKeys?), bool? includeCoordinates = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string id, string foundryFeatures, bool? includeCoordinates, System.ClientModel.Primitives.RequestOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectsEvaluationLevel : System.IEquatable<Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectsEvaluationLevel(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel Conversation { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel Turn { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel left, Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel left, Azure.AI.Projects.Evaluation.ProjectsEvaluationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectsInsight : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>
    {
        public ProjectsInsight(string displayName, Azure.AI.Projects.Evaluation.InsightRequest request) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightsMetadata Metadata { get { throw null; } }
        public Azure.AI.Projects.Evaluation.InsightRequest Request { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.InsightResult Result { get { throw null; } }
        public Azure.AI.Projects.Evaluation.OperationStatus State { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsInsight JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ProjectsInsight (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.ProjectsInsight projectsInsight) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsInsight PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ProjectsInsight System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ProjectsInsight System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsInsight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>
    {
        public ProjectsMetadata() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ProjectsMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ProjectsMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>
    {
        public ProjectsSchedule(bool enabled, Azure.AI.Projects.Evaluation.ScheduleTrigger trigger, Azure.AI.Projects.ProjectsScheduleTask task) { }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? ProvisioningStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.ProjectsScheduleTask Task { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.ScheduleTrigger Trigger { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ProjectsSchedule (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.ProjectsSchedule projectsSchedule) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ProjectsSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ProjectsSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ProjectsSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ProjectsSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptBasedEvaluatorDefinition : Azure.AI.Projects.Evaluation.EvaluatorDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>
    {
        public PromptBasedEvaluatorDefinition(System.BinaryData initParameters, System.BinaryData dataSchema, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Evaluation.EvaluatorMetric> metrics, string promptText) { }
        public PromptBasedEvaluatorDefinition(string promptText) { }
        public string PromptText { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.EvaluatorDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.PromptBasedEvaluatorDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>
    {
        internal RecurrenceSchedule() { }
        protected virtual Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Projects.Evaluation.ScheduleTrigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>
    {
        public RecurrenceTrigger(int interval, Azure.AI.Projects.Evaluation.RecurrenceSchedule schedule) { }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Projects.Evaluation.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>
    {
        public RedTeam(Azure.AI.Projects.Evaluation.TargetConfig target) { }
        public string ApplicationScenario { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.AttackStrategy> AttackStrategies { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsSimulationOnly { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.RiskCategory> RiskCategories { get { throw null; } }
        public string Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.Evaluation.TargetConfig Target { get { throw null; } set { } }
        public int? TurnCount { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Evaluation.RedTeam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.RedTeam (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Evaluation.RedTeam redTeam) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.RedTeam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.RedTeam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.RedTeam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.RedTeam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.RedTeam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RedTeams
    {
        protected RedTeams() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Create(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Create(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Create(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> CreateAsync(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> CreateAsync(Azure.AI.Projects.Evaluation.RedTeam redTeam, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Evaluation.RedTeam> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Evaluation.RedTeam> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Evaluation.RedTeam>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RiskCategory : System.IEquatable<Azure.AI.Projects.Evaluation.RiskCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RiskCategory(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.RiskCategory CodeVulnerability { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory HateUnfairness { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory ProhibitedActions { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory ProtectedMaterial { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory SelfHarm { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory SensitiveDataLeakage { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory Sexual { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory TaskAdherence { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory UngroundedAttributes { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.RiskCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.RiskCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.RiskCategory left, Azure.AI.Projects.Evaluation.RiskCategory right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.RiskCategory (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.RiskCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.RiskCategory left, Azure.AI.Projects.Evaluation.RiskCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleProvisioningStatus : System.IEquatable<Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleProvisioningStatus(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Creating { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Deleting { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Succeeded { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus Updating { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus left, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus left, Azure.AI.Projects.Evaluation.ScheduleProvisioningStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScheduleRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>
    {
        internal ScheduleRun() { }
        public string Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string RunId { get { throw null; } }
        public string ScheduleId { get { throw null; } }
        public bool Success { get { throw null; } }
        public System.DateTimeOffset? TriggerTime { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Evaluation.ScheduleRun (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ScheduleRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ScheduleRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleTaskType : System.IEquatable<Azure.AI.Projects.Evaluation.ScheduleTaskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleTaskType(string value) { throw null; }
        public static Azure.AI.Projects.Evaluation.ScheduleTaskType Evaluation { get { throw null; } }
        public static Azure.AI.Projects.Evaluation.ScheduleTaskType Insight { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Evaluation.ScheduleTaskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Evaluation.ScheduleTaskType left, Azure.AI.Projects.Evaluation.ScheduleTaskType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleTaskType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Evaluation.ScheduleTaskType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Evaluation.ScheduleTaskType left, Azure.AI.Projects.Evaluation.ScheduleTaskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ScheduleTrigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>
    {
        internal ScheduleTrigger() { }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleTrigger JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.ScheduleTrigger PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.ScheduleTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.ScheduleTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.ScheduleTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TargetConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>
    {
        internal TargetConfig() { }
        protected virtual Azure.AI.Projects.Evaluation.TargetConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TargetConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TargetConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TargetConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TargetConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TargetConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaxonomyCategory : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>
    {
        public TaxonomyCategory(string id, string name, Azure.AI.Projects.Evaluation.RiskCategory riskCategory, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Evaluation.TaxonomySubCategory> subCategories) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public Azure.AI.Projects.Evaluation.RiskCategory RiskCategory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Evaluation.TaxonomySubCategory> SubCategories { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomyCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomyCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TaxonomyCategory System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TaxonomyCategory System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomyCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaxonomySubCategory : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>
    {
        public TaxonomySubCategory(string id, string name, bool isEnabled) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public bool IsEnabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomySubCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Evaluation.TaxonomySubCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.TaxonomySubCategory System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.TaxonomySubCategory System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.TaxonomySubCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeeklyRecurrenceSchedule : Azure.AI.Projects.Evaluation.RecurrenceSchedule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>
    {
        public WeeklyRecurrenceSchedule(System.Collections.Generic.IEnumerable<System.DayOfWeek> daysOfWeek) { }
        public System.Collections.Generic.IList<System.DayOfWeek> DaysOfWeek { get { throw null; } }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Evaluation.RecurrenceSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation.WeeklyRecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.AI.Projects.Memory
{
    public partial class AIProjectMemoryStores
    {
        protected AIProjectMemoryStores() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateMemory(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem> CreateMemory(string name, string scope, string content, Azure.AI.Projects.Memory.MemoryItemKind kind, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateMemoryAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem>> CreateMemoryAsync(string name, string scope, string content, Azure.AI.Projects.Memory.MemoryItemKind kind, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateMemoryStore(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> CreateMemoryStore(string name, Azure.AI.Projects.Memory.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateMemoryStoreAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> CreateMemoryStoreAsync(string name, Azure.AI.Projects.Memory.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteMemory(string name, string memoryId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryDeletionResult> DeleteMemory(string name, string memoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteMemoryAsync(string name, string memoryId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryDeletionResult>> DeleteMemoryAsync(string name, string memoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse> DeleteMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>> DeleteMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteScope(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse> DeleteScope(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteScopeAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>> DeleteScopeAsync(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Memory.MemoryItem> GetMemories(string name, string scope, Azure.AI.Projects.Memory.MemoryItemKind? kind = default(Azure.AI.Projects.Memory.MemoryItemKind?), int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetMemoriesAsync(string name, System.ClientModel.BinaryContent content, string kind = null, int? limit = default(int?), string order = null, string after = null, string before = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Memory.MemoryItem> GetMemoriesAsync(string name, string scope, Azure.AI.Projects.Memory.MemoryItemKind? kind = default(Azure.AI.Projects.Memory.MemoryItemKind?), int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetMemory(string name, string memoryId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem> GetMemory(string name, string memoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetMemoryAsync(string name, string memoryId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem>> GetMemoryAsync(string name, string memoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> GetMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStores(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Memory.MemoryStore> GetMemoryStoresAsync(int? limit = default(int?), Azure.AI.Projects.Memory.MemoryStoreListOrder? order = default(Azure.AI.Projects.Memory.MemoryStoreListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetUpdateResult(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult> GetUpdateResult(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetUpdateResultAsync(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult>> GetUpdateResultAsync(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreSearchResponse> SearchMemories(string memoryStoreName, Azure.AI.Projects.Memory.MemorySearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SearchMemories(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>> SearchMemoriesAsync(string memoryStoreName, Azure.AI.Projects.Memory.MemorySearchOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SearchMemoriesAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult UpdateMemories(bool waitUntilCompleted, string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.OperationResult UpdateMemories(bool waitUntilCompleted, string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult> UpdateMemories(string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> UpdateMemoriesAsync(bool waitUntilCompleted, string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> UpdateMemoriesAsync(bool waitUntilCompleted, string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreName, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemory(string name, string memoryId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem> UpdateMemory(string name, string memoryId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoryAsync(string name, string memoryId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryItem>> UpdateMemoryAsync(string name, string memoryId, string content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemoryStore(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore> UpdateMemoryStore(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoryStoreAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Memory.MemoryStore>> UpdateMemoryStoreAsync(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Memory.MemoryUpdateResult WaitForMemoriesUpdate(string memoryStoreName, int pollingInterval, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.Projects.Memory.MemoryUpdateResult> WaitForMemoriesUpdateAsync(string memoryStoreName, int pollingInterval, Azure.AI.Projects.Memory.MemoryUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatSummaryMemoryItem : Azure.AI.Projects.Memory.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>
    {
        internal ChatSummaryMemoryItem() { }
        protected override Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteMemoryStoreResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>
    {
        internal DeleteMemoryStoreResponse() { }
        public bool IsDeleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreObjectType Object { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.DeleteMemoryStoreResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.DeleteMemoryStoreResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.DeleteMemoryStoreResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.DeleteMemoryStoreResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.DeleteMemoryStoreResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.DeleteMemoryStoreResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryDeletionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryDeletionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryDeletionResult>
    {
        internal MemoryDeletionResult() { }
        public bool Deleted { get { throw null; } }
        public string MemoryId { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreObjectType Object { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryDeletionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryDeletionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryDeletionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryDeletionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryDeletionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryDeletionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryDeletionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryDeletionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryDeletionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryDeletionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>
    {
        internal MemoryItem() { }
        public string Content { get { throw null; } }
        public string MemoryId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryItemKind : System.IEquatable<Azure.AI.Projects.Memory.MemoryItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryItemKind(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryItemKind ChatSummary { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryItemKind Procedural { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryItemKind UserProfile { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryItemKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryItemKind left, Azure.AI.Projects.Memory.MemoryItemKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryItemKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryItemKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryItemKind left, Azure.AI.Projects.Memory.MemoryItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>
    {
        internal MemoryOperation() { }
        public Azure.AI.Projects.Memory.MemoryOperationKind Kind { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryOperationKind : System.IEquatable<Azure.AI.Projects.Memory.MemoryOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryOperationKind(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Create { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Delete { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryOperationKind Update { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryOperationKind left, Azure.AI.Projects.Memory.MemoryOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryOperationKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryOperationKind left, Azure.AI.Projects.Memory.MemoryOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemorySearchItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>
    {
        internal MemorySearchItem() { }
        public Azure.AI.Projects.Memory.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemorySearchItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemorySearchItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>
    {
        public MemorySearchOptions(string scope) { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public string PreviousSearchId { get { throw null; } set { } }
        public Azure.AI.Extensions.OpenAI.MemorySearchResultOptions ResultOptions { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemorySearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Memory.MemorySearchOptions memorySearchOptions) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemorySearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>
    {
        internal MemoryStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStore (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDefaultDefinition : Azure.AI.Projects.Memory.MemoryStoreDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>
    {
        public MemoryStoreDefaultDefinition(string chatModel, string embeddingModel) { }
        public string ChatModel { get { throw null; } set { } }
        public string EmbeddingModel { get { throw null; } set { } }
        public Azure.AI.Projects.Memory.MemoryStoreDefaultOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Projects.Memory.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDefaultOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>
    {
        public MemoryStoreDefaultOptions(bool isUserProfileEnabled, bool isChatSummaryEnabled) { }
        public System.TimeSpan? DefaultTtlSeconds { get { throw null; } set { } }
        public bool IsChatSummaryEnabled { get { throw null; } set { } }
        public bool? IsProceduralMemoryEnabled { get { throw null; } set { } }
        public bool IsUserProfileEnabled { get { throw null; } set { } }
        public string UserProfileDetails { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefaultOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefaultOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefaultOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefaultOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefaultOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryStoreDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>
    {
        internal MemoryStoreDefinition() { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDeleteScopeResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>
    {
        internal MemoryStoreDeleteScopeResponse() { }
        public bool IsDeleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreObjectType Object { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreDeleteScopeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreListOrder : System.IEquatable<Azure.AI.Projects.Memory.MemoryStoreListOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreListOrder(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreListOrder Ascending { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreListOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryStoreListOrder other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryStoreListOrder left, Azure.AI.Projects.Memory.MemoryStoreListOrder right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreListOrder (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreListOrder? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryStoreListOrder left, Azure.AI.Projects.Memory.MemoryStoreListOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreObjectType : System.IEquatable<Azure.AI.Projects.Memory.MemoryStoreObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreObjectType(string value) { throw null; }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryDeleted { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStore { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStoreDeleted { get { throw null; } }
        public static Azure.AI.Projects.Memory.MemoryStoreObjectType MemoryStoreScopeDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Memory.MemoryStoreObjectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Memory.MemoryStoreObjectType left, Azure.AI.Projects.Memory.MemoryStoreObjectType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreObjectType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Memory.MemoryStoreObjectType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Memory.MemoryStoreObjectType left, Azure.AI.Projects.Memory.MemoryStoreObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryStoreOperationUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>
    {
        internal MemoryStoreOperationUsage() { }
        public int EmbeddingTokens { get { throw null; } }
        public long InputTokens { get { throw null; } }
        public OpenAI.Responses.ResponseInputTokenUsageDetails InputTokensDetails { get { throw null; } }
        public long OutputTokens { get { throw null; } }
        public OpenAI.Responses.ResponseOutputTokenUsageDetails OutputTokensDetails { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreOperationUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreOperationUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreOperationUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreOperationUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreOperationUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreOperationUsageInputTokensDetails
    {
        public MemoryStoreOperationUsageInputTokensDetails() { }
    }
    public partial class MemoryStoreOperationUsageOutputTokensDetails
    {
        public MemoryStoreOperationUsageOutputTokensDetails() { }
    }
    public partial class MemoryStoreSearchResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>
    {
        internal MemoryStoreSearchResponse() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Memory.MemorySearchItem> Memories { get { throw null; } }
        public string SearchId { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreSearchResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryStoreSearchResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryStoreSearchResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryStoreSearchResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryStoreSearchResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryStoreSearchResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MemoryStoreUpdateStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Superseded = 4,
    }
    public partial class MemoryUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>
    {
        public MemoryUpdateOptions(string scope) { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public string PreviousUpdateId { get { throw null; } set { } }
        public string Scope { get { throw null; } }
        public int? UpdateDelay { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Memory.MemoryUpdateOptions memoryUpdateOptions) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>
    {
        internal MemoryUpdateResult() { }
        public Azure.AI.Projects.Memory.MemoryUpdateResultDetails Details { get { throw null; } }
        public string ErrorDetails { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreUpdateStatus Status { get { throw null; } }
        public string SupersededBy { get { throw null; } }
        public string UpdateId { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryUpdateResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryUpdateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResultDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>
    {
        internal MemoryUpdateResultDetails() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Memory.MemoryOperation> MemoryOperations { get { throw null; } }
        public Azure.AI.Projects.Memory.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Memory.MemoryUpdateResultDetails (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Memory.MemoryUpdateResultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.MemoryUpdateResultDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.MemoryUpdateResultDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.MemoryUpdateResultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProfileMemoryItem : Azure.AI.Projects.Memory.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>
    {
        internal UserProfileMemoryItem() { }
        protected override Azure.AI.Projects.Memory.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Memory.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Memory.UserProfileMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Memory.UserProfileMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Memory.UserProfileMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
