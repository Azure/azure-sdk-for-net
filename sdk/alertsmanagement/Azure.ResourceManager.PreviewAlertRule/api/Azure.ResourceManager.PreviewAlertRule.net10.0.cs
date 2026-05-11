namespace Azure.ResourceManager.PreviewAlertRule
{
    public partial class AzureResourceManagerPreviewAlertRuleContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPreviewAlertRuleContext() { }
        public static Azure.ResourceManager.PreviewAlertRule.AzureResourceManagerPreviewAlertRuleContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PreviewAlertRuleExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse> PreviewAlertRule(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>> PreviewAlertRuleAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PreviewAlertRule.Mocking
{
    public partial class MockablePreviewAlertRuleArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePreviewAlertRuleArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse> PreviewAlertRule(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>> PreviewAlertRuleAsync(Azure.Core.ResourceIdentifier scope, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PreviewAlertRule.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertSeverity : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity>
    {
        private readonly int _dummyPrimitive;
        public AlertSeverity(int value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity Sev0 { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity Sev1 { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity Sev2 { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity Sev3 { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity Sev4 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity left, Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity (int value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity left, Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertState : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.AlertState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertState(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertState Fired { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertState Firing { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertState NoAlert { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertState Resolved { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.AlertState Resolving { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.AlertState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.AlertState left, Azure.ResourceManager.PreviewAlertRule.Models.AlertState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.AlertState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.AlertState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.AlertState left, Azure.ResourceManager.PreviewAlertRule.Models.AlertState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmPreviewAlertRuleModelFactory
    {
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule LogAlertRule(System.Collections.Generic.IDictionary<string, string> tags = null, string location = null, Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind? kind = default(Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind?), string description = null, string displayName = null, Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity? severity = default(Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity?), bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> scopes = null, System.TimeSpan? evaluationFrequency = default(System.TimeSpan?), System.TimeSpan? windowSize = default(System.TimeSpan?), System.TimeSpan? overrideQueryTimeRange = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<string> targetResourceTypes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition> criteriaAllOf = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition LogAlertRuleCondition(Azure.ResourceManager.PreviewAlertRule.Models.CriterionType? criterionType = default(Azure.ResourceManager.PreviewAlertRule.Models.CriterionType?), string query = null, Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation? timeAggregation = default(Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation?), string metricMeasureColumn = null, string resourceIdColumn = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension> dimensions = null, Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator? @operator = default(Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator?), double? threshold = default(double?), string alertSensitivity = null, System.DateTimeOffset? ignoreDataBefore = default(System.DateTimeOffset?), Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods failingPeriods = null, string metricName = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension LogAlertRuleDimension(string name = null, Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator @operator = default(Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest PreviewAlertRuleRequest(string location = null, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties PreviewAlertRuleRequestProperties(System.TimeSpan timespan = default(System.TimeSpan), Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule scheduledQueryRuleProperties = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse PreviewAlertRuleResponse(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult> rulePreviewResults = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue RulePreviewDimensionNameAndValue(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod RulePreviewEvaluatedPeriod(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), double? highThreshold = default(double?), double? lowThreshold = default(double?), double? metricValue = default(double?), bool? thresholdMet = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation RulePreviewEvaluation(System.DateTimeOffset? evaluationOn = default(System.DateTimeOffset?), Azure.ResourceManager.PreviewAlertRule.Models.AlertState? alertState = default(Azure.ResourceManager.PreviewAlertRule.Models.AlertState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod> evaluatedPeriods = null, bool? thresholdMet = default(bool?)) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult RulePreviewResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue> dimensionCombination = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation> evaluations = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionOperator : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionOperator(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator EqualTo { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator GreaterOrLessThan { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator left, Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator left, Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CriterionType : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.CriterionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CriterionType(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.CriterionType DynamicThresholdCriterion { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.CriterionType StaticThresholdCriterion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.CriterionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.CriterionType left, Azure.ResourceManager.PreviewAlertRule.Models.CriterionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.CriterionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.CriterionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.CriterionType left, Azure.ResourceManager.PreviewAlertRule.Models.CriterionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DimensionOperator : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DimensionOperator(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator Exclude { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator Include { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator left, Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator left, Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAlertRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>
    {
        public LogAlertRule(string location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition> CriteriaAllOf { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public System.TimeSpan? EvaluationFrequency { get { throw null; } }
        public Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind? Kind { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public System.TimeSpan? OverrideQueryTimeRange { get { throw null; } }
        public System.Collections.Generic.IList<string> Scopes { get { throw null; } }
        public Azure.ResourceManager.PreviewAlertRule.Models.AlertSeverity? Severity { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Collections.Generic.IList<string> TargetResourceTypes { get { throw null; } }
        public System.TimeSpan? WindowSize { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAlertRuleCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>
    {
        public LogAlertRuleCondition() { }
        public string AlertSensitivity { get { throw null; } set { } }
        public Azure.ResourceManager.PreviewAlertRule.Models.CriterionType? CriterionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension> Dimensions { get { throw null; } }
        public Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods FailingPeriods { get { throw null; } set { } }
        public System.DateTimeOffset? IgnoreDataBefore { get { throw null; } set { } }
        public string MetricMeasureColumn { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public Azure.ResourceManager.PreviewAlertRule.Models.ConditionOperator? Operator { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string ResourceIdColumn { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        public Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation? TimeAggregation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAlertRuleConditionFailingPeriods : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>
    {
        public LogAlertRuleConditionFailingPeriods() { }
        public long? MinFailingPeriodsToAlert { get { throw null; } set { } }
        public long? NumberOfEvaluationPeriods { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleConditionFailingPeriods>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAlertRuleDimension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>
    {
        public LogAlertRuleDimension(string name, Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PreviewAlertRule.Models.DimensionOperator Operator { get { throw null; } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleDimension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAlertRuleKind : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAlertRuleKind(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind EventLogAlert { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind LogAlert { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind LogToMetric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind left, Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind left, Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRuleKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PreviewAlertRuleRequest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>
    {
        public PreviewAlertRuleRequest(string location, Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreviewAlertRuleRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>
    {
        public PreviewAlertRuleRequestProperties(System.TimeSpan timespan) { }
        public Azure.ResourceManager.PreviewAlertRule.Models.LogAlertRule ScheduledQueryRuleProperties { get { throw null; } set { } }
        public System.TimeSpan Timespan { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreviewAlertRuleResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>
    {
        internal PreviewAlertRuleResponse() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult> RulePreviewResults { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.PreviewAlertRuleResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RulePreviewDimensionNameAndValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>
    {
        internal RulePreviewDimensionNameAndValue() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RulePreviewEvaluatedPeriod : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>
    {
        internal RulePreviewEvaluatedPeriod() { }
        public double? HighThreshold { get { throw null; } }
        public double? LowThreshold { get { throw null; } }
        public double? MetricValue { get { throw null; } }
        public bool? ThresholdMet { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RulePreviewEvaluation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>
    {
        internal RulePreviewEvaluation() { }
        public Azure.ResourceManager.PreviewAlertRule.Models.AlertState? AlertState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluatedPeriod> EvaluatedPeriods { get { throw null; } }
        public System.DateTimeOffset? EvaluationOn { get { throw null; } }
        public bool? ThresholdMet { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RulePreviewResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>
    {
        internal RulePreviewResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewDimensionNameAndValue> DimensionCombination { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewEvaluation> Evaluations { get { throw null; } }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PreviewAlertRule.Models.RulePreviewResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeAggregation : System.IEquatable<Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeAggregation(string value) { throw null; }
        public static Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation Average { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation Count { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation Maximum { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation Minimum { get { throw null; } }
        public static Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation Total { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation left, Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation right) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation left, Azure.ResourceManager.PreviewAlertRule.Models.TimeAggregation right) { throw null; }
        public override string ToString() { throw null; }
    }
}
