namespace Azure.ResourceManager.DevTestLabs
{
    public partial class ArmTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>, System.Collections.IEnumerable
    {
        protected ArmTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArmTemplateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArmTemplateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.BinaryData Contents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public string Icon { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ParametersValueFileInfo> ParametersValueFilesInfo { get { throw null; } }
        public string Publisher { get { throw null; } }
    }
    public partial class ArmTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArmTemplateResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ArmTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactResource>, System.Collections.IEnumerable
    {
        protected ArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.ArtifactResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ArtifactResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.ArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.ArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArtifactData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string FilePath { get { throw null; } }
        public string Icon { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetOSType { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class ArtifactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ArmTemplateInfo> GenerateArmTemplate(Azure.ResourceManager.DevTestLabs.Models.GenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ArmTemplateInfo>> GenerateArmTemplateAsync(Azure.ResourceManager.DevTestLabs.Models.GenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ArtifactSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>, System.Collections.IEnumerable
    {
        protected ArtifactSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ArtifactSourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ArtifactSourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArmTemplateFolderPath { get { throw null; } set { } }
        public string BranchRef { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SecurityToken { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.SourceControlType? SourceType { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Status { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class ArtifactSourceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ArtifactSourceResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ArtifactSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource> GetArmTemplate(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArmTemplateResource>> GetArmTemplateAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.ArmTemplateCollection GetArmTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource> GetArtifact(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactResource>> GetArtifactAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.ArtifactCollection GetArtifacts() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> Update(Azure.ResourceManager.DevTestLabs.Models.ArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CustomImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.CustomImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.CustomImageResource>, System.Collections.IEnumerable
    {
        protected CustomImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.CustomImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.CustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.CustomImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.CustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.CustomImageResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.CustomImageResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.CustomImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.CustomImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.CustomImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.CustomImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public CustomImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Author { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.CustomImagePropertiesFromPlan CustomImagePlan { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DataDiskStorageTypeInfo> DataDiskStorageInfo { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsPlanAuthorized { get { throw null; } set { } }
        public string ManagedImageId { get { throw null; } set { } }
        public string ManagedSnapshotId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.CustomImagePropertiesCustom Vhd { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.CustomImagePropertiesFromVm Vm { get { throw null; } set { } }
    }
    public partial class CustomImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomImageResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.CustomImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> Update(Azure.ResourceManager.DevTestLabs.Models.CustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.CustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevTestLabsExtensions
    {
        public static Azure.ResourceManager.DevTestLabs.ArmTemplateResource GetArmTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ArtifactResource GetArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ArtifactSourceResource GetArtifactSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.CustomImageResource GetCustomImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DiskResource GetDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource GetDtlEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.FormulaResource GetFormulaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> GetLab(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> GetLabAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabCostResource GetLabCostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabResource GetLabResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabCollection GetLabs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabResource> GetLabs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabResource> GetLabsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabScheduleResource GetLabScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource GetLabUserServicefabricScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource GetLabVirtualMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource GetLabVirtualmachineScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.NotificationChannelResource GetNotificationChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.PolicyResource GetPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.Models.OperationMetadata> GetProviderOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.Models.OperationMetadata> GetProviderOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> GetSchedule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> GetScheduleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ScheduleResource GetScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ScheduleCollection GetSchedules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.ScheduleResource> GetSchedules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ScheduleResource> GetSchedulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.SecretResource GetSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ServiceFabricResource GetServiceFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.ServiceRunnerResource GetServiceRunnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.UserResource GetUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.VirtualNetworkResource GetVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DiskResource>, System.Collections.IEnumerable
    {
        protected DiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DiskResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DiskResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DiskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiskBlobName { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.StorageType? DiskType { get { throw null; } set { } }
        public System.Uri DiskUri { get { throw null; } set { } }
        public string HostCaching { get { throw null; } set { } }
        public string LeasedByLabVmId { get { throw null; } set { } }
        public string ManagedDiskId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DiskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Attach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.AttachDiskProperties attachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AttachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.AttachDiskProperties attachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Detach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDiskProperties detachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDiskProperties detachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> Update(Azure.ResourceManager.DevTestLabs.Models.DiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DtlEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>, System.Collections.IEnumerable
    {
        protected DtlEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DtlEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DtlEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DtlEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DtlEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArmTemplateDisplayName { get { throw null; } set { } }
        public string CreatedByUser { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.EnvironmentDeploymentProperties DeploymentProperties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceGroupId { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DtlEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DtlEnvironmentResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DtlEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> Update(Azure.ResourceManager.DevTestLabs.Models.DtlEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DtlEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FormulaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.FormulaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.FormulaResource>, System.Collections.IEnumerable
    {
        protected FormulaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.FormulaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.FormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.FormulaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.FormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.FormulaResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.FormulaResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.FormulaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.FormulaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.FormulaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.FormulaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FormulaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FormulaData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Author { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachineCreationParameter FormulaContent { get { throw null; } set { } }
        public string LabVmId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class FormulaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FormulaResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.FormulaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> Update(Azure.ResourceManager.DevTestLabs.Models.FormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.FormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabResource>, System.Collections.IEnumerable
    {
        protected LabCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.LabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.LabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabCostCollection : Azure.ResourceManager.ArmCollection
    {
        protected LabCostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabCostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabCostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabCostData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabCostData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public double? EstimatedLabCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.LabCostDetailsProperties> LabCostDetails { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.LabResourceCostProperties> ResourceCosts { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.TargetCostProperties TargetCost { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class LabCostResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabCostResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.LabCostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabCostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.LabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabCostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.LabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.Models.LabAnnouncementProperties Announcement { get { throw null; } set { } }
        public string ArtifactsStorageAccount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultPremiumStorageAccount { get { throw null; } }
        public string DefaultStorageAccount { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission? EnvironmentPermission { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.StorageType? LabStorageType { get { throw null; } set { } }
        public string LoadBalancerId { get { throw null; } }
        public System.Collections.Generic.IList<string> MandatoryArtifactsResourceIdsLinux { get { throw null; } }
        public System.Collections.Generic.IList<string> MandatoryArtifactsResourceIdsWindows { get { throw null; } }
        public string NetworkSecurityGroupId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk? PremiumDataDisks { get { throw null; } set { } }
        public string PremiumDataDiskStorageAccount { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicIPId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.LabSupportProperties Support { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string VmCreationResourceGroup { get { throw null; } }
    }
    public partial class LabResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.LabData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClaimAnyVm(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimAnyVmAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateEnvironment(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachineCreationParameter labVirtualMachineCreationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateEnvironmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachineCreationParameter labVirtualMachineCreationParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.EvaluatePoliciesResponse> EvaluatePoliciesPolicySet(string name, Azure.ResourceManager.DevTestLabs.Models.EvaluatePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.EvaluatePoliciesResponse>> EvaluatePoliciesPolicySetAsync(string name, Azure.ResourceManager.DevTestLabs.Models.EvaluatePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportResourceUsage(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ExportResourceUsageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportResourceUsageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ExportResourceUsageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.GenerateUploadUriResponse> GenerateUploadUri(Azure.ResourceManager.DevTestLabs.Models.GenerateUploadUriParameter generateUploadUriParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.GenerateUploadUriResponse>> GenerateUploadUriAsync(Azure.ResourceManager.DevTestLabs.Models.GenerateUploadUriParameter generateUploadUriParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource> GetArtifactSource(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ArtifactSourceResource>> GetArtifactSourceAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.ArtifactSourceCollection GetArtifactSources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource> GetCustomImage(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.CustomImageResource>> GetCustomImageAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.CustomImageCollection GetCustomImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource> GetFormula(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.FormulaResource>> GetFormulaAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.FormulaCollection GetFormulas() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.Models.GalleryImage> GetGalleryImages(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.Models.GalleryImage> GetGalleryImagesAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource> GetLabCost(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabCostResource>> GetLabCostAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.LabCostCollection GetLabCosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> GetLabSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> GetLabScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.LabScheduleCollection GetLabSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> GetLabVirtualMachine(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> GetLabVirtualMachineAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.LabVirtualMachineCollection GetLabVirtualMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> GetNotificationChannel(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> GetNotificationChannelAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.NotificationChannelCollection GetNotificationChannels() { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.PolicyCollection GetPolicies(string policySetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> GetPolicy(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> GetPolicyAsync(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> GetServiceRunner(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> GetServiceRunnerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.ServiceRunnerCollection GetServiceRunners() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> GetUser(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> GetUserAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.UserCollection GetUsers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> GetVirtualNetwork(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> GetVirtualNetworkAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.VirtualNetworkCollection GetVirtualNetworks() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportVirtualMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ImportLabVirtualMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportVirtualMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ImportLabVirtualMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource> Update(Azure.ResourceManager.DevTestLabs.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.LabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabScheduleResource>, System.Collections.IEnumerable
    {
        protected LabScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabScheduleResource> GetApplicable(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabScheduleResource> GetApplicableAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.LabScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.LabScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabUserServicefabricScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>, System.Collections.IEnumerable
    {
        protected LabUserServicefabricScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabUserServicefabricScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabUserServicefabricScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string serviceFabricName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabVirtualMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>, System.Collections.IEnumerable
    {
        protected LabVirtualMachineCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.LabVirtualMachineData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualMachineData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LabVirtualMachineData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AllowClaim { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule ApplicableSchedule { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.ArtifactDeploymentStatusProperties ArtifactDeploymentStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArtifactInstallProperties> Artifacts { get { throw null; } }
        public string ComputeId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties ComputeVm { get { throw null; } }
        public string CreatedByUser { get { throw null; } }
        public string CreatedByUserId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CustomImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties> DataDiskParameters { get { throw null; } }
        public bool? DisallowPublicIPAddress { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.GalleryImageReference GalleryImageReference { get { throw null; } set { } }
        public bool? IsAuthenticationWithSshKey { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public string LabVirtualNetworkId { get { throw null; } set { } }
        public string LastKnownPowerState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.NetworkInterfaceProperties NetworkInterface { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public string OSType { get { throw null; } }
        public string OwnerObjectId { get { throw null; } set { } }
        public string OwnerUserPrincipalName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ScheduleCreationParameter> ScheduleParameters { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string SshKey { get { throw null; } set { } }
        public string StorageType { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource? VirtualMachineCreationSource { get { throw null; } }
    }
    public partial class LabVirtualMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabVirtualMachineResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.LabVirtualMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApplyArtifacts(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApplyArtifactsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Claim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDataDiskProperties detachDataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDataDiskProperties detachDataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> GetLabVirtualmachineSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> GetLabVirtualmachineScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleCollection GetLabVirtualmachineSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.RdpConnection> GetRdpFileContents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.RdpConnection>> GetRdpFileContentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ResizeLabVirtualMachineProperties resizeLabVirtualMachineProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ResizeLabVirtualMachineProperties resizeLabVirtualMachineProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TransferDisks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TransferDisksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UnClaim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource> Update(Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualMachineResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachinePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LabVirtualmachineScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>, System.Collections.IEnumerable
    {
        protected LabVirtualmachineScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LabVirtualmachineScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LabVirtualmachineScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string virtualMachineName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabVirtualmachineScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>, System.Collections.IEnumerable
    {
        protected NotificationChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.NotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.NotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationChannelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public NotificationChannelData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EmailRecipient { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.Event> Events { get { throw null; } }
        public string NotificationLocale { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public System.Uri WebHookUri { get { throw null; } set { } }
    }
    public partial class NotificationChannelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationChannelResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.NotificationChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Notify(Azure.ResourceManager.DevTestLabs.Models.NotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NotifyAsync(Azure.ResourceManager.DevTestLabs.Models.NotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource> Update(Azure.ResourceManager.DevTestLabs.Models.NotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.NotificationChannelResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.NotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.PolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.PolicyResource>, System.Collections.IEnumerable
    {
        protected PolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.PolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.PolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.PolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.PolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.PolicyResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.PolicyResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.PolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.PolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.PolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.PolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public PolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType? EvaluatorType { get { throw null; } set { } }
        public string FactData { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.PolicyFactName? FactName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.PolicyStatus? Status { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class PolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.PolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string policySetName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource> Update(Azure.ResourceManager.DevTestLabs.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.PolicyResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.PolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ScheduleResource>, System.Collections.IEnumerable
    {
        protected ScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.ScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.ScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.ScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ScheduleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ScheduleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DailyRecurrenceTime { get { throw null; } set { } }
        public int? HourlyRecurrenceMinute { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.NotificationSettings NotificationSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Status { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TaskType { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.WeekDetails WeeklyRecurrence { get { throw null; } set { } }
    }
    public partial class ScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Retarget(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.RetargetScheduleProperties retargetScheduleProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RetargetAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.RetargetScheduleProperties retargetScheduleProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.SecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.SecretResource>, System.Collections.IEnumerable
    {
        protected SecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.SecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.SecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.SecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.SecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.SecretResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.SecretResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.SecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.SecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.SecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.SecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecretData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public SecretData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SecretResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SecretResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.SecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> Update(Azure.ResourceManager.DevTestLabs.Models.SecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.SecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>, System.Collections.IEnumerable
    {
        protected ServiceFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceFabricData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceFabricData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule ApplicableSchedule { get { throw null; } }
        public string EnvironmentId { get { throw null; } set { } }
        public string ExternalServiceFabricId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class ServiceFabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceFabricResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ServiceFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource> GetLabUserServicefabricSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleResource>> GetLabUserServicefabricScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.LabUserServicefabricScheduleCollection GetLabUserServicefabricSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> Update(Azure.ResourceManager.DevTestLabs.Models.ServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceRunnerCollection : Azure.ResourceManager.ArmCollection
    {
        protected ServiceRunnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.ServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceRunnerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ServiceRunnerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.Models.IdentityProperties Identity { get { throw null; } set { } }
    }
    public partial class ServiceRunnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceRunnerResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.ServiceRunnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.ServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.ServiceRunnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.ServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.UserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.UserResource>, System.Collections.IEnumerable
    {
        protected UserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.UserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.UserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.UserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.UserResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.UserResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.UserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.UserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.UserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.UserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class UserData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public UserData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.UserIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.UserSecretStore SecretStore { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class UserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected UserResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.UserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource> GetDisk(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DiskResource>> GetDiskAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DiskCollection GetDisks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource> GetDtlEnvironment(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DtlEnvironmentResource>> GetDtlEnvironmentAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DtlEnvironmentCollection GetDtlEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource> GetSecret(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.SecretResource>> GetSecretAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.SecretCollection GetSecrets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource> GetServiceFabric(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.ServiceFabricResource>> GetServiceFabricAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.ServiceFabricCollection GetServiceFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource> Update(Azure.ResourceManager.DevTestLabs.Models.UserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.UserResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.UserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.VirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VirtualNetworkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.Subnet> AllowedSubnets { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ExternalProviderResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ExternalSubnet> ExternalSubnets { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.SubnetOverride> SubnetOverrides { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class VirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.VirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource> Update(Azure.ResourceManager.DevTestLabs.Models.VirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.VirtualNetworkResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.VirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevTestLabs.Models
{
    public partial class ApplicableSchedule : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicableSchedule(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.ScheduleData LabVmsShutdown { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.ScheduleData LabVmsStartup { get { throw null; } set { } }
    }
    public partial class ApplyArtifactsContent
    {
        public ApplyArtifactsContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArtifactInstallProperties> Artifacts { get { throw null; } }
    }
    public partial class ArmTemplateInfo
    {
        internal ArmTemplateInfo() { }
        public System.BinaryData Parameters { get { throw null; } }
        public System.BinaryData Template { get { throw null; } }
    }
    public partial class ArmTemplateParameterProperties
    {
        public ArmTemplateParameterProperties() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ArtifactDeploymentStatusProperties
    {
        internal ArtifactDeploymentStatusProperties() { }
        public int? ArtifactsApplied { get { throw null; } }
        public string DeploymentStatus { get { throw null; } }
        public int? TotalArtifacts { get { throw null; } }
    }
    public partial class ArtifactInstallProperties
    {
        public ArtifactInstallProperties() { }
        public string ArtifactId { get { throw null; } set { } }
        public string ArtifactTitle { get { throw null; } set { } }
        public string DeploymentStatusMessage { get { throw null; } set { } }
        public System.DateTimeOffset? InstallOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArtifactParameterProperties> Parameters { get { throw null; } }
        public string Status { get { throw null; } set { } }
        public string VmExtensionStatusMessage { get { throw null; } set { } }
    }
    public partial class ArtifactParameterProperties
    {
        public ArtifactParameterProperties() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ArtifactSourcePatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public ArtifactSourcePatch() { }
    }
    public partial class AttachDiskProperties
    {
        public AttachDiskProperties() { }
        public string LeasedByLabVmId { get { throw null; } set { } }
    }
    public partial class AttachNewDataDiskOptions
    {
        public AttachNewDataDiskOptions() { }
        public string DiskName { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.StorageType? DiskType { get { throw null; } set { } }
    }
    public partial class ComputeDataDisk
    {
        internal ComputeDataDisk() { }
        public int? DiskSizeGiB { get { throw null; } }
        public System.Uri DiskUri { get { throw null; } }
        public string ManagedDiskId { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class ComputeVmInstanceViewStatus
    {
        internal ComputeVmInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ComputeVmProperties
    {
        internal ComputeVmProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DataDiskIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk> DataDisks { get { throw null; } }
        public string NetworkInterfaceId { get { throw null; } }
        public string OSDiskId { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus> Statuses { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class CostThresholdProperties
    {
        public CostThresholdProperties() { }
        public Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus? DisplayOnChart { get { throw null; } set { } }
        public string NotificationSent { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus? SendNotificationWhenExceeded { get { throw null; } set { } }
        public string ThresholdId { get { throw null; } set { } }
        public double? ThresholdValue { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostThresholdStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostThresholdStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus left, Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus left, Azure.ResourceManager.DevTestLabs.Models.CostThresholdStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CostType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.CostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CostType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.CostType Projected { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.CostType Reported { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.CostType Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.CostType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.CostType left, Azure.ResourceManager.DevTestLabs.Models.CostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.CostType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.CostType left, Azure.ResourceManager.DevTestLabs.Models.CostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomImageOSType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomImageOSType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType left, Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType left, Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomImagePatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public CustomImagePatch() { }
    }
    public partial class CustomImagePropertiesCustom
    {
        public CustomImagePropertiesCustom(Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType osType) { }
        public string ImageName { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.CustomImageOSType OSType { get { throw null; } set { } }
        public bool? SysPrep { get { throw null; } set { } }
    }
    public partial class CustomImagePropertiesFromPlan
    {
        public CustomImagePropertiesFromPlan() { }
        public string Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
    }
    public partial class CustomImagePropertiesFromVm
    {
        public CustomImagePropertiesFromVm() { }
        public Azure.ResourceManager.DevTestLabs.Models.LinuxOSState? LinuxOSState { get { throw null; } set { } }
        public string SourceVmId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.WindowsOSState? WindowsOSState { get { throw null; } set { } }
    }
    public partial class DataDiskProperties
    {
        public DataDiskProperties() { }
        public Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskOptions AttachNewDataDiskOptions { get { throw null; } set { } }
        public string ExistingLabDiskId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.HostCachingOption? HostCaching { get { throw null; } set { } }
    }
    public partial class DataDiskStorageTypeInfo
    {
        public DataDiskStorageTypeInfo() { }
        public string Lun { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.StorageType? StorageType { get { throw null; } set { } }
    }
    public partial class DetachDataDiskProperties
    {
        public DetachDataDiskProperties() { }
        public string ExistingLabDiskId { get { throw null; } set { } }
    }
    public partial class DetachDiskProperties
    {
        public DetachDiskProperties() { }
        public string LeasedByLabVmId { get { throw null; } set { } }
    }
    public partial class DiskPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DiskPatch() { }
    }
    public partial class DtlEnvironmentPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DtlEnvironmentPatch() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.EnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.EnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.EnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.EnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.EnableStatus left, Azure.ResourceManager.DevTestLabs.Models.EnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.EnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.EnableStatus left, Azure.ResourceManager.DevTestLabs.Models.EnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnvironmentDeploymentProperties
    {
        public EnvironmentDeploymentProperties() { }
        public string ArmTemplateId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArmTemplateParameterProperties> Parameters { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnvironmentPermission : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnvironmentPermission(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission Contributor { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission left, Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission left, Azure.ResourceManager.DevTestLabs.Models.EnvironmentPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EvaluatePoliciesContent
    {
        public EvaluatePoliciesContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.EvaluatePoliciesProperties> Policies { get { throw null; } }
    }
    public partial class EvaluatePoliciesProperties
    {
        public EvaluatePoliciesProperties() { }
        public string FactData { get { throw null; } set { } }
        public string FactName { get { throw null; } set { } }
        public string UserObjectId { get { throw null; } set { } }
        public string ValueOffset { get { throw null; } set { } }
    }
    public partial class EvaluatePoliciesResponse
    {
        internal EvaluatePoliciesResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.PolicySetResult> Results { get { throw null; } }
    }
    public partial class Event
    {
        public Event() { }
        public Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType? EventName { get { throw null; } set { } }
    }
    public partial class ExportResourceUsageContent
    {
        public ExportResourceUsageContent() { }
        public System.Uri BlobStorageAbsoluteSasUri { get { throw null; } set { } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } set { } }
    }
    public partial class ExternalSubnet
    {
        internal ExternalSubnet() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileUploadOption : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.FileUploadOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileUploadOption(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.FileUploadOption None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.FileUploadOption UploadFilesAndGenerateSasTokens { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.FileUploadOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.FileUploadOption left, Azure.ResourceManager.DevTestLabs.Models.FileUploadOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.FileUploadOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.FileUploadOption left, Azure.ResourceManager.DevTestLabs.Models.FileUploadOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FormulaPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public FormulaPatch() { }
    }
    public partial class GalleryImage : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GalleryImage(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Author { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Icon { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.GalleryImageReference ImageReference { get { throw null; } set { } }
        public bool? IsPlanAuthorized { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
    }
    public partial class GalleryImageReference
    {
        public GalleryImageReference() { }
        public string Offer { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class GenerateArmTemplateContent
    {
        public GenerateArmTemplateContent() { }
        public Azure.ResourceManager.DevTestLabs.Models.FileUploadOption? FileUploadOptions { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ParameterInfo> Parameters { get { throw null; } }
        public string VirtualMachineName { get { throw null; } set { } }
    }
    public partial class GenerateUploadUriParameter
    {
        public GenerateUploadUriParameter() { }
        public string BlobName { get { throw null; } set { } }
    }
    public partial class GenerateUploadUriResponse
    {
        internal GenerateUploadUriResponse() { }
        public System.Uri UploadUri { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HostCachingOption : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.HostCachingOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HostCachingOption(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.HostCachingOption None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.HostCachingOption ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.HostCachingOption ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.HostCachingOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.HostCachingOption left, Azure.ResourceManager.DevTestLabs.Models.HostCachingOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.HostCachingOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.HostCachingOption left, Azure.ResourceManager.DevTestLabs.Models.HostCachingOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityProperties
    {
        public IdentityProperties() { }
        public System.Uri ClientSecretUri { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType? ManagedIdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ImportLabVirtualMachineContent
    {
        public ImportLabVirtualMachineContent() { }
        public string DestinationVirtualMachineName { get { throw null; } set { } }
        public string SourceVirtualMachineResourceId { get { throw null; } set { } }
    }
    public partial class InboundNatRule
    {
        public InboundNatRule() { }
        public int? BackendPort { get { throw null; } set { } }
        public int? FrontendPort { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.TransportProtocol? TransportProtocol { get { throw null; } set { } }
    }
    public partial class LabAnnouncementProperties
    {
        public LabAnnouncementProperties() { }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Enabled { get { throw null; } set { } }
        public bool? Expired { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Markdown { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class LabCostDetailsProperties
    {
        internal LabCostDetailsProperties() { }
        public double? Cost { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.CostType? CostType { get { throw null; } }
        public System.DateTimeOffset? On { get { throw null; } }
    }
    public partial class LabPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public LabPatch() { }
    }
    public partial class LabResourceCostProperties
    {
        internal LabResourceCostProperties() { }
        public string ExternalResourceId { get { throw null; } }
        public double? ResourceCost { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string Resourcename { get { throw null; } }
        public string ResourceOwner { get { throw null; } }
        public string ResourcePricingTier { get { throw null; } }
        public string ResourceStatus { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string ResourceUId { get { throw null; } }
    }
    public partial class LabSupportProperties
    {
        public LabSupportProperties() { }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Enabled { get { throw null; } set { } }
        public string Markdown { get { throw null; } set { } }
    }
    public partial class LabVirtualMachineCreationParameter
    {
        public LabVirtualMachineCreationParameter() { }
        public bool? AllowClaim { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArtifactInstallProperties> Artifacts { get { throw null; } }
        public int? BulkCreationParametersInstanceCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CustomImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties> DataDiskParameters { get { throw null; } }
        public bool? DisallowPublicIPAddress { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.GalleryImageReference GalleryImageReference { get { throw null; } set { } }
        public bool? IsAuthenticationWithSshKey { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public string LabVirtualNetworkId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.NetworkInterfaceProperties NetworkInterface { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public string OwnerObjectId { get { throw null; } set { } }
        public string OwnerUserPrincipalName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ScheduleCreationParameter> ScheduleParameters { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string SshKey { get { throw null; } set { } }
        public string StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string UserName { get { throw null; } set { } }
    }
    public partial class LabVirtualMachinePatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public LabVirtualMachinePatch() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinuxOSState : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.LinuxOSState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinuxOSState(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.LinuxOSState DeprovisionApplied { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.LinuxOSState DeprovisionRequested { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.LinuxOSState NonDeprovisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.LinuxOSState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.LinuxOSState left, Azure.ResourceManager.DevTestLabs.Models.LinuxOSState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.LinuxOSState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.LinuxOSState left, Azure.ResourceManager.DevTestLabs.Models.LinuxOSState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType left, Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType left, Azure.ResourceManager.DevTestLabs.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterfaceProperties
    {
        public NetworkInterfaceProperties() { }
        public string DnsName { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PublicIPAddress { get { throw null; } set { } }
        public string PublicIPAddressId { get { throw null; } set { } }
        public string RdpAuthority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.InboundNatRule> SharedPublicIPAddressInboundNatRules { get { throw null; } }
        public string SshAuthority { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
        public string VirtualNetworkId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationChannelEventType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationChannelEventType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType AutoShutdown { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType Cost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType left, Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType left, Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationChannelPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public NotificationChannelPatch() { }
    }
    public partial class NotificationSettings
    {
        public NotificationSettings() { }
        public string EmailRecipient { get { throw null; } set { } }
        public string NotificationLocale { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Status { get { throw null; } set { } }
        public int? TimeInMinutes { get { throw null; } set { } }
        public System.Uri WebhookUri { get { throw null; } set { } }
    }
    public partial class NotifyContent
    {
        public NotifyContent() { }
        public Azure.ResourceManager.DevTestLabs.Models.NotificationChannelEventType? EventName { get { throw null; } set { } }
        public string JsonPayload { get { throw null; } set { } }
    }
    public partial class OperationMetadata
    {
        internal OperationMetadata() { }
        public Azure.ResourceManager.DevTestLabs.Models.OperationMetadataDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
    }
    public partial class OperationMetadataDisplay
    {
        internal OperationMetadataDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class ParameterInfo
    {
        public ParameterInfo() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ParametersValueFileInfo
    {
        internal ParametersValueFileInfo() { }
        public string FileName { get { throw null; } }
        public System.BinaryData ParametersValueInfo { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyEvaluatorType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyEvaluatorType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType AllowedValuesPolicy { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType MaxValuePolicy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType left, Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType left, Azure.ResourceManager.DevTestLabs.Models.PolicyEvaluatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyFactName : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.PolicyFactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyFactName(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName EnvironmentTemplate { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName GalleryImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName LabPremiumVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName LabTargetCost { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName LabVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName LabVmSize { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName ScheduleEditPermission { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName UserOwnedLabPremiumVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName UserOwnedLabVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyFactName UserOwnedLabVmCountInSubnet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.PolicyFactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.PolicyFactName left, Azure.ResourceManager.DevTestLabs.Models.PolicyFactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.PolicyFactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.PolicyFactName left, Azure.ResourceManager.DevTestLabs.Models.PolicyFactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public PolicyPatch() { }
    }
    public partial class PolicySetResult
    {
        internal PolicySetResult() { }
        public bool? HasError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.PolicyViolation> PolicyViolations { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.PolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.PolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.PolicyStatus left, Azure.ResourceManager.DevTestLabs.Models.PolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.PolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.PolicyStatus left, Azure.ResourceManager.DevTestLabs.Models.PolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PolicyViolation
    {
        internal PolicyViolation() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class Port
    {
        public Port() { }
        public int? BackendPort { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.TransportProtocol? TransportProtocol { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PremiumDataDisk : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PremiumDataDisk(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk left, Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk left, Azure.ResourceManager.DevTestLabs.Models.PremiumDataDisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RdpConnection
    {
        internal RdpConnection() { }
        public string Contents { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReportingCycleType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReportingCycleType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType CalendarMonth { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType left, Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType left, Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResizeLabVirtualMachineProperties
    {
        public ResizeLabVirtualMachineProperties() { }
        public string Size { get { throw null; } set { } }
    }
    public partial class RetargetScheduleProperties
    {
        public RetargetScheduleProperties() { }
        public string CurrentResourceId { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
    }
    public partial class ScheduleCreationParameter
    {
        public ScheduleCreationParameter() { }
        public string DailyRecurrenceTime { get { throw null; } set { } }
        public int? HourlyRecurrenceMinute { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.NotificationSettings NotificationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.EnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TaskType { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.WeekDetails WeeklyRecurrence { get { throw null; } set { } }
    }
    public partial class ScheduleFragment : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public ScheduleFragment() { }
    }
    public partial class SecretPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public SecretPatch() { }
    }
    public partial class ServiceFabricPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public ServiceFabricPatch() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SourceControlType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.SourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.SourceControlType GitHub { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.SourceControlType StorageAccount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.SourceControlType VsoGit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.SourceControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.SourceControlType left, Azure.ResourceManager.DevTestLabs.Models.SourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.SourceControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.SourceControlType left, Azure.ResourceManager.DevTestLabs.Models.SourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.StorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.StorageType Premium { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.StorageType Standard { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.StorageType StandardSSD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.StorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.StorageType left, Azure.ResourceManager.DevTestLabs.Models.StorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.StorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.StorageType left, Azure.ResourceManager.DevTestLabs.Models.StorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Subnet
    {
        public Subnet() { }
        public Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType? AllowPublicIP { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class SubnetOverride
    {
        public SubnetOverride() { }
        public string LabSubnetName { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.Port> SharedPublicIPAddressAllowedPorts { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType? UseInVmCreationPermission { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType? UsePublicIPAddressPermission { get { throw null; } set { } }
        public string VirtualNetworkPoolName { get { throw null; } set { } }
    }
    public partial class TargetCostProperties
    {
        public TargetCostProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.CostThresholdProperties> CostThresholds { get { throw null; } }
        public System.DateTimeOffset? CycleEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? CycleStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.ReportingCycleType? CycleType { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus? Status { get { throw null; } set { } }
        public int? Target { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetCostStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetCostStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus left, Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus left, Azure.ResourceManager.DevTestLabs.Models.TargetCostStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TransportProtocol : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.TransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.TransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.TransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.TransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.TransportProtocol left, Azure.ResourceManager.DevTestLabs.Models.TransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.TransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.TransportProtocol left, Azure.ResourceManager.DevTestLabs.Models.TransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateResource
    {
        public UpdateResource() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsagePermissionType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsagePermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType Allow { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType Default { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType left, Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType left, Azure.ResourceManager.DevTestLabs.Models.UsagePermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserIdentity
    {
        public UserIdentity() { }
        public string AppId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class UserPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public UserPatch() { }
    }
    public partial class UserSecretStore
    {
        public UserSecretStore() { }
        public string KeyVaultId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualMachineCreationSource : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualMachineCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource FromCustomImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource FromGalleryImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource FromSharedGalleryImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource left, Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource left, Azure.ResourceManager.DevTestLabs.Models.VirtualMachineCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public VirtualNetworkPatch() { }
    }
    public partial class WeekDetails
    {
        public WeekDetails() { }
        public string Time { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Weekdays { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsOSState : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.WindowsOSState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsOSState(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState NonSysprepped { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState SysprepApplied { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState SysprepRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState left, Azure.ResourceManager.DevTestLabs.Models.WindowsOSState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.WindowsOSState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState left, Azure.ResourceManager.DevTestLabs.Models.WindowsOSState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
