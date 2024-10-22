namespace Azure.AI.Project
{
    public partial class Agent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Agent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Agent>
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
        public Azure.AI.Project.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        Azure.AI.Project.Agent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Agent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Agent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.Agent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Agent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Agent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Agent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentClient
    {
        protected AgentClient() { }
        public AgentClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AgentClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public AgentClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AgentClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAgent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.Agent> CreateAgent(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, Azure.AI.Project.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.Agent>> CreateAgentAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, Azure.AI.Project.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadMessage> CreateMessage(string threadId, Azure.AI.Project.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Project.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> CreateRun(Azure.AI.Project.AgentThread thread, Azure.AI.Project.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ThreadMessage> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Project.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> CreateRunAsync(Azure.AI.Project.AgentThread thread, Azure.AI.Project.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ThreadMessage> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Project.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.AgentThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Project.ThreadMessageOptions> messages = null, Azure.AI.Project.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThreadAndRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Project.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> overrideTools = null, Azure.AI.Project.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Project.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAndRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Project.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> overrideTools = null, Azure.AI.Project.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Project.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.AgentThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Project.ThreadMessageOptions> messages = null, Azure.AI.Project.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Project.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Project.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFile(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFileBatch(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileBatchAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds, Azure.AI.Project.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAgent(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAgentAsync(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreDeletionStatus> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreDeletionStatus>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFileDeletionStatus> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFileDeletionStatus>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAgent(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.Agent> GetAgent(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAgentAsync(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.Agent>> GetAgentAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.Agent>> GetAgents(int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.Agent>>> GetAgentsAsync(int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.FileContentResponse> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.FileContentResponse>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Project.OpenAIFile>> GetFiles(Azure.AI.Project.OpenAIFilePurpose? purpose = default(Azure.AI.Project.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Project.OpenAIFile>>> GetFilesAsync(Azure.AI.Project.OpenAIFilePurpose? purpose = default(Azure.AI.Project.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.ThreadMessage>> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.ThreadMessage>>> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStep(string threadId, string runId, string stepId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStepAsync(string threadId, string runId, string stepId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.RunStep>> GetRunSteps(Azure.AI.Project.ThreadRun run, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.RunStep>>> GetRunStepsAsync(Azure.AI.Project.ThreadRun run, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.PageableList<Azure.AI.Project.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.AgentThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.AgentThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Project.VectorStoreFileStatusFilter? filter = default(Azure.AI.Project.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Project.VectorStoreFileStatusFilter? filter = default(Azure.AI.Project.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Project.VectorStoreFileStatusFilter? filter = default(Azure.AI.Project.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFiles(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Project.VectorStoreFileStatusFilter? filter = default(Azure.AI.Project.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFilesAsync(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStores(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIPageableListOfVectorStore>> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Project.ListSortOrder? order = default(Azure.AI.Project.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoresAsync(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.VectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Project.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Project.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Project.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolOutput> toolOutputs, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Project.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolOutput> toolOutputs, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAgent(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.Agent> UpdateAgent(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, Azure.AI.Project.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAgentAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.Agent>> UpdateAgentAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, Azure.AI.Project.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.AgentThread> UpdateThread(string threadId, Azure.AI.Project.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.AgentThread>> UpdateThreadAsync(string threadId, Azure.AI.Project.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIFile> UploadFile(System.IO.Stream data, Azure.AI.Project.OpenAIFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.OpenAIFile> UploadFile(string filePath, Azure.AI.Project.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIFile>> UploadFileAsync(System.IO.Stream data, Azure.AI.Project.OpenAIFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.OpenAIFile>> UploadFileAsync(string filePath, Azure.AI.Project.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentsApiResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsApiResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsApiResponseFormat>
    {
        public AgentsApiResponseFormat() { }
        public Azure.AI.Project.ApiResponseFormat? Type { get { throw null; } set { } }
        Azure.AI.Project.AgentsApiResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsApiResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsApiResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AgentsApiResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsApiResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsApiResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsApiResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiResponseFormatMode : System.IEquatable<Azure.AI.Project.AgentsApiResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Project.AgentsApiResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Project.AgentsApiResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Project.AgentsApiResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.AgentsApiResponseFormatMode left, Azure.AI.Project.AgentsApiResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Project.AgentsApiResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.AgentsApiResponseFormatMode left, Azure.AI.Project.AgentsApiResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiToolChoiceOptionMode : System.IEquatable<Azure.AI.Project.AgentsApiToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Project.AgentsApiToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Project.AgentsApiToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Project.AgentsApiToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.AgentsApiToolChoiceOptionMode left, Azure.AI.Project.AgentsApiToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Project.AgentsApiToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.AgentsApiToolChoiceOptionMode left, Azure.AI.Project.AgentsApiToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsNamedToolChoice>
    {
        public AgentsNamedToolChoice(Azure.AI.Project.AgentsNamedToolChoiceType type) { }
        public Azure.AI.Project.FunctionName Function { get { throw null; } set { } }
        public Azure.AI.Project.AgentsNamedToolChoiceType Type { get { throw null; } set { } }
        Azure.AI.Project.AgentsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AgentsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsNamedToolChoiceType : System.IEquatable<Azure.AI.Project.AgentsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Project.AgentsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Project.AgentsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Project.AgentsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.AgentsNamedToolChoiceType left, Azure.AI.Project.AgentsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Project.AgentsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.AgentsNamedToolChoiceType left, Azure.AI.Project.AgentsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStreamEvent : System.IEquatable<Azure.AI.Project.AgentStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStreamEvent(string value) { throw null; }
        public static Azure.AI.Project.AgentStreamEvent Done { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent Error { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadMessageInProgress { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Project.AgentStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.AgentStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.AgentStreamEvent left, Azure.AI.Project.AgentStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.AgentStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.AgentStreamEvent left, Azure.AI.Project.AgentStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThread>
    {
        internal AgentThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Project.ToolResources ToolResources { get { throw null; } }
        Azure.AI.Project.AgentThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AgentThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThreadCreationOptions>
    {
        public AgentThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Project.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Project.ToolResources ToolResources { get { throw null; } set { } }
        Azure.AI.Project.AgentThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AgentThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AgentThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AgentThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIClientModelFactory
    {
        public static Azure.AI.Project.Agent Agent(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, Azure.AI.Project.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.AgentThread AgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Project.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Project.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Project.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Project.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Project.OpenAIFile OpenAIFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Project.OpenAIFilePurpose purpose = default(Azure.AI.Project.OpenAIFilePurpose)) { throw null; }
        public static Azure.AI.Project.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.Project.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Project.RunStep RunStep(string id = null, Azure.AI.Project.RunStepType type = default(Azure.AI.Project.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Project.RunStepStatus status = default(Azure.AI.Project.RunStepStatus), Azure.AI.Project.RunStepDetails stepDetails = null, Azure.AI.Project.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Project.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Project.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.Project.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Project.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Project.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Project.MessageStatus status = default(Azure.AI.Project.MessageStatus), Azure.AI.Project.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Project.MessageRole role = default(Azure.AI.Project.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Project.RunStatus status = default(Azure.AI.Project.RunStatus), Azure.AI.Project.RequiredAction requiredAction = null, Azure.AI.Project.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Project.IncompleteRunDetails? incompleteDetails = default(Azure.AI.Project.IncompleteRunDetails?), Azure.AI.Project.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Project.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Project.UpdateToolResourcesOptions toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
    }
    public partial class AIProjectClient
    {
        protected AIProjectClient() { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Project.AgentClient GetAgentClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Project.ConnectionClient GetConnectionClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Project.EvaluationClient GetEvaluationClient(string apiVersion = "2024-07-01-preview") { throw null; }
    }
    public partial class AIProjectClientOptions : Azure.Core.ClientOptions
    {
        public AIProjectClientOptions(Azure.AI.Project.AIProjectClientOptions.ServiceVersion version = Azure.AI.Project.AIProjectClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_01_Preview = 1,
        }
    }
    public static partial class AIProjectModelFactory
    {
        public static Azure.AI.Project.Evaluation Evaluation(string id = null, Azure.AI.Project.InputData data = null, string displayName = null, string description = null, Azure.AI.Project.SystemData systemData = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Project.EvaluationSchedule EvaluationSchedule(string name = null, Azure.AI.Project.ApplicationInsightsConfiguration data = null, string description = null, Azure.AI.Project.SystemData systemData = null, string provisioningStatus = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> evaluators = null, Azure.AI.Project.Trigger trigger = null, Azure.AI.Project.SamplingStrategy samplingStrategy = null) { throw null; }
        public static Azure.AI.Project.FileContentResponse FileContentResponse(System.BinaryData content = null) { throw null; }
        public static Azure.AI.Project.MessageDelta MessageDelta(Azure.AI.Project.MessageRole role = default(Azure.AI.Project.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Project.MessageDeltaChunkObject @object = default(Azure.AI.Project.MessageDeltaChunkObject), Azure.AI.Project.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Project.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Project.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Project.OpenAIPageableListOfVectorStore OpenAIPageableListOfVectorStore(Azure.AI.Project.OpenAIPageableListOfVectorStoreObject @object = default(Azure.AI.Project.OpenAIPageableListOfVectorStoreObject), System.Collections.Generic.IEnumerable<Azure.AI.Project.VectorStore> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Project.OpenAIPageableListOfVectorStoreFile OpenAIPageableListOfVectorStoreFile(Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject @object = default(Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject), System.Collections.Generic.IEnumerable<Azure.AI.Project.VectorStoreFile> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Project.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Project.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Project.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Project.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Project.RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Project.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Project.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Project.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Project.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Project.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Project.RunStepDelta RunStepDelta(Azure.AI.Project.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Project.RunStepDeltaChunkObject @object = default(Azure.AI.Project.RunStepDeltaChunkObject), Azure.AI.Project.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Project.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Project.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Project.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Project.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Project.RunStepError RunStepError(Azure.AI.Project.RunStepErrorCode code = default(Azure.AI.Project.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Project.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Project.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Project.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Project.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Project.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Project.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Project.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Project.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Project.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Project.SystemData SystemData(System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), string createdBy = null, string createdByType = null, System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Project.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Project.MessageRole role = default(Azure.AI.Project.MessageRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.VectorStore VectorStore(string id = null, Azure.AI.Project.VectorStoreObject @object = default(Azure.AI.Project.VectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Project.VectorStoreFileCount fileCounts = null, Azure.AI.Project.VectorStoreStatus status = default(Azure.AI.Project.VectorStoreStatus), Azure.AI.Project.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Project.VectorStoreDeletionStatus VectorStoreDeletionStatus(string id = null, bool deleted = false, Azure.AI.Project.VectorStoreDeletionStatusObject @object = default(Azure.AI.Project.VectorStoreDeletionStatusObject)) { throw null; }
        public static Azure.AI.Project.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Project.VectorStoreFileObject @object = default(Azure.AI.Project.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Project.VectorStoreFileStatus status = default(Azure.AI.Project.VectorStoreFileStatus), Azure.AI.Project.VectorStoreFileError lastError = null, Azure.AI.Project.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Project.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Project.VectorStoreFileBatchObject @object = default(Azure.AI.Project.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Project.VectorStoreFileBatchStatus status = default(Azure.AI.Project.VectorStoreFileBatchStatus), Azure.AI.Project.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Project.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Project.VectorStoreFileDeletionStatus VectorStoreFileDeletionStatus(string id = null, bool deleted = false, Azure.AI.Project.VectorStoreFileDeletionStatusObject @object = default(Azure.AI.Project.VectorStoreFileDeletionStatusObject)) { throw null; }
        public static Azure.AI.Project.VectorStoreFileError VectorStoreFileError(Azure.AI.Project.VectorStoreFileErrorCode code = default(Azure.AI.Project.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiResponseFormat : System.IEquatable<Azure.AI.Project.ApiResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiResponseFormat(string value) { throw null; }
        public static Azure.AI.Project.ApiResponseFormat JsonObject { get { throw null; } }
        public static Azure.AI.Project.ApiResponseFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.Project.ApiResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.ApiResponseFormat left, Azure.AI.Project.ApiResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.Project.ApiResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.ApiResponseFormat left, Azure.AI.Project.ApiResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsConfiguration : Azure.AI.Project.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ApplicationInsightsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ApplicationInsightsConfiguration>
    {
        public ApplicationInsightsConfiguration(string resourceId, string query, string serviceName) { }
        public string ConnectionString { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        Azure.AI.Project.ApplicationInsightsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ApplicationInsightsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ApplicationInsightsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ApplicationInsightsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ApplicationInsightsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ApplicationInsightsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ApplicationInsightsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AuthenticationType
    {
        ApiKey = 0,
        AAD = 1,
        SAS = 2,
    }
    public partial class AzureAISearchResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchResource>
    {
        public AzureAISearchResource() { }
        public System.Collections.Generic.IList<Azure.AI.Project.IndexResource> IndexList { get { throw null; } }
        Azure.AI.Project.AzureAISearchResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AzureAISearchResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        Azure.AI.Project.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.BingGroundingToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.BingGroundingToolDefinition>
    {
        public BingGroundingToolDefinition() { }
        Azure.AI.Project.BingGroundingToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.BingGroundingToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.BingGroundingToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.BingGroundingToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.BingGroundingToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.BingGroundingToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.BingGroundingToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        Azure.AI.Project.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        Azure.AI.Project.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionClient
    {
        protected ConnectionClient() { }
        public ConnectionClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public ConnectionClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public ConnectionClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public ConnectionClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
    }
    public partial class ConnectionListResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionListResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionListResource>
    {
        public ConnectionListResource() { }
        public System.Collections.Generic.IList<Azure.AI.Project.ConnectionResource> ConnectionList { get { throw null; } }
        Azure.AI.Project.ConnectionListResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionListResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionListResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ConnectionListResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionListResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionListResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionListResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionResource>
    {
        public ConnectionResource(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        Azure.AI.Project.ConnectionResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ConnectionResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ConnectionResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ConnectionResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ConnectionType
    {
        AzureOpenAI = 0,
        Serverless = 1,
        AzureBlobStorage = 2,
        AIServices = 3,
    }
    public partial class CronTrigger : Azure.AI.Project.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public string Expression { get { throw null; } set { } }
        Azure.AI.Project.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Dataset : Azure.AI.Project.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Dataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Dataset>
    {
        public Dataset(string id) { }
        public string Id { get { throw null; } set { } }
        Azure.AI.Project.Dataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Dataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Dataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.Dataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Dataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Dataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Dataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Project.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Project.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Project.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.DoneEvent left, Azure.AI.Project.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.DoneEvent left, Azure.AI.Project.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Project.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Project.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Project.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.ErrorEvent left, Azure.AI.Project.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.ErrorEvent left, Azure.AI.Project.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Evaluation>
    {
        public Evaluation(Azure.AI.Project.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Project.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.AI.Project.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.AI.Project.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationClient
    {
        protected EvaluationClient() { }
        public EvaluationClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public EvaluationClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public EvaluationClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public EvaluationClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Project.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Project.Evaluation> Create(Azure.AI.Project.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.Evaluation>> CreateAsync(Azure.AI.Project.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.EvaluationSchedule> CreateOrReplaceSchedule(string name, Azure.AI.Project.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSchedule(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.EvaluationSchedule>> CreateOrReplaceScheduleAsync(string name, Azure.AI.Project.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceScheduleAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSchedule(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteScheduleAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.Evaluation> GetEvaluation(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.Evaluation>> GetEvaluationAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Project.Evaluation> GetEvaluations(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Project.Evaluation> GetEvaluationsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Project.EvaluationSchedule> GetSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Project.EvaluationSchedule>> GetScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Project.EvaluationSchedule> GetSchedules(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Project.EvaluationSchedule> GetSchedulesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EvaluationSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluationSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluationSchedule>
    {
        public EvaluationSchedule(Azure.AI.Project.ApplicationInsightsConfiguration data, System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> evaluators, Azure.AI.Project.Trigger trigger, Azure.AI.Project.SamplingStrategy samplingStrategy) { }
        public Azure.AI.Project.ApplicationInsightsConfiguration Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Project.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ProvisioningStatus { get { throw null; } }
        public Azure.AI.Project.SamplingStrategy SamplingStrategy { get { throw null; } set { } }
        public Azure.AI.Project.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Project.Trigger Trigger { get { throw null; } set { } }
        Azure.AI.Project.EvaluationSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluationSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluationSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.EvaluationSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluationSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluationSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluationSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        Azure.AI.Project.EvaluatorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluatorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.EvaluatorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.EvaluatorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluatorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluatorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.EvaluatorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileContentResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileContentResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileContentResponse>
    {
        internal FileContentResponse() { }
        public System.BinaryData Content { get { throw null; } }
        Azure.AI.Project.FileContentResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileContentResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileContentResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FileContentResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileContentResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileContentResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileContentResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Project.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        Azure.AI.Project.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        Azure.AI.Project.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        Azure.AI.Project.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Project.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Project.FileState Deleted { get { throw null; } }
        public static Azure.AI.Project.FileState Deleting { get { throw null; } }
        public static Azure.AI.Project.FileState Error { get { throw null; } }
        public static Azure.AI.Project.FileState Pending { get { throw null; } }
        public static Azure.AI.Project.FileState Processed { get { throw null; } }
        public static Azure.AI.Project.FileState Running { get { throw null; } }
        public static Azure.AI.Project.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Project.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.FileState left, Azure.AI.Project.FileState right) { throw null; }
        public static implicit operator Azure.AI.Project.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.FileState left, Azure.AI.Project.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.AI.Project.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.AI.Project.Frequency Day { get { throw null; } }
        public static Azure.AI.Project.Frequency Hour { get { throw null; } }
        public static Azure.AI.Project.Frequency Minute { get { throw null; } }
        public static Azure.AI.Project.Frequency Month { get { throw null; } }
        public static Azure.AI.Project.Frequency Week { get { throw null; } }
        public bool Equals(Azure.AI.Project.Frequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.Frequency left, Azure.AI.Project.Frequency right) { throw null; }
        public static implicit operator Azure.AI.Project.Frequency (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.Frequency left, Azure.AI.Project.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionName>
    {
        public FunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        Azure.AI.Project.FunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.FunctionToolDefinition functionToolDefinition, Azure.AI.Project.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Project.FunctionToolDefinition functionToolDefinition, Azure.AI.Project.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Project.RequiredFunctionToolCall functionToolCall, Azure.AI.Project.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepFunctionToolCall functionToolCall, Azure.AI.Project.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Project.FunctionToolDefinition functionToolDefinition, Azure.AI.Project.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Project.FunctionToolDefinition functionToolDefinition, Azure.AI.Project.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Project.RequiredFunctionToolCall functionToolCall, Azure.AI.Project.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepFunctionToolCall functionToolCall, Azure.AI.Project.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Project.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteRunDetails : System.IEquatable<Azure.AI.Project.IncompleteRunDetails>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteRunDetails(string value) { throw null; }
        public static Azure.AI.Project.IncompleteRunDetails MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Project.IncompleteRunDetails MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Project.IncompleteRunDetails other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.IncompleteRunDetails left, Azure.AI.Project.IncompleteRunDetails right) { throw null; }
        public static implicit operator Azure.AI.Project.IncompleteRunDetails (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.IncompleteRunDetails left, Azure.AI.Project.IncompleteRunDetails right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.IndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.IndexResource>
    {
        public IndexResource(string indexConnectionId, string indexName) { }
        public string IndexConnectionId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        Azure.AI.Project.IndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.IndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.IndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.IndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.IndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.IndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.IndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.InputData>
    {
        protected InputData() { }
        Azure.AI.Project.InputData System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.InputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.InputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.InputData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.InputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.InputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.InputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Project.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Project.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Project.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Project.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.ListSortOrder left, Azure.AI.Project.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Project.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.ListSortOrder left, Azure.AI.Project.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageAttachment>
    {
        public MessageAttachment(string fileId, System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        Azure.AI.Project.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageContent>
    {
        protected MessageContent() { }
        Azure.AI.Project.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Project.MessageRole Role { get { throw null; } }
        Azure.AI.Project.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Project.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.MessageDeltaChunkObject Object { get { throw null; } }
        Azure.AI.Project.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Project.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Project.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Project.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.MessageDeltaChunkObject left, Azure.AI.Project.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Project.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.MessageDeltaChunkObject left, Azure.AI.Project.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Project.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Project.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Project.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        Azure.AI.Project.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Project.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextAnnotation>
    {
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Project.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Project.MessageDeltaTextContentObject Text { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Project.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Project.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Project.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        Azure.AI.Project.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageIncompleteDetails>
    {
        public MessageIncompleteDetails(Azure.AI.Project.MessageIncompleteDetailsReason reason) { }
        public Azure.AI.Project.MessageIncompleteDetailsReason Reason { get { throw null; } set { } }
        Azure.AI.Project.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Project.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Project.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Project.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Project.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Project.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Project.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Project.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.MessageIncompleteDetailsReason left, Azure.AI.Project.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Project.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.MessageIncompleteDetailsReason left, Azure.AI.Project.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Project.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Project.MessageRole Agent { get { throw null; } }
        public static Azure.AI.Project.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Project.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.MessageRole left, Azure.AI.Project.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Project.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.MessageRole left, Azure.AI.Project.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Project.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Project.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Project.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Project.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.MessageStatus left, Azure.AI.Project.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.MessageStatus left, Azure.AI.Project.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Project.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Project.MessageStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Project.MessageStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Project.MessageStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Project.MessageStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Project.MessageStreamEvent ThreadMessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.MessageStreamEvent left, Azure.AI.Project.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.MessageStreamEvent left, Azure.AI.Project.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } set { } }
        Azure.AI.Project.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Project.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.Project.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Project.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } set { } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } set { } }
        Azure.AI.Project.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Project.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } set { } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } set { } }
        Azure.AI.Project.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition() { }
        Azure.AI.Project.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIFile>
    {
        internal OpenAIFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.OpenAIFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Project.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        Azure.AI.Project.OpenAIFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.OpenAIFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIFilePurpose : System.IEquatable<Azure.AI.Project.OpenAIFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIFilePurpose(string value) { throw null; }
        public static Azure.AI.Project.OpenAIFilePurpose Agents { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose AgentsOutput { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose Batch { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose BatchOutput { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose FineTuneResults { get { throw null; } }
        public static Azure.AI.Project.OpenAIFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Project.OpenAIFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.OpenAIFilePurpose left, Azure.AI.Project.OpenAIFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Project.OpenAIFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.OpenAIFilePurpose left, Azure.AI.Project.OpenAIFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenAIPageableListOfVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>
    {
        internal OpenAIPageableListOfVectorStore() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.VectorStore> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Project.OpenAIPageableListOfVectorStoreObject Object { get { throw null; } }
        Azure.AI.Project.OpenAIPageableListOfVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.OpenAIPageableListOfVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIPageableListOfVectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>
    {
        internal OpenAIPageableListOfVectorStoreFile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.VectorStoreFile> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject Object { get { throw null; } }
        Azure.AI.Project.OpenAIPageableListOfVectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.OpenAIPageableListOfVectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.OpenAIPageableListOfVectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIPageableListOfVectorStoreFileObject : System.IEquatable<Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIPageableListOfVectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject List { get { throw null; } }
        public bool Equals(Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject left, Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject left, Azure.AI.Project.OpenAIPageableListOfVectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIPageableListOfVectorStoreObject : System.IEquatable<Azure.AI.Project.OpenAIPageableListOfVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIPageableListOfVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Project.OpenAIPageableListOfVectorStoreObject List { get { throw null; } }
        public bool Equals(Azure.AI.Project.OpenAIPageableListOfVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.OpenAIPageableListOfVectorStoreObject left, Azure.AI.Project.OpenAIPageableListOfVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Project.OpenAIPageableListOfVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.OpenAIPageableListOfVectorStoreObject left, Azure.AI.Project.OpenAIPageableListOfVectorStoreObject right) { throw null; }
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
    public partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceSchedule>
    {
        public RecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Project.WeekDays> WeekDays { get { throw null; } }
        Azure.AI.Project.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Project.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceTrigger>
    {
        public RecurrenceTrigger(Azure.AI.Project.Frequency frequency, int interval, Azure.AI.Project.RecurrenceSchedule schedule) { }
        public Azure.AI.Project.Frequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Project.RecurrenceSchedule Schedule { get { throw null; } set { } }
        Azure.AI.Project.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredAction>
    {
        protected RequiredAction() { }
        Azure.AI.Project.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Project.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.AI.Project.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.Project.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        Azure.AI.Project.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Project.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Project.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Project.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Project.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Project.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Project.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Project.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Project.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Project.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Project.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStatus left, Azure.AI.Project.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStatus left, Azure.AI.Project.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Project.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Project.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Project.RunStepType Type { get { throw null; } }
        public Azure.AI.Project.RunStepCompletionUsage Usage { get { throw null; } }
        Azure.AI.Project.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        Azure.AI.Project.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingGroundingToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepBingGroundingToolCall>
    {
        internal RunStepBingGroundingToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        Azure.AI.Project.RunStepBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Project.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Project.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        Azure.AI.Project.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        Azure.AI.Project.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Project.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        Azure.AI.Project.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        Azure.AI.Project.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        Azure.AI.Project.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        Azure.AI.Project.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Project.RunStepDeltaDetail StepDetails { get { throw null; } }
        Azure.AI.Project.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Project.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.RunStepDeltaChunkObject Object { get { throw null; } }
        Azure.AI.Project.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Project.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Project.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepDeltaChunkObject left, Azure.AI.Project.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepDeltaChunkObject left, Azure.AI.Project.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Project.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Project.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Project.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Project.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        Azure.AI.Project.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Project.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        Azure.AI.Project.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        Azure.AI.Project.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Project.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Project.RunStepDeltaFunction Function { get { throw null; } }
        Azure.AI.Project.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Project.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Project.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        Azure.AI.Project.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        Azure.AI.Project.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCall>
    {
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        Azure.AI.Project.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Project.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Project.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDetails>
    {
        protected RunStepDetails() { }
        Azure.AI.Project.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Project.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Project.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Project.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Project.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Project.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepErrorCode left, Azure.AI.Project.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepErrorCode left, Azure.AI.Project.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        Azure.AI.Project.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        Azure.AI.Project.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Project.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Project.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        Azure.AI.Project.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        Azure.AI.Project.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        Azure.AI.Project.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Project.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        Azure.AI.Project.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Project.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Project.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Project.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Project.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Project.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Project.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepStatus left, Azure.AI.Project.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepStatus left, Azure.AI.Project.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Project.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Project.RunStepStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepStreamEvent left, Azure.AI.Project.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepStreamEvent left, Azure.AI.Project.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.Project.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Project.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RunStepToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Project.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Project.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Project.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Project.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStepType left, Azure.AI.Project.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStepType left, Azure.AI.Project.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Project.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Project.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Project.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Project.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.RunStreamEvent left, Azure.AI.Project.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.RunStreamEvent left, Azure.AI.Project.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SamplingStrategy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SamplingStrategy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SamplingStrategy>
    {
        public SamplingStrategy(float rate) { }
        public float Rate { get { throw null; } set { } }
        Azure.AI.Project.SamplingStrategy System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SamplingStrategy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SamplingStrategy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.SamplingStrategy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SamplingStrategy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SamplingStrategy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SamplingStrategy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointToolDefinition : Azure.AI.Project.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SharepointToolDefinition>
    {
        public SharepointToolDefinition() { }
        Azure.AI.Project.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Project.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.RequiredToolCall> ToolCalls { get { throw null; } }
        Azure.AI.Project.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SystemData>
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        Azure.AI.Project.SystemData System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessage>
    {
        public ThreadMessage(string id, System.DateTimeOffset createdAt, string threadId, Azure.AI.Project.MessageStatus status, Azure.AI.Project.MessageIncompleteDetails incompleteDetails, System.DateTimeOffset? completedAt, System.DateTimeOffset? incompleteAt, Azure.AI.Project.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageContent> contentItems, string assistantId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Project.MessageAttachment> attachments, System.Collections.Generic.IDictionary<string, string> metadata) { }
        public string AssistantId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Project.MessageAttachment> Attachments { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Project.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } set { } }
        public Azure.AI.Project.MessageIncompleteDetails IncompleteDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Project.MessageRole Role { get { throw null; } set { } }
        public string RunId { get { throw null; } set { } }
        public Azure.AI.Project.MessageStatus Status { get { throw null; } set { } }
        public string ThreadId { get { throw null; } set { } }
        Azure.AI.Project.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Project.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Project.MessageAttachment> Attachments { get { throw null; } set { } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Project.MessageRole Role { get { throw null; } }
        Azure.AI.Project.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.IncompleteRunDetails? IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Project.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool? ParallelToolCalls { get { throw null; } }
        public Azure.AI.Project.RequiredAction RequiredAction { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Project.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Project.UpdateToolResourcesOptions ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Project.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Project.TruncationObject TruncationStrategy { get { throw null; } }
        public Azure.AI.Project.RunCompletionUsage Usage { get { throw null; } }
        Azure.AI.Project.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Project.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Project.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Project.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.ThreadStreamEvent left, Azure.AI.Project.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Project.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.ThreadStreamEvent left, Azure.AI.Project.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolDefinition>
    {
        protected ToolDefinition() { }
        Azure.AI.Project.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Project.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Project.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        Azure.AI.Project.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Project.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource BingGrounding { get { throw null; } set { } }
        public Azure.AI.Project.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Project.FileSearchToolResource FileSearch { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource MicrosoftFabric { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource SharePoint { get { throw null; } set { } }
        Azure.AI.Project.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Trigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Trigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Trigger>
    {
        protected Trigger() { }
        Azure.AI.Project.Trigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Trigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.Trigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.Trigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Trigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Trigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.Trigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TruncationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.TruncationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.TruncationObject>
    {
        public TruncationObject(Azure.AI.Project.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Project.TruncationStrategy Type { get { throw null; } set { } }
        Azure.AI.Project.TruncationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.TruncationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.TruncationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.TruncationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.TruncationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.TruncationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.TruncationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Project.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Project.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Project.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Project.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.TruncationStrategy left, Azure.AI.Project.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Project.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.TruncationStrategy left, Azure.AI.Project.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateCodeInterpreterToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>
    {
        public UpdateCodeInterpreterToolResourceOptions() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileSearchToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>
    {
        public UpdateFileSearchToolResourceOptions() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        Azure.AI.Project.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateFileSearchToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolResourcesOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateToolResourcesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateToolResourcesOptions>
    {
        public UpdateToolResourcesOptions() { }
        public Azure.AI.Project.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource BingGrounding { get { throw null; } set { } }
        public Azure.AI.Project.UpdateCodeInterpreterToolResourceOptions CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Project.UpdateFileSearchToolResourceOptions FileSearch { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource MicrosoftFabric { get { throw null; } set { } }
        public Azure.AI.Project.ConnectionListResource SharePoint { get { throw null; } set { } }
        Azure.AI.Project.UpdateToolResourcesOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateToolResourcesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.UpdateToolResourcesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.UpdateToolResourcesOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateToolResourcesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateToolResourcesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.UpdateToolResourcesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStore>
    {
        internal VectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Project.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Project.VectorStoreObject Object { get { throw null; } }
        public Azure.AI.Project.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        Azure.AI.Project.VectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyRequest : Azure.AI.Project.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>
    {
        public VectorStoreAutoChunkingStrategyRequest() { }
        Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Project.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>
    {
        protected VectorStoreChunkingStrategyRequest() { }
        Azure.AI.Project.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        Azure.AI.Project.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreDeletionStatus>
    {
        internal VectorStoreDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.VectorStoreDeletionStatusObject Object { get { throw null; } }
        Azure.AI.Project.VectorStoreDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDeletionStatusObject : System.IEquatable<Azure.AI.Project.VectorStoreDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreDeletionStatusObject VectorStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreDeletionStatusObject left, Azure.AI.Project.VectorStoreDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreDeletionStatusObject left, Azure.AI.Project.VectorStoreDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Project.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Project.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        Azure.AI.Project.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Project.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreExpirationPolicyAnchor left, Azure.AI.Project.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreExpirationPolicyAnchor left, Azure.AI.Project.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Project.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        Azure.AI.Project.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        Azure.AI.Project.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Project.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileBatchObject left, Azure.AI.Project.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileBatchObject left, Azure.AI.Project.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Project.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileBatchStatus left, Azure.AI.Project.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileBatchStatus left, Azure.AI.Project.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        Azure.AI.Project.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileDeletionStatus>
    {
        internal VectorStoreFileDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Project.VectorStoreFileDeletionStatusObject Object { get { throw null; } }
        Azure.AI.Project.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileDeletionStatusObject : System.IEquatable<Azure.AI.Project.VectorStoreFileDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileDeletionStatusObject VectorStoreFileDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileDeletionStatusObject left, Azure.AI.Project.VectorStoreFileDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileDeletionStatusObject left, Azure.AI.Project.VectorStoreFileDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Project.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.Project.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Project.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileErrorCode FileNotFound { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileErrorCode InternalError { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileErrorCode ParsingError { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileErrorCode UnhandledMimeType { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileErrorCode left, Azure.AI.Project.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileErrorCode left, Azure.AI.Project.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Project.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileObject left, Azure.AI.Project.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileObject left, Azure.AI.Project.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Project.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileStatus left, Azure.AI.Project.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileStatus left, Azure.AI.Project.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Project.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreFileStatusFilter left, Azure.AI.Project.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreFileStatusFilter left, Azure.AI.Project.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreObject : System.IEquatable<Azure.AI.Project.VectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreObject(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreObject left, Azure.AI.Project.VectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreObject left, Azure.AI.Project.VectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Project.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Project.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Project.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Project.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Project.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Project.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Project.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Project.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Project.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.VectorStoreStatus left, Azure.AI.Project.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Project.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.VectorStoreStatus left, Azure.AI.Project.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekDays : System.IEquatable<Azure.AI.Project.WeekDays>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDays(string value) { throw null; }
        public static Azure.AI.Project.WeekDays Friday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Monday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Saturday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Sunday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Thursday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Tuesday { get { throw null; } }
        public static Azure.AI.Project.WeekDays Wednesday { get { throw null; } }
        public bool Equals(Azure.AI.Project.WeekDays other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Project.WeekDays left, Azure.AI.Project.WeekDays right) { throw null; }
        public static implicit operator Azure.AI.Project.WeekDays (string value) { throw null; }
        public static bool operator !=(Azure.AI.Project.WeekDays left, Azure.AI.Project.WeekDays right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIProjectClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Project.AIProjectClient, Azure.AI.Project.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Project.AIProjectClient, Azure.AI.Project.AIProjectClientOptions> AddAIProjectClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
