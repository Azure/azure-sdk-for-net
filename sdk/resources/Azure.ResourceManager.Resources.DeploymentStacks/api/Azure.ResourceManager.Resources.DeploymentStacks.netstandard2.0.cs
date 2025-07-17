namespace Azure.ResourceManager.Resources.DeploymentStacks
{
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.Core.HttpMessage))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference))]
    [System.ClientModel.Primitives.ModelReaderWriterBuildableAttribute(typeof(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended))]
    public partial class AzureResourceManagerResourcesDeploymentStacksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesDeploymentStacksContext() { }
        public static Azure.ResourceManager.Resources.DeploymentStacks.AzureResourceManagerResourcesDeploymentStacksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeploymentStackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>, System.Collections.IEnumerable
    {
        protected DeploymentStackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Get(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetIfExists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetIfExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentStackData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>
    {
        public DeploymentStackData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public bool? BypassStackOutOfSyncError { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DeletedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentId { get { throw null; } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.Models.SubResource> DetachedResources { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended> FailedResources { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference> Resources { get { throw null; } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentStackResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentStackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult> ValidateStack(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>> ValidateStackAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesDeploymentStacksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource GetDeploymentStackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.ManagementGroups.ManagementGroupResource managementGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.DeploymentStacks.Mocking
{
    public partial class MockableResourcesDeploymentStacksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentStacksArmClient() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource GetDeploymentStackResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableResourcesDeploymentStacksManagementGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentStacksManagementGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
    public partial class MockableResourcesDeploymentStacksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentStacksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
    public partial class MockableResourcesDeploymentStacksSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentStacksSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks() { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.DeploymentStacks.Models
{
    public partial class ActionOnUnmanage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>
    {
        public ActionOnUnmanage(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum resources) { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum? ManagementGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum? ResourceGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum Resources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesDeploymentStacksModelFactory
    {
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData DeploymentStackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResponseError error = null, System.BinaryData template = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter> parameters = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink parametersLink = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage actionOnUnmanage = null, string debugSettingDetailLevel = null, bool? bypassStackOutOfSyncError = default(bool?), string deploymentScope = null, string description = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings denySettings = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState?), string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> detachedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.SubResource> deletedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended> failedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference> resources = null, string deploymentId = null, System.BinaryData outputs = null, System.TimeSpan? duration = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition DeploymentStackTemplateDefinition(System.BinaryData template = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult DeploymentStackValidateResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties properties = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference ManagedResourceReference(string id = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode? status = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode? denyStatus = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference ResourceReference(string id = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended ResourceReferenceExtended(string id = null, Azure.ResponseError error = null) { throw null; }
    }
    public partial class DenySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>
    {
        public DenySettings(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode mode) { }
        public bool? ApplyToChildScopes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedPrincipals { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenySettingsMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenySettingsMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettingsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DenyStatusMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DenyStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode Inapplicable { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode None { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode RemovedBySystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>
    {
        public DeploymentParameter() { }
        public string DeploymentParameterType { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState DeletingResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState UpdatingDenyAssignments { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Validating { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksDeleteDetachEnum : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksDeleteDetachEnum(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDeleteDetachEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>
    {
        public DeploymentStacksParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>
    {
        public DeploymentStacksTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackTemplateDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>
    {
        internal DeploymentStackTemplateDefinition() { }
        public System.BinaryData Template { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>
    {
        public DeploymentStackValidateProperties() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.SubResource> ValidatedResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>
    {
        public DeploymentStackValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.ResourceManager.Resources.Models.WritableSubResource keyVault, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedResourceReference : Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>
    {
        public ManagedResourceReference() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DenyStatusMode? DenyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ManagedResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>
    {
        public ResourceReference() { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceReferenceExtended : Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>
    {
        public ResourceReferenceExtended() { }
        public Azure.ResponseError Error { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceReferenceExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatusMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode RemoveDenyFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionManagementGroupMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionManagementGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceGroupMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
