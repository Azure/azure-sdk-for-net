namespace Azure.AI.Projects.Agents
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2APreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>
    {
        public A2APreviewTool() { }
        public A2APreviewTool(System.Uri baseUri) { }
        public System.Uri AgentCardUri { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.A2APreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.A2APreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentAdministrationClient
    {
        protected AgentAdministrationClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public AgentAdministrationClient(Azure.AI.Projects.Agents.AgentAdministrationClientSettings settings) { }
        public AgentAdministrationClient(System.Uri endpoint, Azure.AI.Projects.Agents.AgentAdministrationClientOptions options) { }
        public AgentAdministrationClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public AgentAdministrationClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.Agents.AgentAdministrationClientOptions options = null) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateAgent(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentAsync(System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentFromManifest(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentFromManifestAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> CreateAgentVersion(string agentName, Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions options, string foundryFeatures = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersion(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> CreateAgentVersionAsync(string agentName, Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions options = null, string foundryFeatures = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionAsync(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> CreateAgentVersionFromCode(string agentName, string filePath, Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> CreateAgentVersionFromCodeAsync(string agentName, string filePath, Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersionFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession> CreateSession(string agentName, Azure.AI.Projects.Agents.VersionIndicator versionIndicator, string agentSessionId = null, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession>> CreateSessionAsync(string agentName, Azure.AI.Projects.Agents.VersionIndicator versionIndicator, string agentSessionId = null, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, bool? force, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, bool? force, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, bool? force, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, bool? force, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, bool? force, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, bool? force, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, bool? force, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, bool? force, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteSession(string agentName, string sessionId, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSessionAsync(string agentName, string sessionId, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.BinaryData DownloadAgentCode(string agentName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> DownloadAgentCodeAsync(string agentName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentOptimizationJobs GetAgentOptimizationJobs() { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgents(Azure.AI.Projects.Agents.ProjectsAgentKind? kind = default(Azure.AI.Projects.Agents.ProjectsAgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgentsAsync(Azure.AI.Projects.Agents.ProjectsAgentKind? kind = default(Azure.AI.Projects.Agents.ProjectsAgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentSessionFiles GetAgentSessionFiles() { throw null; }
        public virtual Azure.AI.Projects.Agents.ProjectAgentSkills GetAgentSkills() { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentToolboxes GetAgentToolboxes() { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> GetAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersions(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSession(string agentName, string sessionId, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession>> GetSessionAsync(string agentName, string sessionId, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionLogEvent> GetSessionLogStream(string agentName, string agentVersion, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionLogEvent>> GetSessionLogStreamAsync(string agentName, string agentVersion, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSessions(string agentName, string userIsolationKey = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSessionsAsync(string agentName, string userIsolationKey = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> PatchAgentObject(string agentName, Azure.AI.Projects.Agents.PatchAgentOptions patchAgentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> PatchAgentObjectAsync(string agentName, Azure.AI.Projects.Agents.PatchAgentOptions patchAgentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StopSession(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopSessionAsync(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgent(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentAsync(string agentName, System.ClientModel.BinaryContent content, string foundryFeatures = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgentFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class AgentAdministrationClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AgentAdministrationClientOptions(Azure.AI.Projects.Agents.AgentAdministrationClientOptions.ServiceVersion version = Azure.AI.Projects.Agents.AgentAdministrationClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AgentAdministrationClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AgentAdministrationClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentAdministrationClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AgentAdministrationSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AgentAdministrationSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentAdministrationClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public abstract partial class AgentBlueprintReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentBlueprintReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentBlueprintReference>
    {
        internal AgentBlueprintReference() { }
        protected virtual Azure.AI.Projects.Agents.AgentBlueprintReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentBlueprintReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentBlueprintReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentBlueprintReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentBlueprintReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentBlueprintReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentBlueprintReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentBlueprintReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentBlueprintReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentCard : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCard>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCard>
    {
        public AgentCard(string version, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentCardSkill> skills) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentCardSkill> Skills { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentCard JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentCard PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentCard System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCard>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCard>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentCard System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCard>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCard>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCard>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentCardSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCardSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCardSkill>
    {
        public AgentCardSkill(string id, string name) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Examples { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentCardSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentCardSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentCardSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCardSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentCardSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentCardSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCardSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCardSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentCardSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum AgentDefinitionOptInKeys
    {
        HostedAgentsV1Preview = 0,
        WorkflowAgentsV1Preview = 1,
        AgentEndpointV1Preview = 2,
        CodeAgentsV1Preview = 3,
        ExternalAgentsV1Preview = 4,
    }
    public abstract partial class AgentEndpointAuthorizationScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>
    {
        internal AgentEndpointAuthorizationScheme() { }
        protected virtual Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEndpointConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>
    {
        public AgentEndpointConfiguration() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme> AuthorizationSchemes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentEndpointProtocol> Protocols { get { throw null; } }
        public Azure.AI.Projects.Agents.VersionSelector VersionSelector { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentEndpointConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentEndpointConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentEndpointConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentEndpointConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentEndpointConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentEndpointProtocol : System.IEquatable<Azure.AI.Projects.Agents.AgentEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentEndpointProtocol(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol A2a { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol Activity { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol Invocations { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol InvocationsWs { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol Mcp { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentEndpointProtocol Responses { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentEndpointProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentEndpointProtocol left, Azure.AI.Projects.Agents.AgentEndpointProtocol right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentEndpointProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentEndpointProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentEndpointProtocol left, Azure.AI.Projects.Agents.AgentEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentifier>
    {
        public AgentIdentifier(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentIdentifier JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentIdentifier PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentIdentifier System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentity>
    {
        internal AgentIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentIdentity System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentListOrder : System.IEquatable<Azure.AI.Projects.Agents.AgentListOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentListOrder(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentListOrder Ascending { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentListOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentListOrder other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentListOrder left, Azure.AI.Projects.Agents.AgentListOrder right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentListOrder (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentListOrder? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentListOrder left, Azure.AI.Projects.Agents.AgentListOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentManifestOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>
    {
        internal AgentManifestOptions() { }
        public string Description { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentManifestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.AgentManifestOptions agentManifestOptions) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentManifestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentManifestOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentManifestOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentManifestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobs
    {
        protected AgentOptimizationJobs() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob> Cancel(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob>> CancelAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob> Create(Azure.AI.Projects.Agents.OptimizationJobInputs inputs, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob>> CreateAsync(Azure.AI.Projects.Agents.OptimizationJobInputs inputs, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.OptimizationJob> GetAll(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.JobStatus? status = default(Azure.AI.Projects.Agents.JobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.OptimizationJob> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.JobStatus? status = default(Azure.AI.Projects.Agents.JobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.OptimizationJob>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateMetadata> GetCandidate(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateMetadata>> GetCandidateAsync(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateDeployConfig> GetCandidateConfig(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateDeployConfig>> GetCandidateConfigAsync(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetCandidateFile(string jobId, string candidateId, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetCandidateFileAsync(string jobId, string candidateId, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateResults> GetCandidateResults(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.CandidateResults>> GetCandidateResultsAsync(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.OptimizationCandidate> GetCandidates(string jobId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.OptimizationCandidate> GetCandidatesAsync(string jobId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.PromoteCandidateResponse> PromoteCandidate(string jobId, string candidateId, Azure.AI.Projects.Agents.PromoteCandidateRequest candidateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.PromoteCandidateResponse>> PromoteCandidateAsync(string jobId, string candidateId, Azure.AI.Projects.Agents.PromoteCandidateRequest candidateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentSessionFiles
    {
        protected AgentSessionFiles() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult DeleteSessionFile(string agentName, string sessionId, string path, bool? recursive = default(bool?), string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSessionFileAsync(string agentName, string sessionId, string path, bool? recursive = default(bool?), string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.BinaryData DownloadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> DownloadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.SessionDirectoryEntry> GetSessionFiles(string agentName, string agentSessionId, string sessionStoragePath = null, string userIsolationKey = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.SessionDirectoryEntry> GetSessionFilesAsync(string agentName, string agentSessionId, string sessionStoragePath = null, string userIsolationKey = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResponse> UploadSessionFile(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResponse>> UploadSessionFileAsync(string agentName, string sessionId, string sessionStoragePath, string localPath, string userIsolationKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentSessionStatus : System.IEquatable<Azure.AI.Projects.Agents.AgentSessionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentSessionStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Active { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Creating { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Deleted { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Deleting { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Expired { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Idle { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentSessionStatus Updating { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentSessionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentSessionStatus left, Azure.AI.Projects.Agents.AgentSessionStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentSessionStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentSessionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentSessionStatus left, Azure.AI.Projects.Agents.AgentSessionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentsSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentsSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentsSkill>
    {
        internal AgentsSkill() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string DefaultVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string LatestVersion { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentsSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentsSkill (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentsSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentsSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentsSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentsSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentsSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentsSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentsSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentsSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentToolboxes
    {
        protected AgentToolboxes() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateToolboxVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion> CreateToolboxVersion(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProjectsAgentTool> tools, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateToolboxVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion>> CreateToolboxVersionAsync(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProjectsAgentTool> tools, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteToolbox(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteToolbox(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteToolboxAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteToolboxAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteToolboxVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteToolboxVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteToolboxVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteToolboxVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetToolbox(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord> GetToolbox(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetToolboxAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord>> GetToolboxAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ToolboxRecord> GetToolboxes(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetToolboxes(int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ToolboxRecord> GetToolboxesAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetToolboxesAsync(int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult GetToolboxVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion> GetToolboxVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetToolboxVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion>> GetToolboxVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ToolboxVersion> GetToolboxVersions(string toolboxName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetToolboxVersions(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ToolboxVersion> GetToolboxVersionsAsync(string toolboxName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetToolboxVersionsAsync(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateToolbox(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord> UpdateToolbox(string toolboxName, string defaultVersion, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateToolboxAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord>> UpdateToolboxAsync(string toolboxName, string defaultVersion, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public enum AgentVersionStatus
    {
        Creating = 0,
        Active = 1,
        Failed = 2,
        Deleting = 3,
        Deleted = 4,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AzureAIProjectsAgentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsAgentsContext() { }
        public static Azure.AI.Projects.Agents.AzureAIProjectsAgentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Projects.Agents.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Projects.Agents.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AzureAISearchQueryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AzureAISearchQueryType left, Azure.AI.Projects.Agents.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AzureAISearchQueryType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AzureAISearchQueryType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AzureAISearchQueryType left, Azure.AI.Projects.Agents.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>
    {
        public AzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureAISearchToolOptions Options { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>
    {
        public AzureAISearchToolIndex() { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchToolIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchToolIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>
    {
        public AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AzureAISearchToolIndex> indexes) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AzureAISearchToolIndex> Indexes { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureAISearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Projects.Agents.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Projects.Agents.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition(Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction function, Azure.AI.Projects.Agents.AzureFunctionBinding inputBinding, Azure.AI.Projects.Agents.AzureFunctionBinding outputBinding) { }
        public Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>
    {
        public AzureFunctionTool(Azure.AI.Projects.Agents.AzureFunctionDefinition azureFunction) { }
        public Azure.AI.Projects.Agents.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>
    {
        public BingCustomSearchPreviewTool(Azure.AI.Projects.Agents.BingCustomSearchToolOptions bingCustomSearchPreview) { }
        public Azure.AI.Projects.Agents.BingCustomSearchToolOptions BingCustomSearchPreview { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BingCustomSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>
    {
        public BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingCustomSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingCustomSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingCustomSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingCustomSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public string BingUserInterfaceLanguage { get { throw null; } set { } }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>
    {
        public BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BingGroundingSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>
    {
        public BingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions searchToolOptions) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.BingGroundingSearchToolOptions SearchToolOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BingGroundingTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BingGroundingTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BingGroundingTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BingGroundingTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BotServiceAuthorizationScheme : Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>
    {
        public BotServiceAuthorizationScheme() { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BotServiceAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BotServiceAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BotServiceRbacAuthorizationScheme : Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>
    {
        public BotServiceRbacAuthorizationScheme() { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>
    {
        public BrowserAutomationPreviewTool(Azure.AI.Projects.Agents.BrowserAutomationToolOptions toolParameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        public Azure.AI.Projects.Agents.BrowserAutomationToolOptions ToolParameters { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>
    {
        public BrowserAutomationToolOptions(Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters toolConnectionParameters) { }
        public Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters ToolConnectionParameters { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.BrowserAutomationToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CandidateDeployConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateDeployConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateDeployConfig>
    {
        internal CandidateDeployConfig() { }
        public string Instructions { get { throw null; } }
        public string Model { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Skills { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Tools { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CandidateDeployConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.CandidateDeployConfig (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.CandidateDeployConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CandidateDeployConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateDeployConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateDeployConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CandidateDeployConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateDeployConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateDeployConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateDeployConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CandidateFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateFileInfo>
    {
        internal CandidateFileInfo() { }
        public string Path { get { throw null; } }
        public long SizeBytes { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CandidateFileInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.CandidateFileInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CandidateFileInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CandidateFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CandidateMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateMetadata>
    {
        internal CandidateMetadata() { }
        public string CandidateId { get { throw null; } }
        public string CandidateName { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.CandidateFileInfo> Files { get { throw null; } }
        public bool HasResults { get { throw null; } }
        public string JobId { get { throw null; } }
        public Azure.AI.Projects.Agents.PromotionInfo Promotion { get { throw null; } }
        public double? Score { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CandidateMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.CandidateMetadata (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.CandidateMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CandidateMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CandidateMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CandidateResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateResults>
    {
        internal CandidateResults() { }
        public string CandidateId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.OptimizationTaskResult> Results { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CandidateResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.CandidateResults (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.CandidateResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CandidateResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CandidateResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CandidateResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CandidateResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputDefinition) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.StructuredOutputDefinition OutputDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Projects.Agents.AgentAdministrationClient GetProjectAgentsClient(this System.ClientModel.Primitives.ClientConnectionProvider connectionProvider, System.Uri endpoint = null, Azure.AI.Projects.Agents.AgentAdministrationClientOptions options = null) { throw null; }
        public sealed partial class <G>$EE9D7A1C67932FB454531401B8375DE4
        {
            internal <G>$EE9D7A1C67932FB454531401B8375DE4() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$781747A4149937EE6CD40CB5B8268DAD")]
            public Azure.AI.Projects.Agents.AgentAdministrationClient GetProjectAgentsClient(System.Uri endpoint = null, Azure.AI.Projects.Agents.AgentAdministrationClientOptions options = null) { throw null; }
            public static partial class <M>$781747A4149937EE6CD40CB5B8268DAD
            {
                public static void <Extension>$(System.ClientModel.Primitives.ClientConnectionProvider connectionProvider) { }
            }
        }
    }
    public partial class CodeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeConfiguration>
    {
        public CodeConfiguration(string runtime, System.Collections.Generic.IEnumerable<string> entryPoint, Azure.AI.Projects.Agents.CodeDependencyResolution dependencyResolution) { }
        public string ContentHash { get { throw null; } }
        public Azure.AI.Projects.Agents.CodeDependencyResolution DependencyResolution { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> EntryPoint { get { throw null; } }
        public string Runtime { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.CodeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.CodeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CodeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CodeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CodeDependencyResolution : System.IEquatable<Azure.AI.Projects.Agents.CodeDependencyResolution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CodeDependencyResolution(string value) { throw null; }
        public static Azure.AI.Projects.Agents.CodeDependencyResolution Bundled { get { throw null; } }
        public static Azure.AI.Projects.Agents.CodeDependencyResolution RemoteBuild { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.CodeDependencyResolution other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.CodeDependencyResolution left, Azure.AI.Projects.Agents.CodeDependencyResolution right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.CodeDependencyResolution (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.CodeDependencyResolution? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.CodeDependencyResolution left, Azure.AI.Projects.Agents.CodeDependencyResolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerConfiguration>
    {
        public ContainerConfiguration(string image) { }
        public string Image { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ContainerConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ContainerConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ContainerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ContainerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>
    {
        public ContentFilterConfiguration(string raiPolicyName) { }
        public string RaiPolicyName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ContentFilterConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ContentFilterConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ContentFilterConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ContentFilterConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentFromCodeOptions
    {
        public CreateAgentFromCodeOptions(Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata metadata, System.BinaryData code) { }
        public System.BinaryData Code { get { throw null; } }
        public Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata Metadata { get { throw null; } }
    }
    public partial class CreateAgentVersionFromCodeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>
    {
        public CreateAgentVersionFromCodeMetadata(Azure.AI.Projects.Agents.HostedAgentDefinition definition) { }
        public Azure.AI.Projects.Agents.HostedAgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentVersionFromManifestRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>
    {
        public CreateAgentVersionFromManifestRequest(string manifestId, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues) { }
        public string Description { get { throw null; } set { } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class DatasetInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetInfo>
    {
        internal DatasetInfo() { }
        public bool IsInline { get { throw null; } }
        public string Name { get { throw null; } }
        public int TaskCount { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.DatasetInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.DatasetInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.DatasetInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.DatasetInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class DatasetRef : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetRef>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetRef>
    {
        public DatasetRef(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.DatasetRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.DatasetRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.DatasetRef System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DatasetRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.DatasetRef System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DatasetRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeclarativeAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>
    {
        public DeclarativeAgentDefinition(string model) { }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public OpenAI.Responses.ResponseTextOptions TextOptions { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.DeclarativeAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.DeclarativeAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class DeleteSkillResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillResponse>
    {
        internal DeleteSkillResponse() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.DeleteSkillResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.DeleteSkillResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.DeleteSkillResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.DeleteSkillResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.DeleteSkillResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class DeleteSkillVersionResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>
    {
        internal DeleteSkillVersionResponse() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.DeleteSkillVersionResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.DeleteSkillVersionResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.DeleteSkillVersionResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.DeleteSkillVersionResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.DeleteSkillVersionResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraAuthorizationScheme : Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>
    {
        public EntraAuthorizationScheme() { }
        public Azure.AI.Projects.Agents.IsolationKeySource IsolationKeySource { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.EntraAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.EntraAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraIsolationKeySource : Azure.AI.Projects.Agents.IsolationKeySource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>
    {
        public EntraIsolationKeySource() { }
        protected override Azure.AI.Projects.Agents.IsolationKeySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.IsolationKeySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.EntraIsolationKeySource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.EntraIsolationKeySource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraIsolationKeySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationLevel : System.IEquatable<Azure.AI.Projects.Agents.EvaluationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationLevel(string value) { throw null; }
        public static Azure.AI.Projects.Agents.EvaluationLevel Conversation { get { throw null; } }
        public static Azure.AI.Projects.Agents.EvaluationLevel Turn { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.EvaluationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.EvaluationLevel left, Azure.AI.Projects.Agents.EvaluationLevel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.EvaluationLevel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.EvaluationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.EvaluationLevel left, Azure.AI.Projects.Agents.EvaluationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExportedDataTypes : System.IEquatable<Azure.AI.Projects.Agents.ExportedDataTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExportedDataTypes(string value) { throw null; }
        public static Azure.AI.Projects.Agents.ExportedDataTypes ContainerOtel { get { throw null; } }
        public static Azure.AI.Projects.Agents.ExportedDataTypes ContainerStdoutStderr { get { throw null; } }
        public static Azure.AI.Projects.Agents.ExportedDataTypes Metrics { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.ExportedDataTypes other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.ExportedDataTypes left, Azure.AI.Projects.Agents.ExportedDataTypes right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ExportedDataTypes (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ExportedDataTypes? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.ExportedDataTypes left, Azure.AI.Projects.Agents.ExportedDataTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ExternalAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>
    {
        public ExternalAgentDefinition() { }
        public string OtelAgentId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ExternalAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ExternalAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ExternalAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>
    {
        public FabricDataAgentToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.FabricDataAgentToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.FabricDataAgentToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FabricDataAgentToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FabricDataAgentToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricDataAgentToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class FabricIQPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>
    {
        public FabricIQPreviewTool(string projectConnectionId) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.BinaryData RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUrl { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FabricIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FabricIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FixedRatioVersionSelectionRule : Azure.AI.Projects.Agents.VersionSelectionRule, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>
    {
        public FixedRatioVersionSelectionRule(string agentVersion, int trafficPercentage) { }
        public int TrafficPercentage { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VersionSelectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VersionSelectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum FoundryFeaturesOptInKeys
    {
        EvaluationsV1Preview = 0,
        SchedulesV1Preview = 1,
        RedTeamsV1Preview = 2,
        InsightsV1Preview = 3,
        MemoryStoresV1Preview = 4,
        RoutinesV1Preview = 5,
        ToolboxesV1Preview = 6,
        SkillsV1Preview = 7,
        DataGenerationJobsV1Preview = 8,
        ModelsV1Preview = 9,
        AgentsOptimizationV1Preview = 10,
    }
    public partial class HeaderIsolationKeySource : Azure.AI.Projects.Agents.IsolationKeySource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>
    {
        public HeaderIsolationKeySource() { }
        protected override Azure.AI.Projects.Agents.IsolationKeySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.IsolationKeySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.HeaderIsolationKeySource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.HeaderIsolationKeySource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderIsolationKeySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HeaderTelemetryEndpointAuth : Azure.AI.Projects.Agents.TelemetryEndpointAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>
    {
        public HeaderTelemetryEndpointAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelemetryEndpointAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelemetryEndpointAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class HostedAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>
    {
        public HostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> versions, string cpu, string memory) { }
        public HostedAgentDefinition(string cpu, string memory) { }
        public Azure.AI.Projects.Agents.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public string Cpu { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string Image { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ProjectsAgentTool> Tools { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ProtocolVersionRecord> Versions { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.HostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.HostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.HostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class IsolationKeySource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.IsolationKeySource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.IsolationKeySource>
    {
        internal IsolationKeySource() { }
        protected virtual Azure.AI.Projects.Agents.IsolationKeySource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.IsolationKeySource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.IsolationKeySource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.IsolationKeySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.IsolationKeySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.IsolationKeySource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.IsolationKeySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.IsolationKeySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.IsolationKeySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.AI.Projects.Agents.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.JobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.JobStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.JobStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.Agents.JobStatus Queued { get { throw null; } }
        public static Azure.AI.Projects.Agents.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.JobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.JobStatus left, Azure.AI.Projects.Agents.JobStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.JobStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.JobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.JobStatus left, Azure.AI.Projects.Agents.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedAgentIdentityBlueprintReference : Azure.AI.Projects.Agents.AgentBlueprintReference, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>
    {
        public ManagedAgentIdentityBlueprintReference(string blueprintId) { }
        public string BlueprintId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentBlueprintReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentBlueprintReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class McpToolExtensions
    {
        public static string get_ProjectConnectionId(OpenAI.Responses.McpTool mcpTool) { throw null; }
        public static void set_ProjectConnectionId(OpenAI.Responses.McpTool mcpTool, string value) { }
        public sealed partial class <G>$35DCA4819B43CF3F6CAB343048615A7E
        {
            internal <G>$35DCA4819B43CF3F6CAB343048615A7E() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$057BAEB40536DD92FB57E20F2D1CDCDE")]
            public string ProjectConnectionId { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$057BAEB40536DD92FB57E20F2D1CDCDE")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$057BAEB40536DD92FB57E20F2D1CDCDE")] set { } }
            public static partial class <M>$057BAEB40536DD92FB57E20F2D1CDCDE
            {
                public static void <Extension>$(OpenAI.Responses.McpTool mcpTool) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemorySearchPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>
    {
        public MemorySearchPreviewTool(string memoryStoreName, string scope) { }
        public string Description { get { throw null; } set { } }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.MemorySearchToolOptions SearchOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        public int? UpdateDelayInSecs { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MemorySearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MemorySearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MemorySearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>
    {
        public MemorySearchToolOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.MemorySearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.MemorySearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MemorySearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MemorySearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MemorySearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class MicrosoftFabricPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>
    {
        public MicrosoftFabricPreviewTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions toolOptions) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        public Azure.AI.Projects.Agents.FabricDataAgentToolOptions ToolOptions { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIAnonymousAuthenticationDetails : Azure.AI.Projects.Agents.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>
    {
        public OpenAPIAnonymousAuthenticationDetails() { }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthenticationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>
    {
        internal OpenApiAuthenticationDetails() { }
        protected virtual Azure.AI.Projects.Agents.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenApiAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenApiAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData specificationBytes, Azure.AI.Projects.Agents.OpenApiAuthenticationDetails authentication) { }
        public OpenApiFunctionDefinition(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> spec, Azure.AI.Projects.Agents.OpenApiAuthenticationDetails authenticationDetails) { }
        public Azure.AI.Projects.Agents.OpenApiAuthenticationDetails AuthenticationDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.Agents.OpenAPIFunctionEntry> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Spec { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OpenApiFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenApiFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIFunctionEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>
    {
        public OpenAPIFunctionEntry(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIFunctionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIFunctionEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIFunctionEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIFunctionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIManagedAuthenticationDetails : Azure.AI.Projects.Agents.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>
    {
        public OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme securityScheme) { }
        public Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>
    {
        public OpenAPIManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionAuthenticationDetails : Azure.AI.Projects.Agents.OpenApiAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>
    {
        public OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OpenApiAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>
    {
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPITool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>
    {
        public OpenAPITool(Azure.AI.Projects.Agents.OpenApiFunctionDefinition functionDefinition) { }
        public Azure.AI.Projects.Agents.OpenApiFunctionDefinition FunctionDefinition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenAPITool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenAPITool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenAPITool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenAPITool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationAgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>
    {
        internal OptimizationAgentDefinition() { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string Model { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Skills { get { throw null; } }
        public string SystemPrompt { get { throw null; } }
        public System.Collections.Generic.IList<System.Collections.Generic.IDictionary<string, System.BinaryData>> Tools { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationCandidate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationCandidate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationCandidate>
    {
        internal OptimizationCandidate() { }
        public double AvgScore { get { throw null; } }
        public double AvgTokens { get { throw null; } }
        public string CandidateId { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationAgentDefinition Config { get { throw null; } }
        public string EvalId { get { throw null; } }
        public string EvalRunId { get { throw null; } }
        public bool IsParetoOptimal { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Mutations { get { throw null; } }
        public string Name { get { throw null; } }
        public double PassRate { get { throw null; } }
        public Azure.AI.Projects.Agents.PromotionInfo Promotion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.OptimizationTaskResult> TaskScores { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationCandidate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationCandidate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationCandidate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationCandidate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationCandidate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationCandidate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationCandidate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationCandidate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationCandidate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJob>
    {
        internal OptimizationJob() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Agents.DatasetInfo Dataset { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationJobInputs Inputs { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationJobProgress Progress { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationJobResult Result { get { throw null; } }
        public Azure.AI.Projects.Agents.JobStatus Status { get { throw null; } }
        public System.DateTimeOffset? UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.OptimizationJob (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.OptimizationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationJobInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobInputs>
    {
        public OptimizationJobInputs(Azure.AI.Projects.Agents.AgentIdentifier agent, Azure.AI.Projects.Agents.DatasetRef trainDatasetReference) { }
        public Azure.AI.Projects.Agents.AgentIdentifier Agent { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Evaluators { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationOptions Options { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.DatasetRef TrainDatasetReference { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.DatasetRef ValidationDatasetReference { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.OptimizationJobInputs optimizationJobInputs) { throw null; }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationJobProgress : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobProgress>
    {
        internal OptimizationJobProgress() { }
        public double BestScore { get { throw null; } }
        public int CurrentIteration { get { throw null; } }
        public double ElapsedSeconds { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobProgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobProgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationJobProgress System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationJobProgress System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobResult>
    {
        internal OptimizationJobResult() { }
        public bool? AllTargetAttributesFailed { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationCandidate Baseline { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationCandidate Best { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.OptimizationCandidate> Candidates { get { throw null; } }
        public Azure.AI.Projects.Agents.OptimizationOptions Options { get { throw null; } }
        public System.Collections.Generic.IList<string> Warnings { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationJobResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationOptions>
    {
        public OptimizationOptions() { }
        public string EvalModel { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.EvaluationLevel? EvaluationLevel { get { throw null; } set { } }
        public int? MaxIterations { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> OptimizationConfig { get { throw null; } }
        public string OptimizationModel { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OptimizationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizationTaskResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationTaskResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationTaskResult>
    {
        internal OptimizationTaskResult() { }
        public double CompositeScore { get { throw null; } }
        public System.TimeSpan DurationSeconds { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public bool Passed { get { throw null; } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Rationales { get { throw null; } }
        public string Response { get { throw null; } }
        public string RunId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> Scores { get { throw null; } }
        public string TaskName { get { throw null; } }
        public long Tokens { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.OptimizationTaskResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationTaskResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationTaskResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationTaskResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationTaskResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationTaskResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationTaskResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationTaskResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationTaskResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : Azure.AI.Projects.Agents.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes, string endpoint, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol) { }
        public string Endpoint { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelemetryTransportProtocol Protocol { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class PatchAgentOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PatchAgentOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PatchAgentOptions>
    {
        public PatchAgentOptions() { }
        public Azure.AI.Projects.Agents.AgentCard AgentCard { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentEndpointConfiguration AgentEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.PatchAgentOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.PatchAgentOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PatchAgentOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PatchAgentOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PatchAgentOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PatchAgentOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PatchAgentOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PatchAgentOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PatchAgentOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectAgentSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectAgentSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectAgentSession>
    {
        internal ProjectAgentSession() { }
        public string AgentSessionId { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset ExpiresAt { get { throw null; } }
        public System.DateTimeOffset LastAccessedAt { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentSessionStatus Status { get { throw null; } }
        public Azure.AI.Projects.Agents.VersionIndicator VersionIndicator { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ProjectAgentSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.ProjectAgentSession (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectAgentSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectAgentSession System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectAgentSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectAgentSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectAgentSession System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectAgentSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectAgentSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectAgentSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectAgentSkills
    {
        protected ProjectAgentSkills() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion> CreateSkillVersion(string name, Azure.AI.Projects.Agents.SkillInlineContent inlineContent = null, bool? @default = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateSkillVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion>> CreateSkillVersionAsync(string name, Azure.AI.Projects.Agents.SkillInlineContent inlineContent = null, bool? @default = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateSkillVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateSkillVersionFromFiles(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> CreateSkillVersionFromFiles(string name, string directoryPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateSkillVersionFromFilesAsync(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> CreateSkillVersionFromFilesAsync(string name, string directoryPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteSkill(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.DeleteSkillResponse> DeleteSkill(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSkillAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.DeleteSkillResponse>> DeleteSkillAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteSkillVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.DeleteSkillVersionResponse> DeleteSkillVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSkillVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.DeleteSkillVersionResponse>> DeleteSkillVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkill(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> GetSkill(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> GetSkillAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkillContent(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public System.BinaryData GetSkillContent(string skillName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetSkillContent(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillContentAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> GetSkillContentAsync(string skillName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetSkillContentAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentsSkill> GetSkills(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentsSkill> GetSkillsAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkillVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion> GetSkillVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion>> GetSkillVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkillVersionContent(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetSkillVersionContent(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillVersionContentAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetSkillVersionContentAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.SkillVersion> GetSkillVersions(string name, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetSkillVersions(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.SkillVersion> GetSkillVersionsAsync(string name, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetSkillVersionsAsync(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateSkill(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> UpdateSkill(string name, string defaultVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateSkillAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> UpdateSkillAsync(string name, string defaultVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class ProjectsAgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>
    {
        internal ProjectsAgentDefinition() { }
        public Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration { get { throw null; } set { } }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition CreateHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration) { throw null; }
        public static Azure.AI.Projects.Agents.DeclarativeAgentDefinition CreatePromptAgentDefinition(string model) { throw null; }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectsAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectsAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectsAgentKind : System.IEquatable<Azure.AI.Projects.Agents.ProjectsAgentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectsAgentKind(string value) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentKind External { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentKind Hosted { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentKind Prompt { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.ProjectsAgentKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.ProjectsAgentKind left, Azure.AI.Projects.Agents.ProjectsAgentKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ProjectsAgentKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ProjectsAgentKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.ProjectsAgentKind left, Azure.AI.Projects.Agents.ProjectsAgentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectsAgentProtocol : System.IEquatable<Azure.AI.Projects.Agents.ProjectsAgentProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectsAgentProtocol(string value) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol A2a { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol ActivityProtocol { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol Invocations { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol InvocationsWs { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol Mcp { get { throw null; } }
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol Responses { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.ProjectsAgentProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.ProjectsAgentProtocol left, Azure.AI.Projects.Agents.ProjectsAgentProtocol right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ProjectsAgentProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ProjectsAgentProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.ProjectsAgentProtocol left, Azure.AI.Projects.Agents.ProjectsAgentProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectsAgentRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>
    {
        internal ProjectsAgentRecord() { }
        public Azure.AI.Projects.Agents.AgentCard AgentCard { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentEndpointConfiguration AgentEndpoint { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity Blueprint { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentBlueprintReference BlueprintReference { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity InstanceIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.ProjectsAgentVersion GetLatestVersion() { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.ProjectsAgentRecord (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectsAgentRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectsAgentRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public static partial class ProjectsAgentsModelFactory
    {
        public static Azure.AI.Projects.Agents.A2APreviewTool A2APreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.A2APreviewTool A2APreviewTool(System.Uri baseUri, string agentCardPath, string projectConnectionId) { throw null; }
        public static Azure.AI.Projects.Agents.AgentBlueprintReference AgentBlueprintReference(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentCard AgentCard(string version = null, string description = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentCardSkill> skills = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentCardSkill AgentCardSkill(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<string> tags = null, System.Collections.Generic.IEnumerable<string> examples = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme AgentEndpointAuthorizationScheme(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentEndpointConfiguration AgentEndpointConfiguration(Azure.AI.Projects.Agents.VersionSelector versionSelector = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentEndpointProtocol> protocols = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme> authorizationSchemes = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentIdentifier AgentIdentifier(string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentIdentity AgentIdentity(string principalId = null, string clientId = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentManifestOptions AgentManifestOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentsSkill AgentsSkill(string id = null, string name = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string defaultVersion = null, string latestVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchTool AzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchTool AzureAISearchTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchToolIndex AzureAISearchToolIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Projects.Agents.AzureAISearchQueryType? queryType = default(Azure.AI.Projects.Agents.AzureAISearchQueryType?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AzureAISearchToolIndex> indexes = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Projects.Agents.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction function = null, Azure.AI.Projects.Agents.AzureFunctionBinding inputBinding = null, Azure.AI.Projects.Agents.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionTool AzureFunctionTool(Azure.AI.Projects.Agents.AzureFunctionDefinition azureFunction) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionTool AzureFunctionTool(Azure.AI.Projects.Agents.AzureFunctionDefinition azureFunction = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchPreviewTool BingCustomSearchPreviewTool(Azure.AI.Projects.Agents.BingCustomSearchToolOptions bingCustomSearchPreview) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchPreviewTool BingCustomSearchPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.BingCustomSearchToolOptions bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchToolOptions BingCustomSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string bingUserInterfaceLanguage = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingSearchToolOptions BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingTool BingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions searchToolOptions) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingTool BingGroundingTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.BingGroundingSearchToolOptions searchToolOptions = null) { throw null; }
        public static Azure.AI.Projects.Agents.BotServiceAuthorizationScheme BotServiceAuthorizationScheme() { throw null; }
        public static Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme BotServiceRbacAuthorizationScheme() { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewTool BrowserAutomationPreviewTool(Azure.AI.Projects.Agents.BrowserAutomationToolOptions toolParameters) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewTool BrowserAutomationPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.BrowserAutomationToolOptions toolParameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationToolOptions BrowserAutomationToolOptions(Azure.AI.Projects.Agents.BrowserAutomationToolConnectionParameters toolConnectionParameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.CandidateDeployConfig CandidateDeployConfig(string instructions = null, string model = null, float? temperature = default(float?), System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> skills = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> tools = null) { throw null; }
        public static Azure.AI.Projects.Agents.CandidateFileInfo CandidateFileInfo(string path = null, string type = null, long sizeBytes = (long)0) { throw null; }
        public static Azure.AI.Projects.Agents.CandidateMetadata CandidateMetadata(string candidateId = null, string jobId = null, string candidateName = null, string status = null, double? score = default(double?), bool hasResults = false, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), Azure.AI.Projects.Agents.PromotionInfo promotion = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.CandidateFileInfo> files = null) { throw null; }
        public static Azure.AI.Projects.Agents.CandidateResults CandidateResults(string candidateId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OptimizationTaskResult> results = null) { throw null; }
        public static Azure.AI.Projects.Agents.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputDefinition) { throw null; }
        public static Azure.AI.Projects.Agents.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.StructuredOutputDefinition outputDefinition = null) { throw null; }
        public static Azure.AI.Projects.Agents.CodeConfiguration CodeConfiguration(string runtime = null, System.Collections.Generic.IEnumerable<string> entryPoint = null, Azure.AI.Projects.Agents.CodeDependencyResolution dependencyResolution = default(Azure.AI.Projects.Agents.CodeDependencyResolution), string contentHash = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContainerConfiguration ContainerConfiguration(string image = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration(string raiPolicyName = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentFromCodeOptions CreateAgentFromCodeOptions(Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata metadata = null, System.BinaryData code = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentVersionFromCodeMetadata CreateAgentVersionFromCodeMetadata(string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.Agents.HostedAgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest CreateAgentVersionFromManifestRequest(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.DatasetInfo DatasetInfo(string name = null, string version = null, int taskCount = 0, bool isInline = false) { throw null; }
        public static Azure.AI.Projects.Agents.DatasetRef DatasetRef(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.DeclarativeAgentDefinition DeclarativeAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string model = null, string instructions = null, float? temperature = default(float?), float? topP = default(float?), OpenAI.Responses.ResponseReasoningOptions reasoningOptions = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseTool> tools = null, System.BinaryData toolChoice = null, OpenAI.Responses.ResponseTextOptions textOptions = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> structuredInputs = null) { throw null; }
        public static Azure.AI.Projects.Agents.DeleteSkillResponse DeleteSkillResponse(string id = null, string name = null, bool deleted = false) { throw null; }
        public static Azure.AI.Projects.Agents.DeleteSkillVersionResponse DeleteSkillVersionResponse(string id = null, string name = null, bool deleted = false, string version = null) { throw null; }
        public static OpenAI.EmptyModelParam EmptyModelParam() { throw null; }
        public static Azure.AI.Projects.Agents.EntraAuthorizationScheme EntraAuthorizationScheme(Azure.AI.Projects.Agents.IsolationKeySource isolationKeySource = null) { throw null; }
        public static Azure.AI.Projects.Agents.EntraIsolationKeySource EntraIsolationKeySource() { throw null; }
        public static Azure.AI.Projects.Agents.ExternalAgentDefinition ExternalAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string otelAgentId = null) { throw null; }
        public static Azure.AI.Projects.Agents.FabricDataAgentToolOptions FabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.Agents.FabricIQPreviewTool FabricIQPreviewTool(string projectConnectionId = null, string serverLabel = null, System.Uri serverUrl = null, System.BinaryData requireApproval = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule FixedRatioVersionSelectionRule(string agentVersion = null, int trafficPercentage = 0) { throw null; }
        public static Azure.AI.Projects.Agents.HeaderIsolationKeySource HeaderIsolationKeySource() { throw null; }
        public static Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth HeaderTelemetryEndpointAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProjectsAgentTool> tools, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> versions, string cpu, string memory, System.Collections.Generic.IDictionary<string, string> environmentVariables, string image) { throw null; }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProjectsAgentTool> tools = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, Azure.AI.Projects.Agents.ContainerConfiguration containerConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> versions = null, Azure.AI.Projects.Agents.CodeConfiguration codeConfiguration = null, Azure.AI.Projects.Agents.TelemetryConfig telemetryConfig = null) { throw null; }
        public static Azure.AI.Projects.Agents.IsolationKeySource IsolationKeySource(string kind = null) { throw null; }
        public static Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference ManagedAgentIdentityBlueprintReference(string blueprintId = null) { throw null; }
        public static Azure.AI.Projects.Agents.MemorySearchPreviewTool MemorySearchPreviewTool(string memoryStoreName, string scope, Azure.AI.Projects.Agents.MemorySearchToolOptions searchOptions, int? updateDelayInSecs) { throw null; }
        public static Azure.AI.Projects.Agents.MemorySearchPreviewTool MemorySearchPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, string memoryStoreName = null, string scope = null, Azure.AI.Projects.Agents.MemorySearchToolOptions searchOptions = null, int? updateDelayInSecs = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.MemorySearchToolOptions MemorySearchToolOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool MicrosoftFabricPreviewTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions toolOptions) { throw null; }
        public static Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool MicrosoftFabricPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.FabricDataAgentToolOptions toolOptions = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIAnonymousAuthenticationDetails OpenAPIAnonymousAuthenticationDetails() { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiAuthenticationDetails OpenApiAuthenticationDetails(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiFunctionDefinition OpenApiFunctionDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> spec = null, Azure.AI.Projects.Agents.OpenApiAuthenticationDetails authenticationDetails = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OpenAPIFunctionEntry> functions = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIFunctionEntry OpenAPIFunctionEntry(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIManagedAuthenticationDetails OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPIManagedSecurityScheme OpenAPIManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiProjectConnectionAuthenticationDetails OpenApiProjectConnectionAuthenticationDetails(Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiProjectConnectionSecurityScheme OpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPITool OpenAPITool(Azure.AI.Projects.Agents.OpenApiFunctionDefinition functionDefinition) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPITool OpenAPITool(Azure.AI.Projects.Agents.OpenApiFunctionDefinition functionDefinition = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationAgentDefinition OptimizationAgentDefinition(string agentName = null, string agentVersion = null, string model = null, string systemPrompt = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> skills = null, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> tools = null) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationCandidate OptimizationCandidate(string candidateId = null, string name = null, Azure.AI.Projects.Agents.OptimizationAgentDefinition config = null, System.Collections.Generic.IDictionary<string, System.BinaryData> mutations = null, double avgScore = 0, double avgTokens = 0, double passRate = 0, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OptimizationTaskResult> taskScores = null, bool isParetoOptimal = false, string evalId = null, string evalRunId = null, Azure.AI.Projects.Agents.PromotionInfo promotion = null) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationJobInputs OptimizationJobInputs(Azure.AI.Projects.Agents.AgentIdentifier agent = null, Azure.AI.Projects.Agents.DatasetRef trainDatasetReference = null, Azure.AI.Projects.Agents.DatasetRef validationDatasetReference = null, System.Collections.Generic.IEnumerable<string> evaluators = null, Azure.AI.Projects.Agents.OptimizationOptions options = null) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationJobProgress OptimizationJobProgress(int currentIteration = 0, double bestScore = 0, double elapsedSeconds = 0) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationJobResult OptimizationJobResult(Azure.AI.Projects.Agents.OptimizationCandidate baseline = null, Azure.AI.Projects.Agents.OptimizationCandidate best = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OptimizationCandidate> candidates = null, Azure.AI.Projects.Agents.OptimizationOptions options = null, System.Collections.Generic.IEnumerable<string> warnings = null, bool? allTargetAttributesFailed = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationOptions OptimizationOptions(int? maxIterations = default(int?), System.Collections.Generic.IDictionary<string, System.BinaryData> optimizationConfig = null, string evalModel = null, string optimizationModel = null, Azure.AI.Projects.Agents.EvaluationLevel? evaluationLevel = default(Azure.AI.Projects.Agents.EvaluationLevel?)) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationTaskResult OptimizationTaskResult(string taskName = null, string query = null, System.Collections.Generic.IDictionary<string, double> scores = null, double compositeScore = 0, long tokens = (long)0, System.TimeSpan durationSeconds = default(System.TimeSpan), bool passed = false, string errorMessage = null, System.Collections.Generic.IDictionary<string, string> rationales = null, string response = null, string runId = null) { throw null; }
        public static Azure.AI.Projects.Agents.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null, string endpoint = null, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol = default(Azure.AI.Projects.Agents.TelemetryTransportProtocol)) { throw null; }
        public static Azure.AI.Projects.Agents.PatchAgentOptions PatchAgentOptions(Azure.AI.Projects.Agents.AgentEndpointConfiguration agentEndpoint = null, Azure.AI.Projects.Agents.AgentCard agentCard = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectAgentSession ProjectAgentSession(string agentSessionId = null, Azure.AI.Projects.Agents.VersionIndicator versionIndicator = null, Azure.AI.Projects.Agents.AgentSessionStatus status = default(Azure.AI.Projects.Agents.AgentSessionStatus), System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset lastAccessedAt = default(System.DateTimeOffset), System.DateTimeOffset expiresAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentDefinition ProjectsAgentDefinition(string kind = null, Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentRecord ProjectsAgentRecord(string id = null, string name = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentTool ProjectsAgentTool(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata, string id, string name, string version, string description, System.DateTimeOffset createdAt, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null, Azure.AI.Projects.Agents.AgentVersionStatus? status = default(Azure.AI.Projects.Agents.AgentVersionStatus?), Azure.AI.Projects.Agents.AgentIdentity instanceIdentity = null, Azure.AI.Projects.Agents.AgentIdentity blueprint = null, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference = null, string agentGuid = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata, string description, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectWebSearchConfiguration ProjectWebSearchConfiguration(string projectConnectionId = null, string instanceName = null) { throw null; }
        public static Azure.AI.Projects.Agents.PromoteCandidateRequest PromoteCandidateRequest(string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.PromoteCandidateResponse PromoteCandidateResponse(string candidateId = null, string status = null, System.DateTimeOffset promotedAt = default(System.DateTimeOffset), string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.PromotionInfo PromotionInfo(System.DateTimeOffset promotedAt = default(System.DateTimeOffset), string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Projects.Agents.ProjectsAgentProtocol protocol = default(Azure.AI.Projects.Agents.ProjectsAgentProtocol), string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.SessionDirectoryEntry SessionDirectoryEntry(string name = null, long size = (long)0, bool isDirectory = false, System.DateTimeOffset modifiedTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.SessionFileWriteResponse SessionFileWriteResponse(string path = null, long bytesWritten = (long)0) { throw null; }
        public static Azure.AI.Projects.Agents.SessionLogEvent SessionLogEvent(Azure.AI.Projects.Agents.SessionLogEventType @event = default(Azure.AI.Projects.Agents.SessionLogEventType), string data = null) { throw null; }
        public static Azure.AI.Projects.Agents.SharePointGroundingToolOptions SharePointGroundingToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.Agents.SharepointPreviewTool SharepointPreviewTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions toolOptions) { throw null; }
        public static Azure.AI.Projects.Agents.SharepointPreviewTool SharepointPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null, Azure.AI.Projects.Agents.SharePointGroundingToolOptions toolOptions = null) { throw null; }
        public static Azure.AI.Projects.Agents.SkillInlineContent SkillInlineContent(string description = null, string instructions = null, string license = null, string compatibility = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<string> allowedTools = null) { throw null; }
        public static Azure.AI.Projects.Agents.SkillVersion SkillVersion(string id = null, string skillId = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpointAuthentication TelemetryEndpointAuthentication(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxPolicies ToolboxPolicies(Azure.AI.Projects.Agents.ContentFilterConfiguration raiConfig = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxRecord ToolboxRecord(string id = null, string name = null, string defaultVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSearchPreviewTool ToolboxSearchPreviewTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkill ToolboxSkill(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkillReference ToolboxSkillReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxVersion ToolboxVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProjectsAgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolConfig ToolConfig(bool? pin = default(bool?), string additionalSearchText = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolSearchTool ToolSearchTool(OpenAI.ToolSearchExecutionType? execution = default(OpenAI.ToolSearchExecutionType?), string description = null, OpenAI.EmptyModelParam parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.UpdateToolboxRequest UpdateToolboxRequest(string name = null, string defaultVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionIndicator VersionIndicator(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionRefIndicator VersionRefIndicator(string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelectionRule VersionSelectionRule(string type = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelector VersionSelector(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VersionSelectionRule> versionSelectionRules = null) { throw null; }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition WorkflowAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string workflowYaml = null) { throw null; }
        public static Azure.AI.Projects.Agents.WorkIQPreviewTool WorkIQPreviewTool(string projectConnectionId = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> toolConfigs = null) { throw null; }
    }
    public abstract partial class ProjectsAgentTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentTool>
    {
        internal ProjectsAgentTool() { }
        public static Azure.AI.Projects.Agents.ProjectsAgentTool AsProjectTool<T>(T tool) { throw null; }
        public static OpenAI.Responses.ResponseTool CreateA2ATool(System.Uri baseUri, string agentCardPath = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchTool CreateAzureAISearchTool(Azure.AI.Projects.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.Agents.BingCustomSearchPreviewTool CreateBingCustomSearchTool(Azure.AI.Projects.Agents.BingCustomSearchToolOptions parameters) { throw null; }
        public static Azure.AI.Projects.Agents.BingGroundingTool CreateBingGroundingTool(Azure.AI.Projects.Agents.BingGroundingSearchToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewTool CreateBrowserAutomationTool(Azure.AI.Projects.Agents.BrowserAutomationToolOptions parameters) { throw null; }
        public static Azure.AI.Projects.Agents.MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(Azure.AI.Projects.Agents.FabricDataAgentToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.OpenAPITool CreateOpenApiTool(Azure.AI.Projects.Agents.OpenApiFunctionDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.SharepointPreviewTool CreateSharepointTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions options) { throw null; }
        public static Azure.AI.Projects.Agents.CaptureStructuredOutputsTool CreateStructuredOutputsTool(Azure.AI.Projects.Agents.StructuredOutputDefinition outputs) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseTool (Azure.AI.Projects.Agents.ProjectsAgentTool agentTool) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectsAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectsAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsAgentVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>
    {
        internal ProjectsAgentVersion() { }
        public string AgentGuid { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity Blueprint { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentBlueprintReference BlueprintReference { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Agents.ProjectsAgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity InstanceIdentity { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentVersionStatus? Status { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.ProjectsAgentVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectsAgentVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectsAgentVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectsAgentVersionCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>
    {
        public ProjectsAgentVersionCreationOptions(Azure.AI.Projects.Agents.ProjectsAgentDefinition definition) { }
        public Azure.AI.Projects.Agents.AgentBlueprintReference BlueprintReference { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ProjectsAgentDefinition Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ProjectWebSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>
    {
        public ProjectWebSearchConfiguration(string projectConnectionId, string instanceName) { }
        public string InstanceName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ProjectWebSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProjectWebSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProjectWebSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProjectWebSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectWebSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class PromoteCandidateRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>
    {
        public PromoteCandidateRequest(string agentName, string agentVersion) { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.PromoteCandidateRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.PromoteCandidateRequest promoteCandidateRequest) { throw null; }
        protected virtual Azure.AI.Projects.Agents.PromoteCandidateRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PromoteCandidateRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PromoteCandidateRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class PromoteCandidateResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>
    {
        internal PromoteCandidateResponse() { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public string CandidateId { get { throw null; } }
        public System.DateTimeOffset PromotedAt { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.PromoteCandidateResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.PromoteCandidateResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.PromoteCandidateResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PromoteCandidateResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PromoteCandidateResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromoteCandidateResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class PromotionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromotionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromotionInfo>
    {
        internal PromotionInfo() { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public System.DateTimeOffset PromotedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.PromotionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.PromotionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PromotionInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromotionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromotionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PromotionInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromotionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromotionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromotionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolVersionRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>
    {
        public ProtocolVersionRecord(Azure.AI.Projects.Agents.ProjectsAgentProtocol protocol, string version) { }
        public Azure.AI.Projects.Agents.ProjectsAgentProtocol Protocol { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ProtocolVersionRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProtocolVersionRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolVersionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseToolExtensions
    {
        public static Azure.AI.Projects.Agents.ProjectsAgentTool AsAgentTool(this OpenAI.Responses.ResponseTool responseTool) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SessionDirectoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>
    {
        internal SessionDirectoryEntry() { }
        public bool IsDirectory { get { throw null; } }
        public System.DateTimeOffset ModifiedTime { get { throw null; } }
        public string Name { get { throw null; } }
        public long Size { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SessionDirectoryEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SessionDirectoryEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SessionDirectoryEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SessionDirectoryEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SessionFileWriteResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>
    {
        internal SessionFileWriteResponse() { }
        public long BytesWritten { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SessionFileWriteResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SessionFileWriteResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SessionFileWriteResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SessionFileWriteResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SessionFileWriteResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SessionLogEvent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionLogEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionLogEvent>
    {
        internal SessionLogEvent() { }
        public string Data { get { throw null; } }
        public Azure.AI.Projects.Agents.SessionLogEventType Event { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SessionLogEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SessionLogEvent (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SessionLogEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SessionLogEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionLogEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionLogEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SessionLogEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionLogEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionLogEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionLogEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionLogEventType : System.IEquatable<Azure.AI.Projects.Agents.SessionLogEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionLogEventType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.SessionLogEventType Log { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.SessionLogEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.SessionLogEventType left, Azure.AI.Projects.Agents.SessionLogEventType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.SessionLogEventType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.SessionLogEventType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.SessionLogEventType left, Azure.AI.Projects.Agents.SessionLogEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharePointGroundingToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>
    {
        public SharePointGroundingToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SharePointGroundingToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SharePointGroundingToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SharePointGroundingToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SharePointGroundingToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharePointGroundingToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SharepointPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>
    {
        public SharepointPreviewTool(Azure.AI.Projects.Agents.SharePointGroundingToolOptions toolOptions) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        public Azure.AI.Projects.Agents.SharePointGroundingToolOptions ToolOptions { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SharepointPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SharepointPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SharepointPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SkillInlineContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillInlineContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillInlineContent>
    {
        public SkillInlineContent(string description, string instructions) { }
        public System.Collections.Generic.IList<string> AllowedTools { get { throw null; } }
        public string Compatibility { get { throw null; } set { } }
        public string Description { get { throw null; } }
        public string Instructions { get { throw null; } }
        public string License { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SkillInlineContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SkillInlineContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillInlineContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillInlineContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillInlineContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillInlineContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillInlineContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillInlineContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillInlineContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SkillVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersion>
    {
        internal SkillVersion() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string SkillId { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SkillVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SkillVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SkillVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.StructuredInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.StructuredInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? strict) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.StructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.StructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TelemetryEndpoint> Endpoints { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>
    {
        internal TelemetryEndpoint() { }
        public Azure.AI.Projects.Agents.TelemetryEndpointAuthentication Authentication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ExportedDataTypes> ExportedDataTypes { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryEndpointAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>
    {
        internal TelemetryEndpointAuthentication() { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpointAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelemetryEndpointAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelemetryEndpointAuthentication System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelemetryEndpointAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelemetryEndpointAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryTransportProtocol : System.IEquatable<Azure.AI.Projects.Agents.TelemetryTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryTransportProtocol(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryTransportProtocol Grpc { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelemetryTransportProtocol Http { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelemetryTransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelemetryTransportProtocol left, Azure.AI.Projects.Agents.TelemetryTransportProtocol right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryTransportProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelemetryTransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelemetryTransportProtocol left, Azure.AI.Projects.Agents.TelemetryTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ToolboxPolicies : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxPolicies>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxPolicies>
    {
        public ToolboxPolicies() { }
        public Azure.AI.Projects.Agents.ContentFilterConfiguration RaiConfig { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ToolboxPolicies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxPolicies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxPolicies System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxPolicies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxPolicies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxPolicies System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxPolicies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxPolicies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxPolicies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ToolboxRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxRecord>
    {
        internal ToolboxRecord() { }
        public string DefaultVersion { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ToolboxRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.ToolboxRecord (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ToolboxRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ToolboxSearchPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>
    {
        public ToolboxSearchPreviewTool() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class ToolboxSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkill>
    {
        internal ToolboxSkill() { }
        protected virtual Azure.AI.Projects.Agents.ToolboxSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ToolboxSkillReference : Azure.AI.Projects.Agents.ToolboxSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkillReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkillReference>
    {
        public ToolboxSkillReference(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxSkillReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkillReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSkillReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxSkillReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkillReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkillReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSkillReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ToolboxVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersion>
    {
        internal ToolboxVersion() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.ToolboxPolicies Policies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolboxSkill> Skills { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ProjectsAgentTool> Tools { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ToolboxVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.ToolboxVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.ToolboxVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolConfig>
    {
        public ToolConfig() { }
        public string AdditionalSearchText { get { throw null; } set { } }
        public bool? Pin { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ToolConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>
    {
        public ToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolSearchTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchTool>
    {
        public ToolSearchTool() { }
        public string Description { get { throw null; } set { } }
        public OpenAI.ToolSearchExecutionType? Execution { get { throw null; } set { } }
        public OpenAI.EmptyModelParam Parameters { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolSearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolSearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class UpdateToolboxRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>
    {
        public UpdateToolboxRequest(string name, string defaultVersion) { }
        public string DefaultVersion { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.UpdateToolboxRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UpdateToolboxRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UpdateToolboxRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UpdateToolboxRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UpdateToolboxRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VersionIndicator : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionIndicator>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionIndicator>
    {
        internal VersionIndicator() { }
        protected virtual Azure.AI.Projects.Agents.VersionIndicator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VersionIndicator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VersionIndicator System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionIndicator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionIndicator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VersionIndicator System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionIndicator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionIndicator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionIndicator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionRefIndicator : Azure.AI.Projects.Agents.VersionIndicator, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionRefIndicator>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionRefIndicator>
    {
        public VersionRefIndicator(string agentVersion) { }
        public string AgentVersion { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VersionIndicator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VersionIndicator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VersionRefIndicator System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionRefIndicator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionRefIndicator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VersionRefIndicator System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionRefIndicator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionRefIndicator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionRefIndicator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VersionSelectionRule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelectionRule>
    {
        internal VersionSelectionRule() { }
        public string AgentVersion { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VersionSelectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VersionSelectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VersionSelectionRule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VersionSelectionRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionSelector : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelector>
    {
        public VersionSelector(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VersionSelectionRule> versionSelectionRules) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VersionSelectionRule> VersionSelectionRules { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VersionSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VersionSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VersionSelector System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VersionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VersionSelector System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VersionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebSearchToolExtensions
    {
        public static Azure.AI.Projects.Agents.ProjectWebSearchConfiguration get_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool) { throw null; }
        public static void set_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool, Azure.AI.Projects.Agents.ProjectWebSearchConfiguration value) { }
        public sealed partial class <G>$133B1A79670A0C05D9616EBAA22781D3
        {
            internal <G>$133B1A79670A0C05D9616EBAA22781D3() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")]
            public Azure.AI.Projects.Agents.ProjectWebSearchConfiguration CustomSearchConfiguration { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")] set { } }
            public static partial class <M>$153F3998C7DD501BEF8CB71B5BD98F98
            {
                public static void <Extension>$(OpenAI.Responses.WebSearchTool webSearchTool) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WorkflowAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>
    {
        internal WorkflowAgentDefinition() { }
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition FromYaml(string workflowYamlDocument) { throw null; }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkflowAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WorkIQPreviewTool : Azure.AI.Projects.Agents.ProjectsAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>
    {
        public WorkIQPreviewTool(string projectConnectionId) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WorkIQPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WorkIQPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace OpenAI
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class EmptyModelParam : System.ClientModel.Primitives.IJsonModel<OpenAI.EmptyModelParam>, System.ClientModel.Primitives.IPersistableModel<OpenAI.EmptyModelParam>
    {
        public EmptyModelParam() { }
        protected virtual OpenAI.EmptyModelParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual OpenAI.EmptyModelParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.EmptyModelParam System.ClientModel.Primitives.IJsonModel<OpenAI.EmptyModelParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.EmptyModelParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.EmptyModelParam System.ClientModel.Primitives.IPersistableModel<OpenAI.EmptyModelParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.EmptyModelParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.EmptyModelParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum ToolSearchExecutionType
    {
        Server = 0,
        Client = 1,
    }
}
