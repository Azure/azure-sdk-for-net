namespace Azure.AI.Client
{
    public partial class Agent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Agent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Agent>
    {
        internal Agent() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.Client.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        Azure.AI.Client.Agent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Agent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Agent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.Agent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Agent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Agent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Agent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentClient
    {
        protected AgentClient() { }
        public AgentClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AgentClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public AgentClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AgentClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAgent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.Agent> CreateAgent(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, Azure.AI.Client.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.Agent>> CreateAgentAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, Azure.AI.Client.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadMessage> CreateMessage(string threadId, Azure.AI.Client.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Client.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> CreateRun(Azure.AI.Client.AgentThread thread, Azure.AI.Client.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ThreadMessage> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Client.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> CreateRunAsync(Azure.AI.Client.AgentThread thread, Azure.AI.Client.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ThreadMessage> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Client.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.AgentThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Client.ThreadMessageOptions> messages = null, Azure.AI.Client.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThreadAndRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Client.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> overrideTools = null, Azure.AI.Client.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Client.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAndRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Client.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> overrideTools = null, Azure.AI.Client.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Client.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.AgentThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Client.ThreadMessageOptions> messages = null, Azure.AI.Client.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Client.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Client.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFile(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFileBatch(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileBatchAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds, Azure.AI.Client.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAgent(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAgentAsync(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreDeletionStatus> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreDeletionStatus>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFileDeletionStatus> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFileDeletionStatus>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAgent(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.Agent> GetAgent(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAgentAsync(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.Agent>> GetAgentAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.Agent>> GetAgents(int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.Agent>>> GetAgentsAsync(int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.FileContentResponse> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.FileContentResponse>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Client.OpenAIFile>> GetFiles(Azure.AI.Client.OpenAIFilePurpose? purpose = default(Azure.AI.Client.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Client.OpenAIFile>>> GetFilesAsync(Azure.AI.Client.OpenAIFilePurpose? purpose = default(Azure.AI.Client.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.ThreadMessage>> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.ThreadMessage>>> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStep(string threadId, string runId, string stepId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStepAsync(string threadId, string runId, string stepId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.RunStep>> GetRunSteps(Azure.AI.Client.ThreadRun run, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.RunStep>>> GetRunStepsAsync(Azure.AI.Client.ThreadRun run, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.PageableList<Azure.AI.Client.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.AgentThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.AgentThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Client.VectorStoreFileStatusFilter? filter = default(Azure.AI.Client.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Client.VectorStoreFileStatusFilter? filter = default(Azure.AI.Client.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Client.VectorStoreFileStatusFilter? filter = default(Azure.AI.Client.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFiles(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Client.VectorStoreFileStatusFilter? filter = default(Azure.AI.Client.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFilesAsync(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStores(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIPageableListOfVectorStore>> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Client.ListSortOrder? order = default(Azure.AI.Client.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoresAsync(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.VectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Client.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Client.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Client.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolOutput> toolOutputs, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Client.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolOutput> toolOutputs, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAgent(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.Agent> UpdateAgent(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, Azure.AI.Client.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAgentAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.Agent>> UpdateAgentAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, Azure.AI.Client.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.AgentThread> UpdateThread(string threadId, Azure.AI.Client.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.AgentThread>> UpdateThreadAsync(string threadId, Azure.AI.Client.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIFile> UploadFile(System.IO.Stream data, Azure.AI.Client.OpenAIFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.OpenAIFile> UploadFile(string filePath, Azure.AI.Client.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIFile>> UploadFileAsync(System.IO.Stream data, Azure.AI.Client.OpenAIFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.OpenAIFile>> UploadFileAsync(string filePath, Azure.AI.Client.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentsApiResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsApiResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsApiResponseFormat>
    {
        public AgentsApiResponseFormat() { }
        public Azure.AI.Client.ApiResponseFormat? Type { get { throw null; } set { } }
        Azure.AI.Client.AgentsApiResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsApiResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsApiResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AgentsApiResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsApiResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsApiResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsApiResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiResponseFormatMode : System.IEquatable<Azure.AI.Client.AgentsApiResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Client.AgentsApiResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Client.AgentsApiResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Client.AgentsApiResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.AgentsApiResponseFormatMode left, Azure.AI.Client.AgentsApiResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Client.AgentsApiResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.AgentsApiResponseFormatMode left, Azure.AI.Client.AgentsApiResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiToolChoiceOptionMode : System.IEquatable<Azure.AI.Client.AgentsApiToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Client.AgentsApiToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Client.AgentsApiToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Client.AgentsApiToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.AgentsApiToolChoiceOptionMode left, Azure.AI.Client.AgentsApiToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Client.AgentsApiToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.AgentsApiToolChoiceOptionMode left, Azure.AI.Client.AgentsApiToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsNamedToolChoice>
    {
        public AgentsNamedToolChoice(Azure.AI.Client.AgentsNamedToolChoiceType type) { }
        public Azure.AI.Client.FunctionName Function { get { throw null; } set { } }
        public Azure.AI.Client.AgentsNamedToolChoiceType Type { get { throw null; } set { } }
        Azure.AI.Client.AgentsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AgentsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsNamedToolChoiceType : System.IEquatable<Azure.AI.Client.AgentsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Client.AgentsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Client.AgentsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Client.AgentsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.AgentsNamedToolChoiceType left, Azure.AI.Client.AgentsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Client.AgentsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.AgentsNamedToolChoiceType left, Azure.AI.Client.AgentsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStreamEvent : System.IEquatable<Azure.AI.Client.AgentStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStreamEvent(string value) { throw null; }
        public static Azure.AI.Client.AgentStreamEvent Done { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent Error { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadMessageInProgress { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Client.AgentStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.AgentStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.AgentStreamEvent left, Azure.AI.Client.AgentStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.AgentStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.AgentStreamEvent left, Azure.AI.Client.AgentStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThread>
    {
        internal AgentThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Client.ToolResources ToolResources { get { throw null; } }
        Azure.AI.Client.AgentThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AgentThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThreadCreationOptions>
    {
        public AgentThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Client.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Client.ToolResources ToolResources { get { throw null; } set { } }
        Azure.AI.Client.AgentThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AgentThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AgentThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AgentThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIClientModelFactory
    {
        public static Azure.AI.Client.Agent Agent(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, Azure.AI.Client.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.AgentThread AgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Client.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.Evaluation Evaluation(string id = null, Azure.AI.Client.InputData data = null, string displayName = null, string description = null, Azure.AI.Client.SystemData systemData = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Client.EvaluationSchedule EvaluationSchedule(string id = null, Azure.AI.Client.InputData data = null, string displayName = null, string description = null, Azure.AI.Client.SystemData systemData = null, string provisioningStatus = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> evaluators = null, Azure.AI.Client.Trigger trigger = null, Azure.AI.Client.SamplingStrategy samplingStrategy = null) { throw null; }
        public static Azure.AI.Client.FileContentResponse FileContentResponse(System.BinaryData content = null) { throw null; }
        public static Azure.AI.Client.MessageDelta MessageDelta(Azure.AI.Client.MessageRole role = default(Azure.AI.Client.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Client.MessageDeltaChunkObject @object = default(Azure.AI.Client.MessageDeltaChunkObject), Azure.AI.Client.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Client.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Client.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Client.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Client.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Client.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Client.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Client.OpenAIFile OpenAIFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Client.OpenAIFilePurpose purpose = default(Azure.AI.Client.OpenAIFilePurpose)) { throw null; }
        public static Azure.AI.Client.OpenAIPageableListOfVectorStore OpenAIPageableListOfVectorStore(Azure.AI.Client.OpenAIPageableListOfVectorStoreObject @object = default(Azure.AI.Client.OpenAIPageableListOfVectorStoreObject), System.Collections.Generic.IEnumerable<Azure.AI.Client.VectorStore> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Client.OpenAIPageableListOfVectorStoreFile OpenAIPageableListOfVectorStoreFile(Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject @object = default(Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject), System.Collections.Generic.IEnumerable<Azure.AI.Client.VectorStoreFile> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Client.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.Client.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Client.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Client.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Client.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Client.RunStep RunStep(string id = null, Azure.AI.Client.RunStepType type = default(Azure.AI.Client.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Client.RunStepStatus status = default(Azure.AI.Client.RunStepStatus), Azure.AI.Client.RunStepDetails stepDetails = null, Azure.AI.Client.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Client.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Client.RunStepBingSearchToolCall RunStepBingSearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingSearch = null) { throw null; }
        public static Azure.AI.Client.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Client.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Client.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Client.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Client.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Client.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Client.RunStepDelta RunStepDelta(Azure.AI.Client.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Client.RunStepDeltaChunkObject @object = default(Azure.AI.Client.RunStepDeltaChunkObject), Azure.AI.Client.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Client.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Client.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Client.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Client.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Client.RunStepError RunStepError(Azure.AI.Client.RunStepErrorCode code = default(Azure.AI.Client.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Client.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Client.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.Client.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Client.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Client.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Client.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Client.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Client.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Client.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Client.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Client.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Client.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Client.SystemData SystemData(System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), string createdBy = null, string createdByType = null, System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Client.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Client.MessageStatus status = default(Azure.AI.Client.MessageStatus), Azure.AI.Client.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Client.MessageRole role = default(Azure.AI.Client.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Client.MessageRole role = default(Azure.AI.Client.MessageRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Client.RunStatus status = default(Azure.AI.Client.RunStatus), Azure.AI.Client.RequiredAction requiredAction = null, Azure.AI.Client.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Client.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Client.IncompleteRunDetails? incompleteDetails = default(Azure.AI.Client.IncompleteRunDetails?), Azure.AI.Client.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Client.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Client.UpdateToolResourcesOptions toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
        public static Azure.AI.Client.VectorStore VectorStore(string id = null, Azure.AI.Client.VectorStoreObject @object = default(Azure.AI.Client.VectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Client.VectorStoreFileCount fileCounts = null, Azure.AI.Client.VectorStoreStatus status = default(Azure.AI.Client.VectorStoreStatus), Azure.AI.Client.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Client.VectorStoreDeletionStatus VectorStoreDeletionStatus(string id = null, bool deleted = false, Azure.AI.Client.VectorStoreDeletionStatusObject @object = default(Azure.AI.Client.VectorStoreDeletionStatusObject)) { throw null; }
        public static Azure.AI.Client.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Client.VectorStoreFileObject @object = default(Azure.AI.Client.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Client.VectorStoreFileStatus status = default(Azure.AI.Client.VectorStoreFileStatus), Azure.AI.Client.VectorStoreFileError lastError = null, Azure.AI.Client.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Client.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Client.VectorStoreFileBatchObject @object = default(Azure.AI.Client.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Client.VectorStoreFileBatchStatus status = default(Azure.AI.Client.VectorStoreFileBatchStatus), Azure.AI.Client.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Client.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Client.VectorStoreFileDeletionStatus VectorStoreFileDeletionStatus(string id = null, bool deleted = false, Azure.AI.Client.VectorStoreFileDeletionStatusObject @object = default(Azure.AI.Client.VectorStoreFileDeletionStatusObject)) { throw null; }
        public static Azure.AI.Client.VectorStoreFileError VectorStoreFileError(Azure.AI.Client.VectorStoreFileErrorCode code = default(Azure.AI.Client.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiResponseFormat : System.IEquatable<Azure.AI.Client.ApiResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiResponseFormat(string value) { throw null; }
        public static Azure.AI.Client.ApiResponseFormat JsonObject { get { throw null; } }
        public static Azure.AI.Client.ApiResponseFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.Client.ApiResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.ApiResponseFormat left, Azure.AI.Client.ApiResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.Client.ApiResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.ApiResponseFormat left, Azure.AI.Client.ApiResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppInsightsConfiguration : Azure.AI.Client.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AppInsightsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AppInsightsConfiguration>
    {
        public AppInsightsConfiguration(string resourceId, string query, string serviceName) { }
        public string Query { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        Azure.AI.Client.AppInsightsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AppInsightsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AppInsightsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AppInsightsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AppInsightsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AppInsightsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AppInsightsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AuthenticationType
    {
        ApiKey = 0,
        AAD = 1,
        SAS = 2,
    }
    public partial class AzureAIClient
    {
        protected AzureAIClient() { }
        public AzureAIClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AzureAIClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public AzureAIClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AzureAIClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Client.AgentClient GetAgentClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Client.EndpointClient GetEndpointClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Client.EvaluationClient GetEvaluationClient(string apiVersion = "2024-07-01-preview") { throw null; }
    }
    public partial class AzureAIClientOptions : Azure.Core.ClientOptions
    {
        public AzureAIClientOptions(Azure.AI.Client.AzureAIClientOptions.ServiceVersion version = Azure.AI.Client.AzureAIClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_01_Preview = 1,
        }
    }
    public partial class AzureAISearchResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchResource>
    {
        public AzureAISearchResource() { }
        public System.Collections.Generic.IList<Azure.AI.Client.IndexResource> IndexList { get { throw null; } }
        Azure.AI.Client.AzureAISearchResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AzureAISearchResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        Azure.AI.Client.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingSearchToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.BingSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.BingSearchToolDefinition>
    {
        public BingSearchToolDefinition() { }
        Azure.AI.Client.BingSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.BingSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.BingSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.BingSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.BingSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.BingSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.BingSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        Azure.AI.Client.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        Azure.AI.Client.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionListResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionListResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionListResource>
    {
        public ConnectionListResource() { }
        public System.Collections.Generic.IList<Azure.AI.Client.ConnectionResource> ConnectionList { get { throw null; } }
        Azure.AI.Client.ConnectionListResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionListResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionListResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ConnectionListResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionListResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionListResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionListResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionResource>
    {
        public ConnectionResource(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        Azure.AI.Client.ConnectionResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ConnectionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ConnectionResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ConnectionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : Azure.AI.Client.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public string Expression { get { throw null; } set { } }
        Azure.AI.Client.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Dataset : Azure.AI.Client.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Dataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Dataset>
    {
        public Dataset(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.AI.Client.Dataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Dataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Dataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.Dataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Dataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Dataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Dataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Client.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Client.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Client.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.DoneEvent left, Azure.AI.Client.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.DoneEvent left, Azure.AI.Client.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EndpointClient
    {
        protected EndpointClient() { }
        public EndpointClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public EndpointClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public EndpointClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public EndpointClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public enum EndpointType
    {
        AzureOpenAI = 0,
        Serverless = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Client.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Client.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Client.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.ErrorEvent left, Azure.AI.Client.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.ErrorEvent left, Azure.AI.Client.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Evaluation>
    {
        public Evaluation(Azure.AI.Client.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Client.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.AI.Client.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.Client.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationClient
    {
        protected EvaluationClient() { }
        public EvaluationClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public EvaluationClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public EvaluationClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public EvaluationClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Client.AzureAIClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Client.Evaluation> Create(Azure.AI.Client.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.Evaluation>> CreateAsync(Azure.AI.Client.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.EvaluationSchedule> CreateOrReplaceSchedule(string id, Azure.AI.Client.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSchedule(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.EvaluationSchedule>> CreateOrReplaceScheduleAsync(string id, Azure.AI.Client.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceScheduleAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSchedule(string id, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScheduleAsync(string id, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.Evaluation> GetEvaluation(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.Evaluation>> GetEvaluationAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Client.Evaluation> GetEvaluations(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Client.Evaluation> GetEvaluationsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Client.EvaluationSchedule> GetSchedule(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Client.EvaluationSchedule>> GetScheduleAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Client.EvaluationSchedule> GetSchedules(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Client.EvaluationSchedule> GetSchedulesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EvaluationSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluationSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluationSchedule>
    {
        public EvaluationSchedule(Azure.AI.Client.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> evaluators, Azure.AI.Client.Trigger trigger, Azure.AI.Client.SamplingStrategy samplingStrategy) { }
        public Azure.AI.Client.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Client.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ProvisioningStatus { get { throw null; } }
        public Azure.AI.Client.SamplingStrategy SamplingStrategy { get { throw null; } set { } }
        public Azure.AI.Client.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Client.Trigger Trigger { get { throw null; } set { } }
        Azure.AI.Client.EvaluationSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluationSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluationSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.EvaluationSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluationSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluationSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluationSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        Azure.AI.Client.EvaluatorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluatorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.EvaluatorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.EvaluatorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluatorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluatorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.EvaluatorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileContentResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileContentResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileContentResponse>
    {
        internal FileContentResponse() { }
        public System.BinaryData Content { get { throw null; } }
        Azure.AI.Client.FileContentResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileContentResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileContentResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FileContentResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileContentResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileContentResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileContentResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Client.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        Azure.AI.Client.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        Azure.AI.Client.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        Azure.AI.Client.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Client.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Client.FileState Deleted { get { throw null; } }
        public static Azure.AI.Client.FileState Deleting { get { throw null; } }
        public static Azure.AI.Client.FileState Error { get { throw null; } }
        public static Azure.AI.Client.FileState Pending { get { throw null; } }
        public static Azure.AI.Client.FileState Processed { get { throw null; } }
        public static Azure.AI.Client.FileState Running { get { throw null; } }
        public static Azure.AI.Client.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Client.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.FileState left, Azure.AI.Client.FileState right) { throw null; }
        public static implicit operator Azure.AI.Client.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.FileState left, Azure.AI.Client.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.AI.Client.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.AI.Client.Frequency Day { get { throw null; } }
        public static Azure.AI.Client.Frequency Hour { get { throw null; } }
        public static Azure.AI.Client.Frequency Minute { get { throw null; } }
        public static Azure.AI.Client.Frequency Month { get { throw null; } }
        public static Azure.AI.Client.Frequency Week { get { throw null; } }
        public bool Equals(Azure.AI.Client.Frequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.Frequency left, Azure.AI.Client.Frequency right) { throw null; }
        public static implicit operator Azure.AI.Client.Frequency (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.Frequency left, Azure.AI.Client.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionName>
    {
        public FunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.AI.Client.FunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.FunctionToolDefinition functionToolDefinition, Azure.AI.Client.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Client.FunctionToolDefinition functionToolDefinition, Azure.AI.Client.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Client.RequiredFunctionToolCall functionToolCall, Azure.AI.Client.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepFunctionToolCall functionToolCall, Azure.AI.Client.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Client.FunctionToolDefinition functionToolDefinition, Azure.AI.Client.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Client.FunctionToolDefinition functionToolDefinition, Azure.AI.Client.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Client.RequiredFunctionToolCall functionToolCall, Azure.AI.Client.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepFunctionToolCall functionToolCall, Azure.AI.Client.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Client.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteRunDetails : System.IEquatable<Azure.AI.Client.IncompleteRunDetails>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteRunDetails(string value) { throw null; }
        public static Azure.AI.Client.IncompleteRunDetails MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Client.IncompleteRunDetails MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Client.IncompleteRunDetails other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.IncompleteRunDetails left, Azure.AI.Client.IncompleteRunDetails right) { throw null; }
        public static implicit operator Azure.AI.Client.IncompleteRunDetails (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.IncompleteRunDetails left, Azure.AI.Client.IncompleteRunDetails right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.IndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.IndexResource>
    {
        public IndexResource(string indexConnectionId, string indexName) { }
        public string IndexConnectionId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        Azure.AI.Client.IndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.IndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.IndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.IndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.IndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.IndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.IndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.InputData>
    {
        protected InputData() { }
        Azure.AI.Client.InputData System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.InputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.InputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.InputData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.InputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.InputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.InputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Client.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Client.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Client.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Client.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.ListSortOrder left, Azure.AI.Client.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Client.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.ListSortOrder left, Azure.AI.Client.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageAttachment>
    {
        public MessageAttachment(string fileId, System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        Azure.AI.Client.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageContent>
    {
        protected MessageContent() { }
        Azure.AI.Client.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Client.MessageRole Role { get { throw null; } }
        Azure.AI.Client.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Client.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.MessageDeltaChunkObject Object { get { throw null; } }
        Azure.AI.Client.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Client.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Client.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Client.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.MessageDeltaChunkObject left, Azure.AI.Client.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Client.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.MessageDeltaChunkObject left, Azure.AI.Client.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Client.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Client.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Client.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        Azure.AI.Client.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Client.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextAnnotation>
    {
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Client.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Client.MessageDeltaTextContentObject Text { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Client.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Client.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Client.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        Azure.AI.Client.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageIncompleteDetails>
    {
        public MessageIncompleteDetails(Azure.AI.Client.MessageIncompleteDetailsReason reason) { }
        public Azure.AI.Client.MessageIncompleteDetailsReason Reason { get { throw null; } set { } }
        Azure.AI.Client.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Client.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Client.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Client.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Client.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Client.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Client.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Client.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.MessageIncompleteDetailsReason left, Azure.AI.Client.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Client.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.MessageIncompleteDetailsReason left, Azure.AI.Client.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Client.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Client.MessageRole Agent { get { throw null; } }
        public static Azure.AI.Client.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Client.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.MessageRole left, Azure.AI.Client.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Client.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.MessageRole left, Azure.AI.Client.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Client.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Client.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Client.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Client.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.MessageStatus left, Azure.AI.Client.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.MessageStatus left, Azure.AI.Client.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Client.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Client.MessageStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Client.MessageStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Client.MessageStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Client.MessageStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Client.MessageStreamEvent ThreadMessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.MessageStreamEvent left, Azure.AI.Client.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.MessageStreamEvent left, Azure.AI.Client.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } set { } }
        Azure.AI.Client.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Client.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Client.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Client.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } set { } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } set { } }
        Azure.AI.Client.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Client.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } set { } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } set { } }
        Azure.AI.Client.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition() { }
        Azure.AI.Client.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIFile>
    {
        internal OpenAIFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.OpenAIFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Client.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        Azure.AI.Client.OpenAIFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.OpenAIFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIFilePurpose : System.IEquatable<Azure.AI.Client.OpenAIFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIFilePurpose(string value) { throw null; }
        public static Azure.AI.Client.OpenAIFilePurpose Agents { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose AgentsOutput { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose Batch { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose BatchOutput { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose FineTuneResults { get { throw null; } }
        public static Azure.AI.Client.OpenAIFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Client.OpenAIFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.OpenAIFilePurpose left, Azure.AI.Client.OpenAIFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Client.OpenAIFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.OpenAIFilePurpose left, Azure.AI.Client.OpenAIFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenAIPageableListOfVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>
    {
        internal OpenAIPageableListOfVectorStore() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.VectorStore> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Client.OpenAIPageableListOfVectorStoreObject Object { get { throw null; } }
        Azure.AI.Client.OpenAIPageableListOfVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.OpenAIPageableListOfVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIPageableListOfVectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>
    {
        internal OpenAIPageableListOfVectorStoreFile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.VectorStoreFile> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject Object { get { throw null; } }
        Azure.AI.Client.OpenAIPageableListOfVectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.OpenAIPageableListOfVectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.OpenAIPageableListOfVectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIPageableListOfVectorStoreFileObject : System.IEquatable<Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIPageableListOfVectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject List { get { throw null; } }
        public bool Equals(Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject left, Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject left, Azure.AI.Client.OpenAIPageableListOfVectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIPageableListOfVectorStoreObject : System.IEquatable<Azure.AI.Client.OpenAIPageableListOfVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIPageableListOfVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Client.OpenAIPageableListOfVectorStoreObject List { get { throw null; } }
        public bool Equals(Azure.AI.Client.OpenAIPageableListOfVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.OpenAIPageableListOfVectorStoreObject left, Azure.AI.Client.OpenAIPageableListOfVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Client.OpenAIPageableListOfVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.OpenAIPageableListOfVectorStoreObject left, Azure.AI.Client.OpenAIPageableListOfVectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceSchedule>
    {
        public RecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes, System.Collections.Generic.IEnumerable<Azure.AI.Client.WeekDays> weekDays, System.Collections.Generic.IEnumerable<int> monthDays) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Client.WeekDays> WeekDays { get { throw null; } }
        Azure.AI.Client.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Client.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceTrigger>
    {
        public RecurrenceTrigger(Azure.AI.Client.Frequency frequency, int interval, Azure.AI.Client.RecurrenceSchedule schedule) { }
        public Azure.AI.Client.Frequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Client.RecurrenceSchedule Schedule { get { throw null; } set { } }
        Azure.AI.Client.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredAction>
    {
        protected RequiredAction() { }
        Azure.AI.Client.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Client.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.AI.Client.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.Client.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        Azure.AI.Client.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Client.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Client.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Client.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Client.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Client.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Client.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Client.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Client.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Client.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Client.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStatus left, Azure.AI.Client.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStatus left, Azure.AI.Client.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Client.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Client.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Client.RunStepType Type { get { throw null; } }
        public Azure.AI.Client.RunStepCompletionUsage Usage { get { throw null; } }
        Azure.AI.Client.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        Azure.AI.Client.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingSearchToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepBingSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepBingSearchToolCall>
    {
        internal RunStepBingSearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingSearch { get { throw null; } }
        Azure.AI.Client.RunStepBingSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepBingSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepBingSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepBingSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepBingSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepBingSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepBingSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Client.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Client.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        Azure.AI.Client.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        Azure.AI.Client.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Client.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        Azure.AI.Client.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        Azure.AI.Client.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        Azure.AI.Client.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        Azure.AI.Client.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Client.RunStepDeltaDetail StepDetails { get { throw null; } }
        Azure.AI.Client.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Client.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.RunStepDeltaChunkObject Object { get { throw null; } }
        Azure.AI.Client.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Client.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Client.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepDeltaChunkObject left, Azure.AI.Client.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepDeltaChunkObject left, Azure.AI.Client.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Client.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Client.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Client.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Client.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        Azure.AI.Client.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Client.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        Azure.AI.Client.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        Azure.AI.Client.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Client.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Client.RunStepDeltaFunction Function { get { throw null; } }
        Azure.AI.Client.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Client.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Client.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        Azure.AI.Client.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        Azure.AI.Client.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCall>
    {
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        Azure.AI.Client.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Client.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Client.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDetails>
    {
        protected RunStepDetails() { }
        Azure.AI.Client.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Client.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Client.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Client.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Client.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Client.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepErrorCode left, Azure.AI.Client.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepErrorCode left, Azure.AI.Client.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        Azure.AI.Client.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        Azure.AI.Client.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Client.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Client.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        Azure.AI.Client.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        Azure.AI.Client.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        Azure.AI.Client.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Client.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        Azure.AI.Client.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Client.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Client.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Client.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Client.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Client.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Client.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepStatus left, Azure.AI.Client.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepStatus left, Azure.AI.Client.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Client.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Client.RunStepStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepStreamEvent left, Azure.AI.Client.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepStreamEvent left, Azure.AI.Client.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.Client.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Client.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RunStepToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Client.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Client.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Client.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Client.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStepType left, Azure.AI.Client.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStepType left, Azure.AI.Client.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Client.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Client.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Client.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Client.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.RunStreamEvent left, Azure.AI.Client.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.RunStreamEvent left, Azure.AI.Client.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SamplingStrategy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SamplingStrategy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SamplingStrategy>
    {
        public SamplingStrategy(float rate) { }
        public float Rate { get { throw null; } set { } }
        Azure.AI.Client.SamplingStrategy System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SamplingStrategy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SamplingStrategy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.SamplingStrategy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SamplingStrategy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SamplingStrategy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SamplingStrategy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointToolDefinition : Azure.AI.Client.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SharepointToolDefinition>
    {
        public SharepointToolDefinition() { }
        Azure.AI.Client.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Client.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.RequiredToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Client.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SystemData>
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        Azure.AI.Client.SystemData System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessage>
    {
        public ThreadMessage(string id, System.DateTimeOffset createdAt, string threadId, Azure.AI.Client.MessageStatus status, Azure.AI.Client.MessageIncompleteDetails incompleteDetails, System.DateTimeOffset? completedAt, System.DateTimeOffset? incompleteAt, Azure.AI.Client.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageContent> contentItems, string assistantId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Client.MessageAttachment> attachments, System.Collections.Generic.IDictionary<string, string> metadata) { }
        public string AssistantId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Client.MessageAttachment> Attachments { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Client.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } set { } }
        public Azure.AI.Client.MessageIncompleteDetails IncompleteDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Client.MessageRole Role { get { throw null; } set { } }
        public string RunId { get { throw null; } set { } }
        public Azure.AI.Client.MessageStatus Status { get { throw null; } set { } }
        public string ThreadId { get { throw null; } set { } }
        Azure.AI.Client.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Client.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Client.MessageAttachment> Attachments { get { throw null; } set { } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Client.MessageRole Role { get { throw null; } }
        Azure.AI.Client.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.IncompleteRunDetails? IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Client.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool? ParallelToolCalls { get { throw null; } }
        public Azure.AI.Client.RequiredAction RequiredAction { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Client.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Client.UpdateToolResourcesOptions ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Client.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Client.TruncationObject TruncationStrategy { get { throw null; } }
        public Azure.AI.Client.RunCompletionUsage Usage { get { throw null; } }
        Azure.AI.Client.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Client.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Client.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Client.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.ThreadStreamEvent left, Azure.AI.Client.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Client.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.ThreadStreamEvent left, Azure.AI.Client.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolDefinition>
    {
        protected ToolDefinition() { }
        Azure.AI.Client.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Client.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Client.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        Azure.AI.Client.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Client.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource BingSearch { get { throw null; } set { } }
        public Azure.AI.Client.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Client.FileSearchToolResource FileSearch { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource MicrosoftFabric { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource SharePoint { get { throw null; } set { } }
        Azure.AI.Client.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Trigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Trigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Trigger>
    {
        protected Trigger() { }
        Azure.AI.Client.Trigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Trigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.Trigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.Trigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Trigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Trigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.Trigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TruncationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.TruncationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.TruncationObject>
    {
        public TruncationObject(Azure.AI.Client.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Client.TruncationStrategy Type { get { throw null; } set { } }
        Azure.AI.Client.TruncationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.TruncationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.TruncationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.TruncationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.TruncationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.TruncationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.TruncationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Client.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Client.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Client.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Client.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.TruncationStrategy left, Azure.AI.Client.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Client.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.TruncationStrategy left, Azure.AI.Client.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateCodeInterpreterToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>
    {
        public UpdateCodeInterpreterToolResourceOptions() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileSearchToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>
    {
        public UpdateFileSearchToolResourceOptions() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        Azure.AI.Client.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateFileSearchToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolResourcesOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateToolResourcesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateToolResourcesOptions>
    {
        public UpdateToolResourcesOptions() { }
        public Azure.AI.Client.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource BingSearch { get { throw null; } set { } }
        public Azure.AI.Client.UpdateCodeInterpreterToolResourceOptions CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Client.UpdateFileSearchToolResourceOptions FileSearch { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource MicrosoftFabric { get { throw null; } set { } }
        public Azure.AI.Client.ConnectionListResource SharePoint { get { throw null; } set { } }
        Azure.AI.Client.UpdateToolResourcesOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateToolResourcesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.UpdateToolResourcesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.UpdateToolResourcesOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateToolResourcesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateToolResourcesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.UpdateToolResourcesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStore>
    {
        internal VectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Client.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Client.VectorStoreObject Object { get { throw null; } }
        public Azure.AI.Client.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        Azure.AI.Client.VectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyRequest : Azure.AI.Client.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>
    {
        public VectorStoreAutoChunkingStrategyRequest() { }
        Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Client.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>
    {
        protected VectorStoreChunkingStrategyRequest() { }
        Azure.AI.Client.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        Azure.AI.Client.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreDeletionStatus>
    {
        internal VectorStoreDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.VectorStoreDeletionStatusObject Object { get { throw null; } }
        Azure.AI.Client.VectorStoreDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDeletionStatusObject : System.IEquatable<Azure.AI.Client.VectorStoreDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreDeletionStatusObject VectorStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreDeletionStatusObject left, Azure.AI.Client.VectorStoreDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreDeletionStatusObject left, Azure.AI.Client.VectorStoreDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Client.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Client.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        Azure.AI.Client.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Client.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreExpirationPolicyAnchor left, Azure.AI.Client.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreExpirationPolicyAnchor left, Azure.AI.Client.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Client.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        Azure.AI.Client.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        Azure.AI.Client.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Client.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileBatchObject left, Azure.AI.Client.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileBatchObject left, Azure.AI.Client.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Client.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileBatchStatus left, Azure.AI.Client.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileBatchStatus left, Azure.AI.Client.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        Azure.AI.Client.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileDeletionStatus>
    {
        internal VectorStoreFileDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Client.VectorStoreFileDeletionStatusObject Object { get { throw null; } }
        Azure.AI.Client.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileDeletionStatusObject : System.IEquatable<Azure.AI.Client.VectorStoreFileDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileDeletionStatusObject VectorStoreFileDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileDeletionStatusObject left, Azure.AI.Client.VectorStoreFileDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileDeletionStatusObject left, Azure.AI.Client.VectorStoreFileDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Client.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Client.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Client.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileErrorCode FileNotFound { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileErrorCode InternalError { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileErrorCode ParsingError { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileErrorCode UnhandledMimeType { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileErrorCode left, Azure.AI.Client.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileErrorCode left, Azure.AI.Client.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Client.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileObject left, Azure.AI.Client.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileObject left, Azure.AI.Client.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Client.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileStatus left, Azure.AI.Client.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileStatus left, Azure.AI.Client.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Client.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreFileStatusFilter left, Azure.AI.Client.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreFileStatusFilter left, Azure.AI.Client.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreObject : System.IEquatable<Azure.AI.Client.VectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreObject(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreObject left, Azure.AI.Client.VectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreObject left, Azure.AI.Client.VectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Client.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Client.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Client.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Client.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Client.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Client.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Client.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Client.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Client.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.VectorStoreStatus left, Azure.AI.Client.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Client.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.VectorStoreStatus left, Azure.AI.Client.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekDays : System.IEquatable<Azure.AI.Client.WeekDays>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDays(string value) { throw null; }
        public static Azure.AI.Client.WeekDays Friday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Monday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Saturday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Sunday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Thursday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Tuesday { get { throw null; } }
        public static Azure.AI.Client.WeekDays Wednesday { get { throw null; } }
        public bool Equals(Azure.AI.Client.WeekDays other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Client.WeekDays left, Azure.AI.Client.WeekDays right) { throw null; }
        public static implicit operator Azure.AI.Client.WeekDays (string value) { throw null; }
        public static bool operator !=(Azure.AI.Client.WeekDays left, Azure.AI.Client.WeekDays right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIClientClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Client.AzureAIClient, Azure.AI.Client.AzureAIClientOptions> AddAzureAIClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Client.AzureAIClient, Azure.AI.Client.AzureAIClientOptions> AddAzureAIClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
