namespace Azure.ResourceManager.Nginx
{
    public partial class NginxCertificateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>, System.Collections.IEnumerable
    {
        protected NginxCertificateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string certificateName, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxCertificateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxCertificateResource> GetIfExists(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetIfExistsAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxCertificateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxCertificateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxCertificateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>
    {
        public NginxCertificateData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxCertificateProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxCertificateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxCertificateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxCertificateResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxCertificateResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string certificateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxCertificateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxCertificateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>, System.Collections.IEnumerable
    {
        protected NginxConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>
    {
        public NginxConfigurationData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxConfigurationResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName, string configurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.NginxConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NginxDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>, System.Collections.IEnumerable
    {
        protected NginxDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentName, Azure.ResourceManager.Nginx.NginxDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetIfExists(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetIfExistsAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Nginx.NginxDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.NginxDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NginxDeploymentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>
    {
        public NginxDeploymentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.NginxDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.NginxDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NginxDeploymentResource() { }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string deploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource> GetNginxCertificate(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxCertificateResource>> GetNginxCertificateAsync(string certificateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateCollection GetNginxCertificates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource> GetNginxConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxConfigurationResource>> GetNginxConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationCollection GetNginxConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Nginx.NginxDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NginxExtensions
    {
        public static Azure.ResourceManager.Nginx.NginxCertificateResource GetNginxCertificateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxConfigurationResource GetNginxConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployment(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetNginxDeploymentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentResource GetNginxDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentCollection GetNginxDeployments(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployments(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeploymentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Nginx.Mocking
{
    public partial class MockableNginxArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxArmClient() { }
        public virtual Azure.ResourceManager.Nginx.NginxCertificateResource GetNginxCertificateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxConfigurationResource GetNginxConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentResource GetNginxDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNginxResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployment(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Nginx.NginxDeploymentResource>> GetNginxDeploymentAsync(string deploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Nginx.NginxDeploymentCollection GetNginxDeployments() { throw null; }
    }
    public partial class MockableNginxSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNginxSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeployments(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Nginx.NginxDeploymentResource> GetNginxDeploymentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Nginx.Models
{
    public static partial class ArmNginxModelFactory
    {
        public static Azure.ResourceManager.Nginx.NginxCertificateData NginxCertificateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxCertificateProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxCertificateProperties NginxCertificateProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), string keyVirtualPath = null, string certificateVirtualPath = null, string keyVaultSecretId = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxConfigurationData NginxConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties NginxConfigurationProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> files = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> protectedFiles = null, Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage package = null, string rootFile = null) { throw null; }
        public static Azure.ResourceManager.Nginx.NginxDeploymentData NginxDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties properties = null, string skuName = null) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties NginxDeploymentProperties(Azure.ResourceManager.Nginx.Models.NginxProvisioningState? provisioningState = default(Azure.ResourceManager.Nginx.Models.NginxProvisioningState?), string nginxVersion = null, string managedResourceGroup = null, Azure.ResourceManager.Nginx.Models.NginxNetworkProfile networkProfile = null, string ipAddress = null, bool? enableDiagnosticsSupport = default(bool?), Azure.ResourceManager.Nginx.Models.NginxStorageAccount loggingStorageAccount = null, int? scalingCapacity = default(int?), string userPreferredEmail = null) { throw null; }
    }
    public partial class NginxCertificateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>
    {
        public NginxCertificateProperties() { }
        public string CertificateVirtualPath { get { throw null; } set { } }
        public string KeyVaultSecretId { get { throw null; } set { } }
        public string KeyVirtualPath { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Nginx.Models.NginxCertificateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxCertificateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxCertificateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationFile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>
    {
        public NginxConfigurationFile() { }
        public string Content { get { throw null; } set { } }
        public string VirtualPath { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationPackage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>
    {
        public NginxConfigurationPackage() { }
        public string Data { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtectedFiles { get { throw null; } }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>
    {
        public NginxConfigurationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> Files { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxConfigurationPackage Package { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxConfigurationFile> ProtectedFiles { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public string RootFile { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>
    {
        public NginxDeploymentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>
    {
        public NginxDeploymentProperties() { }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public string IPAddress { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
        public string ManagedResourceGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxNetworkProfile NetworkProfile { get { throw null; } set { } }
        public string NginxVersion { get { throw null; } }
        public Azure.ResourceManager.Nginx.Models.NginxProvisioningState? ProvisioningState { get { throw null; } }
        public int? ScalingCapacity { get { throw null; } set { } }
        public string UserPreferredEmail { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxDeploymentUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>
    {
        public NginxDeploymentUpdateProperties() { }
        public bool? EnableDiagnosticsSupport { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxStorageAccount LoggingStorageAccount { get { throw null; } set { } }
        public int? ScalingCapacity { get { throw null; } set { } }
        public string UserPreferredEmail { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxDeploymentUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxFrontendIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>
    {
        public NginxFrontendIPConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress> PrivateIPAddresses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> PublicIPAddresses { get { throw null; } }
        Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>
    {
        public NginxNetworkProfile() { }
        public Azure.ResourceManager.Nginx.Models.NginxFrontendIPConfiguration FrontEndIPConfiguration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetworkInterfaceSubnetId { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NginxPrivateIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>
    {
        public NginxPrivateIPAddress() { }
        public System.Net.IPAddress PrivateIPAddress { get { throw null; } set { } }
        public Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod? PrivateIPAllocationMethod { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxPrivateIPAllocationMethod : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxPrivateIPAllocationMethod(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Dynamic { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod Static { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod left, Azure.ResourceManager.Nginx.Models.NginxPrivateIPAllocationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NginxProvisioningState : System.IEquatable<Azure.ResourceManager.Nginx.Models.NginxProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NginxProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Nginx.Models.NginxProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Nginx.Models.NginxProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Nginx.Models.NginxProvisioningState left, Azure.ResourceManager.Nginx.Models.NginxProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Nginx.Models.NginxProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Nginx.Models.NginxProvisioningState left, Azure.ResourceManager.Nginx.Models.NginxProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NginxStorageAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>
    {
        public NginxStorageAccount() { }
        public string AccountName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        Azure.ResourceManager.Nginx.Models.NginxStorageAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Nginx.Models.NginxStorageAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Nginx.Models.NginxStorageAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
