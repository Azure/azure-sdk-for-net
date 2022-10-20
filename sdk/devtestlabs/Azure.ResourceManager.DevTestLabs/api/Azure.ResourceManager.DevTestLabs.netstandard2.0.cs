namespace Azure.ResourceManager.DevTestLabs
{
    public partial class DevTestLabArmTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArmTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArmTemplateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabArmTemplateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.BinaryData Contents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public string Icon { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ParametersValueFileInfo> ParametersValueFilesInfo { get { throw null; } }
        public string Publisher { get { throw null; } }
    }
    public partial class DevTestLabArmTemplateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArmTemplateResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArtifactData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabArtifactData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string FilePath { get { throw null; } }
        public string Icon { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetOSType { get { throw null; } }
        public string Title { get { throw null; } }
    }
    public partial class DevTestLabArtifactResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArtifactResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ArmTemplateInfo> GenerateArmTemplate(Azure.ResourceManager.DevTestLabs.Models.GenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ArmTemplateInfo>> GenerateArmTemplateAsync(Azure.ResourceManager.DevTestLabs.Models.GenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabArtifactSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArtifactSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArtifactSourceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabArtifactSourceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabArtifactSourceResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArtifactSourceResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetDevTestLabArmTemplate(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetDevTestLabArmTemplateAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateCollection GetDevTestLabArmTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetDevTestLabArtifact(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetDevTestLabArtifactAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactCollection GetDevTestLabArtifacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>, System.Collections.IEnumerable
    {
        protected DevTestLabCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabCostCollection : Azure.ResourceManager.ArmCollection
    {
        protected DevTestLabCostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCostData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabCostData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabCostResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabCostResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCustomImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>, System.Collections.IEnumerable
    {
        protected DevTestLabCustomImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabCustomImageData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabCustomImageData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabCustomImageResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabCustomImageResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>, System.Collections.IEnumerable
    {
        protected DevTestLabDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabDiskData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabDiskData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabDiskResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabDiskResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Attach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.AttachDiskProperties attachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AttachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.AttachDiskProperties attachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Detach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDiskProperties detachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDiskProperties detachDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>, System.Collections.IEnumerable
    {
        protected DevTestLabEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ArmTemplateDisplayName { get { throw null; } set { } }
        public string CreatedByUser { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.EnvironmentDeploymentProperties DeploymentProperties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceGroupId { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DevTestLabEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabEnvironmentResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabFormulaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>, System.Collections.IEnumerable
    {
        protected DevTestLabFormulaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabFormulaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabFormulaData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Author { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.LabVirtualMachineCreationParameter FormulaContent { get { throw null; } set { } }
        public string LabVmId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DevTestLabFormulaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabFormulaResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabGlobalScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabGlobalScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabGlobalScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabGlobalScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Retarget(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.RetargetScheduleProperties retargetScheduleProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RetargetAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.RetargetScheduleProperties retargetScheduleProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabNotificationChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>, System.Collections.IEnumerable
    {
        protected DevTestLabNotificationChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabNotificationChannelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabNotificationChannelData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EmailRecipient { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.Event> Events { get { throw null; } }
        public string NotificationLocale { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public System.Uri WebHookUri { get { throw null; } set { } }
    }
    public partial class DevTestLabNotificationChannelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabNotificationChannelResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Notify(Azure.ResourceManager.DevTestLabs.Models.NotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NotifyAsync(Azure.ResourceManager.DevTestLabs.Models.NotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>, System.Collections.IEnumerable
    {
        protected DevTestLabPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabPolicyData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabPolicyData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabPolicyResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabPolicyResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string policySetName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetDevTestLabArtifactSource(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetDevTestLabArtifactSourceAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceCollection GetDevTestLabArtifactSources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> GetDevTestLabCost(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetDevTestLabCostAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCostCollection GetDevTestLabCosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetDevTestLabCustomImage(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetDevTestLabCustomImageAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageCollection GetDevTestLabCustomImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetDevTestLabFormula(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetDevTestLabFormulaAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabFormulaCollection GetDevTestLabFormulas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetDevTestLabNotificationChannel(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetDevTestLabNotificationChannelAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelCollection GetDevTestLabNotificationChannels() { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabPolicyCollection GetDevTestLabPolicies(string policySetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetDevTestLabPolicy(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetDevTestLabPolicyAsync(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetDevTestLabSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetDevTestLabScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleCollection GetDevTestLabSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> GetDevTestLabServiceRunner(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetDevTestLabServiceRunnerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerCollection GetDevTestLabServiceRunners() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetDevTestLabUser(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetDevTestLabUserAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabUserCollection GetDevTestLabUsers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetDevTestLabVirtualNetwork(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetDevTestLabVirtualNetworkAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkCollection GetDevTestLabVirtualNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetDevTestLabVm(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetDevTestLabVmAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmCollection GetDevTestLabVms() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.Models.GalleryImage> GetGalleryImages(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.Models.GalleryImage> GetGalleryImagesAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportVirtualMachine(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ImportLabVirtualMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportVirtualMachineAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ImportLabVirtualMachineContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetApplicable(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetApplicableAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabScheduleData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabScheduleData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
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
    public partial class DevTestLabScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabSecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>, System.Collections.IEnumerable
    {
        protected DevTestLabSecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabSecretData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabSecretData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class DevTestLabSecretResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabSecretResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabSecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>, System.Collections.IEnumerable
    {
        protected DevTestLabServiceFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabServiceFabricData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabServiceFabricData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule ApplicableSchedule { get { throw null; } }
        public string EnvironmentId { get { throw null; } set { } }
        public string ExternalServiceFabricId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DevTestLabServiceFabricResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceFabricResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetDevTestLabServiceFabricSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetDevTestLabServiceFabricScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleCollection GetDevTestLabServiceFabricSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceFabricScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabServiceFabricScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabServiceFabricScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceFabricScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string serviceFabricName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceRunnerCollection : Azure.ResourceManager.ArmCollection
    {
        protected DevTestLabServiceRunnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceRunnerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabServiceRunnerData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.Models.IdentityProperties Identity { get { throw null; } set { } }
    }
    public partial class DevTestLabServiceRunnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceRunnerResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevTestLabsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLab(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource GetDevTestLabArmTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource GetDevTestLabArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource GetDevTestLabArtifactSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetDevTestLabAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCostResource GetDevTestLabCostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource GetDevTestLabCustomImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource GetDevTestLabDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource GetDevTestLabEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource GetDevTestLabFormulaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetDevTestLabGlobalScheduleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource GetDevTestLabGlobalScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleCollection GetDevTestLabGlobalSchedules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource GetDevTestLabNotificationChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource GetDevTestLabPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabResource GetDevTestLabResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCollection GetDevTestLabs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource GetDevTestLabScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource GetDevTestLabSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource GetDevTestLabServiceFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource GetDevTestLabServiceFabricScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource GetDevTestLabServiceRunnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabUserResource GetDevTestLabUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource GetDevTestLabVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVmResource GetDevTestLabVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource GetDevTestLabVmScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.Models.OperationMetadata> GetProviderOperations(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.Models.OperationMetadata> GetProviderOperationsAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>, System.Collections.IEnumerable
    {
        protected DevTestLabUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabUserData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabUserData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.UserIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.UserSecretStore SecretStore { get { throw null; } set { } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DevTestLabUserResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabUserResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetDevTestLabDisk(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetDevTestLabDiskAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabDiskCollection GetDevTestLabDisks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetDevTestLabEnvironment(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetDevTestLabEnvironmentAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentCollection GetDevTestLabEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetDevTestLabSecret(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetDevTestLabSecretAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabSecretCollection GetDevTestLabSecrets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetDevTestLabServiceFabric(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetDevTestLabServiceFabricAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricCollection GetDevTestLabServiceFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabVirtualNetworkData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.Subnet> AllowedSubnets { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ExternalProviderResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ExternalSubnet> ExternalSubnets { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.SubnetOverride> SubnetOverrides { get { throw null; } }
        public string UniqueIdentifier { get { throw null; } }
    }
    public partial class DevTestLabVirtualNetworkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVmData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DevTestLabVmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public bool? AllowClaim { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule ApplicableSchedule { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.ArtifactDeploymentStatusProperties ArtifactDeploymentStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.ArtifactInstallProperties> Artifacts { get { throw null; } }
        public Azure.Core.ResourceIdentifier ComputeId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties ComputeVm { get { throw null; } }
        public string CreatedByUser { get { throw null; } }
        public string CreatedByUserId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CustomImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties> DataDiskParameters { get { throw null; } }
        public bool? DisallowPublicIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EnvironmentId { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.GalleryImageReference GalleryImageReference { get { throw null; } set { } }
        public bool? IsAuthenticationWithSshKey { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabVirtualNetworkId { get { throw null; } set { } }
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
    public partial class DevTestLabVmResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVmResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApplyArtifacts(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApplyArtifactsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Claim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDataDiskProperties detachDataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DetachDataDiskProperties detachDataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.ApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetDevTestLabVmSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetDevTestLabVmScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleCollection GetDevTestLabVmSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.RdpConnection> GetRdpFileContents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.RdpConnection>> GetRdpFileContentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ResizeLabVirtualMachineProperties resizeLabVirtualMachineProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.ResizeLabVirtualMachineProperties resizeLabVirtualMachineProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TransferDisks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TransferDisksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UnClaim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVmScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVmScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVmScheduleResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVmScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string virtualMachineName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.ScheduleFragment schedule, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevTestLabs.Models
{
    public partial class ApplicableSchedule : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApplicableSchedule(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData LabVmsShutdown { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData LabVmsStartup { get { throw null; } set { } }
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
    public partial class DevTestLabArtifactSourcePatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabArtifactSourcePatch() { }
    }
    public partial class DevTestLabCustomImagePatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabCustomImagePatch() { }
    }
    public partial class DevTestLabDiskPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabDiskPatch() { }
    }
    public partial class DevTestLabEnvironmentPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabEnvironmentPatch() { }
    }
    public partial class DevTestLabFormulaPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabFormulaPatch() { }
    }
    public partial class DevTestLabNotificationChannelPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabNotificationChannelPatch() { }
    }
    public partial class DevTestLabPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabPatch() { }
    }
    public partial class DevTestLabPolicyPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabPolicyPatch() { }
    }
    public partial class DevTestLabSecretPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabSecretPatch() { }
    }
    public partial class DevTestLabServiceFabricPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabServiceFabricPatch() { }
    }
    public partial class DevTestLabUserPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabUserPatch() { }
    }
    public partial class DevTestLabVirtualNetworkPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabVirtualNetworkPatch() { }
    }
    public partial class DevTestLabVmPatch : Azure.ResourceManager.DevTestLabs.Models.UpdateResource
    {
        public DevTestLabVmPatch() { }
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
