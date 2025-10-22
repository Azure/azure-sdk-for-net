namespace Azure.ResourceManager.HybridConnectivity
{
    public partial class AzureResourceManagerHybridConnectivityContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHybridConnectivityContext() { }
        public static Azure.ResourceManager.HybridConnectivity.AzureResourceManagerHybridConnectivityContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class HybridConnectivityEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivityEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivityEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>
    {
        public HybridConnectivityEndpointData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivityEndpointResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess> GetCredentials(Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>> GetCredentialsAsync(Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> GetHybridConnectivityServiceConfiguration(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> GetHybridConnectivityServiceConfigurationAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationCollection GetHybridConnectivityServiceConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset> GetIngressGatewayCredentials(Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset> GetIngressGatewayCredentials(long? expiresin, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(long? expiresin, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset> GetManagedProxyDetails(Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>> GetManagedProxyDetailsAsync(Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> Update(Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HybridConnectivityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> GetHybridConnectivityEndpoint(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> GetHybridConnectivityEndpointAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource GetHybridConnectivityEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointCollection GetHybridConnectivityEndpoints(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource GetHybridConnectivityServiceConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetPublicCloudConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource GetPublicCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorCollection GetPublicCloudConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> GetPublicCloudConnectorSolutionConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> GetPublicCloudConnectorSolutionConfigurationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource GetPublicCloudConnectorSolutionConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationCollection GetPublicCloudConnectorSolutionConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>> GetPublicCloudConnectorSolutionTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource GetPublicCloudConnectorSolutionTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeCollection GetPublicCloudConnectorSolutionTypes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionTypesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource GetPublicCloudInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult> PostGenerateAwsTemplate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>> PostGenerateAwsTemplateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridConnectivityServiceConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivityServiceConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceConfigurationName, Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceConfigurationName, Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> Get(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> GetAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> GetIfExists(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> GetIfExistsAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivityServiceConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>
    {
        public HybridConnectivityServiceConfigurationData() { }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? ServiceName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityServiceConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivityServiceConfigurationResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string endpointName, string serviceConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource> Update(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublicCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>, System.Collections.IEnumerable
    {
        protected PublicCloudConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicCloudConnector, Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicCloudConnector, Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> Get(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetIfExists(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetIfExistsAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublicCloudConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>
    {
        public PublicCloudConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublicCloudConnectorResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publicCloudConnector) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus> TestPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>> TestPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> Update(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>, System.Collections.IEnumerable
    {
        protected PublicCloudConnectorSolutionConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> Get(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> GetAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> GetIfExists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> GetIfExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublicCloudConnectorSolutionConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>
    {
        public PublicCloudConnectorSolutionConfigurationData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublicCloudConnectorSolutionConfigurationResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryCollection GetPublicCloudInventories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> GetPublicCloudInventory(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>> GetPublicCloudInventoryAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus> SyncNow(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>> SyncNowAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> Update(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>, System.Collections.IEnumerable
    {
        protected PublicCloudConnectorSolutionTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> Get(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>> GetAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetIfExists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>> GetIfExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>
    {
        internal PublicCloudConnectorSolutionTypeData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublicCloudConnectorSolutionTypeResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudInventoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>, System.Collections.IEnumerable
    {
        protected PublicCloudInventoryCollection() { }
        public virtual Azure.Response<bool> Exists(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> Get(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>> GetAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> GetIfExists(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>> GetIfExistsAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PublicCloudInventoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>
    {
        internal PublicCloudInventoryData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudInventoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PublicCloudInventoryResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration, string inventoryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridConnectivity.Mocking
{
    public partial class MockableHybridConnectivityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivityArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource> GetHybridConnectivityEndpoint(Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource>> GetHybridConnectivityEndpointAsync(Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointResource GetHybridConnectivityEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointCollection GetHybridConnectivityEndpoints(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource GetHybridConnectivityServiceConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource GetPublicCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource> GetPublicCloudConnectorSolutionConfiguration(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource>> GetPublicCloudConnectorSolutionConfigurationAsync(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationResource GetPublicCloudConnectorSolutionConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationCollection GetPublicCloudConnectorSolutionConfigurations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource GetPublicCloudConnectorSolutionTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryResource GetPublicCloudInventoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridConnectivityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnector(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetPublicCloudConnectorAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorCollection GetPublicCloudConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionType(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource>> GetPublicCloudConnectorSolutionTypeAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeCollection GetPublicCloudConnectorSolutionTypes() { throw null; }
    }
    public partial class MockableHybridConnectivitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeResource> GetPublicCloudConnectorSolutionTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult> PostGenerateAwsTemplate(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>> PostGenerateAwsTemplateAsync(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridConnectivity.Models
{
    public static partial class ArmHybridConnectivityModelFactory
    {
        public static Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent GenerateAwsTemplateContent(Azure.Core.ResourceIdentifier connectorId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings> solutionTypes = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData HybridConnectivityEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties HybridConnectivityEndpointProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType endpointType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType), Azure.Core.ResourceIdentifier resourceId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus HybridConnectivityOperationStatus(Azure.Core.ResourceIdentifier id = null, string name = null, string status = null, double? percentComplete = default(double?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus> operations = null, Azure.ResponseError error = null, Azure.Core.ResourceIdentifier resourceId = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData HybridConnectivityServiceConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?), Azure.Core.ResourceIdentifier resourceId = null, long? port = default(long?), Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset IngressGatewayAsset(string hostname = null, System.Guid? serverId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), string namespaceName = null, string namespaceNameSuffix = null, string hybridConnectionName = null, string accessKey = null, long? expiresOn = default(long?), string serviceConfigurationToken = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset ManagedProxyAsset(string proxy = null, long expiresOn = (long)0) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent ManagedProxyContent(string service = null, string hostname = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData PublicCloudConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch PublicCloudConnectorPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> awsCloudExcludedAccounts = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties PublicCloudConnectorProperties(Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile awsCloudProfile = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType hostType = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType), Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState?), string connectorPrimaryIdentifier = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionConfigurationData PublicCloudConnectorSolutionConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch PublicCloudConnectorSolutionConfigurationPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties PublicCloudConnectorSolutionConfigurationProperties(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState?), string solutionType = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings solutionSettings = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus?), string statusDetails = null, System.DateTimeOffset? lastSyncedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorSolutionTypeData PublicCloudConnectorSolutionTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties PublicCloudConnectorSolutionTypeProperties(string solutionType = null, string description = null, System.Collections.Generic.IEnumerable<string> supportedAzureRegions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties> solutionSettings = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings PublicCloudConnectorSolutionTypeSettings(string solutionType = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings solutionSettings = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties PublicCloudConnectorSolutionTypeSettingsProperties(string name = null, string displayName = null, string type = null, string description = null, System.Collections.Generic.IEnumerable<string> allowedValues = null, string defaultValue = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudInventoryData PublicCloudInventoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties PublicCloudInventoryProperties(Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType? cloudNativeType = default(Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType?), string cloudNativeResourceId = null, Azure.Core.ResourceIdentifier azureResourceId = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus?), string statusDetails = null, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess TargetResourceEndpointAccess(string namespaceName = null, string namespaceNameSuffix = null, string hybridConnectionName = null, string accessKey = null, long? expiresOn = default(long?), string serviceConfigurationToken = null) { throw null; }
    }
    public partial class AwsCloudProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>
    {
        public AwsCloudProfile(string accountId) { }
        public string AccountId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedAccounts { get { throw null; } }
        public bool? IsOrganizationalAccount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudNativeType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudNativeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType Ec2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType left, Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType left, Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateAwsTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>
    {
        public GenerateAwsTemplateContent(Azure.Core.ResourceIdentifier connectorId) { }
        public Azure.Core.ResourceIdentifier ConnectorId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings> SolutionTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenerateAwsTemplateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>
    {
        internal GenerateAwsTemplateResult() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>
    {
        public HybridConnectivityEndpointProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType endpointType) { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType EndpointType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridConnectivityEndpointType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType Custom { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridConnectivityOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>
    {
        internal HybridConnectivityOperationStatus() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus> Operations { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridConnectivityProvisioningState : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridConnectivityServiceConfigurationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>
    {
        public HybridConnectivityServiceConfigurationPatch() { }
        public long? Port { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridConnectivityServiceName : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityServiceName(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName SSH { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName WAC { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IngressGatewayAsset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>
    {
        internal IngressGatewayAsset() { }
        public string AccessKey { get { throw null; } }
        public long? ExpiresOn { get { throw null; } }
        public string Hostname { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string NamespaceNameSuffix { get { throw null; } }
        public System.Guid? ServerId { get { throw null; } }
        public string ServiceConfigurationToken { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListCredentialsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>
    {
        public ListCredentialsContent() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListIngressGatewayCredentialsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>
    {
        public ListIngressGatewayCredentialsContent() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedProxyAsset : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>
    {
        internal ManagedProxyAsset() { }
        public long ExpiresOn { get { throw null; } }
        public string Proxy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedProxyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>
    {
        public ManagedProxyContent(string service) { }
        public string Hostname { get { throw null; } set { } }
        public string Service { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>
    {
        public PublicCloudConnectorPatch() { }
        public System.Collections.Generic.IList<string> AwsCloudExcludedAccounts { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>
    {
        public PublicCloudConnectorProperties(Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile awsCloudProfile, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType hostType) { }
        public Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile AwsCloudProfile { get { throw null; } set { } }
        public string ConnectorPrimaryIdentifier { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType HostType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionConfigurationPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>
    {
        public PublicCloudConnectorSolutionConfigurationPatch() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>
    {
        public PublicCloudConnectorSolutionConfigurationProperties(string solutionType) { }
        public System.DateTimeOffset? LastSyncedOn { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings SolutionSettings { get { throw null; } set { } }
        public string SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicCloudConnectorSolutionConfigurationStatus : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicCloudConnectorSolutionConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PublicCloudConnectorSolutionSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>
    {
        public PublicCloudConnectorSolutionSettings() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>
    {
        internal PublicCloudConnectorSolutionTypeProperties() { }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedAzureRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>
    {
        public PublicCloudConnectorSolutionTypeSettings(string solutionType) { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings SolutionSettings { get { throw null; } set { } }
        public string SolutionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PublicCloudConnectorSolutionTypeSettingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>
    {
        internal PublicCloudConnectorSolutionTypeSettingsProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedValues { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionTypeSettingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicCloudHostType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicCloudHostType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType Aws { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudHostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PublicCloudInventoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>
    {
        internal PublicCloudInventoryProperties() { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
        public string CloudNativeResourceId { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.CloudNativeType? CloudNativeType { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionConfigurationStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudInventoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicCloudResourceProvisioningState : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicCloudResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.PublicCloudResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SolutionConfigurationPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>
    {
        public SolutionConfigurationPropertiesUpdate() { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorSolutionSettings SolutionSettings { get { throw null; } set { } }
        public string SolutionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResourceEndpointAccess : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>
    {
        internal TargetResourceEndpointAccess() { }
        public string AccessKey { get { throw null; } }
        public long? ExpiresOn { get { throw null; } }
        public string HybridConnectionName { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string NamespaceNameSuffix { get { throw null; } }
        public string ServiceConfigurationToken { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
