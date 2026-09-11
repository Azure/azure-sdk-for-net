namespace Azure.ContainerApps.Sandbox
{
    public partial class AddConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddConnectionContent>
    {
        public AddConnectionContent(string connectionId) { }
        public string ConnectionId { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.AddConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.AddConnectionContent addConnectionContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.AddConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AddConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddPodVolumeMountsContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>
    {
        public AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<System.BinaryData> volumes, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerVolumeMounts> containerMounts) { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContainerVolumeMounts> ContainerMounts { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Volumes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent addPodVolumeMountsContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddVolumeMountContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>
    {
        public AddVolumeMountContent(Azure.ContainerApps.Sandbox.SandboxVolume volumeMount) { }
        public Azure.ContainerApps.Sandbox.SandboxVolume VolumeMount { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.AddVolumeMountContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.AddVolumeMountContent addVolumeMountContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.AddVolumeMountContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AddVolumeMountContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AddVolumeMountContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationInsightsTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>
    {
        public ApplicationInsightsTelemetryEndpoint(Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth auth, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data) { }
        public Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? Kind { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationInsightsTelemetryEndpointKind : System.IEquatable<Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationInsightsTelemetryEndpointKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind ApplicationInsights { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AuthorizeConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>
    {
        public AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues) { }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.AuthorizeConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.AuthorizeConnectionContent authorizeConnectionContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.AuthorizeConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AuthorizeConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AuthorizeConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoDeleteTrigger : System.IEquatable<Azure.ContainerApps.Sandbox.AutoDeleteTrigger>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoDeleteTrigger(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.AutoDeleteTrigger AfterCreation { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.AutoDeleteTrigger AfterSuspend { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.AutoDeleteTrigger other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.AutoDeleteTrigger left, Azure.ContainerApps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AutoDeleteTrigger (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AutoDeleteTrigger? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.AutoDeleteTrigger left, Azure.ContainerApps.Sandbox.AutoDeleteTrigger right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureBlobByoPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>
    {
        public AzureBlobByoPodVolume(string fileCacheSizeLimit, string name) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureBlobByoPodVolumeKind : System.IEquatable<Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureBlobByoPodVolumeKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind AzureBlobByo { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind left, Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind left, Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureBlobByoVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>
    {
        public AzureBlobByoVolume(string storageContainerResourceId, System.BinaryData auth) { }
        public System.BinaryData Auth { get { throw null; } set { } }
        public string StorageContainerResourceId { get { throw null; } set { } }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureBlobByoVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureBlobByoVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>
    {
        public AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth(Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector identity) { }
        public Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureBlobPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>
    {
        public AzureBlobPodVolume(string fileCacheSizeLimit, string name) { }
        public string FileCacheSizeLimit { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.AzureBlobPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureBlobPodVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureBlobPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureBlobPodVolumeKind : System.IEquatable<Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureBlobPodVolumeKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind AzureBlob { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind left, Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind left, Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureBlobVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>
    {
        public AzureBlobVolume() { }
        public Azure.ContainerApps.Sandbox.BlobVolumeUsage Usage { get { throw null; } }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureBlobVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureBlobVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureBlobVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContainerAppsSandboxContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureContainerAppsSandboxContext() { }
        public static Azure.ContainerApps.Sandbox.AzureContainerAppsSandboxContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureFileCifsVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>
    {
        public AzureFileCifsVolume() { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureFileCifsVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureFileCifsVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileCifsVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFileNfsVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>
    {
        public AzureFileNfsVolume() { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.AzureFileNfsVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.AzureFileNfsVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.AzureFileNfsVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BlobVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>
    {
        internal BlobVolumeUsage() { }
        public System.DateTimeOffset CalculatedAtUtc { get { throw null; } }
        public long ItemCount { get { throw null; } }
        public System.BinaryData UsedBytes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.BlobVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.BlobVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.BlobVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.BlobVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>
    {
        public CommitSandboxContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CommitSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CommitSandboxContent commitSandboxContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CommitSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CommitSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommitSandboxResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>
    {
        internal CommitSandboxResult() { }
        public Azure.ContainerApps.Sandbox.DiskImage DiskImage { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CommitSandboxResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.CommitSandboxResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CommitSandboxResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CommitSandboxResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CommitSandboxResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsListResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>
    {
        internal ConnectionsListResult() { }
        public System.Collections.Generic.IList<string> ConnectionIds { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ConnectionsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.ConnectionsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ConnectionsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ConnectionsListResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ConnectionsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectionState : System.IEquatable<Azure.ContainerApps.Sandbox.ConnectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectionState(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ConnectionState Creating { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ConnectionState Error { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ConnectionState Ready { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ConnectionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ConnectionState left, Azure.ContainerApps.Sandbox.ConnectionState right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ConnectionState (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ConnectionState? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ConnectionState left, Azure.ContainerApps.Sandbox.ConnectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerAppsSandbox : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>
    {
        internal ContainerAppsSandbox() { }
        public Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } }
        public string AppUri { get { throw null; } }
        public System.Collections.Generic.IList<string> Cmd { get { throw null; } }
        public string ColdStorageSizeInMb { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContainerStatus> ContainerStatuses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.GatewayConnection> GatewayConnections { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } }
        public string ManagementUri { get { throw null; } }
        public System.Collections.Generic.IList<string> OutboundIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxPort> Ports { get { throw null; } }
        public string Region { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxResources Resources { get { throw null; } }
        public string SandboxGroupId { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxSource SourcesRef { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxState? State { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxStateDetails StateDetails { get { throw null; } }
        public string VnetConnectionName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerAppsSandbox JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.ContainerAppsSandbox (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ContainerAppsSandbox PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerAppsSandbox System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerAppsSandboxClient
    {
        protected ContainerAppsSandboxClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ContainerAppsSandboxClient(Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings settings) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContainerAppsSandboxClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroup GetSandboxGroupClient(string subscriptionId, string resourceGroupName, string sandboxGroupName) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ContainerAppsSandboxClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContainerAppsSandboxClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientSettings> configureSettings) { throw null; }
    }
    public partial class ContainerAppsSandboxClientOptions : Azure.Core.ClientOptions
    {
        public ContainerAppsSandboxClientOptions(Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion version = Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions.ServiceVersion.V2026_09_01_Preview) { }
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
        public Azure.ContainerApps.Sandbox.ContainerAppsSandboxClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class ContainerProbe : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbe>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbe>
    {
        public ContainerProbe() { }
        public Azure.ContainerApps.Sandbox.ProbeExecAction Exec { get { throw null; } set { } }
        public int? FailureThreshold { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ProbeHttpGetAction HttpGet { get { throw null; } set { } }
        public int? InitialDelaySeconds { get { throw null; } set { } }
        public int? PeriodSeconds { get { throw null; } set { } }
        public int? SuccessThreshold { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ProbeTcpSocketAction TcpSocket { get { throw null; } set { } }
        public int? TerminationGracePeriodSeconds { get { throw null; } set { } }
        public int? TimeoutSeconds { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerProbe JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerProbe PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerProbe System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbe>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbe>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerProbe System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbe>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbe>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbe>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerProbeResult : System.IEquatable<Azure.ContainerApps.Sandbox.ContainerProbeResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerProbeResult(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerProbeResult Failure { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerProbeResult Success { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerProbeResult Unknown { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ContainerProbeResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ContainerProbeResult left, Azure.ContainerApps.Sandbox.ContainerProbeResult right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerProbeResult (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerProbeResult? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ContainerProbeResult left, Azure.ContainerApps.Sandbox.ContainerProbeResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerProbeStatus : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>
    {
        internal ContainerProbeStatus() { }
        public int? ConsecutiveFailures { get { throw null; } }
        public int? ConsecutiveSuccesses { get { throw null; } }
        public System.DateTimeOffset? LastCheckedOn { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ContainerProbeResult? LastResult { get { throw null; } }
        public System.DateTimeOffset? LastTransitionOn { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerProbeStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerProbeStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerProbeStatus System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerProbeStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerResources : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerResources>
    {
        public ContainerResources() { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerResources System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerResources System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRestartPolicy : System.IEquatable<Azure.ContainerApps.Sandbox.ContainerRestartPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRestartPolicy(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerRestartPolicy Always { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerRestartPolicy Never { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerRestartPolicy OnFailure { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ContainerRestartPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ContainerRestartPolicy left, Azure.ContainerApps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerRestartPolicy (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerRestartPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ContainerRestartPolicy left, Azure.ContainerApps.Sandbox.ContainerRestartPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerRuntimeState : System.IEquatable<Azure.ContainerApps.Sandbox.ContainerRuntimeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerRuntimeState(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerRuntimeState Running { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerRuntimeState Terminated { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerRuntimeState Unknown { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerRuntimeState Waiting { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ContainerRuntimeState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ContainerRuntimeState left, Azure.ContainerApps.Sandbox.ContainerRuntimeState right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerRuntimeState (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerRuntimeState? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ContainerRuntimeState left, Azure.ContainerApps.Sandbox.ContainerRuntimeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>
    {
        public ContainerSecurityContext() { }
        public bool? AllowPrivilegeEscalation { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.LinuxCapabilities Capabilities { get { throw null; } set { } }
        public bool? Privileged { get { throw null; } set { } }
        public bool? ReadOnlyRootFilesystem { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SeccompProfile SeccompProfile { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerSpec : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSpec>
    {
        public ContainerSpec(string name) { }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Env { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ContainerProbe LivenessProbe { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ContainerProbe ReadinessProbe { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ContainerResources Resources { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ContainerSecurityContext SecurityContext { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ContainerProbe StartupProbe { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerSpec System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerSpec System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerStatus : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerStatus>
    {
        internal ContainerStatus() { }
        public int? LastExitCode { get { throw null; } }
        public System.DateTimeOffset? LastFinishedOn { get { throw null; } }
        public System.DateTimeOffset? LastStartedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ContainerApps.Sandbox.ContainerProbeStatus> Probes { get { throw null; } }
        public bool Ready { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ContainerStatusReason? Reason { get { throw null; } }
        public int RestartCount { get { throw null; } }
        public bool Started { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ContainerRuntimeState State { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerStatus System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerStatus System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerStatusReason : System.IEquatable<Azure.ContainerApps.Sandbox.ContainerStatusReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerStatusReason(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerStatusReason Completed { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerStatusReason CrashLoopBackOff { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerStatusReason Error { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerStatusReason RootfsResetFailed { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContainerStatusReason RootfsResetPending { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ContainerStatusReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ContainerStatusReason left, Azure.ContainerApps.Sandbox.ContainerStatusReason right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerStatusReason (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContainerStatusReason? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ContainerStatusReason left, Azure.ContainerApps.Sandbox.ContainerStatusReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerVolumeMount : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>
    {
        public ContainerVolumeMount(string name, string mountPath) { }
        public string MountPath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerVolumeMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerVolumeMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerVolumeMount System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerVolumeMounts : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>
    {
        public ContainerVolumeMounts(string containerName, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts) { }
        public string ContainerName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContainerVolumeMount> VolumeMounts { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContainerVolumeMounts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ContainerVolumeMounts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContainerVolumeMounts System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContainerVolumeMounts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackage>
    {
        internal ContentPackage() { }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public System.BinaryData Size { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.ContentPackage (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContentPackage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContentPackageAction : System.IEquatable<Azure.ContainerApps.Sandbox.ContentPackageAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContentPackageAction(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContentPackageAction Download { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ContentPackageAction Mount { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ContentPackageAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ContentPackageAction left, Azure.ContainerApps.Sandbox.ContentPackageAction right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContentPackageAction (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ContentPackageAction? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ContentPackageAction left, Azure.ContainerApps.Sandbox.ContentPackageAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContentPackageListResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>
    {
        internal ContentPackageListResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContentPackage> Value { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ContentPackageListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.ContentPackageListResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ContentPackageListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ContentPackageListResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ContentPackageListResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ContentPackageListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CpuStats : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CpuStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CpuStats>
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
        protected virtual Azure.ContainerApps.Sandbox.CpuStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.CpuStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CpuStats System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CpuStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CpuStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CpuStats System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CpuStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CpuStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CpuStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>
    {
        public CreateConnectionContent(string name, string type) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string ParameterValueSetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValueSetValues { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateConnectionContent createConnectionContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>
    {
        public CreateDiskImageContent(Azure.ContainerApps.Sandbox.CreateDiskImageSource source) { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.CreateDiskImageSource Source { get { throw null; } }
        public string VnetConnectionName { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.CreateDiskImageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateDiskImageContent createDiskImageContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateDiskImageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateDiskImageContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CreateDiskImageSource : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>
    {
        internal CreateDiskImageSource() { }
        protected virtual Azure.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateDiskImageSource System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceBlobSource : Azure.ContainerApps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>
    {
        public CreateDiskImageSourceBlobSource(string blobSourceUri) { }
        public string BlobSourceUri { get { throw null; } }
        protected override Azure.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateDiskImageSourceRegistrySource : Azure.ContainerApps.Sandbox.CreateDiskImageSource, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>
    {
        public CreateDiskImageSourceRegistrySource(string imageReference) { }
        public Azure.ContainerApps.Sandbox.RegistryAuthentication Authentication { get { throw null; } set { } }
        public string ImageReference { get { throw null; } }
        protected override Azure.ContainerApps.Sandbox.CreateDiskImageSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.CreateDiskImageSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>
    {
        public CreateSandboxContent() { }
        public Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef AgentIdentity { get { throw null; } set { } }
        public string AnthropicApiKey { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Cmd { get { throw null; } }
        public System.Collections.Generic.IList<string> Connections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> ContentPackageDownloads { get { throw null; } }
        public System.Collections.Generic.IList<string> CredentialRefs { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxEgressPolicy EgressPolicy { get { throw null; } set { } }
        public string EgressPolicyId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent> GatewayConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.IdentitySetting> IdentitySettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy Lifecycle { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.CreateSandboxPortContent> Ports { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxPresetProperties PresetProperties { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PresetSandboxType? PresetSandboxType { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxResources Resources { get { throw null; } set { } }
        public string SandboxGroupId { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxSource SourcesRef { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        public string VnetConnectionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxVolume> Volumes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateSandboxContent createSandboxContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGatewayConnectionContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>
    {
        public CreateSandboxGatewayConnectionContent(string resourceId) { }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxGroupCredentialContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>
    {
        public CreateSandboxGroupCredentialContent(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider, Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource source) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent createSandboxGroupCredentialContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSandboxPortContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>
    {
        public CreateSandboxPortContent(int port) { }
        public Azure.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxPortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateSandboxPortContent createSandboxPortContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateSandboxPortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSandboxPortContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSandboxPortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSecretContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSecretContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSecretContent>
    {
        public CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values) { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSecretContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateSecretContent createSecretContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateSecretContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSecretContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSecretContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSecretContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSecretContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSecretContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSecretContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateSnapshotContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>
    {
        public CreateSnapshotContent() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.CreateSnapshotContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.CreateSnapshotContent createSnapshotContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.CreateSnapshotContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.CreateSnapshotContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.CreateSnapshotContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>
    {
        public DataDiskPodVolume(string name) { }
        public Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.DataDiskPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.DataDiskPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DataDiskPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataDiskPodVolumeKind : System.IEquatable<Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataDiskPodVolumeKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind DataDisk { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind left, Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind left, Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataDiskVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolume>
    {
        public DataDiskVolume(string size) { }
        public string AttachedSandboxId { get { throw null; } }
        public string ClusterId { get { throw null; } }
        public bool IsAttached { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.DataDiskVolumeUsage Usage { get { throw null; } }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DataDiskVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataDiskVolumeUsage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>
    {
        internal DataDiskVolumeUsage() { }
        public System.BinaryData CompressedBlobSizeBytes { get { throw null; } }
        public System.DateTimeOffset LastUploadedAtUtc { get { throw null; } }
        public System.BinaryData UsedSizeBytes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DataDiskVolumeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.DataDiskVolumeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DataDiskVolumeUsage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DataDiskVolumeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DirListingResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DirListingResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DirListingResult>
    {
        internal DirListingResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.FileInfo> Entries { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DirListingResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.DirListingResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.DirListingResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DirListingResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DirListingResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DirListingResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DirListingResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DirListingResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DirListingResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DirListingResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImage>
    {
        internal DiskImage() { }
        public string Id { get { throw null; } }
        public Azure.ContainerApps.Sandbox.DiskImageImage Image { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public string SizeInMb { get { throw null; } }
        public Azure.ContainerApps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.DiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.DiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DiskImage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageImage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageImage>
    {
        internal DiskImageImage() { }
        public string Base { get { throw null; } }
        public System.Collections.Generic.IList<string> Cmd { get { throw null; } }
        public System.Collections.Generic.IList<string> Entrypoint { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DiskImageImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.DiskImageImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DiskImageImage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DiskImageImage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskImageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageStatus>
    {
        internal DiskImageStatus() { }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string State { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DiskImageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.DiskImageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskImageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DiskImageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskImageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskStatsEntry : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>
    {
        internal DiskStatsEntry() { }
        public int? AvailableBytes { get { throw null; } }
        public string Filesystem { get { throw null; } }
        public string Label { get { throw null; } }
        public string MountPoint { get { throw null; } }
        public int? TotalBytes { get { throw null; } }
        public int? UsedBytes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DiskStatsEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.DiskStatsEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DiskStatsEntry System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DiskStatsEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DownloadContentPackageToSandboxContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>
    {
        public DownloadContentPackageToSandboxContent(string contentPackageId, string targetPath) { }
        public string ContentPackageId { get { throw null; } }
        public string TargetPath { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent downloadContentPackageToSandboxContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionEntry : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>
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
        protected virtual Azure.ContainerApps.Sandbox.EgressDecisionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressDecisionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressDecisionEntry System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressDecisionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>
    {
        internal EgressDecisionsResult() { }
        public Azure.ContainerApps.Sandbox.NetworkEgressDecisions Http { get { throw null; } }
        public System.DateTimeOffset LastUpdated { get { throw null; } }
        public Azure.ContainerApps.Sandbox.StatefulTcpEgress StatefulTcp { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.EgressDecisionsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.EgressDecisionsResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.EgressDecisionsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressDecisionsResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressDecisionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressForwardMode : System.IEquatable<Azure.ContainerApps.Sandbox.EgressForwardMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressForwardMode(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressForwardMode Default { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressForwardMode Direct { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressForwardMode Proxy { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressForwardMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressForwardMode left, Azure.ContainerApps.Sandbox.EgressForwardMode right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressForwardMode (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressForwardMode? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressForwardMode left, Azure.ContainerApps.Sandbox.EgressForwardMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressForwardProxy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>
    {
        public EgressForwardProxy(string url) { }
        public string Ca { get { throw null; } set { } }
        public string Url { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressForwardProxy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressForwardProxy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressForwardProxy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressForwardProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressHostRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressHostRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressHostRule>
    {
        public EgressHostRule(string pattern) { }
        public Azure.ContainerApps.Sandbox.EgressPolicyAction? Action { get { throw null; } set { } }
        public string Pattern { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressHostRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressHostRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressHostRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressHostRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressHostRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressHostRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressHostRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressHostRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressHostRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyAction : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyAction(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyAction Allow { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyAction Deny { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyAction left, Azure.ContainerApps.Sandbox.EgressPolicyAction right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyAction (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyAction? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyAction left, Azure.ContainerApps.Sandbox.EgressPolicyAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyActionType : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyActionType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyActionType Allow { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyActionType Deny { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyActionType Rewrite { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyActionType Transform { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyActionType left, Azure.ContainerApps.Sandbox.EgressPolicyActionType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyActionType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyActionType left, Azure.ContainerApps.Sandbox.EgressPolicyActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyEnforcementMode : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyEnforcementMode(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode Audit { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode Enforced { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode left, Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode left, Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHeaderOperation : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHeaderOperation(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation Insert { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation Remove { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation Set { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation left, Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation left, Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHeaderTransform : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>
    {
        public EgressPolicyHeaderTransform(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation operation, string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation Operation { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyValueRef ValueRef { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyHookFailBehavior : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyHookFailBehavior(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior Allow { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior Deny { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior left, Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior left, Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyHookRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>
    {
        public EgressPolicyHookRef(string endpoint) { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform> AuthHeaders { get { throw null; } }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? FailBehavior { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequestHeaders { get { throw null; } }
        public Azure.ContainerApps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public int? TimeoutMs { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyHookRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyHookRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyHookRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyHookRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyManagedIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>
    {
        public EgressPolicyManagedIdentityRef(string resource) { }
        public string Format { get { throw null; } set { } }
        public string IdentityResourceId { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyManagedIdentityType : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyManagedIdentityType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType left, Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType left, Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressPolicyMatchScheme : System.IEquatable<Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressPolicyMatchScheme(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme Any { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme Http { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme Https { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme left, Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme left, Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EgressPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>
    {
        public EgressPolicyRule(string name, Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch match) { }
        public Azure.ContainerApps.Sandbox.EgressPolicyRuleAction Action { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProxyActions { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleAction : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>
    {
        public EgressPolicyRuleAction(Azure.ContainerApps.Sandbox.EgressPolicyActionType type) { }
        public Azure.ContainerApps.Sandbox.EgressForwardMode? Forward { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressForwardProxy ForwardProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform> Headers { get { throw null; } }
        public string Host { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressRuleRoutingMode? RoutingMode { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRuleAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRuleAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyRuleAction System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyRuleMatch : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>
    {
        public EgressPolicyRuleMatch(string host) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Methods { get { throw null; } }
        public bool? NormalizePath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme? Scheme { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicySecretRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>
    {
        public EgressPolicySecretRef(string secretId) { }
        public string Format { get { throw null; } set { } }
        public string SecretId { get { throw null; } set { } }
        public string SecretKey { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicySecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicySecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicySecretRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicySecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EgressPolicyValueRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>
    {
        public EgressPolicyValueRef() { }
        public Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef ManagedIdentityRef { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyValueRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EgressPolicyValueRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EgressPolicyValueRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EgressPolicyValueRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EgressRuleRoutingMode : System.IEquatable<Azure.ContainerApps.Sandbox.EgressRuleRoutingMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EgressRuleRoutingMode(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressRuleRoutingMode Default { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressRuleRoutingMode Platform { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EgressRuleRoutingMode Vnet { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EgressRuleRoutingMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EgressRuleRoutingMode left, Azure.ContainerApps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressRuleRoutingMode (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EgressRuleRoutingMode? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EgressRuleRoutingMode left, Azure.ContainerApps.Sandbox.EgressRuleRoutingMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EntityTagHeaderValue : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>
    {
        internal EntityTagHeaderValue() { }
        public bool? IsWeak { get { throw null; } }
        public Azure.ContainerApps.Sandbox.StringSegment Tag { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.EntityTagHeaderValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.EntityTagHeaderValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EntityTagHeaderValue System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EntityTagHeaderValue System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EntityTagHeaderValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EsanSku : System.IEquatable<Azure.ContainerApps.Sandbox.EsanSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EsanSku(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.EsanSku PremiumLrs { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.EsanSku PremiumZrs { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.EsanSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.EsanSku left, Azure.ContainerApps.Sandbox.EsanSku right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EsanSku (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.EsanSku? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.EsanSku left, Azure.ContainerApps.Sandbox.EsanSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EsanVolume : Azure.ContainerApps.Sandbox.SandboxGroupVolume, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EsanVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EsanVolume>
    {
        public EsanVolume(string size) { }
        public string Size { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EsanSku Sku { get { throw null; } }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.EsanVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EsanVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.EsanVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.EsanVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EsanVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EsanVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.EsanVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>
    {
        public ExecuteSandboxCommandContent(string command) { }
        public Azure.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Args { get { throw null; } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent executeSandboxCommandContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecuteSandboxShellCommandContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>
    {
        public ExecuteSandboxShellCommandContent(string command) { }
        public Azure.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public string Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Environment { get { throw null; } }
        public string Shell { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent executeSandboxShellCommandContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileInfo>
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
        protected virtual Azure.ContainerApps.Sandbox.FileInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.FileInfo (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.FileInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.FileInfo System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.FileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileOpStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>
    {
        internal FileOpStatusResult() { }
        public string Error { get { throw null; } }
        public string Message { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.FileOpStatusResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.FileOpStatusResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.FileOpStatusResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.FileOpStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileOpStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileStreamResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileStreamResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileStreamResult>
    {
        internal FileStreamResult() { }
        public string ContentType { get { throw null; } }
        public bool? EnableRangeProcessing { get { throw null; } }
        public Azure.ContainerApps.Sandbox.EntityTagHeaderValue EntityTag { get { throw null; } }
        public string FileDownloadName { get { throw null; } }
        public System.BinaryData FileStream { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.FileStreamResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.FileStreamResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.FileStreamResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.FileStreamResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileStreamResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.FileStreamResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.FileStreamResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileStreamResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileStreamResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.FileStreamResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ForkDataDiskVolumeContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>
    {
        public ForkDataDiskVolumeContent(string destinationVolumeName) { }
        public string DestinationVolumeName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent forkDataDiskVolumeContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FsGroupChangePolicy : System.IEquatable<Azure.ContainerApps.Sandbox.FsGroupChangePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FsGroupChangePolicy(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.FsGroupChangePolicy Always { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.FsGroupChangePolicy None { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.FsGroupChangePolicy OnRootMismatch { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.FsGroupChangePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.FsGroupChangePolicy left, Azure.ContainerApps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.FsGroupChangePolicy (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.FsGroupChangePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.FsGroupChangePolicy left, Azure.ContainerApps.Sandbox.FsGroupChangePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatewayAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>
    {
        internal GatewayAuthentication() { }
        public Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.GatewayAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.GatewayAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.GatewayAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnection : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnection>
    {
        internal GatewayConnection() { }
        public Azure.ContainerApps.Sandbox.GatewayAuthentication Authentication { get { throw null; } }
        public string ConnectionRuntimeUri { get { throw null; } }
        public string McpRuntimeUri { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceId { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.GatewayConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.GatewayConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.GatewayConnection System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.GatewayConnection System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GatewayConnectionAuthRecord : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>
    {
        public GatewayConnectionAuthRecord(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.GatewayConnectionAuthType Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GatewayConnectionAuthType : System.IEquatable<Azure.ContainerApps.Sandbox.GatewayConnectionAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GatewayConnectionAuthType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.GatewayConnectionAuthType SystemAssignedManagedIdentity { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.GatewayConnectionAuthType UserAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType left, Azure.ContainerApps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.GatewayConnectionAuthType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.GatewayConnectionAuthType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType left, Azure.ContainerApps.Sandbox.GatewayConnectionAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateConsentLinkContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>
    {
        public GenerateConsentLinkContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.GenerateConsentLinkContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.GenerateConsentLinkContent generateConsentLinkContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.GenerateConsentLinkContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.GenerateConsentLinkContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateConsentLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>
    {
        internal GenerateConsentLinkResult() { }
        public string ConsentLink { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.GenerateConsentLinkResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.GenerateConsentLinkResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.GenerateConsentLinkResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.GenerateConsentLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HttpEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.HttpEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.HttpEgressSection>
    {
        public HttpEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyAction defaultAction) { }
        public Azure.ContainerApps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressForwardProxy DefaultForward { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.ContainerApps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.HttpEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.HttpEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.HttpEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.HttpEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.HttpEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.HttpEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.HttpEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.HttpEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IdentitySetting : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IdentitySetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IdentitySetting>
    {
        public IdentitySetting(string identity) { }
        public string Identity { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.IdentitySettingLifecycle? Lifecycle { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.IdentitySetting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.IdentitySetting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.IdentitySetting System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IdentitySetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IdentitySetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.IdentitySetting System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IdentitySetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IdentitySetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IdentitySetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentitySettingLifecycle : System.IEquatable<Azure.ContainerApps.Sandbox.IdentitySettingLifecycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentitySettingLifecycle(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.IdentitySettingLifecycle All { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.IdentitySettingLifecycle Main { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.IdentitySettingLifecycle None { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.IdentitySettingLifecycle other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.IdentitySettingLifecycle left, Azure.ContainerApps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.IdentitySettingLifecycle (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.IdentitySettingLifecycle? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.IdentitySettingLifecycle left, Azure.ContainerApps.Sandbox.IdentitySettingLifecycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControl : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControl>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControl>
    {
        public IPAccessControl(Azure.ContainerApps.Sandbox.IPAccessControlAction defaultAction) { }
        public Azure.ContainerApps.Sandbox.IPAccessControlAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.IPAccessControlRule> Rules { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.IPAccessControl JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.IPAccessControl PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.IPAccessControl System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControl>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControl>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.IPAccessControl System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControl>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControl>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControl>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IPAccessControlAction : System.IEquatable<Azure.ContainerApps.Sandbox.IPAccessControlAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IPAccessControlAction(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.IPAccessControlAction Allow { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.IPAccessControlAction Deny { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.IPAccessControlAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.IPAccessControlAction left, Azure.ContainerApps.Sandbox.IPAccessControlAction right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.IPAccessControlAction (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.IPAccessControlAction? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.IPAccessControlAction left, Azure.ContainerApps.Sandbox.IPAccessControlAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPAccessControlRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>
    {
        public IPAccessControlRule(string name, Azure.ContainerApps.Sandbox.IPAccessControlAction action, int priority, System.Collections.Generic.IEnumerable<string> sourceCidrs) { }
        public Azure.ContainerApps.Sandbox.IPAccessControlAction Action { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourceCidrs { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.IPAccessControlRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.IPAccessControlRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.IPAccessControlRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.IPAccessControlRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinuxCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>
    {
        public LinuxCapabilities() { }
        public System.Collections.Generic.IList<string> Add { get { throw null; } }
        public System.Collections.Generic.IList<string> Drop { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.LinuxCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.LinuxCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.LinuxCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LinuxCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalPodVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LocalPodVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LocalPodVolume>
    {
        public LocalPodVolume(string size, string name) { }
        public Azure.ContainerApps.Sandbox.LocalPodVolumeKind? Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.LocalPodVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.LocalPodVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LocalPodVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LocalPodVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.LocalPodVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LocalPodVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LocalPodVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LocalPodVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalPodVolumeKind : System.IEquatable<Azure.ContainerApps.Sandbox.LocalPodVolumeKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalPodVolumeKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.LocalPodVolumeKind Local { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.LocalPodVolumeKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.LocalPodVolumeKind left, Azure.ContainerApps.Sandbox.LocalPodVolumeKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LocalPodVolumeKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LocalPodVolumeKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.LocalPodVolumeKind left, Azure.ContainerApps.Sandbox.LocalPodVolumeKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsLegacyTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>
    {
        public LogAnalyticsLegacyTelemetryEndpoint(string workspaceId, string tableName, System.BinaryData auth, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data) { }
        public System.BinaryData Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public string TableName { get { throw null; } }
        public string WorkspaceId { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAnalyticsLegacyTelemetryEndpointKind : System.IEquatable<Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAnalyticsLegacyTelemetryEndpointKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind LogAnalyticsLegacy { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogAnalyticsTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>
    {
        public LogAnalyticsTelemetryEndpoint(System.Uri dceEndpoint, string dcrImmutableId, string tableName, System.BinaryData auth, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data) { }
        public System.BinaryData Auth { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public System.Uri DceEndpoint { get { throw null; } }
        public string DcrImmutableId { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public string TableName { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogAnalyticsTelemetryEndpointKind : System.IEquatable<Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogAnalyticsTelemetryEndpointKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind LogAnalytics { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogColumnRef : System.IEquatable<Azure.ContainerApps.Sandbox.LogColumnRef>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogColumnRef(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.LogColumnRef ContainerName { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.LogColumnRef LogContent { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.LogColumnRef LogStream { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.LogColumnRef Region { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.LogColumnRef SandboxId { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.LogColumnRef other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.LogColumnRef left, Azure.ContainerApps.Sandbox.LogColumnRef right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogColumnRef (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.LogColumnRef? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.LogColumnRef left, Azure.ContainerApps.Sandbox.LogColumnRef right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedIdentityAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>
    {
        public ManagedIdentityAuthentication(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType type) { }
        public string IdentityResourceId { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityAuthenticationType : System.IEquatable<Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityAuthenticationType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType SystemAssigned { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType left, Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType left, Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class McpPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.McpPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.McpPolicyRule>
    {
        public McpPolicyRule(string hookId, System.Collections.Generic.IEnumerable<string> patterns) { }
        public string HookId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Patterns { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.McpPolicyRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.McpPolicyRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.McpPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.McpPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.McpPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.McpPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.McpPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.McpPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStats : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MemoryStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MemoryStats>
    {
        internal MemoryStats() { }
        public int? AvailableBytes { get { throw null; } }
        public int? TotalBytes { get { throw null; } }
        public int? UsedBytes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.MemoryStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.MemoryStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.MemoryStats System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MemoryStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MemoryStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.MemoryStats System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MemoryStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MemoryStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MemoryStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MkDirContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MkDirContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MkDirContent>
    {
        public MkDirContent(string path) { }
        public bool? CreateParents { get { throw null; } set { } }
        public int? Mode { get { throw null; } set { } }
        public string Path { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.MkDirContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.MkDirContent mkDirContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.MkDirContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.MkDirContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MkDirContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.MkDirContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.MkDirContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MkDirContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MkDirContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.MkDirContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>
    {
        public NamedEgressPolicy(string name, Azure.ContainerApps.Sandbox.EgressPolicyAction defaultAction) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ContainerApps.Sandbox.EgressPolicyAction DefaultAction { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.NamedEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.NamedEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.NamedEgressPolicy namedEgressPolicy) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.NamedEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.NamedEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NamedEgressPolicyListResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>
    {
        internal NamedEgressPolicyListResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.NamedEgressPolicy> EgressPolicies { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkEgressDecisions : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>
    {
        internal NetworkEgressDecisions() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressDecisionEntry> Allowed { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressDecisionEntry> Denied { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.NetworkEgressDecisions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.NetworkEgressDecisions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.NetworkEgressDecisions System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkEgressDecisions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkStats : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkStats>
    {
        internal NetworkStats() { }
        public int? RxBytes { get { throw null; } }
        public int? RxPackets { get { throw null; } }
        public int? TxBytes { get { throw null; } }
        public int? TxPackets { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.NetworkStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.NetworkStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.NetworkStats System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.NetworkStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.NetworkStats System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.NetworkStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Uri endpoint, Azure.ContainerApps.Sandbox.TelemetryProtocol protocol, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data) { }
        public Azure.ContainerApps.Sandbox.TelemetryHeaderAuth Auth { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Columns { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TelemetryData> Data { get { throw null; } }
        public bool? DynamicJsonColumns { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? Kind { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TelemetryProtocol Protocol { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OtlpTelemetryEndpointKind : System.IEquatable<Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OtlpTelemetryEndpointKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind OTLP { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind left, Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PodContentPackage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodContentPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodContentPackage>
    {
        public PodContentPackage(string contentPackageId) { }
        public string ContentPackageId { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.PodContentPackage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PodContentPackage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PodContentPackage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodContentPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodContentPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PodContentPackage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodContentPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodContentPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodContentPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PodSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodSecurityContext>
    {
        public PodSecurityContext() { }
        public int? FsGroup { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.FsGroupChangePolicy? FsGroupChangePolicy { get { throw null; } set { } }
        public int? RunAsGroup { get { throw null; } set { } }
        public bool? RunAsNonRoot { get { throw null; } set { } }
        public int? RunAsUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> SupplementalGroups { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.PodSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PodSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PodSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PodSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PodSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortActivationMode : System.IEquatable<Azure.ContainerApps.Sandbox.PortActivationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortActivationMode(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortActivationMode Manual { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.PortActivationMode OnDemand { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.PortActivationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.PortActivationMode left, Azure.ContainerApps.Sandbox.PortActivationMode right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PortActivationMode (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PortActivationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.PortActivationMode left, Azure.ContainerApps.Sandbox.PortActivationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfig>
    {
        public PortAuthConfig() { }
        public bool? Anonymous { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortAuthConfigEntraId EntraId { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortAuthConfigGithub Github { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PortAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigEntraId : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>
    {
        public PortAuthConfigEntraId() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ObjectIds { get { throw null; } }
        public System.Collections.Generic.IList<string> TenantIds { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfigEntraId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfigEntraId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PortAuthConfigEntraId System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigEntraId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortAuthConfigGithub : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>
    {
        public PortAuthConfigGithub() { }
        public System.Collections.Generic.IList<string> Emails { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailSuffixes { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Usernames { get { throw null; } }
        public System.Collections.Generic.IList<string> UsernameSuffixes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfigGithub JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PortAuthConfigGithub PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PortAuthConfigGithub System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortAuthConfigGithub>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PortCorsConfig : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortCorsConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortCorsConfig>
    {
        public PortCorsConfig() { }
        public bool? AllowCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AllowHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowOrigins { get { throw null; } }
        public int? MaxAge { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.PortCorsConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.PortCorsConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortCorsConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortCorsConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PortCorsConfig System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortCorsConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortCorsConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortCorsConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PortProtocol : System.IEquatable<Azure.ContainerApps.Sandbox.PortProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PortProtocol(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortProtocol Http { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.PortProtocol Http2 { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.PortProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.PortProtocol left, Azure.ContainerApps.Sandbox.PortProtocol right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PortProtocol (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PortProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.PortProtocol left, Azure.ContainerApps.Sandbox.PortProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PortsListResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortsListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortsListResult>
    {
        internal PortsListResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxPort> Ports { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.PortsListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.PortsListResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.PortsListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PortsListResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortsListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PortsListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PortsListResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortsListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortsListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PortsListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PresetSandboxType : System.IEquatable<Azure.ContainerApps.Sandbox.PresetSandboxType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PresetSandboxType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.PresetSandboxType Claude { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.PresetSandboxType GitHubCopilot { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.PresetSandboxType None { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.PresetSandboxType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.PresetSandboxType left, Azure.ContainerApps.Sandbox.PresetSandboxType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PresetSandboxType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.PresetSandboxType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.PresetSandboxType left, Azure.ContainerApps.Sandbox.PresetSandboxType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProbeExecAction : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeExecAction>
    {
        public ProbeExecAction(System.Collections.Generic.IEnumerable<string> command) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ProbeExecAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ProbeExecAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ProbeExecAction System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpGetAction : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>
    {
        public ProbeHttpGetAction(int port) { }
        public string Host { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ProbeHttpHeader> HttpHeaders { get { throw null; } }
        public string Path { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public string Scheme { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ProbeHttpGetAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ProbeHttpGetAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ProbeHttpGetAction System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpGetAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeHttpHeader : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>
    {
        public ProbeHttpHeader(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ProbeHttpHeader JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ProbeHttpHeader PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ProbeHttpHeader System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeHttpHeader>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProbeTcpSocketAction : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>
    {
        public ProbeTcpSocketAction(int port) { }
        public string Host { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ProbeTcpSocketAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ProbeTcpSocketAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ProbeTcpSocketAction System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ProbeTcpSocketAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PublicDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PublicDiskImage>
    {
        internal PublicDiskImage() { }
        public string Name { get { throw null; } }
        public Azure.ContainerApps.Sandbox.DiskImageStatus Status { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.PublicDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.PublicDiskImage (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.PublicDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PublicDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.PublicDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.PublicDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PublicDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PublicDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.PublicDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RefLogColumnDef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>
    {
        public RefLogColumnDef(Azure.ContainerApps.Sandbox.LogColumnRef refName) { }
        public Azure.ContainerApps.Sandbox.RefLogColumnDefKind? Kind { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.LogColumnRef RefName { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.RefLogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.RefLogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.RefLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RefLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RefLogColumnDefKind : System.IEquatable<Azure.ContainerApps.Sandbox.RefLogColumnDefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RefLogColumnDefKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.RefLogColumnDefKind Ref { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.RefLogColumnDefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.RefLogColumnDefKind left, Azure.ContainerApps.Sandbox.RefLogColumnDefKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.RefLogColumnDefKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.RefLogColumnDefKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.RefLogColumnDefKind left, Azure.ContainerApps.Sandbox.RefLogColumnDefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegistryAuthentication : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>
    {
        public RegistryAuthentication() { }
        public Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication Identity { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.RegistryCredentials RegistryCredentials { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.RegistryAuthentication JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.RegistryAuthentication PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.RegistryAuthentication System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryAuthentication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegistryCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryCredentials>
    {
        public RegistryCredentials(string username, string token) { }
        public string Token { get { throw null; } }
        public string Username { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.RegistryCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.RegistryCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RegistryCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.RegistryCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RegistryCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemovePortContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RemovePortContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RemovePortContent>
    {
        public RemovePortContent() { }
        public string Name { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.RemovePortContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.RemovePortContent removePortContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.RemovePortContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.RemovePortContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RemovePortContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.RemovePortContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.RemovePortContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RemovePortContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RemovePortContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.RemovePortContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAgentIdentityRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>
    {
        public SandboxAgentIdentityRef(string tenantId, string agentId) { }
        public string AgentId { get { throw null; } set { } }
        public string TenantId { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoDeletePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>
    {
        public SandboxAutoDeletePolicy(bool enabled) { }
        public int? DeleteIntervalInDays { get { throw null; } set { } }
        public long? DeleteIntervalInSeconds { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.AutoDeleteTrigger? Trigger { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxAutoSuspendPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>
    {
        public SandboxAutoSuspendPolicy(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxSuspendMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxConnection : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxConnection>
    {
        internal SandboxConnection() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? Deletable { get { throw null; } }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        public string State { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> UsedBySandboxIds { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxConnection (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxConnection System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxConnection System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxContentPackageDownload : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>
    {
        public SandboxContentPackageDownload(string contentPackageId, string targetPath) { }
        public Azure.ContainerApps.Sandbox.ContentPackageAction? Action { get { throw null; } set { } }
        public string ContentPackageId { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxContentPackageDownload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxContentPackageDownload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxContentPackageDownload System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxEgressPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>
    {
        public SandboxEgressPolicy() { }
        public Azure.ContainerApps.Sandbox.EgressPolicyAction? DefaultAction { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? EnforcementMode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressHostRule> HostRules { get { throw null; } }
        public Azure.ContainerApps.Sandbox.HttpEgressSection Http { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.EgressPolicyRule> Rules { get { throw null; } }
        public Azure.ContainerApps.Sandbox.TdsEgressSection Tds { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TrafficInspection? TrafficInspection { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TransportEgressSection TransportRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ValidationWarning> ValidationWarnings { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxEgressPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxEgressPolicy (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.SandboxEgressPolicy sandboxEgressPolicy) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxEgressPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxEgressPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>
    {
        internal SandboxExecuteCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxExecuteShellCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>
    {
        internal SandboxExecuteShellCommandResult() { }
        public long ExecutionTimeMs { get { throw null; } }
        public int ExitCode { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxFiles
    {
        protected SandboxFiles() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteSandboxFile(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.FileOpStatusResult> DeleteSandboxFile(string path = null, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteSandboxFileAsync(string path, bool? recursive, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.FileOpStatusResult>> DeleteSandboxFileAsync(string path = null, bool? recursive = default(bool?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFile(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.FileStreamResult> GetSandboxFile(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.FileStreamResult>> GetSandboxFileAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFilesList(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.DirListingResult> GetSandboxFilesList(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFilesListAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.DirListingResult>> GetSandboxFilesListAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxFileStat(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.FileInfo> GetSandboxFileStat(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxFileStatAsync(string path, string containerName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.FileInfo>> GetSandboxFileStatAsync(string path, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxFile(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.WriteFileResult> PostSandboxFile(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxFileAsync(string path, Azure.Core.RequestContent content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.WriteFileResult>> PostSandboxFileAsync(string path, System.BinaryData content, bool? createDirs = default(bool?), int? mode = default(int?), string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.FileOpStatusResult> PostSandboxFileMkdir(Azure.ContainerApps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxFileMkdir(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.FileOpStatusResult>> PostSandboxFileMkdirAsync(Azure.ContainerApps.Sandbox.MkDirContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxFileMkdirAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroup
    {
        protected SandboxGroup() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> CreateSandbox(Azure.ContainerApps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSandbox(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> CreateSandboxAsync(Azure.ContainerApps.Sandbox.CreateSandboxContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSandboxAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSandboxes(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> GetSandboxes(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>>> GetSandboxesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxesCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<int> GetSandboxesCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxesCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<int>> GetSandboxesCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupConnections GetSandboxGroupConnectionsClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupContentPackages GetSandboxGroupContentPackagesClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupCredentials GetSandboxGroupCredentialsClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupDiskImages GetSandboxGroupDiskImagesClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupEgressPolicies GetSandboxGroupEgressPoliciesClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupSandbox GetSandboxGroupSandboxClient(string id) { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupSecrets GetSandboxGroupSecretsClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupSnapshots GetSandboxGroupSnapshotsClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupVolumes GetSandboxGroupVolumesClient() { throw null; }
    }
    public partial class SandboxGroupConnections
    {
        protected SandboxGroupConnections() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteConnection(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteConnection(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteConnectionAsync(string id, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnection(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection> GetConnection(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection>> GetConnectionAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnections(bool? includeSandboxIds, int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxConnection>> GetConnections(bool? includeSandboxIds = default(bool?), int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionsAsync(bool? includeSandboxIds, int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxConnection>>> GetConnectionsAsync(bool? includeSandboxIds = default(bool?), int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection> PostConnection(Azure.ContainerApps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostConnection(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection>> PostConnectionAsync(Azure.ContainerApps.Sandbox.CreateConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostConnectionAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection> PostConnectionAuthorize(string id, Azure.ContainerApps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostConnectionAuthorize(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection>> PostConnectionAuthorizeAsync(string id, Azure.ContainerApps.Sandbox.AuthorizeConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostConnectionAuthorizeAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult> PostConnectionConsentLink(string id, Azure.ContainerApps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostConnectionConsentLink(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.GenerateConsentLinkResult>> PostConnectionConsentLinkAsync(string id, Azure.ContainerApps.Sandbox.GenerateConsentLinkContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostConnectionConsentLinkAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response PostConnectionRefresh(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection> PostConnectionRefresh(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostConnectionRefreshAsync(string id, bool? includeSandboxIds, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection>> PostConnectionRefreshAsync(string id, bool? includeSandboxIds = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection> PutConnectionPolicyRules(string id, Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutConnectionPolicyRules(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxConnection>> PutConnectionPolicyRulesAsync(string id, Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutConnectionPolicyRulesAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContentPackage> GetContentPackage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContentPackage>> GetContentPackageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetContentPackages(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContentPackageListResult> GetContentPackages(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetContentPackagesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContentPackageListResult>> GetContentPackagesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostContentPackageUpload(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContentPackage> PostContentPackageUpload(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostContentPackageUploadAsync(Azure.Core.RequestContent content, string contentType = null, string labels = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContentPackage>> PostContentPackageUploadAsync(System.BinaryData content, string contentType = null, string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupCredential : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>
    {
        internal SandboxGroupCredential() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Origin { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider Provider { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource Source { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ConnectionState State { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredential (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupCredential System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupCredentialConnectionRefDetails : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>
    {
        public SandboxGroupCredentialConnectionRefDetails(Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord authentication, string tokenExchangeEndpoint) { }
        public Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord Authentication { get { throw null; } set { } }
        public string TokenExchangeEndpoint { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialOrigin : System.IEquatable<Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialOrigin(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Connections { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin Credentials { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialProvider : System.IEquatable<Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialProvider(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider Claude { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider GitHubCopilot { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider right) { throw null; }
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
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupCredential> GetCredential(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialAsync(string credentialName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupCredential>> GetCredentialAsync(string credentialName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetCredentials(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxGroupCredential>> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCredentialsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxGroupCredential>>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupCredential> PutCredential(string credentialName, Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutCredential(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupCredential>> PutCredentialAsync(string credentialName, Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutCredentialAsync(string credentialName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxGroupCredentialSource : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>
    {
        public SandboxGroupCredentialSource(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind kind) { }
        public string ConnectionId { get { throw null; } set { } }
        public string ConnectionName { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails ConnectionRefDetails { get { throw null; } set { } }
        public string ConnectionResourceId { get { throw null; } set { } }
        public string ConnectionType { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind Kind { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ParameterValues { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxGroupCredentialSourceKind : System.IEquatable<Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxGroupCredentialSourceKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind ExistingAdcConnection { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind GatewayConnectionRef { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind Pat { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind SecretRef { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind left, Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxGroupDiskImages
    {
        protected SandboxGroupDiskImages() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImage(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.DiskImage> GetDiskImage(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImageAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.DiskImage>> GetDiskImageAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImagePublic(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.PublicDiskImage> GetDiskImagePublic(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImagePublicAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.PublicDiskImage>> GetDiskImagePublicAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImages(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.DiskImage>> GetDiskImages(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImagesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.DiskImage>>> GetDiskImagesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiskImagesPublic(int? page, int? pageSize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.PublicDiskImage>> GetDiskImagesPublic(int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiskImagesPublicAsync(int? page, int? pageSize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.PublicDiskImage>>> GetDiskImagesPublicAsync(int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.DiskImage> PostDiskImage(Azure.ContainerApps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostDiskImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.DiskImage>> PostDiskImageAsync(Azure.ContainerApps.Sandbox.CreateDiskImageContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostDiskImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult> GetEgressPolicies(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPoliciesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult>> GetEgressPoliciesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetEgressPolicy(string policyId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicy> GetEgressPolicy(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEgressPolicyAsync(string policyId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicy>> GetEgressPolicyAsync(string policyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicy> PutEgressPolicy(string policyId, Azure.ContainerApps.Sandbox.NamedEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutEgressPolicy(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.NamedEgressPolicy>> PutEgressPolicyAsync(string policyId, Azure.ContainerApps.Sandbox.NamedEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutEgressPolicyAsync(string policyId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public abstract partial class SandboxGroupIdentitySelector : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>
    {
        internal SandboxGroupIdentitySelector() { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorSystemAssignedIdentitySelector : Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupIdentitySelectorUserAssignedIdentitySelector : Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector, System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>
    {
        public SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId) { }
        public string ResourceId { get { throw null; } set { } }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupSandbox
    {
        protected SandboxGroupSandbox() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response AddPodVolumeMounts(Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddPodVolumeMounts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddPodVolumeMountsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.ContainerApps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddVolumeMount(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.ContainerApps.Sandbox.AddVolumeMountContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddVolumeMountAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.CommitSandboxResult> Commit(Azure.ContainerApps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Commit(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.CommitSandboxResult>> CommitAsync(Azure.ContainerApps.Sandbox.CommitSandboxContent body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CommitAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot> CreateSnapshot(Azure.ContainerApps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateSnapshot(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot>> CreateSnapshotAsync(Azure.ContainerApps.Sandbox.CreateSnapshotContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateSnapshotAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DownloadContentPackage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DownloadContentPackageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Enable(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult> ExecuteCommand(Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult>> ExecuteCommandAsync(Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult> ExecuteShellCommand(Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ExecuteShellCommand(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult>> ExecuteShellCommandAsync(Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent body, string containerName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExecuteShellCommandAsync(Azure.Core.RequestContent content, string containerName = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProperties(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> GetProperties(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPropertiesAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> GetPropertiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxFiles GetSandboxFilesClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupSandboxNetworking GetSandboxGroupSandboxNetworkingClient() { throw null; }
        public virtual Azure.ContainerApps.Sandbox.SandboxGroupSandboxStreams GetSandboxGroupSandboxStreamsClient() { throw null; }
        public virtual Azure.Response GetStats(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxStatsResult> GetStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetStatsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxStatsResult>> GetStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resume(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> Resume(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResumeAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> ResumeAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox> SetLifecyclePolicy(Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetLifecyclePolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ContainerAppsSandbox>> SetLifecyclePolicyAsync(Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetLifecyclePolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Stop(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot> Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot>> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SandboxGroupSandboxNetworking
    {
        protected SandboxGroupSandboxNetworking() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetSandboxEgressDecisions2(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.EgressDecisionsResult> GetSandboxEgressDecisions2(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxEgressDecisions2Async(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.EgressDecisionsResult>> GetSandboxEgressDecisions2Async(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSandboxPorts(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult> GetSandboxPorts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSandboxPortsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult>> GetSandboxPortsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PatchSandboxPort(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PatchSandboxPortAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.ConnectionsListResult> PostSandboxConnectionAdd(Azure.ContainerApps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxConnectionAdd(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.ConnectionsListResult>> PostSandboxConnectionAddAsync(Azure.ContainerApps.Sandbox.AddConnectionContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxConnectionAddAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxEgressPolicy> PostSandboxEgressPolicy(Azure.ContainerApps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxEgressPolicy(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxEgressPolicy>> PostSandboxEgressPolicyAsync(Azure.ContainerApps.Sandbox.SandboxEgressPolicy body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxEgressPolicyAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult> PostSandboxPortAdd(Azure.ContainerApps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxPortAdd(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult>> PostSandboxPortAddAsync(Azure.ContainerApps.Sandbox.CreateSandboxPortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxPortAddAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult> PostSandboxPortRemove(Azure.ContainerApps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSandboxPortRemove(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult>> PostSandboxPortRemoveAsync(Azure.ContainerApps.Sandbox.RemovePortContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSandboxPortRemoveAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult> PutSandboxPorts(Azure.ContainerApps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutSandboxPorts(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.PortsListResult>> PutSandboxPortsAsync(Azure.ContainerApps.Sandbox.UpdatePortsContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutSandboxPortsAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SecretKeysResult> GetSecretKeys(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretKeysAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SecretKeysResult>> GetSecretKeysAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSecrets(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SecretListResult> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSecretsAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SecretListResult>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostSecretPeek(string secretId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SecretPeekResult> PostSecretPeek(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostSecretPeekAsync(string secretId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SecretPeekResult>> PostSecretPeekAsync(string secretId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxSecret> PutSecret(string secretId, Azure.ContainerApps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutSecret(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxSecret>> PutSecretAsync(string secretId, Azure.ContainerApps.Sandbox.CreateSecretContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutSecretAsync(string secretId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
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
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot> GetSnapshot(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxSnapshot>> GetSnapshotAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshots(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxSnapshot>> GetSnapshots(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotsAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxSnapshot>>> GetSnapshotsAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSnapshotsCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<int> GetSnapshotsCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetSnapshotsCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<int>> GetSnapshotsCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public abstract partial class SandboxGroupVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>
    {
        internal SandboxGroupVolume() { }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ContainerApps.Sandbox.VolumeProvisioningState ProvisioningState { get { throw null; } }
        public string VolumeName { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxGroupVolume (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.SandboxGroupVolume sandboxGroupVolume) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxGroupVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxGroupVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxGroupVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxGroupVolumes
    {
        protected SandboxGroupVolumes() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response DeleteVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteVolumeFile(string volumeName, string path = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path, bool? recursive, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVolumeFileAsync(string volumeName, string path = null, bool? recursive = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolume(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume> GetVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeAsync(string volumeName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume>> GetVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFileDownload(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.FileStreamResult> GetVolumeFileDownload(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFileDownloadAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.FileStreamResult>> GetVolumeFileDownloadAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumeFiles(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult> GetVolumeFiles(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumeFilesAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>> GetVolumeFilesAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumes(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxGroupVolume>> GetVolumes(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumesAsync(int? page, int? pageSize, string labels, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SandboxGroupVolume>>> GetVolumesAsync(int? page = default(int?), int? pageSize = default(int?), string labels = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVolumesCount(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.VolumeCountResult> GetVolumesCount(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVolumesCountAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.VolumeCountResult>> GetVolumesCountAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostVolumeFile(string volumeName, Azure.Core.RequestContent content, string path = null, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.VolumePathItem> PostVolumeFile(string volumeName, System.BinaryData content, string path = null, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostVolumeFileAsync(string volumeName, Azure.Core.RequestContent content, string path = null, bool? overwrite = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.VolumePathItem>> PostVolumeFileAsync(string volumeName, System.BinaryData content, string path = null, bool? overwrite = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostVolumeFileMkdir(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.VolumePathItem> PostVolumeFileMkdir(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostVolumeFileMkdirAsync(string volumeName, string path, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.VolumePathItem>> PostVolumeFileMkdirAsync(string volumeName, string path = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume> PostVolumeFork(string volumeName, Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PostVolumeFork(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume>> PostVolumeForkAsync(string volumeName, Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PostVolumeForkAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume> PutVolume(string volumeName, Azure.ContainerApps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PutVolume(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ContainerApps.Sandbox.SandboxGroupVolume>> PutVolumeAsync(string volumeName, Azure.ContainerApps.Sandbox.SandboxGroupVolume body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PutVolumeAsync(string volumeName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class SandboxLifecyclePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>
    {
        public SandboxLifecyclePolicy(Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy, Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy) { }
        public Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy AutoDeletePolicy { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy AutoSuspendPolicy { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy sandboxLifecyclePolicy) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SandboxModelFactory
    {
        public static Azure.ContainerApps.Sandbox.AddConnectionContent AddConnectionContent(string connectionId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AddPodVolumeMountsContent AddPodVolumeMountsContent(System.Collections.Generic.IEnumerable<System.BinaryData> volumes = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerVolumeMounts> containerMounts = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AddVolumeMountContent AddVolumeMountContent(Azure.ContainerApps.Sandbox.SandboxVolume volumeMount = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpoint ApplicationInsightsTelemetryEndpoint(Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind? kind = default(Azure.ContainerApps.Sandbox.ApplicationInsightsTelemetryEndpointKind?), Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth auth = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.AuthorizeConnectionContent AuthorizeConnectionContent(System.Collections.Generic.IDictionary<string, string> parameterValues = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobByoPodVolume AzureBlobByoPodVolume(Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind? kind = default(Azure.ContainerApps.Sandbox.AzureBlobByoPodVolumeKind?), string fileCacheSizeLimit = null, bool? readOnly = default(bool?), string name = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobByoVolume AzureBlobByoVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState), string storageContainerResourceId = null, System.BinaryData auth = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth AzureBlobByoVolumeAuthAzureBlobByoIdentityAuth(Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector identity = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobPodVolume AzureBlobPodVolume(Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind? kind = default(Azure.ContainerApps.Sandbox.AzureBlobPodVolumeKind?), string fileCacheSizeLimit = null, bool? readOnly = default(bool?), string name = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureBlobVolume AzureBlobVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState), Azure.ContainerApps.Sandbox.BlobVolumeUsage usage = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureFileCifsVolume AzureFileCifsVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.ContainerApps.Sandbox.AzureFileNfsVolume AzureFileNfsVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.ContainerApps.Sandbox.BlobVolumeUsage BlobVolumeUsage(System.BinaryData usedBytes = null, long itemCount = (long)0, System.DateTimeOffset calculatedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ContainerApps.Sandbox.CommitSandboxContent CommitSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CommitSandboxResult CommitSandboxResult(Azure.ContainerApps.Sandbox.DiskImage diskImage = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ConnectionsListResult ConnectionsListResult(System.Collections.Generic.IEnumerable<string> connectionIds = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerAppsSandbox ContainerAppsSandbox(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> cmd = null, Azure.ContainerApps.Sandbox.SandboxSource sourcesRef = null, Azure.ContainerApps.Sandbox.SandboxResources resources = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ContainerApps.Sandbox.SandboxState? state = default(Azure.ContainerApps.Sandbox.SandboxState?), Azure.ContainerApps.Sandbox.SandboxStateDetails stateDetails = null, string snapshotId = null, string coldStorageSizeInMb = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxPort> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.GatewayConnection> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.ContainerApps.Sandbox.SandboxEgressPolicy egressPolicy = null, string sandboxGroupId = null, string region = null, Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy lifecycle = null, string appUri = null, string managementUri = null, Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.IdentitySetting> identitySettings = null, System.Collections.Generic.IEnumerable<string> outboundIPAddresses = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerStatus> containerStatuses = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerProbe ContainerProbe(Azure.ContainerApps.Sandbox.ProbeHttpGetAction httpGet = null, Azure.ContainerApps.Sandbox.ProbeExecAction exec = null, Azure.ContainerApps.Sandbox.ProbeTcpSocketAction tcpSocket = null, int? initialDelaySeconds = default(int?), int? periodSeconds = default(int?), int? timeoutSeconds = default(int?), int? failureThreshold = default(int?), int? successThreshold = default(int?), int? terminationGracePeriodSeconds = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerProbeStatus ContainerProbeStatus(Azure.ContainerApps.Sandbox.ContainerProbeResult? lastResult = default(Azure.ContainerApps.Sandbox.ContainerProbeResult?), int? consecutiveFailures = default(int?), int? consecutiveSuccesses = default(int?), System.DateTimeOffset? lastCheckedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastTransitionOn = default(System.DateTimeOffset?), string message = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerResources ContainerResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerSecurityContext ContainerSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), bool? privileged = default(bool?), Azure.ContainerApps.Sandbox.LinuxCapabilities capabilities = null, bool? allowPrivilegeEscalation = default(bool?), bool? readOnlyRootFilesystem = default(bool?), Azure.ContainerApps.Sandbox.SeccompProfile seccompProfile = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerSpec ContainerSpec(string name = null, Azure.ContainerApps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null, System.Collections.Generic.IEnumerable<string> command = null, System.Collections.Generic.IEnumerable<string> args = null, System.Collections.Generic.IDictionary<string, string> env = null, Azure.ContainerApps.Sandbox.ContainerResources resources = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, Azure.ContainerApps.Sandbox.ContainerSecurityContext securityContext = null, Azure.ContainerApps.Sandbox.ContainerProbe startupProbe = null, Azure.ContainerApps.Sandbox.ContainerProbe livenessProbe = null, Azure.ContainerApps.Sandbox.ContainerProbe readinessProbe = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerStatus ContainerStatus(string name = null, Azure.ContainerApps.Sandbox.ContainerRuntimeState state = default(Azure.ContainerApps.Sandbox.ContainerRuntimeState), bool ready = false, bool started = false, int restartCount = 0, Azure.ContainerApps.Sandbox.ContainerStatusReason? reason = default(Azure.ContainerApps.Sandbox.ContainerStatusReason?), string message = null, int? lastExitCode = default(int?), System.DateTimeOffset? lastStartedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastFinishedOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, Azure.ContainerApps.Sandbox.ContainerProbeStatus> probes = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerVolumeMount ContainerVolumeMount(string name = null, string mountPath = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContainerVolumeMounts ContainerVolumeMounts(string containerName = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerVolumeMount> volumeMounts = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContentPackage ContentPackage(string id = null, System.BinaryData size = null, System.Collections.Generic.IDictionary<string, string> labels = null, string contentType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ContentPackageListResult ContentPackageListResult(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContentPackage> value = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CpuStats CpuStats(int? user = default(int?), int? nice = default(int?), int? system = default(int?), int? idle = default(int?), int? iowait = default(int?), int? irq = default(int?), int? softirq = default(int?), int? steal = default(int?), double? loadAvg1 = default(double?), double? loadAvg5 = default(double?), double? loadAvg15 = default(double?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateConnectionContent CreateConnectionContent(string name = null, string type = null, System.Collections.Generic.IDictionary<string, string> labels = null, string parameterValueSetName = null, System.Collections.Generic.IDictionary<string, string> parameterValueSetValues = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateDiskImageContent CreateDiskImageContent(Azure.ContainerApps.Sandbox.CreateDiskImageSource source = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, string vnetConnectionName = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateDiskImageSource CreateDiskImageSource(string kind = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateDiskImageSourceBlobSource CreateDiskImageSourceBlobSource(string blobSourceUri = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateDiskImageSourceRegistrySource CreateDiskImageSourceRegistrySource(string imageReference = null, Azure.ContainerApps.Sandbox.RegistryAuthentication authentication = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSandboxContent CreateSandboxContent(System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> cmd = null, System.Collections.Generic.IDictionary<string, string> environment = null, Azure.ContainerApps.Sandbox.SandboxSource sourcesRef = null, Azure.ContainerApps.Sandbox.SandboxResources resources = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.CreateSandboxPortContent> ports = null, System.Collections.Generic.IEnumerable<string> connections = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent> gatewayConnections = null, System.Collections.Generic.IEnumerable<string> credentialRefs = null, Azure.ContainerApps.Sandbox.SandboxEgressPolicy egressPolicy = null, string egressPolicyId = null, string sandboxGroupId = null, Azure.ContainerApps.Sandbox.PresetSandboxType? presetSandboxType = default(Azure.ContainerApps.Sandbox.PresetSandboxType?), string anthropicApiKey = null, Azure.ContainerApps.Sandbox.SandboxPresetProperties presetProperties = null, Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy lifecycle = null, Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef agentIdentity = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxVolume> volumes = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxContentPackageDownload> contentPackageDownloads = null, string vnetConnectionName = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.IdentitySetting> identitySettings = null, Azure.ContainerApps.Sandbox.TelemetryConfig telemetryConfig = null, string projectId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSandboxGatewayConnectionContent CreateSandboxGatewayConnectionContent(string resourceId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSandboxGroupCredentialContent CreateSandboxGroupCredentialContent(string displayName = null, Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider), Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource source = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSandboxPortContent CreateSandboxPortContent(string name = null, int port = 0, Azure.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.ContainerApps.Sandbox.PortActivationMode?), Azure.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.ContainerApps.Sandbox.PortProtocol?), Azure.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSecretContent CreateSecretContent(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.CreateSnapshotContent CreateSnapshotContent(System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DataDiskPodVolume DataDiskPodVolume(Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind? kind = default(Azure.ContainerApps.Sandbox.DataDiskPodVolumeKind?), string name = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DataDiskVolume DataDiskVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState), string size = null, bool isAttached = false, string clusterId = null, string attachedSandboxId = null, Azure.ContainerApps.Sandbox.DataDiskVolumeUsage usage = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DataDiskVolumeUsage DataDiskVolumeUsage(System.BinaryData compressedBlobSizeBytes = null, System.BinaryData usedSizeBytes = null, System.DateTimeOffset lastUploadedAtUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ContainerApps.Sandbox.DirListingResult DirListingResult(string path = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.FileInfo> entries = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DiskImage DiskImage(string id = null, string name = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.DiskImageImage image = null, Azure.ContainerApps.Sandbox.DiskImageStatus status = null, string sizeInMb = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DiskImageImage DiskImageImage(string base = null, System.Collections.Generic.IEnumerable<string> entrypoint = null, System.Collections.Generic.IEnumerable<string> cmd = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DiskImageStatus DiskImageStatus(string state = null, string errorMessage = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ContainerApps.Sandbox.DiskStatsEntry DiskStatsEntry(string mountPoint = null, string filesystem = null, int? totalBytes = default(int?), int? usedBytes = default(int?), int? availableBytes = default(int?), string label = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.DownloadContentPackageToSandboxContent DownloadContentPackageToSandboxContent(string contentPackageId = null, string targetPath = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressDecisionEntry EgressDecisionEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string host = null, string method = null, string path = null, string scheme = null, string connectionId = null, string connectionName = null, string matchedRule = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressDecisionsResult EgressDecisionsResult(Azure.ContainerApps.Sandbox.NetworkEgressDecisions http = null, Azure.ContainerApps.Sandbox.StatefulTcpEgress statefulTcp = null, System.DateTimeOffset lastUpdated = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressForwardProxy EgressForwardProxy(string url = null, string ca = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressHostRule EgressHostRule(string pattern = null, Azure.ContainerApps.Sandbox.EgressPolicyAction? action = default(Azure.ContainerApps.Sandbox.EgressPolicyAction?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform EgressPolicyHeaderTransform(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation operation = default(Azure.ContainerApps.Sandbox.EgressPolicyHeaderOperation), string name = null, string value = null, Azure.ContainerApps.Sandbox.EgressPolicyValueRef valueRef = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyHookRef EgressPolicyHookRef(string endpoint = null, Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior? failBehavior = default(Azure.ContainerApps.Sandbox.EgressPolicyHookFailBehavior?), System.Collections.Generic.IEnumerable<string> requestHeaders = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform> authHeaders = null, int? timeoutMs = default(int?), Azure.ContainerApps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.ContainerApps.Sandbox.EgressRuleRoutingMode?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef EgressPolicyManagedIdentityRef(string resource = null, string format = null, Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType? type = default(Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityType?), string identityResourceId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyRule EgressPolicyRule(string name = null, Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch match = null, Azure.ContainerApps.Sandbox.EgressPolicyRuleAction action = null, System.Collections.Generic.IEnumerable<string> proxyActions = null, string source = null, Azure.ContainerApps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyRuleAction EgressPolicyRuleAction(Azure.ContainerApps.Sandbox.EgressPolicyActionType type = default(Azure.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressPolicyHeaderTransform> headers = null, string scheme = null, string host = null, string path = null, Azure.ContainerApps.Sandbox.EgressRuleRoutingMode? routingMode = default(Azure.ContainerApps.Sandbox.EgressRuleRoutingMode?), Azure.ContainerApps.Sandbox.EgressForwardMode? forward = default(Azure.ContainerApps.Sandbox.EgressForwardMode?), Azure.ContainerApps.Sandbox.EgressForwardProxy forwardProxy = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyRuleMatch EgressPolicyRuleMatch(string host = null, string path = null, System.Collections.Generic.IEnumerable<string> methods = null, Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme? scheme = default(Azure.ContainerApps.Sandbox.EgressPolicyMatchScheme?), bool? normalizePath = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicySecretRef EgressPolicySecretRef(string secretId = null, string secretKey = null, string format = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EgressPolicyValueRef EgressPolicyValueRef(Azure.ContainerApps.Sandbox.EgressPolicySecretRef secretRef = null, Azure.ContainerApps.Sandbox.EgressPolicyManagedIdentityRef managedIdentityRef = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.EntityTagHeaderValue EntityTagHeaderValue(Azure.ContainerApps.Sandbox.StringSegment tag = null, bool? isWeak = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.EsanVolume EsanVolume(string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState), string size = null, Azure.ContainerApps.Sandbox.EsanSku sku = default(Azure.ContainerApps.Sandbox.EsanSku)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ExecuteSandboxCommandContent ExecuteSandboxCommandContent(string command = null, System.Collections.Generic.IEnumerable<string> args = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.ContainerApps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ExecuteSandboxShellCommandContent ExecuteSandboxShellCommandContent(string command = null, string shell = null, System.Collections.Generic.IDictionary<string, string> environment = null, string workingDirectory = null, string user = null, Azure.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.ContainerApps.Sandbox.PortActivationMode?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.FileInfo FileInfo(string name = null, string path = null, long size = (long)0, int mode = 0, bool isDir = false, bool isSymlink = false, string symlinkTarget = null, long modifiedTime = (long)0) { throw null; }
        public static Azure.ContainerApps.Sandbox.FileOpStatusResult FileOpStatusResult(bool success = false, string error = null, string message = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.FileStreamResult FileStreamResult(System.BinaryData fileStream = null, string contentType = null, string fileDownloadName = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.ContainerApps.Sandbox.EntityTagHeaderValue entityTag = null, bool? enableRangeProcessing = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ForkDataDiskVolumeContent ForkDataDiskVolumeContent(string destinationVolumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.GatewayAuthentication GatewayAuthentication(Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.GatewayConnection GatewayConnection(string resourceId = null, string name = null, string mcpRuntimeUri = null, string connectionRuntimeUri = null, Azure.ContainerApps.Sandbox.GatewayAuthentication authentication = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord GatewayConnectionAuthRecord(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType type = default(Azure.ContainerApps.Sandbox.GatewayConnectionAuthType), string identityResourceId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.GenerateConsentLinkContent GenerateConsentLinkContent(string redirectUri = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.GenerateConsentLinkResult GenerateConsentLinkResult(string consentLink = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.HttpEgressSection HttpEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyAction defaultAction = default(Azure.ContainerApps.Sandbox.EgressPolicyAction), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressPolicyRule> rules = null, Azure.ContainerApps.Sandbox.TrafficInspection? trafficInspection = default(Azure.ContainerApps.Sandbox.TrafficInspection?), Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), Azure.ContainerApps.Sandbox.EgressForwardProxy defaultForward = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.IdentitySetting IdentitySetting(string identity = null, Azure.ContainerApps.Sandbox.IdentitySettingLifecycle? lifecycle = default(Azure.ContainerApps.Sandbox.IdentitySettingLifecycle?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.IPAccessControl IPAccessControl(Azure.ContainerApps.Sandbox.IPAccessControlAction defaultAction = default(Azure.ContainerApps.Sandbox.IPAccessControlAction), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.IPAccessControlRule> rules = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.IPAccessControlRule IPAccessControlRule(string name = null, Azure.ContainerApps.Sandbox.IPAccessControlAction action = default(Azure.ContainerApps.Sandbox.IPAccessControlAction), int priority = 0, System.Collections.Generic.IEnumerable<string> sourceCidrs = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.LinuxCapabilities LinuxCapabilities(System.Collections.Generic.IEnumerable<string> add = null, System.Collections.Generic.IEnumerable<string> drop = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.LocalPodVolume LocalPodVolume(Azure.ContainerApps.Sandbox.LocalPodVolumeKind? kind = default(Azure.ContainerApps.Sandbox.LocalPodVolumeKind?), string size = null, string name = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpoint LogAnalyticsLegacyTelemetryEndpoint(Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind? kind = default(Azure.ContainerApps.Sandbox.LogAnalyticsLegacyTelemetryEndpointKind?), string workspaceId = null, string tableName = null, System.BinaryData auth = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpoint LogAnalyticsTelemetryEndpoint(Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind? kind = default(Azure.ContainerApps.Sandbox.LogAnalyticsTelemetryEndpointKind?), System.Uri dceEndpoint = null, string dcrImmutableId = null, string tableName = null, System.BinaryData auth = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication ManagedIdentityAuthentication(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType type = default(Azure.ContainerApps.Sandbox.ManagedIdentityAuthenticationType), string identityResourceId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.McpPolicyRule McpPolicyRule(string hookId = null, System.Collections.Generic.IEnumerable<string> patterns = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.MemoryStats MemoryStats(int? totalBytes = default(int?), int? availableBytes = default(int?), int? usedBytes = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.MkDirContent MkDirContent(string path = null, bool? createParents = default(bool?), int? mode = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.NamedEgressPolicy NamedEgressPolicy(string id = null, string name = null, string description = null, Azure.ContainerApps.Sandbox.EgressPolicyAction defaultAction = default(Azure.ContainerApps.Sandbox.EgressPolicyAction), Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressPolicyRule> rules = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.NamedEgressPolicyListResult NamedEgressPolicyListResult(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.NamedEgressPolicy> egressPolicies = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.NetworkEgressDecisions NetworkEgressDecisions(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressDecisionEntry> allowed = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressDecisionEntry> denied = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.NetworkStats NetworkStats(int? rxBytes = default(int?), int? txBytes = default(int?), int? rxPackets = default(int?), int? txPackets = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.OtlpTelemetryEndpoint OtlpTelemetryEndpoint(Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind? kind = default(Azure.ContainerApps.Sandbox.OtlpTelemetryEndpointKind?), System.Uri endpoint = null, Azure.ContainerApps.Sandbox.TelemetryProtocol protocol = default(Azure.ContainerApps.Sandbox.TelemetryProtocol), Azure.ContainerApps.Sandbox.TelemetryHeaderAuth auth = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TelemetryData> data = null, System.Collections.Generic.IDictionary<string, System.BinaryData> columns = null, bool? dynamicJsonColumns = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.PodContentPackage PodContentPackage(string contentPackageId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.PodSecurityContext PodSecurityContext(int? runAsUser = default(int?), int? runAsGroup = default(int?), bool? runAsNonRoot = default(bool?), System.Collections.Generic.IEnumerable<int> supplementalGroups = null, int? fsGroup = default(int?), Azure.ContainerApps.Sandbox.FsGroupChangePolicy? fsGroupChangePolicy = default(Azure.ContainerApps.Sandbox.FsGroupChangePolicy?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortAuthConfig PortAuthConfig(bool? anonymous = default(bool?), Azure.ContainerApps.Sandbox.PortAuthConfigGithub github = null, Azure.ContainerApps.Sandbox.PortAuthConfigEntraId entraId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortAuthConfigEntraId PortAuthConfigEntraId(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> objectIds = null, System.Collections.Generic.IEnumerable<string> tenantIds = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortAuthConfigGithub PortAuthConfigGithub(bool? enabled = default(bool?), System.Collections.Generic.IEnumerable<string> emails = null, System.Collections.Generic.IEnumerable<string> emailSuffixes = null, System.Collections.Generic.IEnumerable<string> usernames = null, System.Collections.Generic.IEnumerable<string> usernameSuffixes = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortCorsConfig PortCorsConfig(System.Collections.Generic.IEnumerable<string> allowOrigins = null, System.Collections.Generic.IEnumerable<string> allowMethods = null, System.Collections.Generic.IEnumerable<string> allowHeaders = null, bool? allowCredentials = default(bool?), int? maxAge = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.PortsListResult PortsListResult(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxPort> ports = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ProbeExecAction ProbeExecAction(System.Collections.Generic.IEnumerable<string> command = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ProbeHttpGetAction ProbeHttpGetAction(int port = 0, string path = null, string host = null, string scheme = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ProbeHttpHeader> httpHeaders = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ProbeHttpHeader ProbeHttpHeader(string name = null, string value = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ProbeTcpSocketAction ProbeTcpSocketAction(int port = 0, string host = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.PublicDiskImage PublicDiskImage(string name = null, Azure.ContainerApps.Sandbox.DiskImageStatus status = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.RefLogColumnDef RefLogColumnDef(Azure.ContainerApps.Sandbox.RefLogColumnDefKind? kind = default(Azure.ContainerApps.Sandbox.RefLogColumnDefKind?), Azure.ContainerApps.Sandbox.LogColumnRef refName = default(Azure.ContainerApps.Sandbox.LogColumnRef)) { throw null; }
        public static Azure.ContainerApps.Sandbox.RegistryAuthentication RegistryAuthentication(Azure.ContainerApps.Sandbox.RegistryCredentials registryCredentials = null, Azure.ContainerApps.Sandbox.ManagedIdentityAuthentication identity = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.RegistryCredentials RegistryCredentials(string username = null, string token = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.RemovePortContent RemovePortContent(string name = null, int? port = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxAgentIdentityRef SandboxAgentIdentityRef(string tenantId = null, string agentId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy SandboxAutoDeletePolicy(bool enabled = false, int? deleteIntervalInDays = default(int?), long? deleteIntervalInSeconds = default(long?), Azure.ContainerApps.Sandbox.AutoDeleteTrigger? trigger = default(Azure.ContainerApps.Sandbox.AutoDeleteTrigger?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy SandboxAutoSuspendPolicy(bool enabled = false, int? interval = default(int?), Azure.ContainerApps.Sandbox.SandboxSuspendMode? mode = default(Azure.ContainerApps.Sandbox.SandboxSuspendMode?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxConnection SandboxConnection(string id = null, string name = null, string type = null, string state = null, System.Collections.Generic.IDictionary<string, string> labels = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? deletable = default(bool?), System.Collections.Generic.IEnumerable<string> usedBySandboxIds = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxContentPackageDownload SandboxContentPackageDownload(string contentPackageId = null, string targetPath = null, Azure.ContainerApps.Sandbox.ContentPackageAction? action = default(Azure.ContainerApps.Sandbox.ContentPackageAction?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxEgressPolicy SandboxEgressPolicy(Azure.ContainerApps.Sandbox.HttpEgressSection http = null, Azure.ContainerApps.Sandbox.EgressPolicyAction? defaultAction = default(Azure.ContainerApps.Sandbox.EgressPolicyAction?), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressHostRule> hostRules = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.EgressPolicyRule> rules = null, Azure.ContainerApps.Sandbox.TdsEgressSection tds = null, Azure.ContainerApps.Sandbox.TransportEgressSection transportRules = null, Azure.ContainerApps.Sandbox.TrafficInspection? trafficInspection = default(Azure.ContainerApps.Sandbox.TrafficInspection?), Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode? enforcementMode = default(Azure.ContainerApps.Sandbox.EgressPolicyEnforcementMode?), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ValidationWarning> validationWarnings = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxExecuteCommandResult SandboxExecuteCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxExecuteShellCommandResult SandboxExecuteShellCommandResult(int exitCode = 0, string stdout = null, string stderr = null, long executionTimeMs = (long)0) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredential SandboxGroupCredential(string name = null, string displayName = null, Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider provider = default(Azure.ContainerApps.Sandbox.SandboxGroupCredentialProvider), Azure.ContainerApps.Sandbox.ConnectionState state = default(Azure.ContainerApps.Sandbox.ConnectionState), Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource source = null, Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin origin = default(Azure.ContainerApps.Sandbox.SandboxGroupCredentialOrigin)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails SandboxGroupCredentialConnectionRefDetails(Azure.ContainerApps.Sandbox.GatewayConnectionAuthRecord authentication = null, string tokenExchangeEndpoint = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupCredentialSource SandboxGroupCredentialSource(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind kind = default(Azure.ContainerApps.Sandbox.SandboxGroupCredentialSourceKind), string connectionResourceId = null, Azure.ContainerApps.Sandbox.SandboxGroupCredentialConnectionRefDetails connectionRefDetails = null, System.Collections.Generic.IDictionary<string, string> parameterValues = null, string connectionId = null, string connectionType = null, string connectionName = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelector SandboxGroupIdentitySelector(string kind = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorSystemAssignedIdentitySelector SandboxGroupIdentitySelectorSystemAssignedIdentitySelector() { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupIdentitySelectorUserAssignedIdentitySelector SandboxGroupIdentitySelectorUserAssignedIdentitySelector(string resourceId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxGroupVolume SandboxGroupVolume(string type = null, string volumeName = null, System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ContainerApps.Sandbox.VolumeProvisioningState provisioningState = default(Azure.ContainerApps.Sandbox.VolumeProvisioningState)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxLifecyclePolicy SandboxLifecyclePolicy(Azure.ContainerApps.Sandbox.SandboxAutoSuspendPolicy autoSuspendPolicy = null, Azure.ContainerApps.Sandbox.SandboxAutoDeletePolicy autoDeletePolicy = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxPort SandboxPort(string name = null, int port = 0, System.Uri url = null, Azure.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.ContainerApps.Sandbox.PortActivationMode?), Azure.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.ContainerApps.Sandbox.PortProtocol?), Azure.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxPortUpdate SandboxPortUpdate(string name = null, int port = 0, System.Uri url = null, Azure.ContainerApps.Sandbox.PortAuthConfig auth = null, Azure.ContainerApps.Sandbox.PortActivationMode? activationMode = default(Azure.ContainerApps.Sandbox.PortActivationMode?), Azure.ContainerApps.Sandbox.PortProtocol? protocol = default(Azure.ContainerApps.Sandbox.PortProtocol?), Azure.ContainerApps.Sandbox.IPAccessControl ipAccessControl = null, Azure.ContainerApps.Sandbox.PortCorsConfig cors = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxPresetProperties SandboxPresetProperties(bool? isWorkIqConnectionEnabled = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxResources SandboxResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSecret SandboxSecret(string id = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? updatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSnapshot SandboxSnapshot(string id = null, System.Collections.Generic.IDictionary<string, string> labels = null, string sandboxId = null, System.DateTimeOffset createdAtUtc = default(System.DateTimeOffset), Azure.ContainerApps.Sandbox.SnapshotResources resources = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SnapshotPodContainer> sourcePodContainers = null, string sizeInMb = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSource SandboxSource(Azure.ContainerApps.Sandbox.SandboxSourceDiskImage diskImage = null, Azure.ContainerApps.Sandbox.SandboxSourceSnapshot snapshot = null, Azure.ContainerApps.Sandbox.SandboxSourcePod pod = null, Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion artifactVersion = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion SandboxSourceArtifactVersion(string id = null, Azure.ContainerApps.Sandbox.SandboxSourceAuth auth = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSourceAuth SandboxSourceAuth(string identity = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSourceDiskImage SandboxSourceDiskImage(string id = null, string name = null, bool? isPublic = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSourcePod SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerSpec> containers = null, System.Collections.Generic.IEnumerable<System.BinaryData> volumes = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.PodContentPackage> contentPackages = null, Azure.ContainerApps.Sandbox.PodSecurityContext securityContext = null, Azure.ContainerApps.Sandbox.ContainerRestartPolicy? restartPolicy = default(Azure.ContainerApps.Sandbox.ContainerRestartPolicy?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSourceSnapshot SandboxSourceSnapshot(string id = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxStateDetails SandboxStateDetails(Azure.ContainerApps.Sandbox.StoppedReason stoppedReason = default(Azure.ContainerApps.Sandbox.StoppedReason), System.DateTimeOffset stoppedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxStatsResult SandboxStatsResult(Azure.ContainerApps.Sandbox.TokenUsageStats tokenUsage = null, Azure.ContainerApps.Sandbox.CpuStats cpu = null, Azure.ContainerApps.Sandbox.MemoryStats memory = null, Azure.ContainerApps.Sandbox.NetworkStats network = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.DiskStatsEntry> disk = null, double? uptimeSecs = default(double?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxVolume SandboxVolume(string volumeName = null, string mountpoint = null, bool? readOnly = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SeccompProfile SeccompProfile(Azure.ContainerApps.Sandbox.SeccompProfileType type = default(Azure.ContainerApps.Sandbox.SeccompProfileType)) { throw null; }
        public static Azure.ContainerApps.Sandbox.SecretKeysResult SecretKeysResult(System.Collections.Generic.IEnumerable<string> keys = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SecretListResult SecretListResult(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxSecret> secrets = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SecretPeekResult SecretPeekResult(System.Collections.Generic.IDictionary<string, string> values = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SnapshotPodContainer SnapshotPodContainer(string name = null, string diskImageId = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.SnapshotResources SnapshotResources(string cpu = null, string memory = null, string disk = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.StatefulTcpEgress StatefulTcpEgress(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.StatefulTcpEntry> connections = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.StatefulTcpEntry StatefulTcpEntry(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string phase = null, string outcome = null, string connectorType = null, string server = null, int? port = default(int?), string database = null, string proxyLoginName = null, string sourceIP = null, string correlationId = null, long? bytesIn = default(long?), long? bytesOut = default(long?), long? durationMs = default(long?), string failureReason = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.StringSegment StringSegment(string buffer = null, int? offset = default(int?), int? length = default(int?), string value = null, bool? hasValue = default(bool?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsCredential TdsCredential(string name = null, Azure.ContainerApps.Sandbox.TdsAuthKind kind = default(Azure.ContainerApps.Sandbox.TdsAuthKind), string username = null, Azure.ContainerApps.Sandbox.EgressPolicySecretRef secretRef = null, string secret = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsEgressAction TdsEgressAction(Azure.ContainerApps.Sandbox.EgressPolicyActionType type = default(Azure.ContainerApps.Sandbox.EgressPolicyActionType), string credential = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsEgressMatch TdsEgressMatch(string host = null, System.Collections.Generic.IEnumerable<string> databases = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsEgressRule TdsEgressRule(string name = null, Azure.ContainerApps.Sandbox.TdsEgressMatch match = null, Azure.ContainerApps.Sandbox.TdsEgressAction action = null, Azure.ContainerApps.Sandbox.EgressPolicyHookRef hookRef = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsEgressSection TdsEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TdsCredential> credentials = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TdsEgressRule> rules = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth TelemetryApplicationInsightsAuth(string secretId = null, string secretKey = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryAppSecretRef TelemetryAppSecretRef(string secretRef = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryConfig TelemetryConfig(System.Collections.Generic.IEnumerable<System.BinaryData> endpoints = null, int? metricsIntervalSeconds = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryHeaderAuth TelemetryHeaderAuth(string headerName = null, string secretId = null, string secretKey = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth TelemetryManagedIdentityAuth(Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? kind = default(Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind?), string identity = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef TelemetrySandboxGroupSecretRef(Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? kind = default(Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind?), string secretId = null, string secretKey = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth TelemetrySystemAssignedManagedIdentityAuth(Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? kind = default(Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.TokenUsageStats TokenUsageStats(long? totalInputTokens = default(long?), long? totalOutputTokens = default(long?), int? requestCount = default(int?)) { throw null; }
        public static Azure.ContainerApps.Sandbox.TransportEgressRule TransportEgressRule(Azure.ContainerApps.Sandbox.EgressPolicyActionType action = default(Azure.ContainerApps.Sandbox.EgressPolicyActionType), Azure.ContainerApps.Sandbox.TransportProtocol protocol = default(Azure.ContainerApps.Sandbox.TransportProtocol), string destination = null, int port = 0) { throw null; }
        public static Azure.ContainerApps.Sandbox.TransportEgressSection TransportEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyActionType defaultAction = default(Azure.ContainerApps.Sandbox.EgressPolicyActionType), System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TransportEgressRule> rules = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.McpPolicyRule> policyRules = null, System.Collections.Generic.IEnumerable<string> enabledToolGroups = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.UpdatePortsContent UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxPortUpdate> ports = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ValidationWarning ValidationWarning(string code = null, string message = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.ValueLogColumnDef ValueLogColumnDef(Azure.ContainerApps.Sandbox.ValueLogColumnDefKind? kind = default(Azure.ContainerApps.Sandbox.ValueLogColumnDefKind?), string value = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumeCountResult VolumeCountResult(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.VolumeTypeCount> counts = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumeListDirectoryResult VolumeListDirectoryResult(string path = null, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.VolumePathItem> items = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumePathItem VolumePathItem(string itemName = null, string path = null, bool isDirectory = false, System.BinaryData sizeBytes = null, System.DateTimeOffset? lastModifiedUtc = default(System.DateTimeOffset?), string contentType = null, string eTag = null) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumeTypeCount VolumeTypeCount(Azure.ContainerApps.Sandbox.VolumeType type = default(Azure.ContainerApps.Sandbox.VolumeType), int count = 0) { throw null; }
        public static Azure.ContainerApps.Sandbox.WriteFileResult WriteFileResult(bool success = false, string error = null, long? bytesWritten = default(long?)) { throw null; }
    }
    public partial class SandboxPort : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPort>
    {
        internal SandboxPort() { }
        public Azure.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } }
        public Azure.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } }
        public Azure.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } }
        public Azure.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } }
        public string Name { get { throw null; } }
        public int Port { get { throw null; } }
        public Azure.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPort JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPort PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxPort System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxPort System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPortUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>
    {
        public SandboxPortUpdate(int port, System.Uri url) { }
        public Azure.ContainerApps.Sandbox.PortActivationMode? ActivationMode { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortAuthConfig Auth { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PortCorsConfig Cors { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.IPAccessControl IPAccessControl { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public int Port { get { throw null; } }
        public Azure.ContainerApps.Sandbox.PortProtocol? Protocol { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPortUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPortUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxPortUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPortUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxPresetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>
    {
        public SandboxPresetProperties() { }
        public bool? IsWorkIqConnectionEnabled { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPresetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxPresetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxPresetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxPresetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxResources : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxResources>
    {
        public SandboxResources(string cpu, string memory) { }
        public string Cpu { get { throw null; } set { } }
        public string Disk { get { throw null; } set { } }
        public string Memory { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxResources System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxResources System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSecret : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSecret>
    {
        internal SandboxSecret() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSecret JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxSecret (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSecret PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSecret System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSecret System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>
    {
        internal SandboxSnapshot() { }
        public System.DateTimeOffset CreatedAtUtc { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ContainerApps.Sandbox.SnapshotResources Resources { get { throw null; } }
        public string SandboxId { get { throw null; } }
        public string SizeInMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ContainerApps.Sandbox.SnapshotPodContainer> SourcePodContainers { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxSnapshot (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSource : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSource>
    {
        public SandboxSource() { }
        public Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion ArtifactVersion { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxSourceDiskImage DiskImage { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxSourcePod Pod { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.SandboxSourceSnapshot Snapshot { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSource System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSource System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceArtifactVersion : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>
    {
        public SandboxSourceArtifactVersion(string id, Azure.ContainerApps.Sandbox.SandboxSourceAuth auth) { }
        public Azure.ContainerApps.Sandbox.SandboxSourceAuth Auth { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceArtifactVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>
    {
        public SandboxSourceAuth(string identity) { }
        public string Identity { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSourceAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceDiskImage : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>
    {
        public SandboxSourceDiskImage() { }
        public string Id { get { throw null; } set { } }
        public bool? IsPublic { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceDiskImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceDiskImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSourceDiskImage System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceDiskImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourcePod : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>
    {
        public SandboxSourcePod(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.ContainerSpec> containers) { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.ContainerSpec> Containers { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.PodContentPackage> ContentPackages { get { throw null; } }
        public Azure.ContainerApps.Sandbox.ContainerRestartPolicy? RestartPolicy { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.PodSecurityContext SecurityContext { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Volumes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourcePod JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourcePod PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSourcePod System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourcePod>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxSourceSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>
    {
        public SandboxSourceSnapshot(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceSnapshot JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxSourceSnapshot PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxSourceSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxSourceSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxState : System.IEquatable<Azure.ContainerApps.Sandbox.SandboxState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxState(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxState Creating { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxState Idle { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxState Running { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxState StopFailed { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxState Stopped { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxState Stopping { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SandboxState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SandboxState left, Azure.ContainerApps.Sandbox.SandboxState right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxState (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxState? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SandboxState left, Azure.ContainerApps.Sandbox.SandboxState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>
    {
        internal SandboxStateDetails() { }
        public System.DateTimeOffset StoppedOn { get { throw null; } }
        public Azure.ContainerApps.Sandbox.StoppedReason StoppedReason { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxStateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxStateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SandboxStatsResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>
    {
        internal SandboxStatsResult() { }
        public Azure.ContainerApps.Sandbox.CpuStats Cpu { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.DiskStatsEntry> Disk { get { throw null; } }
        public Azure.ContainerApps.Sandbox.MemoryStats Memory { get { throw null; } }
        public Azure.ContainerApps.Sandbox.NetworkStats Network { get { throw null; } }
        public Azure.ContainerApps.Sandbox.TokenUsageStats TokenUsage { get { throw null; } }
        public double? UptimeSecs { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxStatsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SandboxStatsResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SandboxStatsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxStatsResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxStatsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SandboxSuspendMode : System.IEquatable<Azure.ContainerApps.Sandbox.SandboxSuspendMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SandboxSuspendMode(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SandboxSuspendMode Disk { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxSuspendMode Memory { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SandboxSuspendMode None { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SandboxSuspendMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SandboxSuspendMode left, Azure.ContainerApps.Sandbox.SandboxSuspendMode right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxSuspendMode (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SandboxSuspendMode? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SandboxSuspendMode left, Azure.ContainerApps.Sandbox.SandboxSuspendMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SandboxVolume : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxVolume>
    {
        public SandboxVolume(string volumeName, string mountpoint) { }
        public string Mountpoint { get { throw null; } set { } }
        public bool? ReadOnly { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SandboxVolume JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SandboxVolume PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SandboxVolume System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SandboxVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SandboxVolume System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SandboxVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SeccompProfile : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SeccompProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SeccompProfile>
    {
        public SeccompProfile(Azure.ContainerApps.Sandbox.SeccompProfileType type) { }
        public Azure.ContainerApps.Sandbox.SeccompProfileType Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.SeccompProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SeccompProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SeccompProfile System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SeccompProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SeccompProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SeccompProfile System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SeccompProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SeccompProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SeccompProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SeccompProfileType : System.IEquatable<Azure.ContainerApps.Sandbox.SeccompProfileType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SeccompProfileType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.SeccompProfileType RuntimeDefault { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.SeccompProfileType Unconfined { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.SeccompProfileType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.SeccompProfileType left, Azure.ContainerApps.Sandbox.SeccompProfileType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SeccompProfileType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.SeccompProfileType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.SeccompProfileType left, Azure.ContainerApps.Sandbox.SeccompProfileType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretKeysResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretKeysResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretKeysResult>
    {
        internal SecretKeysResult() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SecretKeysResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SecretKeysResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SecretKeysResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretKeysResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretKeysResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SecretKeysResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretKeysResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretKeysResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretKeysResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretListResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretListResult>
    {
        internal SecretListResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxSecret> Secrets { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SecretListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SecretListResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SecretListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SecretListResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SecretListResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SecretPeekResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretPeekResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretPeekResult>
    {
        internal SecretPeekResult() { }
        public System.Collections.Generic.IDictionary<string, string> Values { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SecretPeekResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.SecretPeekResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.SecretPeekResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretPeekResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SecretPeekResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SecretPeekResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretPeekResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretPeekResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SecretPeekResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPodContainer : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>
    {
        internal SnapshotPodContainer() { }
        public string DiskImageId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SnapshotPodContainer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SnapshotPodContainer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SnapshotPodContainer System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotPodContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResources : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotResources>
    {
        internal SnapshotResources() { }
        public string Cpu { get { throw null; } }
        public string Disk { get { throw null; } }
        public string Memory { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.SnapshotResources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.SnapshotResources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.SnapshotResources System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.SnapshotResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.SnapshotResources System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.SnapshotResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEgress : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>
    {
        internal StatefulTcpEgress() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.StatefulTcpEntry> Connections { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.StatefulTcpEgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.StatefulTcpEgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.StatefulTcpEgress System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StatefulTcpEntry : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>
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
        protected virtual Azure.ContainerApps.Sandbox.StatefulTcpEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.StatefulTcpEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.StatefulTcpEntry System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StatefulTcpEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoppedReason : System.IEquatable<Azure.ContainerApps.Sandbox.StoppedReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoppedReason(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.StoppedReason Disabled { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.StoppedReason Idle { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.StoppedReason UserStopped { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.StoppedReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.StoppedReason left, Azure.ContainerApps.Sandbox.StoppedReason right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.StoppedReason (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.StoppedReason? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.StoppedReason left, Azure.ContainerApps.Sandbox.StoppedReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StringSegment : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StringSegment>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StringSegment>
    {
        internal StringSegment() { }
        public string Buffer { get { throw null; } }
        public bool? HasValue { get { throw null; } }
        public int? Length { get { throw null; } }
        public int? Offset { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.StringSegment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.StringSegment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.StringSegment System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StringSegment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.StringSegment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.StringSegment System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StringSegment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StringSegment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.StringSegment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TdsAuthKind : System.IEquatable<Azure.ContainerApps.Sandbox.TdsAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TdsAuthKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TdsAuthKind EntraToken { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TdsAuthKind SqlPassword { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TdsAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TdsAuthKind left, Azure.ContainerApps.Sandbox.TdsAuthKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TdsAuthKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TdsAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TdsAuthKind left, Azure.ContainerApps.Sandbox.TdsAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TdsCredential : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsCredential>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsCredential>
    {
        public TdsCredential(string name, Azure.ContainerApps.Sandbox.TdsAuthKind kind) { }
        public Azure.ContainerApps.Sandbox.TdsAuthKind Kind { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Secret { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicySecretRef SecretRef { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TdsCredential JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TdsCredential PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TdsCredential System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsCredential>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsCredential>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TdsCredential System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsCredential>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsCredential>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsCredential>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressAction : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressAction>
    {
        public TdsEgressAction(Azure.ContainerApps.Sandbox.EgressPolicyActionType type) { }
        public string Credential { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyActionType Type { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TdsEgressAction System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressMatch : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>
    {
        public TdsEgressMatch(string host) { }
        public System.Collections.Generic.IList<string> Databases { get { throw null; } }
        public string Host { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TdsEgressMatch System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressRule>
    {
        public TdsEgressRule(string name, Azure.ContainerApps.Sandbox.TdsEgressMatch match) { }
        public Azure.ContainerApps.Sandbox.TdsEgressAction Action { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.EgressPolicyHookRef HookRef { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TdsEgressMatch Match { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TdsEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TdsEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressSection>
    {
        public TdsEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TdsCredential> credentials, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TdsEgressRule> rules) { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TdsCredential> Credentials { get { throw null; } }
        public Azure.ContainerApps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TdsEgressRule> Rules { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TdsEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TdsEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TdsEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TdsEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryApplicationInsightsAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>
    {
        public TelemetryApplicationInsightsAuth(string secretId, string secretKey) { }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryApplicationInsightsAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryAppSecretRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>
    {
        public TelemetryAppSecretRef(string secretRef) { }
        public string SecretRef { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryAppSecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryAppSecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetryAppSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryAppSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<System.BinaryData> endpoints) { }
        public System.Collections.Generic.IList<System.BinaryData> Endpoints { get { throw null; } }
        public int? MetricsIntervalSeconds { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryData : System.IEquatable<Azure.ContainerApps.Sandbox.TelemetryData>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryData(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryData ContainerOtel { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TelemetryData ContainerStdoutStderr { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TelemetryData Metrics { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TelemetryData NetworkEgressDecisions { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TelemetryData other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TelemetryData left, Azure.ContainerApps.Sandbox.TelemetryData right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryData (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryData? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TelemetryData left, Azure.ContainerApps.Sandbox.TelemetryData right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetryHeaderAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>
    {
        public TelemetryHeaderAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryHeaderAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryHeaderAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetryHeaderAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryHeaderAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryManagedIdentityAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>
    {
        public TelemetryManagedIdentityAuth(string identity) { }
        public string Identity { get { throw null; } }
        public Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? Kind { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryManagedIdentityAuthKind : System.IEquatable<Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryManagedIdentityAuthKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind ManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind left, Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind left, Azure.ContainerApps.Sandbox.TelemetryManagedIdentityAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryProtocol : System.IEquatable<Azure.ContainerApps.Sandbox.TelemetryProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryProtocol(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetryProtocol Grpc { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TelemetryProtocol Http { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TelemetryProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TelemetryProtocol left, Azure.ContainerApps.Sandbox.TelemetryProtocol right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryProtocol (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetryProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TelemetryProtocol left, Azure.ContainerApps.Sandbox.TelemetryProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySandboxGroupSecretRef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>
    {
        public TelemetrySandboxGroupSecretRef(string secretId, string secretKey) { }
        public Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? Kind { get { throw null; } set { } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetrySandboxGroupSecretRefKind : System.IEquatable<Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetrySandboxGroupSecretRefKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind GlobalSecret { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind left, Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind left, Azure.ContainerApps.Sandbox.TelemetrySandboxGroupSecretRefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TelemetrySystemAssignedManagedIdentityAuth : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>
    {
        public TelemetrySystemAssignedManagedIdentityAuth() { }
        public Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? Kind { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetrySystemAssignedManagedIdentityAuthKind : System.IEquatable<Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetrySystemAssignedManagedIdentityAuthKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind SystemAssignedManagedIdentity { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind left, Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind left, Azure.ContainerApps.Sandbox.TelemetrySystemAssignedManagedIdentityAuthKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenUsageStats : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TokenUsageStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TokenUsageStats>
    {
        internal TokenUsageStats() { }
        public int? RequestCount { get { throw null; } }
        public long? TotalInputTokens { get { throw null; } }
        public long? TotalOutputTokens { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TokenUsageStats JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TokenUsageStats PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TokenUsageStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TokenUsageStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TokenUsageStats System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TokenUsageStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TokenUsageStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TokenUsageStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficInspection : System.IEquatable<Azure.ContainerApps.Sandbox.TrafficInspection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficInspection(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TrafficInspection Full { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TrafficInspection Legacy { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TrafficInspection None { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TrafficInspection Partial { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TrafficInspection other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TrafficInspection left, Azure.ContainerApps.Sandbox.TrafficInspection right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TrafficInspection (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TrafficInspection? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TrafficInspection left, Azure.ContainerApps.Sandbox.TrafficInspection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TransportEgressRule : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressRule>
    {
        public TransportEgressRule(Azure.ContainerApps.Sandbox.EgressPolicyActionType action, Azure.ContainerApps.Sandbox.TransportProtocol protocol, string destination, int port) { }
        public Azure.ContainerApps.Sandbox.EgressPolicyActionType Action { get { throw null; } set { } }
        public string Destination { get { throw null; } set { } }
        public int Port { get { throw null; } set { } }
        public Azure.ContainerApps.Sandbox.TransportProtocol Protocol { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.TransportEgressRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TransportEgressRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TransportEgressRule System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TransportEgressSection : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressSection>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressSection>
    {
        public TransportEgressSection(Azure.ContainerApps.Sandbox.EgressPolicyActionType defaultAction, System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.TransportEgressRule> rules) { }
        public Azure.ContainerApps.Sandbox.EgressPolicyActionType DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.TransportEgressRule> Rules { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.TransportEgressSection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.TransportEgressSection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressSection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.TransportEgressSection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.TransportEgressSection System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressSection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressSection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.TransportEgressSection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.ContainerApps.Sandbox.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.TransportProtocol Tcp { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.TransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.TransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.TransportProtocol left, Azure.ContainerApps.Sandbox.TransportProtocol right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TransportProtocol (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.TransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.TransportProtocol left, Azure.ContainerApps.Sandbox.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdatePolicyRulesContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>
    {
        public UpdatePolicyRulesContent(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.McpPolicyRule> policyRules) { }
        public System.Collections.Generic.IList<string> EnabledToolGroups { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.McpPolicyRule> PolicyRules { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent updatePolicyRulesContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePolicyRulesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdatePortsContent : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>
    {
        public UpdatePortsContent(System.Collections.Generic.IEnumerable<Azure.ContainerApps.Sandbox.SandboxPortUpdate> ports) { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.SandboxPortUpdate> Ports { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.UpdatePortsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.ContainerApps.Sandbox.UpdatePortsContent updatePortsContent) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.UpdatePortsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.UpdatePortsContent System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.UpdatePortsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationWarning : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValidationWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValidationWarning>
    {
        public ValidationWarning(string code, string message) { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual Azure.ContainerApps.Sandbox.ValidationWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ValidationWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ValidationWarning System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValidationWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValidationWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ValidationWarning System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValidationWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValidationWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValidationWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValueLogColumnDef : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>
    {
        public ValueLogColumnDef(string value) { }
        public Azure.ContainerApps.Sandbox.ValueLogColumnDefKind? Kind { get { throw null; } set { } }
        public string Value { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.ValueLogColumnDef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.ValueLogColumnDef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.ValueLogColumnDef System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.ValueLogColumnDef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValueLogColumnDefKind : System.IEquatable<Azure.ContainerApps.Sandbox.ValueLogColumnDefKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValueLogColumnDefKind(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.ValueLogColumnDefKind Value { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.ValueLogColumnDefKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.ValueLogColumnDefKind left, Azure.ContainerApps.Sandbox.ValueLogColumnDefKind right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ValueLogColumnDefKind (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.ValueLogColumnDefKind? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.ValueLogColumnDefKind left, Azure.ContainerApps.Sandbox.ValueLogColumnDefKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeCountResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeCountResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeCountResult>
    {
        internal VolumeCountResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.VolumeTypeCount> Counts { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.VolumeCountResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.VolumeCountResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.VolumeCountResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeCountResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeCountResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.VolumeCountResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeCountResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeCountResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeCountResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumeListDirectoryResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>
    {
        internal VolumeListDirectoryResult() { }
        public System.Collections.Generic.IList<Azure.ContainerApps.Sandbox.VolumePathItem> Items { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.VolumeListDirectoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.VolumeListDirectoryResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.VolumeListDirectoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.VolumeListDirectoryResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeListDirectoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VolumePathItem : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumePathItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumePathItem>
    {
        internal VolumePathItem() { }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public bool IsDirectory { get { throw null; } }
        public string ItemName { get { throw null; } }
        public System.DateTimeOffset? LastModifiedUtc { get { throw null; } }
        public string Path { get { throw null; } }
        public System.BinaryData SizeBytes { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.VolumePathItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.VolumePathItem (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.VolumePathItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.VolumePathItem System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumePathItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumePathItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.VolumePathItem System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumePathItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumePathItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumePathItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeProvisioningState : System.IEquatable<Azure.ContainerApps.Sandbox.VolumeProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeProvisioningState(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumeProvisioningState Provisioning { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.VolumeProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.VolumeProvisioningState left, Azure.ContainerApps.Sandbox.VolumeProvisioningState right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.VolumeProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.VolumeProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.VolumeProvisioningState left, Azure.ContainerApps.Sandbox.VolumeProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeType : System.IEquatable<Azure.ContainerApps.Sandbox.VolumeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeType(string value) { throw null; }
        public static Azure.ContainerApps.Sandbox.VolumeType AzureBlob { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeType AzureBlobByo { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeType AzureFileCifs { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeType AzureFileNfs { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeType DataDisk { get { throw null; } }
        public static Azure.ContainerApps.Sandbox.VolumeType Esan { get { throw null; } }
        public bool Equals(Azure.ContainerApps.Sandbox.VolumeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ContainerApps.Sandbox.VolumeType left, Azure.ContainerApps.Sandbox.VolumeType right) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.VolumeType (string value) { throw null; }
        public static implicit operator Azure.ContainerApps.Sandbox.VolumeType? (string value) { throw null; }
        public static bool operator !=(Azure.ContainerApps.Sandbox.VolumeType left, Azure.ContainerApps.Sandbox.VolumeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VolumeTypeCount : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>
    {
        internal VolumeTypeCount() { }
        public int Count { get { throw null; } }
        public Azure.ContainerApps.Sandbox.VolumeType Type { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.VolumeTypeCount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ContainerApps.Sandbox.VolumeTypeCount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.VolumeTypeCount System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.VolumeTypeCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WriteFileResult : System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.WriteFileResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.WriteFileResult>
    {
        internal WriteFileResult() { }
        public long? BytesWritten { get { throw null; } }
        public string Error { get { throw null; } }
        public bool Success { get { throw null; } }
        protected virtual Azure.ContainerApps.Sandbox.WriteFileResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.ContainerApps.Sandbox.WriteFileResult (Azure.Response response) { throw null; }
        protected virtual Azure.ContainerApps.Sandbox.WriteFileResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ContainerApps.Sandbox.WriteFileResult System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.WriteFileResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ContainerApps.Sandbox.WriteFileResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ContainerApps.Sandbox.WriteFileResult System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.WriteFileResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.WriteFileResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ContainerApps.Sandbox.WriteFileResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
