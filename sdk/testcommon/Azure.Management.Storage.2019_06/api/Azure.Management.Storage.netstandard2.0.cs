namespace Azure.Management.Storage
{
    public partial class BlobContainersClient
    {
        protected BlobContainersClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.LegalHold> ClearLegalHold(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.LegalHold>> ClearLegalHoldAsync(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.BlobContainer> Create(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.BlobContainer blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.BlobContainer>> CreateAsync(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.BlobContainer blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy> CreateOrUpdateImmutabilityPolicy(string resourceGroupName, string accountName, string containerName, string ifMatch = null, Azure.Management.Storage.Models.ImmutabilityPolicy parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy>> CreateOrUpdateImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch = null, Azure.Management.Storage.Models.ImmutabilityPolicy parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy> DeleteImmutabilityPolicy(string resourceGroupName, string accountName, string containerName, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy>> DeleteImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy> ExtendImmutabilityPolicy(string resourceGroupName, string accountName, string containerName, string ifMatch, Azure.Management.Storage.Models.ImmutabilityPolicy parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy>> ExtendImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, Azure.Management.Storage.Models.ImmutabilityPolicy parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.BlobContainer> Get(string resourceGroupName, string accountName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.BlobContainer>> GetAsync(string resourceGroupName, string accountName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy> GetImmutabilityPolicy(string resourceGroupName, string accountName, string containerName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy>> GetImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.LeaseContainerResponse> Lease(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LeaseContainerRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.LeaseContainerResponse>> LeaseAsync(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LeaseContainerRequest parameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.ListContainerItem> List(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.ListContainerItem> ListAsync(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy> LockImmutabilityPolicy(string resourceGroupName, string accountName, string containerName, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ImmutabilityPolicy>> LockImmutabilityPolicyAsync(string resourceGroupName, string accountName, string containerName, string ifMatch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.LegalHold> SetLegalHold(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.LegalHold>> SetLegalHoldAsync(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.LegalHold legalHold, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.BlobContainer> Update(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.BlobContainer blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.BlobContainer>> UpdateAsync(string resourceGroupName, string accountName, string containerName, Azure.Management.Storage.Models.BlobContainer blobContainer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BlobServicesClient
    {
        protected BlobServicesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.BlobServiceProperties> GetServiceProperties(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.BlobServiceProperties>> GetServicePropertiesAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.BlobServiceProperties> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.BlobServiceProperties> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.BlobServiceProperties> SetServiceProperties(string resourceGroupName, string accountName, Azure.Management.Storage.Models.BlobServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.BlobServiceProperties>> SetServicePropertiesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.BlobServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EncryptionScopesClient
    {
        protected EncryptionScopesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.EncryptionScope> Get(string resourceGroupName, string accountName, string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.EncryptionScope>> GetAsync(string resourceGroupName, string accountName, string encryptionScopeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.EncryptionScope> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.EncryptionScope> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.EncryptionScope> Patch(string resourceGroupName, string accountName, string encryptionScopeName, Azure.Management.Storage.Models.EncryptionScope encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.EncryptionScope>> PatchAsync(string resourceGroupName, string accountName, string encryptionScopeName, Azure.Management.Storage.Models.EncryptionScope encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.EncryptionScope> Put(string resourceGroupName, string accountName, string encryptionScopeName, Azure.Management.Storage.Models.EncryptionScope encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.EncryptionScope>> PutAsync(string resourceGroupName, string accountName, string encryptionScopeName, Azure.Management.Storage.Models.EncryptionScope encryptionScope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileServicesClient
    {
        protected FileServicesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileServiceProperties> GetServiceProperties(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileServiceProperties>> GetServicePropertiesAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileServiceItems> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileServiceItems>> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileServiceProperties> SetServiceProperties(string resourceGroupName, string accountName, Azure.Management.Storage.Models.FileServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileServiceProperties>> SetServicePropertiesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.FileServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FileSharesClient
    {
        protected FileSharesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileShare> Create(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.FileShare fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileShare>> CreateAsync(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.FileShare fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileShare> Get(string resourceGroupName, string accountName, string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileShare>> GetAsync(string resourceGroupName, string accountName, string shareName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.FileShareItem> List(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.FileShareItem> ListAsync(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restore(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestoreAsync(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.DeletedShare deletedShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.FileShare> Update(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.FileShare fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.FileShare>> UpdateAsync(string resourceGroupName, string accountName, string shareName, Azure.Management.Storage.Models.FileShare fileShare, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagementPoliciesClient
    {
        protected ManagementPoliciesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.ManagementPolicy> CreateOrUpdate(string resourceGroupName, string accountName, Azure.Management.Storage.Models.ManagementPolicy properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ManagementPolicy>> CreateOrUpdateAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.ManagementPolicy properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ManagementPolicy> Get(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ManagementPolicy>> GetAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ObjectReplicationPoliciesClient
    {
        protected ObjectReplicationPoliciesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.ObjectReplicationPolicy> CreateOrUpdate(string resourceGroupName, string accountName, string objectReplicationPolicyId, Azure.Management.Storage.Models.ObjectReplicationPolicy properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ObjectReplicationPolicy>> CreateOrUpdateAsync(string resourceGroupName, string accountName, string objectReplicationPolicyId, Azure.Management.Storage.Models.ObjectReplicationPolicy properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ObjectReplicationPolicy> Get(string resourceGroupName, string accountName, string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ObjectReplicationPolicy>> GetAsync(string resourceGroupName, string accountName, string objectReplicationPolicyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.ObjectReplicationPolicy> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.ObjectReplicationPolicy> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OperationsClient
    {
        protected OperationsClient() { }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.Operation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.Operation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionsClient
    {
        protected PrivateEndpointConnectionsClient() { }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.PrivateEndpointConnection> Get(string resourceGroupName, string accountName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.PrivateEndpointConnection>> GetAsync(string resourceGroupName, string accountName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.PrivateEndpointConnection> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.PrivateEndpointConnection> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.PrivateEndpointConnection> Put(string resourceGroupName, string accountName, string privateEndpointConnectionName, Azure.Management.Storage.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.PrivateEndpointConnection>> PutAsync(string resourceGroupName, string accountName, string privateEndpointConnectionName, Azure.Management.Storage.Models.PrivateEndpointConnection properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResourcesClient
    {
        protected PrivateLinkResourcesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.PrivateLinkResourceListResult> ListByStorageAccount(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.PrivateLinkResourceListResult>> ListByStorageAccountAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueClient
    {
        protected QueueClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageQueue> Create(string resourceGroupName, string accountName, string queueName, Azure.Management.Storage.Models.StorageQueue queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageQueue>> CreateAsync(string resourceGroupName, string accountName, string queueName, Azure.Management.Storage.Models.StorageQueue queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageQueue> Get(string resourceGroupName, string accountName, string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageQueue>> GetAsync(string resourceGroupName, string accountName, string queueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.ListQueue> List(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.ListQueue> ListAsync(string resourceGroupName, string accountName, string maxpagesize = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageQueue> Update(string resourceGroupName, string accountName, string queueName, Azure.Management.Storage.Models.StorageQueue queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageQueue>> UpdateAsync(string resourceGroupName, string accountName, string queueName, Azure.Management.Storage.Models.StorageQueue queue, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class QueueServicesClient
    {
        protected QueueServicesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.QueueServiceProperties> GetServiceProperties(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.QueueServiceProperties>> GetServicePropertiesAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ListQueueServices> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ListQueueServices>> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.QueueServiceProperties> SetServiceProperties(string resourceGroupName, string accountName, Azure.Management.Storage.Models.QueueServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.QueueServiceProperties>> SetServicePropertiesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.QueueServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SkusClient
    {
        protected SkusClient() { }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.SkuInformation> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.SkuInformation> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountsClient
    {
        protected StorageAccountsClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.CheckNameAvailabilityResult> CheckNameAvailability(Azure.Management.Storage.Models.StorageAccountCheckNameAvailabilityParameters accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.CheckNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.Management.Storage.Models.StorageAccountCheckNameAvailabilityParameters accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageAccount> GetProperties(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountExpand? expand = default(Azure.Management.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageAccount>> GetPropertiesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountExpand? expand = default(Azure.Management.Storage.Models.StorageAccountExpand?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.StorageAccount> List(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ListAccountSasResponse> ListAccountSAS(string resourceGroupName, string accountName, Azure.Management.Storage.Models.AccountSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ListAccountSasResponse>> ListAccountSASAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.AccountSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.StorageAccount> ListAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.StorageAccount> ListByResourceGroup(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.StorageAccount> ListByResourceGroupAsync(string resourceGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageAccountListKeysResult> ListKeys(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageAccountListKeysResult>> ListKeysAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ListServiceSasResponse> ListServiceSAS(string resourceGroupName, string accountName, Azure.Management.Storage.Models.ServiceSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ListServiceSasResponse>> ListServiceSASAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.ServiceSasParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageAccountListKeysResult> RegenerateKey(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountRegenerateKeyParameters regenerateKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageAccountListKeysResult>> RegenerateKeyAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountRegenerateKeyParameters regenerateKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeUserDelegationKeys(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeUserDelegationKeysAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Storage.StorageAccountsCreateOperation StartCreate(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Storage.StorageAccountsCreateOperation> StartCreateAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Storage.StorageAccountsFailoverOperation StartFailover(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Storage.StorageAccountsFailoverOperation> StartFailoverAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Management.Storage.StorageAccountsRestoreBlobRangesOperation StartRestoreBlobRanges(string resourceGroupName, string accountName, Azure.Management.Storage.Models.BlobRestoreParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Management.Storage.StorageAccountsRestoreBlobRangesOperation> StartRestoreBlobRangesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.BlobRestoreParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.StorageAccount> Update(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.StorageAccount>> UpdateAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.StorageAccountUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountsCreateOperation : Azure.Operation<Azure.Management.Storage.Models.StorageAccount>
    {
        internal StorageAccountsCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Storage.Models.StorageAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Storage.Models.StorageAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Storage.Models.StorageAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountsFailoverOperation : Azure.Operation<Azure.Response>
    {
        internal StorageAccountsFailoverOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Response>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAccountsRestoreBlobRangesOperation : Azure.Operation<Azure.Management.Storage.Models.BlobRestoreStatus>
    {
        internal StorageAccountsRestoreBlobRangesOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Management.Storage.Models.BlobRestoreStatus Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.Management.Storage.Models.BlobRestoreStatus>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageManagementClient
    {
        protected StorageManagementClient() { }
        public StorageManagementClient(string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Storage.StorageManagementClientOptions options = null) { }
        public StorageManagementClient(System.Uri endpoint, string subscriptionId, Azure.Core.TokenCredential tokenCredential, Azure.Management.Storage.StorageManagementClientOptions options = null) { }
        public virtual Azure.Management.Storage.BlobContainersClient GetBlobContainersClient() { throw null; }
        public virtual Azure.Management.Storage.BlobServicesClient GetBlobServicesClient() { throw null; }
        public virtual Azure.Management.Storage.EncryptionScopesClient GetEncryptionScopesClient() { throw null; }
        public virtual Azure.Management.Storage.FileServicesClient GetFileServicesClient() { throw null; }
        public virtual Azure.Management.Storage.FileSharesClient GetFileSharesClient() { throw null; }
        public virtual Azure.Management.Storage.ManagementPoliciesClient GetManagementPoliciesClient() { throw null; }
        public virtual Azure.Management.Storage.ObjectReplicationPoliciesClient GetObjectReplicationPoliciesClient() { throw null; }
        public virtual Azure.Management.Storage.OperationsClient GetOperationsClient() { throw null; }
        public virtual Azure.Management.Storage.PrivateEndpointConnectionsClient GetPrivateEndpointConnectionsClient() { throw null; }
        public virtual Azure.Management.Storage.PrivateLinkResourcesClient GetPrivateLinkResourcesClient() { throw null; }
        public virtual Azure.Management.Storage.QueueClient GetQueueClient() { throw null; }
        public virtual Azure.Management.Storage.QueueServicesClient GetQueueServicesClient() { throw null; }
        public virtual Azure.Management.Storage.SkusClient GetSkusClient() { throw null; }
        public virtual Azure.Management.Storage.StorageAccountsClient GetStorageAccountsClient() { throw null; }
        public virtual Azure.Management.Storage.TableClient GetTableClient() { throw null; }
        public virtual Azure.Management.Storage.TableServicesClient GetTableServicesClient() { throw null; }
        public virtual Azure.Management.Storage.UsagesClient GetUsagesClient() { throw null; }
    }
    public partial class StorageManagementClientOptions : Azure.Core.ClientOptions
    {
        public StorageManagementClientOptions() { }
    }
    public partial class TableClient
    {
        protected TableClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.Table> Create(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.Table>> CreateAsync(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.Table> Get(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.Table>> GetAsync(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.Table> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.Table> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.Table> Update(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.Table>> UpdateAsync(string resourceGroupName, string accountName, string tableName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TableServicesClient
    {
        protected TableServicesClient() { }
        public virtual Azure.Response<Azure.Management.Storage.Models.TableServiceProperties> GetServiceProperties(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.TableServiceProperties>> GetServicePropertiesAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.ListTableServices> List(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.ListTableServices>> ListAsync(string resourceGroupName, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.Management.Storage.Models.TableServiceProperties> SetServiceProperties(string resourceGroupName, string accountName, Azure.Management.Storage.Models.TableServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.Management.Storage.Models.TableServiceProperties>> SetServicePropertiesAsync(string resourceGroupName, string accountName, Azure.Management.Storage.Models.TableServiceProperties parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class UsagesClient
    {
        protected UsagesClient() { }
        public virtual Azure.Pageable<Azure.Management.Storage.Models.Usage> ListByLocation(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.Management.Storage.Models.Usage> ListByLocationAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.Management.Storage.Models
{
    public enum AccessTier
    {
        Hot = 0,
        Cool = 1,
    }
    public partial class AccountSasParameters
    {
        public AccountSasParameters(Azure.Management.Storage.Models.Services services, Azure.Management.Storage.Models.SignedResourceTypes resourceTypes, Azure.Management.Storage.Models.Permissions permissions, System.DateTimeOffset sharedAccessExpiryTime) { }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Permissions Permissions { get { throw null; } }
        public Azure.Management.Storage.Models.HttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.Management.Storage.Models.SignedResourceTypes ResourceTypes { get { throw null; } }
        public Azure.Management.Storage.Models.Services Services { get { throw null; } }
        public System.DateTimeOffset SharedAccessExpiryTime { get { throw null; } }
        public System.DateTimeOffset? SharedAccessStartTime { get { throw null; } set { } }
    }
    public enum AccountStatus
    {
        Available = 0,
        Unavailable = 1,
    }
    public partial class ActiveDirectoryProperties
    {
        public ActiveDirectoryProperties(string domainName, string netBiosDomainName, string forestName, string domainGuid, string domainSid, string azureStorageSid) { }
        public string AzureStorageSid { get { throw null; } set { } }
        public string DomainGuid { get { throw null; } set { } }
        public string DomainName { get { throw null; } set { } }
        public string DomainSid { get { throw null; } set { } }
        public string ForestName { get { throw null; } set { } }
        public string NetBiosDomainName { get { throw null; } set { } }
    }
    public partial class AzureEntityResource : Azure.Management.Storage.Models.Resource
    {
        public AzureEntityResource() { }
        public string Etag { get { throw null; } }
    }
    public partial class AzureFilesIdentityBasedAuthentication
    {
        public AzureFilesIdentityBasedAuthentication(Azure.Management.Storage.Models.DirectoryServiceOptions directoryServiceOptions) { }
        public Azure.Management.Storage.Models.ActiveDirectoryProperties ActiveDirectoryProperties { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DirectoryServiceOptions DirectoryServiceOptions { get { throw null; } set { } }
    }
    public partial class BlobContainer : Azure.Management.Storage.Models.AzureEntityResource
    {
        public BlobContainer() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public bool? DenyEncryptionScopeOverride { get { throw null; } set { } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.Management.Storage.Models.ImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.Management.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Management.Storage.Models.PublicAccess? PublicAccess { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class BlobRestoreParameters
    {
        public BlobRestoreParameters(System.DateTimeOffset timeToRestore, System.Collections.Generic.IEnumerable<Azure.Management.Storage.Models.BlobRestoreRange> blobRanges) { }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.BlobRestoreRange> BlobRanges { get { throw null; } }
        public System.DateTimeOffset TimeToRestore { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobRestoreProgressStatus : System.IEquatable<Azure.Management.Storage.Models.BlobRestoreProgressStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobRestoreProgressStatus(string value) { throw null; }
        public static Azure.Management.Storage.Models.BlobRestoreProgressStatus Complete { get { throw null; } }
        public static Azure.Management.Storage.Models.BlobRestoreProgressStatus Failed { get { throw null; } }
        public static Azure.Management.Storage.Models.BlobRestoreProgressStatus InProgress { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.BlobRestoreProgressStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.BlobRestoreProgressStatus left, Azure.Management.Storage.Models.BlobRestoreProgressStatus right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.BlobRestoreProgressStatus (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.BlobRestoreProgressStatus left, Azure.Management.Storage.Models.BlobRestoreProgressStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BlobRestoreRange
    {
        public BlobRestoreRange(string startRange, string endRange) { }
        public string EndRange { get { throw null; } set { } }
        public string StartRange { get { throw null; } set { } }
    }
    public partial class BlobRestoreStatus
    {
        public BlobRestoreStatus() { }
        public string FailureReason { get { throw null; } }
        public Azure.Management.Storage.Models.BlobRestoreParameters Parameters { get { throw null; } }
        public string RestoreId { get { throw null; } }
        public Azure.Management.Storage.Models.BlobRestoreProgressStatus? Status { get { throw null; } }
    }
    public partial class BlobServiceItems
    {
        internal BlobServiceItems() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.BlobServiceProperties> Value { get { throw null; } }
    }
    public partial class BlobServiceProperties : Azure.Management.Storage.Models.Resource
    {
        public BlobServiceProperties() { }
        public bool? AutomaticSnapshotPolicyEnabled { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ChangeFeed ChangeFeed { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DeleteRetentionPolicy ContainerDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Management.Storage.Models.CorsRules Cors { get { throw null; } set { } }
        public string DefaultServiceVersion { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DeleteRetentionPolicy DeleteRetentionPolicy { get { throw null; } set { } }
        public bool? IsVersioningEnabled { get { throw null; } set { } }
        public Azure.Management.Storage.Models.RestorePolicyProperties RestorePolicy { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Sku Sku { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Bypass : System.IEquatable<Azure.Management.Storage.Models.Bypass>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Bypass(string value) { throw null; }
        public static Azure.Management.Storage.Models.Bypass AzureServices { get { throw null; } }
        public static Azure.Management.Storage.Models.Bypass Logging { get { throw null; } }
        public static Azure.Management.Storage.Models.Bypass Metrics { get { throw null; } }
        public static Azure.Management.Storage.Models.Bypass None { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.Bypass other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.Bypass left, Azure.Management.Storage.Models.Bypass right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.Bypass (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.Bypass left, Azure.Management.Storage.Models.Bypass right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ChangeFeed
    {
        public ChangeFeed() { }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.Management.Storage.Models.Reason? Reason { get { throw null; } }
    }
    public partial class CorsRule
    {
        public CorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins, System.Collections.Generic.IEnumerable<Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem> allowedMethods, int maxAgeInSeconds, System.Collections.Generic.IEnumerable<string> exposedHeaders, System.Collections.Generic.IEnumerable<string> allowedHeaders) { }
        public System.Collections.Generic.IList<string> AllowedHeaders { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem> AllowedMethods { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        public System.Collections.Generic.IList<string> ExposedHeaders { get { throw null; } }
        public int MaxAgeInSeconds { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CorsRuleAllowedMethodsItem : System.IEquatable<Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CorsRuleAllowedMethodsItem(string value) { throw null; }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem Delete { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem GET { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem Head { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem Merge { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem Options { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem Post { get { throw null; } }
        public static Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem PUT { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem left, Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem left, Azure.Management.Storage.Models.CorsRuleAllowedMethodsItem right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CorsRules
    {
        public CorsRules() { }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.CorsRule> CorsRulesValue { get { throw null; } set { } }
    }
    public partial class CustomDomain
    {
        public CustomDomain(string name) { }
        public string Name { get { throw null; } set { } }
        public bool? UseSubDomainName { get { throw null; } set { } }
    }
    public partial class DateAfterCreation
    {
        public DateAfterCreation(float daysAfterCreationGreaterThan) { }
        public float DaysAfterCreationGreaterThan { get { throw null; } set { } }
    }
    public partial class DateAfterModification
    {
        public DateAfterModification(float daysAfterModificationGreaterThan) { }
        public float DaysAfterModificationGreaterThan { get { throw null; } set { } }
    }
    public enum DefaultAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class DeletedShare
    {
        public DeletedShare(string deletedShareName, string deletedShareVersion) { }
        public string DeletedShareName { get { throw null; } }
        public string DeletedShareVersion { get { throw null; } }
    }
    public partial class DeleteRetentionPolicy
    {
        public DeleteRetentionPolicy() { }
        public int? Days { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class Dimension
    {
        internal Dimension() { }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DirectoryServiceOptions : System.IEquatable<Azure.Management.Storage.Models.DirectoryServiceOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DirectoryServiceOptions(string value) { throw null; }
        public static Azure.Management.Storage.Models.DirectoryServiceOptions Aadds { get { throw null; } }
        public static Azure.Management.Storage.Models.DirectoryServiceOptions AD { get { throw null; } }
        public static Azure.Management.Storage.Models.DirectoryServiceOptions None { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.DirectoryServiceOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.DirectoryServiceOptions left, Azure.Management.Storage.Models.DirectoryServiceOptions right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.DirectoryServiceOptions (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.DirectoryServiceOptions left, Azure.Management.Storage.Models.DirectoryServiceOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnabledProtocols : System.IEquatable<Azure.Management.Storage.Models.EnabledProtocols>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnabledProtocols(string value) { throw null; }
        public static Azure.Management.Storage.Models.EnabledProtocols NFS { get { throw null; } }
        public static Azure.Management.Storage.Models.EnabledProtocols SMB { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.EnabledProtocols other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.EnabledProtocols left, Azure.Management.Storage.Models.EnabledProtocols right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.EnabledProtocols (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.EnabledProtocols left, Azure.Management.Storage.Models.EnabledProtocols right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encryption
    {
        public Encryption(Azure.Management.Storage.Models.KeySource keySource) { }
        public Azure.Management.Storage.Models.KeySource KeySource { get { throw null; } set { } }
        public Azure.Management.Storage.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public bool? RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.Management.Storage.Models.EncryptionServices Services { get { throw null; } set { } }
    }
    public partial class EncryptionScope : Azure.Management.Storage.Models.Resource
    {
        public EncryptionScope() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.Management.Storage.Models.EncryptionScopeKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.Management.Storage.Models.EncryptionScopeSource? Source { get { throw null; } set { } }
        public Azure.Management.Storage.Models.EncryptionScopeState? State { get { throw null; } set { } }
    }
    public partial class EncryptionScopeKeyVaultProperties
    {
        public EncryptionScopeKeyVaultProperties() { }
        public string KeyUri { get { throw null; } set { } }
    }
    public partial class EncryptionScopeListResult
    {
        internal EncryptionScopeListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.EncryptionScope> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeSource : System.IEquatable<Azure.Management.Storage.Models.EncryptionScopeSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeSource(string value) { throw null; }
        public static Azure.Management.Storage.Models.EncryptionScopeSource MicrosoftKeyVault { get { throw null; } }
        public static Azure.Management.Storage.Models.EncryptionScopeSource MicrosoftStorage { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.EncryptionScopeSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.EncryptionScopeSource left, Azure.Management.Storage.Models.EncryptionScopeSource right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.EncryptionScopeSource (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.EncryptionScopeSource left, Azure.Management.Storage.Models.EncryptionScopeSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionScopeState : System.IEquatable<Azure.Management.Storage.Models.EncryptionScopeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionScopeState(string value) { throw null; }
        public static Azure.Management.Storage.Models.EncryptionScopeState Disabled { get { throw null; } }
        public static Azure.Management.Storage.Models.EncryptionScopeState Enabled { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.EncryptionScopeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.EncryptionScopeState left, Azure.Management.Storage.Models.EncryptionScopeState right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.EncryptionScopeState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.EncryptionScopeState left, Azure.Management.Storage.Models.EncryptionScopeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionService
    {
        public EncryptionService() { }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.Management.Storage.Models.KeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledTime { get { throw null; } }
    }
    public partial class EncryptionServices
    {
        public EncryptionServices() { }
        public Azure.Management.Storage.Models.EncryptionService Blob { get { throw null; } set { } }
        public Azure.Management.Storage.Models.EncryptionService File { get { throw null; } set { } }
        public Azure.Management.Storage.Models.EncryptionService Queue { get { throw null; } set { } }
        public Azure.Management.Storage.Models.EncryptionService Table { get { throw null; } set { } }
    }
    public partial class Endpoints
    {
        public Endpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public Azure.Management.Storage.Models.StorageAccountInternetEndpoints InternetEndpoints { get { throw null; } set { } }
        public Azure.Management.Storage.Models.StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get { throw null; } set { } }
        public string Queue { get { throw null; } }
        public string Table { get { throw null; } }
        public string Web { get { throw null; } }
    }
    public partial class FileServiceItems
    {
        internal FileServiceItems() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.FileServiceProperties> Value { get { throw null; } }
    }
    public partial class FileServiceProperties : Azure.Management.Storage.Models.Resource
    {
        public FileServiceProperties() { }
        public Azure.Management.Storage.Models.CorsRules Cors { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DeleteRetentionPolicy ShareDeleteRetentionPolicy { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Sku Sku { get { throw null; } }
    }
    public partial class FileShare : Azure.Management.Storage.Models.AzureEntityResource
    {
        public FileShare() { }
        public Azure.Management.Storage.Models.ShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeTime { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public Azure.Management.Storage.Models.EnabledProtocols? EnabledProtocols { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.Management.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class FileShareItem : Azure.Management.Storage.Models.AzureEntityResource
    {
        public FileShareItem() { }
        public Azure.Management.Storage.Models.ShareAccessTier? AccessTier { get { throw null; } set { } }
        public System.DateTimeOffset? AccessTierChangeTime { get { throw null; } }
        public string AccessTierStatus { get { throw null; } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public Azure.Management.Storage.Models.EnabledProtocols? EnabledProtocols { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public Azure.Management.Storage.Models.RootSquashType? RootSquash { get { throw null; } set { } }
        public int? ShareQuota { get { throw null; } set { } }
        public long? ShareUsageBytes { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class FileShareItems
    {
        internal FileShareItems() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.FileShareItem> Value { get { throw null; } }
    }
    public partial class GeoReplicationStats
    {
        public GeoReplicationStats() { }
        public bool? CanFailover { get { throw null; } }
        public System.DateTimeOffset? LastSyncTime { get { throw null; } }
        public Azure.Management.Storage.Models.GeoReplicationStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeoReplicationStatus : System.IEquatable<Azure.Management.Storage.Models.GeoReplicationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeoReplicationStatus(string value) { throw null; }
        public static Azure.Management.Storage.Models.GeoReplicationStatus Bootstrap { get { throw null; } }
        public static Azure.Management.Storage.Models.GeoReplicationStatus Live { get { throw null; } }
        public static Azure.Management.Storage.Models.GeoReplicationStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.GeoReplicationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.GeoReplicationStatus left, Azure.Management.Storage.Models.GeoReplicationStatus right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.GeoReplicationStatus (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.GeoReplicationStatus left, Azure.Management.Storage.Models.GeoReplicationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum HttpProtocol
    {
        HttpsHttp = 0,
        Https = 1,
    }
    public partial class Identity
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } set { } }
    }
    public partial class ImmutabilityPolicy : Azure.Management.Storage.Models.AzureEntityResource
    {
        public ImmutabilityPolicy() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
    }
    public partial class ImmutabilityPolicyProperties
    {
        public ImmutabilityPolicyProperties() { }
        public bool? AllowProtectedAppendWrites { get { throw null; } set { } }
        public string Etag { get { throw null; } }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ImmutabilityPolicyState? State { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.UpdateHistoryProperty> UpdateHistory { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityPolicyState : System.IEquatable<Azure.Management.Storage.Models.ImmutabilityPolicyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityPolicyState(string value) { throw null; }
        public static Azure.Management.Storage.Models.ImmutabilityPolicyState Locked { get { throw null; } }
        public static Azure.Management.Storage.Models.ImmutabilityPolicyState Unlocked { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.ImmutabilityPolicyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.ImmutabilityPolicyState left, Azure.Management.Storage.Models.ImmutabilityPolicyState right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.ImmutabilityPolicyState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.ImmutabilityPolicyState left, Azure.Management.Storage.Models.ImmutabilityPolicyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImmutabilityPolicyUpdateType : System.IEquatable<Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImmutabilityPolicyUpdateType(string value) { throw null; }
        public static Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType Extend { get { throw null; } }
        public static Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType Lock { get { throw null; } }
        public static Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType Put { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType left, Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType left, Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRule
    {
        public IPRule(string iPAddressOrRange) { }
        public string Action { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
    }
    public enum KeyPermission
    {
        Read = 0,
        Full = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeySource : System.IEquatable<Azure.Management.Storage.Models.KeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeySource(string value) { throw null; }
        public static Azure.Management.Storage.Models.KeySource MicrosoftKeyvault { get { throw null; } }
        public static Azure.Management.Storage.Models.KeySource MicrosoftStorage { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.KeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.KeySource left, Azure.Management.Storage.Models.KeySource right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.KeySource (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.KeySource left, Azure.Management.Storage.Models.KeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.Management.Storage.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.Management.Storage.Models.KeyType Account { get { throw null; } }
        public static Azure.Management.Storage.Models.KeyType Service { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.KeyType left, Azure.Management.Storage.Models.KeyType right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.KeyType left, Azure.Management.Storage.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties() { }
        public string CurrentVersionedKeyIdentifier { get { throw null; } }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Kind : System.IEquatable<Azure.Management.Storage.Models.Kind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Kind(string value) { throw null; }
        public static Azure.Management.Storage.Models.Kind BlobStorage { get { throw null; } }
        public static Azure.Management.Storage.Models.Kind BlockBlobStorage { get { throw null; } }
        public static Azure.Management.Storage.Models.Kind FileStorage { get { throw null; } }
        public static Azure.Management.Storage.Models.Kind Storage { get { throw null; } }
        public static Azure.Management.Storage.Models.Kind StorageV2 { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.Kind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.Kind left, Azure.Management.Storage.Models.Kind right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.Kind (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.Kind left, Azure.Management.Storage.Models.Kind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LargeFileSharesState : System.IEquatable<Azure.Management.Storage.Models.LargeFileSharesState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LargeFileSharesState(string value) { throw null; }
        public static Azure.Management.Storage.Models.LargeFileSharesState Disabled { get { throw null; } }
        public static Azure.Management.Storage.Models.LargeFileSharesState Enabled { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.LargeFileSharesState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.LargeFileSharesState left, Azure.Management.Storage.Models.LargeFileSharesState right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.LargeFileSharesState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.LargeFileSharesState left, Azure.Management.Storage.Models.LargeFileSharesState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LeaseContainerRequest
    {
        public LeaseContainerRequest(Azure.Management.Storage.Models.LeaseContainerRequestAction action) { }
        public Azure.Management.Storage.Models.LeaseContainerRequestAction Action { get { throw null; } }
        public int? BreakPeriod { get { throw null; } set { } }
        public int? LeaseDuration { get { throw null; } set { } }
        public string LeaseId { get { throw null; } set { } }
        public string ProposedLeaseId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseContainerRequestAction : System.IEquatable<Azure.Management.Storage.Models.LeaseContainerRequestAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseContainerRequestAction(string value) { throw null; }
        public static Azure.Management.Storage.Models.LeaseContainerRequestAction Acquire { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseContainerRequestAction Break { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseContainerRequestAction Change { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseContainerRequestAction Release { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseContainerRequestAction Renew { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.LeaseContainerRequestAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.LeaseContainerRequestAction left, Azure.Management.Storage.Models.LeaseContainerRequestAction right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.LeaseContainerRequestAction (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.LeaseContainerRequestAction left, Azure.Management.Storage.Models.LeaseContainerRequestAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LeaseContainerResponse
    {
        internal LeaseContainerResponse() { }
        public string LeaseId { get { throw null; } }
        public string LeaseTimeSeconds { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseDuration : System.IEquatable<Azure.Management.Storage.Models.LeaseDuration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseDuration(string value) { throw null; }
        public static Azure.Management.Storage.Models.LeaseDuration Fixed { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseDuration Infinite { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.LeaseDuration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.LeaseDuration left, Azure.Management.Storage.Models.LeaseDuration right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.LeaseDuration (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.LeaseDuration left, Azure.Management.Storage.Models.LeaseDuration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseState : System.IEquatable<Azure.Management.Storage.Models.LeaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseState(string value) { throw null; }
        public static Azure.Management.Storage.Models.LeaseState Available { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseState Breaking { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseState Broken { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseState Expired { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseState Leased { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.LeaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.LeaseState left, Azure.Management.Storage.Models.LeaseState right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.LeaseState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.LeaseState left, Azure.Management.Storage.Models.LeaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeaseStatus : System.IEquatable<Azure.Management.Storage.Models.LeaseStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeaseStatus(string value) { throw null; }
        public static Azure.Management.Storage.Models.LeaseStatus Locked { get { throw null; } }
        public static Azure.Management.Storage.Models.LeaseStatus Unlocked { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.LeaseStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.LeaseStatus left, Azure.Management.Storage.Models.LeaseStatus right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.LeaseStatus (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.LeaseStatus left, Azure.Management.Storage.Models.LeaseStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LegalHold
    {
        public LegalHold(System.Collections.Generic.IEnumerable<string> tags) { }
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
    }
    public partial class LegalHoldProperties
    {
        public LegalHoldProperties() { }
        public bool? HasLegalHold { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.TagProperty> Tags { get { throw null; } set { } }
    }
    public partial class ListAccountSasResponse
    {
        internal ListAccountSasResponse() { }
        public string AccountSasToken { get { throw null; } }
    }
    public partial class ListContainerItem : Azure.Management.Storage.Models.AzureEntityResource
    {
        public ListContainerItem() { }
        public string DefaultEncryptionScope { get { throw null; } set { } }
        public bool? Deleted { get { throw null; } }
        public System.DateTimeOffset? DeletedTime { get { throw null; } }
        public bool? DenyEncryptionScopeOverride { get { throw null; } set { } }
        public bool? HasImmutabilityPolicy { get { throw null; } }
        public bool? HasLegalHold { get { throw null; } }
        public Azure.Management.Storage.Models.ImmutabilityPolicyProperties ImmutabilityPolicy { get { throw null; } }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseDuration? LeaseDuration { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseState? LeaseState { get { throw null; } }
        public Azure.Management.Storage.Models.LeaseStatus? LeaseStatus { get { throw null; } }
        public Azure.Management.Storage.Models.LegalHoldProperties LegalHold { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.Management.Storage.Models.PublicAccess? PublicAccess { get { throw null; } set { } }
        public int? RemainingRetentionDays { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ListContainerItems
    {
        internal ListContainerItems() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.ListContainerItem> Value { get { throw null; } }
    }
    public partial class ListQueue : Azure.Management.Storage.Models.Resource
    {
        public ListQueue() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
    }
    public partial class ListQueueResource
    {
        internal ListQueueResource() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.ListQueue> Value { get { throw null; } }
    }
    public partial class ListQueueServices
    {
        internal ListQueueServices() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.QueueServiceProperties> Value { get { throw null; } }
    }
    public partial class ListServiceSasResponse
    {
        internal ListServiceSasResponse() { }
        public string ServiceSasToken { get { throw null; } }
    }
    public partial class ListTableResource
    {
        internal ListTableResource() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.Table> Value { get { throw null; } }
    }
    public partial class ListTableServices
    {
        internal ListTableServices() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.TableServiceProperties> Value { get { throw null; } }
    }
    public partial class ManagementPolicy : Azure.Management.Storage.Models.Resource
    {
        public ManagementPolicy() { }
        public System.DateTimeOffset? LastModifiedTime { get { throw null; } }
        public Azure.Management.Storage.Models.ManagementPolicySchema Policy { get { throw null; } set { } }
    }
    public partial class ManagementPolicyAction
    {
        public ManagementPolicyAction() { }
        public Azure.Management.Storage.Models.ManagementPolicyBaseBlob BaseBlob { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ManagementPolicySnapShot Snapshot { get { throw null; } set { } }
    }
    public partial class ManagementPolicyBaseBlob
    {
        public ManagementPolicyBaseBlob() { }
        public Azure.Management.Storage.Models.DateAfterModification Delete { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DateAfterModification TierToArchive { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DateAfterModification TierToCool { get { throw null; } set { } }
    }
    public partial class ManagementPolicyDefinition
    {
        public ManagementPolicyDefinition(Azure.Management.Storage.Models.ManagementPolicyAction actions) { }
        public Azure.Management.Storage.Models.ManagementPolicyAction Actions { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ManagementPolicyFilter Filters { get { throw null; } set { } }
    }
    public partial class ManagementPolicyFilter
    {
        public ManagementPolicyFilter(System.Collections.Generic.IEnumerable<string> blobTypes) { }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.TagFilter> BlobIndexMatch { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BlobTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } set { } }
    }
    public partial class ManagementPolicyRule
    {
        public ManagementPolicyRule(string name, Azure.Management.Storage.Models.ManagementPolicyDefinition definition) { }
        public Azure.Management.Storage.Models.ManagementPolicyDefinition Definition { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class ManagementPolicySchema
    {
        public ManagementPolicySchema(System.Collections.Generic.IEnumerable<Azure.Management.Storage.Models.ManagementPolicyRule> rules) { }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.ManagementPolicyRule> Rules { get { throw null; } }
    }
    public partial class ManagementPolicySnapShot
    {
        public ManagementPolicySnapShot() { }
        public Azure.Management.Storage.Models.DateAfterCreation Delete { get { throw null; } set { } }
    }
    public partial class MetricSpecification
    {
        internal MetricSpecification() { }
        public string AggregationType { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.Dimension> Dimensions { get { throw null; } }
        public string DisplayDescription { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? FillGapWithZero { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceIdDimensionNameOverride { get { throw null; } }
        public string Unit { get { throw null; } }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet(Azure.Management.Storage.Models.DefaultAction defaultAction) { }
        public Azure.Management.Storage.Models.Bypass? Bypass { get { throw null; } set { } }
        public Azure.Management.Storage.Models.DefaultAction DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.IPRule> IpRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicies
    {
        internal ObjectReplicationPolicies() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.ObjectReplicationPolicy> Value { get { throw null; } }
    }
    public partial class ObjectReplicationPolicy : Azure.Management.Storage.Models.Resource
    {
        public ObjectReplicationPolicy() { }
        public string DestinationAccount { get { throw null; } set { } }
        public System.DateTimeOffset? EnabledTime { get { throw null; } }
        public string PolicyId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.ObjectReplicationPolicyRule> Rules { get { throw null; } set { } }
        public string SourceAccount { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicyFilter
    {
        public ObjectReplicationPolicyFilter() { }
        public string MinCreationTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> PrefixMatch { get { throw null; } set { } }
    }
    public partial class ObjectReplicationPolicyRule
    {
        public ObjectReplicationPolicyRule(string sourceContainer, string destinationContainer) { }
        public string DestinationContainer { get { throw null; } set { } }
        public Azure.Management.Storage.Models.ObjectReplicationPolicyFilter Filters { get { throw null; } set { } }
        public string RuleId { get { throw null; } set { } }
        public string SourceContainer { get { throw null; } set { } }
    }
    public partial class Operation
    {
        internal Operation() { }
        public Azure.Management.Storage.Models.OperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public string Origin { get { throw null; } }
        public Azure.Management.Storage.Models.ServiceSpecification ServiceSpecification { get { throw null; } }
    }
    public partial class OperationDisplay
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
    }
    public partial class OperationListResult
    {
        internal OperationListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.Operation> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Permissions : System.IEquatable<Azure.Management.Storage.Models.Permissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Permissions(string value) { throw null; }
        public static Azure.Management.Storage.Models.Permissions A { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions C { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions D { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions L { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions P { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions R { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions U { get { throw null; } }
        public static Azure.Management.Storage.Models.Permissions W { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.Permissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.Permissions left, Azure.Management.Storage.Models.Permissions right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.Permissions (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.Permissions left, Azure.Management.Storage.Models.Permissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpoint
    {
        public PrivateEndpoint() { }
        public string Id { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.Management.Storage.Models.Resource
    {
        public PrivateEndpointConnection() { }
        public Azure.Management.Storage.Models.PrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.Management.Storage.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionListResult
    {
        internal PrivateEndpointConnectionListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.PrivateEndpointConnection> Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState left, Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState left, Azure.Management.Storage.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus left, Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus left, Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.Management.Storage.Models.Resource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } set { } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.Management.Storage.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public enum ProvisioningState
    {
        Creating = 0,
        ResolvingDNS = 1,
        Succeeded = 2,
    }
    public enum PublicAccess
    {
        Container = 0,
        Blob = 1,
        None = 2,
    }
    public partial class QueueServiceProperties : Azure.Management.Storage.Models.Resource
    {
        public QueueServiceProperties() { }
        public Azure.Management.Storage.Models.CorsRules Cors { get { throw null; } set { } }
    }
    public enum Reason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasonCode : System.IEquatable<Azure.Management.Storage.Models.ReasonCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasonCode(string value) { throw null; }
        public static Azure.Management.Storage.Models.ReasonCode NotAvailableForSubscription { get { throw null; } }
        public static Azure.Management.Storage.Models.ReasonCode QuotaId { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.ReasonCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.ReasonCode left, Azure.Management.Storage.Models.ReasonCode right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.ReasonCode (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.ReasonCode left, Azure.Management.Storage.Models.ReasonCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Resource
    {
        public Resource() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class RestorePolicyProperties
    {
        public RestorePolicyProperties(bool enabled) { }
        public int? Days { get { throw null; } set { } }
        public bool Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? LastEnabledTime { get { throw null; } }
    }
    public partial class Restriction
    {
        internal Restriction() { }
        public Azure.Management.Storage.Models.ReasonCode? ReasonCode { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RootSquashType : System.IEquatable<Azure.Management.Storage.Models.RootSquashType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RootSquashType(string value) { throw null; }
        public static Azure.Management.Storage.Models.RootSquashType AllSquash { get { throw null; } }
        public static Azure.Management.Storage.Models.RootSquashType NoRootSquash { get { throw null; } }
        public static Azure.Management.Storage.Models.RootSquashType RootSquash { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.RootSquashType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.RootSquashType left, Azure.Management.Storage.Models.RootSquashType right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.RootSquashType (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.RootSquashType left, Azure.Management.Storage.Models.RootSquashType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingChoice : System.IEquatable<Azure.Management.Storage.Models.RoutingChoice>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingChoice(string value) { throw null; }
        public static Azure.Management.Storage.Models.RoutingChoice InternetRouting { get { throw null; } }
        public static Azure.Management.Storage.Models.RoutingChoice MicrosoftRouting { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.RoutingChoice other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.RoutingChoice left, Azure.Management.Storage.Models.RoutingChoice right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.RoutingChoice (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.RoutingChoice left, Azure.Management.Storage.Models.RoutingChoice right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RoutingPreference
    {
        public RoutingPreference() { }
        public bool? PublishInternetEndpoints { get { throw null; } set { } }
        public bool? PublishMicrosoftEndpoints { get { throw null; } set { } }
        public Azure.Management.Storage.Models.RoutingChoice? RoutingChoice { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Services : System.IEquatable<Azure.Management.Storage.Models.Services>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Services(string value) { throw null; }
        public static Azure.Management.Storage.Models.Services B { get { throw null; } }
        public static Azure.Management.Storage.Models.Services F { get { throw null; } }
        public static Azure.Management.Storage.Models.Services Q { get { throw null; } }
        public static Azure.Management.Storage.Models.Services T { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.Services other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.Services left, Azure.Management.Storage.Models.Services right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.Services (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.Services left, Azure.Management.Storage.Models.Services right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceSasParameters
    {
        public ServiceSasParameters(string canonicalizedResource) { }
        public string CacheControl { get { throw null; } set { } }
        public string CanonicalizedResource { get { throw null; } }
        public string ContentDisposition { get { throw null; } set { } }
        public string ContentEncoding { get { throw null; } set { } }
        public string ContentLanguage { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string Identifier { get { throw null; } set { } }
        public string IPAddressOrRange { get { throw null; } set { } }
        public string KeyToSign { get { throw null; } set { } }
        public string PartitionKeyEnd { get { throw null; } set { } }
        public string PartitionKeyStart { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Permissions? Permissions { get { throw null; } set { } }
        public Azure.Management.Storage.Models.HttpProtocol? Protocols { get { throw null; } set { } }
        public Azure.Management.Storage.Models.SignedResource? Resource { get { throw null; } set { } }
        public string RowKeyEnd { get { throw null; } set { } }
        public string RowKeyStart { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessExpiryTime { get { throw null; } set { } }
        public System.DateTimeOffset? SharedAccessStartTime { get { throw null; } set { } }
    }
    public partial class ServiceSpecification
    {
        internal ServiceSpecification() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.MetricSpecification> MetricSpecifications { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ShareAccessTier : System.IEquatable<Azure.Management.Storage.Models.ShareAccessTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ShareAccessTier(string value) { throw null; }
        public static Azure.Management.Storage.Models.ShareAccessTier Cool { get { throw null; } }
        public static Azure.Management.Storage.Models.ShareAccessTier Hot { get { throw null; } }
        public static Azure.Management.Storage.Models.ShareAccessTier Premium { get { throw null; } }
        public static Azure.Management.Storage.Models.ShareAccessTier TransactionOptimized { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.ShareAccessTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.ShareAccessTier left, Azure.Management.Storage.Models.ShareAccessTier right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.ShareAccessTier (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.ShareAccessTier left, Azure.Management.Storage.Models.ShareAccessTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignedResource : System.IEquatable<Azure.Management.Storage.Models.SignedResource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignedResource(string value) { throw null; }
        public static Azure.Management.Storage.Models.SignedResource B { get { throw null; } }
        public static Azure.Management.Storage.Models.SignedResource C { get { throw null; } }
        public static Azure.Management.Storage.Models.SignedResource F { get { throw null; } }
        public static Azure.Management.Storage.Models.SignedResource S { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.SignedResource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.SignedResource left, Azure.Management.Storage.Models.SignedResource right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.SignedResource (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.SignedResource left, Azure.Management.Storage.Models.SignedResource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignedResourceTypes : System.IEquatable<Azure.Management.Storage.Models.SignedResourceTypes>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignedResourceTypes(string value) { throw null; }
        public static Azure.Management.Storage.Models.SignedResourceTypes C { get { throw null; } }
        public static Azure.Management.Storage.Models.SignedResourceTypes O { get { throw null; } }
        public static Azure.Management.Storage.Models.SignedResourceTypes S { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.SignedResourceTypes other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.SignedResourceTypes left, Azure.Management.Storage.Models.SignedResourceTypes right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.SignedResourceTypes (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.SignedResourceTypes left, Azure.Management.Storage.Models.SignedResourceTypes right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Sku
    {
        public Sku(Azure.Management.Storage.Models.SkuName name) { }
        public Azure.Management.Storage.Models.SkuName Name { get { throw null; } set { } }
        public Azure.Management.Storage.Models.SkuTier? Tier { get { throw null; } }
    }
    public partial class SKUCapability
    {
        internal SKUCapability() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class SkuInformation
    {
        internal SkuInformation() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.SKUCapability> Capabilities { get { throw null; } }
        public Azure.Management.Storage.Models.Kind? Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public Azure.Management.Storage.Models.SkuName Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.Restriction> Restrictions { get { throw null; } }
        public Azure.Management.Storage.Models.SkuTier? Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuName : System.IEquatable<Azure.Management.Storage.Models.SkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuName(string value) { throw null; }
        public static Azure.Management.Storage.Models.SkuName PremiumLRS { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName PremiumZRS { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardGRS { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardGzrs { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardLRS { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardRagrs { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardRagzrs { get { throw null; } }
        public static Azure.Management.Storage.Models.SkuName StandardZRS { get { throw null; } }
        public bool Equals(Azure.Management.Storage.Models.SkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Management.Storage.Models.SkuName left, Azure.Management.Storage.Models.SkuName right) { throw null; }
        public static implicit operator Azure.Management.Storage.Models.SkuName (string value) { throw null; }
        public static bool operator !=(Azure.Management.Storage.Models.SkuName left, Azure.Management.Storage.Models.SkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SkuTier
    {
        Standard = 0,
        Premium = 1,
    }
    public enum State
    {
        Provisioning = 0,
        Deprovisioning = 1,
        Succeeded = 2,
        Failed = 3,
        NetworkSourceDeleted = 4,
    }
    public partial class StorageAccount : Azure.Management.Storage.Models.TrackedResource
    {
        public StorageAccount(string location) : base (default(string)) { }
        public Azure.Management.Storage.Models.AccessTier? AccessTier { get { throw null; } }
        public Azure.Management.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.Management.Storage.Models.BlobRestoreStatus BlobRestoreStatus { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.Management.Storage.Models.CustomDomain CustomDomain { get { throw null; } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Encryption Encryption { get { throw null; } }
        public bool? FailoverInProgress { get { throw null; } }
        public Azure.Management.Storage.Models.GeoReplicationStats GeoReplicationStats { get { throw null; } }
        public Azure.Management.Storage.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Kind? Kind { get { throw null; } }
        public Azure.Management.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public System.DateTimeOffset? LastGeoFailoverTime { get { throw null; } }
        public Azure.Management.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } }
        public Azure.Management.Storage.Models.Endpoints PrimaryEndpoints { get { throw null; } }
        public string PrimaryLocation { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Management.Storage.Models.PrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Management.Storage.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Management.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Endpoints SecondaryEndpoints { get { throw null; } }
        public string SecondaryLocation { get { throw null; } }
        public Azure.Management.Storage.Models.Sku Sku { get { throw null; } }
        public Azure.Management.Storage.Models.AccountStatus? StatusOfPrimary { get { throw null; } }
        public Azure.Management.Storage.Models.AccountStatus? StatusOfSecondary { get { throw null; } }
    }
    public partial class StorageAccountCheckNameAvailabilityParameters
    {
        public StorageAccountCheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class StorageAccountCreateParameters
    {
        public StorageAccountCreateParameters(Azure.Management.Storage.Models.Sku sku, Azure.Management.Storage.Models.Kind kind, string location) { }
        public Azure.Management.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Management.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.Management.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Identity Identity { get { throw null; } set { } }
        public bool? IsHnsEnabled { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Kind Kind { get { throw null; } }
        public Azure.Management.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public string Location { get { throw null; } }
        public Azure.Management.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Management.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Sku Sku { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public enum StorageAccountExpand
    {
        GeoReplicationStats = 0,
        BlobRestoreStatus = 1,
    }
    public partial class StorageAccountInternetEndpoints
    {
        public StorageAccountInternetEndpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public string Web { get { throw null; } }
    }
    public partial class StorageAccountKey
    {
        internal StorageAccountKey() { }
        public string KeyName { get { throw null; } }
        public Azure.Management.Storage.Models.KeyPermission? Permissions { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class StorageAccountListKeysResult
    {
        internal StorageAccountListKeysResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.StorageAccountKey> Keys { get { throw null; } }
    }
    public partial class StorageAccountListResult
    {
        internal StorageAccountListResult() { }
        public string NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.StorageAccount> Value { get { throw null; } }
    }
    public partial class StorageAccountMicrosoftEndpoints
    {
        public StorageAccountMicrosoftEndpoints() { }
        public string Blob { get { throw null; } }
        public string Dfs { get { throw null; } }
        public string File { get { throw null; } }
        public string Queue { get { throw null; } }
        public string Table { get { throw null; } }
        public string Web { get { throw null; } }
    }
    public partial class StorageAccountRegenerateKeyParameters
    {
        public StorageAccountRegenerateKeyParameters(string keyName) { }
        public string KeyName { get { throw null; } }
    }
    public partial class StorageAccountUpdateParameters
    {
        public StorageAccountUpdateParameters() { }
        public Azure.Management.Storage.Models.AccessTier? AccessTier { get { throw null; } set { } }
        public Azure.Management.Storage.Models.AzureFilesIdentityBasedAuthentication AzureFilesIdentityBasedAuthentication { get { throw null; } set { } }
        public Azure.Management.Storage.Models.CustomDomain CustomDomain { get { throw null; } set { } }
        public bool? EnableHttpsTrafficOnly { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Encryption Encryption { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Identity Identity { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Kind? Kind { get { throw null; } set { } }
        public Azure.Management.Storage.Models.LargeFileSharesState? LargeFileSharesState { get { throw null; } set { } }
        public Azure.Management.Storage.Models.NetworkRuleSet NetworkRuleSet { get { throw null; } set { } }
        public Azure.Management.Storage.Models.RoutingPreference RoutingPreference { get { throw null; } set { } }
        public Azure.Management.Storage.Models.Sku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class StorageQueue : Azure.Management.Storage.Models.Resource
    {
        public StorageQueue() { }
        public int? ApproximateMessageCount { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
    }
    public partial class StorageSkuListResult
    {
        internal StorageSkuListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.SkuInformation> Value { get { throw null; } }
    }
    public partial class Table : Azure.Management.Storage.Models.Resource
    {
        public Table() { }
        public string TableName { get { throw null; } }
    }
    public partial class TableServiceProperties : Azure.Management.Storage.Models.Resource
    {
        public TableServiceProperties() { }
        public Azure.Management.Storage.Models.CorsRules Cors { get { throw null; } set { } }
    }
    public partial class TagFilter
    {
        public TagFilter(string name, string op, string value) { }
        public string Name { get { throw null; } set { } }
        public string Op { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class TagProperty
    {
        public TagProperty() { }
        public string ObjectIdentifier { get { throw null; } }
        public string Tag { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class TrackedResource : Azure.Management.Storage.Models.Resource
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } set { } }
    }
    public partial class UpdateHistoryProperty
    {
        public UpdateHistoryProperty() { }
        public int? ImmutabilityPeriodSinceCreationInDays { get { throw null; } }
        public string ObjectIdentifier { get { throw null; } }
        public string TenantId { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.Management.Storage.Models.ImmutabilityPolicyUpdateType? Update { get { throw null; } }
        public string Upn { get { throw null; } }
    }
    public partial class Usage
    {
        internal Usage() { }
        public int? CurrentValue { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.Management.Storage.Models.UsageName Name { get { throw null; } }
        public Azure.Management.Storage.Models.UsageUnit? Unit { get { throw null; } }
    }
    public partial class UsageListResult
    {
        internal UsageListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Management.Storage.Models.Usage> Value { get { throw null; } }
    }
    public partial class UsageName
    {
        internal UsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public enum UsageUnit
    {
        Count = 0,
        Bytes = 1,
        Seconds = 2,
        Percent = 3,
        CountsPerSecond = 4,
        BytesPerSecond = 5,
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string virtualNetworkResourceId) { }
        public string Action { get { throw null; } set { } }
        public Azure.Management.Storage.Models.State? State { get { throw null; } set { } }
        public string VirtualNetworkResourceId { get { throw null; } set { } }
    }
}
