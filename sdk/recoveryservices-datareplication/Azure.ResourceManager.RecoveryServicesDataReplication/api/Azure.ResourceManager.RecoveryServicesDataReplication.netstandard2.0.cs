namespace Azure.ResourceManager.RecoveryServicesDataReplication
{
    public partial class DraModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>, System.Collections.IEnumerable
    {
        protected DraModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> Get(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>> GetAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DraModelData : Azure.ResourceManager.Models.ResourceData
    {
        public DraModelData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelProperties Properties { get { throw null; } set { } }
    }
    public partial class DraModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DraModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fabricName, string fabricAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetDraOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetDraOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EmailConfigurationModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>, System.Collections.IEnumerable
    {
        protected EmailConfigurationModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string emailConfigurationName, Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string emailConfigurationName, Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> Get(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>> GetAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EmailConfigurationModelData : Azure.ResourceManager.Models.ResourceData
    {
        public EmailConfigurationModelData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.EmailConfigurationModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.EmailConfigurationModelProperties Properties { get { throw null; } set { } }
    }
    public partial class EmailConfigurationModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EmailConfigurationModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string emailConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>, System.Collections.IEnumerable
    {
        protected EventModelCollection() { }
        public virtual Azure.Response<bool> Exists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> Get(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> GetAll(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> GetAllAsync(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>> GetAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EventModelData : Azure.ResourceManager.Models.ResourceData
    {
        internal EventModelData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelProperties Properties { get { throw null; } }
    }
    public partial class EventModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EventModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.EventModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string eventName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FabricModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>, System.Collections.IEnumerable
    {
        protected FabricModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> Get(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> GetAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FabricModelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public FabricModelData(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelProperties Properties { get { throw null; } set { } }
    }
    public partial class FabricModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FabricModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource> GetDraModel(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource>> GetDraModelAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DraModelCollection GetDraModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetFabricOperationsStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetFabricOperationsStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PolicyModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>, System.Collections.IEnumerable
    {
        protected PolicyModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PolicyModelData : Azure.ResourceManager.Models.ResourceData
    {
        public PolicyModelData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelProperties Properties { get { throw null; } set { } }
    }
    public partial class PolicyModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PolicyModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetPolicyOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetPolicyOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProtectedItemModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>, System.Collections.IEnumerable
    {
        protected ProtectedItemModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> Get(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>> GetAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProtectedItemModelData : Azure.ResourceManager.Models.ResourceData
    {
        public ProtectedItemModelData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelProperties Properties { get { throw null; } set { } }
    }
    public partial class ProtectedItemModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProtectedItemModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetProtectedItemOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetProtectedItemOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> GetRecoveryPointModel(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>> GetRecoveryPointModelAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelCollection GetRecoveryPointModels() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RecoveryPointModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>, System.Collections.IEnumerable
    {
        protected RecoveryPointModelCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> Get(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>> GetAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RecoveryPointModelData : Azure.ResourceManager.Models.ResourceData
    {
        internal RecoveryPointModelData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelProperties Properties { get { throw null; } }
    }
    public partial class RecoveryPointModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RecoveryPointModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName, string recoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesDataReplicationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.CheckNameAvailabilityResponseModel> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.CheckNameAvailabilityModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.CheckNameAvailabilityResponseModel>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.CheckNameAvailabilityModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel> DeploymentPreflight(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>> DeploymentPreflightAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DraModelResource GetDraModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource GetEmailConfigurationModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource GetEventModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> GetFabricModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource>> GetFabricModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource GetFabricModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelCollection GetFabricModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> GetFabricModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelResource> GetFabricModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource GetPolicyModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource GetProtectedItemModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelResource GetRecoveryPointModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource GetReplicationExtensionModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> GetVaultModel(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> GetVaultModelAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource GetVaultModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelCollection GetVaultModels(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> GetVaultModels(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> GetVaultModelsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource GetWorkflowModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ReplicationExtensionModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>, System.Collections.IEnumerable
    {
        protected ReplicationExtensionModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> Get(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>> GetAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ReplicationExtensionModelData : Azure.ResourceManager.Models.ResourceData
    {
        public ReplicationExtensionModelData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelProperties Properties { get { throw null; } set { } }
    }
    public partial class ReplicationExtensionModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ReplicationExtensionModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string replicationExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetReplicationExtensionOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetReplicationExtensionOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>, System.Collections.IEnumerable
    {
        protected VaultModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultModelData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public VaultModelData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelProperties Properties { get { throw null; } set { } }
    }
    public partial class VaultModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource> GetEmailConfigurationModel(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelResource>> GetEmailConfigurationModelAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelCollection GetEmailConfigurationModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource> GetEventModel(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.EventModelResource>> GetEventModelAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.EventModelCollection GetEventModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource> GetPolicyModel(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelResource>> GetPolicyModelAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelCollection GetPolicyModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource> GetProtectedItemModel(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelResource>> GetProtectedItemModelAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelCollection GetProtectedItemModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource> GetReplicationExtensionModel(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelResource>> GetReplicationExtensionModelAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelCollection GetReplicationExtensionModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetVaultOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetVaultOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> GetWorkflowModel(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>> GetWorkflowModelAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelCollection GetWorkflowModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>, System.Collections.IEnumerable
    {
        protected WorkflowModelCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> GetAll(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> GetAllAsync(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowModelData : Azure.ResourceManager.Models.ResourceData
    {
        internal WorkflowModelData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelProperties Properties { get { throw null; } }
    }
    public partial class WorkflowModelResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowModelResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus> GetWorkflowOperationStatu(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus>> GetWorkflowOperationStatuAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesDataReplication.Models
{
    public static partial class ArmRecoveryServicesDataReplicationModelFactory
    {
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHCIFabricModelCustomProperties AzStackHCIFabricModelCustomProperties(string azStackHciSiteId = null, System.Collections.Generic.IEnumerable<string> applianceName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHCIClusterProperties cluster = null, string fabricResourceId = null, string fabricContainerId = null, string migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.CheckNameAvailabilityResponseModel CheckNameAvailabilityResponseModel(bool? nameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DraModelData DraModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelProperties DraModelProperties(string correlationId = null, string machineId = null, string machineName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel authenticationIdentity = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel resourceAccessIdentity = null, bool? isResponsive = default(bool?), System.DateTimeOffset? lastHeartbeat = default(System.DateTimeOffset?), string versionNumber = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.EmailConfigurationModelData EmailConfigurationModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.EmailConfigurationModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ErrorModel ErrorModel(string code = null, string errorModelType = null, string severity = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.EventModelData EventModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelProperties EventModelProperties(string resourceType = null, string resourceName = null, string eventType = null, string eventName = null, System.DateTimeOffset? timeOfOccurrence = default(System.DateTimeOffset?), string severity = null, string description = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.FabricModelData FabricModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelProperties FabricModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), string serviceEndpoint = null, string serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus? health = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties FailoverProtectedItemProperties(string protectedItemName = null, string vmName = null, string testVmName = null, string recoveryPointId = null, System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?), string networkName = null, string subnet = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties FailoverWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel HealthErrorModel(string affectedResourceType = null, System.Collections.Generic.IEnumerable<string> affectedResourceCorrelationIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.InnerHealthErrorModel> childErrors = null, string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties HyperVMigrateFabricModelCustomProperties(string hyperVSiteId = null, string fabricResourceId = null, string fabricContainerId = null, string migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIEventModelCustomProperties HyperVToAzStackHCIEventModelCustomProperties(string eventSourceFriendlyName = null, string protectedItemFriendlyName = null, string sourceApplianceName = null, string targetApplianceName = null, string serverType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCINicInput HyperVToAzStackHCINicInput(string nicId = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedDiskProperties HyperVToAzStackHCIProtectedDiskProperties(string storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedItemModelCustomProperties HyperVToAzStackHCIProtectedItemModelCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), string targetHciClusterId = null, string targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, string fabricDiscoveryMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCINicInput> nicsToInclude = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string targetVmName = null, string targetResourceGroupId = null, string storageContainerId = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string runAsAccountId = null, string sourceDraName = null, string targetDraName = null, string sourceApplianceName = null, string targetApplianceName = null, string osType = null, string osName = null, string firmwareType = null, string targetLocation = null, string customLocationRegion = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedNicProperties HyperVToAzStackHCIProtectedNicProperties(string nicId = null, string macAddress = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIRecoveryPointModelCustomProperties HyperVToAzStackHCIRecoveryPointModelCustomProperties(System.Collections.Generic.IEnumerable<string> diskIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIReplicationExtensionModelCustomProperties HyperVToAzStackHCIReplicationExtensionModelCustomProperties(string hyperVFabricArmId = null, string hyperVSiteId = null, string azStackHciFabricArmId = null, string azStackHciSiteId = null, string storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.InnerHealthErrorModel InnerHealthErrorModel(string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.OperationStatus OperationStatus(string id = null, string name = null, string status = null, string startTime = null, string endTime = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.PolicyModelData PolicyModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelProperties PolicyModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties ProtectedItemJobProperties(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.ProtectedItemModelData ProtectedItemModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelProperties ProtectedItemModelProperties(string policyName = null, string replicationExtensionName = null, string correlationId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState?), string protectionStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState? testFailoverState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState?), string testFailoverStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState? resynchronizationState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState?), string fabricObjectId = null, string fabricObjectName = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, string fabricId = null, string targetFabricId = null, string draId = null, string targetDraId = null, bool? resyncRequired = default(bool?), System.DateTimeOffset? lastSuccessfulPlannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulUnplannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulTestFailoverOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesCurrentJob currentJob = null, System.Collections.Generic.IEnumerable<string> allowedJobs = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedEnableProtectionJob lastFailedEnableProtectionJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedPlannedFailoverJob lastFailedPlannedFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastTestFailoverJob lastTestFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus? replicationHealth = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesCurrentJob ProtectedItemModelPropertiesCurrentJob(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedEnableProtectionJob ProtectedItemModelPropertiesLastFailedEnableProtectionJob(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedPlannedFailoverJob ProtectedItemModelPropertiesLastFailedPlannedFailoverJob(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastTestFailoverJob ProtectedItemModelPropertiesLastTestFailoverJob(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.RecoveryPointModelData RecoveryPointModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelProperties RecoveryPointModelProperties(System.DateTimeOffset recoveryPointOn = default(System.DateTimeOffset), Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType recoveryPointType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType), Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.ReplicationExtensionModelData ReplicationExtensionModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelProperties ReplicationExtensionModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskModel TaskModel(string taskName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string customInstanceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelData> childrenWorkflows = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties TestFailoverCleanupWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, string comments = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties TestFailoverWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.VaultModelData VaultModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelProperties VaultModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState?), string serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType? vaultType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCINicInput VMwareToAzStackHCINicInput(string nicId = null, string label = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedDiskProperties VMwareToAzStackHCIProtectedDiskProperties(string storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedItemModelCustomProperties VMwareToAzStackHCIProtectedItemModelCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), string targetHciClusterId = null, string targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, string storageContainerId = null, string targetResourceGroupId = null, string targetLocation = null, string customLocationRegion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCINicInput> nicsToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, string targetVmName = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string osType = null, string osName = null, string firmwareType = null, string fabricDiscoveryMachineId = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string runAsAccountId = null, string sourceDraName = null, string targetDraName = null, string sourceApplianceName = null, string targetApplianceName = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? migrationProgressPercentage = default(int?), int? resumeProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), long? resyncRetryCount = default(long?), bool? resyncRequired = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState?), bool? performAutoResync = default(bool?), long? resumeRetryCount = default(long?), System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedNicProperties VMwareToAzStackHCIProtectedNicProperties(string nicId = null, string macAddress = null, string label = null, bool? isPrimaryNic = default(bool?), string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIReplicationExtensionModelCustomProperties VMwareToAzStackHCIReplicationExtensionModelCustomProperties(string vmwareFabricArmId = null, string vmwareSiteId = null, string azStackHciFabricArmId = null, string azStackHciSiteId = null, string storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties WorkflowModelCustomProperties(string instanceType = null, System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelData WorkflowModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelProperties WorkflowModelProperties(string displayName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string objectId = null, string objectName = null, string objectInternalId = null, string objectInternalName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType? objectType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType?), string replicationProviderId = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, System.Collections.Generic.IEnumerable<string> allowedActions = null, string activityId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskModel> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ErrorModel> errors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties customProperties = null) { throw null; }
    }
    public partial class AzStackHCIClusterProperties
    {
        public AzStackHCIClusterProperties(string clusterName, string resourceName, string storageAccountName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> storageContainers) { }
        public string ClusterName { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> StorageContainers { get { throw null; } }
    }
    public partial class AzStackHCIFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties
    {
        public AzStackHCIFabricModelCustomProperties(string azStackHciSiteId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHCIClusterProperties cluster, string migrationSolutionId) { }
        public System.Collections.Generic.IReadOnlyList<string> ApplianceName { get { throw null; } }
        public string AzStackHciSiteId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHCIClusterProperties Cluster { get { throw null; } set { } }
        public string FabricContainerId { get { throw null; } }
        public string FabricResourceId { get { throw null; } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public string MigrationSolutionId { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityModel
    {
        public CheckNameAvailabilityModel() { }
        public string Name { get { throw null; } set { } }
        public string ResourceType { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResponseModel
    {
        internal CheckNameAvailabilityResponseModel() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public partial class DeploymentPreflightModel
    {
        public DeploymentPreflightModel() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResource> Resources { get { throw null; } }
    }
    public partial class DeploymentPreflightResource
    {
        public DeploymentPreflightResource() { }
        public string ApiVersion { get { throw null; } set { } }
        public string DeploymentPreflightResourceType { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public abstract partial class DraModelCustomProperties
    {
        protected DraModelCustomProperties() { }
    }
    public partial class DraModelProperties
    {
        public DraModelProperties(string machineId, string machineName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel authenticationIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel resourceAccessIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel AuthenticationIdentity { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties CustomProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> HealthErrors { get { throw null; } }
        public bool? IsResponsive { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeat { get { throw null; } }
        public string MachineId { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel ResourceAccessIdentity { get { throw null; } set { } }
        public string VersionNumber { get { throw null; } }
    }
    public partial class EmailConfigurationModelProperties
    {
        public EmailConfigurationModelProperties(bool sendToOwners) { }
        public System.Collections.Generic.IList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public bool SendToOwners { get { throw null; } set { } }
    }
    public partial class ErrorModel
    {
        internal ErrorModel() { }
        public string Causes { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string ErrorModelType { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
    }
    public abstract partial class EventModelCustomProperties
    {
        protected EventModelCustomProperties() { }
    }
    public partial class EventModelProperties
    {
        internal EventModelProperties() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties CustomProperties { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventName { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> HealthErrors { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string Severity { get { throw null; } }
        public System.DateTimeOffset? TimeOfOccurrence { get { throw null; } }
    }
    public abstract partial class FabricModelCustomProperties
    {
        protected FabricModelCustomProperties() { }
    }
    public partial class FabricModelPatch : Azure.ResourceManager.Models.ResourceData
    {
        public FabricModelPatch() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class FabricModelProperties
    {
        public FabricModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public string ServiceResourceId { get { throw null; } }
    }
    public partial class FailoverProtectedItemProperties
    {
        internal FailoverProtectedItemProperties() { }
        public string NetworkName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string TestVmName { get { throw null; } }
        public string VmName { get { throw null; } }
    }
    public partial class FailoverWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties
    {
        internal FailoverWorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
    }
    public partial class HealthErrorModel
    {
        internal HealthErrorModel() { }
        public System.Collections.Generic.IReadOnlyList<string> AffectedResourceCorrelationIds { get { throw null; } }
        public string AffectedResourceType { get { throw null; } }
        public string Category { get { throw null; } }
        public string Causes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.InnerHealthErrorModel> ChildErrors { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string HealthCategory { get { throw null; } }
        public bool? IsCustomerResolvable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Source { get { throw null; } }
        public string Summary { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus Critical { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus Normal { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HyperVMigrateFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties
    {
        public HyperVMigrateFabricModelCustomProperties(string hyperVSiteId, string migrationSolutionId) { }
        public string FabricContainerId { get { throw null; } }
        public string FabricResourceId { get { throw null; } }
        public string HyperVSiteId { get { throw null; } set { } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public string MigrationSolutionId { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIDiskInput
    {
        public HyperVToAzStackHCIDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public string StorageContainerId { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIEventModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties
    {
        internal HyperVToAzStackHCIEventModelCustomProperties() { }
        public string EventSourceFriendlyName { get { throw null; } }
        public string ProtectedItemFriendlyName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string SourceApplianceName { get { throw null; } }
        public string TargetApplianceName { get { throw null; } }
    }
    public partial class HyperVToAzStackHCINicInput
    {
        public HyperVToAzStackHCINicInput(string nicId, string targetNetworkId, string testNetworkId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIPlannedFailoverModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties
    {
        public HyperVToAzStackHCIPlannedFailoverModelCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIPolicyModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties
    {
        public HyperVToAzStackHCIPolicyModelCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIProtectedDiskProperties
    {
        internal HyperVToAzStackHCIProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
        public string DiskType { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsOSDisk { get { throw null; } }
        public string MigrateDiskName { get { throw null; } }
        public string SeedDiskName { get { throw null; } }
        public string SourceDiskId { get { throw null; } }
        public string SourceDiskName { get { throw null; } }
        public string StorageContainerId { get { throw null; } }
        public string StorageContainerLocalPath { get { throw null; } }
        public string TestMigrateDiskName { get { throw null; } }
    }
    public partial class HyperVToAzStackHCIProtectedItemModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties
    {
        public HyperVToAzStackHCIProtectedItemModelCustomProperties(string targetHciClusterId, string targetArcClusterCustomLocationId, string fabricDiscoveryMachineId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCINicInput> nicsToInclude, string targetResourceGroupId, string storageContainerId, string hyperVGeneration, string runAsAccountId, string sourceDraName, string targetDraName, string customLocationRegion) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? ActiveLocation { get { throw null; } }
        public string CustomLocationRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIDiskInput> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public string FabricDiscoveryMachineId { get { throw null; } set { } }
        public string FailoverRecoveryPointId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string HyperVGeneration { get { throw null; } set { } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastReplicationUpdateOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCINicInput> NicsToInclude { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedDiskProperties> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHCIProtectedNicProperties> ProtectedNics { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string SourceApplianceName { get { throw null; } }
        public int? SourceCpuCores { get { throw null; } }
        public string SourceDraName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public string StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public string TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetDraName { get { throw null; } set { } }
        public string TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
    }
    public partial class HyperVToAzStackHCIProtectedNicProperties
    {
        internal HyperVToAzStackHCIProtectedNicProperties() { }
        public string MacAddress { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? SelectionTypeForFailover { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
    }
    public partial class HyperVToAzStackHCIRecoveryPointModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties
    {
        internal HyperVToAzStackHCIRecoveryPointModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DiskIds { get { throw null; } }
    }
    public partial class HyperVToAzStackHCIReplicationExtensionModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties
    {
        public HyperVToAzStackHCIReplicationExtensionModelCustomProperties(string hyperVFabricArmId, string azStackHciFabricArmId) { }
        public System.Uri AsrServiceUri { get { throw null; } }
        public string AzStackHciFabricArmId { get { throw null; } set { } }
        public string AzStackHciSiteId { get { throw null; } }
        public System.Uri GatewayServiceUri { get { throw null; } }
        public string HyperVFabricArmId { get { throw null; } set { } }
        public string HyperVSiteId { get { throw null; } }
        public System.Uri RcmServiceUri { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string SourceGatewayServiceId { get { throw null; } }
        public string SourceStorageContainerName { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public string TargetGatewayServiceId { get { throw null; } }
        public string TargetStorageContainerName { get { throw null; } }
    }
    public partial class IdentityModel
    {
        public IdentityModel(System.Guid tenantId, string applicationId, string objectId, string audience, string aadAuthority) { }
        public string AadAuthority { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public partial class InnerHealthErrorModel
    {
        internal InnerHealthErrorModel() { }
        public string Category { get { throw null; } }
        public string Causes { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string HealthCategory { get { throw null; } }
        public bool? IsCustomerResolvable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Source { get { throw null; } }
        public string Summary { get { throw null; } }
    }
    public partial class OperationStatus
    {
        internal OperationStatus() { }
        public string EndTime { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string StartTime { get { throw null; } }
        public string Status { get { throw null; } }
    }
    public partial class PlannedFailoverModel
    {
        public PlannedFailoverModel(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties PlannedFailoverModelCustomProperties { get { throw null; } set { } }
    }
    public abstract partial class PlannedFailoverModelCustomProperties
    {
        protected PlannedFailoverModelCustomProperties() { }
    }
    public partial class PlannedFailoverModelProperties
    {
        public PlannedFailoverModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties CustomProperties { get { throw null; } set { } }
    }
    public abstract partial class PolicyModelCustomProperties
    {
        protected PolicyModelCustomProperties() { }
    }
    public partial class PolicyModelProperties
    {
        public PolicyModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectedItemActiveLocation : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectedItemActiveLocation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation Primary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation Recovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectedItemDynamicMemoryConfig
    {
        public ProtectedItemDynamicMemoryConfig(long maximumMemoryInMegaBytes, long minimumMemoryInMegaBytes, int targetMemoryBufferPercentage) { }
        public long MaximumMemoryInMegaBytes { get { throw null; } set { } }
        public long MinimumMemoryInMegaBytes { get { throw null; } set { } }
        public int TargetMemoryBufferPercentage { get { throw null; } set { } }
    }
    public partial class ProtectedItemJobProperties
    {
        internal ProtectedItemJobProperties() { }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
    }
    public abstract partial class ProtectedItemModelCustomProperties
    {
        protected ProtectedItemModelCustomProperties() { }
    }
    public partial class ProtectedItemModelProperties
    {
        public ProtectedItemModelProperties(string policyName, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties customProperties) { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedJobs { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesCurrentJob CurrentJob { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties CustomProperties { get { throw null; } set { } }
        public string DraId { get { throw null; } }
        public string FabricId { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string FabricObjectName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthErrorModel> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedEnableProtectionJob LastFailedEnableProtectionJob { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastFailedPlannedFailoverJob LastFailedPlannedFailoverJob { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulPlannedFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulTestFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulUnplannedFailoverOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelPropertiesLastTestFailoverJob LastTestFailoverJob { get { throw null; } }
        public string PolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState? ProtectionState { get { throw null; } }
        public string ProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReplicationExtensionName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.HealthStatus? ReplicationHealth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState? ResynchronizationState { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public string SourceFabricProviderId { get { throw null; } }
        public string TargetDraId { get { throw null; } }
        public string TargetFabricId { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState? TestFailoverState { get { throw null; } }
        public string TestFailoverStateDescription { get { throw null; } }
    }
    public partial class ProtectedItemModelPropertiesCurrentJob : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties
    {
        internal ProtectedItemModelPropertiesCurrentJob() { }
    }
    public partial class ProtectedItemModelPropertiesLastFailedEnableProtectionJob : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties
    {
        internal ProtectedItemModelPropertiesLastFailedEnableProtectionJob() { }
    }
    public partial class ProtectedItemModelPropertiesLastFailedPlannedFailoverJob : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties
    {
        internal ProtectedItemModelPropertiesLastFailedPlannedFailoverJob() { }
    }
    public partial class ProtectedItemModelPropertiesLastTestFailoverJob : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties
    {
        internal ProtectedItemModelPropertiesLastTestFailoverJob() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverFailedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverFailedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverInProgressOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverInProgressOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CancelFailoverStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ChangeRecoveryPointCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ChangeRecoveryPointFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ChangeRecoveryPointInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ChangeRecoveryPointStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ChangeRecoveryPointStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverFailedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverFailedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverInProgressOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverInProgressOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState CommitFailoverStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState DisablingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState DisablingProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState EnablingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState EnablingProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationCompletedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationCompletedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState InitialReplicationStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState MarkedForDeletion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverTransitionStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState PlannedFailoverTransitionStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ProtectedStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ProtectedStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ReprotectFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ReprotectInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ReprotectStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState ReprotectStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverTransitionStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnplannedFailoverTransitionStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnprotectedStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState UnprotectedStatesEnd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RecoveryPointModelCustomProperties
    {
        protected RecoveryPointModelCustomProperties() { }
    }
    public partial class RecoveryPointModelProperties
    {
        internal RecoveryPointModelProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties CustomProperties { get { throw null; } }
        public System.DateTimeOffset RecoveryPointOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType RecoveryPointType { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType CrashConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ReplicationExtensionModelCustomProperties
    {
        protected ReplicationExtensionModelCustomProperties() { }
    }
    public partial class ReplicationExtensionModelProperties
    {
        public ReplicationExtensionModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationVaultType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationVaultType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType Migrate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResynchronizationState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResynchronizationState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState ResynchronizationCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState ResynchronizationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState ResynchronizationInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ResynchronizationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageContainerProperties
    {
        public StorageContainerProperties(string name, string clusterSharedVolumePath) { }
        public string ClusterSharedVolumePath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
    }
    public partial class TaskModel
    {
        internal TaskModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.WorkflowModelData> ChildrenWorkflows { get { throw null; } }
        public string CustomInstanceType { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState? State { get { throw null; } }
        public string TaskName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Skipped { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Started { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestFailoverCleanupWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties
    {
        internal TestFailoverCleanupWorkflowModelCustomProperties() { }
        public string Comments { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TestFailoverState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TestFailoverState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState MarkedForDeletion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverCleanupCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverCleanupInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState TestFailoverInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TestFailoverWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties
    {
        internal TestFailoverWorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
    }
    public partial class VaultModelPatch : Azure.ResourceManager.Models.ResourceData
    {
        public VaultModelPatch() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VaultModelProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultModelProperties
    {
        public VaultModelProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceResourceId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationVaultType? VaultType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmNicSelection : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmNicSelection(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection NotSelected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByDefault { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByUser { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByUserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VMwareDraModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties
    {
        public VMwareDraModelCustomProperties(string biosId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel marsAuthenticationIdentity) { }
        public string BiosId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.IdentityModel MarsAuthenticationIdentity { get { throw null; } set { } }
    }
    public partial class VMwareMigrateFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties
    {
        public VMwareMigrateFabricModelCustomProperties(string vmwareSiteId, string migrationSolutionId) { }
        public string MigrationSolutionId { get { throw null; } set { } }
        public string VmwareSiteId { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCIDiskInput
    {
        public VMwareToAzStackHCIDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public string StorageContainerId { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCINicInput
    {
        public VMwareToAzStackHCINicInput(string nicId, string label, string targetNetworkId, string testNetworkId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public string Label { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCIPlannedFailoverModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties
    {
        public VMwareToAzStackHCIPlannedFailoverModelCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCIPolicyModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties
    {
        public VMwareToAzStackHCIPolicyModelCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCIProtectedDiskProperties
    {
        internal VMwareToAzStackHCIProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
        public string DiskType { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsOSDisk { get { throw null; } }
        public string MigrateDiskName { get { throw null; } }
        public string SeedDiskName { get { throw null; } }
        public string SourceDiskId { get { throw null; } }
        public string SourceDiskName { get { throw null; } }
        public string StorageContainerId { get { throw null; } }
        public string StorageContainerLocalPath { get { throw null; } }
        public string TestMigrateDiskName { get { throw null; } }
    }
    public partial class VMwareToAzStackHCIProtectedItemModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties
    {
        public VMwareToAzStackHCIProtectedItemModelCustomProperties(string targetHciClusterId, string targetArcClusterCustomLocationId, string storageContainerId, string targetResourceGroupId, string customLocationRegion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCINicInput> nicsToInclude, string hyperVGeneration, string fabricDiscoveryMachineId, string runAsAccountId, string sourceDraName, string targetDraName) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? ActiveLocation { get { throw null; } }
        public string CustomLocationRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIDiskInput> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public string FabricDiscoveryMachineId { get { throw null; } set { } }
        public string FailoverRecoveryPointId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string HyperVGeneration { get { throw null; } set { } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
        public System.DateTimeOffset? LastReplicationUpdateOn { get { throw null; } }
        public int? MigrationProgressPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCINicInput> NicsToInclude { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public bool? PerformAutoResync { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedDiskProperties> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHCIProtectedNicProperties> ProtectedNics { get { throw null; } }
        public int? ResumeProgressPercentage { get { throw null; } }
        public long? ResumeRetryCount { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public long? ResyncRetryCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState? ResyncState { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string SourceApplianceName { get { throw null; } }
        public int? SourceCpuCores { get { throw null; } }
        public string SourceDraName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public string StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public string TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetDraName { get { throw null; } set { } }
        public string TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
    }
    public partial class VMwareToAzStackHCIProtectedNicProperties
    {
        internal VMwareToAzStackHCIProtectedNicProperties() { }
        public bool? IsPrimaryNic { get { throw null; } }
        public string Label { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? SelectionTypeForFailover { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
    }
    public partial class VMwareToAzStackHCIReplicationExtensionModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties
    {
        public VMwareToAzStackHCIReplicationExtensionModelCustomProperties(string vmwareFabricArmId, string azStackHciFabricArmId) { }
        public System.Uri AsrServiceUri { get { throw null; } }
        public string AzStackHciFabricArmId { get { throw null; } set { } }
        public string AzStackHciSiteId { get { throw null; } }
        public System.Uri GatewayServiceUri { get { throw null; } }
        public System.Uri RcmServiceUri { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string SourceGatewayServiceId { get { throw null; } }
        public string SourceStorageContainerName { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public string TargetGatewayServiceId { get { throw null; } }
        public string TargetStorageContainerName { get { throw null; } }
        public string VmwareFabricArmId { get { throw null; } set { } }
        public string VmwareSiteId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMwareToAzureMigrateResyncState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMwareToAzureMigrateResyncState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState PreparedForResynchronization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState StartedResynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class WorkflowModelCustomProperties
    {
        protected WorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AffectedObjectDetails { get { throw null; } }
    }
    public partial class WorkflowModelProperties
    {
        internal WorkflowModelProperties() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties CustomProperties { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ErrorModel> Errors { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string ObjectInternalId { get { throw null; } }
        public string ObjectInternalName { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType? ObjectType { get { throw null; } }
        public string ReplicationProviderId { get { throw null; } }
        public string SourceFabricProviderId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState? State { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TaskModel> Tasks { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowObjectType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowObjectType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType AvsDiskPool { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Dra { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Fabric { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Policy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType ProtectedItem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType RecoveryPlan { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType ReplicationExtension { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Vault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState CompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Started { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
