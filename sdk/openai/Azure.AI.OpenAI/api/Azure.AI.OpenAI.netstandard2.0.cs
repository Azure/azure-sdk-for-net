namespace Azure.AI.OpenAI
{
    public partial class AudioTranscription
    {
        internal AudioTranscription() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranscriptionSegment> Segments { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioTranscriptionFormat : System.IEquatable<Azure.AI.OpenAI.AudioTranscriptionFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioTranscriptionFormat(string value) { throw null; }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Srt { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Verbose { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranscriptionFormat Vtt { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AudioTranscriptionFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AudioTranscriptionFormat left, Azure.AI.OpenAI.AudioTranscriptionFormat right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AudioTranscriptionFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AudioTranscriptionFormat left, Azure.AI.OpenAI.AudioTranscriptionFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioTranscriptionOptions
    {
        public AudioTranscriptionOptions() { }
        public AudioTranscriptionOptions(string deploymentName, System.BinaryData audioData) { }
        public System.BinaryData AudioData { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public string Language { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.AudioTranscriptionFormat? ResponseFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
    }
    public partial class AudioTranscriptionSegment
    {
        internal AudioTranscriptionSegment() { }
        public float AverageLogProbability { get { throw null; } }
        public float CompressionRatio { get { throw null; } }
        public System.TimeSpan End { get { throw null; } }
        public int Id { get { throw null; } }
        public float NoSpeechProbability { get { throw null; } }
        public int Seek { get { throw null; } }
        public System.TimeSpan Start { get { throw null; } }
        public float Temperature { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Tokens { get { throw null; } }
    }
    public partial class AudioTranslation
    {
        internal AudioTranslation() { }
        public System.TimeSpan? Duration { get { throw null; } }
        public string Language { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranslationSegment> Segments { get { throw null; } }
        public string Text { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AudioTranslationFormat : System.IEquatable<Azure.AI.OpenAI.AudioTranslationFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AudioTranslationFormat(string value) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslationFormat Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Srt { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Verbose { get { throw null; } }
        public static Azure.AI.OpenAI.AudioTranslationFormat Vtt { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AudioTranslationFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AudioTranslationFormat left, Azure.AI.OpenAI.AudioTranslationFormat right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AudioTranslationFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AudioTranslationFormat left, Azure.AI.OpenAI.AudioTranslationFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AudioTranslationOptions
    {
        public AudioTranslationOptions() { }
        public AudioTranslationOptions(string deploymentName, System.BinaryData audioData) { }
        public System.BinaryData AudioData { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.AudioTranslationFormat? ResponseFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
    }
    public partial class AudioTranslationSegment
    {
        internal AudioTranslationSegment() { }
        public float AverageLogProbability { get { throw null; } }
        public float CompressionRatio { get { throw null; } }
        public System.TimeSpan End { get { throw null; } }
        public int Id { get { throw null; } }
        public float NoSpeechProbability { get { throw null; } }
        public int Seek { get { throw null; } }
        public System.TimeSpan Start { get { throw null; } }
        public float Temperature { get { throw null; } }
        public string Text { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<int> Tokens { get { throw null; } }
    }
    public partial class AzureChatEnhancementConfiguration
    {
        public AzureChatEnhancementConfiguration() { }
        public Azure.AI.OpenAI.AzureChatGroundingEnhancementConfiguration Grounding { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureChatOCREnhancementConfiguration Ocr { get { throw null; } set { } }
    }
    public partial class AzureChatEnhancements
    {
        internal AzureChatEnhancements() { }
        public Azure.AI.OpenAI.AzureGroundingEnhancement Grounding { get { throw null; } }
    }
    public abstract partial class AzureChatExtensionConfiguration
    {
        protected AzureChatExtensionConfiguration() { }
    }
    public partial class AzureChatExtensionsMessageContext
    {
        internal AzureChatExtensionsMessageContext() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatResponseMessage> Messages { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResultsForPrompt RequestContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ResponseContentFilterResults { get { throw null; } }
    }
    public partial class AzureChatExtensionsOptions
    {
        public AzureChatExtensionsOptions() { }
        public Azure.AI.OpenAI.AzureChatEnhancementConfiguration EnhancementOptions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.AzureChatExtensionConfiguration> Extensions { get { throw null; } }
    }
    public partial class AzureChatGroundingEnhancementConfiguration
    {
        public AzureChatGroundingEnhancementConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } }
    }
    public partial class AzureChatOCREnhancementConfiguration
    {
        public AzureChatOCREnhancementConfiguration(bool enabled) { }
        public bool Enabled { get { throw null; } }
    }
    public partial class AzureCognitiveSearchChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public AzureCognitiveSearchChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public System.Uri EmbeddingEndpoint { get { throw null; } set { } }
        public string EmbeddingKey { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCognitiveSearchIndexFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCognitiveSearchQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public System.Uri SearchEndpoint { get { throw null; } set { } }
        public string SemanticConfiguration { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
    }
    public partial class AzureCognitiveSearchIndexFieldMappingOptions
    {
        public AzureCognitiveSearchIndexFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageVectorFieldNames { get { throw null; } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureCognitiveSearchQueryType : System.IEquatable<Azure.AI.OpenAI.AzureCognitiveSearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureCognitiveSearchQueryType(string value) { throw null; }
        public static Azure.AI.OpenAI.AzureCognitiveSearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.OpenAI.AzureCognitiveSearchQueryType Simple { get { throw null; } }
        public static Azure.AI.OpenAI.AzureCognitiveSearchQueryType Vector { get { throw null; } }
        public static Azure.AI.OpenAI.AzureCognitiveSearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.OpenAI.AzureCognitiveSearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AzureCognitiveSearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AzureCognitiveSearchQueryType left, Azure.AI.OpenAI.AzureCognitiveSearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AzureCognitiveSearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AzureCognitiveSearchQueryType left, Azure.AI.OpenAI.AzureCognitiveSearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureCosmosDBChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public AzureCosmosDBChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCosmosDBFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
    }
    public partial class AzureCosmosDBFieldMappingOptions
    {
        public AzureCosmosDBFieldMappingOptions(System.Collections.Generic.IEnumerable<string> vectorFieldNames) { }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
    }
    public partial class AzureGroundingEnhancement
    {
        internal AzureGroundingEnhancement() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementLine> Lines { get { throw null; } }
    }
    public partial class AzureGroundingEnhancementCoordinatePoint
    {
        internal AzureGroundingEnhancementCoordinatePoint() { }
        public float X { get { throw null; } }
        public float Y { get { throw null; } }
    }
    public partial class AzureGroundingEnhancementLine
    {
        internal AzureGroundingEnhancementLine() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan> Spans { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AzureGroundingEnhancementLineSpan
    {
        internal AzureGroundingEnhancementLineSpan() { }
        public int Length { get { throw null; } }
        public int Offset { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint> Polygon { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class AzureMachineLearningIndexChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public AzureMachineLearningIndexChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProjectResourceId { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public static partial class AzureOpenAIModelFactory
    {
        public static Azure.AI.OpenAI.AudioTranscription AudioTranscription(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranscriptionSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranscriptionSegment AudioTranscriptionSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslation AudioTranslation(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranslationSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslationSegment AudioTranslationSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.AzureChatEnhancements AzureChatEnhancements(Azure.AI.OpenAI.AzureGroundingEnhancement grounding = null) { throw null; }
        public static Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureChatExtensionsMessageContext(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatResponseMessage> messages = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancement AzureGroundingEnhancement(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementLine> lines = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint AzureGroundingEnhancementCoordinatePoint(float x = 0f, float y = 0f) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementLine AzureGroundingEnhancementLine(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan> spans = null) { throw null; }
        public static Azure.AI.OpenAI.AzureGroundingEnhancementLineSpan AzureGroundingEnhancementLineSpan(string text = null, int offset = 0, int length = 0, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.AzureGroundingEnhancementCoordinatePoint> polygon = null) { throw null; }
        public static Azure.AI.OpenAI.ChatChoice ChatChoice(Azure.AI.OpenAI.ChatResponseMessage message = null, int index = 0, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?), Azure.AI.OpenAI.ChatFinishDetails finishDetails = null, Azure.AI.OpenAI.ChatResponseMessage deltaMessage = null, Azure.AI.OpenAI.ContentFilterResultsForChoice contentFilterResults = null, Azure.AI.OpenAI.AzureChatEnhancements enhancements = null) { throw null; }
        public static Azure.AI.OpenAI.ChatCompletions ChatCompletions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatChoice> choices = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterResultsForPrompt> promptFilterResults = null, string systemFingerprint = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.ChatResponseMessage ChatResponseMessage(Azure.AI.OpenAI.ChatRole role = default(Azure.AI.OpenAI.ChatRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatCompletionsToolCall> toolCalls = null, Azure.AI.OpenAI.FunctionCall functionCall = null, Azure.AI.OpenAI.AzureChatExtensionsMessageContext azureExtensionsContext = null) { throw null; }
        public static Azure.AI.OpenAI.Choice Choice(string text = null, int index = 0, Azure.AI.OpenAI.ContentFilterResultsForChoice contentFilterResults = null, Azure.AI.OpenAI.CompletionsLogProbabilityModel logProbabilityModel = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?)) { throw null; }
        public static Azure.AI.OpenAI.Completions Completions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterResultsForPrompt> promptFilterResults = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Choice> choices = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsLogProbabilityModel CompletionsLogProbabilityModel(System.Collections.Generic.IEnumerable<string> tokens = null, System.Collections.Generic.IEnumerable<float?> tokenLogProbabilities = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, float?>> topLogProbabilities = null, System.Collections.Generic.IEnumerable<int> textOffsets = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterBlocklistIdResult ContentFilterBlocklistIdResult(string id = null, bool filtered = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterCitedDetectionResult ContentFilterCitedDetectionResult(bool filtered = false, bool detected = false, System.Uri url = null, string license = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterDetectionResult ContentFilterDetectionResult(bool filtered = false, bool detected = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResult ContentFilterResult(Azure.AI.OpenAI.ContentFilterSeverity severity = default(Azure.AI.OpenAI.ContentFilterSeverity), bool filtered = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt ContentFilterResultDetailsForPrompt(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.AI.OpenAI.ContentFilterDetectionResult profanity = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> customBlocklists = null, Azure.ResponseError error = null, Azure.AI.OpenAI.ContentFilterDetectionResult jailbreak = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResultsForChoice(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.AI.OpenAI.ContentFilterDetectionResult profanity = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> customBlocklists = null, Azure.ResponseError error = null, Azure.AI.OpenAI.ContentFilterDetectionResult protectedMaterialText = null, Azure.AI.OpenAI.ContentFilterCitedDetectionResult protectedMaterialCode = null) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResultsForPrompt ContentFilterResultsForPrompt(int promptIndex = 0, Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt contentFilterResults = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingItem EmbeddingItem(System.ReadOnlyMemory<float> embedding = default(System.ReadOnlyMemory<float>), int index = 0) { throw null; }
        public static Azure.AI.OpenAI.Embeddings Embeddings(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.EmbeddingItem> data = null, Azure.AI.OpenAI.EmbeddingsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingsUsage EmbeddingsUsage(int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationData ImageGenerationData(System.Uri url = null, string base64Data = null, string revisedPrompt = null) { throw null; }
        public static Azure.AI.OpenAI.StopFinishDetails StopFinishDetails(string stop = null) { throw null; }
        public static Azure.AI.OpenAI.StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(string id, System.DateTimeOffset created, string systemFingerprint, int? choiceIndex = default(int?), Azure.AI.OpenAI.ChatRole? role = default(Azure.AI.OpenAI.ChatRole?), string authorName = null, string contentUpdate = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?), string functionName = null, string functionArgumentsUpdate = null, Azure.AI.OpenAI.StreamingToolCallUpdate toolCallUpdate = null, Azure.AI.OpenAI.AzureChatExtensionsMessageContext azureExtensionsContext = null) { throw null; }
        public static Azure.AI.OpenAI.StreamingFunctionToolCallUpdate StreamingFunctionToolCallUpdate(string id, int toolCallIndex, string functionName, string functionArgumentsUpdate) { throw null; }
    }
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.AzureChatEnhancements Enhancements { get { throw null; } }
        public Azure.AI.OpenAI.ChatFinishDetails FinishDetails { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.ChatResponseMessage Message { get { throw null; } }
    }
    public partial class ChatCompletions
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatChoice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterResultsForPrompt> PromptFilterResults { get { throw null; } }
        public string SystemFingerprint { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    public partial class ChatCompletionsFunctionToolCall : Azure.AI.OpenAI.ChatCompletionsToolCall
    {
        public ChatCompletionsFunctionToolCall(string id, string name, string arguments) : base (default(string)) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChatCompletionsFunctionToolDefinition : Azure.AI.OpenAI.ChatCompletionsToolDefinition
    {
        public ChatCompletionsFunctionToolDefinition() { }
        public ChatCompletionsFunctionToolDefinition(Azure.AI.OpenAI.FunctionDefinition function) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionDefinition Function { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class ChatCompletionsOptions
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(string deploymentName, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatRequestMessage> messages) { }
        public Azure.AI.OpenAI.AzureChatExtensionsOptions AzureExtensionsOptions { get { throw null; } set { } }
        public int? ChoiceCount { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionDefinition FunctionCall { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.FunctionDefinition> Functions { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatRequestMessage> Messages { get { throw null; } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public Azure.AI.OpenAI.ChatCompletionsResponseFormat ResponseFormat { get { throw null; } set { } }
        public long? Seed { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public Azure.AI.OpenAI.ChatCompletionsToolChoice ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatCompletionsToolDefinition> Tools { get { throw null; } }
        public string User { get { throw null; } set { } }
    }
    public abstract partial class ChatCompletionsResponseFormat
    {
        public static readonly Azure.AI.OpenAI.ChatCompletionsResponseFormat JsonObject;
        public static readonly Azure.AI.OpenAI.ChatCompletionsResponseFormat Text;
        protected ChatCompletionsResponseFormat() { }
    }
    public abstract partial class ChatCompletionsToolCall
    {
        protected ChatCompletionsToolCall(string id) { }
        public string Id { get { throw null; } set { } }
    }
    public partial class ChatCompletionsToolChoice
    {
        public static readonly Azure.AI.OpenAI.ChatCompletionsToolChoice Auto;
        public static readonly Azure.AI.OpenAI.ChatCompletionsToolChoice None;
        public ChatCompletionsToolChoice(Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition functionToolDefinition) { }
        public ChatCompletionsToolChoice(Azure.AI.OpenAI.FunctionDefinition functionDefinition) { }
        public static implicit operator Azure.AI.OpenAI.ChatCompletionsToolChoice (Azure.AI.OpenAI.ChatCompletionsFunctionToolDefinition functionToolDefinition) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatCompletionsToolChoice (Azure.AI.OpenAI.FunctionDefinition functionDefinition) { throw null; }
    }
    public abstract partial class ChatCompletionsToolDefinition
    {
        protected ChatCompletionsToolDefinition() { }
    }
    public abstract partial class ChatFinishDetails
    {
        protected ChatFinishDetails() { }
    }
    public abstract partial class ChatMessageContentItem
    {
        protected ChatMessageContentItem() { }
    }
    public partial class ChatMessageImageContentItem : Azure.AI.OpenAI.ChatMessageContentItem
    {
        public ChatMessageImageContentItem(Azure.AI.OpenAI.ChatMessageImageUrl imageUrl) { }
        public ChatMessageImageContentItem(System.Uri imageUri) { }
        public ChatMessageImageContentItem(System.Uri imageUri, Azure.AI.OpenAI.ChatMessageImageDetailLevel detailLevel) { }
        public Azure.AI.OpenAI.ChatMessageImageUrl ImageUrl { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatMessageImageDetailLevel : System.IEquatable<Azure.AI.OpenAI.ChatMessageImageDetailLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatMessageImageDetailLevel(string value) { throw null; }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel Auto { get { throw null; } }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel High { get { throw null; } }
        public static Azure.AI.OpenAI.ChatMessageImageDetailLevel Low { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatMessageImageDetailLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatMessageImageDetailLevel left, Azure.AI.OpenAI.ChatMessageImageDetailLevel right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatMessageImageDetailLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatMessageImageDetailLevel left, Azure.AI.OpenAI.ChatMessageImageDetailLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChatMessageImageUrl
    {
        public ChatMessageImageUrl(System.Uri url) { }
        public Azure.AI.OpenAI.ChatMessageImageDetailLevel? Detail { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class ChatMessageTextContentItem : Azure.AI.OpenAI.ChatMessageContentItem
    {
        public ChatMessageTextContentItem(string text) { }
        public string Text { get { throw null; } }
    }
    public partial class ChatRequestAssistantMessage : Azure.AI.OpenAI.ChatRequestMessage
    {
        public ChatRequestAssistantMessage(Azure.AI.OpenAI.ChatResponseMessage responseMessage) { }
        public ChatRequestAssistantMessage(string content) { }
        public string Content { get { throw null; } }
        public Azure.AI.OpenAI.FunctionCall FunctionCall { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
    }
    public partial class ChatRequestFunctionMessage : Azure.AI.OpenAI.ChatRequestMessage
    {
        public ChatRequestFunctionMessage(string name, string content) { }
        public string Content { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public abstract partial class ChatRequestMessage
    {
        protected ChatRequestMessage() { }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } set { } }
    }
    public partial class ChatRequestSystemMessage : Azure.AI.OpenAI.ChatRequestMessage
    {
        public ChatRequestSystemMessage(string content) { }
        public string Content { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChatRequestToolMessage : Azure.AI.OpenAI.ChatRequestMessage
    {
        public ChatRequestToolMessage(string content, string toolCallId) { }
        public string Content { get { throw null; } }
        public string ToolCallId { get { throw null; } }
    }
    public partial class ChatRequestUserMessage : Azure.AI.OpenAI.ChatRequestMessage
    {
        public ChatRequestUserMessage(params Azure.AI.OpenAI.ChatMessageContentItem[] content) { }
        public ChatRequestUserMessage(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatMessageContentItem> content) { }
        public ChatRequestUserMessage(string content) { }
        public string Content { get { throw null; } protected set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessageContentItem> MultimodalContentItems { get { throw null; } }
        public string Name { get { throw null; } set { } }
    }
    public partial class ChatResponseMessage
    {
        internal ChatResponseMessage() { }
        public Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureExtensionsContext { get { throw null; } }
        public string Content { get { throw null; } }
        public Azure.AI.OpenAI.FunctionCall FunctionCall { get { throw null; } }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatCompletionsToolCall> ToolCalls { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChatRole : System.IEquatable<Azure.AI.OpenAI.ChatRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChatRole(string value) { throw null; }
        public static Azure.AI.OpenAI.ChatRole Assistant { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole Function { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole System { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole Tool { get { throw null; } }
        public static Azure.AI.OpenAI.ChatRole User { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ChatRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ChatRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ChatRole left, Azure.AI.OpenAI.ChatRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Choice
    {
        internal Choice() { }
        public Azure.AI.OpenAI.ContentFilterResultsForChoice ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsLogProbabilityModel LogProbabilityModel { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class Completions
    {
        internal Completions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Choice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterResultsForPrompt> PromptFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CompletionsFinishReason : System.IEquatable<Azure.AI.OpenAI.CompletionsFinishReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CompletionsFinishReason(string value) { throw null; }
        public static Azure.AI.OpenAI.CompletionsFinishReason ContentFiltered { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason FunctionCall { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason Stopped { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason TokenLimitReached { get { throw null; } }
        public static Azure.AI.OpenAI.CompletionsFinishReason ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.CompletionsFinishReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.CompletionsFinishReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.CompletionsFinishReason left, Azure.AI.OpenAI.CompletionsFinishReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CompletionsLogProbabilityModel
    {
        internal CompletionsLogProbabilityModel() { }
        public System.Collections.Generic.IReadOnlyList<int> TextOffsets { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<float?> TokenLogProbabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Tokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IDictionary<string, float?>> TopLogProbabilities { get { throw null; } }
    }
    public partial class CompletionsOptions
    {
        public CompletionsOptions() { }
        public CompletionsOptions(string deploymentName, System.Collections.Generic.IEnumerable<string> prompts) { }
        public int? ChoicesPerPrompt { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public bool? Echo { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public int? GenerationSampleCount { get { throw null; } set { } }
        public int? LogProbabilityCount { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Prompts { get { throw null; } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public string User { get { throw null; } set { } }
    }
    public partial class CompletionsUsage
    {
        internal CompletionsUsage() { }
        public int CompletionTokens { get { throw null; } }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
    }
    public partial class ContentFilterBlocklistIdResult
    {
        internal ContentFilterBlocklistIdResult() { }
        public bool Filtered { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class ContentFilterCitedDetectionResult
    {
        internal ContentFilterCitedDetectionResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        public string License { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class ContentFilterDetectionResult
    {
        internal ContentFilterDetectionResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
    }
    public partial class ContentFilterResult
    {
        internal ContentFilterResult() { }
        public bool Filtered { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverity Severity { get { throw null; } }
    }
    public partial class ContentFilterResultDetailsForPrompt
    {
        internal ContentFilterResultDetailsForPrompt() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> CustomBlocklists { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
    }
    public partial class ContentFilterResultsForChoice
    {
        internal ContentFilterResultsForChoice() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ContentFilterBlocklistIdResult> CustomBlocklists { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterCitedDetectionResult ProtectedMaterialCode { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterDetectionResult ProtectedMaterialText { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
    }
    public partial class ContentFilterResultsForPrompt
    {
        internal ContentFilterResultsForPrompt() { }
        public Azure.AI.OpenAI.ContentFilterResultDetailsForPrompt ContentFilterResults { get { throw null; } }
        public int PromptIndex { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentFilterSeverity : System.IEquatable<Azure.AI.OpenAI.ContentFilterSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentFilterSeverity(string value) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterSeverity High { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Low { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Medium { get { throw null; } }
        public static Azure.AI.OpenAI.ContentFilterSeverity Safe { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ContentFilterSeverity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ContentFilterSeverity left, Azure.AI.OpenAI.ContentFilterSeverity right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ContentFilterSeverity (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ContentFilterSeverity left, Azure.AI.OpenAI.ContentFilterSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ElasticsearchChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public ElasticsearchChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.ElasticsearchIndexFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public Azure.AI.OpenAI.ElasticsearchQueryType? QueryType { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
    }
    public partial class ElasticsearchIndexFieldMappingOptions
    {
        public ElasticsearchIndexFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ElasticsearchQueryType : System.IEquatable<Azure.AI.OpenAI.ElasticsearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ElasticsearchQueryType(string value) { throw null; }
        public static Azure.AI.OpenAI.ElasticsearchQueryType Simple { get { throw null; } }
        public static Azure.AI.OpenAI.ElasticsearchQueryType Vector { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ElasticsearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ElasticsearchQueryType left, Azure.AI.OpenAI.ElasticsearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ElasticsearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ElasticsearchQueryType left, Azure.AI.OpenAI.ElasticsearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EmbeddingItem
    {
        internal EmbeddingItem() { }
        public System.ReadOnlyMemory<float> Embedding { get { throw null; } }
        public int Index { get { throw null; } }
    }
    public partial class Embeddings
    {
        internal Embeddings() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.EmbeddingItem> Data { get { throw null; } }
        public Azure.AI.OpenAI.EmbeddingsUsage Usage { get { throw null; } }
    }
    public partial class EmbeddingsOptions
    {
        public EmbeddingsOptions() { }
        public EmbeddingsOptions(string deploymentName, System.Collections.Generic.IEnumerable<string> input) { }
        public string DeploymentName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Input { get { throw null; } }
        public string User { get { throw null; } set { } }
    }
    public partial class EmbeddingsUsage
    {
        internal EmbeddingsUsage() { }
        public int PromptTokens { get { throw null; } }
        public int TotalTokens { get { throw null; } }
    }
    public partial class FunctionCall
    {
        public FunctionCall(string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class FunctionDefinition
    {
        public static Azure.AI.OpenAI.FunctionDefinition Auto;
        public static Azure.AI.OpenAI.FunctionDefinition None;
        public FunctionDefinition() { }
        public FunctionDefinition(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
    }
    public partial class ImageGenerationData
    {
        internal ImageGenerationData() { }
        public string Base64Data { get { throw null; } }
        public string RevisedPrompt { get { throw null; } }
        public System.Uri Url { get { throw null; } }
    }
    public partial class ImageGenerationOptions
    {
        public ImageGenerationOptions() { }
        public ImageGenerationOptions(string prompt) { }
        public string DeploymentName { get { throw null; } set { } }
        public int? ImageCount { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageGenerationQuality? Quality { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageSize? Size { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageGenerationStyle? Style { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageGenerationQuality : System.IEquatable<Azure.AI.OpenAI.ImageGenerationQuality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageGenerationQuality(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationQuality Hd { get { throw null; } }
        public static Azure.AI.OpenAI.ImageGenerationQuality Standard { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageGenerationQuality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageGenerationQuality left, Azure.AI.OpenAI.ImageGenerationQuality right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageGenerationQuality (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageGenerationQuality left, Azure.AI.OpenAI.ImageGenerationQuality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageGenerations
    {
        public ImageGenerations(System.DateTimeOffset created, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ImageGenerationData> data) { }
        public System.DateTimeOffset Created { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ImageGenerationData> Data { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageGenerationStyle : System.IEquatable<Azure.AI.OpenAI.ImageGenerationStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageGenerationStyle(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerationStyle Natural { get { throw null; } }
        public static Azure.AI.OpenAI.ImageGenerationStyle Vivid { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageGenerationStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageGenerationStyle left, Azure.AI.OpenAI.ImageGenerationStyle right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageGenerationStyle (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageGenerationStyle left, Azure.AI.OpenAI.ImageGenerationStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageSize : System.IEquatable<Azure.AI.OpenAI.ImageSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageSize(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageSize Size1024x1024 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size1024x1792 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size1792x1024 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size256x256 { get { throw null; } }
        public static Azure.AI.OpenAI.ImageSize Size512x512 { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.ImageSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.ImageSize left, Azure.AI.OpenAI.ImageSize right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.ImageSize (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.ImageSize left, Azure.AI.OpenAI.ImageSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaxTokensFinishDetails : Azure.AI.OpenAI.ChatFinishDetails
    {
        internal MaxTokensFinishDetails() { }
    }
    public partial class OnYourDataApiKeyAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions
    {
        public OnYourDataApiKeyAuthenticationOptions(string key) { }
        public string Key { get { throw null; } }
    }
    public abstract partial class OnYourDataAuthenticationOptions
    {
        protected OnYourDataAuthenticationOptions() { }
    }
    public partial class OnYourDataConnectionStringAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions
    {
        public OnYourDataConnectionStringAuthenticationOptions(string connectionString) { }
        public string ConnectionString { get { throw null; } }
    }
    public partial class OnYourDataDeploymentNameVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource
    {
        public OnYourDataDeploymentNameVectorizationSource(string deploymentName) { }
        public string DeploymentName { get { throw null; } }
    }
    public partial class OnYourDataEndpointVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource
    {
        public OnYourDataEndpointVectorizationSource(System.Uri endpoint, Azure.AI.OpenAI.OnYourDataAuthenticationOptions authentication) { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } }
    }
    public partial class OnYourDataKeyAndKeyIdAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions
    {
        public OnYourDataKeyAndKeyIdAuthenticationOptions(string key, string keyId) { }
        public string Key { get { throw null; } }
        public string KeyId { get { throw null; } }
    }
    public partial class OnYourDataModelIdVectorizationSource : Azure.AI.OpenAI.OnYourDataVectorizationSource
    {
        public OnYourDataModelIdVectorizationSource(string modelId) { }
        public string ModelId { get { throw null; } }
    }
    public partial class OnYourDataSystemAssignedManagedIdentityAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions
    {
        public OnYourDataSystemAssignedManagedIdentityAuthenticationOptions() { }
    }
    public partial class OnYourDataUserAssignedManagedIdentityAuthenticationOptions : Azure.AI.OpenAI.OnYourDataAuthenticationOptions
    {
        public OnYourDataUserAssignedManagedIdentityAuthenticationOptions(string managedIdentityResourceId) { }
        public string ManagedIdentityResourceId { get { throw null; } }
    }
    public abstract partial class OnYourDataVectorizationSource
    {
        protected OnYourDataVectorizationSource() { }
    }
    public partial class OpenAIClient
    {
        protected OpenAIClient() { }
        public OpenAIClient(string openAIApiKey) { }
        public OpenAIClient(string openAIApiKey, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public OpenAIClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.AI.OpenAI.OpenAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.OpenAI.AudioTranscription> GetAudioTranscription(Azure.AI.OpenAI.AudioTranscriptionOptions audioTranscriptionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.AudioTranscription>> GetAudioTranscriptionAsync(Azure.AI.OpenAI.AudioTranscriptionOptions audioTranscriptionOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.AudioTranslation> GetAudioTranslation(Azure.AI.OpenAI.AudioTranslationOptions audioTranslationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.AudioTranslation>> GetAudioTranslationAsync(Azure.AI.OpenAI.AudioTranslationOptions audioTranslationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.ChatCompletions> GetChatCompletions(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ChatCompletions>> GetChatCompletionsAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.StreamingChatCompletionsUpdate> GetChatCompletionsStreaming(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.StreamingChatCompletionsUpdate>> GetChatCompletionsStreamingAsync(Azure.AI.OpenAI.ChatCompletionsOptions chatCompletionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Completions> GetCompletions(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Completions>> GetCompletionsAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.Completions> GetCompletionsStreaming(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.OpenAI.StreamingResponse<Azure.AI.OpenAI.Completions>> GetCompletionsStreamingAsync(Azure.AI.OpenAI.CompletionsOptions completionsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Embeddings> GetEmbeddings(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Embeddings>> GetEmbeddingsAsync(Azure.AI.OpenAI.EmbeddingsOptions embeddingsOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.ImageGenerations> GetImageGenerations(Azure.AI.OpenAI.ImageGenerationOptions imageGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.ImageGenerations>> GetImageGenerationsAsync(Azure.AI.OpenAI.ImageGenerationOptions imageGenerationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAIClientOptions : Azure.Core.ClientOptions
    {
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2023_12_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
            V2023_05_15 = 2,
            V2023_06_01_Preview = 3,
            V2023_07_01_Preview = 4,
            V2023_08_01_Preview = 5,
            V2023_09_01_Preview = 6,
            V2023_12_01_Preview = 7,
        }
    }
    public partial class PineconeChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public PineconeChatExtensionConfiguration() { }
        public Azure.AI.OpenAI.OnYourDataAuthenticationOptions Authentication { get { throw null; } set { } }
        public int? DocumentCount { get { throw null; } set { } }
        public string Environment { get { throw null; } set { } }
        public Azure.AI.OpenAI.PineconeFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string RoleInformation { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public int? Strictness { get { throw null; } set { } }
        public Azure.AI.OpenAI.OnYourDataVectorizationSource VectorizationSource { get { throw null; } set { } }
    }
    public partial class PineconeFieldMappingOptions
    {
        public PineconeFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ImageVectorFieldNames { get { throw null; } }
        public string TitleFieldName { get { throw null; } set { } }
        public string UrlFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorFieldNames { get { throw null; } }
    }
    public partial class StopFinishDetails : Azure.AI.OpenAI.ChatFinishDetails
    {
        internal StopFinishDetails() { }
        public string Stop { get { throw null; } }
    }
    public partial class StreamingChatCompletionsUpdate
    {
        internal StreamingChatCompletionsUpdate() { }
        public string AuthorName { get { throw null; } }
        public Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureExtensionsContext { get { throw null; } }
        public int? ChoiceIndex { get { throw null; } }
        public string ContentUpdate { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public string FunctionArgumentsUpdate { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.ChatRole? Role { get { throw null; } }
        public string SystemFingerprint { get { throw null; } }
        public Azure.AI.OpenAI.StreamingToolCallUpdate ToolCallUpdate { get { throw null; } }
    }
    public partial class StreamingFunctionToolCallUpdate : Azure.AI.OpenAI.StreamingToolCallUpdate
    {
        internal StreamingFunctionToolCallUpdate() { }
        public string ArgumentsUpdate { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class StreamingResponse<T> : System.Collections.Generic.IAsyncEnumerable<T>, System.IDisposable
    {
        internal StreamingResponse() { }
        public static Azure.AI.OpenAI.StreamingResponse<T> CreateFromResponse(Azure.Response response, System.Func<Azure.Response, System.Collections.Generic.IAsyncEnumerable<T>> asyncEnumerableProcessor) { throw null; }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        public System.Collections.Generic.IAsyncEnumerable<T> EnumerateValues() { throw null; }
        public Azure.Response GetRawResponse() { throw null; }
        System.Collections.Generic.IAsyncEnumerator<T> System.Collections.Generic.IAsyncEnumerable<T>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public abstract partial class StreamingToolCallUpdate
    {
        internal StreamingToolCallUpdate() { }
        public string Id { get { throw null; } }
        public int ToolCallIndex { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIOpenAIClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.OpenAIClient, Azure.AI.OpenAI.OpenAIClientOptions> AddOpenAIClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
