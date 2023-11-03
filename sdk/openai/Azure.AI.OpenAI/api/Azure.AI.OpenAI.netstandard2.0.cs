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
    public partial class AzureChatExtensionConfiguration
    {
        public AzureChatExtensionConfiguration() { }
        public AzureChatExtensionConfiguration(Azure.AI.OpenAI.AzureChatExtensionType type, System.BinaryData parameters) { }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public virtual Azure.AI.OpenAI.AzureChatExtensionType Type { get { throw null; } set { } }
    }
    public partial class AzureChatExtensionsMessageContext
    {
        public AzureChatExtensionsMessageContext() { }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessage> Messages { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResults RequestContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResults ResponseContentFilterResults { get { throw null; } }
    }
    public partial class AzureChatExtensionsOptions
    {
        public AzureChatExtensionsOptions() { }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.AzureChatExtensionConfiguration> Extensions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureChatExtensionType : System.IEquatable<Azure.AI.OpenAI.AzureChatExtensionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureChatExtensionType(string value) { throw null; }
        public static Azure.AI.OpenAI.AzureChatExtensionType AzureCognitiveSearch { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.AzureChatExtensionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.AzureChatExtensionType left, Azure.AI.OpenAI.AzureChatExtensionType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.AzureChatExtensionType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.AzureChatExtensionType left, Azure.AI.OpenAI.AzureChatExtensionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureCognitiveSearchChatExtensionConfiguration : Azure.AI.OpenAI.AzureChatExtensionConfiguration
    {
        public AzureCognitiveSearchChatExtensionConfiguration() { }
        public AzureCognitiveSearchChatExtensionConfiguration(Azure.AI.OpenAI.AzureChatExtensionType type, System.Uri searchEndpoint, string indexName) { }
        public int? DocumentCount { get { throw null; } set { } }
        public System.Uri EmbeddingEndpoint { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCognitiveSearchIndexFieldMappingOptions FieldMappingOptions { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public Azure.AI.OpenAI.AzureCognitiveSearchQueryType? QueryType { get { throw null; } set { } }
        public System.Uri SearchEndpoint { get { throw null; } set { } }
        public string SemanticConfiguration { get { throw null; } set { } }
        public bool? ShouldRestrictResultScope { get { throw null; } set { } }
        public override Azure.AI.OpenAI.AzureChatExtensionType Type { get { throw null; } set { } }
        public void SetEmbeddingKey(string embeddingKey) { }
        public void SetSearchKey(string searchKey) { }
    }
    public partial class AzureCognitiveSearchIndexFieldMappingOptions
    {
        public AzureCognitiveSearchIndexFieldMappingOptions() { }
        public System.Collections.Generic.IList<string> ContentFieldNames { get { throw null; } }
        public string ContentFieldSeparator { get { throw null; } set { } }
        public string FilepathFieldName { get { throw null; } set { } }
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
    public static partial class AzureOpenAIModelFactory
    {
        public static Azure.AI.OpenAI.AudioTranscription AudioTranscription(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranscriptionSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranscriptionSegment AudioTranscriptionSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslation AudioTranslation(string text, string language, System.TimeSpan duration, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.AudioTranslationSegment> segments) { throw null; }
        public static Azure.AI.OpenAI.AudioTranslationSegment AudioTranslationSegment(int id = 0, System.TimeSpan start = default(System.TimeSpan), System.TimeSpan end = default(System.TimeSpan), string text = null, float temperature = 0f, float averageLogProbability = 0f, float compressionRatio = 0f, float noSpeechProbability = 0f, System.Collections.Generic.IEnumerable<int> tokens = null, int seek = 0) { throw null; }
        public static Azure.AI.OpenAI.ChatChoice ChatChoice(Azure.AI.OpenAI.ChatMessage message = null, int index = 0, Azure.AI.OpenAI.CompletionsFinishReason finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason), Azure.AI.OpenAI.ChatMessage deltaMessage = null, Azure.AI.OpenAI.ContentFilterResults contentFilterResults = null) { throw null; }
        public static Azure.AI.OpenAI.ChatCompletions ChatCompletions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatChoice> choices = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.PromptFilterResult> promptFilterResults = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.Choice Choice(string text = null, int index = 0, Azure.AI.OpenAI.ContentFilterResults contentFilterResults = null, Azure.AI.OpenAI.CompletionsLogProbabilityModel logProbabilityModel = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?)) { throw null; }
        public static Azure.AI.OpenAI.Completions Completions(string id = null, System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.PromptFilterResult> promptFilterResults = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Choice> choices = null, Azure.AI.OpenAI.CompletionsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsLogProbabilityModel CompletionsLogProbabilityModel(System.Collections.Generic.IEnumerable<string> tokens = null, System.Collections.Generic.IEnumerable<float?> tokenLogProbabilities = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, float?>> topLogProbabilities = null, System.Collections.Generic.IEnumerable<int> textOffsets = null) { throw null; }
        public static Azure.AI.OpenAI.CompletionsUsage CompletionsUsage(int completionTokens = 0, int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResult ContentFilterResult(Azure.AI.OpenAI.ContentFilterSeverity severity = default(Azure.AI.OpenAI.ContentFilterSeverity), bool filtered = false) { throw null; }
        public static Azure.AI.OpenAI.ContentFilterResults ContentFilterResults(Azure.AI.OpenAI.ContentFilterResult sexual = null, Azure.AI.OpenAI.ContentFilterResult violence = null, Azure.AI.OpenAI.ContentFilterResult hate = null, Azure.AI.OpenAI.ContentFilterResult selfHarm = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingItem EmbeddingItem(System.ReadOnlyMemory<float> embedding = default(System.ReadOnlyMemory<float>), int index = 0) { throw null; }
        public static Azure.AI.OpenAI.Embeddings Embeddings(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.EmbeddingItem> data = null, Azure.AI.OpenAI.EmbeddingsUsage usage = null) { throw null; }
        public static Azure.AI.OpenAI.EmbeddingsUsage EmbeddingsUsage(int promptTokens = 0, int totalTokens = 0) { throw null; }
        public static Azure.AI.OpenAI.ImageGenerations ImageGenerations(System.DateTimeOffset created = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ImageLocation> data = null) { throw null; }
        public static Azure.AI.OpenAI.ImageLocation ImageLocation(System.Uri url = null) { throw null; }
        public static Azure.AI.OpenAI.PromptFilterResult PromptFilterResult(int promptIndex = 0, Azure.AI.OpenAI.ContentFilterResults contentFilterResults = null) { throw null; }
        public static Azure.AI.OpenAI.StreamingChatCompletionsUpdate StreamingChatCompletionsUpdate(string id, System.DateTimeOffset created, int? choiceIndex = default(int?), Azure.AI.OpenAI.ChatRole? role = default(Azure.AI.OpenAI.ChatRole?), string authorName = null, string contentUpdate = null, Azure.AI.OpenAI.CompletionsFinishReason? finishReason = default(Azure.AI.OpenAI.CompletionsFinishReason?), string functionName = null, string functionArgumentsUpdate = null, Azure.AI.OpenAI.AzureChatExtensionsMessageContext azureExtensionsContext = null) { throw null; }
    }
    public partial class ChatChoice
    {
        internal ChatChoice() { }
        public Azure.AI.OpenAI.ContentFilterResults ContentFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsFinishReason? FinishReason { get { throw null; } }
        public int Index { get { throw null; } }
        public Azure.AI.OpenAI.ChatMessage Message { get { throw null; } }
    }
    public partial class ChatCompletions
    {
        internal ChatCompletions() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ChatChoice> Choices { get { throw null; } }
        public System.DateTimeOffset Created { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.PromptFilterResult> PromptFilterResults { get { throw null; } }
        public Azure.AI.OpenAI.CompletionsUsage Usage { get { throw null; } }
    }
    public partial class ChatCompletionsOptions
    {
        public ChatCompletionsOptions() { }
        public ChatCompletionsOptions(string deploymentName, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.ChatMessage> messages) { }
        public Azure.AI.OpenAI.AzureChatExtensionsOptions AzureExtensionsOptions { get { throw null; } set { } }
        public int? ChoiceCount { get { throw null; } set { } }
        public string DeploymentName { get { throw null; } set { } }
        public float? FrequencyPenalty { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionDefinition FunctionCall { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.FunctionDefinition> Functions { get { throw null; } set { } }
        public int? MaxTokens { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.ChatMessage> Messages { get { throw null; } }
        public float? NucleusSamplingFactor { get { throw null; } set { } }
        public float? PresencePenalty { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> StopSequences { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<int, int> TokenSelectionBiases { get { throw null; } }
        public string User { get { throw null; } set { } }
    }
    public partial class ChatMessage
    {
        public ChatMessage() { }
        public ChatMessage(Azure.AI.OpenAI.ChatRole role, string content) { }
        public Azure.AI.OpenAI.AzureChatExtensionsMessageContext AzureExtensionsContext { get { throw null; } set { } }
        public string Content { get { throw null; } set { } }
        public Azure.AI.OpenAI.FunctionCall FunctionCall { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.OpenAI.ChatRole Role { get { throw null; } set { } }
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
        public Azure.AI.OpenAI.ContentFilterResults ContentFilterResults { get { throw null; } }
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
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.PromptFilterResult> PromptFilterResults { get { throw null; } }
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
    public partial class ContentFilterResult
    {
        internal ContentFilterResult() { }
        public bool Filtered { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterSeverity Severity { get { throw null; } }
    }
    public partial class ContentFilterResults
    {
        internal ContentFilterResults() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Hate { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult SelfHarm { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Sexual { get { throw null; } }
        public Azure.AI.OpenAI.ContentFilterResult Violence { get { throw null; } }
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
        public System.Collections.Generic.IList<string> Input { get { throw null; } set { } }
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
    public partial class ImageGenerationOptions
    {
        public ImageGenerationOptions() { }
        public ImageGenerationOptions(string prompt) { }
        public int? ImageCount { get { throw null; } set { } }
        public string Prompt { get { throw null; } set { } }
        public Azure.AI.OpenAI.ImageSize? Size { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
    }
    public partial class ImageGenerations
    {
        internal ImageGenerations() { }
        public System.DateTimeOffset Created { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.ImageLocation> Data { get { throw null; } }
    }
    public partial class ImageLocation
    {
        internal ImageLocation() { }
        public System.Uri Url { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageSize : System.IEquatable<Azure.AI.OpenAI.ImageSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageSize(string value) { throw null; }
        public static Azure.AI.OpenAI.ImageSize Size1024x1024 { get { throw null; } }
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
        public OpenAIClientOptions(Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion version = Azure.AI.OpenAI.OpenAIClientOptions.ServiceVersion.V2023_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_12_01 = 1,
            V2023_05_15 = 2,
            V2023_06_01_Preview = 3,
            V2023_07_01_Preview = 4,
            V2023_08_01_Preview = 5,
            V2023_09_01_Preview = 6,
        }
    }
    public partial class PromptFilterResult
    {
        internal PromptFilterResult() { }
        public Azure.AI.OpenAI.ContentFilterResults ContentFilterResults { get { throw null; } }
        public int PromptIndex { get { throw null; } }
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
