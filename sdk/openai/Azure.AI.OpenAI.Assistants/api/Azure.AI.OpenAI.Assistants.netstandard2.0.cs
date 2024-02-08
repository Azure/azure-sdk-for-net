namespace Azure.AI.OpenAI.Assistants
{
    public partial class Assistant : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.Assistant>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.Assistant>
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
        Azure.AI.OpenAI.Assistants.Assistant System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.Assistant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.Assistant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.Assistant System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.Assistant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.Assistant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.Assistant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>
    {
        public AssistantCreationOptions(string model) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
        Azure.AI.OpenAI.Assistants.AssistantCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.AssistantCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantFile>
    {
        internal AssistantFile() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        Azure.AI.OpenAI.Assistants.AssistantFile System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.AssistantFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> CreateRun(Azure.AI.OpenAI.Assistants.AssistantThread thread, Azure.AI.OpenAI.Assistants.Assistant assistant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> CreateRun(string threadId, Azure.AI.OpenAI.Assistants.CreateRunOptions createRunOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> CreateRunAsync(Azure.AI.OpenAI.Assistants.AssistantThread thread, Azure.AI.OpenAI.Assistants.Assistant assistant, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> CreateRunAsync(string threadId, Azure.AI.OpenAI.Assistants.CreateRunOptions createRunOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.Assistant> GetAssistant(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.Assistant>> GetAssistantAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile> GetAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile>> GetAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.AssistantFile>> GetAssistantFiles(string assistantId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.AssistantFile>>> GetAssistantFilesAsync(string assistantId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.Assistant>> GetAssistants(int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.Assistant>>> GetAssistantsAsync(int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.OpenAIFile>> GetFiles(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose? purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.OpenAIFile>>> GetFilesAsync(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose? purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.MessageFile> GetMessageFile(string threadId, string messageId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.MessageFile>> GetMessageFileAsync(string threadId, string messageId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.MessageFile>> GetMessageFiles(string threadId, string messageId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.MessageFile>>> GetMessageFilesAsync(string threadId, string messageId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadMessage>> GetMessages(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadMessage>>> GetMessagesAsync(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>> GetRunSteps(Azure.AI.OpenAI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>>> GetRunStepsAsync(Azure.AI.OpenAI.Assistants.ThreadRun run, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.PageableList<Azure.AI.OpenAI.Assistants.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.OpenAI.Assistants.ListSortOrder? order = default(Azure.AI.OpenAI.Assistants.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile> LinkAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantFile>> LinkAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> SubmitToolOutputsToRun(Azure.AI.OpenAI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.OpenAI.Assistants.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> UnlinkAssistantFile(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> UnlinkAssistantFileAsync(string assistantId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.Assistant> UpdateAssistant(string assistantId, Azure.AI.OpenAI.Assistants.UpdateAssistantOptions updateAssistantOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.Assistant>> UpdateAssistantAsync(string assistantId, Azure.AI.OpenAI.Assistants.UpdateAssistantOptions updateAssistantOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread> UpdateThread(string threadId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.AssistantThread>> UpdateThreadAsync(string threadId, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> UploadFile(System.BinaryData data, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, string filename = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile> UploadFile(string localFilePath, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> UploadFileAsync(System.BinaryData data, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, string filename = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.OpenAI.Assistants.OpenAIFile>> UploadFileAsync(string localFilePath, Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssistantsClientOptions : Azure.Core.ClientOptions
    {
        public AssistantsClientOptions(Azure.AI.OpenAI.Assistants.AssistantsClientOptions.ServiceVersion version = Azure.AI.OpenAI.Assistants.AssistantsClientOptions.ServiceVersion.V2024_02_15_Preview) { }
        public enum ServiceVersion
        {
            V2024_02_15_Preview = 1,
        }
    }
    public static partial class AssistantsModelFactory
    {
        public static Azure.AI.OpenAI.Assistants.Assistant Assistant(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> tools = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.AssistantCreationOptions AssistantCreationOptions(string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> tools = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.AssistantFile AssistantFile(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string assistantId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.AssistantThread AssistantThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions CreateAndRunThreadOptions(string assistantId = null, Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> overrideTools = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.CreateRunOptions CreateRunOptions(string assistantId = null, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> overrideTools = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageFile MessageFile(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string messageId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, int startIndex, int endIndex, string fileId, string quote) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, int startIndex, int endIndex, string fileId) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageTextAnnotation MessageTextAnnotation(string type = null, string text = null, int startIndex = 0, int endIndex = 0) { throw null; }
        public static Azure.AI.OpenAI.Assistants.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.OpenAI.Assistants.OpenAIFile OpenAIFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.OpenAI.Assistants.OpenAIFilePurpose purpose = default(Azure.AI.OpenAI.Assistants.OpenAIFilePurpose)) { throw null; }
        public static Azure.AI.OpenAI.Assistants.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStep RunStep(string id = null, Azure.AI.OpenAI.Assistants.RunStepType type = default(Azure.AI.OpenAI.Assistants.RunStepType), string assistantId = null, string threadId = null, string runId = null, Azure.AI.OpenAI.Assistants.RunStepStatus status = default(Azure.AI.OpenAI.Assistants.RunStepStatus), Azure.AI.OpenAI.Assistants.RunStepDetails stepDetails = null, Azure.AI.OpenAI.Assistants.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepError RunStepError(Azure.AI.OpenAI.Assistants.RunStepErrorCode code = default(Azure.AI.OpenAI.Assistants.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall RunStepRetrievalToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> retrieval = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ThreadInitializationMessage ThreadInitializationMessage(Azure.AI.OpenAI.Assistants.MessageRole role = default(Azure.AI.OpenAI.Assistants.MessageRole), string content = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.OpenAI.Assistants.MessageRole role = default(Azure.AI.OpenAI.Assistants.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.MessageContent> contentItems = null, string assistantId = null, string runId = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.OpenAI.Assistants.ThreadRun ThreadRun(string id = null, string threadId = null, string assistantId = null, Azure.AI.OpenAI.Assistants.RunStatus status = default(Azure.AI.OpenAI.Assistants.RunStatus), Azure.AI.OpenAI.Assistants.RequiredAction requiredAction = null, Azure.AI.OpenAI.Assistants.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.OpenAI.Assistants.ToolDefinition> tools = null, System.Collections.Generic.IEnumerable<string> fileIds = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
    }
    public partial class AssistantThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThread>
    {
        internal AssistantThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        Azure.AI.OpenAI.Assistants.AssistantThread System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.AssistantThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AssistantThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>
    {
        public AssistantThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAndRunThreadOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>
    {
        public CreateAndRunThreadOptions(string assistantId) { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public string OverrideInstructions { get { throw null; } set { } }
        public string OverrideModelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> OverrideTools { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.AssistantThreadCreationOptions Thread { get { throw null; } set { } }
        Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateAndRunThreadOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateRunOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>
    {
        public CreateRunOptions(string assistantId) { }
        public string AdditionalInstructions { get { throw null; } set { } }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public string OverrideInstructions { get { throw null; } set { } }
        public string OverrideModelName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> OverrideTools { get { throw null; } set { } }
        Azure.AI.OpenAI.Assistants.CreateRunOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.CreateRunOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.CreateRunOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition, Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall functionToolCall, Azure.AI.OpenAI.Assistants.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.OpenAI.Assistants.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageContent>
    {
        protected MessageContent() { }
        Azure.AI.OpenAI.Assistants.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageFile>
    {
        internal MessageFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public string MessageId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageFile System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.OpenAI.Assistants.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text, int startIndex, int endIndex) { }
        public int EndIndex { get { throw null; } }
        public int StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.OpenAI.Assistants.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.OpenAI.Assistants.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string), default(int), default(int)) { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.OpenAI.Assistants.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string), default(int), default(int)) { }
        public string FileId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAIFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.OpenAIFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.OpenAIFile>
    {
        internal OpenAIFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.OpenAIFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        Azure.AI.OpenAI.Assistants.OpenAIFile System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.OpenAIFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.OpenAIFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.OpenAIFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.OpenAIFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.OpenAIFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.OpenAIFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredAction>
    {
        protected RequiredAction() { }
        Azure.AI.OpenAI.Assistants.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.OpenAI.Assistants.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RetrievalToolDefinition : Azure.AI.OpenAI.Assistants.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>
    {
        public RetrievalToolDefinition() { }
        Azure.AI.OpenAI.Assistants.RetrievalToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RetrievalToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RetrievalToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStep>
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
        Azure.AI.OpenAI.Assistants.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.OpenAI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepDetails>
    {
        protected RunStepDetails() { }
        Azure.AI.OpenAI.Assistants.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.OpenAI.Assistants.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RunStepFunctionToolCall : Azure.AI.OpenAI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.OpenAI.Assistants.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepRetrievalToolCall : Azure.AI.OpenAI.Assistants.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>
    {
        internal RunStepRetrievalToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Retrieval { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepRetrievalToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.OpenAI.Assistants.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.RunStepToolCall> ToolCalls { get { throw null; } }
        Azure.AI.OpenAI.Assistants.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SubmitToolOutputsAction : Azure.AI.OpenAI.Assistants.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.RequiredToolCall> ToolCalls { get { throw null; } }
        Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadInitializationMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>
    {
        public ThreadInitializationMessage(Azure.AI.OpenAI.Assistants.MessageRole role, string content) { }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.OpenAI.Assistants.MessageRole Role { get { throw null; } }
        Azure.AI.OpenAI.Assistants.ThreadInitializationMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.ThreadInitializationMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadInitializationMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadMessage>
    {
        internal ThreadMessage() { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.OpenAI.Assistants.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> FileIds { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.OpenAI.Assistants.MessageRole Role { get { throw null; } }
        public string RunId { get { throw null; } }
        public string ThreadId { get { throw null; } }
        Azure.AI.OpenAI.Assistants.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadRun>
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
        Azure.AI.OpenAI.Assistants.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolDefinition>
    {
        protected ToolDefinition() { }
        Azure.AI.OpenAI.Assistants.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.OpenAI.Assistants.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.OpenAI.Assistants.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        Azure.AI.OpenAI.Assistants.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAssistantOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>
    {
        public UpdateAssistantOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.OpenAI.Assistants.ToolDefinition> Tools { get { throw null; } }
        Azure.AI.OpenAI.Assistants.UpdateAssistantOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.OpenAI.Assistants.UpdateAssistantOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.OpenAI.Assistants.UpdateAssistantOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
