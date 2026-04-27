namespace Azure.ResourceManager.KubernetesConfiguration.Extensions
{
    public partial class AzureResourceManagerKubernetesConfigurationExtensionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKubernetesConfigurationExtensionsContext() { }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.AzureResourceManagerKubernetesConfigurationExtensionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KubernetesClusterExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>, System.Collections.IEnumerable
    {
        protected KubernetesClusterExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string extensionName, Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> Get(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> GetAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> GetIfExists(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> GetIfExistsAsync(string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KubernetesClusterExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>
    {
        public KubernetesClusterExtensionData() { }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails AdditionalDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity AksAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode? AutoUpgradeMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } }
        public string CurrentVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CustomLocationSettings { get { throw null; } }
        public Azure.ResponseError ErrorInfo { get { throw null; } }
        public string ExtensionState { get { throw null; } }
        public string ExtensionType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsAutoUpgradeMinorVersionEnabled { get { throw null; } set { } }
        public bool? IsSystemExtension { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails ManagementDetails { get { throw null; } set { } }
        public System.Uri PackageUri { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReleaseTrain { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope Scope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus> Statuses { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KubernetesClusterExtensionResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string extensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class KubernetesConfigurationExtensionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> GetKubernetesClusterExtension(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> GetKubernetesClusterExtensionAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource GetKubernetesClusterExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionCollection GetKubernetesClusterExtensions(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.Extensions.Mocking
{
    public partial class MockableKubernetesConfigurationExtensionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationExtensionsArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource> GetKubernetesClusterExtension(Azure.Core.ResourceIdentifier scope, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource>> GetKubernetesClusterExtensionAsync(Azure.Core.ResourceIdentifier scope, string extensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionResource GetKubernetesClusterExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionCollection GetKubernetesClusterExtensions(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.Extensions.Models
{
    public static partial class ArmKubernetesConfigurationExtensionsModelFactory
    {
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail KubernetesClusterAccessDetail(string entity = null, System.Collections.Generic.IEnumerable<string> allowedActions = null, string description = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.KubernetesClusterExtensionData KubernetesClusterExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string extensionType = null, bool? isAutoUpgradeMinorVersionEnabled = default(bool?), string releaseTrain = null, string version = null, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope scope = null, System.Collections.Generic.IDictionary<string, string> configurationSettings = null, System.Collections.Generic.IDictionary<string, string> configurationProtectedSettings = null, string currentVersion = null, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus> statuses = null, Azure.ResponseError errorInfo = null, System.Collections.Generic.IReadOnlyDictionary<string, string> customLocationSettings = null, System.Uri packageUri = null, Azure.ResourceManager.Models.ManagedServiceIdentity aksAssignedIdentity = null, bool? isSystemExtension = default(bool?), Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode? autoUpgradeMode = default(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode?), Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails managementDetails = null, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails additionalDetails = null, string extensionState = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier managedBy = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails KubernetesClusterManagementDetails(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail> accessDetails = null) { throw null; }
    }
    public partial class KubernetesClusterAccessDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>
    {
        public KubernetesClusterAccessDetail() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Entity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterAdditionalDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>
    {
        public KubernetesClusterAdditionalDetails() { }
        public string Docs { get { throw null; } set { } }
        public string ReleaseNotes { get { throw null; } set { } }
        public string TroubleshootingGuide { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAdditionalDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterAutoUpgradeMode : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterAutoUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode Compatible { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode None { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode Patch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterExtensionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>
    {
        public KubernetesClusterExtensionPatch() { }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAutoUpgradeMode? AutoUpgradeMode { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationProtectedSettings { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ConfigurationSettings { get { throw null; } }
        public bool? IsAutoUpgradeMinorVersionEnabled { get { throw null; } set { } }
        public string ReleaseTrain { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionScope : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>
    {
        public KubernetesClusterExtensionScope() { }
        public string ClusterReleaseNamespace { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionScope>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KubernetesClusterExtensionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>
    {
        public KubernetesClusterExtensionStatus() { }
        public string Code { get { throw null; } set { } }
        public string DisplayStatus { get { throw null; } set { } }
        public Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel? Level { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public string Time { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesClusterExtensionStatusLevel : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesClusterExtensionStatusLevel(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel Error { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel Information { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterExtensionStatusLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KubernetesClusterManagementDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>
    {
        public KubernetesClusterManagementDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterAccessDetail> AccessDetails { get { throw null; } }
        public string Category { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesClusterManagementDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KubernetesConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KubernetesConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState left, Azure.ResourceManager.KubernetesConfiguration.Extensions.Models.KubernetesConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
