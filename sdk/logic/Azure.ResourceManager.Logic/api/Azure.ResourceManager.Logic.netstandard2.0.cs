namespace Azure.ResourceManager.Logic
{
    public partial class IntegrationAccountAgreementCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountAgreementCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agreementName, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agreementName, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Get(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountAgreementData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountAgreementData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType agreementType, string hostPartner, string guestPartner, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity hostIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity guestIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent content) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementType AgreementType { get { throw null; } set { } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAgreementContent Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity GuestIdentity { get { throw null; } set { } }
        public string GuestPartner { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity HostIdentity { get { throw null; } set { } }
        public string HostPartner { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
    }
    public partial class IntegrationAccountAgreementResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountAgreementResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string agreementName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountAssemblyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountAssemblyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Get(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountAssemblyDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountAssemblyDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountAssemblyProperties Properties { get { throw null; } set { } }
    }
    public partial class IntegrationAccountAssemblyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountAssemblyDefinitionResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string assemblyArtifactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountBatchConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Get(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountBatchConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountBatchConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBatchConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class IntegrationAccountBatchConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountBatchConfigurationResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string batchConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountCertificateData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountCertificateData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKeyReference Key { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public System.BinaryData PublicCertificate { get { throw null; } set { } }
    }
    public partial class IntegrationAccountCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountCertificateResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationAccountName, Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationAccountName, Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Get(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetAsync(string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
    }
    public partial class IntegrationAccountMapCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountMapCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mapName, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Get(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountMapResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountMapResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountMapResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountMapData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountMapData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType mapType) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountMapType MapType { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string ParametersSchemaRef { get { throw null; } set { } }
    }
    public partial class IntegrationAccountMapResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountMapResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountMapData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string mapName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountMapData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountPartnerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountPartnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string partnerName, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string partnerName, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Get(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountPartnerData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountPartnerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType partnerType, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerContent content) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity> B2BBusinessIdentities { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType PartnerType { get { throw null; } set { } }
    }
    public partial class IntegrationAccountPartnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountPartnerResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountPartnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string partnerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountPartnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.ListOperationCallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetIntegrationAccountAgreement(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetIntegrationAccountAgreementAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementCollection GetIntegrationAccountAgreements() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource> GetIntegrationAccountAssemblyDefinition(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource>> GetIntegrationAccountAssemblyDefinitionAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionCollection GetIntegrationAccountAssemblyDefinitions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource> GetIntegrationAccountBatchConfiguration(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource>> GetIntegrationAccountBatchConfigurationAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationCollection GetIntegrationAccountBatchConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource> GetIntegrationAccountCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountCertificateResource>> GetIntegrationAccountCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountCertificateCollection GetIntegrationAccountCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource> GetIntegrationAccountMap(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountMapResource>> GetIntegrationAccountMapAsync(string mapName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountMapCollection GetIntegrationAccountMaps() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource> GetIntegrationAccountPartner(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountPartnerResource>> GetIntegrationAccountPartnerAsync(string partnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountPartnerCollection GetIntegrationAccountPartners() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetIntegrationAccountSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetIntegrationAccountSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSchemaCollection GetIntegrationAccountSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetIntegrationAccountSession(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetIntegrationAccountSessionAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSessionCollection GetIntegrationAccountSessions() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey> GetKeyVaultKeys(Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultKey> GetKeyVaultKeysAsync(Azure.ResourceManager.Logic.Models.IntegrationAccountListKeyVaultKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response LogTrackingEvents(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> LogTrackingEventsAsync(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> RegenerateAccessKey(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> Update(Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> UpdateAsync(Azure.ResourceManager.Logic.IntegrationAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountSchemaData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountSchemaData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType schemaType) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DocumentName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType SchemaType { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    public partial class IntegrationAccountSchemaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountSchemaResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string schemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSchemaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationAccountSessionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>, System.Collections.IEnumerable
    {
        protected IntegrationAccountSessionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sessionName, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sessionName, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Get(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetAsync(string sessionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationAccountSessionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationAccountSessionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.BinaryData Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
    }
    public partial class IntegrationAccountSessionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationAccountSessionResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountSessionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string sessionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountSessionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountSessionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>, System.Collections.IEnumerable
    {
        protected IntegrationServiceEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string integrationServiceEnvironmentName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string integrationServiceEnvironmentName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Get(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetAsync(string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationServiceEnvironmentData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSku Sku { get { throw null; } set { } }
    }
    public partial class IntegrationServiceEnvironmentManagedApiCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>, System.Collections.IEnumerable
    {
        protected IntegrationServiceEnvironmentManagedApiCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string apiName, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Get(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentManagedApiData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public IntegrationServiceEnvironmentManagedApiData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceDefinitions ApiDefinitions { get { throw null; } }
        public System.Uri ApiDefinitionUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionParameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink DeploymentParametersContentLinkDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceGeneralInformation GeneralInformation { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourceMetadata Metadata { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiResourcePolicies Policies { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Uri> RuntimeUris { get { throw null; } }
        public System.Uri ServiceUri { get { throw null; } }
    }
    public partial class IntegrationServiceEnvironmentManagedApiResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationServiceEnvironmentManagedApiResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string integrationServiceEnvironmentName, string apiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo> GetIntegrationServiceEnvironmentManagedApiOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicApiOperationInfo> GetIntegrationServiceEnvironmentManagedApiOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class IntegrationServiceEnvironmentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IntegrationServiceEnvironmentResource() { }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string integrationServiceEnvironmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource> GetIntegrationServiceEnvironmentManagedApi(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource>> GetIntegrationServiceEnvironmentManagedApiAsync(string apiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiCollection GetIntegrationServiceEnvironmentManagedApis() { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>> GetIntegrationServiceEnvironmentNetworkHealth(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSubnetNetworkHealth>>> GetIntegrationServiceEnvironmentNetworkHealthAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition> GetIntegrationServiceEnvironmentSkus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinition> GetIntegrationServiceEnvironmentSkusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Restart(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RestartAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationServiceEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class LogicExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAgreementResource GetIntegrationAccountAgreementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAssemblyDefinitionResource GetIntegrationAccountAssemblyDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetIntegrationAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountBatchConfigurationResource GetIntegrationAccountBatchConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountCertificateResource GetIntegrationAccountCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountMapResource GetIntegrationAccountMapResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountPartnerResource GetIntegrationAccountPartnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountResource GetIntegrationAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountCollection GetIntegrationAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSchemaResource GetIntegrationAccountSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountSessionResource GetIntegrationAccountSessionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource>> GetIntegrationServiceEnvironmentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationServiceEnvironmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentManagedApiResource GetIntegrationServiceEnvironmentManagedApiResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource GetIntegrationServiceEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationServiceEnvironmentCollection GetIntegrationServiceEnvironments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.IntegrationServiceEnvironmentResource> GetIntegrationServiceEnvironmentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetLogicWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowResource GetLogicWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource GetLogicWorkflowRunActionRepetitionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource GetLogicWorkflowRunActionRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource GetLogicWorkflowRunActionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionResource GetLogicWorkflowRunActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource GetLogicWorkflowRunActionScopeRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource GetLogicWorkflowRunOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowRunResource GetLogicWorkflowRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowCollection GetLogicWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetLogicWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource GetLogicWorkflowTriggerHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowTriggerResource GetLogicWorkflowTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.LogicWorkflowVersionResource GetLogicWorkflowVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response ValidateByLocationWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidateByLocationWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogicWorkflowData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class LogicWorkflowRequestHistoryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogicWorkflowRequestHistoryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRequestHistoryProperties Properties { get { throw null; } set { } }
    }
    public partial class LogicWorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GenerateUpgradedDefinition(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GenerateUpgradedDefinitionAsync(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetLogicWorkflowRun(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetLogicWorkflowRunAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunCollection GetLogicWorkflowRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetLogicWorkflowTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetLogicWorkflowTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerCollection GetLogicWorkflowTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetLogicWorkflowVersion(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetLogicWorkflowVersionAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowVersionCollection GetLogicWorkflowVersions() { throw null; }
        public virtual Azure.Response<System.BinaryData> GetSwagger(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetSwaggerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Move(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.LogicWorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.LogicWorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowRegenerateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use Update(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.LogicWorkflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use UpdateAsync(WaitUntil waitUntil, LogicWorkflowData data, CancellationToken cancellationToken = default) instead.", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateByResourceGroup(Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateByResourceGroupAsync(Azure.ResourceManager.Logic.LogicWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionCollection() { }
        public virtual Azure.Response<bool> Exists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> Get(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionData : Azure.ResourceManager.Models.ResourceData
    {
        internal LogicWorkflowRunActionData() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation Correlation { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
    }
    public partial class LogicWorkflowRunActionRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogicWorkflowRunActionRepetitionDefinitionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Code { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunActionCorrelation Correlation { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.BinaryData Error { get { throw null; } set { } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public int? IterationCount { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowRepetitionIndex> RepetitionIndexes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkRetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } set { } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
    }
    public partial class LogicWorkflowRunActionRepetitionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRepetitionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRepetitionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryCollection GetLogicWorkflowRunActionRepetitionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource> GetLogicWorkflowRunActionRepetitionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionRequestHistoryResource>> GetLogicWorkflowRunActionRepetitionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.LogicExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource> GetLogicWorkflowRunActionRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionResource>> GetLogicWorkflowRunActionRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionCollection GetLogicWorkflowRunActionRepetitions() { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryCollection GetLogicWorkflowRunActionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource> GetLogicWorkflowRunActionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionRequestHistoryResource>> GetLogicWorkflowRunActionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetLogicWorkflowRunActionScopeRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetLogicWorkflowRunActionScopeRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionCollection GetLogicWorkflowRunActionScopeRepetitions() { throw null; }
    }
    public partial class LogicWorkflowRunActionScopeRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunActionScopeRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunActionScopeRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunActionScopeRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionScopeRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> Get(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowRunResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowRunData : Azure.ResourceManager.Models.ResourceData
    {
        internal LogicWorkflowRunData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowOutputParameterInfo> Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger Response { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRunTrigger Trigger { get { throw null; } }
        public System.DateTimeOffset? WaitEndOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Workflow { get { throw null; } }
    }
    public partial class LogicWorkflowRunOperationCollection : Azure.ResourceManager.ArmCollection
    {
        protected LogicWorkflowRunOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunOperationResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowRunResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource> GetLogicWorkflowRunAction(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunActionResource>> GetLogicWorkflowRunActionAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunActionCollection GetLogicWorkflowRunActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource> GetLogicWorkflowRunOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowRunOperationResource>> GetLogicWorkflowRunOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowRunOperationCollection GetLogicWorkflowRunOperations() { throw null; }
    }
    public partial class LogicWorkflowTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowTriggerCollection() { }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        internal LogicWorkflowTriggerData() { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public System.DateTimeOffset? NextExecutionOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence Recurrence { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Workflow { get { throw null; } }
    }
    public partial class LogicWorkflowTriggerHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowTriggerHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> Get(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowTriggerHistoryData : Azure.ResourceManager.Models.ResourceData
    {
        internal LogicWorkflowTriggerHistoryData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public bool? IsFired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Run { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
    }
    public partial class LogicWorkflowTriggerHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowTriggerHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName, string historyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resubmit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResubmitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowTriggerResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryCollection GetLogicWorkflowTriggerHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource> GetLogicWorkflowTriggerHistory(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowTriggerHistoryResource>> GetLogicWorkflowTriggerHistoryAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicJsonSchema> GetSchemaJson(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicJsonSchema>> GetSchemaJsonAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reset(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetState(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetStateAsync(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerStateActionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LogicWorkflowVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>, System.Collections.IEnumerable
    {
        protected LogicWorkflowVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> Get(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LogicWorkflowVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogicWorkflowVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationAccount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class LogicWorkflowVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LogicWorkflowVersionResource() { }
        public virtual Azure.ResourceManager.Logic.LogicWorkflowVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string versionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.LogicWorkflowVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri> GetCallbackUrlWorkflowVersionTrigger(string triggerName, Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackUri>> GetCallbackUrlWorkflowVersionTriggerAsync(string triggerName, Azure.ResourceManager.Logic.Models.ListOperationCallbackUrlParameterInfo info = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Logic.Models
{
    public partial class ArtifactContentProperties : Azure.ResourceManager.Logic.Models.ArtifactProperties
    {
        public ArtifactContentProperties() { }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink ContentLink { get { throw null; } set { } }
        public Azure.Core.ContentType? ContentType { get { throw null; } set { } }
    }
    public partial class ArtifactProperties
    {
        public ArtifactProperties() { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
    }
    public partial class AS2AcknowledgementConnectionSettings
    {
        public AS2AcknowledgementConnectionSettings(bool ignoreCertificateNameMismatch, bool supportHttpStatusCodeContinue, bool keepHttpConnectionAlive, bool unfoldHttpHeaders) { }
        public bool IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public bool KeepHttpConnectionAlive { get { throw null; } set { } }
        public bool SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public bool UnfoldHttpHeaders { get { throw null; } set { } }
    }
    public partial class AS2AgreementContent
    {
        public AS2AgreementContent(Azure.ResourceManager.Logic.Models.AS2OneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.AS2OneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.AS2OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2OneWayAgreement SendAgreement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2EncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2EncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes128 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes192 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Aes256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm Des3 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm RC2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2EnvelopeSettings
    {
        public AS2EnvelopeSettings(Azure.Core.ContentType messageContentType, bool transmitFileNameInMimeHeader, string fileNameTemplate, bool suspendMessageOnFileNameGenerationError, bool autoGenerateFileName) { }
        public bool AutoGenerateFileName { get { throw null; } set { } }
        public string FileNameTemplate { get { throw null; } set { } }
        public Azure.Core.ContentType MessageContentType { get { throw null; } set { } }
        public bool SuspendMessageOnFileNameGenerationError { get { throw null; } set { } }
        public bool TransmitFileNameInMimeHeader { get { throw null; } set { } }
    }
    public partial class AS2ErrorSettings
    {
        public AS2ErrorSettings(bool suspendDuplicateMessage, bool resendIfMdnNotReceived) { }
        public bool ResendIfMdnNotReceived { get { throw null; } set { } }
        public bool SuspendDuplicateMessage { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2HashingAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2HashingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm MD5 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm Sha2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm left, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm left, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2MdnSettings
    {
        public AS2MdnSettings(bool needMdn, bool signMdn, bool sendMdnAsynchronously, bool signOutboundMdnIfOptional, bool sendInboundMdnToMessageBox, Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm micHashingAlgorithm) { }
        public string DispositionNotificationTo { get { throw null; } set { } }
        public string MdnText { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2HashingAlgorithm MicHashingAlgorithm { get { throw null; } set { } }
        public bool NeedMdn { get { throw null; } set { } }
        public System.Uri ReceiptDeliveryUri { get { throw null; } set { } }
        public bool SendInboundMdnToMessageBox { get { throw null; } set { } }
        public bool SendMdnAsynchronously { get { throw null; } set { } }
        public bool SignMdn { get { throw null; } set { } }
        public bool SignOutboundMdnIfOptional { get { throw null; } set { } }
    }
    public partial class AS2MessageConnectionSettings
    {
        public AS2MessageConnectionSettings(bool ignoreCertificateNameMismatch, bool supportHttpStatusCodeContinue, bool keepHttpConnectionAlive, bool unfoldHttpHeaders) { }
        public bool IgnoreCertificateNameMismatch { get { throw null; } set { } }
        public bool KeepHttpConnectionAlive { get { throw null; } set { } }
        public bool SupportHttpStatusCodeContinue { get { throw null; } set { } }
        public bool UnfoldHttpHeaders { get { throw null; } set { } }
    }
    public partial class AS2OneWayAgreement
    {
        public AS2OneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.AS2ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.AS2ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
    }
    public partial class AS2ProtocolSettings
    {
        public AS2ProtocolSettings(Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings messageConnectionSettings, Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings acknowledgementConnectionSettings, Azure.ResourceManager.Logic.Models.AS2MdnSettings mdnSettings, Azure.ResourceManager.Logic.Models.AS2SecuritySettings securitySettings, Azure.ResourceManager.Logic.Models.AS2ValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.AS2ErrorSettings errorSettings) { }
        public Azure.ResourceManager.Logic.Models.AS2AcknowledgementConnectionSettings AcknowledgementConnectionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2ErrorSettings ErrorSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2MdnSettings MdnSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2MessageConnectionSettings MessageConnectionSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2SecuritySettings SecuritySettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2ValidationSettings ValidationSettings { get { throw null; } set { } }
    }
    public partial class AS2SecuritySettings
    {
        public AS2SecuritySettings(bool overrideGroupSigningCertificate, bool enableNrrForInboundEncodedMessages, bool enableNrrForInboundDecodedMessages, bool enableNrrForOutboundMdn, bool enableNrrForOutboundEncodedMessages, bool enableNrrForOutboundDecodedMessages, bool enableNrrForInboundMdn) { }
        public bool EnableNrrForInboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNrrForInboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNrrForInboundMdn { get { throw null; } set { } }
        public bool EnableNrrForOutboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNrrForOutboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNrrForOutboundMdn { get { throw null; } set { } }
        public string EncryptionCertificateName { get { throw null; } set { } }
        public bool OverrideGroupSigningCertificate { get { throw null; } set { } }
        public string Sha2AlgorithmFormat { get { throw null; } set { } }
        public string SigningCertificateName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AS2SigningAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AS2SigningAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm Sha2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm left, Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm left, Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AS2ValidationSettings
    {
        public AS2ValidationSettings(bool overrideMessageProperties, bool encryptMessage, bool signMessage, bool compressMessage, bool checkDuplicateMessage, int interchangeDuplicatesValidityDays, bool checkCertificateRevocationListOnSend, bool checkCertificateRevocationListOnReceive, Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm encryptionAlgorithm) { }
        public bool CheckCertificateRevocationListOnReceive { get { throw null; } set { } }
        public bool CheckCertificateRevocationListOnSend { get { throw null; } set { } }
        public bool CheckDuplicateMessage { get { throw null; } set { } }
        public bool CompressMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2EncryptionAlgorithm EncryptionAlgorithm { get { throw null; } set { } }
        public bool EncryptMessage { get { throw null; } set { } }
        public int InterchangeDuplicatesValidityDays { get { throw null; } set { } }
        public bool OverrideMessageProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.AS2SigningAlgorithm? SigningAlgorithm { get { throw null; } set { } }
        public bool SignMessage { get { throw null; } set { } }
    }
    public partial class EdifactAcknowledgementSettings
    {
        public EdifactAcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgement, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgement, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public bool NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public bool NeedLoopForValidMessages { get { throw null; } set { } }
        public bool NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public bool RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public bool SendSynchronousAcknowledgement { get { throw null; } set { } }
    }
    public partial class EdifactAgreementContent
    {
        public EdifactAgreementContent(Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactOneWayAgreement SendAgreement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdifactCharacterSet : System.IEquatable<Azure.ResourceManager.Logic.Models.EdifactCharacterSet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdifactCharacterSet(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Keca { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoa { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unob { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoc { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unod { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoe { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unof { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unog { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoh { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoi { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoj { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unok { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unox { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EdifactCharacterSet Unoy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.EdifactCharacterSet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.EdifactCharacterSet left, Azure.ResourceManager.Logic.Models.EdifactCharacterSet right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.EdifactCharacterSet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.EdifactCharacterSet left, Azure.ResourceManager.Logic.Models.EdifactCharacterSet right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EdifactDecimalIndicator
    {
        NotSpecified = 0,
        Comma = 1,
        Decimal = 2,
    }
    public partial class EdifactDelimiterOverride
    {
        public EdifactDelimiterOverride(int dataElementSeparator, int componentSeparator, int segmentTerminator, int repetitionSeparator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix, Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator decimalPointIndicator, int releaseIndicator) { }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator DecimalPointIndicator { get { throw null; } set { } }
        public string MessageAssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public int ReleaseIndicator { get { throw null; } set { } }
        public int RepetitionSeparator { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    public partial class EdifactEnvelopeOverride
    {
        public EdifactEnvelopeOverride() { }
        public string ApplicationPassword { get { throw null; } set { } }
        public string AssociationAssignedCode { get { throw null; } set { } }
        public string ControllingAgencyCode { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public string GroupHeaderMessageRelease { get { throw null; } set { } }
        public string GroupHeaderMessageVersion { get { throw null; } set { } }
        public string MessageAssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public string ReceiverApplicationQualifier { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string SenderApplicationQualifier { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    public partial class EdifactEnvelopeSettings
    {
        public EdifactEnvelopeSettings(bool applyDelimiterStringAdvice, bool createGroupingSegments, bool enableDefaultGroupHeaders, long interchangeControlNumberLowerBound, long interchangeControlNumberUpperBound, bool rolloverInterchangeControlNumber, long groupControlNumberLowerBound, long groupControlNumberUpperBound, bool rolloverGroupControlNumber, bool overwriteExistingTransactionSetControlNumber, long transactionSetControlNumberLowerBound, long transactionSetControlNumberUpperBound, bool rolloverTransactionSetControlNumber, bool isTestInterchange) { }
        public string ApplicationReferenceId { get { throw null; } set { } }
        public bool ApplyDelimiterStringAdvice { get { throw null; } set { } }
        public string CommunicationAgreementId { get { throw null; } set { } }
        public bool CreateGroupingSegments { get { throw null; } set { } }
        public bool EnableDefaultGroupHeaders { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public string GroupApplicationPassword { get { throw null; } set { } }
        public string GroupApplicationReceiverId { get { throw null; } set { } }
        public string GroupApplicationReceiverQualifier { get { throw null; } set { } }
        public string GroupApplicationSenderId { get { throw null; } set { } }
        public string GroupApplicationSenderQualifier { get { throw null; } set { } }
        public string GroupAssociationAssignedCode { get { throw null; } set { } }
        public string GroupControllingAgencyCode { get { throw null; } set { } }
        public long GroupControlNumberLowerBound { get { throw null; } set { } }
        public string GroupControlNumberPrefix { get { throw null; } set { } }
        public string GroupControlNumberSuffix { get { throw null; } set { } }
        public long GroupControlNumberUpperBound { get { throw null; } set { } }
        public string GroupMessageRelease { get { throw null; } set { } }
        public string GroupMessageVersion { get { throw null; } set { } }
        public long InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public string InterchangeControlNumberPrefix { get { throw null; } set { } }
        public string InterchangeControlNumberSuffix { get { throw null; } set { } }
        public long InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public bool IsTestInterchange { get { throw null; } set { } }
        public bool OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public string ProcessingPriorityCode { get { throw null; } set { } }
        public string ReceiverInternalIdentification { get { throw null; } set { } }
        public string ReceiverInternalSubIdentification { get { throw null; } set { } }
        public string ReceiverReverseRoutingAddress { get { throw null; } set { } }
        public string RecipientReferencePasswordQualifier { get { throw null; } set { } }
        public string RecipientReferencePasswordValue { get { throw null; } set { } }
        public bool RolloverGroupControlNumber { get { throw null; } set { } }
        public bool RolloverInterchangeControlNumber { get { throw null; } set { } }
        public bool RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public string SenderInternalIdentification { get { throw null; } set { } }
        public string SenderInternalSubIdentification { get { throw null; } set { } }
        public string SenderReverseRoutingAddress { get { throw null; } set { } }
        public long TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public string TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public string TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public long TransactionSetControlNumberUpperBound { get { throw null; } set { } }
    }
    public partial class EdifactFramingSettings
    {
        public EdifactFramingSettings(int protocolVersion, int dataElementSeparator, int componentSeparator, int segmentTerminator, int releaseIndicator, int repetitionSeparator, Azure.ResourceManager.Logic.Models.EdifactCharacterSet characterSet, Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator decimalPointIndicator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix) { }
        public string CharacterEncoding { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactCharacterSet CharacterSet { get { throw null; } set { } }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactDecimalIndicator DecimalPointIndicator { get { throw null; } set { } }
        public int ProtocolVersion { get { throw null; } set { } }
        public int ReleaseIndicator { get { throw null; } set { } }
        public int RepetitionSeparator { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string ServiceCodeListDirectoryVersion { get { throw null; } set { } }
    }
    public partial class EdifactMessageFilter
    {
        public EdifactMessageFilter(Azure.ResourceManager.Logic.Models.MessageFilterType messageFilterType) { }
        public Azure.ResourceManager.Logic.Models.MessageFilterType MessageFilterType { get { throw null; } set { } }
    }
    public partial class EdifactMessageIdentifier
    {
        public EdifactMessageIdentifier(string messageId) { }
        public string MessageId { get { throw null; } set { } }
    }
    public partial class EdifactOneWayAgreement
    {
        public EdifactOneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.EdifactProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.EdifactProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
    }
    public partial class EdifactProcessingSettings
    {
        public EdifactProcessingSettings(bool maskSecurityInfo, bool preserveInterchange, bool suspendInterchangeOnError, bool createEmptyXmlTagsForTrailingSeparators, bool useDotAsDecimalSeparator) { }
        public bool CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public bool MaskSecurityInfo { get { throw null; } set { } }
        public bool PreserveInterchange { get { throw null; } set { } }
        public bool SuspendInterchangeOnError { get { throw null; } set { } }
        public bool UseDotAsDecimalSeparator { get { throw null; } set { } }
    }
    public partial class EdifactProtocolSettings
    {
        public EdifactProtocolSettings(Azure.ResourceManager.Logic.Models.EdifactValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.EdifactFramingSettings framingSettings, Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings acknowledgementSettings, Azure.ResourceManager.Logic.Models.EdifactMessageFilter messageFilter, Azure.ResourceManager.Logic.Models.EdifactProcessingSettings processingSettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.EdifactSchemaReference> schemaReferences) { }
        public Azure.ResourceManager.Logic.Models.EdifactAcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactDelimiterOverride> EdifactDelimiterOverrides { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactEnvelopeOverride> EnvelopeOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.EdifactEnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactFramingSettings FramingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactMessageIdentifier> MessageFilterList { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.MessageFilterType? MessageFilterType { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactSchemaReference> SchemaReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.EdifactValidationOverride> ValidationOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.EdifactValidationSettings ValidationSettings { get { throw null; } set { } }
    }
    public partial class EdifactSchemaReference
    {
        public EdifactSchemaReference(string messageId, string messageVersion, string messageRelease, string schemaName) { }
        public string AssociationAssignedCode { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string MessageRelease { get { throw null; } set { } }
        public string MessageVersion { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string SenderApplicationQualifier { get { throw null; } set { } }
    }
    public partial class EdifactValidationOverride
    {
        public EdifactValidationOverride(string messageId, bool enforceCharacterSet, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy, bool trimLeadingAndTrailingSpacesAndZeroes) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool EnforceCharacterSet { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
    }
    public partial class EdifactValidationSettings
    {
        public EdifactValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
    }
    public partial class FlowAccessControlConfiguration
    {
        public FlowAccessControlConfiguration() { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Actions { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Contents { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy Triggers { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfigurationPolicy WorkflowManagement { get { throw null; } set { } }
    }
    public partial class FlowAccessControlConfigurationPolicy
    {
        public FlowAccessControlConfigurationPolicy() { }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.OpenAuthenticationAccessPolicy> AccessPolicies { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowAccessControlIPAddressRange> AllowedCallerIPAddresses { get { throw null; } }
    }
    public partial class FlowAccessControlIPAddressRange
    {
        public FlowAccessControlIPAddressRange() { }
        public string AddressRange { get { throw null; } set { } }
    }
    public partial class FlowEndpointIPAddress
    {
        public FlowEndpointIPAddress() { }
        public string CidrAddress { get { throw null; } set { } }
    }
    public partial class FlowEndpoints
    {
        public FlowEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress> AccessEndpointIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.FlowEndpointIPAddress> OutgoingIPAddresses { get { throw null; } }
    }
    public partial class FlowEndpointsConfiguration
    {
        public FlowEndpointsConfiguration() { }
        public Azure.ResourceManager.Logic.Models.FlowEndpoints Connector { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpoints Workflow { get { throw null; } set { } }
    }
    public partial class GenerateUpgradedDefinitionContent
    {
        public GenerateUpgradedDefinitionContent() { }
        public string TargetSchemaVersion { get { throw null; } set { } }
    }
    public partial class IntegrationAccountAgreementContent
    {
        public IntegrationAccountAgreementContent() { }
        public Azure.ResourceManager.Logic.Models.AS2AgreementContent AS2 { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactAgreementContent Edifact { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12AgreementContent X12 { get { throw null; } set { } }
    }
    public enum IntegrationAccountAgreementType
    {
        NotSpecified = 0,
        AS2 = 1,
        X12 = 2,
        Edifact = 3,
    }
    public partial class IntegrationAccountAssemblyProperties : Azure.ResourceManager.Logic.Models.ArtifactContentProperties
    {
        public IntegrationAccountAssemblyProperties(string assemblyName) { }
        public string AssemblyCulture { get { throw null; } set { } }
        public string AssemblyName { get { throw null; } set { } }
        public string AssemblyPublicKeyToken { get { throw null; } set { } }
        public string AssemblyVersion { get { throw null; } set { } }
    }
    public partial class IntegrationAccountBatchConfigurationProperties : Azure.ResourceManager.Logic.Models.ArtifactProperties
    {
        public IntegrationAccountBatchConfigurationProperties(string batchGroupName, Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria releaseCriteria) { }
        public string BatchGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBatchReleaseCriteria ReleaseCriteria { get { throw null; } set { } }
    }
    public partial class IntegrationAccountBatchReleaseCriteria
    {
        public IntegrationAccountBatchReleaseCriteria() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? MessageCount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class IntegrationAccountBusinessIdentity
    {
        public IntegrationAccountBusinessIdentity(string qualifier, string value) { }
        public string Qualifier { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public enum IntegrationAccountEventLevel
    {
        LogAlways = 0,
        Critical = 1,
        Error = 2,
        Warning = 3,
        Informational = 4,
        Verbose = 5,
    }
    public partial class IntegrationAccountKeyVaultKey
    {
        internal IntegrationAccountKeyVaultKey() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.Uri KeyId { get { throw null; } }
        public System.DateTimeOffset? UpdatedOn { get { throw null; } }
    }
    public partial class IntegrationAccountKeyVaultKeyReference
    {
        public IntegrationAccountKeyVaultKeyReference(string keyName) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public partial class IntegrationAccountKeyVaultNameReference : Azure.ResourceManager.Logic.Models.LogicResourceReference
    {
        public IntegrationAccountKeyVaultNameReference() { }
    }
    public partial class IntegrationAccountListKeyVaultKeyContent
    {
        public IntegrationAccountListKeyVaultKeyContent(Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference keyVault) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountKeyVaultNameReference KeyVault { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountMapType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountMapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountMapType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Liquid { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt20 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountMapType Xslt30 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType left, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountMapType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountMapType left, Azure.ResourceManager.Logic.Models.IntegrationAccountMapType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationAccountPartnerContent
    {
        public IntegrationAccountPartnerContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity> B2BBusinessIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountPartnerType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountPartnerType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType B2B { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType left, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType left, Azure.ResourceManager.Logic.Models.IntegrationAccountPartnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountSchemaType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType left, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType left, Azure.ResourceManager.Logic.Models.IntegrationAccountSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName left, Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName left, Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountTrackEventOperationOption : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountTrackEventOperationOption(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption DisableSourceInfoEnrich { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationAccountTrackingEvent
    {
        public IntegrationAccountTrackingEvent(Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel eventLevel, System.DateTimeOffset eventOn, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType recordType) { }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEventErrorInfo Error { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountEventLevel EventLevel { get { throw null; } }
        public System.DateTimeOffset EventOn { get { throw null; } }
        public System.BinaryData Record { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType RecordType { get { throw null; } }
    }
    public partial class IntegrationAccountTrackingEventErrorInfo
    {
        public IntegrationAccountTrackingEventErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class IntegrationAccountTrackingEventsContent
    {
        public IntegrationAccountTrackingEventsContent(string sourceType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent> events) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingEvent> Events { get { throw null; } }
        public string SourceType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountTrackEventOperationOption? TrackEventsOptions { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationAccountTrackingRecordType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationAccountTrackingRecordType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType AS2Mdn { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType AS2Message { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType Custom { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactFunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactFunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactInterchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactInterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactTransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType EdifactTransactionSetAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12FunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12FunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12Interchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12InterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12TransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType X12TransactionSetAcknowledgment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType left, Azure.ResourceManager.Logic.Models.IntegrationAccountTrackingRecordType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmenEncryptionKeyReference
    {
        public IntegrationServiceEnvironmenEncryptionKeyReference() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference KeyVault { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentAccessEndpointType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentAccessEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType External { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType Internal { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkDependency
    {
        internal IntegrationServiceEnvironmentNetworkDependency() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType? Category { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndpoint> Endpoints { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkDependencyCategoryType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkDependencyCategoryType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AccessEndpoints { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureManagement { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType AzureStorage { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType DiagnosticLogsAndMetrics { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType IntegrationServiceEnvironmentConnectors { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RecoveryService { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RedisCache { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType RegionalService { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType Sql { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType SslCertificateVerification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkDependencyHealth
    {
        internal IntegrationServiceEnvironmentNetworkDependencyHealth() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState? State { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkDependencyHealthState : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkDependencyHealthState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Healthy { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Unhealthy { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealthState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentNetworkEndpoint
    {
        internal IntegrationServiceEnvironmentNetworkEndpoint() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState? Accessibility { get { throw null; } }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Ports { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentNetworkEndPointAccessibilityState : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentNetworkEndPointAccessibilityState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState Available { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NotAvailable { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentProperties
    {
        public IntegrationServiceEnvironmentProperties() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmenEncryptionKeyReference EncryptionKeyReference { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public string IntegrationServiceEnvironmentId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowState? State { get { throw null; } set { } }
    }
    public partial class IntegrationServiceEnvironmentSku
    {
        public IntegrationServiceEnvironmentSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName? Name { get { throw null; } set { } }
    }
    public partial class IntegrationServiceEnvironmentSkuCapacity
    {
        internal IntegrationServiceEnvironmentSkuCapacity() { }
        public int? Default { get { throw null; } }
        public int? Maximum { get { throw null; } }
        public int? Minimum { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType? ScaleType { get { throw null; } }
    }
    public partial class IntegrationServiceEnvironmentSkuDefinition
    {
        internal IntegrationServiceEnvironmentSkuDefinition() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuCapacity Capacity { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuDefinitionSku Sku { get { throw null; } }
    }
    public partial class IntegrationServiceEnvironmentSkuDefinitionSku
    {
        internal IntegrationServiceEnvironmentSkuDefinitionSku() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName? Name { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName Developer { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName Premium { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceEnvironmentSkuScaleType : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceEnvironmentSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType left, Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceEnvironmentSubnetNetworkHealth
    {
        internal IntegrationServiceEnvironmentSubnetNetworkHealth() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkEndPointAccessibilityState NetworkDependencyHealthState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependency> OutboundNetworkDependencies { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyHealth OutboundNetworkHealth { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IntegrationServiceErrorCode : System.IEquatable<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IntegrationServiceErrorCode(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode IntegrationServiceEnvironmentNotFound { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode InvalidOperationId { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode left, Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode left, Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IntegrationServiceErrorInfo
    {
        internal IntegrationServiceErrorInfo() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceErrorCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.IntegrationServiceErrorInfo> Details { get { throw null; } }
        public System.BinaryData InnerError { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class IntegrationServiceNetworkConfiguration
    {
        public IntegrationServiceNetworkConfiguration() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicResourceReference> Subnets { get { throw null; } }
        public string VirtualNetworkAddressSpace { get { throw null; } set { } }
    }
    public partial class ListOperationCallbackUri
    {
        internal ListOperationCallbackUri() { }
        public System.Uri Uri { get { throw null; } }
    }
    public partial class ListOperationCallbackUrlParameterInfo
    {
        public ListOperationCallbackUrlParameterInfo() { }
        public Azure.ResourceManager.Logic.Models.LogicKeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? NotAfter { get { throw null; } set { } }
    }
    public partial class LogicApiDeploymentParameterMetadata
    {
        internal LogicApiDeploymentParameterMetadata() { }
        public string ApiDeploymentParameterMetadataType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility? Visibility { get { throw null; } }
    }
    public partial class LogicApiDeploymentParameterMetadataSet
    {
        internal LogicApiDeploymentParameterMetadataSet() { }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata PackageContentLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadata RedisCacheConnectionString { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiDeploymentParameterVisibility : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiDeploymentParameterVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility Internal { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicApiOperationAnnotation
    {
        public LogicApiOperationAnnotation() { }
        public string Family { get { throw null; } set { } }
        public int? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiOperationAnnotationStatus : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiOperationAnnotationStatus(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus Preview { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus left, Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus left, Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicApiOperationInfo : Azure.ResourceManager.Models.TrackedResourceData
    {
        public LogicApiOperationInfo(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationProperties Properties { get { throw null; } set { } }
    }
    public partial class LogicApiOperationProperties
    {
        public LogicApiOperationProperties() { }
        public Azure.ResourceManager.Logic.Models.LogicApiOperationAnnotation Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiReference Api { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchema InputsDefinition { get { throw null; } set { } }
        public bool? IsNotification { get { throw null; } set { } }
        public bool? IsPageable { get { throw null; } set { } }
        public bool? IsWebhook { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> ResponsesDefinition { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public string Trigger { get { throw null; } set { } }
        public string TriggerHint { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
    }
    public partial class LogicApiReference : Azure.ResourceManager.Logic.Models.LogicResourceReference
    {
        public LogicApiReference() { }
        public string BrandColor { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.BinaryData Swagger { get { throw null; } set { } }
    }
    public partial class LogicApiResourceDefinitions
    {
        internal LogicApiResourceDefinitions() { }
        public System.Uri ModifiedSwaggerUri { get { throw null; } }
        public System.Uri OriginalSwaggerUri { get { throw null; } }
    }
    public partial class LogicApiResourceGeneralInformation
    {
        internal LogicApiResourceGeneralInformation() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string ReleaseTag { get { throw null; } }
        public System.Uri TermsOfUseUri { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiTier? Tier { get { throw null; } }
    }
    public partial class LogicApiResourceMetadata
    {
        internal LogicApiResourceMetadata() { }
        public Azure.ResourceManager.Logic.Models.LogicApiType? ApiType { get { throw null; } }
        public string BrandColor { get { throw null; } }
        public string ConnectionType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicApiDeploymentParameterMetadataSet DeploymentParameters { get { throw null; } }
        public string HideKey { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod? WsdlImportMethod { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWsdlService WsdlService { get { throw null; } }
    }
    public partial class LogicApiResourcePolicies
    {
        internal LogicApiResourcePolicies() { }
        public System.BinaryData Content { get { throw null; } }
        public string ContentLink { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiTier : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiTier(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Enterprise { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiTier left, Azure.ResourceManager.Logic.Models.LogicApiTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiTier left, Azure.ResourceManager.Logic.Models.LogicApiTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicApiType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicApiType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicApiType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiType Rest { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicApiType Soap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicApiType left, Azure.ResourceManager.Logic.Models.LogicApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicApiType left, Azure.ResourceManager.Logic.Models.LogicApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicContentHash
    {
        internal LogicContentHash() { }
        public string Algorithm { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class LogicContentLink
    {
        public LogicContentLink() { }
        public Azure.ResourceManager.Logic.Models.LogicContentHash ContentHash { get { throw null; } }
        public long? ContentSize { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class LogicErrorInfo
    {
        internal LogicErrorInfo() { }
        public string Code { get { throw null; } }
    }
    public partial class LogicErrorResponse
    {
        public LogicErrorResponse() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class LogicExpression
    {
        internal LogicExpression() { }
        public Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicExpression> Subexpressions { get { throw null; } }
        public string Text { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
    }
    public partial class LogicExpressionErrorInfo : Azure.ResourceManager.Logic.Models.LogicErrorInfo
    {
        internal LogicExpressionErrorInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.LogicExpressionErrorInfo> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class LogicExpressionRoot : Azure.ResourceManager.Logic.Models.LogicExpression
    {
        internal LogicExpressionRoot() { }
        public string Path { get { throw null; } }
    }
    public partial class LogicJsonSchema
    {
        internal LogicJsonSchema() { }
        public System.BinaryData Content { get { throw null; } }
        public string Title { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicKeyType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicKeyType left, Azure.ResourceManager.Logic.Models.LogicKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicKeyType left, Azure.ResourceManager.Logic.Models.LogicKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicResourceReference
    {
        public LogicResourceReference() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
    }
    public partial class LogicSku
    {
        internal LogicSku() { }
        public Azure.ResourceManager.Logic.Models.LogicSkuName Name { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicResourceReference Plan { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicSkuName : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Premium { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Shared { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicSkuName left, Azure.ResourceManager.Logic.Models.LogicSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicSkuName left, Azure.ResourceManager.Logic.Models.LogicSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum LogicWorkflowDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class LogicWorkflowOutputParameterInfo : Azure.ResourceManager.Logic.Models.LogicWorkflowParameterInfo
    {
        public LogicWorkflowOutputParameterInfo() { }
        public System.BinaryData Error { get { throw null; } }
    }
    public partial class LogicWorkflowParameterInfo
    {
        public LogicWorkflowParameterInfo() { }
        public string Description { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType? ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowParameterType : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType left, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType left, Azure.ResourceManager.Logic.Models.LogicWorkflowParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Renewing { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowRecurrenceFrequency : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowRecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Second { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency left, Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency left, Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowRecurrenceSchedule
    {
        public LogicWorkflowRecurrenceSchedule() { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.LogicWorkflowDayOfWeek> WeekDays { get { throw null; } }
    }
    public partial class LogicWorkflowRecurrenceScheduleOccurrence
    {
        public LogicWorkflowRecurrenceScheduleOccurrence() { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowDayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class LogicWorkflowReference : Azure.ResourceManager.Logic.Models.LogicResourceReference
    {
        public LogicWorkflowReference() { }
    }
    public partial class LogicWorkflowRegenerateActionContent
    {
        public LogicWorkflowRegenerateActionContent() { }
        public Azure.ResourceManager.Logic.Models.LogicKeyType? KeyType { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRepetitionIndex
    {
        public LogicWorkflowRepetitionIndex(int itemIndex) { }
        public int ItemIndex { get { throw null; } set { } }
        public string ScopeName { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRequest
    {
        public LogicWorkflowRequest() { }
        public System.BinaryData Headers { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRequestHistoryProperties
    {
        public LogicWorkflowRequestHistoryProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRequest Request { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowResponse Response { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class LogicWorkflowResponse
    {
        public LogicWorkflowResponse() { }
        public Azure.ResourceManager.Logic.Models.LogicContentLink BodyLink { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public int? StatusCode { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRunActionCorrelation : Azure.ResourceManager.Logic.Models.LogicWorkflowRunCorrelation
    {
        public LogicWorkflowRunActionCorrelation() { }
        public System.Guid? ActionTrackingId { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRunCorrelation
    {
        public LogicWorkflowRunCorrelation() { }
        public System.Collections.Generic.IList<string> ClientKeywords { get { throw null; } }
        public string ClientTrackingId { get { throw null; } set { } }
    }
    public partial class LogicWorkflowRunTrigger
    {
        internal LogicWorkflowRunTrigger() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink InputsLink { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicContentLink OutputsLink { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public System.Guid? TrackingId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowState left, Azure.ResourceManager.Logic.Models.LogicWorkflowState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowState left, Azure.ResourceManager.Logic.Models.LogicWorkflowState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowStatus : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowStatus(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Aborted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Faulted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Ignored { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowStatus Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus left, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowStatus left, Azure.ResourceManager.Logic.Models.LogicWorkflowStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowTriggerCallbackQueryParameterInfo
    {
        internal LogicWorkflowTriggerCallbackQueryParameterInfo() { }
        public string ApiVersion { get { throw null; } }
        public string Se { get { throw null; } }
        public string Sig { get { throw null; } }
        public string Sp { get { throw null; } }
        public string Sv { get { throw null; } }
    }
    public partial class LogicWorkflowTriggerCallbackUri
    {
        internal LogicWorkflowTriggerCallbackUri() { }
        public string BasePath { get { throw null; } }
        public Azure.Core.RequestMethod? Method { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerCallbackQueryParameterInfo Queries { get { throw null; } }
        public string RelativePath { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RelativePathParameters { get { throw null; } }
        public string Value { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWorkflowTriggerProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWorkflowTriggerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWorkflowTriggerRecurrence
    {
        public LogicWorkflowTriggerRecurrence() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowRecurrenceSchedule Schedule { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class LogicWorkflowTriggerReference : Azure.ResourceManager.Logic.Models.LogicResourceReference
    {
        public LogicWorkflowTriggerReference() { }
        public string FlowName { get { throw null; } set { } }
        public string TriggerName { get { throw null; } set { } }
    }
    public partial class LogicWorkflowTriggerStateActionContent
    {
        public LogicWorkflowTriggerStateActionContent(Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference source) { }
        public Azure.ResourceManager.Logic.Models.LogicWorkflowTriggerReference Source { get { throw null; } }
    }
    public partial class LogicWorkRetryHistory
    {
        public LogicWorkRetryHistory() { }
        public string ClientRequestId { get { throw null; } set { } }
        public string Code { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.LogicErrorResponse Error { get { throw null; } set { } }
        public string ServiceRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicWsdlImportMethod : System.IEquatable<Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicWsdlImportMethod(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod SoapPassThrough { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod SoapToRest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod left, Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod left, Azure.ResourceManager.Logic.Models.LogicWsdlImportMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogicWsdlService
    {
        internal LogicWsdlService() { }
        public System.Collections.Generic.IReadOnlyList<string> EndpointQualifiedNames { get { throw null; } }
        public string QualifiedName { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageFilterType : System.IEquatable<Azure.ResourceManager.Logic.Models.MessageFilterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageFilterType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType Exclude { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType Include { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MessageFilterType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.MessageFilterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.MessageFilterType left, Azure.ResourceManager.Logic.Models.MessageFilterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.MessageFilterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.MessageFilterType left, Azure.ResourceManager.Logic.Models.MessageFilterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenAuthenticationAccessPolicy
    {
        public OpenAuthenticationAccessPolicy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.OpenAuthenticationPolicyClaim> Claims { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType? ProviderType { get { throw null; } set { } }
    }
    public partial class OpenAuthenticationPolicyClaim
    {
        public OpenAuthenticationPolicyClaim() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenAuthenticationProviderType : System.IEquatable<Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenAuthenticationProviderType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType AAD { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType left, Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType left, Azure.ResourceManager.Logic.Models.OpenAuthenticationProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SegmentTerminatorSuffix
    {
        None = 0,
        NotSpecified = 1,
        CR = 2,
        LF = 3,
        Crlf = 4,
    }
    public partial class SwaggerCustomDynamicList
    {
        public SwaggerCustomDynamicList() { }
        public string BuiltInOperation { get { throw null; } set { } }
        public string ItemsPath { get { throw null; } set { } }
        public string ItemTitlePath { get { throw null; } set { } }
        public string ItemValuePath { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties> Parameters { get { throw null; } }
    }
    public partial class SwaggerCustomDynamicProperties
    {
        public SwaggerCustomDynamicProperties() { }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties> Parameters { get { throw null; } }
        public string ValuePath { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicSchema
    {
        public SwaggerCustomDynamicSchema() { }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Parameters { get { throw null; } }
        public string ValuePath { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicTree
    {
        public SwaggerCustomDynamicTree() { }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand Browse { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeCommand Open { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeSettings Settings { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicTreeCommand
    {
        public SwaggerCustomDynamicTreeCommand() { }
        public string ItemFullTitlePath { get { throw null; } set { } }
        public string ItemIsParent { get { throw null; } set { } }
        public string ItemsPath { get { throw null; } set { } }
        public string ItemTitlePath { get { throw null; } set { } }
        public string ItemValuePath { get { throw null; } set { } }
        public string OperationId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameterInfo> Parameters { get { throw null; } }
        public string SelectableFilter { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicTreeParameterInfo
    {
        public SwaggerCustomDynamicTreeParameterInfo() { }
        public bool? IsRequired { get { throw null; } set { } }
        public string ParameterReference { get { throw null; } set { } }
        public string SelectedItemValuePath { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicTreeSettings
    {
        public SwaggerCustomDynamicTreeSettings() { }
        public bool? CanSelectLeafNodes { get { throw null; } set { } }
        public bool? CanSelectParentNodes { get { throw null; } set { } }
    }
    public partial class SwaggerExternalDocumentation
    {
        public SwaggerExternalDocumentation() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class SwaggerSchema
    {
        public SwaggerSchema() { }
        public System.BinaryData AdditionalProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.SwaggerSchema> AllOf { get { throw null; } }
        public string Discriminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicList DynamicListNew { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicProperties DynamicSchemaNew { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicSchema DynamicSchemaOld { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTree DynamicTree { get { throw null; } set { } }
        public System.BinaryData Example { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerExternalDocumentation ExternalDocs { get { throw null; } set { } }
        public bool? IsNotificationUrlExtension { get { throw null; } set { } }
        public bool? IsReadOnly { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchema Items { get { throw null; } set { } }
        public int? MaxProperties { get { throw null; } set { } }
        public int? MinProperties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> Properties { get { throw null; } }
        public string Reference { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredProperties { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchemaType? SchemaType { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerXml Xml { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SwaggerSchemaType : System.IEquatable<Azure.ResourceManager.Logic.Models.SwaggerSchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SwaggerSchemaType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Array { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Boolean { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType File { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Integer { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Null { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Number { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType Object { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SwaggerSchemaType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.SwaggerSchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.SwaggerSchemaType left, Azure.ResourceManager.Logic.Models.SwaggerSchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.SwaggerSchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.SwaggerSchemaType left, Azure.ResourceManager.Logic.Models.SwaggerSchemaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwaggerXml
    {
        public SwaggerXml() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public bool? IsAttribute { get { throw null; } set { } }
        public bool? IsWrapped { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrailingSeparatorPolicy : System.IEquatable<Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrailingSeparatorPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy Mandatory { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy NotAllowed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy Optional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy left, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy left, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UsageIndicator : System.IEquatable<Azure.ResourceManager.Logic.Models.UsageIndicator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UsageIndicator(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Information { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Production { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.UsageIndicator Test { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.UsageIndicator other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.UsageIndicator left, Azure.ResourceManager.Logic.Models.UsageIndicator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.UsageIndicator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.UsageIndicator left, Azure.ResourceManager.Logic.Models.UsageIndicator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12AcknowledgementSettings
    {
        public X12AcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgement, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgement, bool needImplementationAcknowledgement, bool batchImplementationAcknowledgement, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgement { get { throw null; } set { } }
        public bool BatchImplementationAcknowledgement { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgement { get { throw null; } set { } }
        public string FunctionalAcknowledgementVersion { get { throw null; } set { } }
        public string ImplementationAcknowledgementVersion { get { throw null; } set { } }
        public bool NeedFunctionalAcknowledgement { get { throw null; } set { } }
        public bool NeedImplementationAcknowledgement { get { throw null; } set { } }
        public bool NeedLoopForValidMessages { get { throw null; } set { } }
        public bool NeedTechnicalAcknowledgement { get { throw null; } set { } }
        public bool RolloverAcknowledgementControlNumber { get { throw null; } set { } }
        public bool SendSynchronousAcknowledgement { get { throw null; } set { } }
    }
    public partial class X12AgreementContent
    {
        public X12AgreementContent(Azure.ResourceManager.Logic.Models.X12OneWayAgreement receiveAgreement, Azure.ResourceManager.Logic.Models.X12OneWayAgreement sendAgreement) { }
        public Azure.ResourceManager.Logic.Models.X12OneWayAgreement ReceiveAgreement { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12OneWayAgreement SendAgreement { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12CharacterSet : System.IEquatable<Azure.ResourceManager.Logic.Models.X12CharacterSet>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12CharacterSet(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Basic { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Extended { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet Utf8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12CharacterSet other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12CharacterSet left, Azure.ResourceManager.Logic.Models.X12CharacterSet right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12CharacterSet (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12CharacterSet left, Azure.ResourceManager.Logic.Models.X12CharacterSet right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12DateFormat : System.IEquatable<Azure.ResourceManager.Logic.Models.X12DateFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12DateFormat(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat Ccyymmdd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12DateFormat Yymmdd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12DateFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12DateFormat left, Azure.ResourceManager.Logic.Models.X12DateFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12DateFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12DateFormat left, Azure.ResourceManager.Logic.Models.X12DateFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12DelimiterOverrides
    {
        public X12DelimiterOverrides(int dataElementSeparator, int componentSeparator, int segmentTerminator, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix, int replaceCharacter, bool replaceSeparatorsInPayload) { }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string ProtocolVersion { get { throw null; } set { } }
        public int ReplaceCharacter { get { throw null; } set { } }
        public bool ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
    }
    public partial class X12EnvelopeOverride
    {
        public X12EnvelopeOverride(string targetNamespace, string protocolVersion, string messageId, string responsibleAgencyCode, string headerVersion, string senderApplicationId, string receiverApplicationId, Azure.ResourceManager.Logic.Models.X12DateFormat dateFormat, Azure.ResourceManager.Logic.Models.X12TimeFormat timeFormat) { }
        public Azure.ResourceManager.Logic.Models.X12DateFormat DateFormat { get { throw null; } set { } }
        public string FunctionalIdentifierCode { get { throw null; } set { } }
        public string HeaderVersion { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public string ProtocolVersion { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public string ResponsibleAgencyCode { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public string TargetNamespace { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12TimeFormat TimeFormat { get { throw null; } set { } }
    }
    public partial class X12EnvelopeSettings
    {
        public X12EnvelopeSettings(int controlStandardsId, bool useControlStandardsIdAsRepetitionCharacter, string senderApplicationId, string receiverApplicationId, string controlVersionNumber, int interchangeControlNumberLowerBound, int interchangeControlNumberUpperBound, bool rolloverInterchangeControlNumber, bool enableDefaultGroupHeaders, int groupControlNumberLowerBound, int groupControlNumberUpperBound, bool rolloverGroupControlNumber, string groupHeaderAgencyCode, string groupHeaderVersion, int transactionSetControlNumberLowerBound, int transactionSetControlNumberUpperBound, bool rolloverTransactionSetControlNumber, bool overwriteExistingTransactionSetControlNumber, Azure.ResourceManager.Logic.Models.X12DateFormat groupHeaderDateFormat, Azure.ResourceManager.Logic.Models.X12TimeFormat groupHeaderTimeFormat, Azure.ResourceManager.Logic.Models.UsageIndicator usageIndicator) { }
        public int ControlStandardsId { get { throw null; } set { } }
        public string ControlVersionNumber { get { throw null; } set { } }
        public bool EnableDefaultGroupHeaders { get { throw null; } set { } }
        public string FunctionalGroupId { get { throw null; } set { } }
        public int GroupControlNumberLowerBound { get { throw null; } set { } }
        public int GroupControlNumberUpperBound { get { throw null; } set { } }
        public string GroupHeaderAgencyCode { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12DateFormat GroupHeaderDateFormat { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12TimeFormat GroupHeaderTimeFormat { get { throw null; } set { } }
        public string GroupHeaderVersion { get { throw null; } set { } }
        public int InterchangeControlNumberLowerBound { get { throw null; } set { } }
        public int InterchangeControlNumberUpperBound { get { throw null; } set { } }
        public bool OverwriteExistingTransactionSetControlNumber { get { throw null; } set { } }
        public string ReceiverApplicationId { get { throw null; } set { } }
        public bool RolloverGroupControlNumber { get { throw null; } set { } }
        public bool RolloverInterchangeControlNumber { get { throw null; } set { } }
        public bool RolloverTransactionSetControlNumber { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
        public int TransactionSetControlNumberLowerBound { get { throw null; } set { } }
        public string TransactionSetControlNumberPrefix { get { throw null; } set { } }
        public string TransactionSetControlNumberSuffix { get { throw null; } set { } }
        public int TransactionSetControlNumberUpperBound { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.UsageIndicator UsageIndicator { get { throw null; } set { } }
        public bool UseControlStandardsIdAsRepetitionCharacter { get { throw null; } set { } }
    }
    public partial class X12FramingSettings
    {
        public X12FramingSettings(int dataElementSeparator, int componentSeparator, bool replaceSeparatorsInPayload, int replaceCharacter, int segmentTerminator, Azure.ResourceManager.Logic.Models.X12CharacterSet characterSet, Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix segmentTerminatorSuffix) { }
        public Azure.ResourceManager.Logic.Models.X12CharacterSet CharacterSet { get { throw null; } set { } }
        public int ComponentSeparator { get { throw null; } set { } }
        public int DataElementSeparator { get { throw null; } set { } }
        public int ReplaceCharacter { get { throw null; } set { } }
        public bool ReplaceSeparatorsInPayload { get { throw null; } set { } }
        public int SegmentTerminator { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SegmentTerminatorSuffix SegmentTerminatorSuffix { get { throw null; } set { } }
    }
    public partial class X12MessageFilter
    {
        public X12MessageFilter(Azure.ResourceManager.Logic.Models.MessageFilterType messageFilterType) { }
        public Azure.ResourceManager.Logic.Models.MessageFilterType MessageFilterType { get { throw null; } set { } }
    }
    public partial class X12MessageIdentifier
    {
        public X12MessageIdentifier(string messageId) { }
        public string MessageId { get { throw null; } set { } }
    }
    public partial class X12OneWayAgreement
    {
        public X12OneWayAgreement(Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.X12ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.X12ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountBusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
    }
    public partial class X12ProcessingSettings
    {
        public X12ProcessingSettings(bool maskSecurityInfo, bool convertImpliedDecimal, bool preserveInterchange, bool suspendInterchangeOnError, bool createEmptyXmlTagsForTrailingSeparators, bool useDotAsDecimalSeparator) { }
        public bool ConvertImpliedDecimal { get { throw null; } set { } }
        public bool CreateEmptyXmlTagsForTrailingSeparators { get { throw null; } set { } }
        public bool MaskSecurityInfo { get { throw null; } set { } }
        public bool PreserveInterchange { get { throw null; } set { } }
        public bool SuspendInterchangeOnError { get { throw null; } set { } }
        public bool UseDotAsDecimalSeparator { get { throw null; } set { } }
    }
    public partial class X12ProtocolSettings
    {
        public X12ProtocolSettings(Azure.ResourceManager.Logic.Models.X12ValidationSettings validationSettings, Azure.ResourceManager.Logic.Models.X12FramingSettings framingSettings, Azure.ResourceManager.Logic.Models.X12EnvelopeSettings envelopeSettings, Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings acknowledgementSettings, Azure.ResourceManager.Logic.Models.X12MessageFilter messageFilter, Azure.ResourceManager.Logic.Models.X12SecuritySettings securitySettings, Azure.ResourceManager.Logic.Models.X12ProcessingSettings processingSettings, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.X12SchemaReference> schemaReferences) { }
        public Azure.ResourceManager.Logic.Models.X12AcknowledgementSettings AcknowledgementSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12EnvelopeOverride> EnvelopeOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12EnvelopeSettings EnvelopeSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12FramingSettings FramingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12MessageIdentifier> MessageFilterList { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.MessageFilterType? MessageFilterType { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12ProcessingSettings ProcessingSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12SchemaReference> SchemaReferences { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12SecuritySettings SecuritySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12ValidationOverride> ValidationOverrides { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.X12ValidationSettings ValidationSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.X12DelimiterOverrides> X12DelimiterOverrides { get { throw null; } }
    }
    public partial class X12SchemaReference
    {
        public X12SchemaReference(string messageId, string schemaVersion, string schemaName) { }
        public string MessageId { get { throw null; } set { } }
        public string SchemaName { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } set { } }
        public string SenderApplicationId { get { throw null; } set { } }
    }
    public partial class X12SecuritySettings
    {
        public X12SecuritySettings(string authorizationQualifier, string securityQualifier) { }
        public string AuthorizationQualifier { get { throw null; } set { } }
        public string AuthorizationValue { get { throw null; } set { } }
        public string PasswordValue { get { throw null; } set { } }
        public string SecurityQualifier { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct X12TimeFormat : System.IEquatable<Azure.ResourceManager.Logic.Models.X12TimeFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public X12TimeFormat(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat Hhmm { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat Hhmmss { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat HhmmsSd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat HhmmsSdd { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.X12TimeFormat NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.X12TimeFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.X12TimeFormat left, Azure.ResourceManager.Logic.Models.X12TimeFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.X12TimeFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.X12TimeFormat left, Azure.ResourceManager.Logic.Models.X12TimeFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class X12ValidationOverride
    {
        public X12ValidationOverride(string messageId, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool validateCharacterSet, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
    }
    public partial class X12ValidationSettings
    {
        public X12ValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEdiTypes, bool validateXsdTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEdiTypes { get { throw null; } set { } }
        public bool ValidateXsdTypes { get { throw null; } set { } }
    }
}
