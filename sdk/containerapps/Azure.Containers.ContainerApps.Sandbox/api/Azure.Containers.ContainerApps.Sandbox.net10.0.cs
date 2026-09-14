namespace Azure.Containers.ContainerApps.Sandbox
{
    public partial class AddConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>
    {
        public AddConnectionContent(string connectionId) { }
        public string ConnectionId { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.AddConnectionContent addConnectionContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddPodVolumeMountsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>
    {
        public AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<System.BinaryData> volumes, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts> containerMounts) { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts> ContainerMounts { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Volumes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent addPodVolumeMountsContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddVolumeMountContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>
    {
        public AddVolumeMountContent(Azure.Containers.ContainerApps.Sandbox.SandboxVolume volumeMount) { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxVolume VolumeMount { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent addVolumeMountContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>
    {
        public ApplicationInsightsTelemetryEndpoint(Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth auth, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data) { }
        public Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? Kind { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsTelemetryEndpointKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsTelemetryEndpointKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind ApplicationInsights { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AuthorizeConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>
    {
        public AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues) { }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent authorizeConnectionContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoDeleteTrigger : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoDeleteTrigger(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger AfterCreation { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger AfterSuspend { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger left, Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger left, Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureContainersContainerAppsSandboxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureContainersContainerAppsSandboxContext() { }
        public static Azure.Containers.ContainerApps.Sandbox.AzureContainersContainerAppsSandboxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureFileCifsVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>
    {
        public AzureFileCifsVolume() { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFileNfsVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>
    {
        public AzureFileNfsVolume() { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BlobVolumeAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>
    {
        internal BlobVolumeAuthentication() { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeManagedIdentityAuthentication : Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>
    {
        public BlobVolumeManagedIdentityAuthentication(Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector identity) { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector Identity { get { throw null; } set { } }
        protected override Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>
    {
        internal BlobVolumeUsage() { }
        public System.DateTimeOffset CalculatedAtUtc { get { throw null; } }
        public long ItemCount { get { throw null; } }
        public System.BinaryData UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>
    {
        public CommitSandboxContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent commitSandboxContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>
    {
        internal CommitSandboxResult() { }
        public Azure.Containers.ContainerApps.Sandbox.DiskImage DiskImage { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>
    {
        internal ConnectionsListResult() { }
        public System.Collections.Generic.IList<string> ConnectionIds { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionState : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionState(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ConnectionState Creating { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ConnectionState Error { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ConnectionState Ready { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ConnectionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ConnectionState left, Azure.Containers.ContainerApps.Sandbox.ConnectionState right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ConnectionState (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ConnectionState left, Azure.Containers.ContainerApps.Sandbox.ConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerAppsSandbox : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>
    {
        internal ContainerAppsSandbox() { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } }
        public string AppUri { get { throw null; } }
        public string ColdStorageSizeInMb { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContainerStatus> ContainerStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.GatewayConnection> GatewayConnections { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } }
        public string ManagementUri { get { throw null; } }
        public System.Collections.Generic.IList<string> OutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxPort> Ports { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxResources Resources { get { throw null; } }
        public string SandboxGroupId { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSource SourcesRef { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxState? State { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails StateDetails { get { throw null; } }
        public string VnetConnectionName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerAppsSandboxClient
    {
        protected ContainerAppsSandboxClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ContainerAppsSandboxClient(Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings settings) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroup GetSandboxGroupClient(string subscriptionId, string resourceGroupName, string sandboxGroupName) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ContainerAppsSandboxClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
    }
    public partial class ContainerAppsSandboxClientOptions : Azure.Core.ClientOptions
    {
        public ContainerAppsSandboxClientOptions(Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion version = Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion.V2026_09_01_Preview) { }
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
        public Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class ContainerAppsSandboxModelFactory
    {
        public static Azure.Containers.ContainerApps.Sandbox.AddConnectionContent AddConnectionContent(string connectionId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<System.BinaryData> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts> containerMounts = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent AddVolumeMountContent(Azure.Containers.ContainerApps.Sandbox.SandboxVolume volumeMount = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint ApplicationInsightsTelemetryEndpoint(Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? kind = default(Azure.Containers.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind?), Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth auth = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AzureFileCifsVolume AzureFileCifsVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.AzureFileNfsVolume AzureFileNfsVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication BlobVolumeAuthentication(string kind = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.BlobVolumeManagedIdentityAuthentication BlobVolumeManagedIdentityAuthentication(Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector identity = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage BlobVolumeUsage(System.BinaryData usedBytes = null, long itemCount = (long)0, System.DateTimeOffset calculatedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent CommitSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult CommitSandboxResult(Azure.Containers.ContainerApps.Sandbox.DiskImage diskImage = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult ConnectionsListResult(System.Collections.Generic.IEnumerable<string> connectionIds = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox ContainerAppsSandbox(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, Azure.Containers.ContainerApps.Sandbox.SandboxSource sourcesRef = null, Azure.Containers.ContainerApps.Sandbox.SandboxResources resources = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Containers.ContainerApps.Sandbox.SandboxState? state = default(Azure.Containers.ContainerApps.Sandbox.SandboxState?), Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails stateDetails = null, string snapshotId = null, string coldStorageSizeInMb = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxPort> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.GatewayConnection> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy egressPolicy = null, string sandboxGroupId = null, string region = null, Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy lifecycle = null, string appUri = null, string managementUri = null, Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.IdentitySetting> identitySettings = null, System.Collections.Generic.IEnumerable<string> outboundIPAddresses = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerStatus> containerStatuses = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerProbe ContainerProbe(Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction httpGet = null, Azure.Containers.ContainerApps.Sandbox.ProbeExecAction exec = null, Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction tcpSocket = null, int? initialDelaySeconds = default(int?), int? periodSeconds = default(int?), int? timeoutSeconds = default(int?), int? failureThreshold = default(int?), int? successThreshold = default(int?), int? terminationGracePeriodSeconds = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus ContainerProbeStatus(Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult? lastResult = default(Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult?), int? consecutiveFailures = default(int?), int? consecutiveSuccesses = default(int?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerResources ContainerResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext ContainerSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), bool? privileged = default(bool?), Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities capabilities = null, bool? allowPrivilegeEscalation = default(bool?), bool? readOnlyRootFilesystem = default(bool?), Azure.Containers.ContainerApps.Sandbox.SeccompProfile seccompProfile = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerSpec ContainerSpec(string name = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.ContainerApps.Sandbox.ContainerResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext securityContext = null, Azure.Containers.ContainerApps.Sandbox.ContainerProbe startupProbe = null, Azure.Containers.ContainerApps.Sandbox.ContainerProbe livenessProbe = null, Azure.Containers.ContainerApps.Sandbox.ContainerProbe readinessProbe = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatus ContainerStatus(string name = null, Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState state = default(Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState), bool ready = false, bool started = false, int restartCount = 0, Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason? reason = default(Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason?), string message = null, int? lastExitCode = default(int?), System.DateTimeOffset? lastStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastFinishedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus> probes = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount ContainerVolumeMount(string name = null, string mountPath = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts ContainerVolumeMounts(string containerName = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContentPackage ContentPackage(string id = null, System.BinaryData size = null, System.Collections.Generic.IDictionary<string, string> labels = null, string contentType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult ContentPackageListResult(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContentPackage> value = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CpuStats CpuStats(int? user = default(int?), int? nice = default(int?), int? system = default(int?), int? idle = default(int?), int? iowait = default(int?), int? irq = default(int?), int? softirq = default(int?), int? steal = default(int?), double? loadAvg1 = default(double?), double? loadAvg5 = default(double?), double? loadAvg15 = default(double?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent CreateConnectionContent(string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> labels = null, string parameterValueSetName = null, System.Collections.Generic.IDictionary<string, string> parameterValueSetValues = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent CreateDiskImageContent(Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource source = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, string vnetConnectionName = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource CreateDiskImageSource(string kind = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource CreateDiskImageSourceBlobSource(string blobSourceUri = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource CreateDiskImageSourceRegistrySource(string imageReference = null, Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication authentication = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent CreateSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.Containers.ContainerApps.Sandbox.SandboxSource sourcesRef = null, Azure.Containers.ContainerApps.Sandbox.SandboxResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy egressPolicy = null, string egressPolicyId = null, string sandboxGroupId = null, Azure.Containers.ContainerApps.Sandbox.PresetSandboxType? presetSandboxType = default(Azure.Containers.ContainerApps.Sandbox.PresetSandboxType?), string anthropicApiKey = null, Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties presetProperties = null, Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy lifecycle = null, Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.IdentitySetting> identitySettings = null, Azure.Containers.ContainerApps.Sandbox.TelemetryConfig telemetryConfig = null, string projectId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent CreateSandboxGatewayConnectionContent(string resourceId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent CreateSandboxGroupCredentialContent(string displayName = null, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider), Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource source = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent CreateSandboxPortContent(string name = null, int port = 0, Azure.Containers.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.Containers.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.ContainerApps.Sandbox.PortActivationMode?), Azure.Containers.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.Containers.ContainerApps.Sandbox.PortProtocol?), Azure.Containers.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSecretContent CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent CreateSnapshotContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume DataDiskPodVolume(Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind? kind = default(Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind?), string name = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DataDiskVolume DataDiskVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState), string size = null, bool isAttached = false, string clusterId = null, string attachedSandboxId = null, Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage DataDiskVolumeUsage(System.BinaryData compressedBlobSizeBytes = null, System.BinaryData usedSizeBytes = null, System.DateTimeOffset lastUploadedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DirListingResult DirListingResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.FileInfo> entries = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DiskImage DiskImage(string id = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.DiskImageImage image = null, Azure.Containers.ContainerApps.Sandbox.DiskImageStatus status = null, string sizeInMb = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DiskImageImage DiskImageImage(string base = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DiskImageStatus DiskImageStatus(string state = null, string errorMessage = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry DiskStatsEntry(string mountPoint = null, string filesystem = null, int? totalBytes = default(int?), int? usedBytes = default(int?), int? availableBytes = default(int?), string label = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent DownloadContentPackageToSandboxContent(string contentPackageId = null, string targetPath = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry EgressDecisionEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string host = null, string method = null, string path = null, string scheme = null, string connectionId = null, string connectionName = null, string matchedRule = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult EgressDecisionsResult(Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions http = null, Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress statefulTcp = null, System.DateTimeOffset lastUpdated = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy EgressForwardProxy(string url = null, string certificateAuthority = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressHostRule EgressHostRule(string pattern = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction? action = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform EgressPolicyHeaderTransform(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation operation = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation), string name = null, string value = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef valueRef = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef EgressPolicyHookRef(string endpoint = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? failBehavior = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior?), System.Collections.Generic.IEnumerable<string> requestHeaders = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform> authHeaders = null, int? timeoutMs = default(int?), Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef EgressPolicyManagedIdentityRef(string resource = null, string format = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? type = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType?), string identityResourceId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule EgressPolicyRule(string name = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch match = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction action = null, System.Collections.Generic.IEnumerable<string> proxyActions = null, string source = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction EgressPolicyRuleAction(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType type = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform> headers = null, string scheme = null, string host = null, string path = null, Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode?), Azure.Containers.ContainerApps.Sandbox.EgressForwardMode? forward = default(Azure.Containers.ContainerApps.Sandbox.EgressForwardMode?), Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy forwardProxy = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch EgressPolicyRuleMatch(string host = null, string path = null, System.Collections.Generic.IEnumerable<string> methods = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme? scheme = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme?), bool? normalizePath = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef EgressPolicySecretRef(string secretId = null, string secretKey = null, string format = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef EgressPolicyValueRef(Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef secretRef = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef managedIdentityRef = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue EntityTagHeaderValue(Azure.Containers.ContainerApps.Sandbox.StringSegment tag = null, bool? isWeak = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EsanVolume EsanVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState), string size = null, Azure.Containers.ContainerApps.Sandbox.EsanSku sku = default(Azure.Containers.ContainerApps.Sandbox.EsanSku)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent ExecuteSandboxCommandContent(string command = null, System.Collections.Generic.IEnumerable<string> arguments = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.ContainerApps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent ExecuteSandboxShellCommandContent(string command = null, string shell = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.Containers.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.ContainerApps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.FileInfo FileInfo(string name = null, string path = null, long size = (long)0, int mode = 0, bool isDir = false, bool isSymlink = false, string symlinkTarget = null, long modifiedTime = (long)0) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult FileOpStatusResult(bool success = false, string error = null, string message = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.FileStreamResult FileStreamResult(System.BinaryData fileStream = null, string contentType = null, string fileDownloadName = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue entityTag = null, bool? enableRangeProcessing = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent ForkDataDiskVolumeContent(string destinationVolumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication GatewayAuthentication(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GatewayConnection GatewayConnection(string resourceId = null, string name = null, string mcpRuntimeUri = null, string connectionRuntimeUri = null, Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication authentication = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord GatewayConnectionAuthRecord(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType type = default(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent GenerateConsentLinkContent(string redirectUri = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult GenerateConsentLinkResult(string consentLink = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.HttpEgressSection HttpEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction defaultAction = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> rules = null, Azure.Containers.ContainerApps.Sandbox.TrafficInspection? trafficInspection = default(Azure.Containers.ContainerApps.Sandbox.TrafficInspection?), Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy defaultForward = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.IdentitySetting IdentitySetting(string identity = null, Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle? lifecycle = default(Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.IPAccessControl IPAccessControl(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction defaultAction = default(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule> rules = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule IPAccessControlRule(string name = null, Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction action = default(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction), int priority = 0, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities LinuxCapabilities(System.Collections.Generic.IEnumerable<string> add = null, System.Collections.Generic.IEnumerable<string> drop = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LocalPodVolume LocalPodVolume(Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind? kind = default(Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind?), string size = null, string name = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint LogAnalyticsLegacyTelemetryEndpoint(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? kind = default(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind?), string workspaceId = null, string tableName = null, System.BinaryData auth = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint LogAnalyticsTelemetryEndpoint(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? kind = default(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind?), System.Uri dceEndpoint = null, string dcrImmutableId = null, string tableName = null, System.BinaryData auth = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication ManagedIdentityAuthentication(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType type = default(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType), string identityResourceId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.McpPolicyRule McpPolicyRule(string hookId = null, System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.MemoryStats MemoryStats(int? totalBytes = default(int?), int? availableBytes = default(int?), int? usedBytes = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.MkDirContent MkDirContent(string path = null, bool? createParents = default(bool?), int? mode = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy NamedEgressPolicy(string id = null, string name = null, string description = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction defaultAction = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction), Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> rules = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult NamedEgressPolicyListResult(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy> egressPolicies = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions NetworkEgressDecisions(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry> allowed = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry> denied = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.NetworkStats NetworkStats(int? rxBytes = default(int?), int? txBytes = default(int?), int? rxPackets = default(int?), int? txPackets = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? kind = default(Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind?), System.Uri endpoint = null, Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol protocol = default(Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol), Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth auth = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PodContentPackage PodContentPackage(string contentPackageId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PodSecurityContext PodSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), System.Collections.Generic.IEnumerable<int> supplementalGroups = null, int? fsGroup = default(int?), Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy? fsGroupChangePolicy = default(Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortAuthConfig PortAuthConfig(bool? anonymous = default(bool?), Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub github = null, Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId entraId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId PortAuthConfigEntraId(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> objectIds = null, System.Collections.Generic.IEnumerable<string> tenantIds = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub PortAuthConfigGithub(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> usernames = null, System.Collections.Generic.IEnumerable<string> usernameSuffixes = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortCorsConfig PortCorsConfig(System.Collections.Generic.IEnumerable<string> allowOrigins = null, System.Collections.Generic.IEnumerable<string> allowMethods = null, System.Collections.Generic.IEnumerable<string> allowHeaders = null, bool? allowCredentials = default(bool?), int? maxAge = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortsListResult PortsListResult(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxPort> ports = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ProbeExecAction ProbeExecAction(System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction ProbeHttpGetAction(int port = 0, string path = null, string host = null, string scheme = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader> httpHeaders = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader ProbeHttpHeader(string name = null, string value = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction ProbeTcpSocketAction(int port = 0, string host = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PublicDiskImage PublicDiskImage(string name = null, Azure.Containers.ContainerApps.Sandbox.DiskImageStatus status = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef RefLogColumnDef(Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind? kind = default(Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind?), Azure.Containers.ContainerApps.Sandbox.LogColumnRef refName = default(Azure.Containers.ContainerApps.Sandbox.LogColumnRef)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication RegistryAuthentication(Azure.Containers.ContainerApps.Sandbox.RegistryCredentials registryCredentials = null, Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.RegistryCredentials RegistryCredentials(string username = null, string token = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.RemovePortContent RemovePortContent(string name = null, int? port = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef SandboxAgentIdentityRef(string tenantId = null, string agentId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy SandboxAutoDeletePolicy(bool enabled = false, int? deleteIntervalInDays = default(int?), long? deleteIntervalInSeconds = default(long?), Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger? trigger = default(Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy SandboxAutoSuspendPolicy(bool enabled = false, int? interval = default(int?), Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode? mode = default(Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxConnection SandboxConnection(string id = null, string name = null, string type = null, string state = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? deletable = default(bool?), System.Collections.Generic.IEnumerable<string> usedBySandboxIds = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload SandboxContentPackageDownload(string contentPackageId = null, string targetPath = null, Azure.Containers.ContainerApps.Sandbox.ContentPackageAction? action = default(Azure.Containers.ContainerApps.Sandbox.ContentPackageAction?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy SandboxEgressPolicy(Azure.Containers.ContainerApps.Sandbox.HttpEgressSection http = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction? defaultAction = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction?), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> rules = null, Azure.Containers.ContainerApps.Sandbox.TdsEgressSection tds = null, Azure.Containers.ContainerApps.Sandbox.TransportEgressSection transportRules = null, Azure.Containers.ContainerApps.Sandbox.TrafficInspection? trafficInspection = default(Azure.Containers.ContainerApps.Sandbox.TrafficInspection?), Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ValidationWarning> validationWarnings = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult SandboxExecuteCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult SandboxExecuteShellCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential SandboxGroupCredential(string name = null, string displayName = null, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider), Azure.Containers.ContainerApps.Sandbox.ConnectionState state = default(Azure.Containers.ContainerApps.Sandbox.ConnectionState), Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource source = null, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin origin = default(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails SandboxGroupCredentialConnectionRefDetails(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord authentication = null, string tokenExchangeEndpoint = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource SandboxGroupCredentialSource(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind kind = default(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind), string connectionResourceId = null, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails connectionRefDetails = null, System.Collections.Generic.IDictionary<string, string> parameterValues = null, string connectionId = null, string connectionType = null, string connectionName = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector SandboxGroupIdentitySelector(string kind = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume SandboxGroupVolume(string type = null, string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy SandboxLifecyclePolicy(Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy = null, Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxPort SandboxPort(string name = null, int port = 0, System.Uri url = null, Azure.Containers.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.Containers.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.ContainerApps.Sandbox.PortActivationMode?), Azure.Containers.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.Containers.ContainerApps.Sandbox.PortProtocol?), Azure.Containers.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate SandboxPortUpdate(string name = null, int port = 0, System.Uri url = null, Azure.Containers.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.Containers.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.Containers.ContainerApps.Sandbox.PortActivationMode?), Azure.Containers.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.Containers.ContainerApps.Sandbox.PortProtocol?), Azure.Containers.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.Containers.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties SandboxPresetProperties(bool? isWorkIqConnectionEnabled = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxResources SandboxResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSecret SandboxSecret(string id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot SandboxSnapshot(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, string sandboxId = null, System.DateTimeOffset createdAtUtc = default(System.DateTimeOffset), Azure.Containers.ContainerApps.Sandbox.SnapshotResources resources = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer> sourcePodContainers = null, string sizeInMb = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSource SandboxSource(Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot snapshot = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod pod = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion SandboxSourceArtifactVersion(string id = null, Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth auth = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth SandboxSourceAuth(string identity = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage SandboxSourceDiskImage(string id = null, string name = null, bool? isPublic = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerSpec> containers = null, System.Collections.Generic.IEnumerable<System.BinaryData> volumes = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.PodContentPackage> contentPackages = null, Azure.Containers.ContainerApps.Sandbox.PodSecurityContext securityContext = null, Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy? restartPolicy = default(Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot SandboxSourceSnapshot(string id = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails SandboxStateDetails(Azure.Containers.ContainerApps.Sandbox.StoppedReason stoppedReason = default(Azure.Containers.ContainerApps.Sandbox.StoppedReason), System.DateTimeOffset stoppedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult SandboxStatsResult(Azure.Containers.ContainerApps.Sandbox.TokenUsageStats tokenUsage = null, Azure.Containers.ContainerApps.Sandbox.CpuStats cpu = null, Azure.Containers.ContainerApps.Sandbox.MemoryStats memory = null, Azure.Containers.ContainerApps.Sandbox.NetworkStats network = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry> disk = null, double? uptimeSecs = default(double?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxVolume SandboxVolume(string volumeName = null, string mountpoint = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SeccompProfile SeccompProfile(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType type = default(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SecretKeysResult SecretKeysResult(System.Collections.Generic.IEnumerable<string> keys = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SecretListResult SecretListResult(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxSecret> secrets = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SecretPeekResult SecretPeekResult(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume ServiceManagedBlobPodVolume(Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind? kind = default(Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind?), string fileCacheSizeLimit = null, bool? readOnly = default(bool?), string name = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume ServiceManagedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState), Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage usage = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer SnapshotPodContainer(string name = null, string diskImageId = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SnapshotResources SnapshotResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress StatefulTcpEgress(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry> connections = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry StatefulTcpEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string phase = null, string outcome = null, string connectorType = null, string server = null, int? port = default(int?), string database = null, string proxyLoginName = null, string sourceIP = null, string correlationId = null, long? bytesIn = default(long?), long? bytesOut = default(long?), long? durationMs = default(long?), string failureReason = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.StringSegment StringSegment(string buffer = null, int? offset = default(int?), int? length = default(int?), string value = null, bool? hasValue = default(bool?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsCredential TdsCredential(string name = null, Azure.Containers.ContainerApps.Sandbox.TdsAuthKind kind = default(Azure.Containers.ContainerApps.Sandbox.TdsAuthKind), string username = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef secretRef = null, string secret = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsEgressAction TdsEgressAction(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType type = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType), string credential = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch TdsEgressMatch(string host = null, System.Collections.Generic.IEnumerable<string> databases = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsEgressRule TdsEgressRule(string name = null, Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch match = null, Azure.Containers.ContainerApps.Sandbox.TdsEgressAction action = null, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsEgressSection TdsEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TdsCredential> credentials = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule> rules = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth TelemetryApplicationInsightsAuth(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef TelemetryAppSecretRef(string secretRef = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<System.BinaryData> endpoints = null, int? metricsIntervalSeconds = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth TelemetryHeaderAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth TelemetryManagedIdentityAuth(Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? kind = default(Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind?), string identity = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef TelemetrySandboxGroupSecretRef(Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? kind = default(Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind?), string secretId = null, string secretKey = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth TelemetrySystemAssignedManagedIdentityAuth(Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? kind = default(Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TokenUsageStats TokenUsageStats(long? totalInputTokens = default(long?), long? totalOutputTokens = default(long?), int? requestCount = default(int?)) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TransportEgressRule TransportEgressRule(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType action = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType), Azure.Containers.ContainerApps.Sandbox.TransportProtocol protocol = default(Azure.Containers.ContainerApps.Sandbox.TransportProtocol), string destination = null, int port = 0) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TransportEgressSection TransportEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule> rules = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate> ports = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume UserProvidedBlobPodVolume(Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind? kind = default(Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind?), string fileCacheSizeLimit = null, bool? readOnly = default(bool?), string name = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume UserProvidedBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState), string storageContainerResourceId = null, Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication auth = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ValidationWarning ValidationWarning(string code = null, string message = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef ValueLogColumnDef(Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind? kind = default(Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind?), string value = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeCountResult VolumeCountResult(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount> counts = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult VolumeListDirectoryResult(string path = null, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.VolumePathItem> items = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumePathItem VolumePathItem(string itemName = null, string path = null, bool isDirectory = false, System.BinaryData sizeBytes = null, System.DateTimeOffset? lastModifiedUtc = default(System.DateTimeOffset?), string contentType = null, string eTag = null) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount VolumeTypeCount(Azure.Containers.ContainerApps.Sandbox.VolumeType type = default(Azure.Containers.ContainerApps.Sandbox.VolumeType), int count = 0) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.WriteFileResult WriteFileResult(bool success = false, string error = null, long? bytesWritten = default(long?)) { throw null; }
    }
    public partial class ContainerProbe : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>
    {
        public ContainerProbe() { }
        public Azure.Containers.ContainerApps.Sandbox.ProbeExecAction Exec { get { throw null; } set { } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction HttpGet { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction TcpSocket { get { throw null; } set { } }
        public int? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerProbe JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerProbe PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerProbe System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerProbe System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerProbeResult : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerProbeResult(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult Failure { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult Success { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult Unknown { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult left, Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult left, Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerProbeStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>
    {
        internal ContainerProbeStatus() { }
        public int? ConsecutiveFailures { get { throw null; } }
        public int? ConsecutiveSuccesses { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerProbeResult? LastResult { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>
    {
        public ContainerResources() { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRestartPolicy : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRestartPolicy(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy Always { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy Never { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy left, Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy left, Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRuntimeState : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRuntimeState(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState Running { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState Terminated { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState Unknown { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState Waiting { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState left, Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState left, Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>
    {
        public ContainerSecurityContext() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities Capabilities { get { throw null; } set { } }
        public bool? Privileged { get { throw null; } set { } }
        public bool? ReadOnlyRootFilesystem { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SeccompProfile SeccompProfile { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSpec : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>
    {
        public ContainerSpec(string name) { }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerResources Resources { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerSecurityContext SecurityContext { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerProbe StartupProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerSpec System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerSpec System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>
    {
        internal ContainerStatus() { }
        public int? LastExitCode { get { throw null; } }
        public System.DateTimeOffset? LastFinishedOn { get { throw null; } }
        public System.DateTimeOffset? LastStartedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.Containers.ContainerApps.Sandbox.ContainerProbeStatus> Probes { get { throw null; } }
        public bool Ready { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason? Reason { get { throw null; } }
        public int RestartCount { get { throw null; } }
        public bool Started { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerRuntimeState State { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerStatusReason : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerStatusReason(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason Completed { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason CrashLoopBackOff { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason Error { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason RootfsResetFailed { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason RootfsResetPending { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason left, Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason left, Azure.Containers.ContainerApps.Sandbox.ContainerStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerVolumeMount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolumeMounts : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>
    {
        public ContainerVolumeMounts(string containerName, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts) { }
        public string ContainerName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContainerVolumeMounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>
    {
        internal ContentPackage() { }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public System.BinaryData Size { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.ContentPackage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentPackageAction : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ContentPackageAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentPackageAction(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ContentPackageAction Download { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ContentPackageAction Mount { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ContentPackageAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ContentPackageAction left, Azure.Containers.ContainerApps.Sandbox.ContentPackageAction right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContentPackageAction (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ContentPackageAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ContentPackageAction left, Azure.Containers.ContainerApps.Sandbox.ContentPackageAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentPackageListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>
    {
        internal ContentPackageListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContentPackage> Value { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CpuStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>
    {
        internal CpuStats() { }
        public int? Idle { get { throw null; } }
        public int? Iowait { get { throw null; } }
        public int? Irq { get { throw null; } }
        public double? LoadAvg1 { get { throw null; } }
        public double? LoadAvg15 { get { throw null; } }
        public double? LoadAvg5 { get { throw null; } }
        public int? Nice { get { throw null; } }
        public int? Softirq { get { throw null; } }
        public int? Steal { get { throw null; } }
        public int? System { get { throw null; } }
        public int? User { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CpuStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CpuStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CpuStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CpuStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CpuStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>
    {
        public CreateConnectionContent(string name, string type) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string ParameterValueSetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValueSetValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent createConnectionContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>
    {
        public CreateDiskImageContent(Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource source) { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource Source { get { throw null; } }
        public string VnetConnectionName { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent createDiskImageContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CreateDiskImageSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>
    {
        internal CreateDiskImageSource() { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceBlobSource : Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>
    {
        public CreateDiskImageSourceBlobSource(string blobSourceUri) { }
        public string BlobSourceUri { get { throw null; } }
        protected override Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceRegistrySource : Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>
    {
        public CreateDiskImageSourceRegistrySource(string imageReference) { }
        public Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication Authentication { get { throw null; } set { } }
        public string ImageReference { get { throw null; } }
        protected override Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>
    {
        public CreateSandboxContent() { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } set { } }
        public string AnthropicApiKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } set { } }
        public string EgressPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent> GatewayConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent> Ports { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties PresetProperties { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PresetSandboxType? PresetSandboxType { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxResources Resources { get { throw null; } set { } }
        public string SandboxGroupId { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSource SourcesRef { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public string VnetConnectionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent createSandboxContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGatewayConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>
    {
        public CreateSandboxGatewayConnectionContent(string resourceId) { }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGroupCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>
    {
        public CreateSandboxGroupCredentialContent(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource source) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent createSandboxGroupCredentialContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxPortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>
    {
        public CreateSandboxPortContent(int port) { }
        public Azure.Containers.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent createSandboxPortContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSecretContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>
    {
        public CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values) { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSecretContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateSecretContent createSecretContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSecretContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSecretContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSnapshotContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>
    {
        public CreateSnapshotContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent createSnapshotContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>
    {
        public DataDiskPodVolume(string name) { }
        public Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataDiskPodVolumeKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataDiskPodVolumeKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind DataDisk { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.DataDiskPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDiskVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>
    {
        public DataDiskVolume(string size) { }
        public string AttachedSandboxId { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public bool IsAttached { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>
    {
        internal DataDiskVolumeUsage() { }
        public System.BinaryData CompressedBlobSizeBytes { get { throw null; } }
        public System.DateTimeOffset LastUploadedAtUtc { get { throw null; } }
        public System.BinaryData UsedSizeBytes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DataDiskVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirListingResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>
    {
        internal DirListingResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.FileInfo> Entries { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DirListingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.DirListingResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DirListingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DirListingResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DirListingResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DirListingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>
    {
        internal DiskImage() { }
        public string Id { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.DiskImageImage Image { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string SizeInMb { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.DiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>
    {
        internal DiskImageImage() { }
        public string Base { get { throw null; } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImageImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImageImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DiskImageImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DiskImageImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>
    {
        internal DiskImageStatus() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskStatsEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>
    {
        internal DiskStatsEntry() { }
        public int? AvailableBytes { get { throw null; } }
        public string Filesystem { get { throw null; } }
        public string Label { get { throw null; } }
        public string MountPoint { get { throw null; } }
        public int? TotalBytes { get { throw null; } }
        public int? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadContentPackageToSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>
    {
        public DownloadContentPackageToSandboxContent(string contentPackageId, string targetPath) { }
        public string ContentPackageId { get { throw null; } }
        public string TargetPath { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent downloadContentPackageToSandboxContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>
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
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>
    {
        internal EgressDecisionsResult() { }
        public Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions Http { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress StatefulTcp { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressForwardMode : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressForwardMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressForwardMode(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressForwardMode Default { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressForwardMode Direct { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressForwardMode Proxy { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressForwardMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressForwardMode left, Azure.Containers.ContainerApps.Sandbox.EgressForwardMode right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressForwardMode (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressForwardMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressForwardMode left, Azure.Containers.ContainerApps.Sandbox.EgressForwardMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressForwardProxy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>
    {
        public EgressForwardProxy(string url) { }
        public string CertificateAuthority { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressHostRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>
    {
        public EgressHostRule(string pattern) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction? Action { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressHostRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressHostRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressHostRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressHostRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressHostRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyAction : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyAction(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction Allow { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyActionType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyActionType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Allow { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Deny { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Rewrite { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Transform { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyEnforcementMode : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyEnforcementMode(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode Audit { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode Enforced { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHeaderOperation : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHeaderOperation(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation Insert { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation Remove { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation Set { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHeaderTransform : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>
    {
        public EgressPolicyHeaderTransform(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation operation, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderOperation Operation { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef ValueRef { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHookFailBehavior : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHookFailBehavior(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior Allow { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior Deny { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHookRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>
    {
        public EgressPolicyHookRef(string endpoint) { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform> AuthHeaders { get { throw null; } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? FailBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequestHeaders { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public int? TimeoutMs { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyManagedIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>
    {
        public EgressPolicyManagedIdentityRef(string resource) { }
        public string Format { get { throw null; } set { } }
        public string IdentityResourceId { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyManagedIdentityType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyManagedIdentityType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyMatchScheme : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyMatchScheme(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme Any { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme Http { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme Https { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme left, Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>
    {
        public EgressPolicyRule(string name, Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch match) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction Action { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProxyActions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>
    {
        public EgressPolicyRuleAction(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType type) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressForwardMode? Forward { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy ForwardProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressPolicyHeaderTransform> Headers { get { throw null; } }
        public string Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>
    {
        public EgressPolicyRuleMatch(string host) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public bool? NormalizePath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyMatchScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicySecretRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>
    {
        public EgressPolicySecretRef(string secretId) { }
        public string Format { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyValueRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>
    {
        public EgressPolicyValueRef() { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef ManagedIdentityRef { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EgressPolicyValueRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressRuleRoutingMode : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressRuleRoutingMode(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode Default { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode Platform { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode Vnet { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode left, Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode left, Azure.Containers.ContainerApps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityTagHeaderValue : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>
    {
        internal EntityTagHeaderValue() { }
        public bool? IsWeak { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.StringSegment Tag { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EsanSku : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.EsanSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EsanSku(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.EsanSku PremiumLrs { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.EsanSku PremiumZrs { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.EsanSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.EsanSku left, Azure.Containers.ContainerApps.Sandbox.EsanSku right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EsanSku (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.EsanSku? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.EsanSku left, Azure.Containers.ContainerApps.Sandbox.EsanSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EsanVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>
    {
        public EsanVolume(string size) { }
        public string Size { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EsanSku Sku { get { throw null; } }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.EsanVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.EsanVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.EsanVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>
    {
        public ExecuteSandboxCommandContent(string command) { }
        public Azure.Containers.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Arguments { get { throw null; } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent executeSandboxCommandContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxShellCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>
    {
        public ExecuteSandboxShellCommandContent(string command) { }
        public Azure.Containers.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string Shell { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent executeSandboxShellCommandContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileInfo : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>
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
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.FileInfo (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.FileInfo System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.FileInfo System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileOpStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>
    {
        internal FileOpStatusResult() { }
        public string Error { get { throw null; } }
        public string Message { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileStreamResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>
    {
        internal FileStreamResult() { }
        public string ContentType { get { throw null; } }
        public bool? EnableRangeProcessing { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.EntityTagHeaderValue EntityTag { get { throw null; } }
        public string FileDownloadName { get { throw null; } }
        public System.BinaryData FileStream { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileStreamResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.FileStreamResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.FileStreamResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.FileStreamResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.FileStreamResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForkDataDiskVolumeContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>
    {
        public ForkDataDiskVolumeContent(string destinationVolumeName) { }
        public string DestinationVolumeName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent forkDataDiskVolumeContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FsGroupChangePolicy : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FsGroupChangePolicy(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy Always { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy None { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy OnRootMismatch { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy left, Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy left, Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>
    {
        internal GatewayAuthentication() { }
        public Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>
    {
        internal GatewayConnection() { }
        public Azure.Containers.ContainerApps.Sandbox.GatewayAuthentication Authentication { get { throw null; } }
        public string ConnectionRuntimeUri { get { throw null; } }
        public string McpRuntimeUri { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.GatewayConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.GatewayConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnectionAuthRecord : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>
    {
        public GatewayConnectionAuthRecord(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayConnectionAuthType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayConnectionAuthType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType left, Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType left, Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateConsentLinkContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>
    {
        public GenerateConsentLinkContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent generateConsentLinkContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateConsentLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>
    {
        internal GenerateConsentLinkResult() { }
        public string ConsentLink { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>
    {
        public HttpEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction defaultAction) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressForwardProxy DefaultForward { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.HttpEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.HttpEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.HttpEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentitySetting : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>
    {
        public IdentitySetting(string identity) { }
        public string Identity { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle? Lifecycle { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IdentitySetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IdentitySetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.IdentitySetting System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.IdentitySetting System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IdentitySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentitySettingLifecycle : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentitySettingLifecycle(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle All { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle Main { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle None { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle left, Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle left, Azure.Containers.ContainerApps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>
    {
        public IPAccessControl(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction defaultAction) { }
        public Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IPAccessControl JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IPAccessControl PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.IPAccessControl System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.IPAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlAction : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlAction(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction Allow { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction Deny { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction left, Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction left, Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControlRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>
    {
        public IPAccessControlRule(string name, Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction action, int priority, System.Collections.Generic.IEnumerable<string> sourceAddressPrefixes) { }
        public Azure.Containers.ContainerApps.Sandbox.IPAccessControlAction Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceAddressPrefixes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.IPAccessControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>
    {
        public LinuxCapabilities() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LinuxCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>
    {
        public LocalPodVolume(string size, string name) { }
        public Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LocalPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LocalPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LocalPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalPodVolumeKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalPodVolumeKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind Local { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.LocalPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsLegacyTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>
    {
        public LogAnalyticsLegacyTelemetryEndpoint(string workspaceId, string tableName, System.BinaryData auth, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data) { }
        public System.BinaryData Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public string TableName { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAnalyticsLegacyTelemetryEndpointKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAnalyticsLegacyTelemetryEndpointKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind LogAnalyticsLegacy { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>
    {
        public LogAnalyticsTelemetryEndpoint(System.Uri dceEndpoint, string dcrImmutableId, string tableName, System.BinaryData auth, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data) { }
        public System.BinaryData Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public System.Uri DceEndpoint { get { throw null; } }
        public string DcrImmutableId { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public string TableName { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAnalyticsTelemetryEndpointKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAnalyticsTelemetryEndpointKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind LogAnalytics { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogColumnRef : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.LogColumnRef>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogColumnRef(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.LogColumnRef ContainerName { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.LogColumnRef LogContent { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.LogColumnRef LogStream { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.LogColumnRef Region { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.LogColumnRef SandboxId { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.LogColumnRef other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.LogColumnRef left, Azure.Containers.ContainerApps.Sandbox.LogColumnRef right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogColumnRef (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.LogColumnRef? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.LogColumnRef left, Azure.Containers.ContainerApps.Sandbox.LogColumnRef right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>
    {
        public ManagedIdentityAuthentication(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityAuthenticationType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityAuthenticationType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType SystemAssigned { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType UserAssigned { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType left, Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType left, Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>
    {
        public McpPolicyRule(string hookId, System.Collections.Generic.IEnumerable<string> patterns) { }
        public string HookId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.McpPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.McpPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>
    {
        internal MemoryStats() { }
        public int? AvailableBytes { get { throw null; } }
        public int? TotalBytes { get { throw null; } }
        public int? UsedBytes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.MemoryStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.MemoryStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.MemoryStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.MemoryStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MemoryStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MkDirContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>
    {
        public MkDirContent(string path) { }
        public bool? CreateParents { get { throw null; } set { } }
        public int? Mode { get { throw null; } set { } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.MkDirContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.MkDirContent mkDirContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.MkDirContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.MkDirContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.MkDirContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.MkDirContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>
    {
        public NamedEgressPolicy(string name, Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction defaultAction) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy namedEgressPolicy) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicyListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>
    {
        internal NamedEgressPolicyListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy> EgressPolicies { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkEgressDecisions : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>
    {
        internal NetworkEgressDecisions() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry> Allowed { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressDecisionEntry> Denied { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkEgressDecisions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>
    {
        internal NetworkStats() { }
        public int? RxBytes { get { throw null; } }
        public int? RxPackets { get { throw null; } }
        public int? TxBytes { get { throw null; } }
        public int? TxPackets { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NetworkStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.NetworkStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.NetworkStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.NetworkStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.NetworkStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Uri endpoint, Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol protocol, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TelemetryData> data) { }
        public Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth Auth { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol Protocol { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OtlpTelemetryEndpointKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OtlpTelemetryEndpointKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind OTLP { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind left, Azure.Containers.ContainerApps.Sandbox.OtlpTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PodContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>
    {
        public PodContentPackage(string contentPackageId) { }
        public string ContentPackageId { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PodContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PodContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PodContentPackage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PodContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>
    {
        public PodSecurityContext() { }
        public int? FsGroup { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.FsGroupChangePolicy? FsGroupChangePolicy { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SupplementalGroups { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PodSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PodSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PodSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortActivationMode : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.PortActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortActivationMode(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortActivationMode Manual { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.PortActivationMode OnDemand { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.PortActivationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.PortActivationMode left, Azure.Containers.ContainerApps.Sandbox.PortActivationMode right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PortActivationMode (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PortActivationMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.PortActivationMode left, Azure.Containers.ContainerApps.Sandbox.PortActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>
    {
        public PortAuthConfig() { }
        public bool? Anonymous { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId EntraId { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub Github { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigEntraId : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>
    {
        public PortAuthConfigEntraId() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectIds { get { throw null; } }
        public System.Collections.Generic.IList<string> TenantIds { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigEntraId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigGithub : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>
    {
        public PortAuthConfigGithub() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UsernameSuffixes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortAuthConfigGithub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortCorsConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>
    {
        public PortCorsConfig() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowOrigins { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortCorsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortCorsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortCorsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortProtocol : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.PortProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortProtocol(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PortProtocol Http { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.PortProtocol Http2 { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.PortProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.PortProtocol left, Azure.Containers.ContainerApps.Sandbox.PortProtocol right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PortProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PortProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.PortProtocol left, Azure.Containers.ContainerApps.Sandbox.PortProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortsListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>
    {
        internal PortsListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxPort> Ports { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.PortsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PortsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PortsListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PortsListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PortsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PresetSandboxType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.PresetSandboxType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PresetSandboxType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.PresetSandboxType Claude { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.PresetSandboxType GitHubCopilot { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.PresetSandboxType None { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.PresetSandboxType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.PresetSandboxType left, Azure.Containers.ContainerApps.Sandbox.PresetSandboxType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PresetSandboxType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.PresetSandboxType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.PresetSandboxType left, Azure.Containers.ContainerApps.Sandbox.PresetSandboxType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProbeExecAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>
    {
        public ProbeExecAction(System.Collections.Generic.IEnumerable<string> command) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeExecAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeExecAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpGetAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>
    {
        public ProbeHttpGetAction(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpGetAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>
    {
        public ProbeHttpHeader(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeHttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeTcpSocketAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>
    {
        public ProbeTcpSocketAction(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ProbeTcpSocketAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>
    {
        internal PublicDiskImage() { }
        public string Name { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PublicDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.PublicDiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.PublicDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefLogColumnDef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>
    {
        public RefLogColumnDef(Azure.Containers.ContainerApps.Sandbox.LogColumnRef refName) { }
        public Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind? Kind { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.LogColumnRef RefName { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefLogColumnDefKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefLogColumnDefKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind Ref { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind left, Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind left, Azure.Containers.ContainerApps.Sandbox.RefLogColumnDefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>
    {
        public RegistryAuthentication() { }
        public Azure.Containers.ContainerApps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.RegistryCredentials RegistryCredentials { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>
    {
        public RegistryCredentials(string username, string token) { }
        public string Token { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemovePortContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>
    {
        public RemovePortContent() { }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RemovePortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.RemovePortContent removePortContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.RemovePortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.RemovePortContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.RemovePortContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.RemovePortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAgentIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>
    {
        public SandboxAgentIdentityRef(string tenantId, string agentId) { }
        public string AgentId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoDeletePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>
    {
        public SandboxAutoDeletePolicy(bool enabled) { }
        public int? DeleteIntervalInDays { get { throw null; } set { } }
        public long? DeleteIntervalInSeconds { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.AutoDeleteTrigger? Trigger { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoSuspendPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>
    {
        public SandboxAutoSuspendPolicy(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode? Mode { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxConnection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>
    {
        internal SandboxConnection() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Deletable { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string State { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UsedBySandboxIds { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxConnection (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxConnection System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxConnection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxContentPackageDownload : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>
    {
        public SandboxContentPackageDownload(string contentPackageId, string targetPath) { }
        public Azure.Containers.ContainerApps.Sandbox.ContentPackageAction? Action { get { throw null; } set { } }
        public string ContentPackageId { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxContentPackageDownload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>
    {
        public SandboxEgressPolicy() { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyAction? DefaultAction { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.HttpEgressSection Http { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.TdsEgressSection Tds { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TransportEgressSection TransportRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ValidationWarning> ValidationWarnings { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy sandboxEgressPolicy) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>
    {
        internal SandboxExecuteCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteShellCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>
    {
        internal SandboxExecuteShellCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxFiles
    {
        protected SandboxFiles() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult> CreateSandboxDirectory(Azure.Containers.ContainerApps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandboxDirectory(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>> CreateSandboxDirectoryAsync(Azure.Containers.ContainerApps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxDirectoryAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteSandboxFile(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult> DeleteSandboxFile(string path = null, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSandboxFileAsync(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileOpStatusResult>> DeleteSandboxFileAsync(string path = null, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadSandboxFile(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileStreamResult> DownloadSandboxFile(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadSandboxFileAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>> DownloadSandboxFileAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFileMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileInfo> GetSandboxFileMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileInfo>> GetSandboxFileMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFilesMetadata(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.DirListingResult> GetSandboxFilesMetadata(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFilesMetadataAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.DirListingResult>> GetSandboxFilesMetadataAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadSandboxFile(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.WriteFileResult> UploadSandboxFile(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadSandboxFileAsync(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>> UploadSandboxFileAsync(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroup
    {
        protected SandboxGroup() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> CreateSandbox(Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandbox(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> CreateSandboxAsync(Azure.Containers.ContainerApps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSandboxCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<int> GetSandboxCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<int>> GetSandboxCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxes(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> GetSandboxes(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>>> GetSandboxesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupConnections GetSandboxGroupConnectionsClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupContentPackages GetSandboxGroupContentPackagesClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentials GetSandboxGroupCredentialsClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupDiskImages GetSandboxGroupDiskImagesClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupEgressPolicies GetSandboxGroupEgressPoliciesClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupSandbox GetSandboxGroupSandboxClient(string id) { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupSecrets GetSandboxGroupSecretsClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupSnapshots GetSandboxGroupSnapshotsClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolumes GetSandboxGroupVolumesClient() { throw null; }
    }
    public partial class SandboxGroupConnections
    {
        protected SandboxGroupConnections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection> AuthorizeConnection(string id, Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AuthorizeConnection(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> AuthorizeConnectionAsync(string id, Azure.Containers.ContainerApps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AuthorizeConnectionAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection> CreateConnection(Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> CreateConnectionAsync(Azure.Containers.ContainerApps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult> GenerateConnectionConsentLink(string id, Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GenerateConnectionConsentLink(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkResult>> GenerateConnectionConsentLinkAsync(string id, Azure.Containers.ContainerApps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GenerateConnectionConsentLinkAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection> GetConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> GetConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnections(bool? includeSandboxIds, int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> GetConnections(bool? includeSandboxIds = default(bool?), int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionsAsync(bool? includeSandboxIds, int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>>> GetConnectionsAsync(bool? includeSandboxIds = default(bool?), int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection> RefreshConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> RefreshConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection> UpdateConnectionPolicyRules(string id, Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateConnectionPolicyRules(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxConnection>> UpdateConnectionPolicyRulesAsync(string id, Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackage> GetContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackage>> GetContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetContentPackages(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult> GetContentPackages(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackagesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackageListResult>> GetContentPackagesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadContentPackage(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackage> UploadContentPackage(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadContentPackageAsync(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContentPackage>> UploadContentPackageAsync(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>
    {
        internal SandboxGroupCredential() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Origin { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ConnectionState State { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupCredentialConnectionRefDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>
    {
        public SandboxGroupCredentialConnectionRefDetails(Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord authentication, string tokenExchangeEndpoint) { }
        public Azure.Containers.ContainerApps.Sandbox.GatewayConnectionAuthRecord Authentication { get { throw null; } set { } }
        public string TokenExchangeEndpoint { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialOrigin : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialOrigin(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Connections { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Credentials { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialProvider : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialProvider(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider Claude { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider GitHubCopilot { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
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
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential> GetCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>> GetCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredentials(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential> SetCredential(string credentialName, Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetCredential(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredential>> SetCredentialAsync(string credentialName, Azure.Containers.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetCredentialAsync(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupCredentialSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>
    {
        public SandboxGroupCredentialSource(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind kind) { }
        public string ConnectionId { get { throw null; } set { } }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails ConnectionRefDetails { get { throw null; } set { } }
        public string ConnectionResourceId { get { throw null; } set { } }
        public string ConnectionType { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialSourceKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialSourceKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind ExistingAdcConnection { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind GatewayConnectionRef { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind Pat { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind SecretRef { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.Containers.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxGroupDiskImages
    {
        protected SandboxGroupDiskImages() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.DiskImage> CreateDiskImage(Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateDiskImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.DiskImage>> CreateDiskImageAsync(Azure.Containers.ContainerApps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateDiskImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.DiskImage> GetDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.DiskImage>> GetDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImages(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.DiskImage>> GetDiskImages(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImagesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.DiskImage>>> GetDiskImagesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicDiskImage(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage> GetPublicDiskImage(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicDiskImageAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>> GetPublicDiskImageAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPublicDiskImages(int? page, int? pageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>> GetPublicDiskImages(int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPublicDiskImagesAsync(int? page, int? pageSize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.PublicDiskImage>>> GetPublicDiskImagesAsync(int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupEgressPolicies
    {
        protected SandboxGroupEgressPolicies() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicies(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult> GetEgressPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPoliciesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicyListResult>> GetEgressPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy> GetEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>> GetEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy> SetEgressPolicy(string policyId, Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy>> SetEgressPolicyAsync(string policyId, Azure.Containers.ContainerApps.Sandbox.NamedEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public abstract partial class SandboxGroupIdentitySelector : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>
    {
        internal SandboxGroupIdentitySelector() { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorSystemAssignedIdentitySelector : Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorUserAssignedIdentitySelector : Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupSandbox
    {
        protected SandboxGroupSandbox() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Containers.ContainerApps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Containers.ContainerApps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult> Commit(Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Commit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.CommitSandboxResult>> CommitAsync(Azure.Containers.ContainerApps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CommitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot> CreateSnapshot(Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>> CreateSnapshotAsync(Azure.Containers.ContainerApps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Containers.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Enable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult> ExecuteCommand(Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteCommandResult>> ExecuteCommandAsync(Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult> ExecuteShellCommand(Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteShellCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(Azure.Containers.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteShellCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxFiles GetSandboxFilesClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupSandboxNetworking GetSandboxGroupSandboxNetworkingClient() { throw null; }
        public virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupSandboxStreams GetSandboxGroupSandboxStreamsClient() { throw null; }
        public virtual Azure.Response GetStats(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox> SetLifecyclePolicy(Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLifecyclePolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ContainerAppsSandbox>> SetLifecyclePolicyAsync(Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLifecyclePolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Stop(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot> Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupSandboxNetworking
    {
        protected SandboxGroupSandboxNetworking() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult> AddConnection(Azure.Containers.ContainerApps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.ConnectionsListResult>> AddConnectionAsync(Azure.Containers.ContainerApps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult> AddPort(Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult>> AddPortAsync(Azure.Containers.ContainerApps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEgressDecisions(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult> GetEgressDecisions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressDecisionsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.EgressDecisionsResult>> GetEgressDecisionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetPorts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult> GetPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPortsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult>> GetPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult> RemovePort(Azure.Containers.ContainerApps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemovePort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult>> RemovePortAsync(Azure.Containers.ContainerApps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemovePortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy> SetEgressPolicy(Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetEgressPolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy>> SetEgressPolicyAsync(Azure.Containers.ContainerApps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetEgressPolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult> SetPorts(Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetPorts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.PortsListResult>> SetPortsAsync(Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult> GetSecretKeys(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretKeysAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>> GetSecretKeysAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSecrets(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretListResult> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretListResult>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PeekSecret(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult> PeekSecret(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PeekSecretAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>> PeekSecretAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSecret> SetSecret(string secretId, Azure.Containers.ContainerApps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetSecret(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>> SetSecretAsync(string secretId, Azure.Containers.ContainerApps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot> GetSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>> GetSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshotCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<int> GetSnapshotCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<int>> GetSnapshotCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshots(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>> GetSnapshots(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotsAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>>> GetSnapshotsAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class SandboxGroupVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>
    {
        internal SandboxGroupVolume() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState ProvisioningState { get { throw null; } }
        public string VolumeName { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume sandboxGroupVolume) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupVolumes
    {
        protected SandboxGroupVolumes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume> CreateVolume(string volumeName, Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>> CreateVolumeAsync(string volumeName, Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateVolumeDirectory(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumePathItem> CreateVolumeDirectory(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVolumeDirectoryAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>> CreateVolumeDirectoryAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadVolumeFile(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileStreamResult> DownloadVolumeFile(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadVolumeFileAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.FileStreamResult>> DownloadVolumeFileAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume> ForkVolume(string volumeName, Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ForkVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>> ForkVolumeAsync(string volumeName, Azure.Containers.ContainerApps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ForkVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeCounts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult> GetVolumeCounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeCountsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>> GetVolumeCountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFilesMetadata(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult> GetVolumeFilesMetadata(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFilesMetadataAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>> GetVolumeFilesMetadataAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumes(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>> GetVolumes(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume>>> GetVolumesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadVolumeFile(string volumeName, Azure.Core.RequestContent content, string path = null, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumePathItem> UploadVolumeFile(string volumeName, System.BinaryData content, string path = null, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadVolumeFileAsync(string volumeName, Azure.Core.RequestContent content, string path = null, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>> UploadVolumeFileAsync(string volumeName, System.BinaryData content, string path = null, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxLifecyclePolicy : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>
    {
        public SandboxLifecyclePolicy(Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy, Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy) { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxAutoDeletePolicy AutoDeletePolicy { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxAutoSuspendPolicy AutoSuspendPolicy { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy sandboxLifecyclePolicy) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPort : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>
    {
        internal SandboxPort() { }
        public Azure.Containers.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } }
        public string Name { get { throw null; } }
        public int Port { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPort JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPort PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxPort System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxPort System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPortUpdate : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>
    {
        public SandboxPortUpdate(int port, System.Uri url) { }
        public Azure.Containers.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPresetProperties : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>
    {
        public SandboxPresetProperties() { }
        public bool? IsWorkIqConnectionEnabled { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxPresetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>
    {
        public SandboxResources(string cpu, string memory) { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSecret : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>
    {
        internal SandboxSecret() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSecret JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxSecret (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSecret PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSecret System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSecret System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>
    {
        internal SandboxSnapshot() { }
        public System.DateTimeOffset CreatedAtUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.SnapshotResources Resources { get { throw null; } }
        public string SandboxId { get { throw null; } }
        public string SizeInMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer> SourcePodContainers { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSource : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>
    {
        public SandboxSource() { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod Pod { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot Snapshot { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSource System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSource System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceArtifactVersion : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>
    {
        public SandboxSourceArtifactVersion(string id, Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth auth) { }
        public Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth Auth { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>
    {
        public SandboxSourceAuth(string identity) { }
        public string Identity { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>
    {
        public SandboxSourceDiskImage() { }
        public string Id { get { throw null; } set { } }
        public bool? IsPublic { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourcePod : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>
    {
        public SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.ContainerSpec> containers) { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.ContainerSpec> Containers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.PodContentPackage> ContentPackages { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.ContainerRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.PodSecurityContext SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Volumes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourcePod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>
    {
        public SandboxSourceSnapshot(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxSourceSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxState : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SandboxState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxState(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState Creating { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState Idle { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState Running { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState StopFailed { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState Stopped { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxState Stopping { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SandboxState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SandboxState left, Azure.Containers.ContainerApps.Sandbox.SandboxState right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxState (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SandboxState left, Azure.Containers.ContainerApps.Sandbox.SandboxState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>
    {
        internal SandboxStateDetails() { }
        public System.DateTimeOffset StoppedOn { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.StoppedReason StoppedReason { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxStatsResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>
    {
        internal SandboxStatsResult() { }
        public Azure.Containers.ContainerApps.Sandbox.CpuStats Cpu { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.DiskStatsEntry> Disk { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.MemoryStats Memory { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.NetworkStats Network { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.TokenUsageStats TokenUsage { get { throw null; } }
        public double? UptimeSecs { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxStatsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxSuspendMode : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxSuspendMode(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode Disk { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode Memory { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode None { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode left, Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode left, Azure.Containers.ContainerApps.Sandbox.SandboxSuspendMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>
    {
        public SandboxVolume(string volumeName, string mountpoint) { }
        public string Mountpoint { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SandboxVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SandboxVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SandboxVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SandboxVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SeccompProfile : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>
    {
        public SeccompProfile(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType type) { }
        public Azure.Containers.ContainerApps.Sandbox.SeccompProfileType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SeccompProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SeccompProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SeccompProfile System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SeccompProfile System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SeccompProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeccompProfileType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.SeccompProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeccompProfileType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.SeccompProfileType RuntimeDefault { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.SeccompProfileType Unconfined { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType left, Azure.Containers.ContainerApps.Sandbox.SeccompProfileType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SeccompProfileType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.SeccompProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.SeccompProfileType left, Azure.Containers.ContainerApps.Sandbox.SeccompProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretKeysResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>
    {
        internal SecretKeysResult() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretKeysResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SecretKeysResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretKeysResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretKeysResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretListResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>
    {
        internal SecretListResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxSecret> Secrets { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SecretListResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SecretListResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SecretListResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretPeekResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>
    {
        internal SecretPeekResult() { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretPeekResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.SecretPeekResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SecretPeekResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SecretPeekResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceManagedBlobPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>
    {
        public ServiceManagedBlobPodVolume(string fileCacheSizeLimit, string name) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceManagedBlobPodVolumeKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceManagedBlobPodVolumeKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind AzureBlob { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceManagedBlobVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>
    {
        public ServiceManagedBlobVolume() { }
        public Azure.Containers.ContainerApps.Sandbox.BlobVolumeUsage Usage { get { throw null; } }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ServiceManagedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPodContainer : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>
    {
        internal SnapshotPodContainer() { }
        public string DiskImageId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotPodContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResources : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>
    {
        internal SnapshotResources() { }
        public string Cpu { get { throw null; } }
        public string Disk { get { throw null; } }
        public string Memory { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SnapshotResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.SnapshotResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.SnapshotResources System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.SnapshotResources System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.SnapshotResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEgress : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>
    {
        internal StatefulTcpEgress() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry> Connections { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEntry : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>
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
        protected virtual Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StatefulTcpEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoppedReason : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.StoppedReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoppedReason(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.StoppedReason Disabled { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.StoppedReason Idle { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.StoppedReason UserStopped { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.StoppedReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.StoppedReason left, Azure.Containers.ContainerApps.Sandbox.StoppedReason right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.StoppedReason (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.StoppedReason? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.StoppedReason left, Azure.Containers.ContainerApps.Sandbox.StoppedReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StringSegment : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>
    {
        internal StringSegment() { }
        public string Buffer { get { throw null; } }
        public bool? HasValue { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.StringSegment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.StringSegment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.StringSegment System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.StringSegment System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.StringSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TdsAuthKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TdsAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TdsAuthKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TdsAuthKind EntraToken { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TdsAuthKind SqlPassword { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TdsAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TdsAuthKind left, Azure.Containers.ContainerApps.Sandbox.TdsAuthKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TdsAuthKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TdsAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TdsAuthKind left, Azure.Containers.ContainerApps.Sandbox.TdsAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdsCredential : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>
    {
        public TdsCredential(string name, Azure.Containers.ContainerApps.Sandbox.TdsAuthKind kind) { }
        public Azure.Containers.ContainerApps.Sandbox.TdsAuthKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TdsCredential System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TdsCredential System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressAction : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>
    {
        public TdsEgressAction(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType type) { }
        public string Credential { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressMatch : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>
    {
        public TdsEgressMatch(string host) { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Host { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>
    {
        public TdsEgressRule(string name, Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch match) { }
        public Azure.Containers.ContainerApps.Sandbox.TdsEgressAction Action { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TdsEgressMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>
    {
        public TdsEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TdsCredential> credentials, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule> rules) { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TdsCredential> Credentials { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TdsEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TdsEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TdsEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryApplicationInsightsAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>
    {
        public TelemetryApplicationInsightsAuth(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryAppSecretRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>
    {
        public TelemetryAppSecretRef(string secretRef) { }
        public string SecretRef { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryAppSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<System.BinaryData> endpoints) { }
        public System.Collections.Generic.IList<System.BinaryData> Endpoints { get { throw null; } }
        public int? MetricsIntervalSeconds { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryData : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TelemetryData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryData(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryData ContainerOtel { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryData ContainerStdoutStderr { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryData Metrics { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryData NetworkEgressDecisions { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TelemetryData other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TelemetryData left, Azure.Containers.ContainerApps.Sandbox.TelemetryData right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryData (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryData? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TelemetryData left, Azure.Containers.ContainerApps.Sandbox.TelemetryData right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetryHeaderAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>
    {
        public TelemetryHeaderAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryHeaderAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryManagedIdentityAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>
    {
        public TelemetryManagedIdentityAuth(string identity) { }
        public string Identity { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? Kind { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryManagedIdentityAuthKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryManagedIdentityAuthKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind ManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind left, Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind left, Azure.Containers.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryProtocol : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryProtocol(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol Grpc { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol Http { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol left, Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol left, Azure.Containers.ContainerApps.Sandbox.TelemetryProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySandboxGroupSecretRef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>
    {
        public TelemetrySandboxGroupSecretRef(string secretId, string secretKey) { }
        public Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? Kind { get { throw null; } set { } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetrySandboxGroupSecretRefKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetrySandboxGroupSecretRefKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind GlobalSecret { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind left, Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind left, Azure.Containers.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySystemAssignedManagedIdentityAuth : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>
    {
        public TelemetrySystemAssignedManagedIdentityAuth() { }
        public Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? Kind { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetrySystemAssignedManagedIdentityAuthKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetrySystemAssignedManagedIdentityAuthKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind SystemAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind left, Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind left, Azure.Containers.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenUsageStats : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>
    {
        internal TokenUsageStats() { }
        public int? RequestCount { get { throw null; } }
        public long? TotalInputTokens { get { throw null; } }
        public long? TotalOutputTokens { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TokenUsageStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TokenUsageStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TokenUsageStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficInspection : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TrafficInspection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficInspection(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TrafficInspection Full { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TrafficInspection Legacy { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TrafficInspection None { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TrafficInspection Partial { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TrafficInspection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TrafficInspection left, Azure.Containers.ContainerApps.Sandbox.TrafficInspection right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TrafficInspection (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TrafficInspection? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TrafficInspection left, Azure.Containers.ContainerApps.Sandbox.TrafficInspection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransportEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>
    {
        public TransportEgressRule(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType action, Azure.Containers.ContainerApps.Sandbox.TransportProtocol protocol, string destination, int port) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType Action { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.TransportProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TransportEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TransportEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>
    {
        public TransportEgressSection(Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule> rules) { }
        public Azure.Containers.ContainerApps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.TransportEgressRule> Rules { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TransportEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.TransportEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.TransportEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.TransportProtocol Tcp { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.TransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.TransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.TransportProtocol left, Azure.Containers.ContainerApps.Sandbox.TransportProtocol right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TransportProtocol (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.TransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.TransportProtocol left, Azure.Containers.ContainerApps.Sandbox.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatePolicyRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>
    {
        public UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> policyRules) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent updatePolicyRulesContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePortsContent : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>
    {
        public UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate> ports) { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.SandboxPortUpdate> Ports { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent updatePortsContent) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UpdatePortsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProvidedBlobPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>
    {
        public UserProvidedBlobPodVolume(string fileCacheSizeLimit, string name) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserProvidedBlobPodVolumeKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserProvidedBlobPodVolumeKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind AzureBlobByo { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind left, Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserProvidedBlobVolume : Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>
    {
        public UserProvidedBlobVolume(string storageContainerResourceId, Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication auth) { }
        public Azure.Containers.ContainerApps.Sandbox.BlobVolumeAuthentication Auth { get { throw null; } set { } }
        public string StorageContainerResourceId { get { throw null; } set { } }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.Containers.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.UserProvidedBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationWarning : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>
    {
        public ValidationWarning(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ValidationWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ValidationWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ValidationWarning System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ValidationWarning System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValidationWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValueLogColumnDef : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>
    {
        public ValueLogColumnDef(string value) { }
        public Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind? Kind { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueLogColumnDefKind : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueLogColumnDefKind(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind Value { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind left, Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind left, Azure.Containers.ContainerApps.Sandbox.ValueLogColumnDefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeCountResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>
    {
        internal VolumeCountResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount> Counts { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.VolumeCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeListDirectoryResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>
    {
        internal VolumeListDirectoryResult() { }
        public System.Collections.Generic.IList<Azure.Containers.ContainerApps.Sandbox.VolumePathItem> Items { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeListDirectoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumePathItem : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>
    {
        internal VolumePathItem() { }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string ItemName { get { throw null; } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Path { get { throw null; } }
        public System.BinaryData SizeBytes { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumePathItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.VolumePathItem (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumePathItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.VolumePathItem System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.VolumePathItem System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumePathItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeProvisioningState : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeProvisioningState(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState Provisioning { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState left, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState left, Azure.Containers.ContainerApps.Sandbox.VolumeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeType : System.IEquatable<Azure.Containers.ContainerApps.Sandbox.VolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeType(string value) { throw null; }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType AzureBlob { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType AzureBlobByo { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType AzureFileCifs { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType AzureFileNfs { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType DataDisk { get { throw null; } }
        public static Azure.Containers.ContainerApps.Sandbox.VolumeType Esan { get { throw null; } }
        public bool Equals(Azure.Containers.ContainerApps.Sandbox.VolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Containers.ContainerApps.Sandbox.VolumeType left, Azure.Containers.ContainerApps.Sandbox.VolumeType right) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.VolumeType (string value) { throw null; }
        public static implicit operator Azure.Containers.ContainerApps.Sandbox.VolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.Containers.ContainerApps.Sandbox.VolumeType left, Azure.Containers.ContainerApps.Sandbox.VolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeTypeCount : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>
    {
        internal VolumeTypeCount() { }
        public int Count { get { throw null; } }
        public Azure.Containers.ContainerApps.Sandbox.VolumeType Type { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.VolumeTypeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WriteFileResult : System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>, System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>
    {
        internal WriteFileResult() { }
        public long? BytesWritten { get { throw null; } }
        public string Error { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.Containers.ContainerApps.Sandbox.WriteFileResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.Containers.ContainerApps.Sandbox.WriteFileResult (Azure.Response response) { throw null; }
        protected virtual Azure.Containers.ContainerApps.Sandbox.WriteFileResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.Containers.ContainerApps.Sandbox.WriteFileResult System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.Containers.ContainerApps.Sandbox.WriteFileResult System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.Containers.ContainerApps.Sandbox.WriteFileResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
