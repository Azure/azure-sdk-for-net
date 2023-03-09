namespace Azure.ResourceManager.Maintenance
{
    public partial class MaintenanceApplyUpdateCollection : Azure.ResourceManager.ArmCollection
    {
        protected MaintenanceApplyUpdateCollection() { }
        public virtual Azure.Response<bool> Exists(string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> Get(string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> GetAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceApplyUpdateData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceApplyUpdateData() { }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus? Status { get { throw null; } set { } }
    }
    public partial class MaintenanceApplyUpdateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceApplyUpdateResource() { }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceType, string resourceName, string applyUpdateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>, System.Collections.IEnumerable
    {
        protected MaintenanceConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Maintenance.MaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceName, Azure.ResourceManager.Maintenance.MaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public MaintenanceConfigurationData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExtensionProperties { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.InputPatchConfiguration InstallPatches { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceScope? MaintenanceScope { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string RecurEvery { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility? Visibility { get { throw null; } set { } }
    }
    public partial class MaintenanceConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceConfigurationResource() { }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string resourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> Update(Azure.ResourceManager.Maintenance.MaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> UpdateAsync(Azure.ResourceManager.Maintenance.MaintenanceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MaintenanceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdateByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceGetApplyUpdatesByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.Maintenance.Models.ResourceGroupResourceGetApplyUpdatesByParentOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource>> GetMaintenanceApplyUpdateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string applyUpdateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource GetMaintenanceApplyUpdateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateCollection GetMaintenanceApplyUpdates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfiguration(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource>> GetMaintenanceConfigurationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource GetMaintenanceConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceConfigurationCollection GetMaintenanceConfigurations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceConfigurationResource> GetMaintenanceConfigurationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> GetMaintenanceNestedResourceConfigurationAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> GetMaintenanceNestedResourceConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource GetMaintenanceNestedResourceConfigurationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentCollection GetMaintenanceNestedResourceConfigurationAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> GetMaintenancePublicConfiguration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>> GetMaintenancePublicConfigurationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource GetMaintenancePublicConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationCollection GetMaintenancePublicConfigurations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> GetMaintenanceResourceConfigurationAssignment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> GetMaintenanceResourceConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource GetMaintenanceResourceConfigurationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentCollection GetMaintenanceResourceConfigurationAssignments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> GetMaintenanceResourceGroupConfigurationAssignment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> GetMaintenanceResourceGroupConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource GetMaintenanceResourceGroupConfigurationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentCollection GetMaintenanceResourceGroupConfigurationAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> GetMaintenanceSubscriptionConfigurationAssignment(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> GetMaintenanceSubscriptionConfigurationAssignmentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource GetMaintenanceSubscriptionConfigurationAssignmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentCollection GetMaintenanceSubscriptionConfigurationAssignments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.MaintenanceUpdate> GetUpdates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.MaintenanceUpdate> GetUpdatesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maintenance.Models.MaintenanceUpdate> GetUpdatesByParent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maintenance.Models.MaintenanceUpdate> GetUpdatesByParentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceNestedResourceConfigurationAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>, System.Collections.IEnumerable
    {
        protected MaintenanceNestedResourceConfigurationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> Get(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> GetAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceNestedResourceConfigurationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceNestedResourceConfigurationAssignmentResource() { }
        public virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceNestedResourceConfigurationAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenancePublicConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>, System.Collections.IEnumerable
    {
        protected MaintenancePublicConfigurationCollection() { }
        public virtual Azure.Response<bool> Exists(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> Get(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>> GetAsync(string resourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenancePublicConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenancePublicConfigurationResource() { }
        public virtual Azure.ResourceManager.Maintenance.MaintenanceConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenancePublicConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceResourceConfigurationAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>, System.Collections.IEnumerable
    {
        protected MaintenanceResourceConfigurationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> Get(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> GetAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceResourceConfigurationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceResourceConfigurationAssignmentResource() { }
        public virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceType, string resourceName, string configurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceConfigurationAssignmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceResourceGroupConfigurationAssignmentCollection : Azure.ResourceManager.ArmCollection
    {
        protected MaintenanceResourceGroupConfigurationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> Get(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> GetAsync(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceResourceGroupConfigurationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceResourceGroupConfigurationAssignmentResource() { }
        public virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> Delete(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> Get(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> GetAsync(string resourceGroupName, string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource> Update(string resourceGroupName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceResourceGroupConfigurationAssignmentResource>> UpdateAsync(string resourceGroupName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MaintenanceSubscriptionConfigurationAssignmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>, System.Collections.IEnumerable
    {
        protected MaintenanceSubscriptionConfigurationAssignmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> Get(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> GetAsync(string configurationAssignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MaintenanceSubscriptionConfigurationAssignmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MaintenanceSubscriptionConfigurationAssignmentResource() { }
        public virtual Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string configurationAssignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource> Update(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maintenance.MaintenanceSubscriptionConfigurationAssignmentResource>> UpdateAsync(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Maintenance.Models
{
    public partial class InputLinuxParameters
    {
        public InputLinuxParameters() { }
        public System.Collections.Generic.IList<string> ClassificationsToInclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> PackageNameMasksToInclude { get { throw null; } }
    }
    public partial class InputPatchConfiguration
    {
        public InputPatchConfiguration() { }
        public Azure.ResourceManager.Maintenance.Models.InputLinuxParameters LinuxParameters { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.RebootOption? RebootSetting { get { throw null; } set { } }
        public Azure.ResourceManager.Maintenance.Models.InputWindowsParameters WindowsParameters { get { throw null; } set { } }
    }
    public partial class InputWindowsParameters
    {
        public InputWindowsParameters() { }
        public System.Collections.Generic.IList<string> ClassificationsToInclude { get { throw null; } }
        public bool? ExcludeKbsRequiringReboot { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KbNumbersToExclude { get { throw null; } }
        public System.Collections.Generic.IList<string> KbNumbersToInclude { get { throw null; } }
    }
    public partial class MaintenanceConfigurationAssignmentData : Azure.ResourceManager.Models.ResourceData
    {
        public MaintenanceConfigurationAssignmentData() { }
        public System.Collections.Generic.IDictionary<string, string> ExtensionProperties { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public Azure.Core.ResourceIdentifier MaintenanceConfigurationId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGroups { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.TagSettingsProperties TagSettings { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceConfigurationVisibility : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceConfigurationVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility Custom { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility left, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility left, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceImpactType : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceImpactType(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType Freeze { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType None { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType Redeploy { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType Restart { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType left, Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType left, Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceScope : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceScope(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Extension { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Host { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope InGuestPatch { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope OSImage { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope Resource { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope SqlDB { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceScope SqlManagedInstance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceScope left, Azure.ResourceManager.Maintenance.Models.MaintenanceScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceScope left, Azure.ResourceManager.Maintenance.Models.MaintenanceScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceUpdate
    {
        internal MaintenanceUpdate() { }
        public int? ImpactDurationInSec { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceImpactType? ImpactType { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceScope? MaintenanceScope { get { throw null; } }
        public System.DateTimeOffset? NotBefore { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MaintenanceUpdateStatus : System.IEquatable<Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MaintenanceUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus RetryLater { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus RetryNow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus left, Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus left, Azure.ResourceManager.Maintenance.Models.MaintenanceUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RebootOption : System.IEquatable<Azure.ResourceManager.Maintenance.Models.RebootOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RebootOption(string value) { throw null; }
        public static Azure.ResourceManager.Maintenance.Models.RebootOption Always { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.RebootOption IfRequired { get { throw null; } }
        public static Azure.ResourceManager.Maintenance.Models.RebootOption Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maintenance.Models.RebootOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maintenance.Models.RebootOption left, Azure.ResourceManager.Maintenance.Models.RebootOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maintenance.Models.RebootOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maintenance.Models.RebootOption left, Azure.ResourceManager.Maintenance.Models.RebootOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions
    {
        public ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData data) { }
        public string ConfigurationAssignmentName { get { throw null; } }
        public Azure.ResourceManager.Maintenance.Models.MaintenanceConfigurationAssignmentData Data { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceParentName { get { throw null; } }
        public string ResourceParentType { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions
    {
        public ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName) { }
        public string ConfigurationAssignmentName { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceParentName { get { throw null; } }
        public string ResourceParentType { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class ResourceGroupResourceGetApplyUpdatesByParentOptions
    {
        public ResourceGroupResourceGetApplyUpdatesByParentOptions(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName) { }
        public string ApplyUpdateName { get { throw null; } }
        public string ProviderName { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceParentName { get { throw null; } }
        public string ResourceParentType { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public enum TagOperator
    {
        All = 0,
        Any = 1,
    }
    public partial class TagSettingsProperties
    {
        public TagSettingsProperties() { }
        public Azure.ResourceManager.Maintenance.Models.TagOperator? FilterOperator { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Tags { get { throw null; } }
    }
}
