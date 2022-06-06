namespace Azure.AI.Language.Conversations
{
    public partial class AgeResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal AgeResolution() { }
        public Azure.AI.Language.Conversations.AgeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgeUnit : System.IEquatable<Azure.AI.Language.Conversations.AgeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgeUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.AgeUnit Day { get { throw null; } }
        public static Azure.AI.Language.Conversations.AgeUnit Month { get { throw null; } }
        public static Azure.AI.Language.Conversations.AgeUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.AgeUnit Week { get { throw null; } }
        public static Azure.AI.Language.Conversations.AgeUnit Year { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.AgeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.AgeUnit left, Azure.AI.Language.Conversations.AgeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.AgeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.AgeUnit left, Azure.AI.Language.Conversations.AgeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalysisParameters
    {
        public AnalysisParameters() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public partial class AnalyzeConversationOptions
    {
        public AnalyzeConversationOptions(Azure.AI.Language.Conversations.ConversationItemBase conversationItem) { }
        public Azure.AI.Language.Conversations.ConversationItemBase ConversationItem { get { throw null; } }
        public string DirectTarget { get { throw null; } set { } }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Language.Conversations.AnalysisParameters> Parameters { get { throw null; } }
        public bool Verbose { get { throw null; } set { } }
    }
    public partial class AnalyzeConversationResult
    {
        internal AnalyzeConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.BasePrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public partial class AnalyzeConversationTask
    {
        public AnalyzeConversationTask() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationTaskKind : System.IEquatable<Azure.AI.Language.Conversations.AnalyzeConversationTaskKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationTaskKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.AnalyzeConversationTaskKind CustomConversation { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.AnalyzeConversationTaskKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.AnalyzeConversationTaskKind left, Azure.AI.Language.Conversations.AnalyzeConversationTaskKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.AnalyzeConversationTaskKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.AnalyzeConversationTaskKind left, Azure.AI.Language.Conversations.AnalyzeConversationTaskKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeConversationTaskResult
    {
        internal AnalyzeConversationTaskResult() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeConversationTaskResultsKind : System.IEquatable<Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeConversationTaskResultsKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind CustomConversationResult { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind left, Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind left, Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnswerSpan
    {
        internal AnswerSpan() { }
        public double? Confidence { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AreaResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal AreaResolution() { }
        public Azure.AI.Language.Conversations.AreaUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AreaUnit : System.IEquatable<Azure.AI.Language.Conversations.AreaUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AreaUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.AreaUnit Acre { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareCentimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareDecameter { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareDecimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareFoot { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareHectometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareInch { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareKilometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareMeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareMile { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareMillimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit SquareYard { get { throw null; } }
        public static Azure.AI.Language.Conversations.AreaUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.AreaUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.AreaUnit left, Azure.AI.Language.Conversations.AreaUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.AreaUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.AreaUnit left, Azure.AI.Language.Conversations.AreaUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseExtraInformation
    {
        internal BaseExtraInformation() { }
    }
    public partial class BasePrediction
    {
        internal BasePrediction() { }
        public Azure.AI.Language.Conversations.ProjectKind ProjectKind { get { throw null; } set { } }
        public string TopIntent { get { throw null; } }
    }
    public partial class BaseResolution
    {
        internal BaseResolution() { }
    }
    public partial class BooleanResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal BooleanResolution() { }
        public bool Value { get { throw null; } }
    }
    public partial class ConversationAnalysisClient
    {
        protected ConversationAnalysisClient() { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ConversationAnalysisClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions options) { }
        public virtual System.Uri Endpoint { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Language.Conversations.AnalyzeConversationTaskResult> AnalyzeConversation(string utterance, Azure.AI.Language.Conversations.ConversationsProject project, Azure.AI.Language.Conversations.AnalyzeConversationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Language.Conversations.AnalyzeConversationTaskResult>> AnalyzeConversationAsync(string utterance, Azure.AI.Language.Conversations.ConversationsProject project, Azure.AI.Language.Conversations.AnalyzeConversationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConversationAnalysisClientOptions : Azure.Core.ClientOptions
    {
        public ConversationAnalysisClientOptions(Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion version = Azure.AI.Language.Conversations.ConversationAnalysisClientOptions.ServiceVersion.V2022_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2021_11_01_Preview = 1,
            V2022_03_01_Preview = 2,
        }
    }
    public partial class ConversationCallingOptions
    {
        public ConversationCallingOptions() { }
        public bool? IsLoggingEnabled { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class ConversationEntity
    {
        internal ConversationEntity() { }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.BaseExtraInformation> ExtraInformation { get { throw null; } }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.BaseResolution> Resolutions { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class ConversationIntent
    {
        internal ConversationIntent() { }
        public string Category { get { throw null; } }
        public float Confidence { get { throw null; } }
    }
    public partial class ConversationItemBase
    {
        public ConversationItemBase(string participantId, string id) { }
        public string Id { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public string ParticipantId { get { throw null; } }
    }
    public partial class ConversationParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public ConversationParameters() { }
        public Azure.AI.Language.Conversations.ConversationCallingOptions CallingOptions { get { throw null; } set { } }
    }
    public partial class ConversationPrediction : Azure.AI.Language.Conversations.BasePrediction
    {
        internal ConversationPrediction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.ConversationEntity> Entities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.ConversationIntent> Intents { get { throw null; } }
    }
    public partial class ConversationResult
    {
        internal ConversationResult() { }
        public string DetectedLanguage { get { throw null; } }
        public Azure.AI.Language.Conversations.ConversationPrediction Prediction { get { throw null; } }
        public string Query { get { throw null; } }
    }
    public static partial class ConversationsModelFactory
    {
        public static Azure.AI.Language.Conversations.AgeResolution AgeResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.AgeUnit unit = default(Azure.AI.Language.Conversations.AgeUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.AnalyzeConversationResult AnalyzeConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.BasePrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.AnswerSpan AnswerSpan(string text = null, double? confidence = default(double?), int? offset = default(int?), int? length = default(int?)) { throw null; }
        public static Azure.AI.Language.Conversations.AreaResolution AreaResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.AreaUnit unit = default(Azure.AI.Language.Conversations.AreaUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.BasePrediction BasePrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null) { throw null; }
        public static Azure.AI.Language.Conversations.BooleanResolution BooleanResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), bool value = false) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationEntity ConversationEntity(string category = null, string text = null, int offset = 0, int length = 0, float confidence = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.BaseResolution> resolutions = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.BaseExtraInformation> extraInformation = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationIntent ConversationIntent(string category = null, float confidence = 0f) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationPrediction ConversationPrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.ConversationIntent> intents = null, System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.ConversationEntity> entities = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationResult ConversationResult(string query = null, string detectedLanguage = null, Azure.AI.Language.Conversations.ConversationPrediction prediction = null) { throw null; }
        public static Azure.AI.Language.Conversations.ConversationTargetIntentResult ConversationTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.CurrencyResolution CurrencyResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), string isO4217 = null, string unit = null, double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.CustomConversationalTaskResult CustomConversationalTaskResult(Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind kind = default(Azure.AI.Language.Conversations.AnalyzeConversationTaskResultsKind), Azure.AI.Language.Conversations.AnalyzeConversationResult results = null) { throw null; }
        public static Azure.AI.Language.Conversations.DateTimeResolution DateTimeResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), string timex = null, Azure.AI.Language.Conversations.DateTimeSubKind dateTimeSubKind = default(Azure.AI.Language.Conversations.DateTimeSubKind), string value = null, Azure.AI.Language.Conversations.TemporalModifier? modifier = default(Azure.AI.Language.Conversations.TemporalModifier?)) { throw null; }
        public static Azure.AI.Language.Conversations.EntitySubtype EntitySubtype(Azure.AI.Language.Conversations.ExtraInformationKind extraInformationKind = default(Azure.AI.Language.Conversations.ExtraInformationKind), string value = null) { throw null; }
        public static Azure.AI.Language.Conversations.InformationResolution InformationResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.InformationUnit unit = default(Azure.AI.Language.Conversations.InformationUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswer KnowledgeBaseAnswer(System.Collections.Generic.IEnumerable<string> questions = null, string answer = null, double? confidence = default(double?), int? id = default(int?), string source = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog dialog = null, Azure.AI.Language.Conversations.AnswerSpan answerSpan = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog KnowledgeBaseAnswerDialog(bool? isContextOnly = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt> prompts = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt KnowledgeBaseAnswerPrompt(int? displayOrder = default(int?), int? qnaId = default(int?), string displayText = null) { throw null; }
        public static Azure.AI.Language.Conversations.KnowledgeBaseAnswers KnowledgeBaseAnswers(System.Collections.Generic.IEnumerable<Azure.AI.Language.Conversations.KnowledgeBaseAnswer> answers = null) { throw null; }
        public static Azure.AI.Language.Conversations.LengthResolution LengthResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.LengthUnit unit = default(Azure.AI.Language.Conversations.LengthUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.ListKey ListKey(Azure.AI.Language.Conversations.ExtraInformationKind extraInformationKind = default(Azure.AI.Language.Conversations.ExtraInformationKind), string key = null) { throw null; }
        public static Azure.AI.Language.Conversations.LuisTargetIntentResult LuisTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, float confidenceScore = 0f, object result = null) { throw null; }
        public static Azure.AI.Language.Conversations.NoneLinkedTargetIntentResult NoneLinkedTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.ConversationResult result = null) { throw null; }
        public static Azure.AI.Language.Conversations.NumberResolution NumberResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.NumberKind numberKind = default(Azure.AI.Language.Conversations.NumberKind), string value = null) { throw null; }
        public static Azure.AI.Language.Conversations.NumericRangeResolution NumericRangeResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.RangeKind rangeKind = default(Azure.AI.Language.Conversations.RangeKind), double minimum = 0, double maximum = 0) { throw null; }
        public static Azure.AI.Language.Conversations.OrchestratorPrediction OrchestratorPrediction(Azure.AI.Language.Conversations.ProjectKind projectKind = default(Azure.AI.Language.Conversations.ProjectKind), string topIntent = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.TargetIntentResult> intents = null) { throw null; }
        public static Azure.AI.Language.Conversations.OrdinalResolution OrdinalResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), string offset = null, Azure.AI.Language.Conversations.RelativeTo relativeTo = default(Azure.AI.Language.Conversations.RelativeTo), string value = null) { throw null; }
        public static Azure.AI.Language.Conversations.QuantityResolution QuantityResolution(double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.QuestionAnsweringTargetIntentResult QuestionAnsweringTargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0, Azure.AI.Language.Conversations.KnowledgeBaseAnswers result = null) { throw null; }
        public static Azure.AI.Language.Conversations.SpeedResolution SpeedResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.SpeedUnit unit = default(Azure.AI.Language.Conversations.SpeedUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.TargetIntentResult TargetIntentResult(Azure.AI.Language.Conversations.TargetKind targetKind = default(Azure.AI.Language.Conversations.TargetKind), string apiVersion = null, double confidence = 0) { throw null; }
        public static Azure.AI.Language.Conversations.TemperatureResolution TemperatureResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.TemperatureUnit unit = default(Azure.AI.Language.Conversations.TemperatureUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.TemporalSpanResolution TemporalSpanResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), string begin = null, string end = null, string duration = null, Azure.AI.Language.Conversations.TemporalModifier? modifier = default(Azure.AI.Language.Conversations.TemporalModifier?)) { throw null; }
        public static Azure.AI.Language.Conversations.VolumeResolution VolumeResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.VolumeUnit unit = default(Azure.AI.Language.Conversations.VolumeUnit), double value = 0) { throw null; }
        public static Azure.AI.Language.Conversations.WeightResolution WeightResolution(Azure.AI.Language.Conversations.ResolutionKind resolutionKind = default(Azure.AI.Language.Conversations.ResolutionKind), Azure.AI.Language.Conversations.WeightUnit unit = default(Azure.AI.Language.Conversations.WeightUnit), double value = 0) { throw null; }
    }
    public partial class ConversationsProject
    {
        public ConversationsProject(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
    }
    public partial class ConversationTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal ConversationTargetIntentResult() { }
        public Azure.AI.Language.Conversations.ConversationResult Result { get { throw null; } }
    }
    public partial class CurrencyResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal CurrencyResolution() { }
        public string ISO4217 { get { throw null; } }
        public string Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    public partial class CustomConversationalTask : Azure.AI.Language.Conversations.AnalyzeConversationTask
    {
        public CustomConversationalTask(Azure.AI.Language.Conversations.AnalyzeConversationOptions analysisInput, Azure.AI.Language.Conversations.CustomConversationTaskParameters parameters) { }
        public Azure.AI.Language.Conversations.AnalyzeConversationOptions AnalysisInput { get { throw null; } }
        public Azure.AI.Language.Conversations.CustomConversationTaskParameters Parameters { get { throw null; } }
    }
    public partial class CustomConversationalTaskResult : Azure.AI.Language.Conversations.AnalyzeConversationTaskResult
    {
        internal CustomConversationalTaskResult() { }
        public Azure.AI.Language.Conversations.AnalyzeConversationResult Results { get { throw null; } }
    }
    public partial class CustomConversationTaskParameters
    {
        public CustomConversationTaskParameters(string projectName, string deploymentName) { }
        public string DeploymentName { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class DateTimeResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal DateTimeResolution() { }
        public Azure.AI.Language.Conversations.DateTimeSubKind DateTimeSubKind { get { throw null; } }
        public Azure.AI.Language.Conversations.TemporalModifier? Modifier { get { throw null; } }
        public string Timex { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DateTimeSubKind : System.IEquatable<Azure.AI.Language.Conversations.DateTimeSubKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DateTimeSubKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.DateTimeSubKind Date { get { throw null; } }
        public static Azure.AI.Language.Conversations.DateTimeSubKind DateTime { get { throw null; } }
        public static Azure.AI.Language.Conversations.DateTimeSubKind Duration { get { throw null; } }
        public static Azure.AI.Language.Conversations.DateTimeSubKind Set { get { throw null; } }
        public static Azure.AI.Language.Conversations.DateTimeSubKind Time { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.DateTimeSubKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.DateTimeSubKind left, Azure.AI.Language.Conversations.DateTimeSubKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.DateTimeSubKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.DateTimeSubKind left, Azure.AI.Language.Conversations.DateTimeSubKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntitySubtype : Azure.AI.Language.Conversations.BaseExtraInformation
    {
        internal EntitySubtype() { }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtraInformationKind : System.IEquatable<Azure.AI.Language.Conversations.ExtraInformationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtraInformationKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.ExtraInformationKind EntitySubtype { get { throw null; } }
        public static Azure.AI.Language.Conversations.ExtraInformationKind ListKey { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.ExtraInformationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.ExtraInformationKind left, Azure.AI.Language.Conversations.ExtraInformationKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.ExtraInformationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.ExtraInformationKind left, Azure.AI.Language.Conversations.ExtraInformationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InformationResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal InformationResolution() { }
        public Azure.AI.Language.Conversations.InformationUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InformationUnit : System.IEquatable<Azure.AI.Language.Conversations.InformationUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InformationUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.InformationUnit Bit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Byte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Gigabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Gigabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Kilobit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Kilobyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Megabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Megabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Petabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Petabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Terabit { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Terabyte { get { throw null; } }
        public static Azure.AI.Language.Conversations.InformationUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.InformationUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.InformationUnit left, Azure.AI.Language.Conversations.InformationUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.InformationUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.InformationUnit left, Azure.AI.Language.Conversations.InformationUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InputModality : System.IEquatable<Azure.AI.Language.Conversations.InputModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InputModality(string value) { throw null; }
        public static Azure.AI.Language.Conversations.InputModality Text { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.InputModality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.InputModality left, Azure.AI.Language.Conversations.InputModality right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.InputModality (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.InputModality left, Azure.AI.Language.Conversations.InputModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgeBaseAnswer
    {
        internal KnowledgeBaseAnswer() { }
        public string Answer { get { throw null; } }
        public Azure.AI.Language.Conversations.AnswerSpan AnswerSpan { get { throw null; } }
        public double? Confidence { get { throw null; } }
        public Azure.AI.Language.Conversations.KnowledgeBaseAnswerDialog Dialog { get { throw null; } }
        public int? Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Questions { get { throw null; } }
        public string Source { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswerDialog
    {
        internal KnowledgeBaseAnswerDialog() { }
        public bool? IsContextOnly { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.KnowledgeBaseAnswerPrompt> Prompts { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswerPrompt
    {
        internal KnowledgeBaseAnswerPrompt() { }
        public int? DisplayOrder { get { throw null; } }
        public string DisplayText { get { throw null; } }
        public int? QnaId { get { throw null; } }
    }
    public partial class KnowledgeBaseAnswers
    {
        internal KnowledgeBaseAnswers() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Language.Conversations.KnowledgeBaseAnswer> Answers { get { throw null; } }
    }
    public partial class LengthResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal LengthResolution() { }
        public Azure.AI.Language.Conversations.LengthUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LengthUnit : System.IEquatable<Azure.AI.Language.Conversations.LengthUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LengthUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.LengthUnit Centimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Decameter { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Decimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Foot { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Hectometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Inch { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Kilometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit LightYear { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Meter { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Micrometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Mile { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Millimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Nanometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Picometer { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Pt { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.LengthUnit Yard { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.LengthUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.LengthUnit left, Azure.AI.Language.Conversations.LengthUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.LengthUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.LengthUnit left, Azure.AI.Language.Conversations.LengthUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ListKey : Azure.AI.Language.Conversations.BaseExtraInformation
    {
        internal ListKey() { }
        public string Key { get { throw null; } }
    }
    public partial class LuisCallingOptions
    {
        public LuisCallingOptions() { }
        public string BingSpellCheckSubscriptionKey { get { throw null; } set { } }
        public bool? Log { get { throw null; } set { } }
        public bool? ShowAllIntents { get { throw null; } set { } }
        public bool? SpellCheck { get { throw null; } set { } }
        public float? TimezoneOffset { get { throw null; } set { } }
        public bool? Verbose { get { throw null; } set { } }
    }
    public partial class LuisParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public LuisParameters() { }
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get { throw null; } }
        public Azure.AI.Language.Conversations.LuisCallingOptions CallingOptions { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
    }
    public partial class LuisTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal LuisTargetIntentResult() { }
        public System.BinaryData Result { get { throw null; } }
    }
    public partial class NoneLinkedTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal NoneLinkedTargetIntentResult() { }
        public Azure.AI.Language.Conversations.ConversationResult Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NumberKind : System.IEquatable<Azure.AI.Language.Conversations.NumberKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NumberKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.NumberKind Decimal { get { throw null; } }
        public static Azure.AI.Language.Conversations.NumberKind Fraction { get { throw null; } }
        public static Azure.AI.Language.Conversations.NumberKind Integer { get { throw null; } }
        public static Azure.AI.Language.Conversations.NumberKind Percent { get { throw null; } }
        public static Azure.AI.Language.Conversations.NumberKind Power { get { throw null; } }
        public static Azure.AI.Language.Conversations.NumberKind Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.NumberKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.NumberKind left, Azure.AI.Language.Conversations.NumberKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.NumberKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.NumberKind left, Azure.AI.Language.Conversations.NumberKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NumberResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal NumberResolution() { }
        public Azure.AI.Language.Conversations.NumberKind NumberKind { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class NumericRangeResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal NumericRangeResolution() { }
        public double Maximum { get { throw null; } }
        public double Minimum { get { throw null; } }
        public Azure.AI.Language.Conversations.RangeKind RangeKind { get { throw null; } }
    }
    public partial class OrchestratorPrediction : Azure.AI.Language.Conversations.BasePrediction
    {
        internal OrchestratorPrediction() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Language.Conversations.TargetIntentResult> Intents { get { throw null; } }
    }
    public partial class OrdinalResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal OrdinalResolution() { }
        public string Offset { get { throw null; } }
        public Azure.AI.Language.Conversations.RelativeTo RelativeTo { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectKind : System.IEquatable<Azure.AI.Language.Conversations.ProjectKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.ProjectKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.ProjectKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.ProjectKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.ProjectKind left, Azure.AI.Language.Conversations.ProjectKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.ProjectKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.ProjectKind left, Azure.AI.Language.Conversations.ProjectKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class QuantityResolution
    {
        internal QuantityResolution() { }
        public double Value { get { throw null; } }
    }
    public partial class QuestionAnsweringParameters : Azure.AI.Language.Conversations.AnalysisParameters
    {
        public QuestionAnsweringParameters() { }
        public object CallingOptions { get { throw null; } set { } }
    }
    public partial class QuestionAnsweringTargetIntentResult : Azure.AI.Language.Conversations.TargetIntentResult
    {
        internal QuestionAnsweringTargetIntentResult() { }
        public Azure.AI.Language.Conversations.KnowledgeBaseAnswers Result { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RangeKind : System.IEquatable<Azure.AI.Language.Conversations.RangeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RangeKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.RangeKind Age { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Area { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Currency { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Information { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Length { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Number { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Speed { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Temperature { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Volume { get { throw null; } }
        public static Azure.AI.Language.Conversations.RangeKind Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.RangeKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.RangeKind left, Azure.AI.Language.Conversations.RangeKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.RangeKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.RangeKind left, Azure.AI.Language.Conversations.RangeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RelativeTo : System.IEquatable<Azure.AI.Language.Conversations.RelativeTo>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RelativeTo(string value) { throw null; }
        public static Azure.AI.Language.Conversations.RelativeTo Current { get { throw null; } }
        public static Azure.AI.Language.Conversations.RelativeTo End { get { throw null; } }
        public static Azure.AI.Language.Conversations.RelativeTo Start { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.RelativeTo other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.RelativeTo left, Azure.AI.Language.Conversations.RelativeTo right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.RelativeTo (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.RelativeTo left, Azure.AI.Language.Conversations.RelativeTo right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResolutionKind : System.IEquatable<Azure.AI.Language.Conversations.ResolutionKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResolutionKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.ResolutionKind Age { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Area { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Boolean { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Currency { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind DateTime { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Information { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Length { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Number { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind NumericRange { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Ordinal { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Speed { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Temperature { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind TemporalSpan { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Volume { get { throw null; } }
        public static Azure.AI.Language.Conversations.ResolutionKind Weight { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.ResolutionKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.ResolutionKind left, Azure.AI.Language.Conversations.ResolutionKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.ResolutionKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.ResolutionKind left, Azure.AI.Language.Conversations.ResolutionKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SpeedResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal SpeedResolution() { }
        public Azure.AI.Language.Conversations.SpeedUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpeedUnit : System.IEquatable<Azure.AI.Language.Conversations.SpeedUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpeedUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.SpeedUnit CentimetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit FootPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit FootPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit KilometersPerHour { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit KilometersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit KilometersPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit KilometersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit Knot { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit MetersPerMillisecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit MetersPerSecond { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit MilesPerHour { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit Unspecified { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit YardsPerMinute { get { throw null; } }
        public static Azure.AI.Language.Conversations.SpeedUnit YardsPerSecond { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.SpeedUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.SpeedUnit left, Azure.AI.Language.Conversations.SpeedUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.SpeedUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.SpeedUnit left, Azure.AI.Language.Conversations.SpeedUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetIntentResult
    {
        internal TargetIntentResult() { }
        public string ApiVersion { get { throw null; } }
        public double Confidence { get { throw null; } }
        public Azure.AI.Language.Conversations.TargetKind TargetKind { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetKind : System.IEquatable<Azure.AI.Language.Conversations.TargetKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetKind(string value) { throw null; }
        public static Azure.AI.Language.Conversations.TargetKind Conversation { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind Luis { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind NonLinked { get { throw null; } }
        public static Azure.AI.Language.Conversations.TargetKind QuestionAnswering { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.TargetKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.TargetKind left, Azure.AI.Language.Conversations.TargetKind right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.TargetKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.TargetKind left, Azure.AI.Language.Conversations.TargetKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemperatureResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal TemperatureResolution() { }
        public Azure.AI.Language.Conversations.TemperatureUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemperatureUnit : System.IEquatable<Azure.AI.Language.Conversations.TemperatureUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemperatureUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.TemperatureUnit Celsius { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemperatureUnit Fahrenheit { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemperatureUnit Kelvin { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemperatureUnit Rankine { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemperatureUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.TemperatureUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.TemperatureUnit left, Azure.AI.Language.Conversations.TemperatureUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.TemperatureUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.TemperatureUnit left, Azure.AI.Language.Conversations.TemperatureUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemporalModifier : System.IEquatable<Azure.AI.Language.Conversations.TemporalModifier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemporalModifier(string value) { throw null; }
        public static Azure.AI.Language.Conversations.TemporalModifier After { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier AfterApprox { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier AfterMid { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier AfterStart { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Approx { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Before { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier BeforeApprox { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier BeforeEnd { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier BeforeStart { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier End { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Less { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Mid { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier More { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier ReferenceUndefined { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Since { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier SinceEnd { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Start { get { throw null; } }
        public static Azure.AI.Language.Conversations.TemporalModifier Until { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.TemporalModifier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.TemporalModifier left, Azure.AI.Language.Conversations.TemporalModifier right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.TemporalModifier (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.TemporalModifier left, Azure.AI.Language.Conversations.TemporalModifier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemporalSpanResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal TemporalSpanResolution() { }
        public string Begin { get { throw null; } }
        public string Duration { get { throw null; } }
        public string End { get { throw null; } }
        public Azure.AI.Language.Conversations.TemporalModifier? Modifier { get { throw null; } }
    }
    public partial class TextConversationItem : Azure.AI.Language.Conversations.ConversationItemBase
    {
        public TextConversationItem(string participantId, string id, string text) : base (default(string), default(string)) { }
        public string Text { get { throw null; } }
    }
    public partial class VolumeResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal VolumeResolution() { }
        public Azure.AI.Language.Conversations.VolumeUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeUnit : System.IEquatable<Azure.AI.Language.Conversations.VolumeUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.VolumeUnit Barrel { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Bushel { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Centiliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Cord { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicCentimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicFoot { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicInch { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicMeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicMile { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicMillimeter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit CubicYard { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Cup { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Decaliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit FluidDram { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit FluidOunce { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Gill { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Hectoliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Hogshead { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Liter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Milliliter { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Minim { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Peck { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Pinch { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Pint { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Quart { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Tablespoon { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Teaspoon { get { throw null; } }
        public static Azure.AI.Language.Conversations.VolumeUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.VolumeUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.VolumeUnit left, Azure.AI.Language.Conversations.VolumeUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.VolumeUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.VolumeUnit left, Azure.AI.Language.Conversations.VolumeUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WeightResolution : Azure.AI.Language.Conversations.BaseResolution
    {
        internal WeightResolution() { }
        public Azure.AI.Language.Conversations.WeightUnit Unit { get { throw null; } }
        public double Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeightUnit : System.IEquatable<Azure.AI.Language.Conversations.WeightUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeightUnit(string value) { throw null; }
        public static Azure.AI.Language.Conversations.WeightUnit Dram { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Gallon { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Grain { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Gram { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Kilogram { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit LongTonBritish { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit MetricTon { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Milligram { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Ounce { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit PennyWeight { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Pound { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit ShortHundredWeightUS { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit ShortTonUS { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Stone { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Ton { get { throw null; } }
        public static Azure.AI.Language.Conversations.WeightUnit Unspecified { get { throw null; } }
        public bool Equals(Azure.AI.Language.Conversations.WeightUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Language.Conversations.WeightUnit left, Azure.AI.Language.Conversations.WeightUnit right) { throw null; }
        public static implicit operator Azure.AI.Language.Conversations.WeightUnit (string value) { throw null; }
        public static bool operator !=(Azure.AI.Language.Conversations.WeightUnit left, Azure.AI.Language.Conversations.WeightUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ConversationAnalysisClientExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Language.Conversations.ConversationAnalysisClient, Azure.AI.Language.Conversations.ConversationAnalysisClientOptions> AddConversationAnalysisClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
