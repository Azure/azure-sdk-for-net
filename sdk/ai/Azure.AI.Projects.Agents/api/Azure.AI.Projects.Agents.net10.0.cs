namespace Azure.AI.Projects.Agents
{
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class A2APreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>
    {
        public A2APreviewToolboxTool() { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUrl { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public bool? SendCredentialsForAgentCard { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.A2APreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.A2APreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2APreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class A2AProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>
    {
        public A2AProtocolConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.A2AProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.A2AProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.A2AProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.A2AProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct A2AProtocolVersion : System.IEquatable<Azure.AI.Projects.Agents.A2AProtocolVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public A2AProtocolVersion(string value) { throw null; }
        public static Azure.AI.Projects.Agents.A2AProtocolVersion V10 { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.A2AProtocolVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.A2AProtocolVersion left, Azure.AI.Projects.Agents.A2AProtocolVersion right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.A2AProtocolVersion (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.A2AProtocolVersion? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.A2AProtocolVersion left, Azure.AI.Projects.Agents.A2AProtocolVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class A2AToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AToolboxTool>
    {
        public A2AToolboxTool(Azure.AI.Projects.Agents.A2AProtocolVersion a2aVersion) { }
        public Azure.AI.Projects.Agents.A2AProtocolVersion A2aVersion { get { throw null; } set { } }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUrl { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public bool? SendCredentialsForAgentCard { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.A2AToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.A2AToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.A2AToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.A2AToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityProtocolAccessBoundary : System.IEquatable<Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityProtocolAccessBoundary(string value) { throw null; }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Read1on1Allowlisted { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Read1on1Developers { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Read1on1Manager { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Read1on1Tenant { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary ReadGroupAllowlisted { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary ReadGroupDevelopers { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary ReadGroupManagerInvited { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary ReadGroupManagerPresent { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary ReadGroupTenant { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Write1on1Allowlisted { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Write1on1Developers { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Write1on1Manager { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary Write1on1Tenant { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary WriteGroupAllowlisted { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary WriteGroupDevelopers { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary WriteGroupManagerInvited { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary WriteGroupManagerPresent { get { throw null; } }
        public static Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary WriteGroupTenant { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary left, Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary left, Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ActivityProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>
    {
        public ActivityProtocolConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary> AccessBoundaries { get { throw null; } }
        public bool? EnableM365PublicEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ActivityProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ActivityProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ActivityProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ActivityProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ActivityProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> CreateAgentVersionFromCode(string agentName, string filePath, Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> CreateAgentVersionFromCodeAsync(string agentName, string filePath, Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata metadata, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersionFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, Azure.AI.Projects.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession> CreateSession(string agentName, Azure.AI.Projects.Agents.VersionIndicator versionIndicator, string agentSessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession>> CreateSessionAsync(string agentName, Azure.AI.Projects.Agents.VersionIndicator versionIndicator, string agentSessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.ClientModel.ClientResult DeleteSession(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSessionAsync(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DisableAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DisableAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DisableAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DisableAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.BinaryData DownloadAgentCode(string agentName, string path, string agentVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> DownloadAgentCodeAsync(string agentName, string path, string agentVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult EnableAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult EnableAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> EnableAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> EnableAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual Azure.AI.Projects.Agents.AgentOptimizationJobs GetAgentOptimizationJobs() { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgents(Azure.AI.Projects.Agents.ProjectsAgentKind? kind = default(Azure.AI.Projects.Agents.ProjectsAgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgentsAsync(Azure.AI.Projects.Agents.ProjectsAgentKind? kind = default(Azure.AI.Projects.Agents.ProjectsAgentKind?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentSessionFiles GetAgentSessionFiles(string agentName, string sessionId) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual Azure.AI.Projects.Agents.ProjectAgentSkills GetAgentSkills() { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentToolboxes GetAgentToolboxes() { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentVersion>> GetAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersions(bool? includeDrafts, string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersions(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersionsAsync(bool? includeDrafts, string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectsAgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSession(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectAgentSession>> GetSessionAsync(string agentName, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionLogEvent> GetSessionLogStream(string agentName, string agentVersion, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionLogEvent>> GetSessionLogStreamAsync(string agentName, string agentVersion, string sessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSessions(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ProjectAgentSession> GetSessionsAsync(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> PatchAgent(string agentName, Azure.AI.Projects.Agents.PatchAgentOptions patchAgentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> PatchAgentAsync(string agentName, Azure.AI.Projects.Agents.PatchAgentOptions patchAgentOptions, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
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
    public enum AgentDefinitionOptInKeys
    {
        WorkflowAgentsV1Preview = 0,
        ExternalAgentsV1Preview = 1,
        DraftAgentsV1Preview = 2,
        VoiceAgentsV1Preview = 3,
        DigitalWorkerV1Preview = 4,
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
        public Azure.AI.Projects.Agents.ProtocolConfiguration ProtocolConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.PublishApprovalStatus? PublishApprovalStatus { get { throw null; } }
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
    public partial class AgentFromCodeOptions
    {
        public AgentFromCodeOptions(Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata metadata, System.BinaryData code) { }
        public System.BinaryData Code { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata Metadata { get { throw null; } }
    }
    public partial class AgentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentIdentity>
    {
        internal AgentIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentityStatus? Status { get { throw null; } }
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
    public readonly partial struct AgentIdentityStatus : System.IEquatable<Azure.AI.Projects.Agents.AgentIdentityStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentIdentityStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentIdentityStatus Active { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentIdentityStatus Disabled { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentIdentityStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentIdentityStatus left, Azure.AI.Projects.Agents.AgentIdentityStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentIdentityStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentIdentityStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentIdentityStatus left, Azure.AI.Projects.Agents.AgentIdentityStatus right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class AgentObjectVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>
    {
        internal AgentObjectVersions() { }
        public Azure.AI.Projects.Agents.ProjectsAgentVersion Latest { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentObjectVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentObjectVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentObjectVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentObjectVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentObjectVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationCandidate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>
    {
        internal AgentOptimizationCandidate() { }
        public double AvgScore { get { throw null; } }
        public double AvgTokens { get { throw null; } }
        public string CandidateId { get { throw null; } }
        public string EvalId { get { throw null; } }
        public string EvalRunId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Mutations { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.PromotionInfo Promotion { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationDatasetCriterion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>
    {
        public AgentOptimizationDatasetCriterion(string name, string instruction) { }
        public string Instruction { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class AgentOptimizationDatasetInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>
    {
        internal AgentOptimizationDatasetInput() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationDatasetItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>
    {
        public AgentOptimizationDatasetItem() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion> Criteria { get { throw null; } }
        public int? DesiredTurnCount { get { throw null; } set { } }
        public string GroundTruth { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationDatasetItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationDatasetItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationEvaluatorRef : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>
    {
        public AgentOptimizationEvaluatorRef(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationInlineDatasetInput : Azure.AI.Projects.Agents.AgentOptimizationDatasetInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>
    {
        public AgentOptimizationInlineDatasetInput(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem> items) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem> Items { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationDatasetInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationDatasetInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJob>
    {
        public AgentOptimizationJob() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationJobInputs Inputs { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationJobProgress Progress { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationJobResult Result { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentsJobStatus Status { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentOptimizationJob (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.AgentOptimizationJob agentOptimizationJob) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>
    {
        public AgentOptimizationJobInputs(Azure.AI.Projects.Agents.OptimizedAgentIdentifier agent, Azure.AI.Projects.Agents.AgentOptimizationDatasetInput trainDataset, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef> evaluators) { }
        public Azure.AI.Projects.Agents.OptimizedAgentIdentifier Agent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef> Evaluators { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationOptions Options { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationDatasetInput TrainDataset { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationDatasetInput ValidationDataset { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobListItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>
    {
        internal AgentOptimizationJobListItem() { }
        public Azure.AI.Projects.Agents.OptimizedAgentIdentifier Agent { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationJobProgress Progress { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentsJobStatus Status { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobProgress : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>
    {
        internal AgentOptimizationJobProgress() { }
        public double BestScore { get { throw null; } }
        public int CandidatesCompleted { get { throw null; } }
        public double ElapsedSeconds { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobProgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobProgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobProgress System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobProgress System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>
    {
        internal AgentOptimizationJobResult() { }
        public string Baseline { get { throw null; } }
        public string Best { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationCandidate> Candidates { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentOptimizationJobResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationJobs
    {
        protected AgentOptimizationJobs() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob> Cancel(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob>> CancelAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob> Create(Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob>> CreateAsync(Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentOptimizationJobListItem> GetAll(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.AgentsJobStatus? status = default(Azure.AI.Projects.Agents.AgentsJobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentOptimizationJobListItem> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.AgentsJobStatus? status = default(Azure.AI.Projects.Agents.AgentsJobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>
    {
        public AgentOptimizationOptions() { }
        public string EvalModel { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentsEvaluationLevel? EvaluationLevel { get { throw null; } set { } }
        public int? MaxCandidates { get { throw null; } set { } }
        public int? MaxStalls { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> OptimizationConfig { get { throw null; } }
        public string OptimizationModel { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentOptimizationReferenceDatasetInput : Azure.AI.Projects.Agents.AgentOptimizationDatasetInput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>
    {
        public AgentOptimizationReferenceDatasetInput(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationDatasetInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationDatasetInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSessionFiles
    {
        protected AgentSessionFiles() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult Delete(string localPath, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string localPath, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.BinaryData Download(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.BinaryData> DownloadAsync(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.SessionDirectoryEntry> GetAll(string sessionStoragePath = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.SessionDirectoryEntry> GetAllAsync(string sessionStoragePath = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResponse> Upload(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResponse>> UploadAsync(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsEvaluationLevel : System.IEquatable<Azure.AI.Projects.Agents.AgentsEvaluationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsEvaluationLevel(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentsEvaluationLevel Conversation { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentsEvaluationLevel Turn { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentsEvaluationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentsEvaluationLevel left, Azure.AI.Projects.Agents.AgentsEvaluationLevel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentsEvaluationLevel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentsEvaluationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentsEvaluationLevel left, Azure.AI.Projects.Agents.AgentsEvaluationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsJobStatus : System.IEquatable<Azure.AI.Projects.Agents.AgentsJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsJobStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentsJobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentsJobStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentsJobStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentsJobStatus Queued { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentsJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentsJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentsJobStatus left, Azure.AI.Projects.Agents.AgentsJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentsJobStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentsJobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentsJobStatus left, Azure.AI.Projects.Agents.AgentsJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class AgentsSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentsSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentsSkill>
    {
        internal AgentsSkill() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentState : System.IEquatable<Azure.AI.Projects.Agents.AgentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentState(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentState Disabled { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentState Enabled { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentState left, Azure.AI.Projects.Agents.AgentState right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentState (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentState left, Azure.AI.Projects.Agents.AgentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStateSource : System.IEquatable<Azure.AI.Projects.Agents.AgentStateSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStateSource(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentStateSource AgentBlueprint { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentStateSource AgentInstanceIdentity { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentStateSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentStateSource left, Azure.AI.Projects.Agents.AgentStateSource right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentStateSource (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentStateSource? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentStateSource left, Azure.AI.Projects.Agents.AgentStateSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentToolboxes
    {
        protected AgentToolboxes() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion> CreateVersion(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxTool> tools, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion>> CreateVersionAsync(string name, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxTool> tools, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ToolboxRecord> GetAll(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetAll(int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ToolboxRecord> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetAllAsync(int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion> GetVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxVersion>> GetVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.ToolboxVersion> GetVersions(string name, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetVersions(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.ToolboxVersion> GetVersionsAsync(string name, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetVersionsAsync(string name, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateDefaultVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord> UpdateDefaultVersion(string name, string defaultVersion, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateDefaultVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ToolboxRecord>> UpdateDefaultVersionAsync(string name, string defaultVersion, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class AgentVersionFromCodeMetadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>
    {
        public AgentVersionFromCodeMetadata(Azure.AI.Projects.Agents.HostedAgentDefinition definition) { }
        public Azure.AI.Projects.Agents.HostedAgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentVersionStatus : System.IEquatable<Azure.AI.Projects.Agents.AgentVersionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentVersionStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentVersionStatus Active { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentVersionStatus Creating { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentVersionStatus Deleted { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentVersionStatus Deleting { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentVersionStatus Failed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentVersionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentVersionStatus left, Azure.AI.Projects.Agents.AgentVersionStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentVersionStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentVersionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentVersionStatus left, Azure.AI.Projects.Agents.AgentVersionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
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
    public partial class AzureAISearchToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>
    {
        public AzureAISearchToolboxTool(Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAiSearch) { }
        public Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions AzureAiSearch { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AzureAISearchToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AzureAISearchToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureAISearchToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction>
    {
        internal AzureFunctionDefinitionFunction() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
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
    public partial class BotServiceTenantAuthorizationScheme : Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>
    {
        public BotServiceTenantAuthorizationScheme() { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BrowserAutomationPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>
    {
        public BrowserAutomationPreviewToolboxTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions toolParameters) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions ToolParameters { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class CodeInterpreterToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>
    {
        public CodeInterpreterToolboxTool() { }
        public System.Collections.Generic.IList<OpenAI.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
        public OpenAI.Responses.CodeInterpreterToolContainer Container { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CodeInterpreterToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CodeInterpreterToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CodeInterpreterToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerConfiguration>
    {
        public ContainerConfiguration(string image) { }
        public string Image { get { throw null; } set { } }
        public string RegistryConnectionId { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DigitalWorkerType : System.IEquatable<Azure.AI.Projects.Agents.DigitalWorkerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DigitalWorkerType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.DigitalWorkerType M365 { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.DigitalWorkerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.DigitalWorkerType left, Azure.AI.Projects.Agents.DigitalWorkerType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.DigitalWorkerType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.DigitalWorkerType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.DigitalWorkerType left, Azure.AI.Projects.Agents.DigitalWorkerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntraAuthorizationScheme : Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EntraAuthorizationScheme>
    {
        public EntraAuthorizationScheme() { }
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
    public partial class FabricIQPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>
    {
        public FabricIQPreviewToolboxTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        public OpenAI.Responses.McpToolCallApprovalPolicy RequireApproval { get { throw null; } set { } }
        public System.BinaryData RequireApprovalInternal { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>
    {
        public FileSearchToolboxTool() { }
        public System.BinaryData Filters { get { throw null; } set { } }
        public long? MaxNumResults { get { throw null; } set { } }
        public object RankingOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.FileSearchToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.FileSearchToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.FileSearchToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.AI.Projects.Agents.SessionConfiguration SessionConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
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
    public partial class InvocationsProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>
    {
        public InvocationsProtocolConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.InvocationsProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.InvocationsProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.InvocationsProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.InvocationsProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvocationsWsProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>
    {
        public InvocationsWsProtocolConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class McpProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>
    {
        public McpProtocolConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.McpProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.McpProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.McpProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.McpProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.McpProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MCPToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MCPToolboxTool>
    {
        public MCPToolboxTool(string serverLabel) { }
        public System.Collections.Generic.IList<OpenAI.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
        public System.BinaryData AllowedTools { get { throw null; } set { } }
        public string Authorization { get { throw null; } set { } }
        public OpenAI.MCPToolboxToolConnectorId? ConnectorId { get { throw null; } set { } }
        public bool? DeferLoading { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string ServerDescription { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUri { get { throw null; } set { } }
        public OpenAI.Responses.McpToolCallApprovalPolicy ToolCallApprovalPolicy { get { throw null; } set { } }
        public string TunnelId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.MCPToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MCPToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.MCPToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.MCPToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MCPToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MCPToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.MCPToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OpenApiToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>
    {
        public OpenApiToolboxTool(Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition functionDefinition) { }
        public Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition FunctionDefinition { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OpenApiToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OpenApiToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OpenApiToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class OptimizedAgentIdentifier : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>
    {
        public OptimizedAgentIdentifier(string agentName) { }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.OptimizedAgentIdentifier JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizedAgentIdentifier PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizedAgentIdentifier System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizedAgentIdentifier System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizedAgentIdentifier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ProjectAgentSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectAgentSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectAgentSession>
    {
        internal ProjectAgentSession() { }
        public string AgentSessionId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } }
        public System.DateTimeOffset LastAccessedOn { get { throw null; } }
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
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion> CreateSkillVersion(string name, Azure.AI.Projects.Agents.SkillInlineContent inlineContent = null, bool? isDefault = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateSkillVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersion>> CreateSkillVersionAsync(string name, Azure.AI.Projects.Agents.SkillInlineContent inlineContent = null, bool? isDefault = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateSkillVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateSkillVersionFromFiles(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> CreateSkillVersionFromFiles(string name, string directoryPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateSkillVersionFromFilesAsync(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> CreateSkillVersionFromFilesAsync(string name, string directoryPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteSkill(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillDeletionResult> DeleteSkill(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSkillAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillDeletionResult>> DeleteSkillAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteSkillVersion(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersionDeletionResult> DeleteSkillVersion(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteSkillVersionAsync(string name, string version, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SkillVersionDeletionResult>> DeleteSkillVersionAsync(string name, string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkill(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> GetSkill(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> GetSkillAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetSkillContent(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetSkillContent(string skillName, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetSkillContent(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetSkillContentAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetSkillContentAsync(string skillName, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.ClientModel.ClientResult UpdateDefaultVersion(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill> UpdateDefaultVersion(string name, string defaultVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateDefaultVersionAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentsSkill>> UpdateDefaultVersionAsync(string name, string defaultVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class ProjectsAgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentDefinition>
    {
        internal ProjectsAgentDefinition() { }
        public Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration { get { throw null; } set { } }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition CreateHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration) { throw null; }
        public static Azure.AI.Projects.Agents.DeclarativeAgentDefinition CreatePromptAgentDefinition(string model) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public Azure.AI.Projects.Agents.DigitalWorkerType? DigitalWorkerType { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity InstanceIdentity { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentState State { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentStateSource? StateSource { get { throw null; } }
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
    public static partial class ProjectsAgentsModelFactory
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.A2APreviewToolboxTool A2APreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Uri baseUrl = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.A2AProtocolConfiguration A2AProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.A2AToolboxTool A2AToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Uri baseUrl = null, string agentCardPath = null, string projectConnectionId = null, bool? sendCredentialsForAgentCard = default(bool?), Azure.AI.Projects.Agents.A2AProtocolVersion a2aVersion = default(Azure.AI.Projects.Agents.A2AProtocolVersion)) { throw null; }
        public static Azure.AI.Projects.Agents.ActivityProtocolConfiguration ActivityProtocolConfiguration(bool? enableM365PublicEndpoint = default(bool?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ActivityProtocolAccessBoundary> accessBoundaries = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentBlueprintReference AgentBlueprintReference(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentCard AgentCard(string version = null, string description = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentCardSkill> skills = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentCardSkill AgentCardSkill(string id = null, string name = null, string description = null, System.Collections.Generic.IEnumerable<string> labels = null, System.Collections.Generic.IEnumerable<string> examples = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme AgentEndpointAuthorizationScheme(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentEndpointConfiguration AgentEndpointConfiguration(Azure.AI.Projects.Agents.VersionSelector versionSelector = null, Azure.AI.Projects.Agents.ProtocolConfiguration protocolConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentEndpointAuthorizationScheme> authorizationSchemes = null, Azure.AI.Projects.Agents.PublishApprovalStatus? publishApprovalStatus = default(Azure.AI.Projects.Agents.PublishApprovalStatus?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentFromCodeOptions AgentFromCodeOptions(Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata metadata = null, System.BinaryData code = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentIdentity AgentIdentity(string principalId = null, string clientId = null, Azure.AI.Projects.Agents.AgentIdentityStatus? status = default(Azure.AI.Projects.Agents.AgentIdentityStatus?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentManifestOptions AgentManifestOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentObjectVersions AgentObjectVersions(Azure.AI.Projects.Agents.ProjectsAgentVersion latest = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidate AgentOptimizationCandidate(string candidateId = null, string name = null, System.Collections.Generic.IDictionary<string, System.BinaryData> mutations = null, double avgScore = 0, double avgTokens = 0, string evalId = null, string evalRunId = null, Azure.AI.Projects.Agents.PromotionInfo promotion = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion AgentOptimizationDatasetCriterion(string name = null, string instruction = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationDatasetInput AgentOptimizationDatasetInput(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationDatasetItem AgentOptimizationDatasetItem(string query = null, string groundTruth = null, int? desiredTurnCount = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationDatasetCriterion> criteria = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef AgentOptimizationEvaluatorRef(string name = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationInlineDatasetInput AgentOptimizationInlineDatasetInput(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationDatasetItem> items = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationJobInputs AgentOptimizationJobInputs(Azure.AI.Projects.Agents.OptimizedAgentIdentifier agent = null, Azure.AI.Projects.Agents.AgentOptimizationDatasetInput trainDataset = null, Azure.AI.Projects.Agents.AgentOptimizationDatasetInput validationDataset = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationEvaluatorRef> evaluators = null, Azure.AI.Projects.Agents.AgentOptimizationOptions options = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationJobProgress AgentOptimizationJobProgress(int candidatesCompleted = 0, double bestScore = 0, double elapsedSeconds = 0) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationJobResult AgentOptimizationJobResult(string baseline = null, string best = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationCandidate> candidates = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationOptions AgentOptimizationOptions(int? maxCandidates = default(int?), System.Collections.Generic.IDictionary<string, System.BinaryData> optimizationConfig = null, string evalModel = null, string optimizationModel = null, Azure.AI.Projects.Agents.AgentsEvaluationLevel? evaluationLevel = default(Azure.AI.Projects.Agents.AgentsEvaluationLevel?), int? maxStalls = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentOptimizationReferenceDatasetInput AgentOptimizationReferenceDatasetInput(string name = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentsSkill AgentsSkill(string id = null, string name = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), string defaultVersion = null, string latestVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentVersionFromCodeMetadata AgentVersionFromCodeMetadata(string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Projects.Agents.HostedAgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureAISearchToolboxTool AzureAISearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.AzureAISearchToolOptions azureAiSearch = null) { throw null; }
        public static Azure.AI.Projects.Agents.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.BotServiceAuthorizationScheme BotServiceAuthorizationScheme() { throw null; }
        public static Azure.AI.Projects.Agents.BotServiceRbacAuthorizationScheme BotServiceRbacAuthorizationScheme() { throw null; }
        public static Azure.AI.Projects.Agents.BotServiceTenantAuthorizationScheme BotServiceTenantAuthorizationScheme() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.BrowserAutomationPreviewToolboxTool BrowserAutomationPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions toolParameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.CodeConfiguration CodeConfiguration(string runtime = null, System.Collections.Generic.IEnumerable<string> entryPoint = null, Azure.AI.Projects.Agents.CodeDependencyResolution dependencyResolution = default(Azure.AI.Projects.Agents.CodeDependencyResolution), string contentHash = null) { throw null; }
        public static Azure.AI.Projects.Agents.CodeInterpreterToolboxTool CodeInterpreterToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Collections.Generic.IEnumerable<OpenAI.CallableToolAllowedCaller> allowedCallers = null, System.BinaryData internalContainer = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContainerConfiguration ContainerConfiguration(string image = null, string registryConnectionId = null) { throw null; }
        public static OpenAI.ContainerSkill ContainerSkill(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration(string raiPolicyName = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest CreateAgentVersionFromManifestRequest(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Projects.Agents.DeclarativeAgentDefinition DeclarativeAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string model = null, string instructions = null, float? temperature = default(float?), float? topP = default(float?), OpenAI.Responses.ResponseReasoningOptions reasoningOptions = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseTool> tools = null, System.BinaryData toolChoice = null, OpenAI.Responses.ResponseTextOptions textOptions = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> structuredInputs = null) { throw null; }
        public static Azure.AI.Projects.Agents.EntraAuthorizationScheme EntraAuthorizationScheme() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ExternalAgentDefinition ExternalAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string otelAgentId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool FabricIQPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, System.BinaryData requireApprovalInternal = null) { throw null; }
        public static Azure.AI.Projects.Agents.FileSearchToolboxTool FileSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, long? maxNumResults = default(long?), object rankingOptions = null, System.BinaryData filters = null, System.Collections.Generic.IEnumerable<string> vectorStoreIds = null) { throw null; }
        public static Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule FixedRatioVersionSelectionRule(string agentVersion = null, int trafficPercentage = 0) { throw null; }
        public static Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth HeaderTelemetryEndpointAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, Azure.AI.Projects.Agents.ContainerConfiguration containerConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> versions = null, Azure.AI.Projects.Agents.CodeConfiguration codeConfiguration = null, Azure.AI.Projects.Agents.TelemetryConfig telemetryConfig = null, Azure.AI.Projects.Agents.SessionConfiguration sessionConfiguration = null) { throw null; }
        public static OpenAI.InlineSkillParam InlineSkillParam(string name = null, string description = null, OpenAI.InlineSkillSourceParam source = null) { throw null; }
        public static OpenAI.InlineSkillSourceParam InlineSkillSourceParam(string data = null) { throw null; }
        public static Azure.AI.Projects.Agents.InvocationsProtocolConfiguration InvocationsProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration InvocationsWsProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference ManagedAgentIdentityBlueprintReference(string blueprintId = null) { throw null; }
        public static Azure.AI.Projects.Agents.McpProtocolConfiguration McpProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.MCPToolboxTool MCPToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string serverLabel = null, System.Uri serverUri = null, OpenAI.MCPToolboxToolConnectorId? connectorId = default(OpenAI.MCPToolboxToolConnectorId?), string tunnelId = null, string authorization = null, string serverDescription = null, System.Collections.Generic.IDictionary<string, string> headers = null, System.BinaryData allowedTools = null, System.Collections.Generic.IEnumerable<OpenAI.CallableToolAllowedCaller> allowedCallers = null, System.BinaryData requireApprovalInternal = null, bool? deferLoading = default(bool?), string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiToolboxTool OpenApiToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition functionDefinition = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.OptimizedAgentIdentifier OptimizedAgentIdentifier(string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null, string endpoint = null, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol = default(Azure.AI.Projects.Agents.TelemetryTransportProtocol)) { throw null; }
        public static Azure.AI.Projects.Agents.PatchAgentOptions PatchAgentOptions(Azure.AI.Projects.Agents.AgentEndpointConfiguration agentEndpoint = null, Azure.AI.Projects.Agents.AgentCard agentCard = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectAgentSession ProjectAgentSession(string agentSessionId = null, Azure.AI.Projects.Agents.VersionIndicator versionIndicator = null, Azure.AI.Projects.Agents.AgentSessionStatus status = default(Azure.AI.Projects.Agents.AgentSessionStatus), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastAccessedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentDefinition ProjectsAgentDefinition(string kind = null, Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentRecord ProjectsAgentRecord(string id, string name) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentRecord ProjectsAgentRecord(string id = null, string name = null, Azure.AI.Projects.Agents.AgentState state = default(Azure.AI.Projects.Agents.AgentState)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata, string id, string name, string version, string description, System.DateTimeOffset createdAt, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition, bool? draft, Azure.AI.Projects.Agents.AgentVersionStatus? status = default(Azure.AI.Projects.Agents.AgentVersionStatus?), Azure.AI.Projects.Agents.AgentIdentity instanceIdentity = null, Azure.AI.Projects.Agents.AgentIdentity blueprint = null, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference = null, string agentGuidInternal = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata, string description, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference, Azure.AI.Projects.Agents.DigitalWorkerType? digitalWorkerType = default(Azure.AI.Projects.Agents.DigitalWorkerType?), bool? draft = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.PromotionInfo PromotionInfo(System.DateTimeOffset promotedOn = default(System.DateTimeOffset), string agentName = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolConfiguration ProtocolConfiguration(Azure.AI.Projects.Agents.ActivityProtocolConfiguration activity = null, Azure.AI.Projects.Agents.ResponsesProtocolConfiguration responses = null, Azure.AI.Projects.Agents.A2AProtocolConfiguration a2a = null, Azure.AI.Projects.Agents.McpProtocolConfiguration mcp = null, Azure.AI.Projects.Agents.InvocationsProtocolConfiguration invocations = null, Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration invocationsWs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Projects.Agents.ProjectsAgentProtocol protocol = default(Azure.AI.Projects.Agents.ProjectsAgentProtocol), string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ReminderPreviewToolboxTool ReminderPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ResponsesProtocolConfiguration ResponsesProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.SessionConfiguration SessionConfiguration(System.TimeSpan? idleTimeoutSeconds = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Projects.Agents.SessionDirectoryEntry SessionDirectoryEntry(string name = null, long sizeInBytes = (long)0, bool isDirectory = false, System.DateTimeOffset modifiedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.SessionFileWriteResponse SessionFileWriteResponse(string path = null, long bytesWritten = (long)0) { throw null; }
        public static Azure.AI.Projects.Agents.SessionLogEvent SessionLogEvent(Azure.AI.Projects.Agents.SessionLogEventKind @event = default(Azure.AI.Projects.Agents.SessionLogEventKind), string data = null) { throw null; }
        public static Azure.AI.Projects.Agents.ShellToolboxTool ShellToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Collections.Generic.IEnumerable<OpenAI.CallableToolAllowedCaller> allowedCallers = null, Azure.AI.Projects.Agents.ToolboxShellEnvironment environment = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillDeletionResult SkillDeletionResult(string id = null, string name = null, bool deleted = false) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillInlineContent SkillInlineContent(string description = null, string instructions = null, string license = null, string compatibility = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<string> allowedTools = null) { throw null; }
        public static OpenAI.SkillReferenceParam SkillReferenceParam(string skillId = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillVersion SkillVersion(string id = null, string skillId = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillVersionDeletionResult SkillVersionDeletionResult(string id = null, string name = null, bool deleted = false, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpointAuthentication TelemetryEndpointAuthentication(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxPolicies ToolboxPolicies(Azure.AI.Projects.Agents.ContentFilterConfiguration raiConfig = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxRecord ToolboxRecord(string id = null, string name = null, string defaultVersion = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool ToolboxSearchPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment ToolboxShellContainerAutoEnvironment(System.Collections.Generic.IEnumerable<string> fileIds = null, OpenAI.ContainerMemoryLimit? memoryLimit = default(OpenAI.ContainerMemoryLimit?), System.Collections.Generic.IEnumerable<OpenAI.ContainerSkill> skills = null, Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy networkPolicy = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment ToolboxShellContainerReferenceEnvironment(string containerId = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellEnvironment ToolboxShellEnvironment(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy ToolboxShellNetworkPolicy(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled ToolboxShellNetworkPolicyDisabled() { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkill ToolboxSkill(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkillReference ToolboxSkillReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxTool ToolboxTool(string type = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxVersion ToolboxVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolSearchToolboxTool ToolSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.UpdateToolboxRequest UpdateToolboxRequest(string name = null, string defaultVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionIndicator VersionIndicator(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionRefIndicator VersionRefIndicator(string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelectionRule VersionSelectionRule(string type = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelector VersionSelector(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VersionSelectionRule> versionSelectionRules = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.WebIQPreviewToolboxTool WebIQPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string projectConnectionId = null, string serverLabel = null, System.BinaryData requireApproval = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Projects.Agents.WebSearchToolboxTool WebSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, OpenAI.Responses.WebSearchToolFilters filters = null, OpenAI.Responses.WebSearchToolApproximateLocation userLocation = null, OpenAI.WebSearchToolSearchContextSize? searchContextSize = default(OpenAI.WebSearchToolSearchContextSize?), Azure.AI.Extensions.OpenAI.WebSearchConfiguration customSearchConfiguration = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.WorkflowAgentDefinition WorkflowAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string workflowYaml = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool WorkIQPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string projectConnectionId = null) { throw null; }
    }
    public partial class ProjectsAgentVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProjectsAgentVersion>
    {
        internal ProjectsAgentVersion() { }
        public System.Guid AgentGuid { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentIdentity Blueprint { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentBlueprintReference BlueprintReference { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.Agents.ProjectsAgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public bool? Draft { get { throw null; } }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public Azure.AI.Projects.Agents.DigitalWorkerType? DigitalWorkerType { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public bool? Draft { get { throw null; } set { } }
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
    public partial class PromotionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromotionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromotionInfo>
    {
        internal PromotionInfo() { }
        public string AgentName { get { throw null; } }
        public string AgentVersion { get { throw null; } }
        public System.DateTimeOffset PromotedOn { get { throw null; } }
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
    public partial class ProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolConfiguration>
    {
        public ProtocolConfiguration() { }
        public Azure.AI.Projects.Agents.A2AProtocolConfiguration A2a { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ActivityProtocolConfiguration Activity { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.InvocationsProtocolConfiguration Invocations { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration InvocationsWs { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.McpProtocolConfiguration Mcp { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ResponsesProtocolConfiguration Responses { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublishApprovalStatus : System.IEquatable<Azure.AI.Projects.Agents.PublishApprovalStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublishApprovalStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.PublishApprovalStatus Approved { get { throw null; } }
        public static Azure.AI.Projects.Agents.PublishApprovalStatus NoApprovalNeeded { get { throw null; } }
        public static Azure.AI.Projects.Agents.PublishApprovalStatus NotPublished { get { throw null; } }
        public static Azure.AI.Projects.Agents.PublishApprovalStatus Pending { get { throw null; } }
        public static Azure.AI.Projects.Agents.PublishApprovalStatus Rejected { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.PublishApprovalStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.PublishApprovalStatus left, Azure.AI.Projects.Agents.PublishApprovalStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.PublishApprovalStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.PublishApprovalStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.PublishApprovalStatus left, Azure.AI.Projects.Agents.PublishApprovalStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class ReminderPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>
    {
        public ReminderPreviewToolboxTool() { }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ReminderPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ReminderPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ReminderPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsesProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>
    {
        public ResponsesProtocolConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.ResponsesProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ResponsesProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ResponsesProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ResponsesProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ResponsesProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionConfiguration>
    {
        public SessionConfiguration() { }
        public System.TimeSpan? IdleTimeoutSeconds { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.SessionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SessionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SessionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SessionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionDirectoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionDirectoryEntry>
    {
        internal SessionDirectoryEntry() { }
        public bool IsDirectory { get { throw null; } }
        public System.DateTimeOffset ModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public long SizeInBytes { get { throw null; } }
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
    public partial class SessionLogEvent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionLogEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionLogEvent>
    {
        internal SessionLogEvent() { }
        public string Data { get { throw null; } }
        public Azure.AI.Projects.Agents.SessionLogEventKind Event { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionLogEventKind : System.IEquatable<Azure.AI.Projects.Agents.SessionLogEventKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionLogEventKind(string value) { throw null; }
        public static Azure.AI.Projects.Agents.SessionLogEventKind Log { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.SessionLogEventKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.SessionLogEventKind left, Azure.AI.Projects.Agents.SessionLogEventKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.SessionLogEventKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.SessionLogEventKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.SessionLogEventKind left, Azure.AI.Projects.Agents.SessionLogEventKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShellToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ShellToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ShellToolboxTool>
    {
        public ShellToolboxTool(Azure.AI.Projects.Agents.ToolboxShellEnvironment environment) { }
        public System.Collections.Generic.IList<OpenAI.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ToolboxShellEnvironment Environment { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ShellToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ShellToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ShellToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ShellToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ShellToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ShellToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ShellToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SkillDeletionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillDeletionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillDeletionResult>
    {
        internal SkillDeletionResult() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SkillDeletionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SkillDeletionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SkillDeletionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillDeletionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillDeletionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillDeletionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillDeletionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillDeletionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillDeletionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillDeletionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset CreatedOn { get { throw null; } }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class SkillVersionDeletionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>
    {
        internal SkillVersionDeletionResult() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SkillVersionDeletionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SkillVersionDeletionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SkillVersionDeletionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillVersionDeletionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillVersionDeletionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillVersionDeletionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ToolboxSearchPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>
    {
        public ToolboxSearchPreviewToolboxTool() { }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolboxShellContainerAutoEnvironment : Azure.AI.Projects.Agents.ToolboxShellEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>
    {
        public ToolboxShellContainerAutoEnvironment() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public OpenAI.ContainerMemoryLimit? MemoryLimit { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy NetworkPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.ContainerSkill> Skills { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ToolboxShellEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxShellEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolboxShellContainerReferenceEnvironment : Azure.AI.Projects.Agents.ToolboxShellEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>
    {
        public ToolboxShellContainerReferenceEnvironment(string containerId) { }
        public string ContainerId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxShellEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxShellEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolboxShellEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>
    {
        internal ToolboxShellEnvironment() { }
        protected virtual Azure.AI.Projects.Agents.ToolboxShellEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxShellEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxShellEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxShellEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolboxShellNetworkPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>
    {
        internal ToolboxShellNetworkPolicy() { }
        protected virtual Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolboxShellNetworkPolicyDisabled : Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>
    {
        public ToolboxShellNetworkPolicyDisabled() { }
        protected override Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    public abstract partial class ToolboxTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxTool>
    {
        internal ToolboxTool() { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolboxVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersion>
    {
        internal ToolboxVersion() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.ToolboxPolicies Policies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolboxSkill> Skills { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ToolboxTool> Tools { get { throw null; } }
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
    public partial class ToolSearchToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>
    {
        public ToolSearchToolboxTool() { }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolSearchToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolSearchToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolSearchToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WebIQPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>
    {
        public WebIQPreviewToolboxTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.BinaryData RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WebIQPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WebIQPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>
    {
        public WebSearchToolboxTool() { }
        public Azure.AI.Extensions.OpenAI.WebSearchConfiguration CustomSearchConfiguration { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.WebSearchToolFilters Filters { get { throw null; } set { } }
        public OpenAI.WebSearchToolSearchContextSize? SearchContextSize { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.WebSearchToolApproximateLocation UserLocation { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WebSearchToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WebSearchToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebSearchToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class WebSearchToolExtensions
    {
        public static Azure.AI.Extensions.OpenAI.WebSearchConfiguration get_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool) { throw null; }
        public static void set_CustomSearchConfiguration(OpenAI.Responses.WebSearchTool webSearchTool, Azure.AI.Extensions.OpenAI.WebSearchConfiguration value) { }
        public sealed partial class <G>$133B1A79670A0C05D9616EBAA22781D3
        {
            internal <G>$133B1A79670A0C05D9616EBAA22781D3() { }
            [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")]
            public Azure.AI.Extensions.OpenAI.WebSearchConfiguration CustomSearchConfiguration { [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")] get { throw null; } [System.Runtime.CompilerServices.ExtensionMarkerAttribute("<M>$153F3998C7DD501BEF8CB71B5BD98F98")] set { } }
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
    public partial class WorkIQPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>
    {
        public WorkIQPreviewToolboxTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WorkIQPreviewToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace OpenAI
{
    public enum CallableToolAllowedCaller
    {
        Direct = 0,
        Programmatic = 1,
    }
    public enum ContainerMemoryLimit
    {
        _1g = 0,
        _4g = 1,
        _16g = 2,
        _64g = 3,
    }
    public abstract partial class ContainerSkill : System.ClientModel.Primitives.IJsonModel<OpenAI.ContainerSkill>, System.ClientModel.Primitives.IPersistableModel<OpenAI.ContainerSkill>
    {
        internal ContainerSkill() { }
        protected virtual OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.ContainerSkill System.ClientModel.Primitives.IJsonModel<OpenAI.ContainerSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.ContainerSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.ContainerSkill System.ClientModel.Primitives.IPersistableModel<OpenAI.ContainerSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.ContainerSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.ContainerSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineSkillParam : OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillParam>, System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillParam>
    {
        public InlineSkillParam(string name, string description, OpenAI.InlineSkillSourceParam source) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public OpenAI.InlineSkillSourceParam Source { get { throw null; } set { } }
        protected override OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.InlineSkillParam System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.InlineSkillParam System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineSkillSourceParam : System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillSourceParam>, System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillSourceParam>
    {
        public InlineSkillSourceParam(string data) { }
        public string Data { get { throw null; } set { } }
        public string MediaType { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual OpenAI.InlineSkillSourceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual OpenAI.InlineSkillSourceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.InlineSkillSourceParam System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillSourceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.InlineSkillSourceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.InlineSkillSourceParam System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillSourceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillSourceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.InlineSkillSourceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MCPToolboxToolConnectorId
    {
        ConnectorDropbox = 0,
        ConnectorGmail = 1,
        ConnectorGooglecalendar = 2,
        ConnectorGoogledrive = 3,
        ConnectorMicrosoftteams = 4,
        ConnectorOutlookcalendar = 5,
        ConnectorOutlookemail = 6,
        ConnectorSharepoint = 7,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RealtimeClientEventType : System.IEquatable<OpenAI.RealtimeClientEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RealtimeClientEventType(string value) { throw null; }
        public static OpenAI.RealtimeClientEventType ConversationItemCreate { get { throw null; } }
        public static OpenAI.RealtimeClientEventType ConversationItemDelete { get { throw null; } }
        public static OpenAI.RealtimeClientEventType ConversationItemRetrieve { get { throw null; } }
        public static OpenAI.RealtimeClientEventType ConversationItemTruncate { get { throw null; } }
        public static OpenAI.RealtimeClientEventType InputAudioBufferAppend { get { throw null; } }
        public static OpenAI.RealtimeClientEventType InputAudioBufferClear { get { throw null; } }
        public static OpenAI.RealtimeClientEventType InputAudioBufferCommit { get { throw null; } }
        public static OpenAI.RealtimeClientEventType OutputAudioBufferClear { get { throw null; } }
        public static OpenAI.RealtimeClientEventType ResponseCancel { get { throw null; } }
        public static OpenAI.RealtimeClientEventType ResponseCreate { get { throw null; } }
        public static OpenAI.RealtimeClientEventType SessionAvatarConnect { get { throw null; } }
        public static OpenAI.RealtimeClientEventType SessionUpdate { get { throw null; } }
        public bool Equals(OpenAI.RealtimeClientEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(OpenAI.RealtimeClientEventType left, OpenAI.RealtimeClientEventType right) { throw null; }
        public static implicit operator OpenAI.RealtimeClientEventType (string value) { throw null; }
        public static implicit operator OpenAI.RealtimeClientEventType? (string value) { throw null; }
        public static bool operator !=(OpenAI.RealtimeClientEventType left, OpenAI.RealtimeClientEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkillReferenceParam : OpenAI.ContainerSkill, System.ClientModel.Primitives.IJsonModel<OpenAI.SkillReferenceParam>, System.ClientModel.Primitives.IPersistableModel<OpenAI.SkillReferenceParam>
    {
        public SkillReferenceParam(string skillId) { }
        public string SkillId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override OpenAI.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.SkillReferenceParam System.ClientModel.Primitives.IJsonModel<OpenAI.SkillReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.SkillReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.SkillReferenceParam System.ClientModel.Primitives.IPersistableModel<OpenAI.SkillReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.SkillReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.SkillReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum WebSearchToolSearchContextSize
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
}
