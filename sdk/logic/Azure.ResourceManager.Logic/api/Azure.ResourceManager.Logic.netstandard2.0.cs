namespace Azure.ResourceManager.Logic
{
    public partial class AssemblyDefinitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.AssemblyDefinitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.AssemblyDefinitionResource>, System.Collections.IEnumerable
    {
        protected AssemblyDefinitionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.AssemblyDefinitionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.AssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assemblyArtifactName, Azure.ResourceManager.Logic.AssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> Get(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.AssemblyDefinitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.AssemblyDefinitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> GetAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.AssemblyDefinitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.AssemblyDefinitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.AssemblyDefinitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.AssemblyDefinitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AssemblyDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AssemblyDefinitionData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.AssemblyProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.AssemblyProperties Properties { get { throw null; } set { } }
    }
    public partial class AssemblyDefinitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AssemblyDefinitionResource() { }
        public virtual Azure.ResourceManager.Logic.AssemblyDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string assemblyArtifactName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetContentCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.AssemblyDefinitionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.AssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.AssemblyDefinitionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BatchConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.BatchConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.BatchConfigurationResource>, System.Collections.IEnumerable
    {
        protected BatchConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.BatchConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.BatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.BatchConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string batchConfigurationName, Azure.ResourceManager.Logic.BatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> Get(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.BatchConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.BatchConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> GetAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.BatchConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.BatchConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.BatchConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.BatchConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BatchConfigurationData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public BatchConfigurationData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.BatchConfigurationProperties properties) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.BatchConfigurationProperties Properties { get { throw null; } set { } }
    }
    public partial class BatchConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BatchConfigurationResource() { }
        public virtual Azure.ResourceManager.Logic.BatchConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string integrationAccountName, string batchConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.BatchConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.BatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.BatchConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.BatchConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
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
        public IntegrationAccountAgreementData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.AgreementType agreementType, string hostPartner, string guestPartner, Azure.ResourceManager.Logic.Models.BusinessIdentity hostIdentity, Azure.ResourceManager.Logic.Models.BusinessIdentity guestIdentity, Azure.ResourceManager.Logic.Models.AgreementContent content) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.AgreementType AgreementType { get { throw null; } set { } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.AgreementContent Content { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity GuestIdentity { get { throw null; } set { } }
        public string GuestPartner { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity HostIdentity { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.IntegrationAccountAgreementData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Logic.Models.KeyVaultKeyReference Key { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string PublicCertificate { get { throw null; } set { } }
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
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.IntegrationAccountSkuName? SkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.WorkflowState? State { get { throw null; } set { } }
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
        public IntegrationAccountMapData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.MapType mapType) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ContentLink ContentLink { get { throw null; } }
        public string ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.MapType MapType { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public IntegrationAccountPartnerData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.PartnerType partnerType, Azure.ResourceManager.Logic.Models.PartnerContent content) : base (default(Azure.Core.AzureLocation)) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.BusinessIdentity> B2BBusinessIdentities { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.PartnerType PartnerType { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource> GetAssemblyDefinition(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.AssemblyDefinitionResource>> GetAssemblyDefinitionAsync(string assemblyArtifactName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.AssemblyDefinitionCollection GetAssemblyDefinitions() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource> GetBatchConfiguration(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.BatchConfigurationResource>> GetBatchConfigurationAsync(string batchConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.BatchConfigurationCollection GetBatchConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.CallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters getCallbackUrlParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.CallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters getCallbackUrlParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource> GetIntegrationAccountAgreement(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountAgreementResource>> GetIntegrationAccountAgreementAsync(string agreementName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.IntegrationAccountAgreementCollection GetIntegrationAccountAgreements() { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.KeyVaultKey> GetKeyVaultKeys(Azure.ResourceManager.Logic.Models.ListKeyVaultKeysDefinition listKeyVaultKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.KeyVaultKey> GetKeyVaultKeysAsync(Azure.ResourceManager.Logic.Models.ListKeyVaultKeysDefinition listKeyVaultKeys, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response LogTrackingEvents(Azure.ResourceManager.Logic.Models.TrackingEventsDefinition logTrackingEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> LogTrackingEventsAsync(Azure.ResourceManager.Logic.Models.TrackingEventsDefinition logTrackingEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> RegenerateAccessKey(Azure.ResourceManager.Logic.Models.RegenerateActionParameter regenerateAccessKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.RegenerateActionParameter regenerateAccessKey, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public IntegrationAccountSchemaData(Azure.Core.AzureLocation location, Azure.ResourceManager.Logic.Models.SchemaType schemaType) : base (default(Azure.Core.AzureLocation)) { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public string Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ContentLink ContentLink { get { throw null; } }
        public string ContentType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DocumentName { get { throw null; } set { } }
        public string FileName { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SchemaType SchemaType { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetContentCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetContentCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listContentCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.Logic.Models.ApiResourceDefinitions ApiDefinitions { get { throw null; } }
        public System.Uri ApiDefinitionUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiTier? Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ConnectionParameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink DeploymentParametersContentLinkDefinition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ApiResourceGeneralInformation GeneralInformation { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ApiResourceMetadata Metadata { get { throw null; } }
        public string NamePropertiesName { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiResourcePolicies Policies { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RuntimeUrls { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.ApiOperation> GetIntegrationServiceEnvironmentManagedApiOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.ApiOperation> GetIntegrationServiceEnvironmentManagedApiOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.Logic.AssemblyDefinitionResource GetAssemblyDefinitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.BatchConfigurationResource GetBatchConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource> GetIntegrationAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.IntegrationAccountAgreementResource GetIntegrationAccountAgreementResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.IntegrationAccountResource>> GetIntegrationAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string integrationAccountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> GetWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> GetWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowResource GetWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource GetWorkflowRunActionRepetitionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource GetWorkflowRunActionRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource GetWorkflowRunActionRequestHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunActionResource GetWorkflowRunActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource GetWorkflowRunActionScopeRepetitionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunOperationResource GetWorkflowRunOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowRunResource GetWorkflowRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowCollection GetWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Logic.WorkflowResource> GetWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowResource> GetWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource GetWorkflowTriggerHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowTriggerResource GetWorkflowTriggerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Logic.WorkflowVersionResource GetWorkflowVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response ValidateByLocationWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ValidateByLocationWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.Core.AzureLocation location, string workflowName, Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RequestHistoryData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public RequestHistoryData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.RequestHistoryProperties Properties { get { throw null; } set { } }
    }
    public partial class WorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowResource>, System.Collections.IEnumerable
    {
        protected WorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.WorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Logic.WorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkflowData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationAccount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.WorkflowParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class WorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Disable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Enable(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> EnableAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GenerateUpgradedDefinition(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GenerateUpgradedDefinitionAsync(Azure.ResourceManager.Logic.Models.GenerateUpgradedDefinitionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetCallbackUrl(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetCallbackUrlAsync(Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters listCallbackUrl, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetSwagger(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetSwaggerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource> GetWorkflowRun(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource>> GetWorkflowRunAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunCollection GetWorkflowRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource> GetWorkflowTrigger(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource>> GetWorkflowTriggerAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowTriggerCollection GetWorkflowTriggers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> GetWorkflowVersion(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> GetWorkflowVersionAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowVersionCollection GetWorkflowVersions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Move(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.WorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Logic.Models.WorkflowReference move, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RegenerateAccessKey(Azure.ResourceManager.Logic.Models.RegenerateActionParameter keyType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RegenerateAccessKeyAsync(Azure.ResourceManager.Logic.Models.RegenerateActionParameter keyType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ValidateByResourceGroup(Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateByResourceGroupAsync(Azure.ResourceManager.Logic.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunActionCollection() { }
        public virtual Azure.Response<bool> Exists(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource> Get(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunActionResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunActionResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource>> GetAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunActionData : Azure.ResourceManager.Models.ResourceData
    {
        internal WorkflowRunActionData() { }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.RunActionCorrelation Correlation { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink InputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.RetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    public partial class WorkflowRunActionRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunActionRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunActionRepetitionDefinitionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkflowRunActionRepetitionDefinitionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Code { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.RunActionCorrelation Correlation { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.BinaryData Error { get { throw null; } set { } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink InputsLink { get { throw null; } }
        public int? IterationCount { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink OutputsLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.RepetitionIndex> RepetitionIndexes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.RetryHistory> RetryHistory { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } set { } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    public partial class WorkflowRunActionRepetitionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunActionRepetitionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunActionRepetitionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunActionRepetitionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.RequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunActionRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunActionRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.ExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.ExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryCollection GetWorkflowRunActionRepetitionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource> GetWorkflowRunActionRepetitionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionRequestHistoryResource>> GetWorkflowRunActionRepetitionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunActionRequestHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunActionRequestHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> Get(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> GetAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunActionRequestHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunActionRequestHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.RequestHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string requestHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunActionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunActionResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.Models.ExpressionRoot> GetExpressionTraces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.Models.ExpressionRoot> GetExpressionTracesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource> GetWorkflowRunActionRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRepetitionResource>> GetWorkflowRunActionRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionRepetitionCollection GetWorkflowRunActionRepetitions() { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryCollection GetWorkflowRunActionRequestHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource> GetWorkflowRunActionRequestHistory(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionRequestHistoryResource>> GetWorkflowRunActionRequestHistoryAsync(string requestHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> GetWorkflowRunActionScopeRepetition(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> GetWorkflowRunActionScopeRepetitionAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionCollection GetWorkflowRunActionScopeRepetitions() { throw null; }
    }
    public partial class WorkflowRunActionScopeRepetitionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunActionScopeRepetitionCollection() { }
        public virtual Azure.Response<bool> Exists(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> Get(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> GetAsync(string repetitionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunActionScopeRepetitionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunActionScopeRepetitionResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionRepetitionDefinitionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string actionName, string repetitionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionScopeRepetitionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunResource>, System.Collections.IEnumerable
    {
        protected WorkflowRunCollection() { }
        public virtual Azure.Response<bool> Exists(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource> Get(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowRunResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowRunResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource>> GetAsync(string runName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowRunData : Azure.ResourceManager.Models.ResourceData
    {
        internal WorkflowRunData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.Logic.Models.WorkflowOutputParameter> Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowRunTrigger Response { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowRunTrigger Trigger { get { throw null; } }
        public System.DateTimeOffset? WaitEndOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ResourceReference Workflow { get { throw null; } }
    }
    public partial class WorkflowRunOperationCollection : Azure.ResourceManager.ArmCollection
    {
        protected WorkflowRunOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource> Get(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource>> GetAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunOperationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunOperationResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName, string operationId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowRunResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowRunResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response Cancel(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string runName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource> GetWorkflowRunAction(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunActionResource>> GetWorkflowRunActionAsync(string actionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunActionCollection GetWorkflowRunActions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource> GetWorkflowRunOperation(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowRunOperationResource>> GetWorkflowRunOperationAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowRunOperationCollection GetWorkflowRunOperations() { throw null; }
    }
    public partial class WorkflowTriggerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerResource>, System.Collections.IEnumerable
    {
        protected WorkflowTriggerCollection() { }
        public virtual Azure.Response<bool> Exists(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource> Get(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowTriggerResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowTriggerResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource>> GetAsync(string triggerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowTriggerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowTriggerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowTriggerData : Azure.ResourceManager.Models.ResourceData
    {
        internal WorkflowTriggerData() { }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastExecutionOn { get { throw null; } }
        public System.DateTimeOffset? NextExecutionOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowTriggerRecurrence Recurrence { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowState? State { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ResourceReference Workflow { get { throw null; } }
    }
    public partial class WorkflowTriggerHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>, System.Collections.IEnumerable
    {
        protected WorkflowTriggerHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> Get(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> GetAll(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> GetAllAsync(int? top = default(int?), string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>> GetAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowTriggerHistoryData : Azure.ResourceManager.Models.ResourceData
    {
        internal WorkflowTriggerHistoryData() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public bool? Fired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink InputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink OutputsLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ResourceReference Run { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    public partial class WorkflowTriggerHistoryResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowTriggerHistoryResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowTriggerHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName, string historyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Resubmit(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResubmitAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowTriggerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowTriggerResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowTriggerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string triggerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetCallbackUrl(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetCallbackUrlAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.JsonSchema> GetSchemaJson(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.JsonSchema>> GetSchemaJsonAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Logic.WorkflowTriggerHistoryCollection GetWorkflowTriggerHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource> GetWorkflowTriggerHistory(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowTriggerHistoryResource>> GetWorkflowTriggerHistoryAsync(string historyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reset(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ResetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Run(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SetState(Azure.ResourceManager.Logic.Models.SetTriggerStateActionDefinition setState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SetStateAsync(Azure.ResourceManager.Logic.Models.SetTriggerStateActionDefinition setState, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowVersionResource>, System.Collections.IEnumerable
    {
        protected WorkflowVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> Get(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Logic.WorkflowVersionResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Logic.WorkflowVersionResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> GetAsync(string versionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Logic.WorkflowVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Logic.WorkflowVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Logic.WorkflowVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.WorkflowVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowVersionData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public WorkflowVersionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.FlowAccessControlConfiguration AccessControl { get { throw null; } set { } }
        public string AccessEndpoint { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.BinaryData Definition { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.FlowEndpointsConfiguration EndpointsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationAccount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.WorkflowParameter> Parameters { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.LogicSku Sku { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowState? State { get { throw null; } set { } }
        public string Version { get { throw null; } }
    }
    public partial class WorkflowVersionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowVersionResource() { }
        public virtual Azure.ResourceManager.Logic.WorkflowVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName, string versionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri> GetCallbackUrlWorkflowVersionTrigger(string triggerName, Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters getCallbackUrlParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.Models.WorkflowTriggerCallbackUri>> GetCallbackUrlWorkflowVersionTriggerAsync(string triggerName, Azure.ResourceManager.Logic.Models.GetCallbackUrlParameters getCallbackUrlParameters = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Logic.WorkflowVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Logic.Models
{
    public partial class AgreementContent
    {
        public AgreementContent() { }
        public Azure.ResourceManager.Logic.Models.AS2AgreementContent AS2 { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EdifactAgreementContent Edifact { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.X12AgreementContent X12 { get { throw null; } set { } }
    }
    public enum AgreementType
    {
        NotSpecified = 0,
        AS2 = 1,
        X12 = 2,
        Edifact = 3,
    }
    public partial class ApiDeploymentParameterMetadata
    {
        internal ApiDeploymentParameterMetadata() { }
        public string ApiDeploymentParameterMetadataType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility? Visibility { get { throw null; } }
    }
    public partial class ApiDeploymentParameterMetadataSet
    {
        internal ApiDeploymentParameterMetadataSet() { }
        public Azure.ResourceManager.Logic.Models.ApiDeploymentParameterMetadata PackageContentLink { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiDeploymentParameterMetadata RedisCacheConnectionString { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiDeploymentParameterVisibility : System.IEquatable<Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiDeploymentParameterVisibility(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility Internal { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility left, Azure.ResourceManager.Logic.Models.ApiDeploymentParameterVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiOperation : Azure.ResourceManager.Models.TrackedResourceData
    {
        public ApiOperation(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Logic.Models.ApiOperationPropertiesDefinition Properties { get { throw null; } set { } }
    }
    public partial class ApiOperationAnnotation
    {
        public ApiOperationAnnotation() { }
        public string Family { get { throw null; } set { } }
        public int? Revision { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.StatusAnnotation? Status { get { throw null; } set { } }
    }
    public partial class ApiOperationPropertiesDefinition
    {
        public ApiOperationPropertiesDefinition() { }
        public Azure.ResourceManager.Logic.Models.ApiOperationAnnotation Annotation { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ApiReference Api { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SwaggerSchema InputsDefinition { get { throw null; } set { } }
        public bool? IsNotification { get { throw null; } set { } }
        public bool? IsWebhook { get { throw null; } set { } }
        public bool? Pageable { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> ResponsesDefinition { get { throw null; } }
        public string Summary { get { throw null; } set { } }
        public string Trigger { get { throw null; } set { } }
        public string TriggerHint { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
    }
    public partial class ApiReference : Azure.ResourceManager.Logic.Models.ResourceReference
    {
        public ApiReference() { }
        public string BrandColor { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ApiTier? Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Uri IconUri { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ResourceReference IntegrationServiceEnvironment { get { throw null; } set { } }
        public System.BinaryData Swagger { get { throw null; } set { } }
    }
    public partial class ApiResourceDefinitions
    {
        internal ApiResourceDefinitions() { }
        public System.Uri ModifiedSwaggerUri { get { throw null; } }
        public System.Uri OriginalSwaggerUri { get { throw null; } }
    }
    public partial class ApiResourceGeneralInformation
    {
        internal ApiResourceGeneralInformation() { }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Uri IconUri { get { throw null; } }
        public string ReleaseTag { get { throw null; } }
        public System.Uri TermsOfUseUri { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiTier? Tier { get { throw null; } }
    }
    public partial class ApiResourceMetadata
    {
        internal ApiResourceMetadata() { }
        public Azure.ResourceManager.Logic.Models.ApiType? ApiType { get { throw null; } }
        public string BrandColor { get { throw null; } }
        public string ConnectionType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ApiDeploymentParameterMetadataSet DeploymentParameters { get { throw null; } }
        public string HideKey { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WsdlImportMethod? WsdlImportMethod { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WsdlService WsdlService { get { throw null; } }
    }
    public partial class ApiResourcePolicies
    {
        internal ApiResourcePolicies() { }
        public string Content { get { throw null; } }
        public string ContentLink { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiTier : System.IEquatable<Azure.ResourceManager.Logic.Models.ApiTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiTier(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ApiTier Enterprise { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiTier NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiTier Premium { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.ApiTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.ApiTier left, Azure.ResourceManager.Logic.Models.ApiTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.ApiTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.ApiTier left, Azure.ResourceManager.Logic.Models.ApiTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApiType : System.IEquatable<Azure.ResourceManager.Logic.Models.ApiType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApiType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ApiType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiType Rest { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ApiType Soap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.ApiType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.ApiType left, Azure.ResourceManager.Logic.Models.ApiType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.ApiType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.ApiType left, Azure.ResourceManager.Logic.Models.ApiType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ArtifactContentPropertiesDefinition : Azure.ResourceManager.Logic.Models.ArtifactProperties
    {
        public ArtifactContentPropertiesDefinition() { }
        public System.BinaryData Content { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ContentLink ContentLink { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
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
    public partial class AS2EnvelopeSettings
    {
        public AS2EnvelopeSettings(string messageContentType, bool transmitFileNameInMimeHeader, string fileNameTemplate, bool suspendMessageOnFileNameGenerationError, bool autogenerateFileName) { }
        public bool AutogenerateFileName { get { throw null; } set { } }
        public string FileNameTemplate { get { throw null; } set { } }
        public string MessageContentType { get { throw null; } set { } }
        public bool SuspendMessageOnFileNameGenerationError { get { throw null; } set { } }
        public bool TransmitFileNameInMimeHeader { get { throw null; } set { } }
    }
    public partial class AS2ErrorSettings
    {
        public AS2ErrorSettings(bool suspendDuplicateMessage, bool resendIfMDNNotReceived) { }
        public bool ResendIfMDNNotReceived { get { throw null; } set { } }
        public bool SuspendDuplicateMessage { get { throw null; } set { } }
    }
    public partial class AS2MdnSettings
    {
        public AS2MdnSettings(bool needMDN, bool signMDN, bool sendMDNAsynchronously, bool signOutboundMDNIfOptional, bool sendInboundMDNToMessageBox, Azure.ResourceManager.Logic.Models.HashingAlgorithm micHashingAlgorithm) { }
        public string DispositionNotificationTo { get { throw null; } set { } }
        public string MdnText { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.HashingAlgorithm MicHashingAlgorithm { get { throw null; } set { } }
        public bool NeedMDN { get { throw null; } set { } }
        public System.Uri ReceiptDeliveryUri { get { throw null; } set { } }
        public bool SendInboundMDNToMessageBox { get { throw null; } set { } }
        public bool SendMDNAsynchronously { get { throw null; } set { } }
        public bool SignMDN { get { throw null; } set { } }
        public bool SignOutboundMDNIfOptional { get { throw null; } set { } }
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
        public AS2OneWayAgreement(Azure.ResourceManager.Logic.Models.BusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.BusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.AS2ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.AS2ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
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
        public AS2SecuritySettings(bool overrideGroupSigningCertificate, bool enableNRRForInboundEncodedMessages, bool enableNRRForInboundDecodedMessages, bool enableNRRForOutboundMDN, bool enableNRRForOutboundEncodedMessages, bool enableNRRForOutboundDecodedMessages, bool enableNRRForInboundMDN) { }
        public bool EnableNRRForInboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNRRForInboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNRRForInboundMDN { get { throw null; } set { } }
        public bool EnableNRRForOutboundDecodedMessages { get { throw null; } set { } }
        public bool EnableNRRForOutboundEncodedMessages { get { throw null; } set { } }
        public bool EnableNRRForOutboundMDN { get { throw null; } set { } }
        public string EncryptionCertificateName { get { throw null; } set { } }
        public bool OverrideGroupSigningCertificate { get { throw null; } set { } }
        public string Sha2AlgorithmFormat { get { throw null; } set { } }
        public string SigningCertificateName { get { throw null; } set { } }
    }
    public partial class AS2ValidationSettings
    {
        public AS2ValidationSettings(bool overrideMessageProperties, bool encryptMessage, bool signMessage, bool compressMessage, bool checkDuplicateMessage, int interchangeDuplicatesValidityDays, bool checkCertificateRevocationListOnSend, bool checkCertificateRevocationListOnReceive, Azure.ResourceManager.Logic.Models.EncryptionAlgorithm encryptionAlgorithm) { }
        public bool CheckCertificateRevocationListOnReceive { get { throw null; } set { } }
        public bool CheckCertificateRevocationListOnSend { get { throw null; } set { } }
        public bool CheckDuplicateMessage { get { throw null; } set { } }
        public bool CompressMessage { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EncryptionAlgorithm EncryptionAlgorithm { get { throw null; } set { } }
        public bool EncryptMessage { get { throw null; } set { } }
        public int InterchangeDuplicatesValidityDays { get { throw null; } set { } }
        public bool OverrideMessageProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.SigningAlgorithm? SigningAlgorithm { get { throw null; } set { } }
        public bool SignMessage { get { throw null; } set { } }
    }
    public partial class AssemblyProperties : Azure.ResourceManager.Logic.Models.ArtifactContentPropertiesDefinition
    {
        public AssemblyProperties(string assemblyName) { }
        public string AssemblyCulture { get { throw null; } set { } }
        public string AssemblyName { get { throw null; } set { } }
        public string AssemblyPublicKeyToken { get { throw null; } set { } }
        public string AssemblyVersion { get { throw null; } set { } }
    }
    public partial class AzureResourceErrorInfo : Azure.ResourceManager.Logic.Models.ErrorInfo
    {
        internal AzureResourceErrorInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.AzureResourceErrorInfo> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class BatchConfigurationProperties : Azure.ResourceManager.Logic.Models.ArtifactProperties
    {
        public BatchConfigurationProperties(string batchGroupName, Azure.ResourceManager.Logic.Models.BatchReleaseCriteria releaseCriteria) { }
        public string BatchGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BatchReleaseCriteria ReleaseCriteria { get { throw null; } set { } }
    }
    public partial class BatchReleaseCriteria
    {
        public BatchReleaseCriteria() { }
        public int? BatchSize { get { throw null; } set { } }
        public int? MessageCount { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.WorkflowTriggerRecurrence Recurrence { get { throw null; } set { } }
    }
    public partial class BusinessIdentity
    {
        public BusinessIdentity(string qualifier, string value) { }
        public string Qualifier { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class CallbackUri
    {
        internal CallbackUri() { }
        public string Value { get { throw null; } }
    }
    public partial class ContentHash
    {
        internal ContentHash() { }
        public string Algorithm { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ContentLink
    {
        public ContentLink() { }
        public Azure.ResourceManager.Logic.Models.ContentHash ContentHash { get { throw null; } }
        public long? ContentSize { get { throw null; } }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public enum DayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public enum DaysOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    public partial class EdifactAcknowledgementSettings
    {
        public EdifactAcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgements, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgements, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgements { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgements { get { throw null; } set { } }
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
        public EdifactOneWayAgreement(Azure.ResourceManager.Logic.Models.BusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.BusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.EdifactProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.EdifactProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
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
        public EdifactValidationOverride(string messageId, bool enforceCharacterSet, bool validateEDITypes, bool validateXSDTypes, bool allowLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy, bool trimLeadingAndTrailingSpacesAndZeroes) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool EnforceCharacterSet { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateEDITypes { get { throw null; } set { } }
        public bool ValidateXSDTypes { get { throw null; } set { } }
    }
    public partial class EdifactValidationSettings
    {
        public EdifactValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEDITypes, bool validateXSDTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEDITypes { get { throw null; } set { } }
        public bool ValidateXSDTypes { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.EncryptionAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm AES128 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm AES192 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm AES256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm DES3 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.EncryptionAlgorithm RC2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.EncryptionAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.EncryptionAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.EncryptionAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.EncryptionAlgorithm left, Azure.ResourceManager.Logic.Models.EncryptionAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ErrorInfo
    {
        internal ErrorInfo() { }
        public string Code { get { throw null; } }
    }
    public partial class ErrorProperties
    {
        public ErrorProperties() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorResponseCode : System.IEquatable<Azure.ResourceManager.Logic.Models.ErrorResponseCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorResponseCode(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ErrorResponseCode IntegrationServiceEnvironmentNotFound { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ErrorResponseCode InternalServerError { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ErrorResponseCode InvalidOperationId { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ErrorResponseCode NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.ErrorResponseCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.ErrorResponseCode left, Azure.ResourceManager.Logic.Models.ErrorResponseCode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.ErrorResponseCode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.ErrorResponseCode left, Azure.ResourceManager.Logic.Models.ErrorResponseCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EventLevel
    {
        LogAlways = 0,
        Critical = 1,
        Error = 2,
        Warning = 3,
        Informational = 4,
        Verbose = 5,
    }
    public partial class Expression
    {
        internal Expression() { }
        public Azure.ResourceManager.Logic.Models.AzureResourceErrorInfo Error { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.Expression> Subexpressions { get { throw null; } }
        public string Text { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
    }
    public partial class ExpressionRoot : Azure.ResourceManager.Logic.Models.Expression
    {
        internal ExpressionRoot() { }
        public string Path { get { throw null; } }
    }
    public partial class ExtendedErrorInfo
    {
        internal ExtendedErrorInfo() { }
        public Azure.ResourceManager.Logic.Models.ErrorResponseCode Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Logic.Models.ExtendedErrorInfo> Details { get { throw null; } }
        public System.BinaryData InnerError { get { throw null; } }
        public string Message { get { throw null; } }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IPAddressRange> AllowedCallerIPAddresses { get { throw null; } }
    }
    public partial class FlowEndpoints
    {
        public FlowEndpoints() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IPAddress> AccessEndpointIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.IPAddress> OutgoingIPAddresses { get { throw null; } }
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
    public partial class GetCallbackUrlParameters
    {
        public GetCallbackUrlParameters() { }
        public Azure.ResourceManager.Logic.Models.KeyType? KeyType { get { throw null; } set { } }
        public System.DateTimeOffset? NotAfter { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HashingAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.HashingAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HashingAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm MD5 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm None { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm SHA1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm SHA2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm SHA2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.HashingAlgorithm SHA2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.HashingAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.HashingAlgorithm left, Azure.ResourceManager.Logic.Models.HashingAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.HashingAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.HashingAlgorithm left, Azure.ResourceManager.Logic.Models.HashingAlgorithm right) { throw null; }
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
    public partial class IntegrationServiceEnvironmenEncryptionKeyReference
    {
        public IntegrationServiceEnvironmenEncryptionKeyReference() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ResourceReference KeyVault { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType SQL { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentNetworkDependencyCategoryType SSLCertificateVerification { get { throw null; } }
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
        public Azure.ResourceManager.Logic.Models.ExtendedErrorInfo Error { get { throw null; } }
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
        public Azure.ResourceManager.Logic.Models.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.WorkflowProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.WorkflowState? State { get { throw null; } set { } }
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
        public string ResourceType { get { throw null; } }
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
    public partial class IPAddress
    {
        public IPAddress() { }
        public string Address { get { throw null; } set { } }
    }
    public partial class IPAddressRange
    {
        public IPAddressRange() { }
        public string AddressRange { get { throw null; } set { } }
    }
    public partial class JsonSchema
    {
        internal JsonSchema() { }
        public string Content { get { throw null; } }
        public string Title { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyType : System.IEquatable<Azure.ResourceManager.Logic.Models.KeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.KeyType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.KeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.KeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.KeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.KeyType left, Azure.ResourceManager.Logic.Models.KeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.KeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.KeyType left, Azure.ResourceManager.Logic.Models.KeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyVaultKey
    {
        internal KeyVaultKey() { }
        public Azure.ResourceManager.Logic.Models.KeyVaultKeyAttributes Attributes { get { throw null; } }
        public string Kid { get { throw null; } }
    }
    public partial class KeyVaultKeyAttributes
    {
        internal KeyVaultKeyAttributes() { }
        public long? Created { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public long? Updated { get { throw null; } }
    }
    public partial class KeyVaultKeyReference
    {
        public KeyVaultKeyReference(Azure.ResourceManager.Logic.Models.KeyVaultKeyReferenceKeyVault keyVault, string keyName) { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.KeyVaultKeyReferenceKeyVault KeyVault { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
    }
    public partial class KeyVaultKeyReferenceKeyVault
    {
        public KeyVaultKeyReferenceKeyVault() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class KeyVaultReference : Azure.ResourceManager.Logic.Models.ResourceReference
    {
        public KeyVaultReference() { }
    }
    public partial class ListKeyVaultKeysDefinition
    {
        public ListKeyVaultKeysDefinition(Azure.ResourceManager.Logic.Models.KeyVaultReference keyVault) { }
        public Azure.ResourceManager.Logic.Models.KeyVaultReference KeyVault { get { throw null; } }
        public string SkipToken { get { throw null; } set { } }
    }
    public partial class LogicSku
    {
        internal LogicSku() { }
        public Azure.ResourceManager.Logic.Models.LogicSkuName Name { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ResourceReference Plan { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapType : System.IEquatable<Azure.ResourceManager.Logic.Models.MapType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.MapType Liquid { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MapType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MapType Xslt { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MapType Xslt20 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.MapType Xslt30 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.MapType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.MapType left, Azure.ResourceManager.Logic.Models.MapType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.MapType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.MapType left, Azure.ResourceManager.Logic.Models.MapType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class NetworkConfiguration
    {
        public NetworkConfiguration() { }
        public Azure.ResourceManager.Logic.Models.IntegrationServiceEnvironmentAccessEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.ResourceReference> Subnets { get { throw null; } }
        public string VirtualNetworkAddressSpace { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.Logic.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.ParameterType Array { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType SecureObject { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType SecureString { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.ParameterType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.ParameterType left, Azure.ResourceManager.Logic.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.ParameterType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.ParameterType left, Azure.ResourceManager.Logic.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PartnerContent
    {
        public PartnerContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.BusinessIdentity> B2BBusinessIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PartnerType : System.IEquatable<Azure.ResourceManager.Logic.Models.PartnerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PartnerType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.PartnerType B2B { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.PartnerType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.PartnerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.PartnerType left, Azure.ResourceManager.Logic.Models.PartnerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.PartnerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.PartnerType left, Azure.ResourceManager.Logic.Models.PartnerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecurrenceFrequency : System.IEquatable<Azure.ResourceManager.Logic.Models.RecurrenceFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecurrenceFrequency(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Day { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Hour { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Minute { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Month { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Second { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Week { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.RecurrenceFrequency Year { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.RecurrenceFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.RecurrenceFrequency left, Azure.ResourceManager.Logic.Models.RecurrenceFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.RecurrenceFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.RecurrenceFrequency left, Azure.ResourceManager.Logic.Models.RecurrenceFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecurrenceSchedule
    {
        public RecurrenceSchedule() { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.RecurrenceScheduleOccurrence> MonthlyOccurrences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.DaysOfWeek> WeekDays { get { throw null; } }
    }
    public partial class RecurrenceScheduleOccurrence
    {
        public RecurrenceScheduleOccurrence() { }
        public Azure.ResourceManager.Logic.Models.DayOfWeek? Day { get { throw null; } set { } }
        public int? Occurrence { get { throw null; } set { } }
    }
    public partial class RegenerateActionParameter
    {
        public RegenerateActionParameter() { }
        public Azure.ResourceManager.Logic.Models.KeyType? KeyType { get { throw null; } set { } }
    }
    public partial class RepetitionIndex
    {
        public RepetitionIndex(int itemIndex) { }
        public int ItemIndex { get { throw null; } set { } }
        public string ScopeName { get { throw null; } set { } }
    }
    public partial class Request
    {
        public Request() { }
        public System.BinaryData Headers { get { throw null; } set { } }
        public string Method { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
    }
    public partial class RequestHistoryProperties
    {
        public RequestHistoryProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.Request Request { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.Response Response { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class ResourceReference
    {
        public ResourceReference() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
    }
    public partial class Response
    {
        public Response() { }
        public Azure.ResourceManager.Logic.Models.ContentLink BodyLink { get { throw null; } set { } }
        public System.BinaryData Headers { get { throw null; } set { } }
        public int? StatusCode { get { throw null; } set { } }
    }
    public partial class RetryHistory
    {
        public RetryHistory() { }
        public string ClientRequestId { get { throw null; } set { } }
        public string Code { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ErrorProperties Error { get { throw null; } set { } }
        public string ServiceRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
    }
    public partial class RunActionCorrelation : Azure.ResourceManager.Logic.Models.RunCorrelation
    {
        public RunActionCorrelation() { }
        public string ActionTrackingId { get { throw null; } set { } }
    }
    public partial class RunCorrelation
    {
        public RunCorrelation() { }
        public System.Collections.Generic.IList<string> ClientKeywords { get { throw null; } }
        public string ClientTrackingId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SchemaType : System.IEquatable<Azure.ResourceManager.Logic.Models.SchemaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SchemaType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.SchemaType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SchemaType Xml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.SchemaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.SchemaType left, Azure.ResourceManager.Logic.Models.SchemaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.SchemaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.SchemaType left, Azure.ResourceManager.Logic.Models.SchemaType right) { throw null; }
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
    public partial class SetTriggerStateActionDefinition
    {
        public SetTriggerStateActionDefinition(Azure.ResourceManager.Logic.Models.WorkflowTriggerReference source) { }
        public Azure.ResourceManager.Logic.Models.WorkflowTriggerReference Source { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SigningAlgorithm : System.IEquatable<Azure.ResourceManager.Logic.Models.SigningAlgorithm>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SigningAlgorithm(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm Default { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm SHA1 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm SHA2256 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm SHA2384 { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.SigningAlgorithm SHA2512 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.SigningAlgorithm other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.SigningAlgorithm left, Azure.ResourceManager.Logic.Models.SigningAlgorithm right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.SigningAlgorithm (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.SigningAlgorithm left, Azure.ResourceManager.Logic.Models.SigningAlgorithm right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StatusAnnotation : System.IEquatable<Azure.ResourceManager.Logic.Models.StatusAnnotation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StatusAnnotation(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.StatusAnnotation NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.StatusAnnotation Preview { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.StatusAnnotation Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.StatusAnnotation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.StatusAnnotation left, Azure.ResourceManager.Logic.Models.StatusAnnotation right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.StatusAnnotation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.StatusAnnotation left, Azure.ResourceManager.Logic.Models.StatusAnnotation right) { throw null; }
        public override string ToString() { throw null; }
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
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerCustomDynamicTreeParameter> Parameters { get { throw null; } }
        public string SelectableFilter { get { throw null; } set { } }
    }
    public partial class SwaggerCustomDynamicTreeParameter
    {
        public SwaggerCustomDynamicTreeParameter() { }
        public string ParameterReference { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
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
        public Azure.ResourceManager.Logic.Models.SwaggerSchema Items { get { throw null; } set { } }
        public int? MaxProperties { get { throw null; } set { } }
        public int? MinProperties { get { throw null; } set { } }
        public bool? NotificationUrlExtension { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Logic.Models.SwaggerSchema> Properties { get { throw null; } }
        public bool? ReadOnly { get { throw null; } set { } }
        public string Ref { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Required { get { throw null; } }
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
        public bool? Attribute { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Extensions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Prefix { get { throw null; } set { } }
        public bool? Wrapped { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackEventsOperationOption : System.IEquatable<Azure.ResourceManager.Logic.Models.TrackEventsOperationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackEventsOperationOption(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.TrackEventsOperationOption DisableSourceInfoEnrich { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackEventsOperationOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.TrackEventsOperationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.TrackEventsOperationOption left, Azure.ResourceManager.Logic.Models.TrackEventsOperationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.TrackEventsOperationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.TrackEventsOperationOption left, Azure.ResourceManager.Logic.Models.TrackEventsOperationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrackingEvent
    {
        public TrackingEvent(Azure.ResourceManager.Logic.Models.EventLevel eventLevel, System.DateTimeOffset eventOn, Azure.ResourceManager.Logic.Models.TrackingRecordType recordType) { }
        public Azure.ResourceManager.Logic.Models.TrackingEventErrorInfo Error { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.EventLevel EventLevel { get { throw null; } }
        public System.DateTimeOffset EventOn { get { throw null; } }
        public System.BinaryData Record { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrackingRecordType RecordType { get { throw null; } }
    }
    public partial class TrackingEventErrorInfo
    {
        public TrackingEventErrorInfo() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
    }
    public partial class TrackingEventsDefinition
    {
        public TrackingEventsDefinition(string sourceType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Logic.Models.TrackingEvent> events) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Logic.Models.TrackingEvent> Events { get { throw null; } }
        public string SourceType { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.TrackEventsOperationOption? TrackEventsOptions { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrackingRecordType : System.IEquatable<Azure.ResourceManager.Logic.Models.TrackingRecordType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrackingRecordType(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType AS2MDN { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType AS2Message { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType Custom { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactFunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactFunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactInterchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactInterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactTransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType EdifactTransactionSetAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12FunctionalGroup { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12FunctionalGroupAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12Interchange { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12InterchangeAcknowledgment { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12TransactionSet { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.TrackingRecordType X12TransactionSetAcknowledgment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.TrackingRecordType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.TrackingRecordType left, Azure.ResourceManager.Logic.Models.TrackingRecordType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.TrackingRecordType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.TrackingRecordType left, Azure.ResourceManager.Logic.Models.TrackingRecordType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class WorkflowOutputParameter : Azure.ResourceManager.Logic.Models.WorkflowParameter
    {
        public WorkflowOutputParameter() { }
        public System.BinaryData Error { get { throw null; } }
    }
    public partial class WorkflowParameter
    {
        public WorkflowParameter() { }
        public string Description { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.ParameterType? ParameterType { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.WorkflowProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Renewing { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Updating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.WorkflowProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.WorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.WorkflowProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.WorkflowProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.WorkflowProvisioningState left, Azure.ResourceManager.Logic.Models.WorkflowProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkflowReference : Azure.ResourceManager.Logic.Models.ResourceReference
    {
        public WorkflowReference() { }
    }
    public partial class WorkflowRunTrigger
    {
        internal WorkflowRunTrigger() { }
        public string Code { get { throw null; } }
        public string CorrelationClientTrackingId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.BinaryData Error { get { throw null; } }
        public System.BinaryData Inputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink InputsLink { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Outputs { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.ContentLink OutputsLink { get { throw null; } }
        public System.DateTimeOffset? ScheduledOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowStatus? Status { get { throw null; } }
        public System.BinaryData TrackedProperties { get { throw null; } }
        public string TrackingId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowState : System.IEquatable<Azure.ResourceManager.Logic.Models.WorkflowState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.WorkflowState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowState Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.WorkflowState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.WorkflowState left, Azure.ResourceManager.Logic.Models.WorkflowState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.WorkflowState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.WorkflowState left, Azure.ResourceManager.Logic.Models.WorkflowState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowStatus : System.IEquatable<Azure.ResourceManager.Logic.Models.WorkflowStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowStatus(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Aborted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Faulted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Ignored { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Paused { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Skipped { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus TimedOut { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowStatus Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.WorkflowStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.WorkflowStatus left, Azure.ResourceManager.Logic.Models.WorkflowStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.WorkflowStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.WorkflowStatus left, Azure.ResourceManager.Logic.Models.WorkflowStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkflowTriggerCallbackUri
    {
        internal WorkflowTriggerCallbackUri() { }
        public string BasePath { get { throw null; } }
        public string Method { get { throw null; } }
        public Azure.ResourceManager.Logic.Models.WorkflowTriggerListCallbackUrlQueries Queries { get { throw null; } }
        public string RelativePath { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RelativePathParameters { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class WorkflowTriggerListCallbackUrlQueries
    {
        internal WorkflowTriggerListCallbackUrlQueries() { }
        public string ApiVersion { get { throw null; } }
        public string Se { get { throw null; } }
        public string Sig { get { throw null; } }
        public string Sp { get { throw null; } }
        public string Sv { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowTriggerProvisioningState : System.IEquatable<Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowTriggerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Completed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Registering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Unregistering { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState left, Azure.ResourceManager.Logic.Models.WorkflowTriggerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkflowTriggerRecurrence
    {
        public WorkflowTriggerRecurrence() { }
        public string EndTime { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.RecurrenceFrequency? Frequency { get { throw null; } set { } }
        public int? Interval { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.RecurrenceSchedule Schedule { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
    }
    public partial class WorkflowTriggerReference : Azure.ResourceManager.Logic.Models.ResourceReference
    {
        public WorkflowTriggerReference() { }
        public string FlowName { get { throw null; } set { } }
        public string TriggerName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WsdlImportMethod : System.IEquatable<Azure.ResourceManager.Logic.Models.WsdlImportMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WsdlImportMethod(string value) { throw null; }
        public static Azure.ResourceManager.Logic.Models.WsdlImportMethod NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WsdlImportMethod SoapPassThrough { get { throw null; } }
        public static Azure.ResourceManager.Logic.Models.WsdlImportMethod SoapToRest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Logic.Models.WsdlImportMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Logic.Models.WsdlImportMethod left, Azure.ResourceManager.Logic.Models.WsdlImportMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Logic.Models.WsdlImportMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Logic.Models.WsdlImportMethod left, Azure.ResourceManager.Logic.Models.WsdlImportMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WsdlService
    {
        internal WsdlService() { }
        public System.Collections.Generic.IReadOnlyList<string> EndpointQualifiedNames { get { throw null; } }
        public string QualifiedName { get { throw null; } }
    }
    public partial class X12AcknowledgementSettings
    {
        public X12AcknowledgementSettings(bool needTechnicalAcknowledgement, bool batchTechnicalAcknowledgements, bool needFunctionalAcknowledgement, bool batchFunctionalAcknowledgements, bool needImplementationAcknowledgement, bool batchImplementationAcknowledgements, bool needLoopForValidMessages, bool sendSynchronousAcknowledgement, int acknowledgementControlNumberLowerBound, int acknowledgementControlNumberUpperBound, bool rolloverAcknowledgementControlNumber) { }
        public int AcknowledgementControlNumberLowerBound { get { throw null; } set { } }
        public string AcknowledgementControlNumberPrefix { get { throw null; } set { } }
        public string AcknowledgementControlNumberSuffix { get { throw null; } set { } }
        public int AcknowledgementControlNumberUpperBound { get { throw null; } set { } }
        public bool BatchFunctionalAcknowledgements { get { throw null; } set { } }
        public bool BatchImplementationAcknowledgements { get { throw null; } set { } }
        public bool BatchTechnicalAcknowledgements { get { throw null; } set { } }
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
        public static Azure.ResourceManager.Logic.Models.X12CharacterSet UTF8 { get { throw null; } }
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
        public X12OneWayAgreement(Azure.ResourceManager.Logic.Models.BusinessIdentity senderBusinessIdentity, Azure.ResourceManager.Logic.Models.BusinessIdentity receiverBusinessIdentity, Azure.ResourceManager.Logic.Models.X12ProtocolSettings protocolSettings) { }
        public Azure.ResourceManager.Logic.Models.X12ProtocolSettings ProtocolSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity ReceiverBusinessIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.BusinessIdentity SenderBusinessIdentity { get { throw null; } set { } }
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
        public X12ValidationOverride(string messageId, bool validateEDITypes, bool validateXSDTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool validateCharacterSet, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public string MessageId { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEDITypes { get { throw null; } set { } }
        public bool ValidateXSDTypes { get { throw null; } set { } }
    }
    public partial class X12ValidationSettings
    {
        public X12ValidationSettings(bool validateCharacterSet, bool checkDuplicateInterchangeControlNumber, int interchangeControlNumberValidityDays, bool checkDuplicateGroupControlNumber, bool checkDuplicateTransactionSetControlNumber, bool validateEDITypes, bool validateXSDTypes, bool allowLeadingAndTrailingSpacesAndZeroes, bool trimLeadingAndTrailingSpacesAndZeroes, Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy trailingSeparatorPolicy) { }
        public bool AllowLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool CheckDuplicateGroupControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateInterchangeControlNumber { get { throw null; } set { } }
        public bool CheckDuplicateTransactionSetControlNumber { get { throw null; } set { } }
        public int InterchangeControlNumberValidityDays { get { throw null; } set { } }
        public Azure.ResourceManager.Logic.Models.TrailingSeparatorPolicy TrailingSeparatorPolicy { get { throw null; } set { } }
        public bool TrimLeadingAndTrailingSpacesAndZeroes { get { throw null; } set { } }
        public bool ValidateCharacterSet { get { throw null; } set { } }
        public bool ValidateEDITypes { get { throw null; } set { } }
        public bool ValidateXSDTypes { get { throw null; } set { } }
    }
}
