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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GenerateAgent(Azure.AI.Projects.Agents.GenerateVoiceAgentRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GenerateAgent(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GenerateAgent(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> GenerateAgentAsync(Azure.AI.Projects.Agents.GenerateVoiceAgentRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> GenerateAgentAsync(System.BinaryData body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GenerateAgentAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.ProjectsAgentRecord>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Projects.Agents.AgentOptimizationJobCandidates GetAgentOptimizationJobCandidatesClient() { throw null; }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual Azure.AI.Projects.Agents.BetaVoiceAgentsConversations GetBetaVoiceAgentEndpointConversations() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual Azure.AI.Projects.Agents.BetaVoiceAgentsTelephony GetBetaVoiceAgentTelephony() { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class AgentHarness : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentHarness>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentHarness>
    {
        internal AgentHarness() { }
        protected virtual Azure.AI.Projects.Agents.AgentHarness JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentHarness PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentHarness System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentHarness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentHarness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentHarness System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentHarness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentHarness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentHarness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class AgentOptimizationAgentCandidateOutput : Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>
    {
        internal AgentOptimizationAgentCandidateOutput() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationMutation> Mutations { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationBaselineAgentConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>
    {
        public AgentOptimizationBaselineAgentConfiguration() { }
        public string CurrentModel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationSkill> Skills { get { throw null; } }
        public string SystemPrompt { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Chat.ChatTool> Tools { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationCandidate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>
    {
        internal AgentOptimizationCandidate() { }
        public string AgentVersion { get { throw null; } }
        public string CandidateId { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation Evaluation { get { throw null; } }
        public string JobId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput Output { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo Promotion { get { throw null; } }
        public string Rationale { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus Status { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentOptimizationCandidate (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationCandidateEvaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>
    {
        internal AgentOptimizationCandidateEvaluation() { }
        public System.TimeSpan? AvgLatencyMs { get { throw null; } }
        public double? AvgTokens { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string EvalId { get { throw null; } }
        public string EvalRunId { get { throw null; } }
        public double? Score { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentOptimizationCandidateExpand : System.IEquatable<Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentOptimizationCandidateExpand(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand Mutations { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand left, Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand left, Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class AgentOptimizationCandidateOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>
    {
        internal AgentOptimizationCandidateOutput() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationCandidatePromotionInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>
    {
        internal AgentOptimizationCandidatePromotionInfo() { }
        public Azure.AI.Projects.Agents.AgentReference PromotedAgent { get { throw null; } }
        public System.DateTimeOffset PromotedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationCandidateSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>
    {
        public AgentOptimizationCandidateSearchConfiguration() { }
        public int? MaxCandidates { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentOptimizationCandidateStatus : System.IEquatable<Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentOptimizationCandidateStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus Evaluating { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus Generating { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus left, Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus left, Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentOptimizationConfiguration : Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>
    {
        public AgentOptimizationConfiguration(Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration evaluationConfiguration, Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration candidateSearchConfiguration, Azure.AI.Projects.Agents.AgentOptimizationSpace agentOptimizationSpace) { }
        public Azure.AI.Projects.Agents.AgentOptimizationSpace AgentOptimizationSpace { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration BaselineAgentConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration CandidateSearchConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration EvaluationConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationGoal? Goal { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationConfigurationBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>
    {
        internal AgentOptimizationConfigurationBase() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationCostEstimate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>
    {
        internal AgentOptimizationCostEstimate() { }
        public Azure.AI.Projects.Agents.AgentOptimizationStageEstimate ByStage { get { throw null; } }
        public string Currency { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationEstimateBand Total { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationStage> UnpricedStages { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCostEstimate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationCostEstimate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationCostEstimate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationCostEstimate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationCostEstimate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationEstimateBand : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>
    {
        internal AgentOptimizationEstimateBand() { }
        public double Ceiling { get { throw null; } }
        public double Low { get { throw null; } }
        public double Typical { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateBand JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateBand PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateBand System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateBand System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateBand>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationEstimateInputs : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>
    {
        public AgentOptimizationEstimateInputs(Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration optimizationModelConfiguration, Azure.AI.Projects.Agents.AgentOptimizationConfiguration optimizationConfiguration) { }
        public Azure.AI.Projects.Agents.AgentOptimizationConfiguration OptimizationConfiguration { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration OptimizationModelConfiguration { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration TargetConfiguration { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs agentOptimizationEstimateInputs) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationEstimateResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>
    {
        internal AgentOptimizationEstimateResult() { }
        public Azure.AI.Projects.Agents.AgentOptimizationStageEstimate CallCounts { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCostEstimate Cost { get { throw null; } }
        public System.DateTimeOffset? PricesAsOf { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.AgentOptimizationEstimateResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEstimateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEstimateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationEvaluationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>
    {
        public AgentOptimizationEvaluationConfiguration(Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet trainingSet, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationEvaluator> evaluators, Azure.AI.Projects.Agents.EvaluationModelConfiguration evaluationModel) { }
        public Azure.AI.Projects.Agents.EvaluationModelConfiguration EvaluationModel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationEvaluator> Evaluators { get { throw null; } }
        public int? MaxConcurrentAgentRuns { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet TrainingSet { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet ValidationSet { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationEvaluationSet : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>
    {
        internal AgentOptimizationEvaluationSet() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationEvaluator : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>
    {
        public AgentOptimizationEvaluator(string name) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitializationParameters { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluator JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationEvaluator PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluator System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationEvaluator System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationEvaluator>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationFoundryAgentTargetConfiguration : Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>
    {
        public AgentOptimizationFoundryAgentTargetConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentOptimizationGoal : System.IEquatable<Azure.AI.Projects.Agents.AgentOptimizationGoal>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentOptimizationGoal(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationGoal ImproveQuality { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentOptimizationGoal other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentOptimizationGoal left, Azure.AI.Projects.Agents.AgentOptimizationGoal right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationGoal (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationGoal? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentOptimizationGoal left, Azure.AI.Projects.Agents.AgentOptimizationGoal right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentOptimizationInstructionsMutation : Azure.AI.Projects.Agents.AgentOptimizationMutation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>
    {
        internal AgentOptimizationInstructionsMutation() { }
        public string Value { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJob>
    {
        public AgentOptimizationJob(Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration optimizationModelConfiguration, Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase optimizationConfiguration) { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase OptimizationConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration OptimizationModelConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationJobResult Result { get { throw null; } }
        public System.TimeSpan RunDurationMs { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentsJobStatus Status { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration TargetConfiguration { get { throw null; } set { } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Warnings { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationJob FromClientResult(System.ClientModel.ClientResult result) { throw null; }
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
    public partial class AgentOptimizationJobCandidates
    {
        protected AgentOptimizationJobCandidates() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult GetCandidate(string jobId, string candidateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate> GetCandidate(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetCandidateAsync(string jobId, string candidateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate>> GetCandidateAsync(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate> GetCandidates(string jobId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand> expand = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.CollectionResult GetCandidates(string jobId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand> expand, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate> GetCandidatesAsync(string jobId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand> expand = null, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.Primitives.AsyncCollectionResult GetCandidatesAsync(string jobId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationCandidateExpand> expand, int? limit, string order, string after, string before, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult PromoteCandidate(string jobId, string candidateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate> PromoteCandidate(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> PromoteCandidateAsync(string jobId, string candidateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationCandidate>> PromoteCandidateAsync(string jobId, string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentOptimizationJobLatency : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>
    {
        internal AgentOptimizationJobLatency() { }
        public System.TimeSpan AvgLatencyMs { get { throw null; } }
        public long CallCount { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationStage Stage { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobLatency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobLatency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobLatency System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobLatency System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobLatency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationJobResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobResult>
    {
        internal AgentOptimizationJobResult() { }
        public Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary CandidateSummary { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationJobLatency> LatencyMetrics { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationTerminationReason? TerminationReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage> TokenUsage { get { throw null; } }
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
        public virtual System.ClientModel.ClientResult Cancel(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob> Cancel(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CancelAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob>> CancelAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.ClientModel.Primitives.OperationResult Create(bool waitUntilCompleted, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, Azure.AI.Projects.Agents.AgentOptimizationJob job, string operationId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0006")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.Primitives.OperationResult> CreateAsync(bool waitUntilCompleted, System.ClientModel.BinaryContent content, string operationId = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult Delete(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult> Estimate(Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult Estimate(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationEstimateResult>> EstimateAsync(Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs inputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> EstimateAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult Get(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob> Get(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.AgentOptimizationJob> GetAll(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.AgentsJobStatus? status = default(Azure.AI.Projects.Agents.AgentsJobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.AgentOptimizationJob> GetAllAsync(int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, Azure.AI.Projects.Agents.AgentsJobStatus? status = default(Azure.AI.Projects.Agents.AgentsJobStatus?), string agentName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAsync(string jobId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.AgentOptimizationJob>> GetAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentOptimizationJobTokenUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>
    {
        internal AgentOptimizationJobTokenUsage() { }
        public long? CachedTokens { get { throw null; } }
        public long? InputTokens { get { throw null; } }
        public string Model { get { throw null; } }
        public long? OutputTokens { get { throw null; } }
        public long? ReasoningTokens { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationStage Stage { get { throw null; } }
        public long? TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>
    {
        public AgentOptimizationModelConfiguration(string model) { }
        public string Model { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationModelMutation : Azure.AI.Projects.Agents.AgentOptimizationMutation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>
    {
        internal AgentOptimizationModelMutation() { }
        public string Value { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationModelMutation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationModelMutation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationModelMutation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationMutation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>
    {
        internal AgentOptimizationMutation() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationMutation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationMutation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationMutation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationMutation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationMutation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationPromptCandidateOutput : Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>
    {
        internal AgentOptimizationPromptCandidateOutput() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationMutation> Mutations { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationResultCandidateSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>
    {
        internal AgentOptimizationResultCandidateSummary() { }
        public string BaselineId { get { throw null; } }
        public double? BaselineScore { get { throw null; } }
        public string BestId { get { throw null; } }
        public double? BestScore { get { throw null; } }
        public int CompletedCandidateCount { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo LatestPromotedCandidate { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>
    {
        public AgentOptimizationSkill(string name, string description) { }
        public string Body { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationSkillsMutation : Azure.AI.Projects.Agents.AgentOptimizationMutation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>
    {
        internal AgentOptimizationSkillsMutation() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationSkill> Value { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationSpace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>
    {
        public AgentOptimizationSpace() { }
        public System.Collections.Generic.IList<string> ModelSearchSpace { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TargetAttribute> TargetAttributes { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationSpace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationSpace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationSpace System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationSpace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationSpace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentOptimizationStage : System.IEquatable<Azure.AI.Projects.Agents.AgentOptimizationStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentOptimizationStage(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationStage Agent { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationStage Evaluation { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationStage Optimization { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentOptimizationStage other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentOptimizationStage left, Azure.AI.Projects.Agents.AgentOptimizationStage right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationStage (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationStage? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentOptimizationStage left, Azure.AI.Projects.Agents.AgentOptimizationStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentOptimizationStageEstimate : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>
    {
        internal AgentOptimizationStageEstimate() { }
        public Azure.AI.Projects.Agents.AgentOptimizationEstimateBand Agent { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationEstimateBand Evaluation { get { throw null; } }
        public Azure.AI.Projects.Agents.AgentOptimizationEstimateBand Optimization { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationStageEstimate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationStageEstimate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationStageEstimate System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationStageEstimate System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationStageEstimate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationTargetCompletionDatasetReferenceDataSource : Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>
    {
        public AgentOptimizationTargetCompletionDatasetReferenceDataSource(string name, string version) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationTargetCompletionDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>
    {
        internal AgentOptimizationTargetCompletionDataSource() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationTargetCompletionEvaluationSet : Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>
    {
        public AgentOptimizationTargetCompletionEvaluationSet(Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource source) { }
        public Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationTargetCompletionInlineDataSource : Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>
    {
        public AgentOptimizationTargetCompletionInlineDataSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase> testCases) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase> TestCases { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationTargetCompletionTestCase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>
    {
        public AgentOptimizationTargetCompletionTestCase(string query) { }
        public string GroundTruth { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationTargetConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>
    {
        internal AgentOptimizationTargetConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentOptimizationTerminationReason : System.IEquatable<Azure.AI.Projects.Agents.AgentOptimizationTerminationReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentOptimizationTerminationReason(string value) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTerminationReason BudgetExhausted { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationTerminationReason CandidateScreeningStalled { get { throw null; } }
        public static Azure.AI.Projects.Agents.AgentOptimizationTerminationReason Completed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.AgentOptimizationTerminationReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.AgentOptimizationTerminationReason left, Azure.AI.Projects.Agents.AgentOptimizationTerminationReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationTerminationReason (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.AgentOptimizationTerminationReason? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.AgentOptimizationTerminationReason left, Azure.AI.Projects.Agents.AgentOptimizationTerminationReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentOptimizationToolsMutation : Azure.AI.Projects.Agents.AgentOptimizationMutation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>
    {
        internal AgentOptimizationToolsMutation() { }
        public System.Collections.Generic.IList<OpenAI.Chat.ChatTool> Value { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationMutation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationToolsMutation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationToolsMutation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationToolsMutation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationUserConversationSimulationDatasetReferenceDataSource : Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>
    {
        public AgentOptimizationUserConversationSimulationDatasetReferenceDataSource(string name, string version) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentOptimizationUserConversationSimulationDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>
    {
        internal AgentOptimizationUserConversationSimulationDataSource() { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationUserConversationSimulationEvaluationSet : Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>
    {
        public AgentOptimizationUserConversationSimulationEvaluationSet(Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource source) { }
        public Azure.AI.Projects.Agents.UserConversationSimulationConfiguration DefaultSimulationConfiguration { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOptimizationUserConversationSimulationInlineDataSource : Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>
    {
        public AgentOptimizationUserConversationSimulationInlineDataSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.UserConversationSimulationTestCase> testCases) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.UserConversationSimulationTestCase> TestCases { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentReference>
    {
        internal AgentReference() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.AgentReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.AgentReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.AgentReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.AgentReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.AgentReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.AgentReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResult> Upload(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.SessionFileWriteResult>> UploadAsync(string sessionStoragePath, string localPath, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual System.ClientModel.ClientResult InvokeLatestToolboxMcp(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> InvokeLatestToolboxMcp(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> request, string contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> InvokeLatestToolboxMcpAsync(string name, System.ClientModel.BinaryContent content, string contentType, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> InvokeLatestToolboxMcpAsync(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> request, string contentType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BetaVoiceAgentsConversations
    {
        protected BetaVoiceAgentsConversations() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult DeleteAgentConversation(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentConversation(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentConversationAsync(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentConversationAsync(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversation(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceConversation> GetAgentConversation(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationAsync(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceConversation>> GetAgentConversationAsync(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationAudio(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceRecording> GetAgentConversationAudio(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationAudioAsync(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceRecording>> GetAgentConversationAudioAsync(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationAudioContent(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetAgentConversationAudioContent(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationAudioContentAsync(string agentName, string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetAgentConversationAudioContentAsync(string agentName, string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationAudioItem(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceAudioItem> GetAgentConversationAudioItem(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationAudioItemAsync(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceAudioItem>> GetAgentConversationAudioItemAsync(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationAudioItemContent(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetAgentConversationAudioItemContent(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationAudioItemContentAsync(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetAgentConversationAudioItemContentAsync(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationGeneratedAudioItem(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem> GetAgentConversationGeneratedAudioItem(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationGeneratedAudioItemAsync(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>> GetAgentConversationGeneratedAudioItemAsync(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationGeneratedAudioItemContent(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<System.BinaryData> GetAgentConversationGeneratedAudioItemContent(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationGeneratedAudioItemContentAsync(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.BinaryData>> GetAgentConversationGeneratedAudioItemContentAsync(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationItem(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public virtual System.ClientModel.ClientResult<OpenAI.Realtime.RealtimeItem> GetAgentConversationItem(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Realtime.RealtimeItem>> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Realtime.RealtimeItem> GetAgentConversationItems(string agentName, string conversationId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Realtime.RealtimeItem> GetAgentConversationItemsAsync(string agentName, string conversationId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentConversationResponse(string agentName, string conversationId, string responseId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceResult> GetAgentConversationResponse(string agentName, string conversationId, string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentConversationResponseAsync(string agentName, string conversationId, string responseId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.VoiceResult>> GetAgentConversationResponseAsync(string agentName, string conversationId, string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<OpenAI.Realtime.RealtimeItem> GetAgentConversationResponseItems(string agentName, string conversationId, string responseId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<OpenAI.Realtime.RealtimeItem> GetAgentConversationResponseItemsAsync(string agentName, string conversationId, string responseId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.VoiceResult> GetAgentConversationResponses(string agentName, string conversationId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.VoiceResult> GetAgentConversationResponsesAsync(string agentName, string conversationId, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.VoiceConversation> GetAgentConversations(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.VoiceConversation> GetAgentConversationsAsync(string agentName, int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class BetaVoiceAgentsTelephony
    {
        protected BetaVoiceAgentsTelephony() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob> CancelTelephonyCallJob(string agentName, string callJobId, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob>> CancelTelephonyCallJobAsync(string agentName, string callJobId, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyBinding> CreateTelephonyBinding(string agentName, Azure.AI.Projects.Agents.CreateTelephonyBindingContent telephonyBinding, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyBinding>> CreateTelephonyBindingAsync(string agentName, Azure.AI.Projects.Agents.CreateTelephonyBindingContent telephonyBinding, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob> CreateTelephonyCallJob(string agentName, string idempotencyKey, Azure.AI.Projects.Agents.CreateTelephonyCallJobContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob>> CreateTelephonyCallJobAsync(string agentName, string idempotencyKey, Azure.AI.Projects.Agents.CreateTelephonyCallJobContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteTelephonyBinding(string agentName, string bindingId, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord> EndTelephonyCall(string agentName, string callId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord>> EndTelephonyCallAsync(string agentName, string callId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyBinding> GetTelephonyBinding(string agentName, string bindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyBinding>> GetTelephonyBindingAsync(string agentName, string bindingId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.TelephonyBindingListItem> GetTelephonyBindings(string agentName, Azure.AI.Projects.Agents.TelephonyProvider? provider = default(Azure.AI.Projects.Agents.TelephonyProvider?), Azure.AI.Projects.Agents.TelephonyBindingStatus? status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.TelephonyBindingListItem> GetTelephonyBindingsAsync(string agentName, Azure.AI.Projects.Agents.TelephonyProvider? provider = default(Azure.AI.Projects.Agents.TelephonyProvider?), Azure.AI.Projects.Agents.TelephonyBindingStatus? status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord> GetTelephonyCall(string agentName, string callId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord>> GetTelephonyCallAsync(string agentName, string callId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob> GetTelephonyCallJob(string agentName, string callJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallJob>> GetTelephonyCallJobAsync(string agentName, string callJobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.Agents.TelephonyCallSummary> GetTelephonyCalls(string agentName, Azure.AI.Projects.Agents.TelephonyProvider? provider = default(Azure.AI.Projects.Agents.TelephonyProvider?), Azure.AI.Projects.Agents.TelephonyCallStatus? status = default(Azure.AI.Projects.Agents.TelephonyCallStatus?), System.DateTimeOffset? startedAfter = default(System.DateTimeOffset?), System.DateTimeOffset? startedBefore = default(System.DateTimeOffset?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.Agents.TelephonyCallSummary> GetTelephonyCallsAsync(string agentName, Azure.AI.Projects.Agents.TelephonyProvider? provider = default(Azure.AI.Projects.Agents.TelephonyProvider?), Azure.AI.Projects.Agents.TelephonyCallStatus? status = default(Azure.AI.Projects.Agents.TelephonyCallStatus?), System.DateTimeOffset? startedAfter = default(System.DateTimeOffset?), System.DateTimeOffset? startedBefore = default(System.DateTimeOffset?), int? limit = default(int?), Azure.AI.Projects.Agents.AgentListOrder? order = default(Azure.AI.Projects.Agents.AgentListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyTransferTargets> GetTelephonyTransferTargets(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyTransferTargets>> GetTelephonyTransferTargetsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyTransferTargets> ReplaceTelephonyTransferTargets(string agentName, string ifMatch, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelephonyTransferTarget> transferTargets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyTransferTargets>> ReplaceTelephonyTransferTargetsAsync(string agentName, string ifMatch, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelephonyTransferTarget> transferTargets, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord> TransferTelephonyCall(string agentName, string callId, string target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.Agents.TelephonyCallRecord>> TransferTelephonyCallAsync(string agentName, string callId, string target, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateTelephonyBinding(string agentName, string bindingId, string ifMatch, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
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
    public partial class BrowserAutomationToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>
    {
        public BrowserAutomationToolboxTool(Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions toolParameters) { }
        public Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions ToolParameters { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ToolboxTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ToolboxTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.BrowserAutomationToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.BrowserAutomationToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.BrowserAutomationToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CallableToolAllowedCaller
    {
        Direct = 0,
        Programmatic = 1,
    }
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Projects.Agents.AgentAdministrationClient GetProjectAgentsClient(this System.ClientModel.Primitives.ClientConnectionProvider connectionProvider, System.Uri endpoint = null, Azure.AI.Projects.Agents.AgentAdministrationClientOptions options = null) { throw null; }
        public sealed partial class <G>$EE9D7A1C67932FB454531401B8375DE4
        {
            internal <G>$EE9D7A1C67932FB454531401B8375DE4() { }
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
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
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
    public abstract partial class ContainerSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerSkill>
    {
        internal ContainerSkill() { }
        protected virtual Azure.AI.Projects.Agents.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ContainerSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContainerSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ContainerSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContainerSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ContentFilterConfiguration>
    {
        public ContentFilterConfiguration(string raiPolicyName) { }
        public Azure.AI.Projects.Agents.RaiInvocationModeration InvocationsModeration { get { throw null; } set { } }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CreateTeamsPhoneExtensibilityTelephonyBindingContent : Azure.AI.Projects.Agents.CreateTelephonyBindingContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>
    {
        public CreateTeamsPhoneExtensibilityTelephonyBindingContent(string connectionName, string resourceAccountObjectId) { }
        public string PhoneNumber { get { throw null; } set { } }
        public string ResourceAccountObjectId { get { throw null; } }
        protected override Azure.AI.Projects.Agents.CreateTelephonyBindingContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.CreateTelephonyBindingContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class CreateTelephonyBindingContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>
    {
        internal CreateTelephonyBindingContent() { }
        public string ConnectionName { get { throw null; } }
        public string Label { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.CreateTelephonyBindingContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.CreateTelephonyBindingContent createTelephonyBindingContent) { throw null; }
        protected virtual Azure.AI.Projects.Agents.CreateTelephonyBindingContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateTelephonyBindingContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateTelephonyBindingContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyBindingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CreateTelephonyCallJobContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>
    {
        public CreateTelephonyCallJobContent(Azure.AI.Projects.Agents.TelephonyOutboundDestination destination, string connectionName, string source) { }
        public string ConnectionName { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyOutboundDestination Destination { get { throw null; } }
        public string Purpose { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy RetryPolicy { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelephonyCallJobSchedule Schedule { get { throw null; } set { } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StructuredInputs { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.CreateTelephonyCallJobContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Projects.Agents.CreateTelephonyCallJobContent createTelephonyCallJobContent) { throw null; }
        protected virtual Azure.AI.Projects.Agents.CreateTelephonyCallJobContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateTelephonyCallJobContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateTelephonyCallJobContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTelephonyCallJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class CreateTwilioTelephonyBindingContent : Azure.AI.Projects.Agents.CreateTelephonyBindingContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>
    {
        public CreateTwilioTelephonyBindingContent(string connectionName, string phoneNumber) { }
        public string PhoneNumber { get { throw null; } }
        protected override Azure.AI.Projects.Agents.CreateTelephonyBindingContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.CreateTelephonyBindingContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeclarativeAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.DeclarativeAgentDefinition>
    {
        public DeclarativeAgentDefinition(string model) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public Azure.AI.Projects.Agents.AgentHarness Harness { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.SkillReference> Skills { get { throw null; } }
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
    public partial class EvaluationAzureStandardVoiceModelConfiguration : Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>
    {
        public EvaluationAzureStandardVoiceModelConfiguration(string name) { }
        public string Name { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>
    {
        public EvaluationModelConfiguration(string model) { }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ModelSamplingParams SamplingParams { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration VoiceModel { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.EvaluationModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.EvaluationModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.EvaluationModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.EvaluationModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EvaluationVoiceModelConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>
    {
        internal EvaluationVoiceModelConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class GenerateVoiceAgentRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>
    {
        public GenerateVoiceAgentRequest(string name) { }
        public string Description { get { throw null; } set { } }
        public bool? Draft { get { throw null; } set { } }
        public string Goal { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceModelType? ModelType { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentTool> Tools { get { throw null; } }
        public string UseCase { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.GenerateVoiceAgentRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.GenerateVoiceAgentRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.GenerateVoiceAgentRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.GenerateVoiceAgentRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GenerateVoiceAgentRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class GitHubCopilotHarness : Azure.AI.Projects.Agents.AgentHarness, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>
    {
        public GitHubCopilotHarness() { }
        protected override Azure.AI.Projects.Agents.AgentHarness JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentHarness PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.GitHubCopilotHarness System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.GitHubCopilotHarness System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.GitHubCopilotHarness>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class InlineSkillParam : Azure.AI.Projects.Agents.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillParam>
    {
        public InlineSkillParam(string name, string description, Azure.AI.Projects.Agents.InlineSkillSourceParam source) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.InlineSkillSourceParam Source { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.InlineSkillParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.InlineSkillParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineSkillSourceParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>
    {
        public InlineSkillSourceParam(string data) { }
        public string Data { get { throw null; } set { } }
        public string MediaType { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.InlineSkillSourceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.InlineSkillSourceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.InlineSkillSourceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.InlineSkillSourceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.InlineSkillSourceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
        public System.BinaryData AllowedTools { get { throw null; } set { } }
        public string Authorization { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.McpToolConnectorId? ConnectorId { get { throw null; } set { } }
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
            public string ProjectConnectionId { get { throw null; } set { } }
            public static partial class <M>$057BAEB40536DD92FB57E20F2D1CDCDE
            {
                public static void <Extension>$(OpenAI.Responses.McpTool mcpTool) { }
            }
        }
    }
    public partial class ModelSamplingParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ModelSamplingParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ModelSamplingParams>
    {
        public ModelSamplingParams() { }
        public int? MaxCompletionTokens { get { throw null; } set { } }
        public int? Seed { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public float? TopP { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.ModelSamplingParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ModelSamplingParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ModelSamplingParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ModelSamplingParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ModelSamplingParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ModelSamplingParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ModelSamplingParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ModelSamplingParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ModelSamplingParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class OptimizationContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationContext>
    {
        internal OptimizationContext() { }
        protected virtual Azure.AI.Projects.Agents.OptimizationContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.OptimizationContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.OptimizationContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.OptimizationContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.OptimizationContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.OptimizationContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset? StoppedOn { get { throw null; } }
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
        public static Azure.AI.Projects.Agents.ProjectsAgentKind Voice { get { throw null; } }
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
        public static Azure.AI.Projects.Agents.ProjectsAgentProtocol Voice { get { throw null; } }
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
        public Azure.AI.Projects.Agents.AgentState ConfigurationState { get { throw null; } }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.AgentHarness AgentHarness(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentIdentity AgentIdentity(string principalId = null, string clientId = null, Azure.AI.Projects.Agents.AgentIdentityStatus? status = default(Azure.AI.Projects.Agents.AgentIdentityStatus?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentManifestOptions AgentManifestOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentObjectVersions AgentObjectVersions(Azure.AI.Projects.Agents.ProjectsAgentVersion latest = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationAgentCandidateOutput AgentOptimizationAgentCandidateOutput(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationMutation> mutations = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration AgentOptimizationBaselineAgentConfiguration(string systemPrompt = null, string currentModel = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationSkill> skills = null, System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatTool> tools = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidate AgentOptimizationCandidate(string candidateId = null, string jobId = null, string name = null, Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus status = default(Azure.AI.Projects.Agents.AgentOptimizationCandidateStatus), System.DateTimeOffset startedOn = default(System.DateTimeOffset), Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput output = null, string rationale = null, string agentVersion = null, Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation evaluation = null, Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo promotion = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateEvaluation AgentOptimizationCandidateEvaluation(double? score = default(double?), double? avgTokens = default(double?), System.TimeSpan? avgLatencyMs = default(System.TimeSpan?), string evalId = null, string evalRunId = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateOutput AgentOptimizationCandidateOutput(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo AgentOptimizationCandidatePromotionInfo(System.DateTimeOffset promotedOn = default(System.DateTimeOffset), Azure.AI.Projects.Agents.AgentReference promotedAgent = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration AgentOptimizationCandidateSearchConfiguration(int? maxCandidates = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationConfiguration AgentOptimizationConfiguration(Azure.AI.Projects.Agents.AgentOptimizationGoal? goal = default(Azure.AI.Projects.Agents.AgentOptimizationGoal?), Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration evaluationConfiguration = null, Azure.AI.Projects.Agents.AgentOptimizationCandidateSearchConfiguration candidateSearchConfiguration = null, Azure.AI.Projects.Agents.AgentOptimizationBaselineAgentConfiguration baselineAgentConfiguration = null, Azure.AI.Projects.Agents.AgentOptimizationSpace agentOptimizationSpace = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase AgentOptimizationConfigurationBase(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationCostEstimate AgentOptimizationCostEstimate(string currency = null, Azure.AI.Projects.Agents.AgentOptimizationEstimateBand total = null, Azure.AI.Projects.Agents.AgentOptimizationStageEstimate byStage = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationStage> unpricedStages = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEstimateBand AgentOptimizationEstimateBand(double low = 0, double typical = 0, double ceiling = 0) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEstimateInputs AgentOptimizationEstimateInputs(Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration targetConfiguration = null, Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration optimizationModelConfiguration = null, Azure.AI.Projects.Agents.AgentOptimizationConfiguration optimizationConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEstimateResult AgentOptimizationEstimateResult(Azure.AI.Projects.Agents.AgentOptimizationStageEstimate callCounts = null, Azure.AI.Projects.Agents.AgentOptimizationCostEstimate cost = null, System.DateTimeOffset? pricesAsOf = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEvaluationConfiguration AgentOptimizationEvaluationConfiguration(Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet trainingSet = null, Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet validationSet = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationEvaluator> evaluators = null, Azure.AI.Projects.Agents.EvaluationModelConfiguration evaluationModel = null, int? maxConcurrentAgentRuns = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEvaluationSet AgentOptimizationEvaluationSet(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationEvaluator AgentOptimizationEvaluator(string name = null, string version = null, System.Collections.Generic.IDictionary<string, System.BinaryData> initializationParameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationFoundryAgentTargetConfiguration AgentOptimizationFoundryAgentTargetConfiguration(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationInstructionsMutation AgentOptimizationInstructionsMutation(string value = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationJobLatency AgentOptimizationJobLatency(Azure.AI.Projects.Agents.AgentOptimizationStage stage = default(Azure.AI.Projects.Agents.AgentOptimizationStage), string model = null, System.TimeSpan avgLatencyMs = default(System.TimeSpan), long callCount = (long)0) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationJobResult AgentOptimizationJobResult(Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary candidateSummary = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage> tokenUsage = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationJobLatency> latencyMetrics = null, Azure.AI.Projects.Agents.AgentOptimizationTerminationReason? terminationReason = default(Azure.AI.Projects.Agents.AgentOptimizationTerminationReason?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationJobTokenUsage AgentOptimizationJobTokenUsage(Azure.AI.Projects.Agents.AgentOptimizationStage stage = default(Azure.AI.Projects.Agents.AgentOptimizationStage), string model = null, long? inputTokens = default(long?), long? outputTokens = default(long?), long? totalTokens = default(long?), long? cachedTokens = default(long?), long? reasoningTokens = default(long?)) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationModelConfiguration AgentOptimizationModelConfiguration(string model = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationModelMutation AgentOptimizationModelMutation(string value = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationMutation AgentOptimizationMutation(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationPromptCandidateOutput AgentOptimizationPromptCandidateOutput(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationMutation> mutations = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationResultCandidateSummary AgentOptimizationResultCandidateSummary(int completedCandidateCount = 0, string baselineId = null, string bestId = null, double? baselineScore = default(double?), double? bestScore = default(double?), Azure.AI.Projects.Agents.AgentOptimizationCandidatePromotionInfo latestPromotedCandidate = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationSkill AgentOptimizationSkill(string name = null, string description = null, string body = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationSkillsMutation AgentOptimizationSkillsMutation(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationSkill> value = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationSpace AgentOptimizationSpace(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TargetAttribute> targetAttributes = null, System.Collections.Generic.IEnumerable<string> modelSearchSpace = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationStageEstimate AgentOptimizationStageEstimate(Azure.AI.Projects.Agents.AgentOptimizationEstimateBand agent = null, Azure.AI.Projects.Agents.AgentOptimizationEstimateBand evaluation = null, Azure.AI.Projects.Agents.AgentOptimizationEstimateBand optimization = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDatasetReferenceDataSource AgentOptimizationTargetCompletionDatasetReferenceDataSource(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource AgentOptimizationTargetCompletionDataSource(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionEvaluationSet AgentOptimizationTargetCompletionEvaluationSet(Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionDataSource source = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionInlineDataSource AgentOptimizationTargetCompletionInlineDataSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase> testCases = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetCompletionTestCase AgentOptimizationTargetCompletionTestCase(string query = null, string groundTruth = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationTargetConfiguration AgentOptimizationTargetConfiguration(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationToolsMutation AgentOptimizationToolsMutation(System.Collections.Generic.IEnumerable<OpenAI.Chat.ChatTool> value = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDatasetReferenceDataSource AgentOptimizationUserConversationSimulationDatasetReferenceDataSource(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource AgentOptimizationUserConversationSimulationDataSource(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationEvaluationSet AgentOptimizationUserConversationSimulationEvaluationSet(Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationDataSource source = null, Azure.AI.Projects.Agents.UserConversationSimulationConfiguration defaultSimulationConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentOptimizationUserConversationSimulationInlineDataSource AgentOptimizationUserConversationSimulationInlineDataSource(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.UserConversationSimulationTestCase> testCases = null) { throw null; }
        public static Azure.AI.Projects.Agents.AgentReference AgentReference(string name = null, string version = null) { throw null; }
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
        public static Azure.AI.Projects.Agents.BrowserAutomationToolboxTool BrowserAutomationToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.BrowserAutomationToolOptions toolParameters = null) { throw null; }
        public static Azure.AI.Projects.Agents.CodeConfiguration CodeConfiguration(string runtime = null, System.Collections.Generic.IEnumerable<string> entryPoint = null, Azure.AI.Projects.Agents.CodeDependencyResolution dependencyResolution = default(Azure.AI.Projects.Agents.CodeDependencyResolution), string contentHash = null) { throw null; }
        public static Azure.AI.Projects.Agents.CodeInterpreterToolboxTool CodeInterpreterToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.CallableToolAllowedCaller> allowedCallers = null, System.BinaryData internalContainer = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContainerConfiguration ContainerConfiguration(string image = null, string registryConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContainerSkill ContainerSkill(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration(string raiPolicyName) { throw null; }
        public static Azure.AI.Projects.Agents.ContentFilterConfiguration ContentFilterConfiguration(string raiPolicyName = null, Azure.AI.Projects.Agents.RaiInvocationModeration invocationsModeration = null) { throw null; }
        public static Azure.AI.Projects.Agents.CreateAgentVersionFromManifestRequest CreateAgentVersionFromManifestRequest(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.CreateTeamsPhoneExtensibilityTelephonyBindingContent CreateTeamsPhoneExtensibilityTelephonyBindingContent(string connectionName = null, string label = null, string phoneNumber = null, string resourceAccountObjectId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.CreateTelephonyBindingContent CreateTelephonyBindingContent(string provider = null, string connectionName = null, string label = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.CreateTelephonyCallJobContent CreateTelephonyCallJobContent(Azure.AI.Projects.Agents.TelephonyOutboundDestination destination = null, string connectionName = null, string source = null, string purpose = null, System.Collections.Generic.IDictionary<string, System.BinaryData> structuredInputs = null, Azure.AI.Projects.Agents.TelephonyCallJobSchedule schedule = null, Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy retryPolicy = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.CreateTwilioTelephonyBindingContent CreateTwilioTelephonyBindingContent(string connectionName = null, string label = null, string phoneNumber = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.DeclarativeAgentDefinition DeclarativeAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, Azure.AI.Projects.Agents.AgentHarness harness = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.SkillReference> skills = null, float? temperature = default(float?), float? topP = default(float?), OpenAI.Responses.ResponseReasoningOptions reasoningOptions = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseTool> tools = null, System.BinaryData toolChoice = null, OpenAI.Responses.ResponseTextOptions textOptions = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> structuredInputs = null) { throw null; }
        public static Azure.AI.Projects.Agents.EntraAuthorizationScheme EntraAuthorizationScheme() { throw null; }
        public static Azure.AI.Projects.Agents.EvaluationAzureStandardVoiceModelConfiguration EvaluationAzureStandardVoiceModelConfiguration(string name = null, float? temperature = default(float?)) { throw null; }
        public static Azure.AI.Projects.Agents.EvaluationModelConfiguration EvaluationModelConfiguration(string model = null, Azure.AI.Projects.Agents.ModelSamplingParams samplingParams = null, Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration voiceModel = null) { throw null; }
        public static Azure.AI.Projects.Agents.EvaluationVoiceModelConfiguration EvaluationVoiceModelConfiguration(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ExternalAgentDefinition ExternalAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string otelAgentId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.FabricIQPreviewToolboxTool FabricIQPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string projectConnectionId = null, string serverLabel = null, System.Uri serverUri = null, System.BinaryData requireApprovalInternal = null) { throw null; }
        public static Azure.AI.Projects.Agents.FileSearchToolboxTool FileSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, long? maxNumResults = default(long?), object rankingOptions = null, System.BinaryData filters = null, System.Collections.Generic.IEnumerable<string> vectorStoreIds = null) { throw null; }
        public static Azure.AI.Projects.Agents.FixedRatioVersionSelectionRule FixedRatioVersionSelectionRule(string agentVersion = null, int trafficPercentage = 0) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.GenerateVoiceAgentRequest GenerateVoiceAgentRequest(string name = null, Azure.AI.Projects.Agents.VoiceModelType? modelType = default(Azure.AI.Projects.Agents.VoiceModelType?), string model = null, string useCase = null, string goal = null, string description = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentTool> tools = null, bool? draft = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.GitHubCopilotHarness GitHubCopilotHarness() { throw null; }
        public static Azure.AI.Projects.Agents.HeaderTelemetryEndpointAuth HeaderTelemetryEndpointAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.AI.Projects.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, Azure.AI.Projects.Agents.ContainerConfiguration containerConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ProtocolVersionRecord> versions = null, Azure.AI.Projects.Agents.CodeConfiguration codeConfiguration = null, Azure.AI.Projects.Agents.TelemetryConfig telemetryConfig = null, Azure.AI.Projects.Agents.SessionConfiguration sessionConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.InlineSkillParam InlineSkillParam(string name = null, string description = null, Azure.AI.Projects.Agents.InlineSkillSourceParam source = null) { throw null; }
        public static Azure.AI.Projects.Agents.InlineSkillSourceParam InlineSkillSourceParam(string data = null) { throw null; }
        public static Azure.AI.Projects.Agents.InvocationsProtocolConfiguration InvocationsProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration InvocationsWsProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.ManagedAgentIdentityBlueprintReference ManagedAgentIdentityBlueprintReference(string blueprintId = null) { throw null; }
        public static Azure.AI.Projects.Agents.McpProtocolConfiguration McpProtocolConfiguration() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Projects.Agents.MCPToolboxTool MCPToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string serverLabel = null, System.Uri serverUri = null, OpenAI.Responses.McpToolConnectorId? connectorId = default(OpenAI.Responses.McpToolConnectorId?), string tunnelId = null, string authorization = null, string serverDescription = null, System.Collections.Generic.IDictionary<string, string> headers = null, System.BinaryData allowedTools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.CallableToolAllowedCaller> allowedCallers = null, System.BinaryData requireApprovalInternal = null, bool? deferLoading = default(bool?), string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.Agents.ModelSamplingParams ModelSamplingParams(float? temperature = default(float?), float? topP = default(float?), int? seed = default(int?), int? maxCompletionTokens = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.OpenApiToolboxTool OpenApiToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, Azure.AI.Extensions.OpenAI.OpenApiFunctionDefinition functionDefinition = null) { throw null; }
        public static Azure.AI.Projects.Agents.OptimizationContext OptimizationContext(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null, string endpoint = null, Azure.AI.Projects.Agents.TelemetryTransportProtocol protocol = default(Azure.AI.Projects.Agents.TelemetryTransportProtocol)) { throw null; }
        public static Azure.AI.Projects.Agents.PatchAgentOptions PatchAgentOptions(Azure.AI.Projects.Agents.AgentEndpointConfiguration agentEndpoint = null, Azure.AI.Projects.Agents.AgentCard agentCard = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectAgentSession ProjectAgentSession(string agentSessionId = null, Azure.AI.Projects.Agents.VersionIndicator versionIndicator = null, Azure.AI.Projects.Agents.AgentSessionStatus status = default(Azure.AI.Projects.Agents.AgentSessionStatus), System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset lastAccessedOn = default(System.DateTimeOffset), System.DateTimeOffset expiresOn = default(System.DateTimeOffset), System.DateTimeOffset? stoppedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentDefinition ProjectsAgentDefinition(string kind = null, Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentRecord ProjectsAgentRecord(string id, string name) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentRecord ProjectsAgentRecord(string id = null, string name = null, Azure.AI.Projects.Agents.AgentState state = default(Azure.AI.Projects.Agents.AgentState)) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata, string id, string name, string version, string description, System.DateTimeOffset createdAt, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersion ProjectsAgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null, bool? draft = default(bool?), Azure.AI.Projects.Agents.AgentVersionStatus? status = default(Azure.AI.Projects.Agents.AgentVersionStatus?), Azure.AI.Projects.Agents.AgentIdentity instanceIdentity = null, Azure.AI.Projects.Agents.AgentIdentity blueprint = null, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference = null, string agentGuidInternal = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata, string description, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition) { throw null; }
        public static Azure.AI.Projects.Agents.ProjectsAgentVersionCreationOptions ProjectsAgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Projects.Agents.ProjectsAgentDefinition definition = null, Azure.AI.Projects.Agents.AgentBlueprintReference blueprintReference = null, Azure.AI.Projects.Agents.DigitalWorkerType? digitalWorkerType = default(Azure.AI.Projects.Agents.DigitalWorkerType?), bool? draft = default(bool?)) { throw null; }
        public static Azure.AI.Projects.Agents.PromptOptimizationConfiguration PromptOptimizationConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.OptimizationContext> context = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolConfiguration ProtocolConfiguration(Azure.AI.Projects.Agents.ActivityProtocolConfiguration activity = null, Azure.AI.Projects.Agents.ResponsesProtocolConfiguration responses = null, Azure.AI.Projects.Agents.A2AProtocolConfiguration a2a = null, Azure.AI.Projects.Agents.McpProtocolConfiguration mcp = null, Azure.AI.Projects.Agents.InvocationsProtocolConfiguration invocations = null, Azure.AI.Projects.Agents.InvocationsWsProtocolConfiguration invocationsWs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Projects.Agents.ProjectsAgentProtocol protocol = default(Azure.AI.Projects.Agents.ProjectsAgentProtocol), string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination PSTNTelephonyTransferDestination(string value = null) { throw null; }
        public static Azure.AI.Projects.Agents.RaiInvocationModeration RaiInvocationModeration(Azure.AI.Projects.Agents.RaiInvocationContentType? inputContentType = default(Azure.AI.Projects.Agents.RaiInvocationContentType?), Azure.AI.Projects.Agents.RaiInvocationContentType? outputContentType = default(Azure.AI.Projects.Agents.RaiInvocationContentType?), Azure.AI.Projects.Agents.RaiInvocationMode responseMode = default(Azure.AI.Projects.Agents.RaiInvocationMode), System.Collections.Generic.IEnumerable<string> inputPaths = null, System.Collections.Generic.IEnumerable<string> outputPaths = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.RaiSseTextSelector> streamSelectors = null) { throw null; }
        public static Azure.AI.Projects.Agents.RaiSseTextSelector RaiSseTextSelector(string eventType = null, string textField = null) { throw null; }
        public static Azure.AI.Projects.Agents.RealtimeFunctionToolParameters RealtimeFunctionToolParameters() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ReminderPreviewToolboxTool ReminderPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ResponsesProtocolConfiguration ResponsesProtocolConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.SessionConfiguration SessionConfiguration(System.TimeSpan? idleTimeoutSeconds = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Projects.Agents.SessionDirectoryEntry SessionDirectoryEntry(string name = null, long sizeInBytes = (long)0, bool isDirectory = false, System.DateTimeOffset modifiedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Projects.Agents.SessionFileWriteResult SessionFileWriteResult(string path = null, long bytesWritten = (long)0) { throw null; }
        public static Azure.AI.Projects.Agents.SessionLogEvent SessionLogEvent(Azure.AI.Projects.Agents.SessionLogEventKind @event = default(Azure.AI.Projects.Agents.SessionLogEventKind), string data = null) { throw null; }
        public static Azure.AI.Projects.Agents.ShellToolboxTool ShellToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.CallableToolAllowedCaller> allowedCallers = null, Azure.AI.Projects.Agents.ToolboxShellEnvironment environment = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SipTelephonyTransferDestination SipTelephonyTransferDestination(System.Uri value = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillDeletionResult SkillDeletionResult(string id = null, string name = null, bool deleted = false) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillInlineContent SkillInlineContent(string description = null, string instructions = null, string license = null, string compatibility = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<string> allowedTools = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillReference SkillReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.SkillReferenceParam SkillReferenceParam(string skillId = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillVersion SkillVersion(string id = null, string skillId = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.SkillVersionDeletionResult SkillVersionDeletionResult(string id = null, string name = null, bool deleted = false, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.SteeringPromptOptimizationContext SteeringPromptOptimizationContext(string prompt = null) { throw null; }
        public static Azure.AI.Projects.Agents.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? isRequired = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding TeamsPhoneExtensibilityTelephonyBinding(string id = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null, string phoneNumber = null, string resourceAccountObjectId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem TeamsPhoneExtensibilityTelephonyBindingListItem(string id = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null, string etag = null, string phoneNumber = null, string resourceAccountObjectId = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination TeamsTelephonyTransferDestination(string value = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelemetryEndpoint> endpoints = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ExportedDataTypes> exportedDataTypes = null, Azure.AI.Projects.Agents.TelemetryEndpointAuthentication authentication = null) { throw null; }
        public static Azure.AI.Projects.Agents.TelemetryEndpointAuthentication TelemetryEndpointAuthentication(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyBinding TelephonyBinding(string id = null, string provider = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyBindingListItem TelephonyBindingListItem(string id = null, string provider = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null, string etag = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallJob TelephonyCallJob(Azure.AI.Projects.Agents.TelephonyOutboundDestination destination = null, string connectionName = null, string source = null, string purpose = null, System.Collections.Generic.IDictionary<string, System.BinaryData> structuredInputs = null, Azure.AI.Projects.Agents.TelephonyCallJobSchedule schedule = null, string id = null, string agentName = null, Azure.AI.Projects.Agents.TelephonyCallJobStatus status = default(Azure.AI.Projects.Agents.TelephonyCallJobStatus), Azure.AI.Projects.Agents.TelephonyCallJobCancellation cancellation = null, Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy retryPolicy = null, int attemptCount = 0, System.DateTimeOffset? nextAttemptOn = default(System.DateTimeOffset?), Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason? terminalReason = default(Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason?), long revision = (long)0, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallJobCancellation TelephonyCallJobCancellation(string requestedBy = null, string mode = null, System.DateTimeOffset requestedOn = default(System.DateTimeOffset), long revision = (long)0) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallJobSchedule TelephonyCallJobSchedule(System.DateTimeOffset? notBefore = default(System.DateTimeOffset?), System.DateTimeOffset? expiresOn = default(System.DateTimeOffset?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent TelephonyCallLifecycleEvent(long sequence = (long)0, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName name = default(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName), Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource source = default(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource), Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome outcome = default(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome), System.DateTimeOffset observedOn = default(System.DateTimeOffset), System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), Azure.AI.Projects.Agents.TelephonyCallTimestampSource timestampSource = default(Azure.AI.Projects.Agents.TelephonyCallTimestampSource), Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason? reason = default(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason?), string providerEventId = null, long? providerSequence = default(long?), int? providerStatusCode = default(int?), int? providerSubCode = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallRecord TelephonyCallRecord(string id = null, Azure.AI.Projects.Agents.TelephonyProvider provider = default(Azure.AI.Projects.Agents.TelephonyProvider), string providerCallId = null, string callerNumber = null, string providerNumber = null, Azure.AI.Projects.Agents.TelephonyCallStatus status = default(Azure.AI.Projects.Agents.TelephonyCallStatus), Azure.AI.Projects.Agents.TelephonyCallPhase phase = default(Azure.AI.Projects.Agents.TelephonyCallPhase), System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? answeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? mediaConnectedOn = default(System.DateTimeOffset?), System.DateTimeOffset? agentSessionReadyOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), System.TimeSpan? durationMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.TelephonyCallEndReason? endReason = default(Azure.AI.Projects.Agents.TelephonyCallEndReason?), int? providerStatusCode = default(int?), int? providerSubCode = default(int?), string providerMessage = null, Azure.AI.Projects.Agents.TelephonyCallTiming timing = null, Azure.AI.Projects.Agents.TelephonyCallTrace trace = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent> events = null, bool eventsTruncated = false) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallSummary TelephonyCallSummary(string id = null, Azure.AI.Projects.Agents.TelephonyProvider provider = default(Azure.AI.Projects.Agents.TelephonyProvider), string providerCallId = null, string callerNumber = null, string providerNumber = null, Azure.AI.Projects.Agents.TelephonyCallStatus status = default(Azure.AI.Projects.Agents.TelephonyCallStatus), Azure.AI.Projects.Agents.TelephonyCallPhase phase = default(Azure.AI.Projects.Agents.TelephonyCallPhase), System.DateTimeOffset startedOn = default(System.DateTimeOffset), System.DateTimeOffset? answeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? mediaConnectedOn = default(System.DateTimeOffset?), System.DateTimeOffset? agentSessionReadyOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), System.TimeSpan? durationMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.TelephonyCallEndReason? endReason = default(Azure.AI.Projects.Agents.TelephonyCallEndReason?), int? providerStatusCode = default(int?), int? providerSubCode = default(int?), string providerMessage = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallTiming TelephonyCallTiming(System.DateTimeOffset? receivedOn = default(System.DateTimeOffset?), System.DateTimeOffset? validatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? admittedOn = default(System.DateTimeOffset?), System.DateTimeOffset? answerRequestedOn = default(System.DateTimeOffset?), System.DateTimeOffset? answeredOn = default(System.DateTimeOffset?), System.DateTimeOffset? mediaConnectedOn = default(System.DateTimeOffset?), System.DateTimeOffset? agentSessionReadyOn = default(System.DateTimeOffset?), System.DateTimeOffset? firstCallerAudioOn = default(System.DateTimeOffset?), System.DateTimeOffset? firstAgentAudioOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), Azure.AI.Projects.Agents.TelephonyCallDurationBasis? durationBasis = default(Azure.AI.Projects.Agents.TelephonyCallDurationBasis?), Azure.AI.Projects.Agents.TelephonyCallTimestampSource timestampSource = default(Azure.AI.Projects.Agents.TelephonyCallTimestampSource)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyCallTrace TelephonyCallTrace(Azure.AI.Projects.Agents.TelephonyCallTraceStatus status = default(Azure.AI.Projects.Agents.TelephonyCallTraceStatus), string traceId = null, string rootSpanId = null, string conversationId = null, Azure.AI.Projects.Agents.TelephonyCallTraceMode? mode = default(Azure.AI.Projects.Agents.TelephonyCallTraceMode?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyOutboundDestination TelephonyOutboundDestination(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType type = default(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType), string value = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult TelephonyOutboundFixedIntervalRetryPolicyResult(int? maxAttempts = default(int?), System.TimeSpan interval = default(System.TimeSpan)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy TelephonyOutboundRetryPolicy(string type = null, int? maxAttempts = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyTransferDestination TelephonyTransferDestination(string kind = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyTransferTarget TelephonyTransferTarget(string name = null, string description = null, Azure.AI.Projects.Agents.TelephonyTransferDestination destination = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TelephonyTransferTargets TelephonyTransferTargets(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.TelephonyTransferTarget> transferTargets = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxPolicies ToolboxPolicies(Azure.AI.Projects.Agents.ContentFilterConfiguration raiConfig = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxRecord ToolboxRecord(string id = null, string name = null, System.DateTimeOffset updatedOn = default(System.DateTimeOffset), Azure.AI.Projects.Agents.ToolboxVersions versions = null, string defaultVersion = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.ToolboxSearchPreviewToolboxTool ToolboxSearchPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Projects.Agents.ToolboxShellContainerAutoEnvironment ToolboxShellContainerAutoEnvironment(System.Collections.Generic.IEnumerable<string> fileIds = null, OpenAI.Containers.ContainerMemoryLimit? memoryLimit = default(OpenAI.Containers.ContainerMemoryLimit?), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ContainerSkill> skills = null, Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy networkPolicy = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellContainerReferenceEnvironment ToolboxShellContainerReferenceEnvironment(string containerId = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellEnvironment ToolboxShellEnvironment(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy ToolboxShellNetworkPolicy(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxShellNetworkPolicyDisabled ToolboxShellNetworkPolicyDisabled() { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkill ToolboxSkill(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxSkillReference ToolboxSkillReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxTool ToolboxTool(string type = null, string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxVersion ToolboxVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.ToolboxSkill> skills = null, Azure.AI.Projects.Agents.ToolboxPolicies policies = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolboxVersions ToolboxVersions(Azure.AI.Projects.Agents.ToolboxVersion latest = null) { throw null; }
        public static Azure.AI.Projects.Agents.ToolSearchToolboxTool ToolSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TwilioTelephonyBinding TwilioTelephonyBinding(string id = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null, string phoneNumber = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem TwilioTelephonyBindingListItem(string id = null, string connectionName = null, string label = null, Azure.AI.Projects.Agents.TelephonyBindingStatus status = default(Azure.AI.Projects.Agents.TelephonyBindingStatus), System.Uri incomingCallUrl = null, string etag = null, string phoneNumber = null) { throw null; }
        public static Azure.AI.Projects.Agents.UpdateToolboxRequest UpdateToolboxRequest(string name = null, string defaultVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration UserConversationSimulationAudioEffectsConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect> effects = null, int? volumePercentage = default(int?)) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationConfiguration UserConversationSimulationConfiguration(int? maxNumTurns = default(int?), int? conversationRepetitions = default(int?), int? desiredNumTurns = default(int?), Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration audioEffects = null, Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration userBehavior = null) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration UserConversationSimulationDefaultInterruptionConfiguration() { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration UserConversationSimulationInterruptionConfiguration(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationTestCase UserConversationSimulationTestCase(string testCaseId = null, string testCaseCategory = null, string testCaseDescription = null, Azure.AI.Projects.Agents.UserConversationSimulationConfiguration simulationConfiguration = null) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration UserConversationSimulationUserBehaviorConfiguration(Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration interruption = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionIndicator VersionIndicator(string type = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionRefIndicator VersionRefIndicator(string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelectionRule VersionSelectionRule(string type = null, string agentVersion = null) { throw null; }
        public static Azure.AI.Projects.Agents.VersionSelector VersionSelector(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VersionSelectionRule> versionSelectionRules = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAudioConfig VoiceAgentAudioConfig(Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig input = null, Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig output = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig VoiceAgentAudioInputConfig(OpenAI.Realtime.RealtimeAudioFormat format = null, Azure.AI.Projects.Agents.VoiceAgentNoiseReduction noiseReduction = null, Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig turnDetection = null, Azure.AI.Projects.Agents.VoiceAgentEchoCancellation echoCancellation = null, Azure.AI.Projects.Agents.VoiceAgentInputTranscription transcription = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig VoiceAgentAudioOutputConfig(OpenAI.Realtime.RealtimeAudioFormat format = null, string voice = null, Azure.AI.Projects.Agents.VoiceType? voiceType = default(Azure.AI.Projects.Agents.VoiceType?), string voiceLocale = null, float? speed = default(float?), float? voiceTemperature = default(float?), System.Uri customLexiconUrl = null, System.Uri customTextNormalizationUrl = null, System.Collections.Generic.IEnumerable<string> preferLocales = null, string style = null, string pitch = null, string volume = null, string customVoiceEndpointId = null, string personalVoiceModel = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentAudioTimestampType> outputAudioTimestampTypes = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarConfig VoiceAgentAvatarConfig(Azure.AI.Projects.Agents.VoiceAgentAvatarType type = default(Azure.AI.Projects.Agents.VoiceAgentAvatarType), string character = null, string style = null, bool? customized = default(bool?), Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol? outputProtocol = default(Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol?), string model = null, Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams video = null, Azure.AI.Projects.Agents.VoiceAgentAvatarScene scene = null, bool? outputAuditAudio = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarScene VoiceAgentAvatarScene(float? zoom = default(float?), float? positionX = default(float?), float? positionY = default(float?), float? rotationX = default(float?), float? rotationY = default(float?), float? rotationZ = default(float?), float? amplitude = default(float?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground VoiceAgentAvatarVideoBackground(System.Uri imageUrl = null, string color = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop VoiceAgentAvatarVideoCrop(System.Collections.Generic.IEnumerable<object> bottomRight = null, System.Collections.Generic.IEnumerable<object> topLeft = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams VoiceAgentAvatarVideoParams(int? bitrate = default(int?), Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop crop = null, Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution resolution = null, Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground background = null, int? gopSize = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution VoiceAgentAvatarVideoResolution(int width = 0, int height = 0) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection VoiceAgentAzureSemanticVadEnTurnDetection(bool? autoTruncate = default(bool?), float? threshold = default(float?), System.TimeSpan? prefixPaddingMs = default(System.TimeSpan?), System.TimeSpan? silenceDurationMs = default(System.TimeSpan?), System.TimeSpan? idleTimeoutMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection endOfUtteranceDetection = null, System.TimeSpan? speechDurationMs = default(System.TimeSpan?), bool? removeFillerWords = default(bool?), bool? createResponse = default(bool?), bool? interruptResponse = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection VoiceAgentAzureSemanticVadMultilingualTurnDetection(bool? autoTruncate = default(bool?), float? threshold = default(float?), System.TimeSpan? prefixPaddingMs = default(System.TimeSpan?), System.TimeSpan? silenceDurationMs = default(System.TimeSpan?), System.TimeSpan? idleTimeoutMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection endOfUtteranceDetection = null, System.TimeSpan? speechDurationMs = default(System.TimeSpan?), bool? removeFillerWords = default(bool?), bool? createResponse = default(bool?), bool? interruptResponse = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection VoiceAgentAzureSemanticVadTurnDetection(bool? autoTruncate = default(bool?), float? threshold = default(float?), System.TimeSpan? prefixPaddingMs = default(System.TimeSpan?), System.TimeSpan? silenceDurationMs = default(System.TimeSpan?), System.TimeSpan? idleTimeoutMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection endOfUtteranceDetection = null, System.TimeSpan? speechDurationMs = default(System.TimeSpan?), bool? removeFillerWords = default(bool?), bool? createResponse = default(bool?), bool? interruptResponse = default(bool?), System.Collections.Generic.IEnumerable<string> languages = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentDefinition VoiceAgentDefinition(Azure.AI.Projects.Agents.ContentFilterConfiguration contentFilterConfiguration = null, Azure.AI.Projects.Agents.VoiceModelType? modelType = default(Azure.AI.Projects.Agents.VoiceModelType?), string model = null, Azure.AI.Projects.Agents.VoiceConversationEngine conversationEngine = null, string instructions = null, Azure.AI.Projects.Agents.VoiceAgentGreetingConfig greeting = null, Azure.AI.Projects.Agents.VoiceAgentAudioConfig audio = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceOutputModality> outputModalities = null, System.BinaryData maxOutputTokens = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentSessionIncludeOption> include = null, Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig interimResponse = null, Azure.AI.Projects.Agents.VoiceAgentAvatarConfig avatar = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentTool> tools = null, System.BinaryData toolChoice = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> structuredInputs = null, Azure.AI.Projects.Agents.VoiceAgentSubagentConfig subagentConfig = null, bool? store = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentEchoCancellation VoiceAgentEchoCancellation(Azure.AI.Projects.Agents.VoiceAgentEchoCancellationReferenceSource? referenceSource = default(Azure.AI.Projects.Agents.VoiceAgentEchoCancellationReferenceSource?), int? channels = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool VoiceAgentEndConversationSystemTool(string description = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection VoiceAgentEndOfUtteranceDetection(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel model = default(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel), Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel? thresholdLevel = default(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel?), System.TimeSpan? timeoutMs = default(System.TimeSpan?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentFunctionTool VoiceAgentFunctionTool(string description = null, Azure.AI.Projects.Agents.RealtimeFunctionToolParameters parameters = null, string name = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentGreetingConfig VoiceAgentGreetingConfig(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscription VoiceAgentInputTranscription(string language = null, System.Collections.Generic.IEnumerable<string> languages = null, System.Collections.Generic.IEnumerable<string> keywords = null, string prompt = null, Azure.AI.Projects.Agents.VoiceAgentAudioInputConfigTranscriptionDelay? delay = default(Azure.AI.Projects.Agents.VoiceAgentAudioInputConfigTranscriptionDelay?), Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel model = default(Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel), System.Collections.Generic.IDictionary<string, string> customSpeech = null, System.Collections.Generic.IEnumerable<string> phraseList = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig VoiceAgentInterimResponseConfig(string type = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger> triggers = null, System.TimeSpan? latencyThresholdMs = default(System.TimeSpan?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig VoiceAgentLlmGeneratedGreetingConfig(string prompt = null, System.BinaryData toolChoice = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig VoiceAgentLlmInterimResponseConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger> triggers = null, System.TimeSpan? latencyThresholdMs = default(System.TimeSpan?), string model = null, string instructions = null, int? maxCompletionTokens = default(int?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentMcpTool VoiceAgentMcpTool(string serverLabel = null, string authorization = null, string serverDescription = null, System.Collections.Generic.IDictionary<string, string> headers = null, System.BinaryData allowedTools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.CallableToolAllowedCaller> allowedCallers = null, System.BinaryData requireApproval = null, bool? deferLoading = default(bool?), string projectConnectionId = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, System.Uri serverUrl = null, Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling? responseScheduling = default(Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentNoiseReduction VoiceAgentNoiseReduction(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType type = default(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection VoiceAgentSemanticVadTurnDetection(bool? autoTruncate = default(bool?), OpenAI.Realtime.RealtimeSemanticVadEagernessLevel? eagerness = default(OpenAI.Realtime.RealtimeSemanticVadEagernessLevel?), bool? createResponse = default(bool?), bool? interruptResponse = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection VoiceAgentServerVadTurnDetection(bool? autoTruncate = default(bool?), double? threshold = default(double?), long? prefixPaddingMs = default(long?), long? silenceDurationMs = default(long?), bool? createResponse = default(bool?), bool? interruptResponse = default(bool?), long? idleTimeoutMs = default(long?), System.TimeSpan? speechDurationMs = default(System.TimeSpan?), Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection endOfUtteranceDetection = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig VoiceAgentStaticInterimResponseConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger> triggers = null, System.TimeSpan? latencyThresholdMs = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<string> texts = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentSubagent VoiceAgentSubagent(string agentName = null, string agentVersion = null, string agentCapabilities = null, Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy responsePolicy = null, System.TimeSpan? invokeTimeoutSeconds = default(System.TimeSpan?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentSubagentConfig VoiceAgentSubagentConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentSubagent> subagents = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy VoiceAgentSubagentResponsePolicy(bool? immediateAck = default(bool?), System.TimeSpan? gapFillingInterval = default(System.TimeSpan?), string ackInstructions = null, string gapFillingInstructions = null, bool? enableDeltaProgress = default(bool?), string progressInstructions = null, System.TimeSpan? progressUpdateInterval = default(System.TimeSpan?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentSystemTool VoiceAgentSystemTool(string description = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig VoiceAgentTemplateGreetingConfig(string text = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentTool VoiceAgentTool(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentToolboxTool VoiceAgentToolboxTool(string toolboxName = null, string toolboxVersion = null, Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling? responseScheduling = default(Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig VoiceAgentTurnDetectionConfig(string type = null, bool? autoTruncate = default(bool?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceAudioItem VoiceAudioItem(string conversationId = null, string itemId = null, Azure.AI.Projects.Agents.VoiceAudioRole? role = default(Azure.AI.Projects.Agents.VoiceAudioRole?), Azure.AI.Projects.Agents.VoiceAudioContainerFormat? format = default(Azure.AI.Projects.Agents.VoiceAudioContainerFormat?), Azure.AI.Projects.Agents.VoiceAudioCodec? codec = default(Azure.AI.Projects.Agents.VoiceAudioCodec?), int? sampleRate = default(int?), int? channels = default(int?), System.TimeSpan? startOffsetMs = default(System.TimeSpan?), System.TimeSpan? durationMs = default(System.TimeSpan?), System.Uri blobUri = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceConversationEngine VoiceConversationEngine(string type = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceGeneratedAudioItem VoiceGeneratedAudioItem(string conversationId = null, string itemId = null, Azure.AI.Projects.Agents.VoiceAudioRole? role = default(Azure.AI.Projects.Agents.VoiceAudioRole?), Azure.AI.Projects.Agents.VoiceAudioContainerFormat? format = default(Azure.AI.Projects.Agents.VoiceAudioContainerFormat?), Azure.AI.Projects.Agents.VoiceAudioCodec? codec = default(Azure.AI.Projects.Agents.VoiceAudioCodec?), int? sampleRate = default(int?), int? channels = default(int?), System.TimeSpan? startOffsetMs = default(System.TimeSpan?), System.TimeSpan? durationMs = default(System.TimeSpan?), System.Uri blobUri = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine VoiceHostedAgentConversationEngine(string name = null, string version = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceRecording VoiceRecording(string conversationId = null, Azure.AI.Projects.Agents.VoiceAudioContainerFormat format = default(Azure.AI.Projects.Agents.VoiceAudioContainerFormat), int sampleRate = 0, int channels = 0, Azure.AI.Projects.Agents.VoiceRecordingChannelLayout channelLayout = null, System.TimeSpan durationMs = default(System.TimeSpan), System.Uri blobUri = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceRecordingChannelLayout VoiceRecordingChannelLayout() { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceResponseAudio VoiceResponseAudio(Azure.AI.Projects.Agents.VoiceResponseAudioOutput output = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceResponseAudioOutput VoiceResponseAudioOutput(string voice = null, Azure.AI.Projects.Agents.VoiceType? voiceType = default(Azure.AI.Projects.Agents.VoiceType?), string voiceLocale = null, OpenAI.Realtime.RealtimeAudioFormat format = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceResponseBase VoiceResponseBase(Azure.AI.Projects.Agents.VoiceResponseBaseObject? @object = default(Azure.AI.Projects.Agents.VoiceResponseBaseObject?), OpenAI.Realtime.RealtimeResponseStatus? status = default(OpenAI.Realtime.RealtimeResponseStatus?), OpenAI.Realtime.RealtimeResponseStatusDetails statusDetails = null, OpenAI.Realtime.RealtimeResponseUsage usage = null, System.Collections.Generic.IEnumerable<OpenAI.Realtime.RealtimeOutputModality> outputModalities = null, System.BinaryData maxOutputTokens = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.VoiceResult VoiceResult(Azure.AI.Projects.Agents.VoiceResponseBaseObject? @object = default(Azure.AI.Projects.Agents.VoiceResponseBaseObject?), OpenAI.Realtime.RealtimeResponseStatus? status = default(OpenAI.Realtime.RealtimeResponseStatus?), OpenAI.Realtime.RealtimeResponseStatusDetails statusDetails = null, OpenAI.Realtime.RealtimeResponseUsage usage = null, System.Collections.Generic.IEnumerable<OpenAI.Realtime.RealtimeOutputModality> outputModalities = null, System.BinaryData maxOutputTokens = null, string id = null, System.Collections.Generic.IEnumerable<OpenAI.Realtime.RealtimeItem> output = null, string conversationId = null, Azure.AI.Projects.Agents.VoiceResponseAudio audio = null, System.Collections.Generic.IDictionary<string, string> metadata = null, float? temperature = default(float?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?)) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
        public static Azure.AI.Projects.Agents.WebIQPreviewToolboxTool WebIQPreviewToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, string projectConnectionId = null, string serverLabel = null, System.BinaryData requireApprovalInternal = null) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public static Azure.AI.Projects.Agents.WebSearchToolboxTool WebSearchToolboxTool(string name = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> toolConfigs = null, bool? externalWebAccess = default(bool?), OpenAI.Responses.WebSearchToolFilters filters = null, OpenAI.Responses.WebSearchToolApproximateLocation userLocation = null, OpenAI.Responses.WebSearchToolContextSize? searchContextSize = default(OpenAI.Responses.WebSearchToolContextSize?), Azure.AI.Extensions.OpenAI.WebSearchConfiguration customSearchConfiguration = null) { throw null; }
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
    public partial class PromptOptimizationConfiguration : Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>
    {
        public PromptOptimizationConfiguration() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.OptimizationContext> Context { get { throw null; } }
        protected override Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.AgentOptimizationConfigurationBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PromptOptimizationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PromptOptimizationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PromptOptimizationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class PSTNTelephonyTransferDestination : Azure.AI.Projects.Agents.TelephonyTransferDestination, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>
    {
        public PSTNTelephonyTransferDestination(string value) { }
        public string Value { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.PSTNTelephonyTransferDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiInvocationContentType : System.IEquatable<Azure.AI.Projects.Agents.RaiInvocationContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiInvocationContentType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.RaiInvocationContentType Json { get { throw null; } }
        public static Azure.AI.Projects.Agents.RaiInvocationContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.RaiInvocationContentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.RaiInvocationContentType left, Azure.AI.Projects.Agents.RaiInvocationContentType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.RaiInvocationContentType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.RaiInvocationContentType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.RaiInvocationContentType left, Azure.AI.Projects.Agents.RaiInvocationContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RaiInvocationMode : System.IEquatable<Azure.AI.Projects.Agents.RaiInvocationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RaiInvocationMode(string value) { throw null; }
        public static Azure.AI.Projects.Agents.RaiInvocationMode Both { get { throw null; } }
        public static Azure.AI.Projects.Agents.RaiInvocationMode NonStreaming { get { throw null; } }
        public static Azure.AI.Projects.Agents.RaiInvocationMode Streaming { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.RaiInvocationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.RaiInvocationMode left, Azure.AI.Projects.Agents.RaiInvocationMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.RaiInvocationMode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.RaiInvocationMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.RaiInvocationMode left, Azure.AI.Projects.Agents.RaiInvocationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RaiInvocationModeration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiInvocationModeration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiInvocationModeration>
    {
        public RaiInvocationModeration(Azure.AI.Projects.Agents.RaiInvocationMode responseMode) { }
        public Azure.AI.Projects.Agents.RaiInvocationContentType? InputContentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> InputPaths { get { throw null; } }
        public Azure.AI.Projects.Agents.RaiInvocationContentType? OutputContentType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OutputPaths { get { throw null; } }
        public Azure.AI.Projects.Agents.RaiInvocationMode ResponseMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.RaiSseTextSelector> StreamSelectors { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.RaiInvocationModeration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.RaiInvocationModeration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.RaiInvocationModeration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiInvocationModeration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiInvocationModeration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.RaiInvocationModeration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiInvocationModeration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiInvocationModeration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiInvocationModeration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiSseTextSelector : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiSseTextSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiSseTextSelector>
    {
        public RaiSseTextSelector(string eventType) { }
        public string EventType { get { throw null; } set { } }
        public string TextField { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.RaiSseTextSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.RaiSseTextSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.RaiSseTextSelector System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiSseTextSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RaiSseTextSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.RaiSseTextSelector System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiSseTextSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiSseTextSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RaiSseTextSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RealtimeFunctionToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>
    {
        public RealtimeFunctionToolParameters() { }
        protected virtual Azure.AI.Projects.Agents.RealtimeFunctionToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.RealtimeFunctionToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.RealtimeFunctionToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.RealtimeFunctionToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.RealtimeFunctionToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SessionFileWriteResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResult>
    {
        internal SessionFileWriteResult() { }
        public long BytesWritten { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.SessionFileWriteResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.SessionFileWriteResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.SessionFileWriteResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SessionFileWriteResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SessionFileWriteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SessionFileWriteResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SessionFileWriteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
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
    public partial class SipTelephonyTransferDestination : Azure.AI.Projects.Agents.TelephonyTransferDestination, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>
    {
        public SipTelephonyTransferDestination(System.Uri value) { }
        public System.Uri Value { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SipTelephonyTransferDestination System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SipTelephonyTransferDestination System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SipTelephonyTransferDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SkillReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReference>
    {
        public SkillReference(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.SkillReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.SkillReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkillReferenceParam : Azure.AI.Projects.Agents.ContainerSkill, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReferenceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReferenceParam>
    {
        public SkillReferenceParam(string skillId) { }
        public string SkillId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.ContainerSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ContainerSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SkillReferenceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReferenceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SkillReferenceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SkillReferenceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReferenceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReferenceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SkillReferenceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SteeringPromptOptimizationContext : Azure.AI.Projects.Agents.OptimizationContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>
    {
        public SteeringPromptOptimizationContext(string prompt) { }
        public string Prompt { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.OptimizationContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.OptimizationContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.SteeringPromptOptimizationContext System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.SteeringPromptOptimizationContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.SteeringPromptOptimizationContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAttribute : System.IEquatable<Azure.AI.Projects.Agents.TargetAttribute>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAttribute(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TargetAttribute Instructions { get { throw null; } }
        public static Azure.AI.Projects.Agents.TargetAttribute Model { get { throw null; } }
        public static Azure.AI.Projects.Agents.TargetAttribute Skills { get { throw null; } }
        public static Azure.AI.Projects.Agents.TargetAttribute Tools { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TargetAttribute other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TargetAttribute left, Azure.AI.Projects.Agents.TargetAttribute right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TargetAttribute (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TargetAttribute? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TargetAttribute left, Azure.AI.Projects.Agents.TargetAttribute right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TeamsPhoneExtensibilityTelephonyBinding : Azure.AI.Projects.Agents.TelephonyBinding, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>
    {
        internal TeamsPhoneExtensibilityTelephonyBinding() { }
        public string PhoneNumber { get { throw null; } }
        public string ResourceAccountObjectId { get { throw null; } }
        protected override Azure.AI.Projects.Agents.TelephonyBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TeamsPhoneExtensibilityTelephonyBindingListItem : Azure.AI.Projects.Agents.TelephonyBindingListItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>
    {
        internal TeamsPhoneExtensibilityTelephonyBindingListItem() { }
        public string PhoneNumber { get { throw null; } }
        public string ResourceAccountObjectId { get { throw null; } }
        protected override Azure.AI.Projects.Agents.TelephonyBindingListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyBindingListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsPhoneExtensibilityTelephonyBindingListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TeamsTelephonyTransferDestination : Azure.AI.Projects.Agents.TelephonyTransferDestination, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>
    {
        public TeamsTelephonyTransferDestination(string value) { }
        public string Value { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyTransferDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TeamsTelephonyTransferDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class TelephonyBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBinding>
    {
        internal TelephonyBinding() { }
        public string ConnectionName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri IncomingCallUrl { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyBindingStatus Status { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.TelephonyBinding (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.TelephonyBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class TelephonyBindingListItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>
    {
        internal TelephonyBindingListItem() { }
        public string ConnectionName { get { throw null; } }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Uri IncomingCallUrl { get { throw null; } }
        public string Label { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyBindingStatus Status { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyBindingListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyBindingListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyBindingListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyBindingListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyBindingListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyBindingStatus : System.IEquatable<Azure.AI.Projects.Agents.TelephonyBindingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyBindingStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyBindingStatus Active { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyBindingStatus Suspended { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyBindingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyBindingStatus left, Azure.AI.Projects.Agents.TelephonyBindingStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyBindingStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyBindingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyBindingStatus left, Azure.AI.Projects.Agents.TelephonyBindingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallDurationBasis : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallDurationBasis>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallDurationBasis(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallDurationBasis Answered { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallDurationBasis Received { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallDurationBasis other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallDurationBasis left, Azure.AI.Projects.Agents.TelephonyCallDurationBasis right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallDurationBasis (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallDurationBasis? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallDurationBasis left, Azure.AI.Projects.Agents.TelephonyCallDurationBasis right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallEndReason : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallEndReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallEndReason(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason AdmissionCheckFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason AdmissionRejected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason AgentSessionConnectFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason AnswerFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason BindingNotFound { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason BindingSuspended { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason BridgeCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason BridgeFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason CredentialResolutionFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason EndpointResolutionFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason IngressSetupFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason InvalidBindingConfiguration { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason InvalidWebhookPayload { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason LiveCallConflict { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason LiveCallPersistenceFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ManagedHangup { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ManagedTransfer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ManageHangupFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ManageTransferFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason MediaStreamEnded { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderBusy { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderDisconnected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderNoAnswer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderResourceMismatch { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderStreamError { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason ProviderStreamStopped { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason RouteAgentMismatch { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallEndReason WebhookValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallEndReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallEndReason left, Azure.AI.Projects.Agents.TelephonyCallEndReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallEndReason (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallEndReason? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallEndReason left, Azure.AI.Projects.Agents.TelephonyCallEndReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallJob : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJob>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJob>
    {
        internal TelephonyCallJob() { }
        public string AgentName { get { throw null; } }
        public int AttemptCount { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallJobCancellation Cancellation { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyOutboundDestination Destination { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? NextAttemptOn { get { throw null; } }
        public string Object { get { throw null; } }
        public string Purpose { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy RetryPolicy { get { throw null; } }
        public long Revision { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallJobSchedule Schedule { get { throw null; } }
        public string Source { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallJobStatus Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> StructuredInputs { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason? TerminalReason { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJob JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.TelephonyCallJob (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJob PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallJob System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallJob System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallJobCancellation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>
    {
        internal TelephonyCallJobCancellation() { }
        public string Mode { get { throw null; } }
        public string RequestedBy { get { throw null; } }
        public System.DateTimeOffset RequestedOn { get { throw null; } }
        public long Revision { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJobCancellation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJobCancellation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallJobCancellation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallJobCancellation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobCancellation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallJobSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>
    {
        public TelephonyCallJobSchedule() { }
        public System.DateTimeOffset? ExpiresOn { get { throw null; } set { } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJobSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallJobSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallJobSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallJobSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallJobSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallJobStatus : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallJobStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Accepted { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Blocked { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus CancellationRequested { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Dispatching { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Expired { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus Queued { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus WaitingForRetry { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobStatus WaitingForSchedule { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallJobStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallJobStatus left, Azure.AI.Projects.Agents.TelephonyCallJobStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallJobStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallJobStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallJobStatus left, Azure.AI.Projects.Agents.TelephonyCallJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallJobTerminalReason : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallJobTerminalReason(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason AnswerFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason BridgeCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason BridgeFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason CampaignCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason CampaignCompleted { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason CampaignFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason CampaignNotFound { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason CancellationReconciliationTimeout { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason ConnectionProjectMismatch { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason NoAnswer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason NoAnswerTimeout { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason OriginationFenceNotRecorded { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason OriginationReconciliationTimeout { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason OutboundConnectionChanged { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason OutboundConnectionUnavailable { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason ProviderCallbackTimeoutCancellationReconciliationTimeout { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason TelephonyBindingChanged { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason TelephonyBindingInactive { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason TelephonyBindingInvalid { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason TelephonyBindingNotFound { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason VoiceSessionConfigurationInvalid { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason left, Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason left, Azure.AI.Projects.Agents.TelephonyCallJobTerminalReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallLifecycleEvent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>
    {
        internal TelephonyCallLifecycleEvent() { }
        public Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName Name { get { throw null; } }
        public System.DateTimeOffset ObservedOn { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Outcome { get { throw null; } }
        public string ProviderEventId { get { throw null; } }
        public long? ProviderSequence { get { throw null; } }
        public int? ProviderStatusCode { get { throw null; } }
        public int? ProviderSubCode { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason? Reason { get { throw null; } }
        public long Sequence { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource Source { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTimestampSource TimestampSource { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallLifecycleEventName : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallLifecycleEventName(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName AgentSessionConnect { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName BindingResolve { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName CallDisconnect { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName CallHangup { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName CallTransfer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName FirstAgentAudio { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName FirstCallerAudio { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName MediaConnect { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName ProviderAnswer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName WebhookReceived { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName WebhookValidation { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallLifecycleEventOutcome : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallLifecycleEventOutcome(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Cancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Observed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Rejected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Started { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventOutcome right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallLifecycleEventReason : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallLifecycleEventReason(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason AdmissionCheckFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason AdmissionRejected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason AgentSessionConnectFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason AnswerFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason BindingNotFound { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason BindingSuspended { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason BridgeCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason BridgeFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason CredentialResolutionFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason EndpointResolutionFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason IngressSetupFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason InvalidBindingConfiguration { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason InvalidWebhookPayload { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason LiveCallConflict { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason LiveCallPersistenceFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ManagedHangup { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ManagedTransfer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ManageHangupFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ManageTransferFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason MediaStreamEnded { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderBusy { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderCancelled { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderDisconnected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderFailed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderNoAnswer { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderResourceMismatch { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderStreamError { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason ProviderStreamStopped { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason RouteAgentMismatch { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason WebhookValidationFailed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallLifecycleEventSource : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallLifecycleEventSource(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource Gateway { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource TeamsPhoneExtensibility { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource Twilio { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource VoiceAgent { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource left, Azure.AI.Projects.Agents.TelephonyCallLifecycleEventSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallPhase : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallPhase>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallPhase(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Admitted { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase AgentSessionReady { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Answered { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Answering { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Bridging { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Completed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Managing { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase MediaConnected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Received { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Rejected { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallPhase Validated { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallPhase other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallPhase left, Azure.AI.Projects.Agents.TelephonyCallPhase right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallPhase (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallPhase? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallPhase left, Azure.AI.Projects.Agents.TelephonyCallPhase right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallRecord>
    {
        internal TelephonyCallRecord() { }
        public System.DateTimeOffset? AgentSessionReadyOn { get { throw null; } }
        public System.DateTimeOffset? AnsweredOn { get { throw null; } }
        public string CallerNumber { get { throw null; } }
        public System.TimeSpan? DurationMs { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallEndReason? EndReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TelephonyCallLifecycleEvent> Events { get { throw null; } }
        public bool EventsTruncated { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? MediaConnectedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallPhase Phase { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyProvider Provider { get { throw null; } }
        public string ProviderCallId { get { throw null; } }
        public string ProviderMessage { get { throw null; } }
        public string ProviderNumber { get { throw null; } }
        public int? ProviderStatusCode { get { throw null; } }
        public int? ProviderSubCode { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallStatus Status { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTiming Timing { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTrace Trace { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.TelephonyCallRecord (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallStatus : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallStatus Success { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallStatus left, Azure.AI.Projects.Agents.TelephonyCallStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallStatus left, Azure.AI.Projects.Agents.TelephonyCallStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallSummary>
    {
        internal TelephonyCallSummary() { }
        public System.DateTimeOffset? AgentSessionReadyOn { get { throw null; } }
        public System.DateTimeOffset? AnsweredOn { get { throw null; } }
        public string CallerNumber { get { throw null; } }
        public System.TimeSpan? DurationMs { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallEndReason? EndReason { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? MediaConnectedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallPhase Phase { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyProvider Provider { get { throw null; } }
        public string ProviderCallId { get { throw null; } }
        public string ProviderMessage { get { throw null; } }
        public string ProviderNumber { get { throw null; } }
        public int? ProviderStatusCode { get { throw null; } }
        public int? ProviderSubCode { get { throw null; } }
        public System.DateTimeOffset StartedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallStatus Status { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallTimestampSource : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallTimestampSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallTimestampSource(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallTimestampSource Derived { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTimestampSource Gateway { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTimestampSource Provider { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallTimestampSource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallTimestampSource left, Azure.AI.Projects.Agents.TelephonyCallTimestampSource right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTimestampSource (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTimestampSource? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallTimestampSource left, Azure.AI.Projects.Agents.TelephonyCallTimestampSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallTiming : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTiming>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTiming>
    {
        internal TelephonyCallTiming() { }
        public System.DateTimeOffset? AdmittedOn { get { throw null; } }
        public System.DateTimeOffset? AgentSessionReadyOn { get { throw null; } }
        public System.DateTimeOffset? AnsweredOn { get { throw null; } }
        public System.DateTimeOffset? AnswerRequestedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallDurationBasis? DurationBasis { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.DateTimeOffset? FirstAgentAudioOn { get { throw null; } }
        public System.DateTimeOffset? FirstCallerAudioOn { get { throw null; } }
        public System.DateTimeOffset? MediaConnectedOn { get { throw null; } }
        public System.DateTimeOffset? ReceivedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTimestampSource TimestampSource { get { throw null; } }
        public System.DateTimeOffset? ValidatedOn { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallTiming JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallTiming PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallTiming System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTiming>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTiming>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallTiming System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTiming>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTiming>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTiming>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyCallTrace : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTrace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTrace>
    {
        internal TelephonyCallTrace() { }
        public string ConversationId { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTraceMode? Mode { get { throw null; } }
        public string RootSpanId { get { throw null; } }
        public Azure.AI.Projects.Agents.TelephonyCallTraceStatus Status { get { throw null; } }
        public string TraceId { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallTrace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyCallTrace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyCallTrace System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTrace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyCallTrace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyCallTrace System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTrace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTrace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyCallTrace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallTraceMode : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallTraceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallTraceMode(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceMode Live { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceMode PostCall { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallTraceMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallTraceMode left, Azure.AI.Projects.Agents.TelephonyCallTraceMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTraceMode (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTraceMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallTraceMode left, Azure.AI.Projects.Agents.TelephonyCallTraceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyCallTraceStatus : System.IEquatable<Azure.AI.Projects.Agents.TelephonyCallTraceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyCallTraceStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus Available { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus Emitting { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus NotApplicable { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus NotRecorded { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyCallTraceStatus Pending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyCallTraceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyCallTraceStatus left, Azure.AI.Projects.Agents.TelephonyCallTraceStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTraceStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyCallTraceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyCallTraceStatus left, Azure.AI.Projects.Agents.TelephonyCallTraceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyOutboundDestination : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>
    {
        public TelephonyOutboundDestination(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType type, string value) { }
        public Azure.AI.Projects.Agents.TelephonyOutboundDestinationType Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.TelephonyOutboundDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyOutboundDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyOutboundDestination System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyOutboundDestination System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyOutboundDestinationType : System.IEquatable<Azure.AI.Projects.Agents.TelephonyOutboundDestinationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyOutboundDestinationType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyOutboundDestinationType PhoneNumber { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType left, Azure.AI.Projects.Agents.TelephonyOutboundDestinationType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyOutboundDestinationType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyOutboundDestinationType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyOutboundDestinationType left, Azure.AI.Projects.Agents.TelephonyOutboundDestinationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyOutboundFixedIntervalRetryPolicyResult : Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>
    {
        public TelephonyOutboundFixedIntervalRetryPolicyResult(System.TimeSpan interval) { }
        public System.TimeSpan Interval { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundFixedIntervalRetryPolicyResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class TelephonyOutboundRetryPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>
    {
        internal TelephonyOutboundRetryPolicy() { }
        public int? MaxAttempts { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyOutboundRetryPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelephonyProvider : System.IEquatable<Azure.AI.Projects.Agents.TelephonyProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelephonyProvider(string value) { throw null; }
        public static Azure.AI.Projects.Agents.TelephonyProvider TeamsPhoneExtensibility { get { throw null; } }
        public static Azure.AI.Projects.Agents.TelephonyProvider Twilio { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.TelephonyProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.TelephonyProvider left, Azure.AI.Projects.Agents.TelephonyProvider right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyProvider (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.TelephonyProvider? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.TelephonyProvider left, Azure.AI.Projects.Agents.TelephonyProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class TelephonyTransferDestination : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>
    {
        internal TelephonyTransferDestination() { }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferDestination JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferDestination PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyTransferDestination System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyTransferDestination System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferDestination>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyTransferTarget : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>
    {
        public TelephonyTransferTarget(string name, string description, Azure.AI.Projects.Agents.TelephonyTransferDestination destination) { }
        public string Description { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.TelephonyTransferDestination Destination { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyTransferTarget System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyTransferTarget System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TelephonyTransferTargets : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>
    {
        internal TelephonyTransferTargets() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.TelephonyTransferTarget> TransferTargets { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferTargets JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.TelephonyTransferTargets (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.TelephonyTransferTargets PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TelephonyTransferTargets System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TelephonyTransferTargets System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TelephonyTransferTargets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        public Azure.AI.Projects.Agents.ToolboxVersions Versions { get { throw null; } }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Containers.ContainerMemoryLimit? MemoryLimit { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.ToolboxShellNetworkPolicy NetworkPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.ContainerSkill> Skills { get { throw null; } }
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
    public partial class ToolboxVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersions>
    {
        internal ToolboxVersions() { }
        public Azure.AI.Projects.Agents.ToolboxVersion Latest { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.ToolboxVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.ToolboxVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.ToolboxVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.ToolboxVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.ToolboxVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.ToolboxVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TwilioTelephonyBinding : Azure.AI.Projects.Agents.TelephonyBinding, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>
    {
        internal TwilioTelephonyBinding() { }
        public string PhoneNumber { get { throw null; } }
        protected override Azure.AI.Projects.Agents.TelephonyBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TwilioTelephonyBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TwilioTelephonyBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class TwilioTelephonyBindingListItem : Azure.AI.Projects.Agents.TelephonyBindingListItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>
    {
        internal TwilioTelephonyBindingListItem() { }
        public string PhoneNumber { get { throw null; } }
        protected override Azure.AI.Projects.Agents.TelephonyBindingListItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.TelephonyBindingListItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.TwilioTelephonyBindingListItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserConversationSimulationAudioEffect : System.IEquatable<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserConversationSimulationAudioEffect(string value) { throw null; }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect BackgroundTv { get { throw null; } }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect CrowdChatter { get { throw null; } }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect MetroStation { get { throw null; } }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect StreetTraffic { get { throw null; } }
        public static Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect TelephonicVoice { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect left, Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect left, Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserConversationSimulationAudioEffectsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>
    {
        public UserConversationSimulationAudioEffectsConfiguration() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffect> Effects { get { throw null; } }
        public int? VolumePercentage { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>
    {
        public UserConversationSimulationConfiguration() { }
        public Azure.AI.Projects.Agents.UserConversationSimulationAudioEffectsConfiguration AudioEffects { get { throw null; } set { } }
        public int? ConversationRepetitions { get { throw null; } set { } }
        public int? DesiredNumTurns { get { throw null; } set { } }
        public int? MaxNumTurns { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration UserBehavior { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationDefaultInterruptionConfiguration : Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>
    {
        public UserConversationSimulationDefaultInterruptionConfiguration() { }
        protected override Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationDefaultInterruptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class UserConversationSimulationInterruptionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>
    {
        internal UserConversationSimulationInterruptionConfiguration() { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationTestCase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>
    {
        public UserConversationSimulationTestCase() { }
        public Azure.AI.Projects.Agents.UserConversationSimulationConfiguration SimulationConfiguration { get { throw null; } set { } }
        public string TestCaseCategory { get { throw null; } set { } }
        public string TestCaseDescription { get { throw null; } set { } }
        public string TestCaseId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationTestCase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationTestCase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationTestCase System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationTestCase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationTestCase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserConversationSimulationUserBehaviorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>
    {
        public UserConversationSimulationUserBehaviorConfiguration() { }
        public Azure.AI.Projects.Agents.UserConversationSimulationInterruptionConfiguration Interruption { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.UserConversationSimulationUserBehaviorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VoiceAgentAudioConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>
    {
        public VoiceAgentAudioConfig() { }
        public Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig Input { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig Output { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAudioConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAudioConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAudioInputConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>
    {
        public VoiceAgentAudioInputConfig() { }
        public Azure.AI.Projects.Agents.VoiceAgentEchoCancellation EchoCancellation { get { throw null; } set { } }
        public OpenAI.Realtime.RealtimeAudioFormat Format { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentNoiseReduction NoiseReduction { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentInputTranscription Transcription { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig TurnDetection { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioInputConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum VoiceAgentAudioInputConfigTranscriptionDelay
    {
        Minimal = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        Xhigh = 4,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAudioOutputConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>
    {
        public VoiceAgentAudioOutputConfig() { }
        public System.Uri CustomLexiconUrl { get { throw null; } set { } }
        public System.Uri CustomTextNormalizationUrl { get { throw null; } set { } }
        public string CustomVoiceEndpointId { get { throw null; } set { } }
        public OpenAI.Realtime.RealtimeAudioFormat Format { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentAudioTimestampType> OutputAudioTimestampTypes { get { throw null; } }
        public string PersonalVoiceModel { get { throw null; } set { } }
        public string Pitch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PreferLocales { get { throw null; } }
        public float? Speed { get { throw null; } set { } }
        public string Style { get { throw null; } set { } }
        public string Voice { get { throw null; } set { } }
        public string VoiceLocale { get { throw null; } set { } }
        public float? VoiceTemperature { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceType? VoiceType { get { throw null; } set { } }
        public string Volume { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAudioOutputConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum VoiceAgentAudioTimestampType
    {
        Word = 0,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>
    {
        public VoiceAgentAvatarConfig(Azure.AI.Projects.Agents.VoiceAgentAvatarType type, string character) { }
        public string Character { get { throw null; } set { } }
        public bool? Customized { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public bool? OutputAuditAudio { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol? OutputProtocol { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarScene Scene { get { throw null; } set { } }
        public string Style { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarType Type { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams Video { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentAvatarOutputProtocol : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentAvatarOutputProtocol(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol Webrtc { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol Websocket { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol left, Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol left, Azure.AI.Projects.Agents.VoiceAgentAvatarOutputProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarScene : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>
    {
        public VoiceAgentAvatarScene() { }
        public float? Amplitude { get { throw null; } set { } }
        public float? PositionX { get { throw null; } set { } }
        public float? PositionY { get { throw null; } set { } }
        public float? RotationX { get { throw null; } set { } }
        public float? RotationY { get { throw null; } set { } }
        public float? RotationZ { get { throw null; } set { } }
        public float? Zoom { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarScene JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarScene PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarScene System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarScene System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarScene>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentAvatarType : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentAvatarType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentAvatarType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarType PhotoAvatar { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentAvatarType VideoAvatar { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentAvatarType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentAvatarType left, Azure.AI.Projects.Agents.VoiceAgentAvatarType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentAvatarType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentAvatarType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentAvatarType left, Azure.AI.Projects.Agents.VoiceAgentAvatarType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarVideoBackground : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>
    {
        public VoiceAgentAvatarVideoBackground() { }
        public string Color { get { throw null; } set { } }
        public System.Uri ImageUrl { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarVideoCrop : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>
    {
        public VoiceAgentAvatarVideoCrop(System.Collections.Generic.IEnumerable<object> bottomRight, System.Collections.Generic.IEnumerable<object> topLeft) { }
        public System.Collections.Generic.IList<object> BottomRight { get { throw null; } }
        public System.Collections.Generic.IList<object> TopLeft { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarVideoParams : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>
    {
        public VoiceAgentAvatarVideoParams() { }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarVideoBackground Background { get { throw null; } set { } }
        public int? Bitrate { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarVideoCrop Crop { get { throw null; } set { } }
        public int? GopSize { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution Resolution { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoParams>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAvatarVideoResolution : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>
    {
        public VoiceAgentAvatarVideoResolution(int width, int height) { }
        public int Height { get { throw null; } set { } }
        public int Width { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAvatarVideoResolution>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAzureSemanticVadEnTurnDetection : Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>
    {
        public VoiceAgentAzureSemanticVadEnTurnDetection() { }
        public bool? CreateResponse { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.TimeSpan? IdleTimeoutMs { get { throw null; } set { } }
        public bool? InterruptResponse { get { throw null; } set { } }
        public System.TimeSpan? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public System.TimeSpan? SilenceDurationMs { get { throw null; } set { } }
        public System.TimeSpan? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadEnTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAzureSemanticVadMultilingualTurnDetection : Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>
    {
        public VoiceAgentAzureSemanticVadMultilingualTurnDetection() { }
        public bool? CreateResponse { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.TimeSpan? IdleTimeoutMs { get { throw null; } set { } }
        public bool? InterruptResponse { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public System.TimeSpan? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public System.TimeSpan? SilenceDurationMs { get { throw null; } set { } }
        public System.TimeSpan? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadMultilingualTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentAzureSemanticVadTurnDetection : Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>
    {
        public VoiceAgentAzureSemanticVadTurnDetection() { }
        public bool? CreateResponse { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public System.TimeSpan? IdleTimeoutMs { get { throw null; } set { } }
        public bool? InterruptResponse { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public System.TimeSpan? PrefixPaddingMs { get { throw null; } set { } }
        public bool? RemoveFillerWords { get { throw null; } set { } }
        public System.TimeSpan? SilenceDurationMs { get { throw null; } set { } }
        public System.TimeSpan? SpeechDurationMs { get { throw null; } set { } }
        public float? Threshold { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentAzureSemanticVadTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentDefinition : Azure.AI.Projects.Agents.ProjectsAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>
    {
        public VoiceAgentDefinition() { }
        public Azure.AI.Projects.Agents.VoiceAgentAudioConfig Audio { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentAvatarConfig Avatar { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceConversationEngine ConversationEngine { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentGreetingConfig Greeting { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentSessionIncludeOption> Include { get { throw null; } }
        public string Instructions { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig InterimResponse { get { throw null; } set { } }
        public System.BinaryData MaxOutputTokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceModelType? ModelType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceOutputModality> OutputModalities { get { throw null; } }
        public bool? ParallelToolCalls { get { throw null; } set { } }
        public bool? Store { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.Agents.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAgentSubagentConfig SubagentConfig { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentTool> Tools { get { throw null; } }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.ProjectsAgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentEchoCancellation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>
    {
        public VoiceAgentEchoCancellation() { }
        public int? Channels { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEchoCancellationReferenceSource? ReferenceSource { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentEchoCancellation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentEchoCancellation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentEchoCancellation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentEchoCancellation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEchoCancellation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum VoiceAgentEchoCancellationReferenceSource
    {
        Server = 0,
        Client = 1,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentEndConversationSystemTool : Azure.AI.Projects.Agents.VoiceAgentSystemTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>
    {
        public VoiceAgentEndConversationSystemTool() : base (default(Azure.AI.Projects.Agents.VoiceAgentSystemToolName)) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndConversationSystemTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentEndOfUtteranceDetection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>
    {
        public VoiceAgentEndOfUtteranceDetection(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel model) { }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel Model { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel? ThresholdLevel { get { throw null; } set { } }
        public System.TimeSpan? TimeoutMs { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentEndOfUtteranceDetectionModel : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentEndOfUtteranceDetectionModel(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel SemanticDetectionV1 { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel SemanticDetectionV1En { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel SemanticDetectionV1Multilingual { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel SmartEndOfTurnDetection { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel left, Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel left, Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetectionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentEndOfUtteranceThresholdLevel : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentEndOfUtteranceThresholdLevel(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel Default { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel High { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel Low { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel Medium { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel left, Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel left, Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceThresholdLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentFunctionTool : Azure.AI.Projects.Agents.VoiceAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>
    {
        public VoiceAgentFunctionTool(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.RealtimeFunctionToolParameters Parameters { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentFunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentFunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentFunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class VoiceAgentGreetingConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>
    {
        internal VoiceAgentGreetingConfig() { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentGreetingConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentGreetingConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentGreetingConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentGreetingConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentGreetingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentInputTranscription : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>
    {
        public VoiceAgentInputTranscription(Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel model) { }
        public System.Collections.Generic.IDictionary<string, string> CustomSpeech { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAgentAudioInputConfigTranscriptionDelay? Delay { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Keywords { get { throw null; } }
        public string Language { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Languages { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel Model { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PhraseList { get { throw null; } }
        public string Prompt { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentInputTranscription JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentInputTranscription PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentInputTranscription System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentInputTranscription System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInputTranscription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentInputTranscriptionModel : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentInputTranscriptionModel(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel AzureSpeech { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel Gpt4oMiniTranscribe { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel Gpt4oTranscribe { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel Gpt4oTranscribeDiarize { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel GptLiveTranscribe { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel GptRealtimeWhisper { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel GptTranscribe { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel MaiTranscribe { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel Whisper1 { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel left, Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel left, Azure.AI.Projects.Agents.VoiceAgentInputTranscriptionModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class VoiceAgentInterimResponseConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>
    {
        internal VoiceAgentInterimResponseConfig() { }
        public System.TimeSpan? LatencyThresholdMs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger> Triggers { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentInterimResponseTrigger : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentInterimResponseTrigger(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger Latency { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger Tool { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger left, Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger left, Azure.AI.Projects.Agents.VoiceAgentInterimResponseTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentLlmGeneratedGreetingConfig : Azure.AI.Projects.Agents.VoiceAgentGreetingConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>
    {
        public VoiceAgentLlmGeneratedGreetingConfig(string prompt) { }
        public string Prompt { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentGreetingConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentGreetingConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmGeneratedGreetingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentLlmInterimResponseConfig : Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>
    {
        public VoiceAgentLlmInterimResponseConfig() { }
        public string Instructions { get { throw null; } set { } }
        public int? MaxCompletionTokens { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentLlmInterimResponseConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentMcpTool : Azure.AI.Projects.Agents.VoiceAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>
    {
        public VoiceAgentMcpTool(string serverLabel) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.CallableToolAllowedCaller> AllowedCallers { get { throw null; } set { } }
        public System.BinaryData AllowedTools { get { throw null; } set { } }
        public string Authorization { get { throw null; } set { } }
        public bool? DeferLoading { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.BinaryData RequireApproval { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling? ResponseScheduling { get { throw null; } set { } }
        public string ServerDescription { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Uri ServerUrl { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Extensions.OpenAI.ToolConfig> ToolConfigs { get { throw null; } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentMcpTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentMcpTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentMcpTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentNoiseReduction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>
    {
        public VoiceAgentNoiseReduction(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType type) { }
        public Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType Type { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentNoiseReduction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentNoiseReduction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentNoiseReduction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentNoiseReduction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentNoiseReduction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentNoiseReductionType : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentNoiseReductionType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType AzureDeepNoiseSuppression { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType FarField { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType NearField { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType left, Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType left, Azure.AI.Projects.Agents.VoiceAgentNoiseReductionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentSemanticVadTurnDetection : Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>
    {
        public VoiceAgentSemanticVadTurnDetection() { }
        public bool? CreateResponse { get { throw null; } set { } }
        public OpenAI.Realtime.RealtimeSemanticVadEagernessLevel? Eagerness { get { throw null; } set { } }
        public bool? InterruptResponse { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSemanticVadTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentServerVadTurnDetection : Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>
    {
        public VoiceAgentServerVadTurnDetection() { }
        public bool? CreateResponse { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentEndOfUtteranceDetection EndOfUtteranceDetection { get { throw null; } set { } }
        public long? IdleTimeoutMs { get { throw null; } set { } }
        public bool? InterruptResponse { get { throw null; } set { } }
        public long? PrefixPaddingMs { get { throw null; } set { } }
        public long? SilenceDurationMs { get { throw null; } set { } }
        public System.TimeSpan? SpeechDurationMs { get { throw null; } set { } }
        public double? Threshold { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentServerVadTurnDetection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public enum VoiceAgentSessionIncludeOption
    {
        InputAudioTranscriptionLogprobs = 0,
        InputAudioTranscriptionPhrases = 1,
        FileSearchCallResults = 2,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentStaticInterimResponseConfig : Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>
    {
        public VoiceAgentStaticInterimResponseConfig() { }
        public System.Collections.Generic.IList<string> Texts { get { throw null; } }
        protected override Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentInterimResponseConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentStaticInterimResponseConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentSubagent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>
    {
        public VoiceAgentSubagent(string agentName, string agentCapabilities) { }
        public string AgentCapabilities { get { throw null; } set { } }
        public string AgentName { get { throw null; } set { } }
        public string AgentVersion { get { throw null; } set { } }
        public System.TimeSpan? InvokeTimeoutSeconds { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy ResponsePolicy { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentSubagent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentSubagent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentSubagentConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>
    {
        public VoiceAgentSubagentConfig(System.Collections.Generic.IEnumerable<Azure.AI.Projects.Agents.VoiceAgentSubagent> subagents) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.Agents.VoiceAgentSubagent> Subagents { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagentConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagentConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentSubagentConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentSubagentConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentSubagentResponsePolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>
    {
        public VoiceAgentSubagentResponsePolicy() { }
        public string AckInstructions { get { throw null; } set { } }
        public bool? EnableDeltaProgress { get { throw null; } set { } }
        public string GapFillingInstructions { get { throw null; } set { } }
        public System.TimeSpan? GapFillingInterval { get { throw null; } set { } }
        public bool? ImmediateAck { get { throw null; } set { } }
        public string ProgressInstructions { get { throw null; } set { } }
        public System.TimeSpan? ProgressUpdateInterval { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSubagentResponsePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentSystemTool : Azure.AI.Projects.Agents.VoiceAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>
    {
        public VoiceAgentSystemTool(Azure.AI.Projects.Agents.VoiceAgentSystemToolName name) { }
        public string Description { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentSystemTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentSystemTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentSystemTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentSystemToolName : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentSystemToolName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentSystemToolName(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentSystemToolName EndConversation { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentSystemToolName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentSystemToolName left, Azure.AI.Projects.Agents.VoiceAgentSystemToolName right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentSystemToolName (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentSystemToolName? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentSystemToolName left, Azure.AI.Projects.Agents.VoiceAgentSystemToolName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentTemplateGreetingConfig : Azure.AI.Projects.Agents.VoiceAgentGreetingConfig, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>
    {
        public VoiceAgentTemplateGreetingConfig(string text) { }
        public string Text { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentGreetingConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentGreetingConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTemplateGreetingConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class VoiceAgentTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTool>
    {
        internal VoiceAgentTool() { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAgentToolboxTool : Azure.AI.Projects.Agents.VoiceAgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>
    {
        public VoiceAgentToolboxTool(string toolboxName, string toolboxVersion) { }
        public Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling? ResponseScheduling { get { throw null; } set { } }
        public string ToolboxName { get { throw null; } set { } }
        public string ToolboxVersion { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceAgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentToolboxTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentToolboxTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentToolboxTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentToolResponseScheduling : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentToolResponseScheduling(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling Interrupt { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling Silent { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling SkipIfBusy { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling WhenIdle { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling left, Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling left, Azure.AI.Projects.Agents.VoiceAgentToolResponseScheduling right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAgentTransport : System.IEquatable<Azure.AI.Projects.Agents.VoiceAgentTransport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAgentTransport(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAgentTransport Webrtc { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAgentTransport Websocket { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAgentTransport other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAgentTransport left, Azure.AI.Projects.Agents.VoiceAgentTransport right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentTransport (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAgentTransport? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAgentTransport left, Azure.AI.Projects.Agents.VoiceAgentTransport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class VoiceAgentTurnDetectionConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>
    {
        internal VoiceAgentTurnDetectionConfig() { }
        public bool? AutoTruncate { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAgentTurnDetectionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAudioCodec : System.IEquatable<Azure.AI.Projects.Agents.VoiceAudioCodec>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAudioCodec(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAudioCodec Pcm16 { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAudioCodec Pcma { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAudioCodec Pcmu { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAudioCodec other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAudioCodec left, Azure.AI.Projects.Agents.VoiceAudioCodec right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioCodec (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioCodec? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAudioCodec left, Azure.AI.Projects.Agents.VoiceAudioCodec right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAudioContainerFormat : System.IEquatable<Azure.AI.Projects.Agents.VoiceAudioContainerFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAudioContainerFormat(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAudioContainerFormat Wav { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAudioContainerFormat other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAudioContainerFormat left, Azure.AI.Projects.Agents.VoiceAudioContainerFormat right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioContainerFormat (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioContainerFormat? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAudioContainerFormat left, Azure.AI.Projects.Agents.VoiceAudioContainerFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceAudioItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAudioItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAudioItem>
    {
        internal VoiceAudioItem() { }
        public System.Uri BlobUri { get { throw null; } }
        public int? Channels { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioCodec? Codec { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public System.TimeSpan? DurationMs { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioContainerFormat? Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioRole? Role { get { throw null; } }
        public int? SampleRate { get { throw null; } }
        public System.TimeSpan? StartOffsetMs { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceAudioItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.VoiceAudioItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.VoiceAudioItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceAudioItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAudioItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceAudioItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceAudioItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAudioItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAudioItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceAudioItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceAudioRole : System.IEquatable<Azure.AI.Projects.Agents.VoiceAudioRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceAudioRole(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceAudioRole Agent { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceAudioRole User { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceAudioRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceAudioRole left, Azure.AI.Projects.Agents.VoiceAudioRole right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioRole (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceAudioRole? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceAudioRole left, Azure.AI.Projects.Agents.VoiceAudioRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversation>
    {
        internal VoiceConversation() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Object { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceConversationStatus Status { get { throw null; } }
        public OpenAI.Realtime.RealtimeResponseUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.VoiceConversation (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.VoiceConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public abstract partial class VoiceConversationEngine : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversationEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversationEngine>
    {
        internal VoiceConversationEngine() { }
        protected virtual Azure.AI.Projects.Agents.VoiceConversationEngine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceConversationEngine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceConversationEngine System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversationEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceConversationEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceConversationEngine System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversationEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversationEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceConversationEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceConversationStatus : System.IEquatable<Azure.AI.Projects.Agents.VoiceConversationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceConversationStatus(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceConversationStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceConversationStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceConversationStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceConversationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceConversationStatus left, Azure.AI.Projects.Agents.VoiceConversationStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceConversationStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceConversationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceConversationStatus left, Azure.AI.Projects.Agents.VoiceConversationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceGeneratedAudioItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>
    {
        internal VoiceGeneratedAudioItem() { }
        public System.Uri BlobUri { get { throw null; } }
        public int? Channels { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioCodec? Codec { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public System.TimeSpan? DurationMs { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioContainerFormat? Format { get { throw null; } }
        public string ItemId { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioRole? Role { get { throw null; } }
        public int? SampleRate { get { throw null; } }
        public System.TimeSpan? StartOffsetMs { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceGeneratedAudioItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.VoiceGeneratedAudioItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.VoiceGeneratedAudioItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceGeneratedAudioItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceGeneratedAudioItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceGeneratedAudioItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceHostedAgentConversationEngine : Azure.AI.Projects.Agents.VoiceConversationEngine, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>
    {
        public VoiceHostedAgentConversationEngine(string name) { }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected override Azure.AI.Projects.Agents.VoiceConversationEngine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.Agents.VoiceConversationEngine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceHostedAgentConversationEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceModelType : System.IEquatable<Azure.AI.Projects.Agents.VoiceModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceModelType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceModelType Managed { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceModelType SelfDeployed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceModelType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceModelType left, Azure.AI.Projects.Agents.VoiceModelType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceModelType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceModelType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceModelType left, Azure.AI.Projects.Agents.VoiceModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceOutputModality : System.IEquatable<Azure.AI.Projects.Agents.VoiceOutputModality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceOutputModality(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceOutputModality Animation { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceOutputModality Audio { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceOutputModality Avatar { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceOutputModality Text { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceOutputModality other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceOutputModality left, Azure.AI.Projects.Agents.VoiceOutputModality right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceOutputModality (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceOutputModality? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceOutputModality left, Azure.AI.Projects.Agents.VoiceOutputModality right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceRecording : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecording>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecording>
    {
        internal VoiceRecording() { }
        public System.Uri BlobUri { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceRecordingChannelLayout ChannelLayout { get { throw null; } }
        public int Channels { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public System.TimeSpan DurationMs { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceAudioContainerFormat Format { get { throw null; } }
        public int SampleRate { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceRecording JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.VoiceRecording (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Projects.Agents.VoiceRecording PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceRecording System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecording>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecording>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceRecording System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecording>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecording>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecording>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceRecordingChannelLayout : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>
    {
        internal VoiceRecordingChannelLayout() { }
        public string Left { get { throw null; } }
        public string Right { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceRecordingChannelLayout JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceRecordingChannelLayout PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceRecordingChannelLayout System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceRecordingChannelLayout System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceRecordingChannelLayout>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceResponseAudio : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudio>
    {
        public VoiceResponseAudio() { }
        public Azure.AI.Projects.Agents.VoiceResponseAudioOutput Output { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseAudio JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseAudio PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceResponseAudio System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceResponseAudio System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceResponseAudioOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>
    {
        public VoiceResponseAudioOutput() { }
        public OpenAI.Realtime.RealtimeAudioFormat Format { get { throw null; } set { } }
        public string Voice { get { throw null; } set { } }
        public string VoiceLocale { get { throw null; } set { } }
        public Azure.AI.Projects.Agents.VoiceType? VoiceType { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseAudioOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseAudioOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceResponseAudioOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceResponseAudioOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseAudioOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceResponseBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseBase>
    {
        internal VoiceResponseBase() { }
        public System.BinaryData MaxOutputTokens { get { throw null; } }
        public Azure.AI.Projects.Agents.VoiceResponseBaseObject? Object { get { throw null; } }
        public System.Collections.Generic.IList<OpenAI.Realtime.RealtimeOutputModality> OutputModalities { get { throw null; } }
        public OpenAI.Realtime.RealtimeResponseStatus? Status { get { throw null; } }
        public OpenAI.Realtime.RealtimeResponseStatusDetails StatusDetails { get { throw null; } }
        public OpenAI.Realtime.RealtimeResponseUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.Agents.VoiceResponseBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceResponseBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResponseBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceResponseBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResponseBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceResponseBaseObject : System.IEquatable<Azure.AI.Projects.Agents.VoiceResponseBaseObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceResponseBaseObject(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceResponseBaseObject RealtimeResponse { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceResponseBaseObject other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceResponseBaseObject left, Azure.AI.Projects.Agents.VoiceResponseBaseObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceResponseBaseObject (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceResponseBaseObject? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceResponseBaseObject left, Azure.AI.Projects.Agents.VoiceResponseBaseObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class VoiceResult : Azure.AI.Projects.Agents.VoiceResponseBase, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResult>
    {
        internal VoiceResult() { }
        public Azure.AI.Projects.Agents.VoiceResponseAudio Audio { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<OpenAI.Realtime.RealtimeItem> Output { get { throw null; } }
        public float? Temperature { get { throw null; } }
        protected override Azure.AI.Projects.Agents.VoiceResponseBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Projects.Agents.VoiceResult (System.ClientModel.ClientResult result) { throw null; }
        protected override Azure.AI.Projects.Agents.VoiceResponseBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.Agents.VoiceResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.VoiceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agents.VoiceResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.VoiceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VoiceType : System.IEquatable<Azure.AI.Projects.Agents.VoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VoiceType(string value) { throw null; }
        public static Azure.AI.Projects.Agents.VoiceType AvatarVoiceSync { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceType AzureCustom { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceType AzurePersonal { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceType AzureRealtimeNative { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceType AzureStandard { get { throw null; } }
        public static Azure.AI.Projects.Agents.VoiceType Openai { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Agents.VoiceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Agents.VoiceType left, Azure.AI.Projects.Agents.VoiceType right) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.Agents.VoiceType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Agents.VoiceType left, Azure.AI.Projects.Agents.VoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP001")]
    public partial class WebIQPreviewToolboxTool : Azure.AI.Projects.Agents.ToolboxTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agents.WebIQPreviewToolboxTool>
    {
        public WebIQPreviewToolboxTool(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        public OpenAI.Responses.McpToolCallApprovalPolicy RequireApproval { get { throw null; } set { } }
        public System.BinaryData RequireApprovalInternal { get { throw null; } set { } }
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
        public bool? ExternalWebAccess { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.WebSearchToolFilters Filters { get { throw null; } set { } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.WebSearchToolContextSize? SearchContextSize { get { throw null; } set { } }
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
            public Azure.AI.Extensions.OpenAI.WebSearchConfiguration CustomSearchConfiguration { get { throw null; } set { } }
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
}
