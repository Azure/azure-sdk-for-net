namespace Azure.Containers.Apps.Sandbox
{
    public partial class AddConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>
    {
        public AddConnectionContent(string connectionId) { }
        public string ConnectionId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.AddConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.AddConnectionContent addConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.AddConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddPodVolumeMountsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>
    {
        public AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.PodVolume> volumes, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts> containerMounts) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts> ContainerMounts { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.PodVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent addPodVolumeMountsContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddVolumeMountContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>
    {
        public AddVolumeMountContent(Azure.Containers.Apps.Sandbox.SandboxVolume volumeMount) { }
        public Azure.Containers.Apps.Sandbox.SandboxVolume VolumeMount { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.AddVolumeMountContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.AddVolumeMountContent addVolumeMountContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.AddVolumeMountContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AddVolumeMountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsTelemetryEndpoint : Azure.Containers.Apps.Sandbox.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>
    {
        public ApplicationInsightsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data, Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth auth) { }
        public Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth Auth { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AppsSandboxModelFactory
    {
        public static Azure.Containers.Apps.Sandbox.AddConnectionContent AddConnectionContent(string connectionId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.PodVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts> containerMounts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.AddVolumeMountContent AddVolumeMountContent(Azure.Containers.Apps.Sandbox.SandboxVolume volumeMount = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ApplicationInsightsTelemetryEndpoint ApplicationInsightsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> columns = null, bool? dynamicJsonColumns = default(bool?), Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication BlobVolumeAuthentication(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication BlobVolumeManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.BlobVolumeUsage BlobVolumeUsage(long usedBytes = (long)0, long itemCount = (long)0, System.DateTimeOffset calculatedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CommitSandboxContent CommitSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CommitSandboxResult CommitSandboxResult(Azure.Containers.Apps.Sandbox.DiskImage diskImage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ConnectionsListResult ConnectionsListResult(System.Collections.Generic.IEnumerable<string> connectionIds = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerAppsSandbox ContainerAppsSandbox(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, Azure.Containers.Apps.Sandbox.SandboxSource sourcesRef = null, Azure.Containers.Apps.Sandbox.SandboxResources resources = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Containers.Apps.Sandbox.SandboxState? state = default(Azure.Containers.Apps.Sandbox.SandboxState?), Azure.Containers.Apps.Sandbox.SandboxStateDetails stateDetails = null, string snapshotId = null, long? coldStorageSizeInMb = default(long?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxPort> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.GatewayConnection> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.Apps.Sandbox.SandboxEgressPolicy egressPolicy = null, string sandboxGroupId = null, string region = null, Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy lifecycle = null, System.Uri appUri = null, System.Uri managementUri = null, Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.IdentitySetting> identitySettings = null, System.Collections.Generic.IEnumerable<string> outboundIPAddresses = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerStatus> containerStatuses = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerProbe ContainerProbe(Azure.Containers.Apps.Sandbox.ProbeHttpGetAction httpGet = null, Azure.Containers.Apps.Sandbox.ProbeExecAction exec = null, Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction tcpSocket = null, int? initialDelaySeconds = default(int?), int? periodSeconds = default(int?), int? timeoutSeconds = default(int?), int? failureThreshold = default(int?), int? successThreshold = default(int?), int? terminationGracePeriodSeconds = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerProbeStatus ContainerProbeStatus(Azure.Containers.Apps.Sandbox.ContainerProbeResult? lastResult = default(Azure.Containers.Apps.Sandbox.ContainerProbeResult?), int? consecutiveFailures = default(int?), int? consecutiveSuccesses = default(int?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerResources ContainerResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerSecurityContext ContainerSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), bool? privileged = default(bool?), Azure.Containers.Apps.Sandbox.LinuxCapabilities capabilities = null, bool? allowPrivilegeEscalation = default(bool?), bool? readOnlyRootFilesystem = default(bool?), Azure.Containers.Apps.Sandbox.SeccompProfile seccompProfile = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerSpec ContainerSpec(string name = null, Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.Apps.Sandbox.ContainerResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerVolumeMount> volumeMounts = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, Azure.Containers.Apps.Sandbox.ContainerSecurityContext securityContext = null, Azure.Containers.Apps.Sandbox.ContainerProbe startupProbe = null, Azure.Containers.Apps.Sandbox.ContainerProbe livenessProbe = null, Azure.Containers.Apps.Sandbox.ContainerProbe readinessProbe = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerStatus ContainerStatus(string name = null, Azure.Containers.Apps.Sandbox.ContainerRuntimeState state = default(Azure.Containers.Apps.Sandbox.ContainerRuntimeState), bool ready = false, bool started = false, int restartCount = 0, Azure.Containers.Apps.Sandbox.ContainerStatusReason? reason = default(Azure.Containers.Apps.Sandbox.ContainerStatusReason?), string message = null, int? lastExitCode = default(int?), System.DateTimeOffset? lastStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastFinishedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.ContainerProbeStatus> probes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerVolumeMount ContainerVolumeMount(string name = null, string mountPath = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerVolumeMounts ContainerVolumeMounts(string containerName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerVolumeMount> volumeMounts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContentPackage ContentPackage(string id = null, long size = (long)0, System.Collections.Generic.IDictionary<string, string> labels = null, string contentType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CpuStats CpuStats(long? user = default(long?), long? nice = default(long?), long? system = default(long?), long? idle = default(long?), long? iowait = default(long?), long? irq = default(long?), long? softirq = default(long?), long? steal = default(long?), double? loadAvg1 = default(double?), double? loadAvg5 = default(double?), double? loadAvg15 = default(double?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateConnectionContent CreateConnectionContent(string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> labels = null, string parameterValueSetName = null, System.Collections.Generic.IDictionary<string, string> parameterValueSetValues = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateDiskImageContent CreateDiskImageContent(Azure.Containers.Apps.Sandbox.CreateDiskImageSource source = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, string vnetConnectionName = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateDiskImageSource CreateDiskImageSource(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource CreateDiskImageSourceBlobSource(System.Uri blobSourceUri = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource CreateDiskImageSourceRegistrySource(string imageReference = null, Azure.Containers.Apps.Sandbox.RegistryAuthentication authentication = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSandboxContent CreateSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.Apps.Sandbox.SandboxSource sourcesRef = null, Azure.Containers.Apps.Sandbox.SandboxResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.Apps.Sandbox.SandboxEgressPolicy egressPolicy = null, string egressPolicyId = null, string sandboxGroupId = null, Azure.Containers.Apps.Sandbox.PresetSandboxType? presetSandboxType = default(Azure.Containers.Apps.Sandbox.PresetSandboxType?), string anthropicApiKey = null, Azure.Containers.Apps.Sandbox.SandboxPresetProperties presetProperties = null, Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy lifecycle = null, Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.IdentitySetting> identitySettings = null, Azure.Containers.Apps.Sandbox.TelemetryConfig telemetryConfig = null, string projectId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent CreateSandboxGatewayConnectionContent(string resourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent CreateSandboxGroupCredentialContent(string displayName = null, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider), Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource source = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSandboxPortContent CreateSandboxPortContent(string name = null, int port = 0, Azure.Containers.Apps.Sandbox.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.PortActivationMode?), Azure.Containers.Apps.Sandbox.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.PortProtocol?), Azure.Containers.Apps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSecretContent CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.CreateSnapshotContent CreateSnapshotContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DataDiskPodVolume DataDiskPodVolume(string name = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DataDiskVolume DataDiskVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.VolumeProvisioningState), string size = null, bool isAttached = false, string clusterId = null, string attachedSandboxId = null, Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage DataDiskVolumeUsage(long compressedBlobSizeBytes = (long)0, long usedSizeBytes = (long)0, System.DateTimeOffset lastUploadedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DirListingResult DirListingResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.FileInfo> entries = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DiskImage DiskImage(string id = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.DiskImageImage image = null, Azure.Containers.Apps.Sandbox.DiskImageStatus status = null, long? sizeInMb = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DiskImageImage DiskImageImage(string base = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DiskImageStatus DiskImageStatus(string state = null, string errorMessage = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DiskStatsEntry DiskStatsEntry(string mountPoint = null, string filesystem = null, long? totalBytes = default(long?), long? usedBytes = default(long?), long? availableBytes = default(long?), string label = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent DownloadContentPackageToSandboxContent(string contentPackageId = null, string targetPath = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressDecisionEntry EgressDecisionEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string host = null, string method = null, string path = null, string scheme = null, string connectionId = null, string connectionName = null, string matchedRule = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressDecisionsResult EgressDecisionsResult(Azure.Containers.Apps.Sandbox.NetworkEgressDecisions http = null, Azure.Containers.Apps.Sandbox.StatefulTcpEgress statefulTcp = null, System.DateTimeOffset lastUpdated = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressForwardProxy EgressForwardProxy(System.Uri url = null, string certificateAuthority = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressHostRule EgressHostRule(string pattern = null, Azure.Containers.Apps.Sandbox.EgressPolicyAction? action = default(Azure.Containers.Apps.Sandbox.EgressPolicyAction?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform EgressPolicyHeaderTransform(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation operation = default(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation), string name = null, string value = null, Azure.Containers.Apps.Sandbox.EgressPolicyValueRef valueRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHookRef EgressPolicyHookRef(string endpoint = null, Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior? failBehavior = default(Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior?), System.Collections.Generic.IEnumerable<string> requestHeaders = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform> authHeaders = null, int? timeoutMs = default(int?), Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef EgressPolicyManagedIdentityRef(string resource = null, string format = null, Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType? type = default(Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType?), string identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyRule EgressPolicyRule(string name = null, Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch match = null, Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction action = null, System.Collections.Generic.IEnumerable<string> proxyActions = null, string source = null, Azure.Containers.Apps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction EgressPolicyRuleAction(Azure.Containers.Apps.Sandbox.EgressPolicyActionType type = default(Azure.Containers.Apps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform> headers = null, string scheme = null, string host = null, string path = null, Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode?), Azure.Containers.Apps.Sandbox.EgressForwardMode? forward = default(Azure.Containers.Apps.Sandbox.EgressForwardMode?), Azure.Containers.Apps.Sandbox.EgressForwardProxy forwardProxy = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch EgressPolicyRuleMatch(string host = null, string path = null, System.Collections.Generic.IEnumerable<string> methods = null, Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme? scheme = default(Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme?), bool? normalizePath = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicySecretRef EgressPolicySecretRef(string secretId = null, string secretKey = null, string format = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyValueRef EgressPolicyValueRef(Azure.Containers.Apps.Sandbox.EgressPolicySecretRef secretRef = null, Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef managedIdentityRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent ExecuteSandboxCommandContent(string command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.Apps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent ExecuteSandboxShellCommandContent(string command = null, string shell = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.Apps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.FileInfo FileInfo(string name = null, string path = null, long size = (long)0, int mode = 0, bool isDir = false, bool isSymlink = false, string symlinkTarget = null, long modifiedTime = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.FileOpStatusResult FileOpStatusResult(bool success = false, string error = null, string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent ForkDataDiskVolumeContent(string destinationVolumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GatewayAuthentication GatewayAuthentication(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GatewayConnection GatewayConnection(string resourceId = null, string name = null, System.Uri mcpRuntimeUri = null, System.Uri connectionRuntimeUri = null, Azure.Containers.Apps.Sandbox.GatewayAuthentication authentication = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord GatewayConnectionAuthRecord(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType type = default(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent GenerateConsentLinkContent(System.Uri redirectUri = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult GenerateConsentLinkResult(System.Uri consentLink = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.HttpEgressSection HttpEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyAction defaultAction = default(Azure.Containers.Apps.Sandbox.EgressPolicyAction), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressPolicyRule> rules = null, Azure.Containers.Apps.Sandbox.TrafficInspection? trafficInspection = default(Azure.Containers.Apps.Sandbox.TrafficInspection?), Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode?), Azure.Containers.Apps.Sandbox.EgressForwardProxy defaultForward = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.IdentitySetting IdentitySetting(string identity = null, Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle? lifecycle = default(Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.IPAccessControl IPAccessControl(Azure.Containers.Apps.Sandbox.IPAccessControlAction defaultAction = default(Azure.Containers.Apps.Sandbox.IPAccessControlAction), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.IPAccessControlRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.IPAccessControlRule IPAccessControlRule(string name = null, Azure.Containers.Apps.Sandbox.IPAccessControlAction action = default(Azure.Containers.Apps.Sandbox.IPAccessControlAction), int priority = 0, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LinuxCapabilities LinuxCapabilities(System.Collections.Generic.IEnumerable<string> add = null, System.Collections.Generic.IEnumerable<string> drop = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LocalPodVolume LocalPodVolume(string name = null, string size = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint LogAnalyticsLegacyTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> columns = null, bool? dynamicJsonColumns = default(bool?), string workspaceId = null, string tableName = null, Azure.Containers.Apps.Sandbox.TelemetrySecretReference auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint LogAnalyticsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> columns = null, bool? dynamicJsonColumns = default(bool?), System.Uri dceEndpoint = null, string dcrImmutableId = null, string tableName = null, Azure.Containers.Apps.Sandbox.TelemetryAuth auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LogColumnDef LogColumnDef(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication ManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType type = default(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.McpPolicyRule McpPolicyRule(string hookId = null, System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.MemoryStats MemoryStats(long? totalBytes = default(long?), long? availableBytes = default(long?), long? usedBytes = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.MkDirContent MkDirContent(string path = null, bool? createParents = default(bool?), int? mode = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.NamedEgressPolicy NamedEgressPolicy(string id = null, string name = null, string description = null, Azure.Containers.Apps.Sandbox.EgressPolicyAction defaultAction = default(Azure.Containers.Apps.Sandbox.EgressPolicyAction), Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressPolicyRule> rules = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.NetworkEgressDecisions NetworkEgressDecisions(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressDecisionEntry> allowed = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressDecisionEntry> denied = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.NetworkStats NetworkStats(long? rxBytes = default(long?), long? txBytes = default(long?), long? rxPackets = default(long?), long? txPackets = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> columns = null, bool? dynamicJsonColumns = default(bool?), System.Uri endpoint = null, Azure.Containers.Apps.Sandbox.TelemetryProtocol protocol = default(Azure.Containers.Apps.Sandbox.TelemetryProtocol), Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PodContentPackage PodContentPackage(string contentPackageId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PodSecurityContext PodSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), System.Collections.Generic.IEnumerable<int> supplementalGroups = null, int? fsGroup = default(int?), Azure.Containers.Apps.Sandbox.FsGroupChangePolicy? fsGroupChangePolicy = default(Azure.Containers.Apps.Sandbox.FsGroupChangePolicy?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PodVolume PodVolume(string kind = null, string name = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortAuthConfig PortAuthConfig(bool? anonymous = default(bool?), Azure.Containers.Apps.Sandbox.PortAuthConfigGithub github = null, Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId entraId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId PortAuthConfigEntraId(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> objectIds = null, System.Collections.Generic.IEnumerable<string> tenantIds = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortAuthConfigGithub PortAuthConfigGithub(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> usernames = null, System.Collections.Generic.IEnumerable<string> usernameSuffixes = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortCorsConfig PortCorsConfig(System.Collections.Generic.IEnumerable<string> allowOrigins = null, System.Collections.Generic.IEnumerable<string> allowMethods = null, System.Collections.Generic.IEnumerable<string> allowHeaders = null, bool? allowCredentials = default(bool?), int? maxAge = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortsListResult PortsListResult(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxPort> ports = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ProbeExecAction ProbeExecAction(System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ProbeHttpGetAction ProbeHttpGetAction(int port = 0, string path = null, string host = null, string scheme = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ProbeHttpHeader> httpHeaders = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ProbeHttpHeader ProbeHttpHeader(string name = null, string value = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction ProbeTcpSocketAction(int port = 0, string host = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PublicDiskImage PublicDiskImage(string name = null, Azure.Containers.Apps.Sandbox.DiskImageStatus status = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.RefLogColumnDef RefLogColumnDef(Azure.Containers.Apps.Sandbox.LogColumnRef refName = default(Azure.Containers.Apps.Sandbox.LogColumnRef)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.RegistryAuthentication RegistryAuthentication(Azure.Containers.Apps.Sandbox.RegistryCredentials registryCredentials = null, Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.RegistryCredentials RegistryCredentials(string username = null, string token = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.RemovePortContent RemovePortContent(string name = null, int? port = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef SandboxAgentIdentityRef(string tenantId = null, string agentId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy SandboxAutoDeletePolicy(bool enabled = false, int? deleteIntervalInDays = default(int?), long? deleteIntervalInSeconds = default(long?), Azure.Containers.Apps.Sandbox.AutoDeleteTrigger? trigger = default(Azure.Containers.Apps.Sandbox.AutoDeleteTrigger?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy SandboxAutoSuspendPolicy(bool enabled = false, int? interval = default(int?), Azure.Containers.Apps.Sandbox.SandboxSuspendMode? mode = default(Azure.Containers.Apps.Sandbox.SandboxSuspendMode?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxConnection SandboxConnection(string id = null, string name = null, string type = null, string state = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? deletable = default(bool?), System.Collections.Generic.IEnumerable<string> usedBySandboxIds = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload SandboxContentPackageDownload(string contentPackageId = null, string targetPath = null, Azure.Containers.Apps.Sandbox.ContentPackageAction? action = default(Azure.Containers.Apps.Sandbox.ContentPackageAction?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxCountResult SandboxCountResult(int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxEgressPolicy SandboxEgressPolicy(Azure.Containers.Apps.Sandbox.HttpEgressSection http = null, Azure.Containers.Apps.Sandbox.EgressPolicyAction? defaultAction = default(Azure.Containers.Apps.Sandbox.EgressPolicyAction?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.EgressPolicyRule> rules = null, Azure.Containers.Apps.Sandbox.TdsEgressSection tds = null, Azure.Containers.Apps.Sandbox.TransportEgressSection transportRules = null, Azure.Containers.Apps.Sandbox.TrafficInspection? trafficInspection = default(Azure.Containers.Apps.Sandbox.TrafficInspection?), Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ValidationWarning> validationWarnings = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult SandboxExecuteCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult SandboxExecuteShellCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredential SandboxGroupCredential(string name = null, string displayName = null, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider), Azure.Containers.Apps.Sandbox.ConnectionState state = default(Azure.Containers.Apps.Sandbox.ConnectionState), Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource source = null, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin origin = default(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails SandboxGroupCredentialConnectionRefDetails(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord authentication = null, System.Uri tokenExchangeEndpoint = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource SandboxGroupCredentialSource(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind kind = default(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind), string connectionResourceId = null, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails connectionRefDetails = null, System.Collections.Generic.IDictionary<string, string> parameterValues = null, string connectionId = null, string connectionType = null, string connectionName = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector SandboxGroupIdentitySelector(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupVolume SandboxGroupVolume(string type = null, string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy SandboxLifecyclePolicy(Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy = null, Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxPort SandboxPort(string name = null, int port = 0, System.Uri url = null, Azure.Containers.Apps.Sandbox.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.PortActivationMode?), Azure.Containers.Apps.Sandbox.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.PortProtocol?), Azure.Containers.Apps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxPortUpdate SandboxPortUpdate(string name = null, int port = 0, System.Uri url = null, Azure.Containers.Apps.Sandbox.PortAuthConfig auth = null, Azure.Containers.Apps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.Apps.Sandbox.PortActivationMode?), Azure.Containers.Apps.Sandbox.PortProtocol? protocol = default(Azure.Containers.Apps.Sandbox.PortProtocol?), Azure.Containers.Apps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.Apps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxPresetProperties SandboxPresetProperties(bool? isWorkIqConnectionEnabled = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxResources SandboxResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSecret SandboxSecret(string id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSnapshot SandboxSnapshot(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, string sandboxId = null, System.DateTimeOffset createdAtUtc = default(System.DateTimeOffset), Azure.Containers.Apps.Sandbox.SnapshotResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SnapshotPodContainer> sourcePodContainers = null, long? sizeInMb = default(long?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSource SandboxSource(Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot snapshot = null, Azure.Containers.Apps.Sandbox.SandboxSourcePod pod = null, Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion SandboxSourceArtifactVersion(string id = null, Azure.Containers.Apps.Sandbox.SandboxSourceAuth auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSourceAuth SandboxSourceAuth(string identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage SandboxSourceDiskImage(string id = null, string name = null, bool? isPublic = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSourcePod SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerSpec> containers = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.PodVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.PodContentPackage> contentPackages = null, Azure.Containers.Apps.Sandbox.PodSecurityContext securityContext = null, Azure.Containers.Apps.Sandbox.ContainerRestartPolicy? restartPolicy = default(Azure.Containers.Apps.Sandbox.ContainerRestartPolicy?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot SandboxSourceSnapshot(string id = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxStateDetails SandboxStateDetails(Azure.Containers.Apps.Sandbox.StoppedReason stoppedReason = default(Azure.Containers.Apps.Sandbox.StoppedReason), System.DateTimeOffset stoppedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxStatsResult SandboxStatsResult(Azure.Containers.Apps.Sandbox.TokenUsageStats tokenUsage = null, Azure.Containers.Apps.Sandbox.CpuStats cpu = null, Azure.Containers.Apps.Sandbox.MemoryStats memory = null, Azure.Containers.Apps.Sandbox.NetworkStats network = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.DiskStatsEntry> disk = null, double? uptimeSecs = default(double?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxVolume SandboxVolume(string volumeName = null, string mountpoint = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SeccompProfile SeccompProfile(Azure.Containers.Apps.Sandbox.SeccompProfileType type = default(Azure.Containers.Apps.Sandbox.SeccompProfileType)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SecretKeysResult SecretKeysResult(System.Collections.Generic.IEnumerable<string> keys = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SecretPeekResult SecretPeekResult(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume ServiceManagedBlobPodVolume(string name = null, string fileCacheSizeLimit = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume ServiceManagedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.VolumeProvisioningState), Azure.Containers.Apps.Sandbox.BlobVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SnapshotCountResult SnapshotCountResult(int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SnapshotPodContainer SnapshotPodContainer(string name = null, string diskImageId = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SnapshotResources SnapshotResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.StatefulTcpEgress StatefulTcpEgress(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.StatefulTcpEntry> connections = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.StatefulTcpEntry StatefulTcpEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string phase = null, string outcome = null, string connectorType = null, string server = null, int? port = default(int?), string database = null, string proxyLoginName = null, string sourceIP = null, string correlationId = null, long? bytesIn = default(long?), long? bytesOut = default(long?), long? durationMs = default(long?), string failureReason = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsCredential TdsCredential(string name = null, Azure.Containers.Apps.Sandbox.TdsAuthKind kind = default(Azure.Containers.Apps.Sandbox.TdsAuthKind), string username = null, Azure.Containers.Apps.Sandbox.EgressPolicySecretRef secretRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsEgressAction TdsEgressAction(Azure.Containers.Apps.Sandbox.EgressPolicyActionType type = default(Azure.Containers.Apps.Sandbox.EgressPolicyActionType), string credential = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsEgressMatch TdsEgressMatch(string host = null, System.Collections.Generic.IEnumerable<string> databases = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsEgressRule TdsEgressRule(string name = null, Azure.Containers.Apps.Sandbox.TdsEgressMatch match = null, Azure.Containers.Apps.Sandbox.TdsEgressAction action = null, Azure.Containers.Apps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsEgressSection TdsEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.Containers.Apps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TdsCredential> credentials = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TdsEgressRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth TelemetryApplicationInsightsAuth(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef TelemetryAppSecretRef(string secretRef = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryAuth TelemetryAuth(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryEndpoint> endpoints = null, int? metricsIntervalSeconds = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryEndpoint TelemetryEndpoint(string kind = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth TelemetryHeaderAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth TelemetryManagedIdentityAuth(string identity = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef TelemetrySandboxGroupSecretRef(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetrySecretReference TelemetrySecretReference(string kind = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth TelemetrySystemAssignedManagedIdentityAuth() { throw null; }
        public static Azure.Containers.Apps.Sandbox.TokenUsageStats TokenUsageStats(long? totalInputTokens = default(long?), long? totalOutputTokens = default(long?), int? requestCount = default(int?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TransportEgressRule TransportEgressRule(Azure.Containers.Apps.Sandbox.EgressPolicyActionType action = default(Azure.Containers.Apps.Sandbox.EgressPolicyActionType), Azure.Containers.Apps.Sandbox.TransportProtocol protocol = default(Azure.Containers.Apps.Sandbox.TransportProtocol), string destination = null, int port = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TransportEgressSection TransportEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.Containers.Apps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TransportEgressRule> rules = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.UpdatePortsContent UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxPortUpdate> ports = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume UserProvidedBlobPodVolume(string name = null, string fileCacheSizeLimit = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume UserProvidedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.Apps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.Apps.Sandbox.VolumeProvisioningState), string storageContainerResourceId = null, Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication auth = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ValidationWarning ValidationWarning(string code = null, string message = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ValueLogColumnDef ValueLogColumnDef(string value = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumeCountResult VolumeCountResult(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.VolumeTypeCount> counts = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult VolumeListDirectoryResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.VolumePathItem> items = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumePathItem VolumePathItem(string itemName = null, string path = null, bool isDirectory = false, long? sizeBytes = default(long?), System.DateTimeOffset? lastModifiedUtc = default(System.DateTimeOffset?), string contentType = null, string eTag = null) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumeTypeCount VolumeTypeCount(Azure.Containers.Apps.Sandbox.VolumeType type = default(Azure.Containers.Apps.Sandbox.VolumeType), int count = 0) { throw null; }
        public static Azure.Containers.Apps.Sandbox.WriteFileResult WriteFileResult(bool success = false, string error = null, long? bytesWritten = default(long?)) { throw null; }
    }
    public partial class AuthorizeConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>
    {
        public AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues) { }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent authorizeConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoDeleteTrigger : System.IEquatable<Azure.Containers.Apps.Sandbox.AutoDeleteTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoDeleteTrigger(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.AutoDeleteTrigger AfterCreation { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.AutoDeleteTrigger AfterSuspend { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.AutoDeleteTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.AutoDeleteTrigger left, Azure.Containers.Apps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.AutoDeleteTrigger (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.AutoDeleteTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.AutoDeleteTrigger left, Azure.Containers.Apps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureContainersAppsSandboxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureContainersAppsSandboxContext() { }
        public static Azure.Containers.Apps.Sandbox.AzureContainersAppsSandboxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public abstract partial class BlobVolumeAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>
    {
        internal BlobVolumeAuthentication() { }
        protected virtual Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeManagedIdentityAuthentication : Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>
    {
        public BlobVolumeManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector identity) { }
        public Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector Identity { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>
    {
        internal BlobVolumeUsage() { }
        public System.DateTimeOffset CalculatedAtUtc { get { throw null; } }
        public long ItemCount { get { throw null; } }
        public long UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.BlobVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.BlobVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.BlobVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>
    {
        public CommitSandboxContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CommitSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CommitSandboxContent commitSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CommitSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>
    {
        internal CommitSandboxResult() { }
        public Azure.Containers.Apps.Sandbox.DiskImage DiskImage { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CommitSandboxResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.CommitSandboxResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CommitSandboxResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CommitSandboxResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>
    {
        internal ConnectionsListResult() { }
        public System.Collections.Generic.IList<string> ConnectionIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ConnectionsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.ConnectionsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ConnectionsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ConnectionsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionState : System.IEquatable<Azure.Containers.Apps.Sandbox.ConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ConnectionState Creating { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ConnectionState Error { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ConnectionState Ready { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ConnectionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ConnectionState left, Azure.Containers.Apps.Sandbox.ConnectionState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ConnectionState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ConnectionState left, Azure.Containers.Apps.Sandbox.ConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerAppsSandbox : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>
    {
        internal ContainerAppsSandbox() { }
        public Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } }
        public System.Uri AppUri { get { throw null; } }
        public long? ColdStorageSizeInMb { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ContainerStatus> ContainerStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.GatewayConnection> GatewayConnections { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } }
        public System.Uri ManagementUri { get { throw null; } }
        public System.Collections.Generic.IList<string> OutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxPort> Ports { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxResources Resources { get { throw null; } }
        public string SandboxGroupId { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxSource SourcesRef { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxState? State { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxStateDetails StateDetails { get { throw null; } }
        public string VnetConnectionName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerAppsSandbox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.ContainerAppsSandbox (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerAppsSandbox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerAppsSandboxClient
    {
        protected ContainerAppsSandboxClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ContainerAppsSandboxClient(Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientSettings settings) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroup GetSandboxGroupClient(string subscriptionId, string resourceGroupName, string sandboxGroupName) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ContainerAppsSandboxClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
    }
    public partial class ContainerAppsSandboxClientOptions : Azure.Core.ClientOptions
    {
        public ContainerAppsSandboxClientOptions(Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion version = Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion.V2026_09_01_Preview) { }
        public enum ServiceVersion
        {
            V2026_09_01_Preview = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ContainerAppsSandboxClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ContainerAppsSandboxClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ContainerAppsSandboxClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class ContainerProbe : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbe>
    {
        public ContainerProbe() { }
        public Azure.Containers.Apps.Sandbox.ProbeExecAction Exec { get { throw null; } set { } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ProbeHttpGetAction HttpGet { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction TcpSocket { get { throw null; } set { } }
        public int? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerProbe JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerProbe PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerProbe System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerProbe System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerProbeResult : System.IEquatable<Azure.Containers.Apps.Sandbox.ContainerProbeResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerProbeResult(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerProbeResult Failure { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerProbeResult Success { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerProbeResult Unknown { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ContainerProbeResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ContainerProbeResult left, Azure.Containers.Apps.Sandbox.ContainerProbeResult right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerProbeResult (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerProbeResult? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ContainerProbeResult left, Azure.Containers.Apps.Sandbox.ContainerProbeResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerProbeStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>
    {
        internal ContainerProbeStatus() { }
        public int? ConsecutiveFailures { get { throw null; } }
        public int? ConsecutiveSuccesses { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ContainerProbeResult? LastResult { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerProbeStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerProbeStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerProbeStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerResources>
    {
        public ContainerResources() { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRestartPolicy : System.IEquatable<Azure.Containers.Apps.Sandbox.ContainerRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRestartPolicy(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerRestartPolicy Always { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerRestartPolicy Never { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ContainerRestartPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ContainerRestartPolicy left, Azure.Containers.Apps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerRestartPolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerRestartPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ContainerRestartPolicy left, Azure.Containers.Apps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRuntimeState : System.IEquatable<Azure.Containers.Apps.Sandbox.ContainerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRuntimeState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerRuntimeState Running { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerRuntimeState Terminated { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerRuntimeState Unknown { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerRuntimeState Waiting { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ContainerRuntimeState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ContainerRuntimeState left, Azure.Containers.Apps.Sandbox.ContainerRuntimeState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerRuntimeState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerRuntimeState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ContainerRuntimeState left, Azure.Containers.Apps.Sandbox.ContainerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>
    {
        public ContainerSecurityContext() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.LinuxCapabilities Capabilities { get { throw null; } set { } }
        public bool? Privileged { get { throw null; } set { } }
        public bool? ReadOnlyRootFilesystem { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SeccompProfile SeccompProfile { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSpec : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSpec>
    {
        public ContainerSpec(string name) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ContainerResources Resources { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ContainerSecurityContext SecurityContext { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ContainerProbe StartupProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerSpec System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerSpec System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerStatus>
    {
        internal ContainerStatus() { }
        public int? LastExitCode { get { throw null; } }
        public System.DateTimeOffset? LastFinishedOn { get { throw null; } }
        public System.DateTimeOffset? LastStartedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.ContainerProbeStatus> Probes { get { throw null; } }
        public bool Ready { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ContainerStatusReason? Reason { get { throw null; } }
        public int RestartCount { get { throw null; } }
        public bool Started { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ContainerRuntimeState State { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerStatusReason : System.IEquatable<Azure.Containers.Apps.Sandbox.ContainerStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerStatusReason(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContainerStatusReason Completed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerStatusReason CrashLoopBackOff { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerStatusReason Error { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerStatusReason RootfsResetFailed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContainerStatusReason RootfsResetPending { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ContainerStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ContainerStatusReason left, Azure.Containers.Apps.Sandbox.ContainerStatusReason right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerStatusReason (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContainerStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ContainerStatusReason left, Azure.Containers.Apps.Sandbox.ContainerStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerVolumeMount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerVolumeMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerVolumeMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolumeMounts : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>
    {
        public ContainerVolumeMounts(string containerName, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerVolumeMount> volumeMounts) { }
        public string ContainerName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerVolumeMounts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ContainerVolumeMounts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContainerVolumeMounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContentPackage>
    {
        internal ContentPackage() { }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public long Size { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.ContentPackage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentPackageAction : System.IEquatable<Azure.Containers.Apps.Sandbox.ContentPackageAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentPackageAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ContentPackageAction Download { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ContentPackageAction Mount { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ContentPackageAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ContentPackageAction left, Azure.Containers.Apps.Sandbox.ContentPackageAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContentPackageAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ContentPackageAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ContentPackageAction left, Azure.Containers.Apps.Sandbox.ContentPackageAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CpuStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CpuStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CpuStats>
    {
        internal CpuStats() { }
        public long? Idle { get { throw null; } }
        public long? Iowait { get { throw null; } }
        public long? Irq { get { throw null; } }
        public double? LoadAvg1 { get { throw null; } }
        public double? LoadAvg15 { get { throw null; } }
        public double? LoadAvg5 { get { throw null; } }
        public long? Nice { get { throw null; } }
        public long? Softirq { get { throw null; } }
        public long? Steal { get { throw null; } }
        public long? System { get { throw null; } }
        public long? User { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CpuStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.CpuStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CpuStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CpuStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CpuStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CpuStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CpuStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CpuStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CpuStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>
    {
        public CreateConnectionContent(string name, string type) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string ParameterValueSetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValueSetValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateConnectionContent createConnectionContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>
    {
        public CreateDiskImageContent(Azure.Containers.Apps.Sandbox.CreateDiskImageSource source) { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.CreateDiskImageSource Source { get { throw null; } }
        public string VnetConnectionName { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateDiskImageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateDiskImageContent createDiskImageContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateDiskImageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CreateDiskImageSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>
    {
        internal CreateDiskImageSource() { }
        protected virtual Azure.Containers.Apps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceBlobSource : Azure.Containers.Apps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>
    {
        public CreateDiskImageSourceBlobSource(System.Uri blobSourceUri) { }
        public System.Uri BlobSourceUri { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceRegistrySource : Azure.Containers.Apps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>
    {
        public CreateDiskImageSourceRegistrySource(string imageReference) { }
        public Azure.Containers.Apps.Sandbox.RegistryAuthentication Authentication { get { throw null; } set { } }
        public string ImageReference { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>
    {
        public CreateSandboxContent() { }
        public Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } set { } }
        public string AnthropicApiKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } set { } }
        public string EgressPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent> GatewayConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent> Ports { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxPresetProperties PresetProperties { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PresetSandboxType? PresetSandboxType { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxResources Resources { get { throw null; } set { } }
        public string SandboxGroupId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxSource SourcesRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public string VnetConnectionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateSandboxContent createSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGatewayConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>
    {
        public CreateSandboxGatewayConnectionContent(string resourceId) { }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGroupCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>
    {
        public CreateSandboxGroupCredentialContent(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider provider, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource source) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent createSandboxGroupCredentialContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxPortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>
    {
        public CreateSandboxPortContent(int port) { }
        public Azure.Containers.Apps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxPortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateSandboxPortContent createSandboxPortContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSandboxPortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSandboxPortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSecretContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>
    {
        public CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values) { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSecretContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateSecretContent createSecretContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSecretContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSecretContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSnapshotContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>
    {
        public CreateSnapshotContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSnapshotContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.CreateSnapshotContent createSnapshotContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.CreateSnapshotContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.CreateSnapshotContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskPodVolume : Azure.Containers.Apps.Sandbox.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>
    {
        public DataDiskPodVolume(string name) { }
        protected override Azure.Containers.Apps.Sandbox.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolume : Azure.Containers.Apps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>
    {
        public DataDiskVolume(string size) { }
        public string AttachedSandboxId { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public bool IsAttached { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>
    {
        internal DataDiskVolumeUsage() { }
        public long CompressedBlobSizeBytes { get { throw null; } }
        public System.DateTimeOffset LastUploadedAtUtc { get { throw null; } }
        public long UsedSizeBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DataDiskVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirListingResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DirListingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DirListingResult>
    {
        internal DirListingResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.FileInfo> Entries { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DirListingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.DirListingResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.DirListingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DirListingResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DirListingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DirListingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DirListingResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DirListingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DirListingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DirListingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImage>
    {
        internal DiskImage() { }
        public string Id { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.DiskImageImage Image { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public long? SizeInMb { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.DiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageImage>
    {
        internal DiskImageImage() { }
        public string Base { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImageImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImageImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DiskImageImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DiskImageImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>
    {
        internal DiskImageStatus() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.DiskImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskStatsEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>
    {
        internal DiskStatsEntry() { }
        public long? AvailableBytes { get { throw null; } }
        public string Filesystem { get { throw null; } }
        public string Label { get { throw null; } }
        public string MountPoint { get { throw null; } }
        public long? TotalBytes { get { throw null; } }
        public long? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DiskStatsEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.DiskStatsEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DiskStatsEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadContentPackageToSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>
    {
        public DownloadContentPackageToSandboxContent(string contentPackageId, string targetPath) { }
        public string ContentPackageId { get { throw null; } }
        public string TargetPath { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent downloadContentPackageToSandboxContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>
    {
        internal EgressDecisionEntry() { }
        public string ConnectionId { get { throw null; } }
        public string ConnectionName { get { throw null; } }
        public string Host { get { throw null; } }
        public string MatchedRule { get { throw null; } }
        public string Method { get { throw null; } }
        public string Path { get { throw null; } }
        public string Scheme { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressDecisionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressDecisionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>
    {
        internal EgressDecisionsResult() { }
        public Azure.Containers.Apps.Sandbox.NetworkEgressDecisions Http { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.StatefulTcpEgress StatefulTcp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressDecisionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.EgressDecisionsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.EgressDecisionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressForwardMode : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressForwardMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressForwardMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressForwardMode Default { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressForwardMode Direct { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressForwardMode Proxy { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressForwardMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressForwardMode left, Azure.Containers.Apps.Sandbox.EgressForwardMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressForwardMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressForwardMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressForwardMode left, Azure.Containers.Apps.Sandbox.EgressForwardMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressForwardProxy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>
    {
        public EgressForwardProxy(System.Uri url) { }
        public string CertificateAuthority { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressForwardProxy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressForwardProxy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressForwardProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressHostRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressHostRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressHostRule>
    {
        public EgressHostRule(string pattern) { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyAction? Action { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressHostRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressHostRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressHostRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressHostRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressHostRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressHostRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressHostRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressHostRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressHostRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyAction : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyAction Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyAction left, Azure.Containers.Apps.Sandbox.EgressPolicyAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyAction left, Azure.Containers.Apps.Sandbox.EgressPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyActionType : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyActionType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyActionType Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyActionType Deny { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyActionType Rewrite { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyActionType Transform { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyActionType left, Azure.Containers.Apps.Sandbox.EgressPolicyActionType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyActionType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyActionType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyActionType left, Azure.Containers.Apps.Sandbox.EgressPolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyEnforcementMode : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyEnforcementMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode Audit { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode Enforced { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode left, Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode left, Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHeaderOperation : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHeaderOperation(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation Insert { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation Remove { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation Set { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation left, Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation left, Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHeaderTransform : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>
    {
        public EgressPolicyHeaderTransform(Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation operation, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyHeaderOperation Operation { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyValueRef ValueRef { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHookFailBehavior : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHookFailBehavior(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior left, Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior left, Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHookRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>
    {
        public EgressPolicyHookRef(string endpoint) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform> AuthHeaders { get { throw null; } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyHookFailBehavior? FailBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequestHeaders { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public int? TimeoutMs { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyHookRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyHookRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyHookRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyManagedIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>
    {
        public EgressPolicyManagedIdentityRef(string resource) { }
        public string Format { get { throw null; } set { } }
        public string IdentityResourceId { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyManagedIdentityType : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyManagedIdentityType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType left, Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType left, Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyMatchScheme : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyMatchScheme(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme Any { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme Http { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme Https { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme left, Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme left, Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>
    {
        public EgressPolicyRule(string name, Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch match) { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction Action { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProxyActions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>
    {
        public EgressPolicyRuleAction(Azure.Containers.Apps.Sandbox.EgressPolicyActionType type) { }
        public Azure.Containers.Apps.Sandbox.EgressForwardMode? Forward { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressForwardProxy ForwardProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressPolicyHeaderTransform> Headers { get { throw null; } }
        public string Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>
    {
        public EgressPolicyRuleMatch(string host) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public bool? NormalizePath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyMatchScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyRuleMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicySecretRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>
    {
        public EgressPolicySecretRef(string secretId) { }
        public string Format { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicySecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicySecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicySecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyValueRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>
    {
        public EgressPolicyValueRef() { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyManagedIdentityRef ManagedIdentityRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyValueRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.EgressPolicyValueRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.EgressPolicyValueRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressRuleRoutingMode : System.IEquatable<Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressRuleRoutingMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode Default { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode Platform { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode Vnet { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode left, Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode left, Azure.Containers.Apps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecuteSandboxCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>
    {
        public ExecuteSandboxCommandContent(string command) { }
        public Azure.Containers.Apps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent executeSandboxCommandContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxShellCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>
    {
        public ExecuteSandboxShellCommandContent(string command) { }
        public Azure.Containers.Apps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string Shell { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent executeSandboxShellCommandContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileInfo : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileInfo>
    {
        internal FileInfo() { }
        public bool IsDir { get { throw null; } }
        public bool IsSymlink { get { throw null; } }
        public int Mode { get { throw null; } }
        public long ModifiedTime { get { throw null; } }
        public string Name { get { throw null; } }
        public string Path { get { throw null; } }
        public long Size { get { throw null; } }
        public string SymlinkTarget { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.FileInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.FileInfo (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.FileInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.FileInfo System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.FileInfo System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileOpStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>
    {
        internal FileOpStatusResult() { }
        public string Error { get { throw null; } }
        public string Message { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.FileOpStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.FileOpStatusResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.FileOpStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.FileOpStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForkDataDiskVolumeContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>
    {
        public ForkDataDiskVolumeContent(string destinationVolumeName) { }
        public string DestinationVolumeName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent forkDataDiskVolumeContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FsGroupChangePolicy : System.IEquatable<Azure.Containers.Apps.Sandbox.FsGroupChangePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FsGroupChangePolicy(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.FsGroupChangePolicy Always { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.FsGroupChangePolicy None { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.FsGroupChangePolicy OnRootMismatch { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.FsGroupChangePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.FsGroupChangePolicy left, Azure.Containers.Apps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.FsGroupChangePolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.FsGroupChangePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.FsGroupChangePolicy left, Azure.Containers.Apps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>
    {
        internal GatewayAuthentication() { }
        public Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnection>
    {
        internal GatewayConnection() { }
        public Azure.Containers.Apps.Sandbox.GatewayAuthentication Authentication { get { throw null; } }
        public System.Uri ConnectionRuntimeUri { get { throw null; } }
        public System.Uri McpRuntimeUri { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.GatewayConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.GatewayConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnectionAuthRecord : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>
    {
        public GatewayConnectionAuthRecord(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayConnectionAuthType : System.IEquatable<Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayConnectionAuthType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType left, Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType left, Azure.Containers.Apps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateConsentLinkContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>
    {
        public GenerateConsentLinkContent() { }
        public System.Uri RedirectUri { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent generateConsentLinkContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateConsentLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>
    {
        internal GenerateConsentLinkResult() { }
        public System.Uri ConsentLink { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>
    {
        public HttpEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyAction defaultAction) { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressForwardProxy DefaultForward { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.HttpEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.HttpEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.HttpEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentitySetting : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IdentitySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IdentitySetting>
    {
        public IdentitySetting(string identity) { }
        public string Identity { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle? Lifecycle { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.IdentitySetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.IdentitySetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.IdentitySetting System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IdentitySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IdentitySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.IdentitySetting System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IdentitySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IdentitySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IdentitySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentitySettingLifecycle : System.IEquatable<Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentitySettingLifecycle(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle All { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle Main { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle left, Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle left, Azure.Containers.Apps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControl>
    {
        public IPAccessControl(Azure.Containers.Apps.Sandbox.IPAccessControlAction defaultAction) { }
        public Azure.Containers.Apps.Sandbox.IPAccessControlAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.IPAccessControlRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.IPAccessControl JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.IPAccessControl PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.IPAccessControl System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.IPAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlAction : System.IEquatable<Azure.Containers.Apps.Sandbox.IPAccessControlAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlAction(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.IPAccessControlAction Allow { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.IPAccessControlAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.IPAccessControlAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.IPAccessControlAction left, Azure.Containers.Apps.Sandbox.IPAccessControlAction right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.IPAccessControlAction (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.IPAccessControlAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.IPAccessControlAction left, Azure.Containers.Apps.Sandbox.IPAccessControlAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControlRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>
    {
        public IPAccessControlRule(string name, Azure.Containers.Apps.Sandbox.IPAccessControlAction action, int priority, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes) { }
        public Azure.Containers.Apps.Sandbox.IPAccessControlAction Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.IPAccessControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.IPAccessControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.IPAccessControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>
    {
        public LinuxCapabilities() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.LinuxCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.LinuxCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LinuxCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalPodVolume : Azure.Containers.Apps.Sandbox.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>
    {
        public LocalPodVolume(string name, string size) { }
        public string Size { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LocalPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsLegacyTelemetryEndpoint : Azure.Containers.Apps.Sandbox.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>
    {
        public LogAnalyticsLegacyTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data, string workspaceId, string tableName, Azure.Containers.Apps.Sandbox.TelemetrySecretReference auth) { }
        public Azure.Containers.Apps.Sandbox.TelemetrySecretReference Auth { get { throw null; } }
        public string TableName { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogAnalyticsTelemetryEndpoint : Azure.Containers.Apps.Sandbox.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>
    {
        public LogAnalyticsTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data, System.Uri dceEndpoint, string dcrImmutableId, string tableName, Azure.Containers.Apps.Sandbox.TelemetryAuth auth) { }
        public Azure.Containers.Apps.Sandbox.TelemetryAuth Auth { get { throw null; } }
        public System.Uri DceEndpoint { get { throw null; } }
        public string DcrImmutableId { get { throw null; } }
        public string TableName { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class LogColumnDef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogColumnDef>
    {
        internal LogColumnDef() { }
        protected virtual Azure.Containers.Apps.Sandbox.LogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.LogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.LogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.LogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.LogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.LogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogColumnRef : System.IEquatable<Azure.Containers.Apps.Sandbox.LogColumnRef>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogColumnRef(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.LogColumnRef ContainerName { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.LogColumnRef LogContent { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.LogColumnRef LogStream { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.LogColumnRef Region { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.LogColumnRef SandboxId { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.LogColumnRef other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.LogColumnRef left, Azure.Containers.Apps.Sandbox.LogColumnRef right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.LogColumnRef (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.LogColumnRef? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.LogColumnRef left, Azure.Containers.Apps.Sandbox.LogColumnRef right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>
    {
        public ManagedIdentityAuthentication(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityAuthenticationType : System.IEquatable<Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityAuthenticationType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType SystemAssigned { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType left, Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType left, Azure.Containers.Apps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>
    {
        public McpPolicyRule(string hookId, System.Collections.Generic.IEnumerable<string> patterns) { }
        public string HookId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.McpPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.McpPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.McpPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MemoryStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MemoryStats>
    {
        internal MemoryStats() { }
        public long? AvailableBytes { get { throw null; } }
        public long? TotalBytes { get { throw null; } }
        public long? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.MemoryStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.MemoryStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.MemoryStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MemoryStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MemoryStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.MemoryStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MemoryStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MemoryStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MemoryStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MkDirContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MkDirContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MkDirContent>
    {
        public MkDirContent(string path) { }
        public bool? CreateParents { get { throw null; } set { } }
        public int? Mode { get { throw null; } set { } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.MkDirContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.MkDirContent mkDirContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.MkDirContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.MkDirContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MkDirContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.MkDirContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.MkDirContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MkDirContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MkDirContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.MkDirContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>
    {
        public NamedEgressPolicy(string name, Azure.Containers.Apps.Sandbox.EgressPolicyAction defaultAction) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.NamedEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.NamedEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.NamedEgressPolicy namedEgressPolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.NamedEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkEgressDecisions : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>
    {
        internal NetworkEgressDecisions() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressDecisionEntry> Allowed { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressDecisionEntry> Denied { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.NetworkEgressDecisions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.NetworkEgressDecisions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkEgressDecisions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkStats>
    {
        internal NetworkStats() { }
        public long? RxBytes { get { throw null; } }
        public long? RxPackets { get { throw null; } }
        public long? TxBytes { get { throw null; } }
        public long? TxPackets { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.NetworkStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.NetworkStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.NetworkStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.NetworkStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.NetworkStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.NetworkStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : Azure.Containers.Apps.Sandbox.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryData> data, System.Uri endpoint, Azure.Containers.Apps.Sandbox.TelemetryProtocol protocol) { }
        public Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth Auth { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.TelemetryProtocol Protocol { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodContentPackage>
    {
        public PodContentPackage(string contentPackageId) { }
        public string ContentPackageId { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.PodContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PodContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PodContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PodContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>
    {
        public PodSecurityContext() { }
        public int? FsGroup { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.FsGroupChangePolicy? FsGroupChangePolicy { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SupplementalGroups { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.PodSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PodSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodVolume>
    {
        internal PodVolume() { }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortActivationMode : System.IEquatable<Azure.Containers.Apps.Sandbox.PortActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortActivationMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortActivationMode Manual { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.PortActivationMode OnDemand { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.PortActivationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.PortActivationMode left, Azure.Containers.Apps.Sandbox.PortActivationMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PortActivationMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PortActivationMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.PortActivationMode left, Azure.Containers.Apps.Sandbox.PortActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>
    {
        public PortAuthConfig() { }
        public bool? Anonymous { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId EntraId { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortAuthConfigGithub Github { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigEntraId : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>
    {
        public PortAuthConfigEntraId() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectIds { get { throw null; } }
        public System.Collections.Generic.IList<string> TenantIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigEntraId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigGithub : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>
    {
        public PortAuthConfigGithub() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UsernameSuffixes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfigGithub JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PortAuthConfigGithub PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortAuthConfigGithub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortCorsConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>
    {
        public PortCorsConfig() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowOrigins { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.PortCorsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.PortCorsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortCorsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.PortProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PortProtocol Http { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.PortProtocol Http2 { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.PortProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.PortProtocol left, Azure.Containers.Apps.Sandbox.PortProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PortProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PortProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.PortProtocol left, Azure.Containers.Apps.Sandbox.PortProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortsListResult>
    {
        internal PortsListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxPort> Ports { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.PortsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.PortsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.PortsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PortsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PortsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PortsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PortsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PresetSandboxType : System.IEquatable<Azure.Containers.Apps.Sandbox.PresetSandboxType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PresetSandboxType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.PresetSandboxType Claude { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.PresetSandboxType GitHubCopilot { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.PresetSandboxType None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.PresetSandboxType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.PresetSandboxType left, Azure.Containers.Apps.Sandbox.PresetSandboxType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PresetSandboxType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.PresetSandboxType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.PresetSandboxType left, Azure.Containers.Apps.Sandbox.PresetSandboxType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProbeExecAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>
    {
        public ProbeExecAction(System.Collections.Generic.IEnumerable<string> command) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeExecAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeExecAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpGetAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>
    {
        public ProbeHttpGetAction(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ProbeHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeHttpGetAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeHttpGetAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpGetAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>
    {
        public ProbeHttpHeader(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeHttpHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeHttpHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeHttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeTcpSocketAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>
    {
        public ProbeTcpSocketAction(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ProbeTcpSocketAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>
    {
        internal PublicDiskImage() { }
        public string Name { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.PublicDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.PublicDiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.PublicDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.PublicDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefLogColumnDef : Azure.Containers.Apps.Sandbox.LogColumnDef, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>
    {
        public RefLogColumnDef(Azure.Containers.Apps.Sandbox.LogColumnRef refName) { }
        public Azure.Containers.Apps.Sandbox.LogColumnRef RefName { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.LogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.LogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RefLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>
    {
        public RegistryAuthentication() { }
        public Azure.Containers.Apps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.RegistryCredentials RegistryCredentials { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.RegistryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.RegistryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>
    {
        public RegistryCredentials(string username, string token) { }
        public string Token { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.RegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.RegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemovePortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RemovePortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RemovePortContent>
    {
        public RemovePortContent() { }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.RemovePortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.RemovePortContent removePortContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.RemovePortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.RemovePortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RemovePortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.RemovePortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.RemovePortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RemovePortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RemovePortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.RemovePortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAgentIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>
    {
        public SandboxAgentIdentityRef(string tenantId, string agentId) { }
        public string AgentId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAgentIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoDeletePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>
    {
        public SandboxAutoDeletePolicy(bool enabled) { }
        public int? DeleteIntervalInDays { get { throw null; } set { } }
        public long? DeleteIntervalInSeconds { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.AutoDeleteTrigger? Trigger { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoSuspendPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>
    {
        public SandboxAutoSuspendPolicy(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxSuspendMode? Mode { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxConnection>
    {
        internal SandboxConnection() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Deletable { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string State { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UsedBySandboxIds { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxConnection (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxContentPackageDownload : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>
    {
        public SandboxContentPackageDownload(string contentPackageId, string targetPath) { }
        public Azure.Containers.Apps.Sandbox.ContentPackageAction? Action { get { throw null; } set { } }
        public string ContentPackageId { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxContentPackageDownload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>
    {
        internal SandboxCountResult() { }
        public int Count { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>
    {
        public SandboxEgressPolicy() { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyAction? DefaultAction { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.HttpEgressSection Http { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.TdsEgressSection Tds { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.TransportEgressSection TransportRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ValidationWarning> ValidationWarnings { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.SandboxEgressPolicy sandboxEgressPolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>
    {
        internal SandboxExecuteCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteShellCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>
    {
        internal SandboxExecuteShellCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroup
    {
        protected SandboxGroup() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> CreateSandbox(Azure.Containers.Apps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandbox(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> CreateSandboxAsync(Azure.Containers.Apps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSandboxCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxCountResult> GetSandboxCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxCountResult>> GetSandboxCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSandboxes(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> GetSandboxes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSandboxesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> GetSandboxesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupConnections GetSandboxGroupConnectionsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupContentPackages GetSandboxGroupContentPackagesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredentials GetSandboxGroupCredentialsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupDiskImages GetSandboxGroupDiskImagesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupEgressPolicies GetSandboxGroupEgressPoliciesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSandbox GetSandboxGroupSandboxClient(string id) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSecrets GetSandboxGroupSecretsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSnapshots GetSandboxGroupSnapshotsClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupVolumes GetSandboxGroupVolumesClient() { throw null; }
    }
    public partial class SandboxGroupConnections
    {
        protected SandboxGroupConnections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection> AuthorizeConnection(string id, Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeConnection(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection>> AuthorizeConnectionAsync(string id, Azure.Containers.Apps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeConnectionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection> CreateConnection(Azure.Containers.Apps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection>> CreateConnectionAsync(Azure.Containers.Apps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult> GenerateConnectionConsentLink(string id, Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateConnectionConsentLink(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.GenerateConsentLinkResult>> GenerateConnectionConsentLinkAsync(string id, Azure.Containers.Apps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateConnectionConsentLinkAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection> GetConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection>> GetConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetConnections(bool? includeSandboxIds, string labels, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxConnection> GetConnections(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetConnectionsAsync(bool? includeSandboxIds, string labels, string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxConnection> GetConnectionsAsync(bool? includeSandboxIds = default(bool?), string labels = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection> RefreshConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection>> RefreshConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection> UpdateConnectionPolicyRules(string id, Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateConnectionPolicyRules(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxConnection>> UpdateConnectionPolicyRulesAsync(string id, Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateConnectionPolicyRulesAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupContentPackages
    {
        protected SandboxGroupContentPackages() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteContentPackage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetContentPackage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackage> GetContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackage>> GetContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetContentPackages(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.ContentPackage> GetContentPackages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetContentPackagesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.ContentPackage> GetContentPackagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadContentPackage(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackage> UploadContentPackage(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadContentPackageAsync(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContentPackage>> UploadContentPackageAsync(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>
    {
        internal SandboxGroupCredential() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin Origin { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ConnectionState State { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredential (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupCredentialConnectionRefDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>
    {
        public SandboxGroupCredentialConnectionRefDetails(Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord authentication, System.Uri tokenExchangeEndpoint) { }
        public Azure.Containers.Apps.Sandbox.GatewayConnectionAuthRecord Authentication { get { throw null; } set { } }
        public System.Uri TokenExchangeEndpoint { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialOrigin : System.IEquatable<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialOrigin(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin Connections { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin Credentials { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialProvider : System.IEquatable<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialProvider(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider Claude { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider GitHubCopilot { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxGroupCredentials
    {
        protected SandboxGroupCredentials() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteCredential(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredential(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupCredential> GetCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>> GetCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCredentials(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxGroupCredential> GetCredentials(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCredentialsAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxGroupCredential> GetCredentialsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupCredential> SetCredential(string credentialName, Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetCredential(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupCredential>> SetCredentialAsync(string credentialName, Azure.Containers.Apps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetCredentialAsync(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupCredentialSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>
    {
        public SandboxGroupCredentialSource(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind kind) { }
        public string ConnectionId { get { throw null; } set { } }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialConnectionRefDetails ConnectionRefDetails { get { throw null; } set { } }
        public string ConnectionResourceId { get { throw null; } set { } }
        public string ConnectionType { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialSourceKind : System.IEquatable<Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialSourceKind(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind ExistingAdcConnection { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind GatewayConnectionRef { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind Pat { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind SecretRef { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.Containers.Apps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxGroupDiskImages
    {
        protected SandboxGroupDiskImages() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.DiskImage> CreateDiskImage(Azure.Containers.Apps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateDiskImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.DiskImage>> CreateDiskImageAsync(Azure.Containers.Apps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateDiskImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.DiskImage> GetDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.DiskImage>> GetDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDiskImages(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.DiskImage> GetDiskImages(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDiskImagesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.DiskImage> GetDiskImagesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicDiskImage(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PublicDiskImage> GetPublicDiskImage(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicDiskImageAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PublicDiskImage>> GetPublicDiskImageAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPublicDiskImages(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.PublicDiskImage> GetPublicDiskImages(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPublicDiskImagesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.PublicDiskImage> GetPublicDiskImagesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupEgressPolicies
    {
        protected SandboxGroupEgressPolicies() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEgressPolicies(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.NamedEgressPolicy> GetEgressPolicies(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEgressPoliciesAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.NamedEgressPolicy> GetEgressPoliciesAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.NamedEgressPolicy> GetEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>> GetEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.NamedEgressPolicy> SetEgressPolicy(string policyId, Azure.Containers.Apps.Sandbox.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.NamedEgressPolicy>> SetEgressPolicyAsync(string policyId, Azure.Containers.Apps.Sandbox.NamedEgressPolicy resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public abstract partial class SandboxGroupIdentitySelector : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>
    {
        internal SandboxGroupIdentitySelector() { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorSystemAssignedIdentitySelector : Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorUserAssignedIdentitySelector : Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupSandbox
    {
        protected SandboxGroupSandbox() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Containers.Apps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Containers.Apps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Containers.Apps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.CommitSandboxResult> Commit(Azure.Containers.Apps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Commit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.CommitSandboxResult>> CommitAsync(Azure.Containers.Apps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CommitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot> CreateSnapshot(Azure.Containers.Apps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot>> CreateSnapshotAsync(Azure.Containers.Apps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Containers.Apps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Enable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult> ExecuteCommand(Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxExecuteCommandResult>> ExecuteCommandAsync(Azure.Containers.Apps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult> ExecuteShellCommand(Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteShellCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(Azure.Containers.Apps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteShellCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSandboxFiles GetSandboxGroupSandboxFilesClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSandboxNetworking GetSandboxGroupSandboxNetworkingClient() { throw null; }
        public virtual Azure.Containers.Apps.Sandbox.SandboxGroupSandboxStreams GetSandboxGroupSandboxStreamsClient() { throw null; }
        public virtual Azure.Response GetStats(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxStatsResult> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxStatsResult>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox> SetLifecyclePolicy(Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLifecyclePolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ContainerAppsSandbox>> SetLifecyclePolicyAsync(Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLifecyclePolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Stop(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot> Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot>> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupSandboxFiles
    {
        protected SandboxGroupSandboxFiles() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.FileOpStatusResult> CreateSandboxDirectory(Azure.Containers.Apps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandboxDirectory(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.FileOpStatusResult>> CreateSandboxDirectoryAsync(Azure.Containers.Apps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxDirectoryAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSandboxFile(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.FileOpStatusResult> DeleteSandboxFile(string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSandboxFileAsync(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.FileOpStatusResult>> DeleteSandboxFileAsync(string path, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadSandboxFile(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> DownloadSandboxFile(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadSandboxFileAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> DownloadSandboxFileAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFileMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.FileInfo> GetSandboxFileMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.FileInfo>> GetSandboxFileMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFilesMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.DirListingResult> GetSandboxFilesMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFilesMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.DirListingResult>> GetSandboxFilesMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadSandboxFile(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.WriteFileResult> UploadSandboxFile(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadSandboxFileAsync(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.WriteFileResult>> UploadSandboxFileAsync(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupSandboxNetworking
    {
        protected SandboxGroupSandboxNetworking() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionsListResult> AddConnection(Azure.Containers.Apps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.ConnectionsListResult>> AddConnectionAsync(Azure.Containers.Apps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult> AddPort(Azure.Containers.Apps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult>> AddPortAsync(Azure.Containers.Apps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEgressDecisions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.EgressDecisionsResult> GetEgressDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressDecisionsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.EgressDecisionsResult>> GetEgressDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPorts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult> GetPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPortsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult>> GetPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult> RemovePort(Azure.Containers.Apps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemovePort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult>> RemovePortAsync(Azure.Containers.Apps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemovePortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy> SetEgressPolicy(Azure.Containers.Apps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxEgressPolicy>> SetEgressPolicyAsync(Azure.Containers.Apps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult> SetPorts(Azure.Containers.Apps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetPorts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.PortsListResult>> SetPortsAsync(Azure.Containers.Apps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetPortsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdatePort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupSandboxStreams
    {
        protected SandboxGroupSandboxStreams() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSandboxExecStream(string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxExecStream(string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string containerName, string user, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxExecStreamAsync(string containerName = null, string user = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxLogStream(int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(int? tailLines, int? logFormat, bool? follow, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxLogStreamAsync(int? tailLines = default(int?), int? logFormat = default(int?), bool? follow = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetSandboxProcessesStream(string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxProcessesStreamAsync(string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupSecrets
    {
        protected SandboxGroupSecrets() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteSecret(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSecret(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSecretAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSecretKeys(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SecretKeysResult> GetSecretKeys(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretKeysAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SecretKeysResult>> GetSecretKeysAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSecrets(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxSecret> GetSecrets(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSecretsAsync(string skipToken, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxSecret> GetSecretsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PeekSecret(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SecretPeekResult> PeekSecret(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PeekSecretAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SecretPeekResult>> PeekSecretAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSecret> SetSecret(string secretId, Azure.Containers.Apps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetSecret(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSecret>> SetSecretAsync(string secretId, Azure.Containers.Apps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetSecretAsync(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupSnapshots
    {
        protected SandboxGroupSnapshots() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteSnapshot(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshot(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot> GetSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxSnapshot>> GetSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshotCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotCountResult> GetSnapshotCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SnapshotCountResult>> GetSnapshotCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSnapshots(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxSnapshot> GetSnapshots(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSnapshotsAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxSnapshot> GetSnapshotsAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class SandboxGroupVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>
    {
        internal SandboxGroupVolume() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.VolumeProvisioningState ProvisioningState { get { throw null; } }
        public string VolumeName { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxGroupVolume (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.SandboxGroupVolume sandboxGroupVolume) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupVolumes
    {
        protected SandboxGroupVolumes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume> CreateVolume(string volumeName, Azure.Containers.Apps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>> CreateVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateVolumeDirectory(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumePathItem> CreateVolumeDirectory(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeDirectoryAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumePathItem>> CreateVolumeDirectoryAsync(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadVolumeFile(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> DownloadVolumeFile(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadVolumeFileAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> DownloadVolumeFileAsync(string volumeName, string path, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume> ForkVolume(string volumeName, Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ForkVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>> ForkVolumeAsync(string volumeName, Azure.Containers.Apps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ForkVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.SandboxGroupVolume>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeCounts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumeCountResult> GetVolumeCounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeCountsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumeCountResult>> GetVolumeCountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFilesMetadata(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult> GetVolumeFilesMetadata(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFilesMetadataAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>> GetVolumeFilesMetadataAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetVolumes(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.Containers.Apps.Sandbox.SandboxGroupVolume> GetVolumes(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetVolumesAsync(string skipToken, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Containers.Apps.Sandbox.SandboxGroupVolume> GetVolumesAsync(string skipToken = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadVolumeFile(string volumeName, string path, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.Apps.Sandbox.VolumePathItem> UploadVolumeFile(string volumeName, string path, System.BinaryData content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadVolumeFileAsync(string volumeName, string path, Azure.Core.RequestContent content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.Apps.Sandbox.VolumePathItem>> UploadVolumeFileAsync(string volumeName, string path, System.BinaryData content, bool? overwrite = default(bool?), Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxLifecyclePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>
    {
        public SandboxLifecyclePolicy(Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy, Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy) { }
        public Azure.Containers.Apps.Sandbox.SandboxAutoDeletePolicy AutoDeletePolicy { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxAutoSuspendPolicy AutoSuspendPolicy { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy sandboxLifecyclePolicy) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxLifecyclePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPort : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPort>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPort>
    {
        internal SandboxPort() { }
        public Azure.Containers.Apps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.PortAuthConfig Auth { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.PortCorsConfig Cors { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } }
        public string Name { get { throw null; } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.PortProtocol? Protocol { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPort JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPort PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxPort System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxPort System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPortUpdate : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>
    {
        public SandboxPortUpdate(int port, System.Uri url) { }
        public Azure.Containers.Apps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPortUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPortUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPortUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPresetProperties : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>
    {
        public SandboxPresetProperties() { }
        public bool? IsWorkIqConnectionEnabled { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPresetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxPresetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxPresetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxResources>
    {
        public SandboxResources(string cpu, string memory) { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSecret : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSecret>
    {
        internal SandboxSecret() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSecret JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxSecret (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSecret PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSecret System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSecret System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>
    {
        internal SandboxSnapshot() { }
        public System.DateTimeOffset CreatedAtUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.SnapshotResources Resources { get { throw null; } }
        public string SandboxId { get { throw null; } }
        public long? SizeInMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.Apps.Sandbox.SnapshotPodContainer> SourcePodContainers { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxSnapshot (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSource>
    {
        public SandboxSource() { }
        public Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxSourcePod Pod { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot Snapshot { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceArtifactVersion : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>
    {
        public SandboxSourceArtifactVersion(string id, Azure.Containers.Apps.Sandbox.SandboxSourceAuth auth) { }
        public Azure.Containers.Apps.Sandbox.SandboxSourceAuth Auth { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceArtifactVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>
    {
        public SandboxSourceAuth(string identity) { }
        public string Identity { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>
    {
        public SandboxSourceDiskImage() { }
        public string Id { get { throw null; } set { } }
        public bool? IsPublic { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourcePod : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>
    {
        public SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.ContainerSpec> containers) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.ContainerSpec> Containers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.PodContentPackage> ContentPackages { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.ContainerRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.PodSecurityContext SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.PodVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourcePod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourcePod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourcePod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>
    {
        public SandboxSourceSnapshot(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxSourceSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxState : System.IEquatable<Azure.Containers.Apps.Sandbox.SandboxState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxState Creating { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxState Idle { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxState Running { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxState StopFailed { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxState Stopped { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxState Stopping { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SandboxState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SandboxState left, Azure.Containers.Apps.Sandbox.SandboxState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SandboxState left, Azure.Containers.Apps.Sandbox.SandboxState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>
    {
        internal SandboxStateDetails() { }
        public System.DateTimeOffset StoppedOn { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.StoppedReason StoppedReason { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxStateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxStateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxStatsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>
    {
        internal SandboxStatsResult() { }
        public Azure.Containers.Apps.Sandbox.CpuStats Cpu { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.DiskStatsEntry> Disk { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.MemoryStats Memory { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.NetworkStats Network { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.TokenUsageStats TokenUsage { get { throw null; } }
        public double? UptimeSecs { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxStatsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SandboxStatsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxStatsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxStatsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxSuspendMode : System.IEquatable<Azure.Containers.Apps.Sandbox.SandboxSuspendMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxSuspendMode(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SandboxSuspendMode Disk { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxSuspendMode Memory { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SandboxSuspendMode None { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SandboxSuspendMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SandboxSuspendMode left, Azure.Containers.Apps.Sandbox.SandboxSuspendMode right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxSuspendMode (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SandboxSuspendMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SandboxSuspendMode left, Azure.Containers.Apps.Sandbox.SandboxSuspendMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxVolume>
    {
        public SandboxVolume(string volumeName, string mountpoint) { }
        public string Mountpoint { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SandboxVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SandboxVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SandboxVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SandboxVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SandboxVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SeccompProfile : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SeccompProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SeccompProfile>
    {
        public SeccompProfile(Azure.Containers.Apps.Sandbox.SeccompProfileType type) { }
        public Azure.Containers.Apps.Sandbox.SeccompProfileType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.SeccompProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SeccompProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SeccompProfile System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SeccompProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SeccompProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SeccompProfile System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SeccompProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SeccompProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SeccompProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeccompProfileType : System.IEquatable<Azure.Containers.Apps.Sandbox.SeccompProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeccompProfileType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.SeccompProfileType RuntimeDefault { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.SeccompProfileType Unconfined { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.SeccompProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.SeccompProfileType left, Azure.Containers.Apps.Sandbox.SeccompProfileType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SeccompProfileType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.SeccompProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.SeccompProfileType left, Azure.Containers.Apps.Sandbox.SeccompProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretKeysResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>
    {
        internal SecretKeysResult() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SecretKeysResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SecretKeysResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SecretKeysResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretKeysResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretPeekResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>
    {
        internal SecretPeekResult() { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SecretPeekResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SecretPeekResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SecretPeekResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SecretPeekResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedBlobPodVolume : Azure.Containers.Apps.Sandbox.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>
    {
        public ServiceManagedBlobPodVolume(string name, string fileCacheSizeLimit) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedBlobVolume : Azure.Containers.Apps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>
    {
        public ServiceManagedBlobVolume() { }
        public Azure.Containers.Apps.Sandbox.BlobVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ServiceManagedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>
    {
        internal SnapshotCountResult() { }
        public int Count { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.SnapshotCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SnapshotCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SnapshotCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPodContainer : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>
    {
        internal SnapshotPodContainer() { }
        public string DiskImageId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotPodContainer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotPodContainer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotPodContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotResources>
    {
        internal SnapshotResources() { }
        public string Cpu { get { throw null; } }
        public string Disk { get { throw null; } }
        public string Memory { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.SnapshotResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.SnapshotResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.SnapshotResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.SnapshotResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.SnapshotResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEgress : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>
    {
        internal StatefulTcpEgress() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.StatefulTcpEntry> Connections { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.StatefulTcpEgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.StatefulTcpEgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>
    {
        internal StatefulTcpEntry() { }
        public long? BytesIn { get { throw null; } }
        public long? BytesOut { get { throw null; } }
        public string ConnectorType { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string Database { get { throw null; } }
        public long? DurationMs { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Outcome { get { throw null; } }
        public string Phase { get { throw null; } }
        public int? Port { get { throw null; } }
        public string ProxyLoginName { get { throw null; } }
        public string Server { get { throw null; } }
        public string SourceIP { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.StatefulTcpEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.StatefulTcpEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.StatefulTcpEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoppedReason : System.IEquatable<Azure.Containers.Apps.Sandbox.StoppedReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoppedReason(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.StoppedReason Disabled { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.StoppedReason Idle { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.StoppedReason UserStopped { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.StoppedReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.StoppedReason left, Azure.Containers.Apps.Sandbox.StoppedReason right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.StoppedReason (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.StoppedReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.StoppedReason left, Azure.Containers.Apps.Sandbox.StoppedReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TdsAuthKind : System.IEquatable<Azure.Containers.Apps.Sandbox.TdsAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TdsAuthKind(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TdsAuthKind EntraToken { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TdsAuthKind SqlPassword { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.TdsAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.TdsAuthKind left, Azure.Containers.Apps.Sandbox.TdsAuthKind right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TdsAuthKind (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TdsAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.TdsAuthKind left, Azure.Containers.Apps.Sandbox.TdsAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdsCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsCredential>
    {
        public TdsCredential(string name, Azure.Containers.Apps.Sandbox.TdsAuthKind kind) { }
        public Azure.Containers.Apps.Sandbox.TdsAuthKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TdsCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TdsCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TdsCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TdsCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>
    {
        public TdsEgressAction(Azure.Containers.Apps.Sandbox.EgressPolicyActionType type) { }
        public string Credential { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>
    {
        public TdsEgressMatch(string host) { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Host { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>
    {
        public TdsEgressRule(string name, Azure.Containers.Apps.Sandbox.TdsEgressMatch match) { }
        public Azure.Containers.Apps.Sandbox.TdsEgressAction Action { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.TdsEgressMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>
    {
        public TdsEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TdsCredential> credentials, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TdsEgressRule> rules) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.TdsCredential> Credentials { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.TdsEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TdsEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TdsEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryApplicationInsightsAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>
    {
        public TelemetryApplicationInsightsAuth(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryAppSecretRef : Azure.Containers.Apps.Sandbox.TelemetrySecretReference, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>
    {
        public TelemetryAppSecretRef(string secretRef) { }
        public string SecretRef { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAppSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>
    {
        internal TelemetryAuth() { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TelemetryEndpoint> endpoints) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.TelemetryEndpoint> Endpoints { get { throw null; } }
        public int? MetricsIntervalSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryData : System.IEquatable<Azure.Containers.Apps.Sandbox.TelemetryData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryData(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryData ContainerOtel { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TelemetryData ContainerStdoutStderr { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TelemetryData Metrics { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TelemetryData NetworkEgressDecisions { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.TelemetryData other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.TelemetryData left, Azure.Containers.Apps.Sandbox.TelemetryData right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TelemetryData (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TelemetryData? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.TelemetryData left, Azure.Containers.Apps.Sandbox.TelemetryData right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>
    {
        internal TelemetryEndpoint() { }
        public System.Collections.Generic.IDictionary<string, Azure.Containers.Apps.Sandbox.LogColumnDef> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryHeaderAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>
    {
        public TelemetryHeaderAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryHeaderAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryManagedIdentityAuth : Azure.Containers.Apps.Sandbox.TelemetryAuth, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>
    {
        public TelemetryManagedIdentityAuth(string identity) { }
        public string Identity { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetryAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.TelemetryProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TelemetryProtocol Grpc { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TelemetryProtocol Http { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.TelemetryProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.TelemetryProtocol left, Azure.Containers.Apps.Sandbox.TelemetryProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TelemetryProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TelemetryProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.TelemetryProtocol left, Azure.Containers.Apps.Sandbox.TelemetryProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySandboxGroupSecretRef : Azure.Containers.Apps.Sandbox.TelemetrySecretReference, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>
    {
        public TelemetrySandboxGroupSecretRef(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetrySecretReference : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>
    {
        internal TelemetrySecretReference() { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetrySecretReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TelemetrySecretReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetrySecretReference System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetrySecretReference System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetrySystemAssignedManagedIdentityAuth : Azure.Containers.Apps.Sandbox.TelemetryAuth, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>
    {
        public TelemetrySystemAssignedManagedIdentityAuth() { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.TelemetryAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenUsageStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>
    {
        internal TokenUsageStats() { }
        public int? RequestCount { get { throw null; } }
        public long? TotalInputTokens { get { throw null; } }
        public long? TotalOutputTokens { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.TokenUsageStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TokenUsageStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TokenUsageStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficInspection : System.IEquatable<Azure.Containers.Apps.Sandbox.TrafficInspection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficInspection(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TrafficInspection Full { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TrafficInspection Legacy { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TrafficInspection None { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TrafficInspection Partial { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.TrafficInspection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.TrafficInspection left, Azure.Containers.Apps.Sandbox.TrafficInspection right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TrafficInspection (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TrafficInspection? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.TrafficInspection left, Azure.Containers.Apps.Sandbox.TrafficInspection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransportEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>
    {
        public TransportEgressRule(Azure.Containers.Apps.Sandbox.EgressPolicyActionType action, Azure.Containers.Apps.Sandbox.TransportProtocol protocol, string destination, int port) { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyActionType Action { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.Containers.Apps.Sandbox.TransportProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.TransportEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TransportEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>
    {
        public TransportEgressSection(Azure.Containers.Apps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.TransportEgressRule> rules) { }
        public Azure.Containers.Apps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.TransportEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.TransportEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.TransportEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.TransportEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.Containers.Apps.Sandbox.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.TransportProtocol Tcp { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.TransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.TransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.TransportProtocol left, Azure.Containers.Apps.Sandbox.TransportProtocol right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TransportProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.TransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.TransportProtocol left, Azure.Containers.Apps.Sandbox.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatePolicyRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>
    {
        public UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.McpPolicyRule> policyRules) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent updatePolicyRulesContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePolicyRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePortsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>
    {
        public UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.Apps.Sandbox.SandboxPortUpdate> ports) { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.SandboxPortUpdate> Ports { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.UpdatePortsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.Apps.Sandbox.UpdatePortsContent updatePortsContent) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.UpdatePortsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UpdatePortsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProvidedBlobPodVolume : Azure.Containers.Apps.Sandbox.PodVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>
    {
        public UserProvidedBlobPodVolume(string name, string fileCacheSizeLimit) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.PodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.PodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProvidedBlobVolume : Azure.Containers.Apps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>
    {
        public UserProvidedBlobVolume(string storageContainerResourceId, Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication auth) { }
        public Azure.Containers.Apps.Sandbox.BlobVolumeAuthentication Auth { get { throw null; } set { } }
        public string StorageContainerResourceId { get { throw null; } set { } }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.UserProvidedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationWarning : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValidationWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValidationWarning>
    {
        public ValidationWarning(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.Containers.Apps.Sandbox.ValidationWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.ValidationWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ValidationWarning System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValidationWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValidationWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ValidationWarning System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValidationWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValidationWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValidationWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValueLogColumnDef : Azure.Containers.Apps.Sandbox.LogColumnDef, System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>
    {
        public ValueLogColumnDef(string value) { }
        public string Value { get { throw null; } }
        protected override Azure.Containers.Apps.Sandbox.LogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.Apps.Sandbox.LogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.ValueLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>
    {
        internal VolumeCountResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.VolumeTypeCount> Counts { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.VolumeCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeListDirectoryResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>
    {
        internal VolumeListDirectoryResult() { }
        public System.Collections.Generic.IList<Azure.Containers.Apps.Sandbox.VolumePathItem> Items { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeListDirectoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumePathItem : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumePathItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumePathItem>
    {
        internal VolumePathItem() { }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string ItemName { get { throw null; } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Path { get { throw null; } }
        public long? SizeBytes { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.VolumePathItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.VolumePathItem (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.VolumePathItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.VolumePathItem System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumePathItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumePathItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.VolumePathItem System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumePathItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumePathItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumePathItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeProvisioningState : System.IEquatable<Azure.Containers.Apps.Sandbox.VolumeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeProvisioningState(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumeProvisioningState Provisioning { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.VolumeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.VolumeProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.VolumeProvisioningState left, Azure.Containers.Apps.Sandbox.VolumeProvisioningState right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.VolumeProvisioningState (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.VolumeProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.VolumeProvisioningState left, Azure.Containers.Apps.Sandbox.VolumeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeType : System.IEquatable<Azure.Containers.Apps.Sandbox.VolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeType(string value) { throw null; }
        public static Azure.Containers.Apps.Sandbox.VolumeType AzureBlob { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.VolumeType AzureBlobByo { get { throw null; } }
        public static Azure.Containers.Apps.Sandbox.VolumeType DataDisk { get { throw null; } }
        public bool Equals(Azure.Containers.Apps.Sandbox.VolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.Apps.Sandbox.VolumeType left, Azure.Containers.Apps.Sandbox.VolumeType right) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.VolumeType (string value) { throw null; }
        public static implicit operator Azure.Containers.Apps.Sandbox.VolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.Apps.Sandbox.VolumeType left, Azure.Containers.Apps.Sandbox.VolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeTypeCount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>
    {
        internal VolumeTypeCount() { }
        public int Count { get { throw null; } }
        public Azure.Containers.Apps.Sandbox.VolumeType Type { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeTypeCount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.Apps.Sandbox.VolumeTypeCount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.VolumeTypeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WriteFileResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.WriteFileResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.WriteFileResult>
    {
        internal WriteFileResult() { }
        public long? BytesWritten { get { throw null; } }
        public string Error { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.Apps.Sandbox.WriteFileResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.Apps.Sandbox.WriteFileResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.Apps.Sandbox.WriteFileResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.Apps.Sandbox.WriteFileResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.WriteFileResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.Apps.Sandbox.WriteFileResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.Apps.Sandbox.WriteFileResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.WriteFileResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.WriteFileResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.Apps.Sandbox.WriteFileResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
