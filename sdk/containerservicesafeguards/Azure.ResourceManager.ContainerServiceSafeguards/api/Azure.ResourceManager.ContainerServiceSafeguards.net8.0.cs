namespace Azure.ResourceManager.ContainerServiceSafeguards
{
    public partial class AzureResourceManagerContainerServiceSafeguardsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServiceSafeguardsContext() { }
        public static Azure.ResourceManager.ContainerServiceSafeguards.AzureResourceManagerContainerServiceSafeguardsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ContainerServiceSafeguardsExtensions
    {
        public static Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource GetDeploymentSafeguard(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource GetDeploymentSafeguardResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeploymentSafeguardData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>
    {
        public DeploymentSafeguardData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentSafeguardResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentSafeguardResource() { }
        public virtual Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceSafeguards.Mocking
{
    public partial class MockableContainerServiceSafeguardsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceSafeguardsArmClient() { }
        public virtual Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource GetDeploymentSafeguard(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardResource GetDeploymentSafeguardResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceSafeguards.Models
{
    public static partial class ArmContainerServiceSafeguardsModelFactory
    {
        public static Azure.ResourceManager.ContainerServiceSafeguards.DeploymentSafeguardData DeploymentSafeguardData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties DeploymentSafeguardsProperties(Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState?), Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel level = default(Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel), System.Collections.Generic.IEnumerable<string> excludedNamespaces = null, System.Collections.Generic.IEnumerable<string> systemExcludedNamespaces = null, Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel? podSecurityStandardsLevel = default(Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentSafeguardsLevel : System.IEquatable<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentSafeguardsLevel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel Enforce { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel Warn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel left, Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel left, Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentSafeguardsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>
    {
        public DeploymentSafeguardsProperties(Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel level) { }
        public System.Collections.Generic.IList<string> ExcludedNamespaces { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsLevel Level { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel? PodSecurityStandardsLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SystemExcludedNamespaces { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceSafeguards.Models.DeploymentSafeguardsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PodSecurityStandardsLevel : System.IEquatable<Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PodSecurityStandardsLevel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel PodSecurityStandardsBaseline { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel PodSecurityStandardsPrivileged { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel PodSecurityStandardsRestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel left, Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel left, Azure.ResourceManager.ContainerServiceSafeguards.Models.PodSecurityStandardsLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState left, Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState left, Azure.ResourceManager.ContainerServiceSafeguards.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
