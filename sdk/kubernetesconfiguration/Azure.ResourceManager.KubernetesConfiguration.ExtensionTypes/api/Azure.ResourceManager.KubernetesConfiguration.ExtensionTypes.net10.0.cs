namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes
{
    public partial class AzureResourceManagerKubernetesConfigurationExtensionTypesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKubernetesConfigurationExtensionTypesContext() { }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.AzureResourceManagerKubernetesConfigurationExtensionTypesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ExtensionTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>
    {
        internal ExtensionTypeData() { }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeInterfaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>, System.Collections.IEnumerable
    {
        protected ExtensionTypeInterfaceCollection() { }
        public virtual Azure.Response<bool> Exists(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> Get(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetAll(string releaseTrain = null, string majorVersion = null, bool? showLatest = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetAllAsync(string releaseTrain = null, string majorVersion = null, bool? showLatest = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetAsync(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetIfExists(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetIfExistsAsync(string versionNumber, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExtensionTypeInterfaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExtensionTypeInterfaceResource() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string clusterRp, string clusterResourceName, string clusterName, string extensionTypeName, string versionNumber) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeVersionForReleaseTrainData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>
    {
        internal ExtensionTypeVersionForReleaseTrainData() { }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class KubernetesConfigurationExtensionTypesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetExtensionTypeInterface(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetExtensionTypeInterface(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetExtensionTypeInterfaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetExtensionTypeInterfaceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource GetExtensionTypeInterfaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceCollection GetExtensionTypeInterfaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string clusterRp, string clusterResourceName, string clusterName) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceCollection GetExtensionTypeInterfaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Mocking
{
    public partial class MockableKubernetesConfigurationExtensionTypesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationExtensionTypesArmClient() { }
        public virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource GetExtensionTypeInterfaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKubernetesConfigurationExtensionTypesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationExtensionTypesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetExtensionTypeInterface(string clusterRp, string clusterResourceName, string clusterName, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetExtensionTypeInterfaceAsync(string clusterRp, string clusterResourceName, string clusterName, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceCollection GetExtensionTypeInterfaces(string clusterRp, string clusterResourceName, string clusterName) { throw null; }
    }
    public partial class MockableKubernetesConfigurationExtensionTypesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKubernetesConfigurationExtensionTypesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource> GetExtensionTypeInterface(string location, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceResource>> GetExtensionTypeInterfaceAsync(string location, string extensionTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeInterfaceCollection GetExtensionTypeInterfaces(string location) { throw null; }
    }
}
namespace Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models
{
    public static partial class ArmKubernetesConfigurationExtensionTypesModelFactory
    {
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings ExtensionTypeClusterScopeSettings(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isMultipleInstancesAllowed = default(bool?), string defaultReleaseNamespace = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeData ExtensionTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo ExtensionTypePlanInfo(string publisherId = null, string planId = null, string offerId = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties ExtensionTypeProperties(bool? isSystemExtension = default(bool?), bool? isManagedIdentityRequired = default(bool?), string description = null, string publisher = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo planInfo = null, System.Collections.Generic.IEnumerable<string> supportedClusterTypes = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes supportedScopes = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes ExtensionTypeSupportedScopes(string defaultScope = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings clusterScopeSettings = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions ExtensionTypeUnsupportedKubernetesVersions(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> connectedCluster = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> appliances = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> provisionedCluster = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> managedCluster = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.ExtensionTypeVersionForReleaseTrainData ExtensionTypeVersionForReleaseTrainData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties ExtensionTypeVersionForReleaseTrainProperties(string version = null, Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions unsupportedKubernetesVersions = null, System.Collections.Generic.IEnumerable<string> supportedClusterTypes = null) { throw null; }
        public static Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem ExtensionTypeVersionUnsupportedKubernetesMatrixItem(System.Collections.Generic.IEnumerable<string> distributions = null, System.Collections.Generic.IEnumerable<string> unsupportedVersions = null) { throw null; }
    }
    public partial class ExtensionTypeClusterScopeSettings : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>
    {
        internal ExtensionTypeClusterScopeSettings() { }
        public string DefaultReleaseNamespace { get { throw null; } }
        public bool? IsMultipleInstancesAllowed { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypePlanInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>
    {
        internal ExtensionTypePlanInfo() { }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>
    {
        internal ExtensionTypeProperties() { }
        public string Description { get { throw null; } }
        public bool? IsManagedIdentityRequired { get { throw null; } }
        public bool? IsSystemExtension { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypePlanInfo PlanInfo { get { throw null; } }
        public string Publisher { get { throw null; } }
        public System.Collections.Generic.IList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes SupportedScopes { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeSupportedScopes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>
    {
        internal ExtensionTypeSupportedScopes() { }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeClusterScopeSettings ClusterScopeSettings { get { throw null; } }
        public string DefaultScope { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeSupportedScopes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeUnsupportedKubernetesVersions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>
    {
        internal ExtensionTypeUnsupportedKubernetesVersions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> Appliances { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ConnectedCluster { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ManagedCluster { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem> ProvisionedCluster { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeVersionForReleaseTrainProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>
    {
        internal ExtensionTypeVersionForReleaseTrainProperties() { }
        public System.Collections.Generic.IList<string> SupportedClusterTypes { get { throw null; } }
        public Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeUnsupportedKubernetesVersions UnsupportedKubernetesVersions { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionForReleaseTrainProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionTypeVersionUnsupportedKubernetesMatrixItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>
    {
        internal ExtensionTypeVersionUnsupportedKubernetesMatrixItem() { }
        public System.Collections.Generic.IList<string> Distributions { get { throw null; } }
        public System.Collections.Generic.IList<string> UnsupportedVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes.Models.ExtensionTypeVersionUnsupportedKubernetesMatrixItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
