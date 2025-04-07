namespace Azure.AI.Assistants
{
    public static partial class AIAssistantsModelFactory
    {
        public static Azure.AI.Assistants.AssistantPageableListOfVectorStore AssistantPageableListOfVectorStore(Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject @object = default(Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject), System.Collections.Generic.IEnumerable<Azure.AI.Assistants.VectorStore> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile AssistantPageableListOfVectorStoreFile(Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject @object = default(Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject), System.Collections.Generic.IEnumerable<Azure.AI.Assistants.VectorStoreFile> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Assistants.AssistantThread AssistantThread(string id = null, Azure.AI.Assistants.AssistantThreadObject @object = default(Azure.AI.Assistants.AssistantThreadObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Assistants.AzureFunctionBindingType type = default(Azure.AI.Assistants.AzureFunctionBindingType), Azure.AI.Assistants.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Assistants.FileSearchToolCallContent FileSearchToolCallContent(Azure.AI.Assistants.FileSearchToolCallContentType type = default(Azure.AI.Assistants.FileSearchToolCallContentType), string text = null) { throw null; }
        public static Azure.AI.Assistants.IncompleteRunDetails IncompleteRunDetails(Azure.AI.Assistants.IncompleteDetailsReason reason = default(Azure.AI.Assistants.IncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Assistants.MessageDelta MessageDelta(Azure.AI.Assistants.MessageRole role = default(Azure.AI.Assistants.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Assistants.MessageDeltaChunkObject @object = default(Azure.AI.Assistants.MessageDeltaChunkObject), Azure.AI.Assistants.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Assistants.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Assistants.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation MessageDeltaTextUrlCitationAnnotation(int index = 0, Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails urlCitation = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails MessageDeltaTextUrlCitationDetails(string url = null, string title = null) { throw null; }
        public static Azure.AI.Assistants.MessageIncompleteDetails MessageIncompleteDetails(Azure.AI.Assistants.MessageIncompleteDetailsReason reason = default(Azure.AI.Assistants.MessageIncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Assistants.MessageTextAnnotation MessageTextAnnotation(string type = null, string text = null) { throw null; }
        public static Azure.AI.Assistants.MessageTextUrlCitationAnnotation MessageTextUrlCitationAnnotation(string text = null, Azure.AI.Assistants.MessageTextUrlCitationDetails urlCitation = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Assistants.MessageTextUrlCitationDetails MessageTextUrlCitationDetails(string url = null, string title = null) { throw null; }
        public static Azure.AI.Assistants.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Assistants.ResponseFormatJsonSchemaType ResponseFormatJsonSchemaType(Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType type = default(Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType), Azure.AI.Assistants.ResponseFormatJsonSchema jsonSchema = null) { throw null; }
        public static Azure.AI.Assistants.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Assistants.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Assistants.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Assistants.RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Assistants.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Assistants.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Assistants.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Assistants.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Assistants.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Assistants.RunStepCustomSearchToolCall RunStepCustomSearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingCustomSearch = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDelta RunStepDelta(Azure.AI.Assistants.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Assistants.RunStepDeltaChunkObject @object = default(Azure.AI.Assistants.RunStepDeltaChunkObject), Azure.AI.Assistants.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, Azure.AI.Assistants.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Assistants.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Assistants.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Assistants.RunStepError RunStepError(Azure.AI.Assistants.RunStepErrorCode code = default(Azure.AI.Assistants.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Assistants.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, Azure.AI.Assistants.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Assistants.RunStepFileSearchToolCallResult RunStepFileSearchToolCallResult(string fileId = null, string fileName = null, float score = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.FileSearchToolCallContent> content = null) { throw null; }
        public static Azure.AI.Assistants.RunStepFileSearchToolCallResults RunStepFileSearchToolCallResults(Azure.AI.Assistants.FileSearchRankingOptions rankingOptions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunStepFileSearchToolCallResult> results = null) { throw null; }
        public static Azure.AI.Assistants.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Assistants.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Assistants.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Assistants.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Assistants.RunStepOpenAPIToolCall RunStepOpenAPIToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> openAPI = null) { throw null; }
        public static Azure.AI.Assistants.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Assistants.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Assistants.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Assistants.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Assistants.MessageRole role = default(Azure.AI.Assistants.MessageRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.VectorStore VectorStore(string id = null, Azure.AI.Assistants.VectorStoreObject @object = default(Azure.AI.Assistants.VectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Assistants.VectorStoreFileCount fileCounts = null, Azure.AI.Assistants.VectorStoreStatus status = default(Azure.AI.Assistants.VectorStoreStatus), Azure.AI.Assistants.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.VectorStoreDeletionStatus VectorStoreDeletionStatus(string id = null, bool deleted = false, Azure.AI.Assistants.VectorStoreDeletionStatusObject @object = default(Azure.AI.Assistants.VectorStoreDeletionStatusObject)) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Assistants.VectorStoreFileObject @object = default(Azure.AI.Assistants.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Assistants.VectorStoreFileStatus status = default(Azure.AI.Assistants.VectorStoreFileStatus), Azure.AI.Assistants.VectorStoreFileError lastError = null, Azure.AI.Assistants.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Assistants.VectorStoreFileBatchObject @object = default(Azure.AI.Assistants.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Assistants.VectorStoreFileBatchStatus status = default(Azure.AI.Assistants.VectorStoreFileBatchStatus), Azure.AI.Assistants.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileDeletionStatus VectorStoreFileDeletionStatus(string id = null, bool deleted = false, Azure.AI.Assistants.VectorStoreFileDeletionStatusObject @object = default(Azure.AI.Assistants.VectorStoreFileDeletionStatusObject)) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileError VectorStoreFileError(Azure.AI.Assistants.VectorStoreFileErrorCode code = default(Azure.AI.Assistants.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
    }
    public static partial class AIClientModelFactory
    {
        public static Azure.AI.Assistants.AssistantThread AgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.Assistant Assistant(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, Azure.AI.Assistants.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.AssistantFile AssistantFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Assistants.AssistantFilePurpose purpose = default(Azure.AI.Assistants.AssistantFilePurpose)) { throw null; }
        public static Azure.AI.Assistants.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Assistants.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Assistants.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Assistants.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Assistants.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.Assistants.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Assistants.RunStep RunStep(string id = null, Azure.AI.Assistants.RunStepType type = default(Azure.AI.Assistants.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Assistants.RunStepStatus status = default(Azure.AI.Assistants.RunStepStatus), Azure.AI.Assistants.RunStepDetails stepDetails = null, Azure.AI.Assistants.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Assistants.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Assistants.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.Assistants.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Assistants.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Assistants.MessageStatus status = default(Azure.AI.Assistants.MessageStatus), Azure.AI.Assistants.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Assistants.MessageRole role = default(Azure.AI.Assistants.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Assistants.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Assistants.RunStatus status = default(Azure.AI.Assistants.RunStatus), Azure.AI.Assistants.RequiredAction requiredAction = null, Azure.AI.Assistants.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Assistants.IncompleteRunDetails incompleteDetails = null, Azure.AI.Assistants.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Assistants.UpdateToolResourcesOptions toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
    }
    public partial class AISearchIndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AISearchIndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AISearchIndexResource>
    {
        public AISearchIndexResource(string indexConnectionId, string indexName) { }
        public string Filter { get { throw null; } set { } }
        public string IndexConnectionId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public Azure.AI.Assistants.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AISearchIndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AISearchIndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AISearchIndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AISearchIndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AISearchIndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AISearchIndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AISearchIndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Assistant : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.Assistant>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.Assistant>
    {
        internal Assistant() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.Assistants.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.Assistant System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.Assistant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.Assistant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.Assistant System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.Assistant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.Assistant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.Assistant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantFile>
    {
        internal AssistantFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.AssistantFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Assistants.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantFilePurpose : System.IEquatable<Azure.AI.Assistants.AssistantFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantFilePurpose(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantFilePurpose Assistants { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose AssistantsOutput { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose Batch { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose BatchOutput { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose FineTuneResults { get { throw null; } }
        public static Azure.AI.Assistants.AssistantFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantFilePurpose left, Azure.AI.Assistants.AssistantFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantFilePurpose left, Azure.AI.Assistants.AssistantFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssistantPageableListOfVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>
    {
        internal AssistantPageableListOfVectorStore() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.VectorStore> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantPageableListOfVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantPageableListOfVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantPageableListOfVectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>
    {
        internal AssistantPageableListOfVectorStoreFile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.VectorStoreFile> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantPageableListOfVectorStoreFileObject : System.IEquatable<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantPageableListOfVectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject List { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject left, Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject left, Azure.AI.Assistants.AssistantPageableListOfVectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantPageableListOfVectorStoreObject : System.IEquatable<Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantPageableListOfVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject List { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject left, Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject left, Azure.AI.Assistants.AssistantPageableListOfVectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssistantsApiResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsApiResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsApiResponseFormat>
    {
        public AssistantsApiResponseFormat() { }
        public Azure.AI.Assistants.ResponseFormat? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantsApiResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsApiResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsApiResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantsApiResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsApiResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsApiResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsApiResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantsApiResponseFormatMode : System.IEquatable<Azure.AI.Assistants.AssistantsApiResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantsApiResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantsApiResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsApiResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantsApiResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantsApiResponseFormatMode left, Azure.AI.Assistants.AssistantsApiResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantsApiResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantsApiResponseFormatMode left, Azure.AI.Assistants.AssistantsApiResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantsApiToolChoiceOptionMode : System.IEquatable<Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantsApiToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode left, Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode left, Azure.AI.Assistants.AssistantsApiToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssistantsClient
    {
        protected AssistantsClient() { }
        public AssistantsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AssistantsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Assistants.AssistantsClientOptions options) { }
        public AssistantsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.AzureKeyCredential credential) { }
        public AssistantsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.AzureKeyCredential credential, Azure.AI.Assistants.AssistantsClientOptions options) { }
        public AssistantsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AssistantsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Assistants.AssistantsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAssistant(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.Assistant> CreateAssistant(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, Azure.AI.Assistants.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAssistantAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.Assistant>> CreateAssistantAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, Azure.AI.Assistants.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadMessage> CreateMessage(string threadId, Azure.AI.Assistants.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Assistants.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> CreateRun(Azure.AI.Assistants.AssistantThread thread, Azure.AI.Assistants.Assistant assistant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> CreateRunAsync(Azure.AI.Assistants.AssistantThread thread, Azure.AI.Assistants.Assistant assistant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Assistants.StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Assistants.StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> messages = null, Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThreadAndRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Assistants.AssistantThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, Azure.AI.Assistants.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAndRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Assistants.AssistantThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> overrideTools = null, Azure.AI.Assistants.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Assistants.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ThreadMessageOptions> messages = null, Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Assistants.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Assistants.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Assistants.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Assistants.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFile(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId = null, Azure.AI.Assistants.VectorStoreDataSource dataSource = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId = null, Azure.AI.Assistants.VectorStoreDataSource dataSource = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFileBatch(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.VectorStoreDataSource> dataSources = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileBatchAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.VectorStoreDataSource> dataSources = null, Azure.AI.Assistants.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAssistant(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAssistantAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreDeletionStatus> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreDeletionStatus>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFileDeletionStatus> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFileDeletionStatus>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAssistant(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.Assistant> GetAssistant(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAssistantAsync(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.Assistant>> GetAssistantAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.Assistant>> GetAssistants(int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.Assistant>>> GetAssistantsAsync(int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.AssistantFile>> GetFiles(Azure.AI.Assistants.AssistantFilePurpose? purpose = default(Azure.AI.Assistants.AssistantFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.AssistantFile>>> GetFilesAsync(Azure.AI.Assistants.AssistantFilePurpose? purpose = default(Azure.AI.Assistants.AssistantFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.ThreadMessage>> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.ThreadMessage>>> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.RunStep>> GetRunSteps(Azure.AI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.RunStep>>> GetRunStepsAsync(Azure.AI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.PageableList<Azure.AI.Assistants.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Assistants.VectorStoreFileStatusFilter? filter = default(Azure.AI.Assistants.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Assistants.VectorStoreFileStatusFilter? filter = default(Azure.AI.Assistants.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Assistants.VectorStoreFileStatusFilter? filter = default(Azure.AI.Assistants.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFiles(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStoreFile>> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Assistants.VectorStoreFileStatusFilter? filter = default(Azure.AI.Assistants.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFilesAsync(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStores(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantPageableListOfVectorStore>> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Assistants.ListSortOrder? order = default(Azure.AI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoresAsync(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.VectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Assistants.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Assistants.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Assistants.StreamingUpdate> SubmitToolOutputsToStream(Azure.AI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Assistants.StreamingUpdate> SubmitToolOutputsToStreamAsync(Azure.AI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAssistant(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.Assistant> UpdateAssistant(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, Azure.AI.Assistants.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAssistantAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.Assistant>> UpdateAssistantAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Assistants.ToolDefinition> tools = null, Azure.AI.Assistants.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantThread> UpdateThread(string threadId, Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantThread>> UpdateThreadAsync(string threadId, Azure.AI.Assistants.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantFile> UploadFile(System.IO.Stream data, Azure.AI.Assistants.AssistantFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Assistants.AssistantFile> UploadFile(string filePath, Azure.AI.Assistants.AssistantFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantFile>> UploadFileAsync(System.IO.Stream data, Azure.AI.Assistants.AssistantFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Assistants.AssistantFile>> UploadFileAsync(string filePath, Azure.AI.Assistants.AssistantFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssistantsClientOptions : Azure.Core.ClientOptions
    {
        public AssistantsClientOptions(Azure.AI.Assistants.AssistantsClientOptions.ServiceVersion version = Azure.AI.Assistants.AssistantsClientOptions.ServiceVersion.Vlatest) { }
        public enum ServiceVersion
        {
            Vlatest = 1,
        }
    }
    public partial class AssistantsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsNamedToolChoice>
    {
        public AssistantsNamedToolChoice(Azure.AI.Assistants.AssistantsNamedToolChoiceType type) { }
        public Azure.AI.Assistants.FunctionName Function { get { throw null; } set { } }
        public Azure.AI.Assistants.AssistantsNamedToolChoiceType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantsNamedToolChoiceType : System.IEquatable<Azure.AI.Assistants.AssistantsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType BingCustomSearch { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Assistants.AssistantsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantsNamedToolChoiceType left, Azure.AI.Assistants.AssistantsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantsNamedToolChoiceType left, Azure.AI.Assistants.AssistantsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantStreamEvent : System.IEquatable<Azure.AI.Assistants.AssistantStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantStreamEvent(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantStreamEvent Done { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent Error { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadMessageInProgress { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Assistants.AssistantStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantStreamEvent left, Azure.AI.Assistants.AssistantStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantStreamEvent left, Azure.AI.Assistants.AssistantStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AssistantThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThread>
    {
        internal AssistantThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Assistants.AssistantThreadObject Object { get { throw null; } }
        public Azure.AI.Assistants.ToolResources ToolResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThreadCreationOptions>
    {
        public AssistantThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Assistants.ToolResources ToolResources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AssistantThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AssistantThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AssistantThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssistantThreadObject : System.IEquatable<Azure.AI.Assistants.AssistantThreadObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssistantThreadObject(string value) { throw null; }
        public static Azure.AI.Assistants.AssistantThreadObject Thread { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AssistantThreadObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AssistantThreadObject left, Azure.AI.Assistants.AssistantThreadObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AssistantThreadObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AssistantThreadObject left, Azure.AI.Assistants.AssistantThreadObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Assistants.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Assistants.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Assistants.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Assistants.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Assistants.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Assistants.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AzureAISearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AzureAISearchQueryType left, Azure.AI.Assistants.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AzureAISearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AzureAISearchQueryType left, Azure.AI.Assistants.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchResource>
    {
        public AzureAISearchResource() { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.AISearchIndexResource> IndexList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureAISearchResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureAISearchResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Assistants.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Assistants.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public Azure.AI.Assistants.AzureFunctionBindingType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionBindingType : System.IEquatable<Azure.AI.Assistants.AzureFunctionBindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionBindingType(string value) { throw null; }
        public static Azure.AI.Assistants.AzureFunctionBindingType StorageQueue { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.AzureFunctionBindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.AzureFunctionBindingType left, Azure.AI.Assistants.AzureFunctionBindingType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.AzureFunctionBindingType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.AzureFunctionBindingType left, Azure.AI.Assistants.AzureFunctionBindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string storageServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string StorageServiceEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionToolDefinition>
    {
        public AzureFunctionToolDefinition(string name, string description, Azure.AI.Assistants.AzureFunctionBinding inputBinding, Azure.AI.Assistants.AzureFunctionBinding outputBinding, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.AzureFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.AzureFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.AzureFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>
    {
        public BingCustomSearchToolDefinition(Azure.AI.Assistants.SearchConfigurationList bingCustomSearch) { }
        public Azure.AI.Assistants.SearchConfigurationList BingCustomSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.BingCustomSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.BingCustomSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingCustomSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingGroundingToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingGroundingToolDefinition>
    {
        public BingGroundingToolDefinition(Azure.AI.Assistants.ToolConnectionList bingGrounding) { }
        public Azure.AI.Assistants.ToolConnectionList BingGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.BingGroundingToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingGroundingToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.BingGroundingToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.BingGroundingToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingGroundingToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingGroundingToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.BingGroundingToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.VectorStoreDataSource> DataSources { get { throw null; } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Assistants.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Assistants.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.DoneEvent left, Azure.AI.Assistants.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.DoneEvent left, Azure.AI.Assistants.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Assistants.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Assistants.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.ErrorEvent left, Azure.AI.Assistants.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.ErrorEvent left, Azure.AI.Assistants.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchRankingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchRankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchRankingOptions>
    {
        public FileSearchRankingOptions(string ranker, float scoreThreshold) { }
        public string Ranker { get { throw null; } set { } }
        public float ScoreThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchRankingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchRankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchRankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchRankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchRankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchRankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchRankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolCallContent>
    {
        internal FileSearchToolCallContent() { }
        public string Text { get { throw null; } }
        public Azure.AI.Assistants.FileSearchToolCallContentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolCallContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolCallContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSearchToolCallContentType : System.IEquatable<Azure.AI.Assistants.FileSearchToolCallContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSearchToolCallContentType(string value) { throw null; }
        public static Azure.AI.Assistants.FileSearchToolCallContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.FileSearchToolCallContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.FileSearchToolCallContentType left, Azure.AI.Assistants.FileSearchToolCallContentType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.FileSearchToolCallContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.FileSearchToolCallContentType left, Azure.AI.Assistants.FileSearchToolCallContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Assistants.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        public Azure.AI.Assistants.FileSearchRankingOptions RankingOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public FileSearchToolResource(System.Collections.Generic.IList<string> vectorStoreIds, System.Collections.Generic.IList<Azure.AI.Assistants.VectorStoreConfigurations> vectorStores) { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Assistants.VectorStoreConfigurations> VectorStores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Assistants.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Assistants.FileState Deleted { get { throw null; } }
        public static Azure.AI.Assistants.FileState Deleting { get { throw null; } }
        public static Azure.AI.Assistants.FileState Error { get { throw null; } }
        public static Azure.AI.Assistants.FileState Pending { get { throw null; } }
        public static Azure.AI.Assistants.FileState Processed { get { throw null; } }
        public static Azure.AI.Assistants.FileState Running { get { throw null; } }
        public static Azure.AI.Assistants.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.FileState left, Azure.AI.Assistants.FileState right) { throw null; }
        public static implicit operator Azure.AI.Assistants.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.FileState left, Azure.AI.Assistants.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionName>
    {
        public FunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static bool operator ==(Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.Assistants.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.Assistants.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RequiredFunctionToolCall functionToolCall, Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepFunctionToolCall functionToolCall, Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.Assistants.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.Assistants.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RequiredFunctionToolCall functionToolCall, Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepFunctionToolCall functionToolCall, Azure.AI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Assistants.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteDetailsReason : System.IEquatable<Azure.AI.Assistants.IncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Assistants.IncompleteDetailsReason MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Assistants.IncompleteDetailsReason MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.IncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.IncompleteDetailsReason left, Azure.AI.Assistants.IncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Assistants.IncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.IncompleteDetailsReason left, Azure.AI.Assistants.IncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncompleteRunDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.IncompleteRunDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.IncompleteRunDetails>
    {
        internal IncompleteRunDetails() { }
        public Azure.AI.Assistants.IncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.IncompleteRunDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.IncompleteRunDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.IncompleteRunDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.IncompleteRunDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.IncompleteRunDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.IncompleteRunDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.IncompleteRunDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Assistants.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Assistants.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Assistants.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.ListSortOrder left, Azure.AI.Assistants.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Assistants.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.ListSortOrder left, Azure.AI.Assistants.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageAttachment>
    {
        public MessageAttachment(Azure.AI.Assistants.VectorStoreDataSource ds, System.Collections.Generic.List<Azure.AI.Assistants.ToolDefinition> tools) { }
        public MessageAttachment(System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public MessageAttachment(string fileId, System.Collections.Generic.List<Azure.AI.Assistants.ToolDefinition> tools) { }
        public Azure.AI.Assistants.VectorStoreDataSource DataSource { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageContent>
    {
        protected MessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentUpdate : Azure.AI.Assistants.StreamingUpdate
    {
        internal MessageContentUpdate() { }
        public string ImageFileId { get { throw null; } }
        public string MessageId { get { throw null; } }
        public int MessageIndex { get { throw null; } }
        public Azure.AI.Assistants.MessageRole? Role { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Assistants.TextAnnotationUpdate TextAnnotation { get { throw null; } }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Assistants.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Assistants.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.MessageDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Assistants.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Assistants.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.MessageDeltaChunkObject left, Azure.AI.Assistants.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.MessageDeltaChunkObject left, Azure.AI.Assistants.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Assistants.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Assistants.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Assistants.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Assistants.MessageDeltaTextContentObject Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Assistants.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Assistants.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextUrlCitationAnnotation : Azure.AI.Assistants.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>
    {
        internal MessageDeltaTextUrlCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails UrlCitation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextUrlCitationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>
    {
        internal MessageDeltaTextUrlCitationDetails() { }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageDeltaTextUrlCitationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Assistants.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageIncompleteDetails>
    {
        internal MessageIncompleteDetails() { }
        public Azure.AI.Assistants.MessageIncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Assistants.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Assistants.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Assistants.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Assistants.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Assistants.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Assistants.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.MessageIncompleteDetailsReason left, Azure.AI.Assistants.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Assistants.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.MessageIncompleteDetailsReason left, Azure.AI.Assistants.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Assistants.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Assistants.MessageRole Assistant { get { throw null; } }
        public static Azure.AI.Assistants.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.MessageRole left, Azure.AI.Assistants.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Assistants.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.MessageRole left, Azure.AI.Assistants.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Assistants.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Assistants.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Assistants.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.MessageStatus left, Azure.AI.Assistants.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.MessageStatus left, Azure.AI.Assistants.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageStatusUpdate : Azure.AI.Assistants.StreamingUpdate<Azure.AI.Assistants.ThreadMessage>
    {
        internal MessageStatusUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Assistants.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Assistants.MessageStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Assistants.MessageStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Assistants.MessageStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Assistants.MessageStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Assistants.MessageStreamEvent ThreadMessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.MessageStreamEvent left, Azure.AI.Assistants.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.MessageStreamEvent left, Azure.AI.Assistants.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Assistants.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Assistants.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Assistants.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextUrlCitationAnnotation : Azure.AI.Assistants.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>
    {
        internal MessageTextUrlCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public Azure.AI.Assistants.MessageTextUrlCitationDetails UrlCitation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextUrlCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextUrlCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextUrlCitationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>
    {
        internal MessageTextUrlCitationDetails() { }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextUrlCitationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MessageTextUrlCitationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MessageTextUrlCitationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition(Azure.AI.Assistants.ToolConnectionList fabricDataagent) { }
        public Azure.AI.Assistants.ToolConnectionList FabricDataagent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Assistants.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAuthDetails>
    {
        protected OpenApiAuthDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionAuthDetails : Azure.AI.Assistants.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>
    {
        public OpenApiConnectionAuthDetails(Azure.AI.Assistants.OpenApiConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Assistants.OpenApiConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>
    {
        public OpenApiConnectionSecurityScheme(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Assistants.OpenApiAuthDetails auth) { }
        public Azure.AI.Assistants.OpenApiAuthDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Assistants.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Assistants.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Assistants.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiToolDefinition>
    {
        public OpenApiToolDefinition(Azure.AI.Assistants.OpenApiFunctionDefinition openapi) { }
        public OpenApiToolDefinition(string name, string description, System.BinaryData spec, Azure.AI.Assistants.OpenApiAuthDetails auth) { }
        public Azure.AI.Assistants.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.OpenApiToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.OpenApiToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.OpenApiToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PageableList<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
    {
        internal PageableList() { }
        public System.Collections.Generic.IReadOnlyList<T> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public T this[int index] { get { throw null; } }
        public string LastId { get { throw null; } }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredAction>
    {
        protected RequiredAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredActionUpdate : Azure.AI.Assistants.RunUpdate
    {
        internal RequiredActionUpdate() { }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public Azure.AI.Assistants.ThreadRun GetThreadRun() { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Assistants.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : Azure.AI.Assistants.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormat : System.IEquatable<Azure.AI.Assistants.ResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormat(string value) { throw null; }
        public static Azure.AI.Assistants.ResponseFormat JsonObject { get { throw null; } }
        public static Azure.AI.Assistants.ResponseFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.ResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.ResponseFormat left, Azure.AI.Assistants.ResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.Assistants.ResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.ResponseFormat left, Azure.AI.Assistants.ResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseFormatJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchema>
    {
        public ResponseFormatJsonSchema(string name, System.BinaryData schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchemaType : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>
    {
        public ResponseFormatJsonSchemaType(Azure.AI.Assistants.ResponseFormatJsonSchema jsonSchema) { }
        public Azure.AI.Assistants.ResponseFormatJsonSchema JsonSchema { get { throw null; } set { } }
        public Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ResponseFormatJsonSchemaType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormatJsonSchemaTypeType : System.IEquatable<Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormatJsonSchemaTypeType(string value) { throw null; }
        public static Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType JsonSchema { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType left, Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType left, Azure.AI.Assistants.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunAdditionalFieldList : System.IEquatable<Azure.AI.Assistants.RunAdditionalFieldList>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunAdditionalFieldList(string value) { throw null; }
        public static Azure.AI.Assistants.RunAdditionalFieldList FileSearchContents { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunAdditionalFieldList other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunAdditionalFieldList left, Azure.AI.Assistants.RunAdditionalFieldList right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunAdditionalFieldList (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunAdditionalFieldList left, Azure.AI.Assistants.RunAdditionalFieldList right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Assistants.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Assistants.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Assistants.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStatus left, Azure.AI.Assistants.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStatus left, Azure.AI.Assistants.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Assistants.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Assistants.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Assistants.RunStepType Type { get { throw null; } }
        public Azure.AI.Assistants.RunStepCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingGroundingToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>
    {
        internal RunStepBingGroundingToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Assistants.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCustomSearchToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>
    {
        internal RunStepCustomSearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingCustomSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCustomSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepCustomSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepCustomSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Assistants.RunStepDeltaDetail StepDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Assistants.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.RunStepDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Assistants.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Assistants.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepDeltaChunkObject left, Azure.AI.Assistants.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepDeltaChunkObject left, Azure.AI.Assistants.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Assistants.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Assistants.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Assistants.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Assistants.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Assistants.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Assistants.RunStepDeltaFunction Function { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Assistants.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Assistants.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCall>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Assistants.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDetails>
    {
        protected RunStepDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDetailsUpdate : Azure.AI.Assistants.StreamingUpdate
    {
        internal RunStepDetailsUpdate() { }
        public string CodeInterpreterInput { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepDeltaCodeInterpreterOutput> CodeInterpreterOutputs { get { throw null; } }
        public string CreatedMessageId { get { throw null; } }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string FunctionOutput { get { throw null; } }
        public string StepId { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public int? ToolCallIndex { get { throw null; } }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Assistants.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Assistants.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Assistants.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Assistants.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepErrorCode left, Azure.AI.Assistants.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepErrorCode left, Azure.AI.Assistants.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public Azure.AI.Assistants.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>
    {
        internal RunStepFileSearchToolCallResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.FileSearchToolCallContent> Content { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>
    {
        internal RunStepFileSearchToolCallResults() { }
        public Azure.AI.Assistants.FileSearchRankingOptions RankingOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepFileSearchToolCallResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFileSearchToolCallResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Assistants.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Assistants.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepOpenAPIToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>
    {
        internal RunStepOpenAPIToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> OpenAPI { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepOpenAPIToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepOpenAPIToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepOpenAPIToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Assistants.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Assistants.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepStatus left, Azure.AI.Assistants.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepStatus left, Azure.AI.Assistants.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Assistants.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Assistants.RunStepStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepStreamEvent left, Azure.AI.Assistants.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepStreamEvent left, Azure.AI.Assistants.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Assistants.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RunStepToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Assistants.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Assistants.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Assistants.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStepType left, Azure.AI.Assistants.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStepType left, Azure.AI.Assistants.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepUpdate : Azure.AI.Assistants.StreamingUpdate<Azure.AI.Assistants.RunStep>
    {
        internal RunStepUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Assistants.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Assistants.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.RunStreamEvent left, Azure.AI.Assistants.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.RunStreamEvent left, Azure.AI.Assistants.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunUpdate : Azure.AI.Assistants.StreamingUpdate<Azure.AI.Assistants.ThreadRun>
    {
        internal RunUpdate() { }
    }
    public partial class SearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfiguration>
    {
        public SearchConfiguration(string connectionId, string instanceName) { }
        public string ConnectionId { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchConfigurationList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfigurationList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfigurationList>
    {
        public SearchConfigurationList(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.SearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.SearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SearchConfigurationList System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfigurationList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SearchConfigurationList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SearchConfigurationList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfigurationList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfigurationList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SearchConfigurationList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointToolDefinition : Azure.AI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SharepointToolDefinition>
    {
        public SharepointToolDefinition(Azure.AI.Assistants.ToolConnectionList sharepointGrounding) { }
        public Azure.AI.Assistants.ToolConnectionList SharepointGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingUpdate
    {
        internal StreamingUpdate() { }
        public Azure.AI.Assistants.StreamingUpdateReason UpdateKind { get { throw null; } }
    }
    public enum StreamingUpdateReason
    {
        Unknown = 0,
        ThreadCreated = 1,
        RunCreated = 2,
        RunQueued = 3,
        RunInProgress = 4,
        RunRequiresAction = 5,
        RunCompleted = 6,
        RunIncomplete = 7,
        RunFailed = 8,
        RunCancelling = 9,
        RunCancelled = 10,
        RunExpired = 11,
        RunStepCreated = 12,
        RunStepInProgress = 13,
        RunStepUpdated = 14,
        RunStepCompleted = 15,
        RunStepFailed = 16,
        RunStepCancelled = 17,
        RunStepExpired = 18,
        MessageCreated = 19,
        MessageInProgress = 20,
        MessageUpdated = 21,
        MessageCompleted = 22,
        MessageFailed = 23,
        Error = 24,
        Done = 25,
    }
    public partial class StreamingUpdate<T> : Azure.AI.Assistants.StreamingUpdate where T : class
    {
        internal StreamingUpdate() { }
        public T Value { get { throw null; } }
        public static implicit operator T (Azure.AI.Assistants.StreamingUpdate<T> update) { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Assistants.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RequiredToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAnnotationUpdate
    {
        internal TextAnnotationUpdate() { }
        public int ContentIndex { get { throw null; } }
        public int? EndIndex { get { throw null; } }
        public string InputFileId { get { throw null; } }
        public string OutputFileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string TextToReplace { get { throw null; } }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessage>
    {
        internal ThreadMessage() { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.MessageAttachment> Attachments { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } }
        public Azure.AI.Assistants.MessageIncompleteDetails IncompleteDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Assistants.MessageRole Role { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Assistants.MessageStatus Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Assistants.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.MessageAttachment> Attachments { get { throw null; } set { } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Assistants.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.IncompleteRunDetails IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Assistants.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public Azure.AI.Assistants.RequiredAction RequiredAction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.RequiredFunctionToolCall> RequiredActions { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Assistants.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Assistants.UpdateToolResourcesOptions ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Assistants.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Assistants.TruncationObject TruncationStrategy { get { throw null; } }
        public Azure.AI.Assistants.RunCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Assistants.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Assistants.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.ThreadStreamEvent left, Azure.AI.Assistants.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Assistants.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.ThreadStreamEvent left, Azure.AI.Assistants.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreadUpdate : Azure.AI.Assistants.StreamingUpdate<Azure.AI.Assistants.AssistantThread>
    {
        internal ThreadUpdate() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Assistants.ToolResources ToolResources { get { throw null; } }
    }
    public partial class ToolConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnection>
    {
        public ToolConnection(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolConnectionList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnectionList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnectionList>
    {
        public ToolConnectionList() { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.ToolConnection> ConnectionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolConnectionList System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnectionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolConnectionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolConnectionList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnectionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnectionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolConnectionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolDefinition>
    {
        protected ToolDefinition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Assistants.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Assistants.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Assistants.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Assistants.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Assistants.FileSearchToolResource FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TruncationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.TruncationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.TruncationObject>
    {
        public TruncationObject(Azure.AI.Assistants.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Assistants.TruncationStrategy Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.TruncationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.TruncationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.TruncationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.TruncationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.TruncationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.TruncationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.TruncationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Assistants.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Assistants.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Assistants.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.TruncationStrategy left, Azure.AI.Assistants.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Assistants.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.TruncationStrategy left, Azure.AI.Assistants.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateCodeInterpreterToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>
    {
        public UpdateCodeInterpreterToolResourceOptions() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileSearchToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>
    {
        public UpdateFileSearchToolResourceOptions() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateFileSearchToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolResourcesOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateToolResourcesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateToolResourcesOptions>
    {
        public UpdateToolResourcesOptions() { }
        public Azure.AI.Assistants.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Assistants.UpdateCodeInterpreterToolResourceOptions CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Assistants.UpdateFileSearchToolResourceOptions FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateToolResourcesOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateToolResourcesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.UpdateToolResourcesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.UpdateToolResourcesOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateToolResourcesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateToolResourcesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.UpdateToolResourcesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStore>
    {
        internal VectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreObject Object { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyRequest : Azure.AI.Assistants.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>
    {
        public VectorStoreAutoChunkingStrategyRequest() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Assistants.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>
    {
        protected VectorStoreChunkingStrategyRequest() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfiguration>
    {
        public VectorStoreConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Assistants.VectorStoreDataSource> dataSources) { }
        public System.Collections.Generic.IList<Azure.AI.Assistants.VectorStoreDataSource> DataSources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfigurations>
    {
        public VectorStoreConfigurations(string storeName, Azure.AI.Assistants.VectorStoreConfiguration storeConfiguration) { }
        public Azure.AI.Assistants.VectorStoreConfiguration StoreConfiguration { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreConfigurations System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDataSource>
    {
        public VectorStoreDataSource(string assetIdentifier, Azure.AI.Assistants.VectorStoreDataSourceAssetType assetType) { }
        public string AssetIdentifier { get { throw null; } set { } }
        public Azure.AI.Assistants.VectorStoreDataSourceAssetType AssetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDataSourceAssetType : System.IEquatable<Azure.AI.Assistants.VectorStoreDataSourceAssetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDataSourceAssetType(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreDataSourceAssetType IdAsset { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreDataSourceAssetType UriAsset { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreDataSourceAssetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreDataSourceAssetType left, Azure.AI.Assistants.VectorStoreDataSourceAssetType right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreDataSourceAssetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreDataSourceAssetType left, Azure.AI.Assistants.VectorStoreDataSourceAssetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDeletionStatus>
    {
        internal VectorStoreDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDeletionStatusObject : System.IEquatable<Azure.AI.Assistants.VectorStoreDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreDeletionStatusObject VectorStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreDeletionStatusObject left, Azure.AI.Assistants.VectorStoreDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreDeletionStatusObject left, Azure.AI.Assistants.VectorStoreDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor left, Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor left, Azure.AI.Assistants.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Assistants.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Assistants.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileBatchObject left, Azure.AI.Assistants.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileBatchObject left, Azure.AI.Assistants.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Assistants.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileBatchStatus left, Azure.AI.Assistants.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileBatchStatus left, Azure.AI.Assistants.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>
    {
        internal VectorStoreFileDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Assistants.VectorStoreFileDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileDeletionStatusObject : System.IEquatable<Azure.AI.Assistants.VectorStoreFileDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileDeletionStatusObject VectorStoreFileDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileDeletionStatusObject left, Azure.AI.Assistants.VectorStoreFileDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileDeletionStatusObject left, Azure.AI.Assistants.VectorStoreFileDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Assistants.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Assistants.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileErrorCode InvalidFile { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileErrorCode ServerError { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileErrorCode UnsupportedFile { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileErrorCode left, Azure.AI.Assistants.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileErrorCode left, Azure.AI.Assistants.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Assistants.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileObject left, Azure.AI.Assistants.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileObject left, Azure.AI.Assistants.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Assistants.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileStatus left, Azure.AI.Assistants.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileStatus left, Azure.AI.Assistants.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Assistants.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreFileStatusFilter left, Azure.AI.Assistants.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreFileStatusFilter left, Azure.AI.Assistants.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreObject : System.IEquatable<Azure.AI.Assistants.VectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreObject(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreObject left, Azure.AI.Assistants.VectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreObject left, Azure.AI.Assistants.VectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Assistants.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Assistants.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Assistants.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Assistants.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Assistants.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Assistants.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Assistants.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Assistants.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Assistants.VectorStoreStatus left, Azure.AI.Assistants.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Assistants.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Assistants.VectorStoreStatus left, Azure.AI.Assistants.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.AI.Assistants.Custom
{
    public partial class AssistantThread
    {
        public AssistantThread() { }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIAssistantsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Assistants.AssistantsClient, Azure.AI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Assistants.AssistantsClient, Azure.AI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Assistants.AssistantsClient, Azure.AI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
