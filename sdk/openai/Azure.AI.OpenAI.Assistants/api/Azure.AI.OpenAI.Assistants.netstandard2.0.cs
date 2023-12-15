namespace Azure.AI.OpenAI.Assistants
{
    public partial class Assistant
    {
        internal Assistant() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileIds { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
    }
    public partial class AssistantCreationOptions
    {
        public AssistantCreationOptions(string model) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
    }
    public partial class AssistantFile
    {
        internal AssistantFile() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
    }
    public partial class AssistantModificationOptions
    {
        public AssistantModificationOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
    }
    public partial class AssistantsClient
    {
        protected AssistantsClient() { }
        public AssistantsClient(string openAIApiKey) { }
        public AssistantsClient(string openAIApiKey, Azure.AI.OpenAI.Assistants.AssistantsClientOptions options) { }
        public AssistantsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential) { }
        public AssistantsClient(System.Uri endpoint, Azure.AzureKeyCredential keyCredential, Azure.AI.OpenAI.Assistants.AssistantsClientOptions options) { }
        public AssistantsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential) { }
        public AssistantsClient(System.Uri endpoint, Azure.Core.TokenCredential tokenCredential, Azure.AI.OpenAI.Assistants.AssistantsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.Assistant> CreateAssistant(Azure.AI.OpenAI.Assistants.AssistantCreationOptions assistantCreationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.Assistant>> CreateAssistantAsync(Azure.AI.OpenAI.Assistants.AssistantCreationOptions assistantCreationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage> CreateMessage(string threadId, Azure.AI.OpenAI.Assistants.MessageRole role, string content, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.OpenAI.Assistants.MessageRole role, string content, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> overrideTools = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> overrideTools = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> CreateThread(Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions assistantThreadCreationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> CreateThread(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> CreateThreadAndRun(Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions createAndRunThreadOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> CreateThreadAndRunAsync(Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions createAndRunThreadOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> CreateThreadAsync(Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions assistantThreadCreationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> CreateThreadAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAssistant(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAssistantAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.AssistantFile>> GetAssistantFiles(string assistantId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.AssistantFile>>> GetAssistantFilesAsync(string assistantId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.Assistant>> GetAssistants(int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.Assistant>>> GetAssistantsAsync(int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.OpenAIFile>> GetFiles(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose? purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.OpenAIFile>>> GetFilesAsync(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose? purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.MessageFile>> GetMessageFiles(string threadId, string messageId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.MessageFile>>> GetMessageFilesAsync(string threadId, string messageId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadMessage>> GetMessages(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadMessage>>> GetMessagesAsync(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>> GetRunSteps(Azure.AI.OpenAI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>>> GetRunStepsAsync(Azure.AI.OpenAI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile> LinkAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile>> LinkAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.Assistant> ModifyAssistant(string assistantId, Azure.AI.OpenAI.Assistants.AssistantModificationOptions modificationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.Assistant>> ModifyAssistantAsync(string assistantId, Azure.AI.OpenAI.Assistants.AssistantModificationOptions modificationOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage> ModifyMessage(string threadId, string messageId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage>> ModifyMessageAsync(string threadId, string messageId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> ModifyRun(string threadId, string runId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> ModifyRunAsync(string threadId, string runId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> ModifyThread(string threadId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> ModifyThreadAsync(string threadId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.Assistant> RetrieveAssistant(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.Assistant>> RetrieveAssistantAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile> RetrieveAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile>> RetrieveAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> RetrieveFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> RetrieveFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> RetrieveFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> RetrieveFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage> RetrieveMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage>> RetrieveMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.MessageFile> RetrieveMessageFile(string threadId, string messageId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.MessageFile>> RetrieveMessageFileAsync(string threadId, string messageId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> RetrieveRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> RetrieveRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.RunStep> RetrieveRunStep(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.RunStep>> RetrieveRunStepAsync(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> RetrieveThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> RetrieveThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> SubmitRunToolOutputs(Azure.AI.OpenAI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> SubmitRunToolOutputs(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> SubmitRunToolOutputsAsync(Azure.AI.OpenAI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> SubmitRunToolOutputsAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> UnlinkAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> UnlinkAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> UploadFile(System.BinaryData data, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, string filename = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> UploadFile(string localFilePath, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> UploadFileAsync(System.BinaryData data, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, string filename = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> UploadFileAsync(string localFilePath, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssistantsClientOptions : Azure.Core.ClientOptions
    {
        public AssistantsClientOptions(Azure.AI.OpenAI.Assistants.AssistantsClientOptions.ServiceVersion version = Azure.AI.OpenAI.Assistants.AssistantsClientOptions.ServiceVersion.V2023_11_06_Beta) { }
        public enum ServiceVersion
        {
            V2023_11_06_Beta = 1,
        }
    }
    public static partial class AssistantsModelFactory
    {
        public static Azure.AI.OpenAI.Assistants.Assistant Assistant(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> tools = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.AssistantFile AssistantFile(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string assistantId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.AssistantThread AssistantThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CodeInterpreterImageOutput CodeInterpreterImageOutput(Azure.AI.OpenAI.Assistants.CodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CodeInterpreterImageReference CodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CodeInterpreterLogOutput CodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CodeInterpreterToolCall CodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.CodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.OpenAI.Assistants.FunctionToolCall FunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageFile MessageFile(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string messageId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageFileCitationTextAnnotation MessageFileCitationTextAnnotation(string text, int startIndex, int endIndex, string fileId, string quote) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageFilePathTextAnnotation MessageFilePathTextAnnotation(string text, int startIndex, int endIndex, string fileId) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.OpenAI.Assistants.OpenAIFile OpenAIFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose)) { throw null; }
        public static Azure.AI.OpenAI.Assistants.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RetrievalToolCall RetrievalToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> retrieval = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStep RunStep(string id = null, Azure.AI.OpenAI.Assistants.RunStepType type = default(Azure.AI.OpenAI.Assistants.RunStepType), string assistantId = null, string threadId = null, string runId = null, Azure.AI.OpenAI.Assistants.RunStepStatus status = default(Azure.AI.OpenAI.Assistants.RunStepStatus), Azure.AI.OpenAI.Assistants.RunStepDetails stepDetails = null, Azure.AI.OpenAI.Assistants.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepError RunStepError(Azure.AI.OpenAI.Assistants.RunStepErrorCode code = default(Azure.AI.OpenAI.Assistants.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolCall> toolCalls) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.OpenAI.Assistants.MessageRole role = default(Azure.AI.OpenAI.Assistants.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.MessageContent> contentItems = null, string assistantId = null, string runId = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ThreadRun ThreadRun(string id = null, string threadId = null, string assistantId = null, Azure.AI.OpenAI.Assistants.RunStatus status = default(Azure.AI.OpenAI.Assistants.RunStatus), Azure.AI.OpenAI.Assistants.RequiredAction requiredAction = null, Azure.AI.OpenAI.Assistants.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> tools = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ToolCall ToolCall(string type = null, string id = null) { throw null; }
    }
    public partial class AssistantThread
    {
        internal AssistantThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class AssistantThreadCreationOptions
    {
        public AssistantThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ThreadMessage> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
    }
    public partial class CodeInterpreterImageOutput : Azure.AI.OpenAI.Assistants.CodeInterpreterToolCallOutput
    {
        internal CodeInterpreterImageOutput() { }
        public Azure.AI.OpenAI.Assistants.CodeInterpreterImageReference Image { get { throw null; } }
    }
    public partial class CodeInterpreterImageReference
    {
        internal CodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
    }
    public partial class CodeInterpreterLogOutput : Azure.AI.OpenAI.Assistants.CodeInterpreterToolCallOutput
    {
        internal CodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
    }
    public partial class CodeInterpreterToolCall : Azure.AI.OpenAI.Assistants.ToolCall
    {
        internal CodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.CodeInterpreterToolCallOutput> Outputs { get { throw null; } }
    }
    public abstract partial class CodeInterpreterToolCallOutput
    {
        protected CodeInterpreterToolCallOutput() { }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition
    {
        public CodeInterpreterToolDefinition() { }
    }
    public partial class CreateAndRunThreadOptions
    {
        public CreateAndRunThreadOptions(string assistantId) { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string OverrideInstructions { get { throw null; } set { } }
        public string OverrideModelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> OverrideTools { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions Thread { get { throw null; } set { } }
    }
    public partial class FunctionToolCall : Azure.AI.OpenAI.Assistants.ToolCall
    {
        internal FunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
    }
    public partial class FunctionToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.FunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.FunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.FunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.FunctionToolCall functionToolCall) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.OpenAI.Assistants.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.ListSortOrder left, Azure.AI.OpenAI.Assistants.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.ListSortOrder left, Azure.AI.OpenAI.Assistants.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageContent
    {
        protected MessageContent() { }
    }
    public partial class MessageFile
    {
        internal MessageFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public string MessageId { get { throw null; } }
    }
    public partial class MessageFileCitationTextAnnotation : Azure.AI.OpenAI.Assistants.MessageTextAnnotation
    {
        internal MessageFileCitationTextAnnotation() : base (default(string), default(int), default(int)) { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
    }
    public partial class MessageFilePathTextAnnotation : Azure.AI.OpenAI.Assistants.MessageTextAnnotation
    {
        internal MessageFilePathTextAnnotation() : base (default(string), default(int), default(int)) { }
        public string FileId { get { throw null; } }
    }
    public partial class MessageImageFileContent : Azure.AI.OpenAI.Assistants.MessageContent
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.OpenAI.Assistants.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageRole Assistant { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.MessageRole left, Azure.AI.OpenAI.Assistants.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.MessageRole left, Azure.AI.OpenAI.Assistants.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation
    {
        protected MessageTextAnnotation(string text, int startIndex, int endIndex) { }
        public int EndIndex { get { throw null; } set { } }
        public int StartIndex { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
    }
    public partial class MessageTextContent : Azure.AI.OpenAI.Assistants.MessageContent
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public partial class OpenAIFile
    {
        internal OpenAIFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.OpenAIFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAIFilePurpose : System.IEquatable<Azure.AI.OpenAI.Assistants.OpenAIFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAIFilePurpose(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.OpenAIFilePurpose Assistants { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.OpenAIFilePurpose AssistantsOutput { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.OpenAIFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.OpenAIFilePurpose FineTuneResults { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose left, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.OpenAIFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose left, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose right) { throw null; }
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
    public abstract partial class RequiredAction
    {
        protected RequiredAction() { }
    }
    public partial class RetrievalToolCall : Azure.AI.OpenAI.Assistants.ToolCall
    {
        internal RetrievalToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Retrieval { get { throw null; } }
    }
    public partial class RetrievalToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition
    {
        public RetrievalToolDefinition() { }
    }
    public partial class RunError
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.OpenAI.Assistants.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus Completed { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus Expired { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus Failed { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus Queued { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RunStatus left, Azure.AI.OpenAI.Assistants.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RunStatus left, Azure.AI.OpenAI.Assistants.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunStepStatus Status { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunStepType Type { get { throw null; } }
    }
    public abstract partial class RunStepDetails
    {
        protected RunStepDetails() { }
    }
    public partial class RunStepError
    {
        internal RunStepError() { }
        public Azure.AI.OpenAI.Assistants.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.OpenAI.Assistants.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RunStepErrorCode left, Azure.AI.OpenAI.Assistants.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RunStepErrorCode left, Azure.AI.OpenAI.Assistants.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.OpenAI.Assistants.RunStepDetails
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference MessageCreation { get { throw null; } }
    }
    public partial class RunStepMessageCreationReference
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.OpenAI.Assistants.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RunStepStatus left, Azure.AI.OpenAI.Assistants.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RunStepStatus left, Azure.AI.OpenAI.Assistants.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.OpenAI.Assistants.RunStepDetails
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.ToolCall> ToolCalls { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.OpenAI.Assistants.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.OpenAI.Assistants.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.OpenAI.Assistants.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RunStepType left, Azure.AI.OpenAI.Assistants.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.OpenAI.Assistants.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RunStepType left, Azure.AI.OpenAI.Assistants.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.OpenAI.Assistants.RequiredAction
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.ToolCall> ToolCalls { get { throw null; } }
    }
    public partial class ThreadMessage
    {
        public ThreadMessage(string id, System.DateTimeOffset createdAt, string threadId, Azure.AI.OpenAI.Assistants.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.MessageContent> contentItems, System.Collections.Generic.IEnumerable<string> fileIds) { }
        public string AssistantId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.MessageRole Role { get { throw null; } set { } }
        public string RunId { get { throw null; } set { } }
        public string ThreadId { get { throw null; } set { } }
    }
    public partial class ThreadRun
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileIds { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RequiredAction RequiredAction { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.RunStatus Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
    }
    public abstract partial class ToolCall
    {
        protected ToolCall(string id) { }
        public string Id { get { throw null; } }
    }
    public abstract partial class ToolDefinition
    {
        protected ToolDefinition() { }
    }
    public partial class ToolOutput
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.OpenAI.Assistants.ToolCall toolCall) { }
        public ToolOutput(Azure.AI.OpenAI.Assistants.ToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIOpenAIAssistantsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.Assistants.AssistantsClient, Azure.AI.OpenAI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.Assistants.AssistantsClient, Azure.AI.OpenAI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.OpenAI.Assistants.AssistantsClient, Azure.AI.OpenAI.Assistants.AssistantsClientOptions> AddAssistantsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
