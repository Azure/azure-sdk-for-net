namespace Azure.ResourceManager.DesktopVirtualization
{
    public partial class ActiveSessionHostConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>
    {
        internal ActiveSessionHostConfigurationData() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveSessionHostConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ActiveSessionHostConfigurationResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppAttachPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>, System.Collections.IEnumerable
    {
        protected AppAttachPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string appAttachPackageName, Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string appAttachPackageName, Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> Get(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> GetAsync(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetIfExists(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> GetIfExistsAsync(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppAttachPackageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>
    {
        public AppAttachPackageData(Azure.Core.AzureLocation location, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties properties) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppAttachPackageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppAttachPackageResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string appAttachPackageName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerDesktopVirtualizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDesktopVirtualizationContext() { }
        public static Azure.ResourceManager.DesktopVirtualization.AzureResourceManagerDesktopVirtualizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DesktopVirtualizationExtensions
    {
        public static Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource GetActiveSessionHostConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackage(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> GetAppAttachPackageAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource GetAppAttachPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.AppAttachPackageCollection GetAppAttachPackages(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> GetHostPoolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource GetHostPoolPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolResource GetHostPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolCollection GetHostPools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPoolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.MsixPackageResource GetMsixPackageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlan(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> GetScalingPlanAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource GetScalingPlanPersonalScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource GetScalingPlanPooledScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource GetScalingPlanResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanCollection GetScalingPlans(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource GetSessionHostConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource GetSessionHostManagementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostResource GetSessionHostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.UserSessionResource GetUserSessionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> GetVirtualApplicationGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource GetVirtualApplicationGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupCollection GetVirtualApplicationGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource GetVirtualApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource GetVirtualDesktopResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> GetVirtualWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource GetVirtualWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceCollection GetVirtualWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DesktopVirtualizationPrivateEndpointConnectionDataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>
    {
        public DesktopVirtualizationPrivateEndpointConnectionDataData() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>, System.Collections.IEnumerable
    {
        protected HostPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hostPoolName, Azure.ResourceManager.DesktopVirtualization.HostPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hostPoolName, Azure.ResourceManager.DesktopVirtualization.HostPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> Get(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> GetAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetIfExists(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> GetIfExistsAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>
    {
        public HostPoolData(Azure.Core.AzureLocation location, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType hostPoolType, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType loadBalancerType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType preferredAppGroupType) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties AgentUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink? AllowRdpShortPathWithPrivateLink { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> AppAttachPackageReferences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApplicationGroupReferences { get { throw null; } }
        public string CustomRdpProperty { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp? DirectUdp { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType HostPoolType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsCloudPCResource { get { throw null; } }
        public bool? IsValidationEnvironment { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType LoadBalancerType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp? ManagedPrivateUdp { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType? ManagementType { get { throw null; } set { } }
        public int? MaxSessionLimit { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version", false)]
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationMigrationProperties MigrationRequest { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public string OboTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType PreferredAppGroupType { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp? PublicUdp { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo RegistrationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp? RelayUdp { get { throw null; } set { } }
        public int? Ring { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public string SsoAdfsAuthority { get { throw null; } set { } }
        public string SsoClientId { get { throw null; } set { } }
        public string SsoClientSecretKeyVaultPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? SsoSecretType { get { throw null; } set { } }
        public bool? StartVmOnConnect { get { throw null; } set { } }
        public string VmTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.HostPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.HostPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostPoolPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HostPoolPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HostPoolPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostPoolPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HostPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HostPoolResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage> ExpandMsixImages(Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri msixImageUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage> ExpandMsixImagesAsync(Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri msixImageUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource GetActiveSessionHostConfiguration() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource> GetByHostPool(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource> GetByHostPoolAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource> GetHostPoolPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource>> GetHostPoolPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionCollection GetHostPoolPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetMsixPackage(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> GetMsixPackageAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.MsixPackageCollection GetMsixPackages() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResources(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResourcesAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal> GetRegistrationTokens(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal> GetRegistrationTokensAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetSessionHost(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> GetSessionHostAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource GetSessionHostConfiguration() { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource GetSessionHostManagement() { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostCollection GetSessionHosts() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetUserSessions(string filter = null, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetUserSessions(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetUserSessionsAsync(string filter = null, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetUserSessionsAsync(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> ImportAppAttachPackageInfos(Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> ImportAppAttachPackageInfosAsync(Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo> RetrieveRegistrationToken(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>> RetrieveRegistrationTokenAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.HostPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.HostPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.HostPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MsixPackageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>, System.Collections.IEnumerable
    {
        protected MsixPackageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string msixPackageFullName, Azure.ResourceManager.DesktopVirtualization.MsixPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string msixPackageFullName, Azure.ResourceManager.DesktopVirtualization.MsixPackageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> Get(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> GetAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> GetIfExists(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> GetIfExistsAsync(string msixPackageFullName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MsixPackageData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>
    {
        public MsixPackageData() { }
        public string DisplayName { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> PackageApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> PackageDependencies { get { throw null; } }
        public string PackageFamilyName { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public string PackageRelativePath { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.MsixPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.MsixPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsixPackageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MsixPackageResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.MsixPackageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string msixPackageFullName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.MsixPackageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.MsixPackageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.MsixPackageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.MsixPackageResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScalingPlanCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>, System.Collections.IEnumerable
    {
        protected ScalingPlanCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scalingPlanName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scalingPlanName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> Get(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> GetAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetIfExists(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> GetIfExistsAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScalingPlanData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>
    {
        public ScalingPlanData(Azure.Core.AzureLocation location) { }
        public ScalingPlanData(Azure.Core.AzureLocation location, string timeZone) { }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string ExclusionTag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference> HostPoolReferences { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version", false)]
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? HostPoolType { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType? ScalingHostPoolType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule> Schedules { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingPlanPersonalScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>, System.Collections.IEnumerable
    {
        protected ScalingPlanPersonalScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scalingPlanScheduleName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scalingPlanScheduleName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> Get(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> GetAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> GetIfExists(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> GetIfExistsAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScalingPlanPersonalScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>
    {
        public ScalingPlanPersonalScheduleData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? OffPeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? OffPeakActionOnLogoff { get { throw null; } set { } }
        public int? OffPeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? OffPeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? OffPeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? PeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? PeakActionOnLogoff { get { throw null; } set { } }
        public int? PeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? PeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? PeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampDownActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampDownActionOnLogoff { get { throw null; } set { } }
        public int? RampDownMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? RampDownMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? RampDownStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampUpActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampUpActionOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior? RampUpAutoStartHosts { get { throw null; } set { } }
        public int? RampUpMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? RampUpMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? RampUpStartVmOnConnect { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingPlanPersonalScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScalingPlanPersonalScheduleResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scalingPlanName, string scalingPlanScheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScalingPlanPooledScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>, System.Collections.IEnumerable
    {
        protected ScalingPlanPooledScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string scalingPlanScheduleName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string scalingPlanScheduleName, Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> Get(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> GetAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> GetIfExists(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> GetIfExistsAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScalingPlanPooledScheduleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>
    {
        public ScalingPlanPooledScheduleData() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties CreateDelete { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public int? RampDownCapacityThresholdPct { get { throw null; } set { } }
        public bool? RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampDownMinimumHostsPct { get { throw null; } set { } }
        public string RampDownNotificationMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? RampDownStopHostsWhen { get { throw null; } set { } }
        public int? RampDownWaitTimeMinutes { get { throw null; } set { } }
        public int? RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampUpMinimumHostsPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? ScalingMethod { get { throw null; } set { } }
        public string ScheduleName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingPlanPooledScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScalingPlanPooledScheduleResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scalingPlanName, string scalingPlanScheduleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScalingPlanResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScalingPlanResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string scalingPlanName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource> GetScalingPlanPersonalSchedule(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource>> GetScalingPlanPersonalScheduleAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleCollection GetScalingPlanPersonalSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource> GetScalingPlanPooledSchedule(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource>> GetScalingPlanPooledScheduleAsync(string scalingPlanScheduleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleCollection GetScalingPlanPooledSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.ScalingPlanData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.ScalingPlanData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SessionHostCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>, System.Collections.IEnumerable
    {
        protected SessionHostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sessionHostName, Azure.ResourceManager.DesktopVirtualization.SessionHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sessionHostName, Azure.ResourceManager.DesktopVirtualization.SessionHostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> Get(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), string vmPath = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAll(int? pageSize, bool? isDescending, int? initialSkip, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), string vmPath = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAllAsync(int? pageSize, bool? isDescending, int? initialSkip, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> GetAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> GetIfExists(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> GetIfExistsAsync(string sessionHostName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SessionHostConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>
    {
        public SessionHostConfigurationData(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties properties) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SessionHostConfigurationResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SessionHostData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>
    {
        public SessionHostData() { }
        public int? ActiveSessions { get { throw null; } }
        public string AgentVersion { get { throw null; } set { } }
        public bool? AllowNewSession { get { throw null; } set { } }
        public string AssignedUser { get { throw null; } set { } }
        public int? DisconnectedSessions { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public System.DateTimeOffset? LastHeartBeatOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastSessionHostUpdateOn { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string OSVersion { get { throw null; } set { } }
        public int? PendingSessions { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string SessionHostConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport> SessionHostHealthCheckResults { get { throw null; } }
        public int? Sessions { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus? Status { get { throw null; } set { } }
        public System.DateTimeOffset? StatusTimestamp { get { throw null; } }
        public string SxsStackVersion { get { throw null; } set { } }
        public string UpdateErrorMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState? UpdateState { get { throw null; } set { } }
        public string VmId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>
    {
        public SessionHostManagementData(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties properties) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SessionHostManagementResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation ControlSessionHostProvisioning(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ControlSessionHostProvisioningAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ControlSessionHostUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ControlSessionHostUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus> GetProvisioningStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>> GetProvisioningStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus> GetUpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>> GetUpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response InitiateSessionHostUpdate(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> InitiateSessionHostUpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SessionHostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SessionHostResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal> GetSingleSessionHostRegistrationTokens(Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal> GetSingleSessionHostRegistrationTokensAsync(Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetUserSession(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>> GetUserSessionAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.UserSessionCollection GetUserSessions() { throw null; }
        public virtual Azure.Response RetryProvisioning(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RetryProvisioningAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.SessionHostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.SessionHostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.SessionHostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch patch = null, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch patch = null, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.SessionHostResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserSessionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>, System.Collections.IEnumerable
    {
        protected UserSessionCollection() { }
        public virtual Azure.Response<bool> Exists(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> Get(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>> GetAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> GetIfExists(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>> GetIfExistsAsync(string userSessionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserSessionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>
    {
        public UserSessionData() { }
        public string ActiveDirectoryUserName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType? ApplicationType { get { throw null; } set { } }
        public System.DateTimeOffset? CreateOn { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState? SessionState { get { throw null; } set { } }
        public string UserPrincipalName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.UserSessionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.UserSessionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserSessionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserSessionResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.UserSessionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hostPoolName, string sessionHostName, string userSessionId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? force = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disconnect(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisconnectAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.UserSessionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendMessage(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage sendMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendMessageAsync(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage sendMessage, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.UserSessionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.UserSessionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.UserSessionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>, System.Collections.IEnumerable
    {
        protected VirtualApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> Get(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> GetAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetIfExists(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> GetIfExistsAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualApplicationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>
    {
        public VirtualApplicationData(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting commandLineSetting) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? ApplicationType { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting CommandLineSetting { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.BinaryData IconContent { get { throw null; } }
        public string IconHash { get { throw null; } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
        public string MsixPackageApplicationId { get { throw null; } set { } }
        public string MsixPackageFamilyName { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public bool? ShowInPortal { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualApplicationGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>, System.Collections.IEnumerable
    {
        protected VirtualApplicationGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string applicationGroupName, Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> Get(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetAll(string filter = null, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetAll(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetAllAsync(string filter = null, int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetAllAsync(string filter, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> GetAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetIfExists(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> GetIfExistsAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualApplicationGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>
    {
        public VirtualApplicationGroupData(Azure.Core.AzureLocation location, Azure.Core.ResourceIdentifier hostPoolId, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType applicationGroupType) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType ApplicationGroupType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? DeploymentScope { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HostPoolId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsCloudPCResource { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version", false)]
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationMigrationProperties MigrationRequest { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public string OboTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public bool? ShowInFeed { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualApplicationGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualApplicationGroupResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem> GetStartMenuItems(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem> GetStartMenuItems(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem> GetStartMenuItemsAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem> GetStartMenuItemsAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> GetVirtualApplication(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> GetVirtualApplicationAsync(string applicationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationCollection GetVirtualApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetVirtualDesktop(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>> GetVirtualDesktopAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualDesktopCollection GetVirtualDesktops() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualApplicationResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName, string applicationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualDesktopCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>, System.Collections.IEnumerable
    {
        protected VirtualDesktopCollection() { }
        public virtual Azure.Response<bool> Exists(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> Get(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>> GetAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> GetIfExists(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>> GetIfExistsAsync(string desktopName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualDesktopData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>
    {
        public VirtualDesktopData() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.BinaryData IconContent { get { throw null; } }
        public string IconHash { get { throw null; } }
        public string ObjectId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualDesktopResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualDesktopResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string applicationGroupName, string desktopName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>, System.Collections.IEnumerable
    {
        protected VirtualWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetAll(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetAllAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>
    {
        public VirtualWorkspaceData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> ApplicationGroupReferences { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsCloudPCResource { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } set { } }
        public string ObjectId { get { throw null; } }
        public string OboTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ArmPlan Plan { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualWorkspaceResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResources(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData> GetPrivateLinkResourcesAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> GetWorkspacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> GetWorkspacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionCollection GetWorkspacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> Update(Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> UpdateAsync(Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch patch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection connection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DesktopVirtualization.Mocking
{
    public partial class MockableDesktopVirtualizationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDesktopVirtualizationArmClient() { }
        public virtual Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationResource GetActiveSessionHostConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource GetAppAttachPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolPrivateEndpointConnectionResource GetHostPoolPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolResource GetHostPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.MsixPackageResource GetMsixPackageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleResource GetScalingPlanPersonalScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleResource GetScalingPlanPooledScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource GetScalingPlanResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationResource GetSessionHostConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostManagementResource GetSessionHostManagementResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.SessionHostResource GetSessionHostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.UserSessionResource GetUserSessionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource GetVirtualApplicationGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationResource GetVirtualApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualDesktopResource GetVirtualDesktopResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource GetVirtualWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDesktopVirtualizationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDesktopVirtualizationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackage(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource>> GetAppAttachPackageAsync(string appAttachPackageName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.AppAttachPackageCollection GetAppAttachPackages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPool(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.HostPoolResource>> GetHostPoolAsync(string hostPoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.HostPoolCollection GetHostPools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlan(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource>> GetScalingPlanAsync(string scalingPlanName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.ScalingPlanCollection GetScalingPlans() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroup(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource>> GetVirtualApplicationGroupAsync(string applicationGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupCollection GetVirtualApplicationGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource>> GetVirtualWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceCollection GetVirtualWorkspaces() { throw null; }
    }
    public partial class MockableDesktopVirtualizationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDesktopVirtualizationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackages(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.AppAttachPackageResource> GetAppAttachPackagesAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPools(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPools(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPoolsAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.HostPoolResource> GetHostPoolsAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlans(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(int? pageSize = default(int?), bool? isDescending = default(bool?), int? initialSkip = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.ScalingPlanResource> GetScalingPlansAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroups(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupResource> GetVirtualApplicationGroupsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceResource> GetVirtualWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public partial class ActiveDirectoryInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>
    {
        public ActiveDirectoryInfoProperties(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties domainCredentials, string ouPath) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties DomainCredentials { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string OuPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActiveSessionHostConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>
    {
        internal ActiveSessionHostConfigurationProperties() { }
        public System.Collections.Generic.IList<int> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties BootDiagnosticsInfo { get { throw null; } }
        public System.Uri CustomConfigurationScriptUri { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties DiskInfo { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties DomainInfo { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties ImageInfo { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties NetworkInfo { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties SecurityInfo { get { throw null; } }
        public System.DateTimeOffset? Version { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties VmAdminCredentials { get { throw null; } }
        public Azure.Core.AzureLocation? VmLocation { get { throw null; } }
        public string VmNamePrefix { get { throw null; } }
        public string VmResourceGroup { get { throw null; } }
        public string VmSizeId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> VmTags { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowRdpShortPathWithPrivateLink : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowRdpShortPathWithPrivateLink(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink left, Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink left, Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppAttachPackageArchitecture : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppAttachPackageArchitecture(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture All { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture Arm { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture Arm64 { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture Neutral { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture X64 { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture X86 { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture X86A64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture left, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture left, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppAttachPackageInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>
    {
        public AppAttachPackageInfoProperties() { }
        public System.DateTimeOffset? CertificateExpireOn { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped? IsPackageTimestamped { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string PackageAlias { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> PackageApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> PackageDependencies { get { throw null; } set { } }
        public string PackageFamilyName { get { throw null; } set { } }
        public string PackageFullName { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public string PackageRelativePath { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppAttachPackagePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>
    {
        public AppAttachPackagePatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppAttachPackagePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>
    {
        public AppAttachPackagePatchProperties() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? FailHealthCheckOnStagingFailure { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> HostPoolReferences { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties Image { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public System.Uri PackageLookbackUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppAttachPackageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>
    {
        public AppAttachPackageProperties() { }
        public string CustomData { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? DeploymentScope { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? FailHealthCheckOnStagingFailure { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> HostPoolReferences { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties Image { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public System.Uri PackageLookbackUri { get { throw null; } set { } }
        public string PackageOwnerName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppAttachPackageProvisioningState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppAttachPackageProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState left, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState left, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmDesktopVirtualizationModelFactory
    {
        public static Azure.ResourceManager.DesktopVirtualization.ActiveSessionHostConfigurationData ActiveSessionHostConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ActiveSessionHostConfigurationProperties ActiveSessionHostConfigurationProperties(System.DateTimeOffset? version = default(System.DateTimeOffset?), string friendlyName = null, System.Collections.Generic.IDictionary<string, string> vmTags = null, Azure.Core.AzureLocation? vmLocation = default(Azure.Core.AzureLocation?), string vmResourceGroup = null, string vmNamePrefix = null, System.Collections.Generic.IEnumerable<int> availabilityZones = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties networkInfo = null, string vmSizeId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties diskInfo = null, System.Uri customConfigurationScriptUri = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties imageInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties domainInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties securityInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties vmAdminCredentials = null, Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties bootDiagnosticsInfo = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.AppAttachPackageData AppAttachPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties AppAttachPackageInfoProperties(string packageAlias = null, string imagePath = null, string packageName = null, string packageFamilyName = null, string packageFullName = null, string displayName = null, string packageRelativePath = null, bool? isRegularRegistration = default(bool?), bool? isActive = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> packageDependencies = null, string version = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> packageApplications = null, string certificateName = null, System.DateTimeOffset? certificateExpireOn = default(System.DateTimeOffset?), Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped? isPackageTimestamped = default(Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch AppAttachPackagePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties properties) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatch AppAttachPackagePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackagePatchProperties AppAttachPackagePatchProperties(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties image = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> hostPoolReferences = null, System.Uri keyVaultUri = null, Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? failHealthCheckOnStagingFailure = default(Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure?), System.Uri packageLookbackUri = null, string customData = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties AppAttachPackageProperties(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState? provisioningState, Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties image, System.Collections.Generic.IEnumerable<string> hostPoolReferences, System.Uri keyVaultUri, Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? failHealthCheckOnStagingFailure) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProperties AppAttachPackageProperties(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState? provisioningState = default(Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageProvisioningState?), Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageInfoProperties image = null, System.Collections.Generic.IEnumerable<string> hostPoolReferences = null, System.Uri keyVaultUri = null, Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? failHealthCheckOnStagingFailure = default(Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure?), string packageOwnerName = null, System.Uri packageLookbackUri = null, string customData = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? deploymentScope = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection DesktopVirtualizationPrivateEndpointConnection(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState connectionState, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection DesktopVirtualizationPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData DesktopVirtualizationPrivateEndpointConnectionDataData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState connectionState, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.DesktopVirtualizationPrivateEndpointConnectionDataData DesktopVirtualizationPrivateEndpointConnectionDataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData DesktopVirtualizationPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal DesktopVirtualizationRegistrationTokenMinimal(System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string token = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem DesktopVirtualizationStartMenuItem(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string appAlias = null, string filePath = null, string commandLineArguments = null, string iconPath = null, int? iconIndex = default(int?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage ExpandMsixImage(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string packageAlias, string imagePath, string packageName, string packageFamilyName, string packageFullName, string displayName, string packageRelativePath, bool? isRegularRegistration, bool? isActive, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> packageDependencies, string version, System.DateTimeOffset? lastUpdatedOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> packageApplications) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage ExpandMsixImage(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string packageAlias = null, string imagePath = null, string packageName = null, string packageFamilyName = null, string packageFullName = null, string displayName = null, string packageRelativePath = null, bool? isRegularRegistration = default(bool?), bool? isActive = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> packageDependencies = null, string version = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> packageApplications = null, string certificateName = null, System.DateTimeOffset? certificateExpiry = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolData HostPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string friendlyName, string description, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType hostPoolType, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType, string customRdpProperty, int? maxSessionLimit, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType loadBalancerType, int? ring, bool? isValidationEnvironment, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo registrationInfo, string vmTemplate, System.Collections.Generic.IEnumerable<string> applicationGroupReferences, System.Collections.Generic.IEnumerable<string> appAttachPackageReferences, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType preferredAppGroupType, bool? startVmOnConnect, bool? isCloudPCResource, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties agentUpdate, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> privateEndpointConnections, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolData HostPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string friendlyName, string description, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType hostPoolType, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType, string customRdpProperty, int? maxSessionLimit, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType loadBalancerType, int? ring, bool? isValidationEnvironment, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo registrationInfo, string vmTemplate, System.Collections.Generic.IEnumerable<string> applicationGroupReferences, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType preferredAppGroupType, bool? startVmOnConnect, bool? isCloudPCResource, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties agentUpdate, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolData HostPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string friendlyName, string description, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType hostPoolType, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType, string customRdpProperty, int? maxSessionLimit, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType loadBalancerType, int? ring, bool? isValidationEnvironment, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo registrationInfo, string vmTemplate, System.Collections.Generic.IEnumerable<string> applicationGroupReferences, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType preferredAppGroupType, bool? startVmOnConnect, bool? isCloudPCResource, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties agentUpdate, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> privateEndpointConnections, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.HostPoolData HostPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string objectId = null, string friendlyName = null, string description = null, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? hostPoolType = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType?), Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType = default(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType?), string customRdpProperty = null, int? maxSessionLimit = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? loadBalancerType = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType?), int? ring = default(int?), bool? isValidationEnvironment = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo registrationInfo = null, string vmTemplate = null, System.Collections.Generic.IEnumerable<string> applicationGroupReferences = null, System.Collections.Generic.IEnumerable<string> appAttachPackageReferences = null, string ssoAdfsAuthority = null, string ssoClientId = null, string ssoClientSecretKeyVaultPath = null, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType?), Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? preferredAppGroupType = default(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType?), bool? startVmOnConnect = default(bool?), bool? isCloudPCResource = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties agentUpdate = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp? managedPrivateUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp? directUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp? publicUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp? relayUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType? managementType = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? deploymentScope = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope?), string oboTenantId = null, Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink? allowRdpShortPathWithPrivateLink = default(Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.Core.ResourceIdentifier managedBy = null, Azure.ResourceManager.Models.ArmPlan plan = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch HostPoolPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, string friendlyName, string description, string customRdpProperty, int? maxSessionLimit, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? loadBalancerType, int? ring, bool? isValidationEnvironment, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch registrationInfo, string vmTemplate, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? preferredAppGroupType, bool? startVmOnConnect, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties agentUpdate) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch HostPoolPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, string friendlyName, string description, string customRdpProperty, int? maxSessionLimit, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? loadBalancerType, int? ring, bool? isValidationEnvironment, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch registrationInfo, string vmTemplate, string ssoAdfsAuthority, string ssoClientId, string ssoClientSecretKeyVaultPath, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? preferredAppGroupType, bool? startVmOnConnect, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties agentUpdate) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch HostPoolPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, string friendlyName = null, string description = null, string customRdpProperty = null, int? maxSessionLimit = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? personalDesktopAssignmentType = default(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? loadBalancerType = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType?), int? ring = default(int?), bool? isValidationEnvironment = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch registrationInfo = null, string vmTemplate = null, string ssoAdfsAuthority = null, string ssoClientId = null, string ssoClientSecretKeyVaultPath = null, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? ssoSecretType = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType?), Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? preferredAppGroupType = default(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType?), bool? startVmOnConnect = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties agentUpdate = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp? managedPrivateUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp? directUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp? publicUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp? relayUdp = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp?), Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink? allowRdpShortPathWithPrivateLink = default(Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent HostPoolProvisioningControlContent(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction action = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction), string cancelMessage = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent HostPoolUpdateControlContent(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction action = default(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction), string cancelMessage = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.MsixPackageData MsixPackageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string imagePath = null, string packageName = null, string packageFamilyName = null, string displayName = null, string packageRelativePath = null, bool? isRegularRegistration = default(bool?), bool? isActive = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> packageDependencies = null, string version = null, System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> packageApplications = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch MsixPackagePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? isActive = default(bool?), bool? isRegularRegistration = default(bool?), string displayName = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanData ScalingPlanData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string objectId = null, string description = null, string friendlyName = null, string timeZone = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType? scalingHostPoolType = default(Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType?), string exclusionTag = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule> schedules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference> hostPoolReferences = null, Azure.Core.ResourceIdentifier managedBy = null, string kind = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku = null, Azure.ResourceManager.Models.ArmPlan plan = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanPersonalScheduleData ScalingPlanPersonalScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> daysOfWeek = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior? rampUpAutoStartHosts = default(Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior?), Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? rampUpStartVmOnConnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? rampUpActionOnDisconnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? rampUpMinutesToWaitOnDisconnect = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? rampUpActionOnLogoff = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? rampUpMinutesToWaitOnLogoff = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? peakStartVmOnConnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? peakActionOnDisconnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? peakMinutesToWaitOnDisconnect = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? peakActionOnLogoff = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? peakMinutesToWaitOnLogoff = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? rampDownStartVmOnConnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? rampDownActionOnDisconnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? rampDownMinutesToWaitOnDisconnect = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? rampDownActionOnLogoff = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? rampDownMinutesToWaitOnLogoff = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? offPeakStartVmOnConnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? offPeakActionOnDisconnect = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? offPeakMinutesToWaitOnDisconnect = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? offPeakActionOnLogoff = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation?), int? offPeakMinutesToWaitOnLogoff = default(int?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData ScalingPlanPooledScheduleData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> daysOfWeek, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampUpLoadBalancingAlgorithm, int? rampUpMinimumHostsPct, int? rampUpCapacityThresholdPct, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? peakLoadBalancingAlgorithm, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampDownLoadBalancingAlgorithm, int? rampDownMinimumHostsPct, int? rampDownCapacityThresholdPct, bool? rampDownForceLogoffUsers, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? rampDownStopHostsWhen, int? rampDownWaitTimeMinutes, string rampDownNotificationMessage, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? offPeakLoadBalancingAlgorithm) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.ScalingPlanPooledScheduleData ScalingPlanPooledScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scheduleName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> daysOfWeek = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? scalingMethod = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties createDelete = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampUpLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampUpMinimumHostsPct = default(int?), int? rampUpCapacityThresholdPct = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? peakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampDownLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampDownMinimumHostsPct = default(int?), int? rampDownCapacityThresholdPct = default(int?), bool? rampDownForceLogoffUsers = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? rampDownStopHostsWhen = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen?), int? rampDownWaitTimeMinutes = default(int?), string rampDownNotificationMessage = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? offPeakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch ScalingPlanPooledSchedulePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> daysOfWeek, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampUpLoadBalancingAlgorithm, int? rampUpMinimumHostsPct, int? rampUpCapacityThresholdPct, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? peakLoadBalancingAlgorithm, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampDownLoadBalancingAlgorithm, int? rampDownMinimumHostsPct, int? rampDownCapacityThresholdPct, bool? rampDownForceLogoffUsers, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? rampDownStopHostsWhen, int? rampDownWaitTimeMinutes, string rampDownNotificationMessage, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? offPeakLoadBalancingAlgorithm) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch ScalingPlanPooledSchedulePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string scheduleName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> daysOfWeek = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? scalingMethod = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties createDelete = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampUpLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampUpMinimumHostsPct = default(int?), int? rampUpCapacityThresholdPct = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? peakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampDownLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampDownMinimumHostsPct = default(int?), int? rampDownCapacityThresholdPct = default(int?), bool? rampDownForceLogoffUsers = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? rampDownStopHostsWhen = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen?), int? rampDownWaitTimeMinutes = default(int?), string rampDownNotificationMessage = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? offPeakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule ScalingSchedule(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem> daysOfWeek = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? scalingMethod = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties createDelete = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampUpStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampUpLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampUpMinimumHostsPct = default(int?), int? rampUpCapacityThresholdPct = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime peakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? peakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime rampDownStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? rampDownLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?), int? rampDownMinimumHostsPct = default(int?), int? rampDownCapacityThresholdPct = default(int?), bool? rampDownForceLogoffUsers = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? rampDownStopHostsWhen = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen?), int? rampDownWaitTimeMinutes = default(int?), string rampDownNotificationMessage = null, Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime offPeakStartTime = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? offPeakLoadBalancingAlgorithm = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties ScopedRegistrationTokenProperties(System.DateTimeOffset expirationTimeInUtc = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostConfigurationData SessionHostConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties SessionHostConfigurationPatchProperties(string friendlyName = null, System.Collections.Generic.IDictionary<string, string> vmTags = null, Azure.Core.AzureLocation? vmLocation = default(Azure.Core.AzureLocation?), string vmResourceGroup = null, string vmNamePrefix = null, System.Collections.Generic.IEnumerable<int> availabilityZones = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties networkInfo = null, string vmSizeId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties diskInfo = null, System.Uri customConfigurationScriptUri = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties imageInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties activeDirectoryInfoDomainCredentials = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties securityInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties vmAdminCredentials = null, Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties bootDiagnosticsInfo = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties SessionHostConfigurationProperties(System.DateTimeOffset? version = default(System.DateTimeOffset?), string friendlyName = null, Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration? provisioningState = default(Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration?), System.Collections.Generic.IDictionary<string, string> vmTags = null, Azure.Core.AzureLocation? vmLocation = default(Azure.Core.AzureLocation?), string vmResourceGroup = null, string vmNamePrefix = null, System.Collections.Generic.IEnumerable<int> availabilityZones = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties networkInfo = null, string vmSizeId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties diskInfo = null, System.Uri customConfigurationScriptUri = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties imageInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties domainInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties securityInfo = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties vmAdminCredentials = null, Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties bootDiagnosticsInfo = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostData SessionHostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? activeSessions = default(int?), int? disconnectedSessions = default(int?), int? pendingSessions = default(int?), string objectId = null, bool? allowNewSession = default(bool?), string vmId = null, Azure.Core.ResourceIdentifier resourceId = null, string assignedUser = null, string friendlyName = null, System.DateTimeOffset? statusTimestamp = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSessionHostUpdateOn = default(System.DateTimeOffset?), string sessionHostConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport> sessionHostHealthCheckResults = null, string agentVersion = null, System.DateTimeOffset? lastHeartBeatOn = default(System.DateTimeOffset?), string osVersion = null, int? sessions = default(int?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus? status = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus?), string sxsStackVersion = null, string updateErrorMessage = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState? updateState = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostData SessionHostData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string objectId, System.DateTimeOffset? lastHeartBeatOn, int? sessions, string agentVersion, bool? allowNewSession, string vmId, Azure.Core.ResourceIdentifier resourceId, string assignedUser, string friendlyName, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus? status, System.DateTimeOffset? statusTimestamp, string osVersion, string sxsStackVersion, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState? updateState, System.DateTimeOffset? lastUpdatedOn, string updateErrorMessage, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport> sessionHostHealthCheckResults) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails SessionHostHealthCheckFailureDetails(string message = null, int? errorCode = default(int?), System.DateTimeOffset? lastHealthCheckOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport SessionHostHealthCheckReport(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName? healthCheckName = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult? healthCheckResult = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult?), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails additionalFailureDetails = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData SessionHostManagementData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress SessionHostManagementOperationProgress(System.DateTimeOffset? executionStartOn = default(System.DateTimeOffset?), int? totalSessionHosts = default(int?), int? sessionHostsInProgress = default(int?), int? sessionHostsCompleted = default(int?), int? sessionHostsRollbackFailed = default(int?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress SessionHostManagementProvisioningOperationProgress(System.DateTimeOffset? executionStartOn = default(System.DateTimeOffset?), int? sessionHostsInProgress = default(int?), int? sessionHostsCompleted = default(int?), int? finalSessionHostsCount = default(int?), int? initialSessionHostsCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus SessionHostManagementProvisioningStatus(Azure.Core.ResourceIdentifier id = null, string name = null, double? percentComplete = default(double?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus status = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties SessionHostManagementProvisioningStatusProperties(string correlationId = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress progress = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData sessionHostManagement = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus SessionHostManagementUpdateStatus(Azure.Core.ResourceIdentifier id = null, string name = null, double? percentComplete = default(double?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResponseError error = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus status = default(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus), Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties SessionHostManagementUpdateStatusProperties(string correlationId = null, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress progress = null, System.DateTimeOffset? scheduledOn = default(System.DateTimeOffset?), Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData sessionHostManagement = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch SessionHostPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? allowNewSession = default(bool?), string assignedUser = null, string friendlyName = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.UserSessionData UserSessionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string objectId = null, string userPrincipalName = null, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType? applicationType = default(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType?), Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState? sessionState = default(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState?), string activeDirectoryUserName = null, System.DateTimeOffset? createOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationData VirtualApplicationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string objectId, string description, string friendlyName, string filePath, string msixPackageFamilyName, string msixPackageApplicationId, Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? applicationType, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting commandLineSetting, string commandLineArguments, bool? showInPortal, string iconPath, int? iconIndex, string iconHash, System.BinaryData iconContent) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData VirtualApplicationGroupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string description, string friendlyName, Azure.Core.ResourceIdentifier hostPoolId, Azure.Core.ResourceIdentifier workspaceId, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType applicationGroupType, bool? isCloudPCResource, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData VirtualApplicationGroupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string description, string friendlyName, Azure.Core.ResourceIdentifier hostPoolId, Azure.Core.ResourceIdentifier workspaceId, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType applicationGroupType, bool? isCloudPCResource, bool? showInFeed, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualApplicationGroupData VirtualApplicationGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string objectId = null, string description = null, string friendlyName = null, Azure.Core.ResourceIdentifier hostPoolId = null, Azure.Core.ResourceIdentifier workspaceId = null, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType? applicationGroupType = default(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType?), bool? isCloudPCResource = default(bool?), bool? showInFeed = default(bool?), string oboTenantId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? deploymentScope = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.Core.ResourceIdentifier managedBy = null, Azure.ResourceManager.Models.ArmPlan plan = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch VirtualApplicationGroupPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, string description, string friendlyName) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch VirtualApplicationGroupPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, string description = null, string friendlyName = null, bool? showInFeed = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualDesktopData VirtualDesktopData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string objectId = null, string description = null, string friendlyName = null, string iconHash = null, System.BinaryData iconContent = null) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData VirtualWorkspaceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string description, string friendlyName, System.Collections.Generic.IEnumerable<string> applicationGroupReferences, bool? isCloudPCResource, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData VirtualWorkspaceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string objectId, string description, string friendlyName, System.Collections.Generic.IEnumerable<string> applicationGroupReferences, bool? isCloudPCResource, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess? publicNetworkAccess, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> privateEndpointConnections, Azure.Core.ResourceIdentifier managedBy, string kind, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku, Azure.ResourceManager.Models.ArmPlan plan) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.VirtualWorkspaceData VirtualWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string objectId = null, string description = null, string friendlyName = null, bool? isCloudPCResource = default(bool?), Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection> privateEndpointConnections = null, string oboTenantId = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? deploymentScope = default(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope?), System.Collections.Generic.IEnumerable<string> applicationGroupReferences = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ETag? etag = default(Azure.ETag?), string kind = null, Azure.Core.ResourceIdentifier managedBy = null, Azure.ResourceManager.Models.ArmPlan plan = null, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku sku = null) { throw null; }
    }
    public partial class BootDiagnosticsInfoPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>
    {
        public BootDiagnosticsInfoPatchProperties() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BootDiagnosticsInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>
    {
        public BootDiagnosticsInfoProperties() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationCanaryPolicy : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationCanaryPolicy(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy Auto { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationCreateDeleteProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>
    {
        public DesktopVirtualizationCreateDeleteProperties() { }
        public int? RampDownMaximumHostPoolSize { get { throw null; } set { } }
        public int? RampDownMinimumHostPoolSize { get { throw null; } set { } }
        public int? RampUpMaximumHostPoolSize { get { throw null; } set { } }
        public int? RampUpMinimumHostPoolSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DesktopVirtualizationDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationDeploymentScope : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationDeploymentScope(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope Geographical { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDeploymentScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationDiffDiskOption : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationDiffDiskOption(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption Local { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationDiffDiskPlacement : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationDiffDiskPlacement(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement CacheDisk { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement ResourceDisk { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationDiffDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>
    {
        public DesktopVirtualizationDiffDiskProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskOption? Option { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskPlacement? Placement { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationDirectUdp : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationDirectUdp(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp Default { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationDiskInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>
    {
        public DesktopVirtualizationDiskInfoProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiffDiskProperties DiffDiskSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType? ManagedDiskType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationDomainInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>
    {
        public DesktopVirtualizationDomainInfoProperties(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType joinType) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.ActiveDirectoryInfoProperties ActiveDirectoryInfo { get { throw null; } set { } }
        public string AzureActiveDirectoryInfoMdmProviderGuid { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType JoinType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationDomainJoinType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationDomainJoinType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType ActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType AzureActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainJoinType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationImageInfoPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>
    {
        public DesktopVirtualizationImageInfoPatchProperties() { }
        public Azure.Core.ResourceIdentifier CustomInfoResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType? ImageType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties MarketplaceInfo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationImageInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>
    {
        public DesktopVirtualizationImageInfoProperties(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType imageType) { }
        public Azure.Core.ResourceIdentifier CustomInfoResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType ImageType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties MarketplaceInfo { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationImageType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationImageType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType Custom { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType Marketplace { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationKeyVaultCredentialsPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>
    {
        public DesktopVirtualizationKeyVaultCredentialsPatchProperties() { }
        public System.Uri PasswordKeyVaultSecretUri { get { throw null; } set { } }
        public System.Uri UsernameKeyVaultSecretUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationKeyVaultCredentialsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>
    {
        public DesktopVirtualizationKeyVaultCredentialsProperties(System.Uri usernameKeyVaultSecretUri, System.Uri passwordKeyVaultSecretUri) { }
        public System.Uri PasswordKeyVaultSecretUri { get { throw null; } set { } }
        public System.Uri UsernameKeyVaultSecretUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationManagedPrivateUdp : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationManagedPrivateUdp(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp Default { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationManagementType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationManagementType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType Automated { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    public partial class DesktopVirtualizationMigrationProperties
    {
        public DesktopVirtualizationMigrationProperties() { }
        public string MigrationPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation? Operation { get { throw null; } set { } }
    }
    public partial class DesktopVirtualizationNetworkInfoPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>
    {
        public DesktopVirtualizationNetworkInfoPatchProperties() { }
        public Azure.Core.ResourceIdentifier SecurityGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationNetworkInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>
    {
        public DesktopVirtualizationNetworkInfoProperties(Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.Core.ResourceIdentifier SecurityGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>
    {
        public DesktopVirtualizationPrivateEndpointConnection() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>
    {
        public DesktopVirtualizationPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>
    {
        public DesktopVirtualizationPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationPublicUdp : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationPublicUdp(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp Default { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationRegistrationTokenMinimal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>
    {
        internal DesktopVirtualizationRegistrationTokenMinimal() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRegistrationTokenMinimal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationRelayUdp : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationRelayUdp(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp Default { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationScalingMethodType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationScalingMethodType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType CreateDeletePowerManage { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType PowerManage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationSecurityInfoPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>
    {
        public DesktopVirtualizationSecurityInfoPatchProperties() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType? Type { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationSecurityInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>
    {
        public DesktopVirtualizationSecurityInfoProperties() { }
        public bool? IsSecureBootEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType? Type { get { throw null; } set { } }
        public bool? VTpmEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DesktopVirtualizationSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>
    {
        public DesktopVirtualizationSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSkuTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DesktopVirtualizationSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public partial class DesktopVirtualizationStartMenuItem : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>
    {
        public DesktopVirtualizationStartMenuItem() { }
        public string AppAlias { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStartMenuItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationStopHostsWhen : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationStopHostsWhen(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen ZeroActiveSessions { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen ZeroSessions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DesktopVirtualizationUpdateSessionHostsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>
    {
        public DesktopVirtualizationUpdateSessionHostsContent() { }
        public string ScheduledDateTimeZone { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties Update { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationUpdateSessionHostsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationVirtualMachineDiskType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationVirtualMachineDiskType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType StandardLRS { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType StandardSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DesktopVirtualizationVirtualMachineSecurityType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DesktopVirtualizationVirtualMachineSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType ConfidentialVM { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType Standard { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType left, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationVirtualMachineSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExpandMsixImage : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>
    {
        public ExpandMsixImage() { }
        public System.DateTimeOffset? CertificateExpiry { get { throw null; } set { } }
        public string CertificateName { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ImagePath { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public string PackageAlias { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications> PackageApplications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies> PackageDependencies { get { throw null; } set { } }
        public string PackageFamilyName { get { throw null; } set { } }
        public string PackageFullName { get { throw null; } set { } }
        public string PackageName { get { throw null; } set { } }
        public string PackageRelativePath { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ExpandMsixImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailedSessionHostCleanupPolicySessionHostConfiguration : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailedSessionHostCleanupPolicySessionHostConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration KeepAll { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration KeepNone { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration KeepOne { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration left, Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration left, Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FailHealthCheckOnStagingFailure : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FailHealthCheckOnStagingFailure(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure DoNotFail { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure NeedsAssistance { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure left, Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure left, Azure.ResourceManager.DesktopVirtualization.Models.FailHealthCheckOnStagingFailure right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolLoadBalancerType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolLoadBalancerType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType BreadthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType DepthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType MultiplePersistent { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType Persistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostPoolPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>
    {
        public HostPoolPatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties AgentUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.AllowRdpShortPathWithPrivateLink? AllowRdpShortPathWithPrivateLink { get { throw null; } set { } }
        public string CustomRdpProperty { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDirectUdp? DirectUdp { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? IsValidationEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolLoadBalancerType? LoadBalancerType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationManagedPrivateUdp? ManagedPrivateUdp { get { throw null; } set { } }
        public int? MaxSessionLimit { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? PersonalDesktopAssignmentType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? PreferredAppGroupType { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicUdp? PublicUdp { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch RegistrationInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationRelayUdp? RelayUdp { get { throw null; } set { } }
        public int? Ring { get { throw null; } set { } }
        public string SsoAdfsAuthority { get { throw null; } set { } }
        public string SsoClientId { get { throw null; } set { } }
        public string SsoClientSecretKeyVaultPath { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? SsoSecretType { get { throw null; } set { } }
        public bool? StartVmOnConnect { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string VmTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolProvisioningAction : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolProvisioningAction(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction Cancel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostPoolProvisioningControlContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>
    {
        public HostPoolProvisioningControlContent(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction action) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningAction Action { get { throw null; } }
        public string CancelMessage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolProvisioningControlContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess EnabledForClientsOnly { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess EnabledForSessionHostsOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostPoolRegistrationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>
    {
        public HostPoolRegistrationInfo() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation? RegistrationTokenOperation { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostPoolRegistrationInfoPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>
    {
        public HostPoolRegistrationInfoPatch() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation? RegistrationTokenOperation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationInfoPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolRegistrationTokenOperation : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolRegistrationTokenOperation(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation None { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolRegistrationTokenOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolSsoSecretType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolSsoSecretType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType Certificate { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType CertificateInKeyVault { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType SharedKey { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType SharedKeyInKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolSsoSecretType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType BringYourOwnDesktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType Personal { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType Pooled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostPoolUpdateAction : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostPoolUpdateAction(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Cancel { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Pause { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Resume { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Retry { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Start { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction left, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HostPoolUpdateConfigurationPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>
    {
        public HostPoolUpdateConfigurationPatchProperties() { }
        public int? LogOffDelayMinutes { get { throw null; } set { } }
        public string LogOffMessage { get { throw null; } set { } }
        public int? MaxVmsRemoved { get { throw null; } set { } }
        public bool? ShouldDeleteOriginalVm { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostPoolUpdateConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>
    {
        public HostPoolUpdateConfigurationProperties(int maxVmsRemoved, int logOffDelayMinutes) { }
        public int LogOffDelayMinutes { get { throw null; } set { } }
        public string LogOffMessage { get { throw null; } set { } }
        public int MaxVmsRemoved { get { throw null; } set { } }
        public bool? ShouldDeleteOriginalVm { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostPoolUpdateControlContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>
    {
        public HostPoolUpdateControlContent(Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction action) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateAction Action { get { throw null; } }
        public string CancelMessage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateControlContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportPackageInfoContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>
    {
        public ImportPackageInfoContent() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.AppAttachPackageArchitecture? PackageArchitecture { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ImportPackageInfoContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MaintenanceWindowPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>
    {
        public MaintenanceWindowPatchProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceInfoPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>
    {
        public MarketplaceInfoPatchProperties() { }
        public string ExactVersion { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MarketplaceInfoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>
    {
        public MarketplaceInfoProperties(string offer, string publisher, string sku, string exactVersion) { }
        public string ExactVersion { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MarketplaceInfoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ObsoleteAttribute("This struct is obsolete and will be removed in a future release", false)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationOperation : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationOperation(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Complete { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Hide { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Revoke { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Start { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation Unhide { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation left, Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation left, Azure.ResourceManager.DesktopVirtualization.Models.MigrationOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MsixImageUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>
    {
        public MsixImageUri() { }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixImageUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsixPackageApplications : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>
    {
        public MsixPackageApplications() { }
        public string AppId { get { throw null; } set { } }
        public string AppUserModelId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string IconImageName { get { throw null; } set { } }
        public System.BinaryData RawIcon { get { throw null; } set { } }
        public System.BinaryData RawPng { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageApplications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsixPackageDependencies : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>
    {
        public MsixPackageDependencies() { }
        public string DependencyName { get { throw null; } set { } }
        public string MinVersion { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackageDependencies>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MsixPackagePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>
    {
        public MsixPackagePatch() { }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsActive { get { throw null; } set { } }
        public bool? IsRegularRegistration { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.MsixPackagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PackageTimestamped : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PackageTimestamped(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped NotTimestamped { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped Timestamped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped left, Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped left, Azure.ResourceManager.DesktopVirtualization.Models.PackageTimestamped right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersonalDesktopAssignmentType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersonalDesktopAssignmentType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType Automatic { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType Direct { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType left, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType left, Azure.ResourceManager.DesktopVirtualization.Models.PersonalDesktopAssignmentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreferredAppGroupType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreferredAppGroupType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType None { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType RailApplications { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.PreferredAppGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningStateSessionHostConfiguration : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningStateSessionHostConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration Canceled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration Provisioning { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration left, Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration left, Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RemoteApplicationType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RemoteApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType InBuilt { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType MsixApplication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScalingActionTime : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>
    {
        public ScalingActionTime(int hour, int minute) { }
        public int Hour { get { throw null; } set { } }
        public int Minute { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingHostPoolReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>
    {
        public ScalingHostPoolReference() { }
        public Azure.Core.ResourceIdentifier HostPoolId { get { throw null; } set { } }
        public bool? IsScalingPlanEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScalingHostPoolType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScalingHostPoolType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType Personal { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType Pooled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScalingPlanPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>
    {
        public ScalingPlanPatch() { }
        public string Description { get { throw null; } set { } }
        public string ExclusionTag { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingHostPoolReference> HostPoolReferences { get { throw null; } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version", false)]
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolType? HostPoolType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule> Schedules { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingPlanPersonalSchedulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>
    {
        public ScalingPlanPersonalSchedulePatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? OffPeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? OffPeakActionOnLogoff { get { throw null; } set { } }
        public int? OffPeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? OffPeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? OffPeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? PeakActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? PeakActionOnLogoff { get { throw null; } set { } }
        public int? PeakMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? PeakMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? PeakStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampDownActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampDownActionOnLogoff { get { throw null; } set { } }
        public int? RampDownMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? RampDownMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? RampDownStartVmOnConnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampUpActionOnDisconnect { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? RampUpActionOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior? RampUpAutoStartHosts { get { throw null; } set { } }
        public int? RampUpMinutesToWaitOnDisconnect { get { throw null; } set { } }
        public int? RampUpMinutesToWaitOnLogoff { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? RampUpStartVmOnConnect { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPersonalSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingPlanPooledSchedulePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>
    {
        public ScalingPlanPooledSchedulePatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties CreateDelete { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public int? RampDownCapacityThresholdPct { get { throw null; } set { } }
        public bool? RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampDownMinimumHostsPct { get { throw null; } set { } }
        public string RampDownNotificationMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? RampDownStopHostsWhen { get { throw null; } set { } }
        public int? RampDownWaitTimeMinutes { get { throw null; } set { } }
        public int? RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampUpMinimumHostsPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? ScalingMethod { get { throw null; } set { } }
        public string ScheduleName { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingPlanPooledSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScalingSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>
    {
        public ScalingSchedule() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCreateDeleteProperties CreateDelete { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem> DaysOfWeek { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? OffPeakLoadBalancingAlgorithm { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `OffPeakStartTime` instead.", false)]
        public System.DateTimeOffset? OffPeakStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime OffPeakStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? PeakLoadBalancingAlgorithm { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `PeakStartTime` instead.", false)]
        public System.DateTimeOffset? PeakStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime PeakStartTime { get { throw null; } set { } }
        public int? RampDownCapacityThresholdPct { get { throw null; } set { } }
        public bool? RampDownForceLogoffUsers { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampDownLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampDownMinimumHostsPct { get { throw null; } set { } }
        public string RampDownNotificationMessage { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `RampDownStartTime` instead.", false)]
        public System.DateTimeOffset? RampDownStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampDownStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationStopHostsWhen? RampDownStopHostsWhen { get { throw null; } set { } }
        public int? RampDownWaitTimeMinutes { get { throw null; } set { } }
        public int? RampUpCapacityThresholdPct { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? RampUpLoadBalancingAlgorithm { get { throw null; } set { } }
        public int? RampUpMinimumHostsPct { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `RampUpStartTime` instead.", false)]
        public System.DateTimeOffset? RampUpStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ScalingActionTime RampUpStartTime { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationScalingMethodType? ScalingMethod { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScalingSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScalingScheduleDaysOfWeekItem : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScalingScheduleDaysOfWeekItem(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Friday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Monday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Saturday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Sunday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Thursday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Tuesday { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem left, Azure.ResourceManager.DesktopVirtualization.Models.ScalingScheduleDaysOfWeekItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScopedRegistrationTokenProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>
    {
        public ScopedRegistrationTokenProperties(System.DateTimeOffset expirationTimeInUtc) { }
        public System.DateTimeOffset ExpirationTimeInUtc { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.ScopedRegistrationTokenProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHandlingOperation : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHandlingOperation(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation Deallocate { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation Hibernate { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHandlingOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostAgentUpdatePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>
    {
        public SessionHostAgentUpdatePatchProperties() { }
        public bool? DoesUseSessionHostLocalTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.MaintenanceWindowPatchProperties> MaintenanceWindows { get { throw null; } set { } }
        public string MaintenanceWindowTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType? UpdateType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdatePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostAgentUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>
    {
        public SessionHostAgentUpdateProperties() { }
        public bool? DoesUseSessionHostLocalTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties> MaintenanceWindows { get { throw null; } set { } }
        public string MaintenanceWindowTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType? UpdateType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostAgentUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostComponentUpdateType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostComponentUpdateType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType Default { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostComponentUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>
    {
        public SessionHostConfigurationPatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostConfigurationPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>
    {
        public SessionHostConfigurationPatchProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties ActiveDirectoryInfoDomainCredentials { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoPatchProperties BootDiagnosticsInfo { get { throw null; } set { } }
        public System.Uri CustomConfigurationScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties DiskInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoPatchProperties ImageInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoPatchProperties NetworkInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoPatchProperties SecurityInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsPatchProperties VmAdminCredentials { get { throw null; } set { } }
        public Azure.Core.AzureLocation? VmLocation { get { throw null; } set { } }
        public string VmNamePrefix { get { throw null; } set { } }
        public string VmResourceGroup { get { throw null; } set { } }
        public string VmSizeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VmTags { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>
    {
        public SessionHostConfigurationProperties(string vmNamePrefix, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties networkInfo, string vmSizeId, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties diskInfo, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties imageInfo, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties domainInfo, Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties vmAdminCredentials) { }
        public System.Collections.Generic.IList<int> AvailabilityZones { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.BootDiagnosticsInfoProperties BootDiagnosticsInfo { get { throw null; } set { } }
        public System.Uri CustomConfigurationScriptUri { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDiskInfoProperties DiskInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDomainInfoProperties DomainInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationImageInfoProperties ImageInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationNetworkInfoProperties NetworkInfo { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.ProvisioningStateSessionHostConfiguration? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationSecurityInfoProperties SecurityInfo { get { throw null; } set { } }
        public System.DateTimeOffset? Version { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationKeyVaultCredentialsProperties VmAdminCredentials { get { throw null; } set { } }
        public Azure.Core.AzureLocation? VmLocation { get { throw null; } set { } }
        public string VmNamePrefix { get { throw null; } set { } }
        public string VmResourceGroup { get { throw null; } set { } }
        public string VmSizeId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> VmTags { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostHealthCheckFailureDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>
    {
        internal SessionHostHealthCheckFailureDetails() { }
        public int? ErrorCode { get { throw null; } }
        public System.DateTimeOffset? LastHealthCheckOn { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostHealthCheckName : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostHealthCheckName(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName AppAttachHealthCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName DomainJoinedCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName DomainReachable { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName DomainTrustCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName FSLogixHealthCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName MetaDataServiceCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName MonitoringAgentCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName SupportedEncryptionCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName SxsStackListenerCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName UrlsAccessibleCheck { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName WebRtcRedirectorCheck { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostHealthCheckReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>
    {
        internal SessionHostHealthCheckReport() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckFailureDetails AdditionalFailureDetails { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckName? HealthCheckName { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult? HealthCheckResult { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostHealthCheckResult : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostHealthCheckResult(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult HealthCheckFailed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult HealthCheckSucceeded { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult SessionHostShutdown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostHealthCheckResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostLoadBalancingAlgorithm : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostLoadBalancingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm BreadthFirst { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm DepthFirst { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostLoadBalancingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostMaintenanceWindowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>
    {
        public SessionHostMaintenanceWindowProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostMaintenanceWindowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementOperationProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>
    {
        internal SessionHostManagementOperationProgress() { }
        public System.DateTimeOffset? ExecutionStartOn { get { throw null; } }
        public int? SessionHostsCompleted { get { throw null; } }
        public int? SessionHostsInProgress { get { throw null; } }
        public int? SessionHostsRollbackFailed { get { throw null; } }
        public int? TotalSessionHosts { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>
    {
        public SessionHostManagementPatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>
    {
        public SessionHostManagementPatchProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration? FailedSessionHostCleanupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties Provisioning { get { throw null; } set { } }
        public string ScheduledDateTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationPatchProperties Update { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>
    {
        public SessionHostManagementProperties(string scheduledDateTimeZone, Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties update) { }
        public Azure.ResourceManager.DesktopVirtualization.Models.FailedSessionHostCleanupPolicySessionHostConfiguration? FailedSessionHostCleanupPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties Provisioning { get { throw null; } set { } }
        public string ScheduledDateTimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.HostPoolUpdateConfigurationProperties Update { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementProvisioningOperationProgress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>
    {
        internal SessionHostManagementProvisioningOperationProgress() { }
        public System.DateTimeOffset? ExecutionStartOn { get { throw null; } }
        public int? FinalSessionHostsCount { get { throw null; } }
        public int? InitialSessionHostsCount { get { throw null; } }
        public int? SessionHostsCompleted { get { throw null; } }
        public int? SessionHostsInProgress { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostManagementProvisioningOperationStatus : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostManagementProvisioningOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus ProvisioningSessionHosts { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus ValidatingSessionHostProvisioning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostManagementProvisioningStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>
    {
        internal SessionHostManagementProvisioningStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementProvisioningStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>
    {
        internal SessionHostManagementProvisioningStatusProperties() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningOperationProgress Progress { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData SessionHostManagement { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementProvisioningStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostManagementUpdateOperationStatus : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostManagementUpdateOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Cancelling { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Pausing { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Scheduled { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus UpdatingSessionHosts { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus ValidatingSessionHostUpdate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SessionHostManagementUpdateStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>
    {
        internal SessionHostManagementUpdateStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties Properties { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateOperationStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostManagementUpdateStatusProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>
    {
        internal SessionHostManagementUpdateStatusProperties() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementOperationProgress Progress { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public Azure.ResourceManager.DesktopVirtualization.SessionHostManagementData SessionHostManagement { get { throw null; } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostManagementUpdateStatusProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>
    {
        public SessionHostPatch() { }
        public bool? AllowNewSession { get { throw null; } set { } }
        public string AssignedUser { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostProvisioningConfigurationPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>
    {
        public SessionHostProvisioningConfigurationPatchProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy? CanaryPolicy { get { throw null; } set { } }
        public int? InstanceCount { get { throw null; } set { } }
        public bool? IsDrainModeEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SessionHostProvisioningConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>
    {
        public SessionHostProvisioningConfigurationProperties() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationCanaryPolicy? CanaryPolicy { get { throw null; } set { } }
        public int? InstanceCount { get { throw null; } set { } }
        public bool? IsDrainModeEnabled { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostProvisioningConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostStatus : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostStatus(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Available { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus DomainTrustRelationshipLost { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus FSLogixNotHealthy { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NeedsAssistance { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NoHeartbeat { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus NotJoinedToDomain { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Shutdown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus SxsStackListenerNotReady { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Unavailable { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus UpgradeFailed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SessionHostUpdateState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SessionHostUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState Initial { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState Pending { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState Started { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState left, Azure.ResourceManager.DesktopVirtualization.Models.SessionHostUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SetStartVmOnConnect : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SetStartVmOnConnect(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect Disable { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect Enable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect left, Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect left, Azure.ResourceManager.DesktopVirtualization.Models.SetStartVmOnConnect right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StartupBehavior : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StartupBehavior(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior All { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior None { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior WithAssignedUser { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior left, Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior left, Azure.ResourceManager.DesktopVirtualization.Models.StartupBehavior right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserSessionMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>
    {
        public UserSessionMessage() { }
        public string MessageBody { get { throw null; } set { } }
        public string MessageTitle { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UserSessionState : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UserSessionState(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState Active { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState LogOff { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState Pending { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState Unknown { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState UserProfileDiskMounted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState left, Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState left, Azure.ResourceManager.DesktopVirtualization.Models.UserSessionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualApplicationCommandLineSetting : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualApplicationCommandLineSetting(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting Allow { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting DoNotAllow { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting Require { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualApplicationGroupPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>
    {
        public VirtualApplicationGroupPatch() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public bool? ShowInFeed { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualApplicationGroupType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualApplicationGroupType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType RemoteApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationGroupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualApplicationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>
    {
        public VirtualApplicationPatch() { }
        public Azure.ResourceManager.DesktopVirtualization.Models.RemoteApplicationType? ApplicationType { get { throw null; } set { } }
        public string CommandLineArguments { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationCommandLineSetting? CommandLineSetting { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public int? IconIndex { get { throw null; } set { } }
        public string IconPath { get { throw null; } set { } }
        public string MsixPackageApplicationId { get { throw null; } set { } }
        public string MsixPackageFamilyName { get { throw null; } set { } }
        public bool? ShowInPortal { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is no longer supported by the service and will be removed in a future version.")]
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualApplicationType : System.IEquatable<Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType Desktop { get { throw null; } }
        public static Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType RemoteApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType left, Azure.ResourceManager.DesktopVirtualization.Models.VirtualApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualDesktopPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>
    {
        public VirtualDesktopPatch() { }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        [System.ObsoleteAttribute("This property is no longer supported by the service and will be removed in a future version.")]
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualDesktopPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>
    {
        public VirtualWorkspacePatch() { }
        public System.Collections.Generic.IList<string> ApplicationGroupReferences { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.DesktopVirtualization.Models.DesktopVirtualizationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DesktopVirtualization.Models.VirtualWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
