namespace Azure.Provisioning.SelfHelp
{
    public partial class AutomatedCheckResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutomatedCheckResult() { }
        public Azure.Provisioning.BicepValue<string> Result { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.AutomatedCheckResultType> ResultType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutomatedCheckResultType
    {
        Success = 0,
        Warning = 1,
        Error = 2,
        Information = 3,
    }
    public enum ChartAggregationType
    {
        Sum = 0,
        Avg = 1,
        Count = 2,
        Min = 3,
        Max = 4,
    }
    public partial class KBSearchResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KBSearchResult() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpConfidence> Confidence { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Link { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Rank { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.KBSearchResultType> ResultType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum KBSearchResultType
    {
        Community = 0,
        Documentation = 1,
    }
    public partial class KBWebResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KBWebResult() { }
        public Azure.Provisioning.BicepValue<string> ReplacementKey { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.KBSearchResult> SearchResults { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MetricsBasedChart : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MetricsBasedChart() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.ChartAggregationType> AggregationType { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpFilter> Filter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplacementKey { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TimeSpanDuration { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ReplacementMapsResult : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ReplacementMapsResult() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.VideoGroupDetail> VideoGroups { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpVideo> Videos { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.KBWebResult> WebResults { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponseConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseConfig() { }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ResponseValidationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ResponseValidationProperties() { }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> MaxLength { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Regex { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ValidationErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.TroubleshooterValidationScope> ValidationScope { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SelfHelpConfidence
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class SelfHelpDiagnostic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SelfHelpDiagnostic(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AcceptedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticInfo> Diagnostics { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> GlobalParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticInvocation> Insights { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SelfHelp.SelfHelpDiagnostic FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_03_01_PREVIEW;
        }
    }
    public partial class SelfHelpDiagnosticInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpDiagnosticInfo() { }
        public Azure.Provisioning.SelfHelp.SelfHelpError Error { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticStatus> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHelpDiagnosticInsight : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpDiagnosticInsight() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpImportanceLevel> InsightImportanceLevel { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Results { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHelpDiagnosticInvocation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpDiagnosticInvocation() { }
        public Azure.Provisioning.BicepDictionary<string> AdditionalParameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SelfHelpDiagnosticStatus
    {
        Failed = 0,
        MissingInputs = 1,
        Running = 2,
        Succeeded = 3,
        Timeout = 4,
    }
    public partial class SelfHelpError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpError() { }
        public Azure.Provisioning.BicepValue<string> Code { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpError> Details { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ErrorType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHelpFilter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpFilter() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Operator { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Values { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SelfHelpImportanceLevel
    {
        Critical = 0,
        Warning = 1,
        Information = 2,
    }
    public enum SelfHelpName
    {
        SolutionId = 0,
        ProblemClassificationId = 1,
        ReplacementKey = 2,
    }
    public enum SelfHelpProvisioningState
    {
        Succeeded = 0,
        PartialComplete = 1,
        Failed = 2,
        Running = 3,
        Canceled = 4,
    }
    public partial class SelfHelpSection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpSection() { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.SelfHelp.SolutionReplacementMaps ReplacementMaps { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHelpSimplifiedSolution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SelfHelpSimplifiedSolution(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepDictionary<string> Appendix { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SolutionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SelfHelp.SelfHelpSimplifiedSolution FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_03_01_PREVIEW;
        }
    }
    public partial class SelfHelpSolution : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SelfHelpSolution(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SolutionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.SelfHelp.SolutionReplacementMaps ReplacementMaps { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpSection> Sections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SolutionTriggerCriterion> TriggerCriteria { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SelfHelp.SelfHelpSolution FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_03_01_PREVIEW;
        }
    }
    public partial class SelfHelpSolutionResult : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal SelfHelpSolutionResult() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.SelfHelp.ReplacementMapsResult ReplacementMaps { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SolutionSection> Sections { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SelfHelp.SelfHelpSolutionResult FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_03_01_PREVIEW;
        }
    }
    public partial class SelfHelpStep : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SelfHelpStep() { }
        public Azure.Provisioning.SelfHelp.AutomatedCheckResult AutomatedCheckResults { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.TroubleshooterExecutionStatus> ExecutionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ExecutionStatusDescription { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Guidance { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.TroubleshooterStepInput> Inputs { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLastStep { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpType> StepType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SelfHelpTroubleshooter : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public SelfHelpTroubleshooter(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.TroubleshooterProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Primitives.ProvisionableResource Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpStep> Steps { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.SelfHelp.SelfHelpTroubleshooter FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_03_01_PREVIEW;
        }
    }
    public enum SelfHelpType
    {
        Decision = 0,
        Solution = 1,
        Insight = 2,
        AutomatedCheck = 3,
        Input = 4,
    }
    public partial class SelfHelpVideo : Azure.Provisioning.SelfHelp.VideoGroupVideo
    {
        public SelfHelpVideo() { }
        public Azure.Provisioning.BicepValue<string> ReplacementKey { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SolutionProvisioningState
    {
        Succeeded = 0,
        PartialComplete = 1,
        Failed = 2,
        Running = 3,
        Canceled = 4,
    }
    public partial class SolutionReplacementMaps : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SolutionReplacementMaps() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SolutionsDiagnostic> Diagnostics { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.MetricsBasedChart> MetricsBasedCharts { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SolutionsTroubleshooters> Troubleshooters { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.VideoGroupDetail> VideoGroups { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpVideo> Videos { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.KBWebResult> WebResults { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SolutionsDiagnostic : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SolutionsDiagnostic() { }
        public Azure.Provisioning.BicepValue<string> EstimatedCompletionTime { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticInsight> Insights { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ReplacementKey { get { throw null; } }
        public Azure.Provisioning.BicepList<string> RequiredParameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpDiagnosticStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> StatusDetails { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SolutionSection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SolutionSection() { }
        public Azure.Provisioning.BicepValue<string> Content { get { throw null; } }
        public Azure.Provisioning.SelfHelp.ReplacementMapsResult ReplacementMaps { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SolutionsTroubleshooters : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SolutionsTroubleshooters() { }
        public Azure.Provisioning.BicepValue<string> SolutionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Summary { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SolutionTriggerCriterion : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SolutionTriggerCriterion() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.SelfHelpName> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TroubleshooterExecutionStatus
    {
        Success = 0,
        Running = 1,
        Failed = 2,
        Warning = 3,
    }
    public enum TroubleshooterProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Running = 3,
        AutoContinue = 4,
    }
    public enum TroubleshooterQuestionContentType
    {
        Text = 0,
        Html = 1,
        Markdown = 2,
    }
    public enum TroubleshooterQuestionType
    {
        RadioButton = 0,
        Dropdown = 1,
        TextInput = 2,
        MultiLineInfoBox = 3,
        DateTimePicker = 4,
        MultiSelect = 5,
    }
    public partial class TroubleshooterStepInput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TroubleshooterStepInput() { }
        public Azure.Provisioning.BicepValue<string> QuestionContent { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.TroubleshooterQuestionContentType> QuestionContentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QuestionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> QuestionTitle { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.SelfHelp.TroubleshooterQuestionType> QuestionType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RecommendedOption { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResponseHint { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.ResponseConfig> ResponseOptions { get { throw null; } }
        public Azure.Provisioning.SelfHelp.ResponseValidationProperties ResponseValidationProperties { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SelectedOptionValue { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TroubleshooterValidationScope
    {
        None = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="URLFormat")]
        UrlFormat = 1,
        GuidFormat = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="IpAddressFormat")]
        IPAddressFormat = 3,
        NumberOnlyFormat = 4,
    }
    public partial class VideoGroupDetail : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VideoGroupDetail() { }
        public Azure.Provisioning.BicepValue<string> ReplacementKey { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.SelfHelp.VideoGroupVideo> Videos { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class VideoGroupVideo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VideoGroupVideo() { }
        public Azure.Provisioning.BicepValue<string> Src { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Title { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
