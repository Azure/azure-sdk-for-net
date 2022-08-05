namespace Azure.ResourceManager.Migrate
{
    public partial class AssessedMachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>, System.Collections.IEnumerable
    {
        protected AssessedMachineCollection() { }
        public virtual Azure.Response<bool> Exists(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> Get(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessedMachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessedMachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessedMachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessedMachineData : Azure.ResourceManager.Models.ResourceData
    {
        internal AssessedMachineData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessedMachineProperties Properties { get { throw null; } }
    }
    public partial class AssessedMachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessedMachineResource() { }
        public virtual Azure.ResourceManager.Migrate.AssessedMachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName, string assessedMachineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AssessmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessmentResource>, System.Collections.IEnumerable
    {
        protected AssessmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.AssessmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.AssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.AssessmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assessmentName, Azure.ResourceManager.Migrate.AssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource> Get(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessmentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessmentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource>> GetAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.AssessmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.AssessmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.AssessmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.AssessmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssessmentData : Azure.ResourceManager.Models.ResourceData
    {
        public AssessmentData(Azure.ResourceManager.Migrate.Models.AssessmentProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentProperties Properties { get { throw null; } set { } }
    }
    public partial class AssessmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssessmentResource() { }
        public virtual Azure.ResourceManager.Migrate.AssessmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName, string assessmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource> GetAssessedMachine(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessedMachineResource>> GetAssessedMachineAsync(string assessedMachineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessedMachineCollection GetAssessedMachines() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.DownloadUri> GetReportDownloadUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.DownloadUri>> GetReportDownloadUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.AssessmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.AssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.AssessmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.AssessmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.GroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.GroupResource>, System.Collections.IEnumerable
    {
        protected GroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.GroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migrate.GroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.GroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string groupName, Azure.ResourceManager.Migrate.GroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.GroupResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.GroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.GroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.GroupResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.GroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.GroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.GroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.GroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GroupData : Azure.ResourceManager.Models.ResourceData
    {
        public GroupData(Azure.ResourceManager.Migrate.Models.GroupProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.GroupProperties Properties { get { throw null; } set { } }
    }
    public partial class GroupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GroupResource() { }
        public virtual Azure.ResourceManager.Migrate.GroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string groupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.GroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource> GetAssessment(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.AssessmentResource>> GetAssessmentAsync(string assessmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.AssessmentCollection GetAssessments() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.GroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.GroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.GroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.GroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.GroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.GroupResource> UpdateMachines(Azure.ResourceManager.Migrate.Models.UpdateGroupBody groupUpdateProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.GroupResource>> UpdateMachinesAsync(Azure.ResourceManager.Migrate.Models.UpdateGroupBody groupUpdateProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HyperVCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.HyperVCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.HyperVCollectorResource>, System.Collections.IEnumerable
    {
        protected HyperVCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.HyperVCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migrate.HyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.HyperVCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hyperVCollectorName, Azure.ResourceManager.Migrate.HyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource> Get(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.HyperVCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.HyperVCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource>> GetAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.HyperVCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.HyperVCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.HyperVCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.HyperVCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HyperVCollectorData : Azure.ResourceManager.Models.ResourceData
    {
        public HyperVCollectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.CollectorProperties Properties { get { throw null; } set { } }
    }
    public partial class HyperVCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HyperVCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.HyperVCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string hyperVCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.HyperVCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.HyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.HyperVCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.HyperVCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ImportCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ImportCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ImportCollectorResource>, System.Collections.IEnumerable
    {
        protected ImportCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ImportCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migrate.ImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ImportCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string importCollectorName, Azure.ResourceManager.Migrate.ImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource> Get(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.ImportCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.ImportCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource>> GetAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.ImportCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ImportCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.ImportCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ImportCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ImportCollectorData : Azure.ResourceManager.Models.ResourceData
    {
        public ImportCollectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.ImportCollectorProperties Properties { get { throw null; } set { } }
    }
    public partial class ImportCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ImportCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.ImportCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string importCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ImportCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.ImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ImportCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.ImportCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MachineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MachineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MachineResource>, System.Collections.IEnumerable
    {
        protected MachineCollection() { }
        public virtual Azure.Response<bool> Exists(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MachineResource> Get(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MachineResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MachineResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MachineResource>> GetAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MachineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MachineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MachineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MachineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MachineData : Azure.ResourceManager.Models.ResourceData
    {
        internal MachineData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.MachineProperties Properties { get { throw null; } }
    }
    public partial class MachineResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MachineResource() { }
        public virtual Azure.ResourceManager.Migrate.MachineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string machineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MachineResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MachineResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MigrateExtensions
    {
        public static Azure.ResourceManager.Migrate.AssessedMachineResource GetAssessedMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.AssessmentResource GetAssessmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.GroupResource GetGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.HyperVCollectorResource GetHyperVCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.ImportCollectorResource GetImportCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MachineResource GetMachineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource GetMigratePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.MigratePrivateLinkResource GetMigratePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Migrate.ProjectResource> GetProject(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ProjectResource>> GetProjectAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.ProjectCollection GetProjects(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Migrate.ProjectResource> GetProjects(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Migrate.ProjectResource> GetProjectsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Migrate.ServerCollectorResource GetServerCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Migrate.VMwareCollectorResource GetVMwareCollectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MigratePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MigratePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigratePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public MigratePrivateEndpointConnectionData(Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionProperties properties) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
    }
    public partial class MigratePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigratePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigratePrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigratePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigratePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MigratePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigratePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData
    {
        internal MigratePrivateLinkResourceData() { }
        public Azure.ResourceManager.Migrate.Models.MigratePrivateLinkResourceProperties Properties { get { throw null; } }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Migrate.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public ProjectData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.ProjectProperties Properties { get { throw null; } set { } }
        public System.BinaryData Tags { get { throw null; } set { } }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.Migrate.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.Models.AssessmentOptions> AssessmentOptions(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.Models.AssessmentOptions>> AssessmentOptionsAsync(string assessmentOptionsName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.Models.AssessmentOptions> AssessmentOptionsList(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.Models.AssessmentOptions> AssessmentOptionsListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.AssessmentResource> GetAssessments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.AssessmentResource> GetAssessmentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.GroupResource> GetGroup(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.GroupResource>> GetGroupAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.GroupCollection GetGroups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource> GetHyperVCollector(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.HyperVCollectorResource>> GetHyperVCollectorAsync(string hyperVCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.HyperVCollectorCollection GetHyperVCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource> GetImportCollector(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ImportCollectorResource>> GetImportCollectorAsync(string importCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.ImportCollectorCollection GetImportCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MachineResource> GetMachine(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MachineResource>> GetMachineAsync(string machineName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MachineCollection GetMachines() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource> GetMigratePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionResource>> GetMigratePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionCollection GetMigratePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource> GetMigratePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.MigratePrivateLinkResource>> GetMigratePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.MigratePrivateLinkResourceCollection GetMigratePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource> GetServerCollector(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource>> GetServerCollectorAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.ServerCollectorCollection GetServerCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource> GetVMwareCollector(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource>> GetVMwareCollectorAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Migrate.VMwareCollectorCollection GetVMwareCollectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ProjectResource> Update(Azure.ResourceManager.Migrate.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ProjectResource>> UpdateAsync(Azure.ResourceManager.Migrate.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ServerCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ServerCollectorResource>, System.Collections.IEnumerable
    {
        protected ServerCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ServerCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migrate.ServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ServerCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverCollectorName, Azure.ResourceManager.Migrate.ServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource> Get(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.ServerCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.ServerCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource>> GetAsync(string serverCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.ServerCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.ServerCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.ServerCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.ServerCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerCollectorData : Azure.ResourceManager.Models.ResourceData
    {
        public ServerCollectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.CollectorProperties Properties { get { throw null; } set { } }
    }
    public partial class ServerCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.ServerCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string serverCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.ServerCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ServerCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.ServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.ServerCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.ServerCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VMwareCollectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.VMwareCollectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.VMwareCollectorResource>, System.Collections.IEnumerable
    {
        protected VMwareCollectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.VMwareCollectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migrate.VMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.VMwareCollectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vmWareCollectorName, Azure.ResourceManager.Migrate.VMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource> Get(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Migrate.VMwareCollectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Migrate.VMwareCollectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource>> GetAsync(string vmWareCollectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Migrate.VMwareCollectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Migrate.VMwareCollectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Migrate.VMwareCollectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.VMwareCollectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VMwareCollectorData : Azure.ResourceManager.Models.ResourceData
    {
        public VMwareCollectorData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.CollectorProperties Properties { get { throw null; } set { } }
    }
    public partial class VMwareCollectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VMwareCollectorResource() { }
        public virtual Azure.ResourceManager.Migrate.VMwareCollectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string projectName, string vmWareCollectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Migrate.VMwareCollectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.VMwareCollectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.VMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Migrate.VMwareCollectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Migrate.VMwareCollectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Migrate.Models
{
    public partial class AssessedDisk
    {
        internal AssessedDisk() { }
        public string DisplayName { get { throw null; } }
        public int? GigabytesForRecommendedDiskSize { get { throw null; } }
        public double? GigabytesProvisioned { get { throw null; } }
        public double? MegabytesPerSecondOfRead { get { throw null; } }
        public double? MegabytesPerSecondOfWrite { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public string Name { get { throw null; } }
        public double? NumberOfReadOperationsPerSecond { get { throw null; } }
        public double? NumberOfWriteOperationsPerSecond { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSize? RecommendedDiskSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskType? RecommendedDiskType { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.CloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
    }
    public partial class AssessedMachineProperties
    {
        internal AssessedMachineProperties() { }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public string DatacenterMachineArmId { get { throw null; } }
        public string DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedDisk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public double? MegabytesOfMemory { get { throw null; } }
        public double? MegabytesOfMemoryForRecommendedSize { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCostForRecommendedSize { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSSDStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.AssessedNetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public int? NumberOfCoresForRecommendedSize { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public double? PercentageCoresUtilization { get { throw null; } }
        public double? PercentageMemoryUtilization { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSize? RecommendedSize { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.CloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
    }
    public partial class AssessedNetworkAdapter
    {
        internal AssessedNetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public double? MegabytesPerSecondReceived { get { throw null; } }
        public double? MegabytesPerSecondTransmitted { get { throw null; } }
        public double? MonthlyBandwidthCosts { get { throw null; } }
        public double? NetGigabytesTransmittedPerMonth { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.CloudSuitability? Suitability { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail? SuitabilityDetail { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation? SuitabilityExplanation { get { throw null; } }
    }
    public partial class AssessmentOptions
    {
        internal AssessmentOptions() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.AssessmentOptionsProperties Properties { get { throw null; } }
    }
    public partial class AssessmentOptionsProperties
    {
        internal AssessmentOptionsProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedCurrencies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceSupportedOffers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReservedInstanceVmFamilies { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.Models.VmFamily> VmFamilies { get { throw null; } }
    }
    public partial class AssessmentProperties
    {
        public AssessmentProperties(Azure.ResourceManager.Migrate.Models.AzureLocation azureLocation, Azure.ResourceManager.Migrate.Models.AzureOfferCode azureOfferCode, Azure.ResourceManager.Migrate.Models.AzurePricingTier azurePricingTier, Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy azureStorageRedundancy, double scalingFactor, Azure.ResourceManager.Migrate.Models.Percentile percentile, Azure.ResourceManager.Migrate.Models.TimeRange timeRange, Azure.ResourceManager.Migrate.Models.AssessmentStage stage, Azure.ResourceManager.Migrate.Models.Currency currency, Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit azureHybridUseBenefit, double discountPercentage, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion sizingCriterion, Azure.ResourceManager.Migrate.Models.ReservedInstance reservedInstance, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Migrate.Models.AzureVmFamily> azureVmFamilies, Azure.ResourceManager.Migrate.Models.AzureDiskType azureDiskType, Azure.ResourceManager.Migrate.Models.VmUptime vmUptime) { }
        public Azure.ResourceManager.Migrate.Models.AzureDiskType AzureDiskType { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit AzureHybridUseBenefit { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureLocation AzureLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureOfferCode AzureOfferCode { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzurePricingTier AzurePricingTier { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy AzureStorageRedundancy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Migrate.Models.AzureVmFamily> AzureVmFamilies { get { throw null; } }
        public double? ConfidenceRatingInPercentage { get { throw null; } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.Currency Currency { get { throw null; } set { } }
        public double DiscountPercentage { get { throw null; } set { } }
        public string EaSubscriptionId { get { throw null; } }
        public double? MonthlyBandwidthCost { get { throw null; } }
        public double? MonthlyComputeCost { get { throw null; } }
        public double? MonthlyPremiumStorageCost { get { throw null; } }
        public double? MonthlyStandardSSDStorageCost { get { throw null; } }
        public double? MonthlyStorageCost { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.Percentile Percentile { get { throw null; } set { } }
        public System.DateTimeOffset? PerfDataEndOn { get { throw null; } }
        public System.DateTimeOffset? PerfDataStartOn { get { throw null; } }
        public System.DateTimeOffset? PricesTimestamp { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ReservedInstance ReservedInstance { get { throw null; } set { } }
        public double ScalingFactor { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion SizingCriterion { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStage Stage { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.AssessmentStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.TimeRange TimeRange { get { throw null; } set { } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.VmUptime VmUptime { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentSizingCriterion : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentSizingCriterion(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion AsOnPremises { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion PerformanceBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion left, Azure.ResourceManager.Migrate.Models.AssessmentSizingCriterion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStage : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentStage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStage(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage Approved { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage InProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStage UnderReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentStage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentStage left, Azure.ResourceManager.Migrate.Models.AssessmentStage right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentStage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentStage left, Azure.ResourceManager.Migrate.Models.AssessmentStage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AssessmentStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.AssessmentStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AssessmentStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus OutDated { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus OutOfSync { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AssessmentStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AssessmentStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AssessmentStatus left, Azure.ResourceManager.Migrate.Models.AssessmentStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AssessmentStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AssessmentStatus left, Azure.ResourceManager.Migrate.Models.AssessmentStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSize : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSize(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize PremiumP80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardS80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE15 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE20 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE30 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE40 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE60 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE70 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize StandardSSDE80 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSize left, Azure.ResourceManager.Migrate.Models.AzureDiskSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSize left, Azure.ResourceManager.Migrate.Models.AzureDiskSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesConsumedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail DiskGigabytesProvisionedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfReadOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail MegabytesPerSecondOfWriteOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfReadOperationsPerSecondOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail NumberOfWriteOperationsPerSecondOutOfRange { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation DiskSizeGreaterThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation InternalErrorOccurredForDiskEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundForSelectedRedundancy { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoDiskSizeFoundInSelectedLocation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoEaPriceFoundForDiskSize { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForIops { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NoSuitableDiskSizeForThroughput { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureDiskSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureDiskType : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureDiskType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureDiskType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Premium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Standard { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType StandardOrPremium { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType StandardSSD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureDiskType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureDiskType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureDiskType left, Azure.ResourceManager.Migrate.Models.AzureDiskType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureDiskType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureDiskType left, Azure.ResourceManager.Migrate.Models.AzureDiskType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureHybridUseBenefit : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureHybridUseBenefit(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit No { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit Yes { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit left, Azure.ResourceManager.Migrate.Models.AzureHybridUseBenefit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureLocation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureLocation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation AustraliaEast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation AustraliaSoutheast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation BrazilSouth { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation CanadaCentral { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation CanadaEast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation CentralIndia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation CentralUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation ChinaEast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation ChinaNorth { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation EastAsia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation EastUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation EastUs2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation GermanyCentral { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation GermanyNortheast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation JapanEast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation JapanWest { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation KoreaCentral { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation KoreaSouth { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation NorthCentralUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation NorthEurope { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation SouthCentralUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation SoutheastAsia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation SouthIndia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation UkSouth { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation UkWest { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USDoDCentral { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USDoDEast { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USGovArizona { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USGovIowa { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USGovTexas { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation USGovVirginia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation WestCentralUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation WestEurope { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation WestIndia { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation WestUs { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureLocation WestUs2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureLocation left, Azure.ResourceManager.Migrate.Models.AzureLocation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureLocation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureLocation left, Azure.ResourceManager.Migrate.Models.AzureLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail MegabytesOfDataTransmittedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureNetworkAdapterSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureNetworkAdapterSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation InternalErrorOccurred { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureNetworkAdapterSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureOfferCode : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureOfferCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureOfferCode(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode EA { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0022P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0023P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0025P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0029P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0036P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0059P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0060P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0062P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0063P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0064P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0111P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0120P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0121P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0122P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0123P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0124P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0125P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0126P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0127P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0128P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0129P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0130P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0144P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0148P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazr0149P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazrde0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazrde0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msazrusgov0003P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0044P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0059P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0060P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0063P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0120P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0121P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0125P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Msmcazr0128P { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureOfferCode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureOfferCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureOfferCode left, Azure.ResourceManager.Migrate.Models.AzureOfferCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureOfferCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureOfferCode left, Azure.ResourceManager.Migrate.Models.AzureOfferCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzurePricingTier : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzurePricingTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzurePricingTier(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzurePricingTier Basic { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzurePricingTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzurePricingTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzurePricingTier left, Azure.ResourceManager.Migrate.Models.AzurePricingTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzurePricingTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzurePricingTier left, Azure.ResourceManager.Migrate.Models.AzurePricingTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureStorageRedundancy : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureStorageRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy ReadAccessGeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy left, Azure.ResourceManager.Migrate.Models.AzureStorageRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmFamily : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmFamily(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Av2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily BasicA0A4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DCSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily DSv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dsv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Dv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Esv3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Ev3Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily FSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily FsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Fsv2Series { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily GSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily GSSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily HSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily LsSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily MSeries { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily StandardA0A7 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily StandardA8A11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmFamily Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmFamily left, Azure.ResourceManager.Migrate.Models.AzureVmFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmFamily left, Azure.ResourceManager.Migrate.Models.AzureVmFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSize : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA0 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize BasicA4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA0 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA10 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA6 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA7 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8MV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA8V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardA9 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD12 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD13 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD14 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardD8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS11 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS11V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS12 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS12V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS13 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS13V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS14 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS14V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS15V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS1V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS2V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS3V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS4V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardDS5V2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE16V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE2V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE32V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE4V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE64V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8SV3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardE8V3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF16SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF1S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF2SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF32SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF4SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF64SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF72SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardF8SV2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardG5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS1 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS2 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS3 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS4 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardGS5 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16Mr { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH16R { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH8 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardH8M { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL16S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL32S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL4S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardL8S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM128S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64Ms { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize StandardM64S { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSize Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSize other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSize left, Azure.ResourceManager.Migrate.Models.AzureVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSize (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSize left, Azure.ResourceManager.Migrate.Models.AzureVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityDetail : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityDetail(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportBandwidthCosts { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportComputeCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail CannotReportStorageCost { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfCoresUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedMissing { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail PercentageOfMemoryUtilizedOutOfRange { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail RecommendedSizeHasLessNetworkAdapters { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureVmSuitabilityExplanation : System.IEquatable<Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureVmSuitabilityExplanation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation BootTypeNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation BootTypeUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckCentOSVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckCoreOSLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckDebianLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckOpenSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckOracleLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckRedHatLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckSuseLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckUbuntuLinuxVersion { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation CheckWindowsServer2008R2Version { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation EndorsedWithConditionsLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemArchitectureNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemNotSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation GuestOperatingSystemUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringComputeEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringNetworkEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation InternalErrorOccurredDuringStorageEvaluation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation MoreDisksThanSupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoGuestOperatingSystemConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoSuitableVmSizeFound { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NotApplicable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForBasicPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedAzureLocation { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForSelectedPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeForStandardPricingTier { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsNetworkPerformance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation NoVmSizeSupportsStoragePerformance { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation OneOrMoreAdaptersNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation OneOrMoreDisksNotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation UnendorsedLinuxDistributions { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsClientVersionsConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsOSNoLongerUnderMSSupport { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsServerVersionConditionallySupported { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation WindowsServerVersionsSupportedWithCaveat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation left, Azure.ResourceManager.Migrate.Models.AzureVmSuitabilityExplanation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudSuitability : System.IEquatable<Azure.ResourceManager.Migrate.Models.CloudSuitability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudSuitability(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.CloudSuitability ConditionallySuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CloudSuitability NotSuitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CloudSuitability ReadinessUnknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CloudSuitability Suitable { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.CloudSuitability Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.CloudSuitability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.CloudSuitability left, Azure.ResourceManager.Migrate.Models.CloudSuitability right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.CloudSuitability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.CloudSuitability left, Azure.ResourceManager.Migrate.Models.CloudSuitability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CollectorAgentProperties
    {
        public CollectorAgentProperties() { }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatUtc { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.CollectorBodyAgentSpnProperties SpnDetails { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class CollectorBodyAgentSpnProperties
    {
        public CollectorBodyAgentSpnProperties() { }
        public string ApplicationId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string Authority { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class CollectorProperties
    {
        public CollectorProperties() { }
        public Azure.ResourceManager.Migrate.Models.CollectorAgentProperties AgentProperties { get { throw null; } set { } }
        public string CreatedTimestamp { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public string UpdatedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Currency : System.IEquatable<Azure.ResourceManager.Migrate.Models.Currency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Currency(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.Currency ARS { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency AUD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency BRL { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency CAD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency CHF { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency CNY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency DKK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency EUR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency GBP { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency HKD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency IdR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency INR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency JPY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency KRW { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency MXN { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency MYR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency NOK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency NZD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency RUB { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency SAR { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency SEK { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency TRY { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency TWD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency Unknown { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency USD { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Currency ZAR { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.Currency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.Currency left, Azure.ResourceManager.Migrate.Models.Currency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.Currency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.Currency left, Azure.ResourceManager.Migrate.Models.Currency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Disk
    {
        internal Disk() { }
        public string DisplayName { get { throw null; } }
        public double? GigabytesAllocated { get { throw null; } }
    }
    public partial class DownloadUri
    {
        internal DownloadUri() { }
        public System.Uri AssessmentReportUri { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
    }
    public partial class GroupBodyProperties
    {
        public GroupBodyProperties() { }
        public System.Collections.Generic.IList<string> Machines { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.GroupUpdateOperation? OperationType { get { throw null; } set { } }
    }
    public partial class GroupProperties
    {
        public GroupProperties() { }
        public bool? AreAssessmentsRunning { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Assessments { get { throw null; } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.GroupStatus? GroupStatus { get { throw null; } }
        public string GroupType { get { throw null; } set { } }
        public int? MachineCount { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.GroupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GroupStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GroupStatus Created { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GroupStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GroupStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GroupStatus Updated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.GroupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.GroupStatus left, Azure.ResourceManager.Migrate.Models.GroupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.GroupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.GroupStatus left, Azure.ResourceManager.Migrate.Models.GroupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupUpdateOperation : System.IEquatable<Azure.ResourceManager.Migrate.Models.GroupUpdateOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupUpdateOperation(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.GroupUpdateOperation Add { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.GroupUpdateOperation Remove { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.GroupUpdateOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.GroupUpdateOperation left, Azure.ResourceManager.Migrate.Models.GroupUpdateOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.GroupUpdateOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.GroupUpdateOperation left, Azure.ResourceManager.Migrate.Models.GroupUpdateOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImportCollectorProperties
    {
        public ImportCollectorProperties() { }
        public string CreatedTimestamp { get { throw null; } }
        public string DiscoverySiteId { get { throw null; } set { } }
        public string UpdatedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MachineBootType : System.IEquatable<Azure.ResourceManager.Migrate.Models.MachineBootType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MachineBootType(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType Bios { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType EFI { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.MachineBootType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.MachineBootType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.MachineBootType left, Azure.ResourceManager.Migrate.Models.MachineBootType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.MachineBootType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.MachineBootType left, Azure.ResourceManager.Migrate.Models.MachineBootType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MachineProperties
    {
        internal MachineProperties() { }
        public Azure.ResourceManager.Migrate.Models.MachineBootType? BootType { get { throw null; } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public string DatacenterManagementServerArmId { get { throw null; } }
        public string DatacenterManagementServerName { get { throw null; } }
        public string Description { get { throw null; } }
        public string DiscoveryMachineArmId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.Disk> Disks { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Groups { get { throw null; } }
        public float? MegabytesOfMemory { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Migrate.Models.NetworkAdapter> NetworkAdapters { get { throw null; } }
        public int? NumberOfCores { get { throw null; } }
        public string OperatingSystemName { get { throw null; } }
        public string OperatingSystemType { get { throw null; } }
        public string OperatingSystemVersion { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
    }
    public partial class MigratePrivateLinkResourceProperties
    {
        internal MigratePrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MigratePrivateLinkServiceConnectionState
    {
        public MigratePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus? Status { get { throw null; } set { } }
    }
    public partial class NetworkAdapter
    {
        internal NetworkAdapter() { }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IPAddresses { get { throw null; } }
        public string MacAddress { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Percentile : System.IEquatable<Azure.ResourceManager.Migrate.Models.Percentile>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Percentile(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.Percentile Percentile50 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Percentile Percentile90 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Percentile Percentile95 { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.Percentile Percentile99 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.Percentile other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.Percentile left, Azure.ResourceManager.Migrate.Models.Percentile right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.Percentile (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.Percentile left, Azure.ResourceManager.Migrate.Models.Percentile right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties
    {
        public PrivateEndpointConnectionProperties() { }
        public Azure.ResourceManager.Migrate.Models.MigratePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionPropertiesProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionPropertiesProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState left, Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState left, Azure.ResourceManager.Migrate.Models.PrivateEndpointConnectionPropertiesProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.Migrate.Models.PrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProjectProperties
    {
        public ProjectProperties() { }
        public string AssessmentSolutionId { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedTimestamp { get { throw null; } }
        public string CustomerStorageAccountArmId { get { throw null; } set { } }
        public string CustomerWorkspaceId { get { throw null; } set { } }
        public string CustomerWorkspaceLocation { get { throw null; } set { } }
        public System.DateTimeOffset? LastAssessmentTimestamp { get { throw null; } }
        public int? NumberOfAssessments { get { throw null; } }
        public int? NumberOfGroups { get { throw null; } }
        public int? NumberOfMachines { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Migrate.MigratePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Migrate.Models.ProjectStatus? ProjectStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string ServiceEndpoint { get { throw null; } }
        public System.DateTimeOffset? UpdatedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProjectStatus : System.IEquatable<Azure.ResourceManager.Migrate.Models.ProjectStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProjectStatus(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ProjectStatus Active { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProjectStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ProjectStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ProjectStatus left, Azure.ResourceManager.Migrate.Models.ProjectStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ProjectStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ProjectStatus left, Azure.ResourceManager.Migrate.Models.ProjectStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Migrate.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ProvisioningState left, Azure.ResourceManager.Migrate.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ProvisioningState left, Azure.ResourceManager.Migrate.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReservedInstance : System.IEquatable<Azure.ResourceManager.Migrate.Models.ReservedInstance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReservedInstance(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.ReservedInstance None { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ReservedInstance RI1Year { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.ReservedInstance RI3Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.ReservedInstance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.ReservedInstance left, Azure.ResourceManager.Migrate.Models.ReservedInstance right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.ReservedInstance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.ReservedInstance left, Azure.ResourceManager.Migrate.Models.ReservedInstance right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TimeRange : System.IEquatable<Azure.ResourceManager.Migrate.Models.TimeRange>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TimeRange(string value) { throw null; }
        public static Azure.ResourceManager.Migrate.Models.TimeRange Custom { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TimeRange Day { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TimeRange Month { get { throw null; } }
        public static Azure.ResourceManager.Migrate.Models.TimeRange Week { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Migrate.Models.TimeRange other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Migrate.Models.TimeRange left, Azure.ResourceManager.Migrate.Models.TimeRange right) { throw null; }
        public static implicit operator Azure.ResourceManager.Migrate.Models.TimeRange (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Migrate.Models.TimeRange left, Azure.ResourceManager.Migrate.Models.TimeRange right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateGroupBody
    {
        public UpdateGroupBody() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.Migrate.Models.GroupBodyProperties Properties { get { throw null; } set { } }
    }
    public partial class VmFamily
    {
        internal VmFamily() { }
        public System.Collections.Generic.IReadOnlyList<string> Category { get { throw null; } }
        public string FamilyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> TargetLocations { get { throw null; } }
    }
    public partial class VmUptime
    {
        public VmUptime() { }
        public int? DaysPerMonth { get { throw null; } set { } }
        public int? HoursPerDay { get { throw null; } set { } }
    }
}
