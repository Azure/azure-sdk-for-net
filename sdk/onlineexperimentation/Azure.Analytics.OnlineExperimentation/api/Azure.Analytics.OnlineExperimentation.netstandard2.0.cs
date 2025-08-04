namespace Azure.Analytics.OnlineExperimentation
{
    public partial class AggregatedValue : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>
    {
        public AggregatedValue(string eventName, string eventProperty) { }
        public string EventName { get { throw null; } set { } }
        public string EventProperty { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.AggregatedValue System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.AggregatedValue System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AggregatedValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AnalyticsOnlineExperimentationModelFactory
    {
        public static Azure.Analytics.OnlineExperimentation.DiagnosticDetail DiagnosticDetail(string message = null, Azure.Analytics.OnlineExperimentation.DiagnosticCode code = default(Azure.Analytics.OnlineExperimentation.DiagnosticCode)) { throw null; }
        public static Azure.Analytics.OnlineExperimentation.ExperimentMetric ExperimentMetric(string id = null, Azure.Analytics.OnlineExperimentation.LifecycleStage lifecycle = default(Azure.Analytics.OnlineExperimentation.LifecycleStage), string displayName = null, string description = null, System.Collections.Generic.IEnumerable<string> categories = null, Azure.Analytics.OnlineExperimentation.DesiredDirection desiredDirection = default(Azure.Analytics.OnlineExperimentation.DesiredDirection), Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition definition = null, Azure.ETag eTag = default(Azure.ETag), System.DateTimeOffset lastModifiedAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult ExperimentMetricValidationResult(bool isValid = false, System.Collections.Generic.IEnumerable<Azure.Analytics.OnlineExperimentation.DiagnosticDetail> diagnostics = null) { throw null; }
    }
    public partial class AverageMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>
    {
        public AverageMetricDefinition(Azure.Analytics.OnlineExperimentation.AggregatedValue value) { }
        public AverageMetricDefinition(string eventName, string eventProperty) { }
        public Azure.Analytics.OnlineExperimentation.AggregatedValue Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.AverageMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.AverageMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.AverageMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAnalyticsOnlineExperimentationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAnalyticsOnlineExperimentationContext() { }
        public static Azure.Analytics.OnlineExperimentation.AzureAnalyticsOnlineExperimentationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesiredDirection : System.IEquatable<Azure.Analytics.OnlineExperimentation.DesiredDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesiredDirection(string value) { throw null; }
        public static Azure.Analytics.OnlineExperimentation.DesiredDirection Decrease { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.DesiredDirection Increase { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.DesiredDirection Neutral { get { throw null; } }
        public bool Equals(Azure.Analytics.OnlineExperimentation.DesiredDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.OnlineExperimentation.DesiredDirection left, Azure.Analytics.OnlineExperimentation.DesiredDirection right) { throw null; }
        public static implicit operator Azure.Analytics.OnlineExperimentation.DesiredDirection (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.OnlineExperimentation.DesiredDirection left, Azure.Analytics.OnlineExperimentation.DesiredDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticCode : System.IEquatable<Azure.Analytics.OnlineExperimentation.DiagnosticCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticCode(string value) { throw null; }
        public static Azure.Analytics.OnlineExperimentation.DiagnosticCode FailedSchemaValidation { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.DiagnosticCode InvalidEventCondition { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.DiagnosticCode InvalidExperimentMetricDefinition { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.DiagnosticCode UnsupportedEventCondition { get { throw null; } }
        public bool Equals(Azure.Analytics.OnlineExperimentation.DiagnosticCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.OnlineExperimentation.DiagnosticCode left, Azure.Analytics.OnlineExperimentation.DiagnosticCode right) { throw null; }
        public static implicit operator Azure.Analytics.OnlineExperimentation.DiagnosticCode (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.OnlineExperimentation.DiagnosticCode left, Azure.Analytics.OnlineExperimentation.DiagnosticCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticDetail : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>
    {
        internal DiagnosticDetail() { }
        public Azure.Analytics.OnlineExperimentation.DiagnosticCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.DiagnosticDetail System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.DiagnosticDetail System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.DiagnosticDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventCountMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>
    {
        public EventCountMetricDefinition(Azure.Analytics.OnlineExperimentation.ObservedEvent @event) { }
        public EventCountMetricDefinition(string eventName) { }
        public Azure.Analytics.OnlineExperimentation.ObservedEvent Event { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventCountMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EventRateMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>
    {
        public EventRateMetricDefinition(Azure.Analytics.OnlineExperimentation.ObservedEvent @event, string rateCondition) { }
        public EventRateMetricDefinition(string eventName, string rateCondition) { }
        public Azure.Analytics.OnlineExperimentation.ObservedEvent Event { get { throw null; } set { } }
        public string RateCondition { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.EventRateMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExperimentMetric : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>
    {
        public ExperimentMetric(Azure.Analytics.OnlineExperimentation.LifecycleStage lifecycle, string displayName, string description, System.Collections.Generic.IEnumerable<string> categories, Azure.Analytics.OnlineExperimentation.DesiredDirection desiredDirection, Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition definition) { }
        public System.Collections.Generic.IList<string> Categories { get { throw null; } }
        public Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Analytics.OnlineExperimentation.DesiredDirection DesiredDirection { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset LastModifiedAt { get { throw null; } }
        public Azure.Analytics.OnlineExperimentation.LifecycleStage Lifecycle { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetric System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetric System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ExperimentMetricDefinition : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>
    {
        protected ExperimentMetricDefinition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExperimentMetricUpdate : Azure.Analytics.OnlineExperimentation.ExperimentMetric
    {
        public ExperimentMetricUpdate() : base (default(Azure.Analytics.OnlineExperimentation.LifecycleStage), default(string), default(string), default(System.Collections.Generic.IEnumerable<string>), default(Azure.Analytics.OnlineExperimentation.DesiredDirection), default(Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
    }
    public partial class ExperimentMetricValidationResult : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>
    {
        internal ExperimentMetricValidationResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Analytics.OnlineExperimentation.DiagnosticDetail> Diagnostics { get { throw null; } }
        public bool IsValid { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LifecycleStage : System.IEquatable<Azure.Analytics.OnlineExperimentation.LifecycleStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LifecycleStage(string value) { throw null; }
        public static Azure.Analytics.OnlineExperimentation.LifecycleStage Active { get { throw null; } }
        public static Azure.Analytics.OnlineExperimentation.LifecycleStage Inactive { get { throw null; } }
        public bool Equals(Azure.Analytics.OnlineExperimentation.LifecycleStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Analytics.OnlineExperimentation.LifecycleStage left, Azure.Analytics.OnlineExperimentation.LifecycleStage right) { throw null; }
        public static implicit operator Azure.Analytics.OnlineExperimentation.LifecycleStage (string value) { throw null; }
        public static bool operator !=(Azure.Analytics.OnlineExperimentation.LifecycleStage left, Azure.Analytics.OnlineExperimentation.LifecycleStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ObservedEvent : System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>
    {
        public ObservedEvent(string eventName) { }
        public string EventName { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ObservedEvent System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.ObservedEvent System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.ObservedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationClient
    {
        protected OnlineExperimentationClient() { }
        public OnlineExperimentationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public OnlineExperimentationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Analytics.OnlineExperimentation.OnlineExperimentationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> ActivateMetric(string experimentMetricId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> ActivateMetricAsync(string experimentMetricId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> CreateMetric(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetric metric, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> CreateMetricAsync(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetric metric, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> CreateOrUpdateMetric(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetric metric, Azure.ETag? ifMatch = default(Azure.ETag?), Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrUpdateMetric(string experimentMetricId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> CreateOrUpdateMetricAsync(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetric metric, Azure.ETag? ifMatch = default(Azure.ETag?), Azure.ETag? ifNoneMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateMetricAsync(string experimentMetricId, Azure.Core.RequestContent content, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> DeactivateMetric(string experimentMetricId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> DeactivateMetricAsync(string experimentMetricId, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteMetric(string experimentMetricId, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteMetricAsync(string experimentMetricId, Azure.RequestConditions requestConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetMetric(string experimentMetricId, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> GetMetric(string experimentMetricId, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMetricAsync(string experimentMetricId, Azure.RequestConditions requestConditions, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> GetMetricAsync(string experimentMetricId, Azure.RequestConditions requestConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetMetrics(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Analytics.OnlineExperimentation.ExperimentMetric> GetMetrics(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetMetricsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Analytics.OnlineExperimentation.ExperimentMetric> GetMetricsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric> UpdateMetric(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetricUpdate metric, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetric>> UpdateMetricAsync(string experimentMetricId, Azure.Analytics.OnlineExperimentation.ExperimentMetricUpdate metric, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult> ValidateMetric(Azure.Analytics.OnlineExperimentation.ExperimentMetric body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateMetric(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Analytics.OnlineExperimentation.ExperimentMetricValidationResult>> ValidateMetricAsync(Azure.Analytics.OnlineExperimentation.ExperimentMetric body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateMetricAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class OnlineExperimentationClientOptions : Azure.Core.ClientOptions
    {
        public OnlineExperimentationClientOptions(Azure.Analytics.OnlineExperimentation.OnlineExperimentationClientOptions.ServiceVersion version = Azure.Analytics.OnlineExperimentation.OnlineExperimentationClientOptions.ServiceVersion.V2025_05_31_Preview) { }
        public enum ServiceVersion
        {
            V2025_05_31_Preview = 1,
        }
    }
    public partial class PercentileMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>
    {
        public PercentileMetricDefinition(Azure.Analytics.OnlineExperimentation.AggregatedValue value, double percentile) { }
        public PercentileMetricDefinition(string eventName, string eventProperty, int percentile) { }
        public double Percentile { get { throw null; } set { } }
        public Azure.Analytics.OnlineExperimentation.AggregatedValue Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.PercentileMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SumMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>
    {
        public SumMetricDefinition(Azure.Analytics.OnlineExperimentation.AggregatedValue value) { }
        public SumMetricDefinition(string eventName, string eventProperty) { }
        public Azure.Analytics.OnlineExperimentation.AggregatedValue Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.SumMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.SumMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.SumMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserCountMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>
    {
        public UserCountMetricDefinition(Azure.Analytics.OnlineExperimentation.ObservedEvent @event) { }
        public UserCountMetricDefinition(string eventName) { }
        public Azure.Analytics.OnlineExperimentation.ObservedEvent Event { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserCountMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserRateMetricDefinition : Azure.Analytics.OnlineExperimentation.ExperimentMetricDefinition, System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>
    {
        public UserRateMetricDefinition(Azure.Analytics.OnlineExperimentation.ObservedEvent startEvent, Azure.Analytics.OnlineExperimentation.ObservedEvent endEvent) { }
        public UserRateMetricDefinition(string startEventName, string endEventName) { }
        public Azure.Analytics.OnlineExperimentation.ObservedEvent EndEvent { get { throw null; } set { } }
        public Azure.Analytics.OnlineExperimentation.ObservedEvent StartEvent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Analytics.OnlineExperimentation.UserRateMetricDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AnalyticsOnlineExperimentationClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.OnlineExperimentation.OnlineExperimentationClient, Azure.Analytics.OnlineExperimentation.OnlineExperimentationClientOptions> AddOnlineExperimentationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Analytics.OnlineExperimentation.OnlineExperimentationClient, Azure.Analytics.OnlineExperimentation.OnlineExperimentationClientOptions> AddOnlineExperimentationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
