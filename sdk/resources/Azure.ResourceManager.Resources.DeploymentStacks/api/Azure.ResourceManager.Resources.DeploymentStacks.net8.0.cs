namespace Azure.ResourceManager.Resources
{
    public partial class AzureResourceManagerResourcesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesContext() { }
        public static Azure.ResourceManager.Resources.AzureResourceManagerResourcesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeploymentStackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>, System.Collections.IEnumerable
    {
        protected DeploymentStackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> Get(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentStackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentStackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStackResource> GetIfExists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStackResource>> GetIfExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentStackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentStackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentStackData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>
    {
        public DeploymentStackData() { }
        public Azure.ResourceManager.Resources.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public bool? BypassStackOutOfSyncError { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DeletedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DetachedResources { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended> FailedResources { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.ManagedResourceReference> Resources { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentStackResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentStackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult> ValidateStack(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>> ValidateStackAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackResource GetDeploymentStackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Mocking
{
    public partial class MockableResourcesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesArmClient() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStackResource GetDeploymentStackResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
    public partial class MockableResourcesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
    public partial class MockableResourcesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.Models
{
    public partial class ActionOnUnmanage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>
    {
        public ActionOnUnmanage(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum resources) { }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum? ManagementGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum? ResourceGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Resources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ActionOnUnmanage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ActionOnUnmanage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ActionOnUnmanage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesModelFactory
    {
        public static Azure.ResourceManager.Resources.DeploymentStackData DeploymentStackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResponseError error = null, System.BinaryData template = null, Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> parameters = null, Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink parametersLink = null, Azure.ResourceManager.Resources.Models.ActionOnUnmanage actionOnUnmanage = null, string debugSettingDetailLevel = null, bool? bypassStackOutOfSyncError = default(bool?), string deploymentScope = null, string description = null, Azure.ResourceManager.Resources.Models.DenySettings denySettings = null, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState?), string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> detachedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> deletedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended> failedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.ManagedResourceReference> resources = null, string deploymentId = null, System.BinaryData outputs = null, System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition DeploymentStackTemplateDefinition(System.BinaryData template = null, Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink templateLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult DeploymentStackValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties properties = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ManagedResourceReference ManagedResourceReference(string id = null, Azure.ResourceManager.Resources.Models.ResourceStatusMode? status = default(Azure.ResourceManager.Resources.Models.ResourceStatusMode?), Azure.ResourceManager.Resources.Models.DenyStatusMode? denyStatus = default(Azure.ResourceManager.Resources.Models.DenyStatusMode?)) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated ResourceReferenceAutoGenerated(string id = null) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceReferenceExtended ResourceReferenceExtended(string id = null, Azure.ResponseError error = null) { throw null; }
    }
    public partial class DenySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>
    {
        public DenySettings(Azure.ResourceManager.Resources.Models.DenySettingsMode mode) { }
        public bool? ApplyToChildScopes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedPrincipals { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DenySettingsMode Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DenySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DenySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DenySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DenySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenySettingsMode : System.IEquatable<Azure.ResourceManager.Resources.Models.DenySettingsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenySettingsMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenySettingsMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DenySettingsMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DenySettingsMode left, Azure.ResourceManager.Resources.Models.DenySettingsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DenySettingsMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DenySettingsMode left, Azure.ResourceManager.Resources.Models.DenySettingsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenyStatusMode : System.IEquatable<Azure.ResourceManager.Resources.Models.DenyStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenyStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode Inapplicable { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode None { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DenyStatusMode RemovedBySystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DenyStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DenyStatusMode left, Azure.ResourceManager.Resources.Models.DenyStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DenyStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DenyStatusMode left, Azure.ResourceManager.Resources.Models.DenyStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>
    {
        public DeploymentParameter() { }
        public string DeploymentParameterType { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState DeletingResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState UpdatingDenyAssignments { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Validating { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.Models.DeploymentStackProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksDeleteDetachEnum : System.IEquatable<Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksDeleteDetachEnum(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>
    {
        public DeploymentStacksParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>
    {
        public DeploymentStacksTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackTemplateDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>
    {
        internal DeploymentStackTemplateDefinition() { }
        public System.BinaryData Template { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackTemplateDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>
    {
        public DeploymentStackValidateProperties() { }
        public Azure.ResourceManager.Resources.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>
    {
        public DeploymentStackValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.DeploymentStackValidateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.DeploymentStackValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedResourceReference : Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>
    {
        public ManagedResourceReference() { }
        public Azure.ResourceManager.Resources.Models.DenyStatusMode? DenyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ResourceStatusMode? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ManagedResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ManagedResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceReferenceAutoGenerated : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>
    {
        public ResourceReferenceAutoGenerated() { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceReferenceExtended : Azure.ResourceManager.Resources.Models.ResourceReferenceAutoGenerated, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>
    {
        public ResourceReferenceExtended() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.Models.ResourceReferenceExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.Models.ResourceReferenceExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatusMode : System.IEquatable<Azure.ResourceManager.Resources.Models.ResourceStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.ResourceStatusMode RemoveDenyFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.ResourceStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.Models.ResourceStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.ResourceStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.Models.ResourceStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionManagementGroupMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionManagementGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceGroupMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceMode : System.IEquatable<Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.Models.UnmanageActionResourceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
