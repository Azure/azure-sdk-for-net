namespace Azure.ResourceManager.HybridConnectivity
{
    public partial class EndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EndpointResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.EndpointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string endpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess> GetCredentials(Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.TargetResourceEndpointAccess>> GetCredentialsAsync(Azure.ResourceManager.HybridConnectivity.Models.ListCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset> GetIngressGatewayCredentials(Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset> GetManagedProxyDetails(Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset>> GetManagedProxyDetailsAsync(Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> GetServiceConfigurationResource(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> GetServiceConfigurationResourceAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceCollection GetServiceConfigurationResources() { throw null; }
        Azure.ResourceManager.HybridConnectivity.EndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.EndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource> Update(Azure.ResourceManager.HybridConnectivity.EndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.EndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EndpointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.EndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.EndpointResource>, System.Collections.IEnumerable
    {
        protected EndpointResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.EndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.HybridConnectivity.EndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.EndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string endpointName, Azure.ResourceManager.HybridConnectivity.EndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource> Get(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.EndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.EndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource>> GetAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.EndpointResource> GetIfExists(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.EndpointResource>> GetIfExistsAsync(string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.EndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.EndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.EndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.EndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EndpointResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>
    {
        public EndpointResourceData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.EndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.EndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.EndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class HybridConnectivityExtensions
    {
        public static Azure.ResourceManager.HybridConnectivity.EndpointResource GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource> GetEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource>> GetEndpointResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.EndpointResourceCollection GetEndpointResources(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource GetHybridConnectivityInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetPublicCloudConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource GetPublicCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorCollection GetPublicCloudConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource GetServiceConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> GetSolutionConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> GetSolutionConfigurationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource GetSolutionConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionConfigurationCollection GetSolutionConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionTypeResource GetSolutionTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>> GetSolutionTypeResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceCollection GetSolutionTypeResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.BinaryData> PostGenerateAwsTemplate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> PostGenerateAwsTemplateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridConnectivityInventoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivityInventoryResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration, string inventoryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityInventoryResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivityInventoryResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> Get(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> GetIfExists(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetIfExistsAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivityInventoryResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>
    {
        public HybridConnectivityInventoryResourceData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult> TestPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>> TestPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> Update(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServiceConfigurationResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string endpointName, string serviceConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> Update(Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServiceConfigurationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>, System.Collections.IEnumerable
    {
        protected ServiceConfigurationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serviceConfigurationName, Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serviceConfigurationName, Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> Get(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> GetAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> GetIfExists(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>> GetIfExistsAsync(string serviceConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServiceConfigurationResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>
    {
        public ServiceConfigurationResourceData() { }
        public long? Port { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? ServiceName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>, System.Collections.IEnumerable
    {
        protected SolutionConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> Get(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> GetAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> GetIfExists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> GetIfExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>
    {
        public SolutionConfigurationData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionConfigurationResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> GetHybridConnectivityInventoryResource(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetHybridConnectivityInventoryResourceAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceCollection GetHybridConnectivityInventoryResources() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult> SyncNow(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>> SyncNowAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> Update(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionTypeResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTypeResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>, System.Collections.IEnumerable
    {
        protected SolutionTypeResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> Get(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>> GetAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetIfExists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>> GetIfExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionTypeResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>
    {
        public SolutionTypeResourceData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridConnectivity.Mocking
{
    public partial class MockableHybridConnectivityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivityArmClient() { }
        public virtual Azure.ResourceManager.HybridConnectivity.EndpointResource GetEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource> GetEndpointResource(Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.EndpointResource>> GetEndpointResourceAsync(Azure.Core.ResourceIdentifier scope, string endpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.EndpointResourceCollection GetEndpointResources(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource GetHybridConnectivityInventoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource GetPublicCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResource GetServiceConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource> GetSolutionConfiguration(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource>> GetSolutionConfigurationAsync(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionConfigurationResource GetSolutionConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionConfigurationCollection GetSolutionConfigurations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionTypeResource GetSolutionTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridConnectivityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnector(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource>> GetPublicCloudConnectorAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorCollection GetPublicCloudConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResource(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource>> GetSolutionTypeResourceAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceCollection GetSolutionTypeResources() { throw null; }
    }
    public partial class MockableHybridConnectivitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorResource> GetPublicCloudConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.SolutionTypeResource> GetSolutionTypeResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> PostGenerateAwsTemplate(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> PostGenerateAwsTemplateAsync(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridConnectivity.Models
{
    public static partial class ArmHybridConnectivityModelFactory
    {
        public static Azure.ResourceManager.HybridConnectivity.EndpointResourceData EndpointResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent GenerateAwsTemplateContent(Azure.Core.ResourceIdentifier connectorId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings> solutionTypes = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties HybridConnectivityEndpointProperties(Azure.ResourceManager.HybridConnectivity.Models.EndpointType endpointType = default(Azure.ResourceManager.HybridConnectivity.Models.EndpointType), Azure.Core.ResourceIdentifier resourceId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties HybridConnectivityInventoryProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType? cloudNativeType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType?), string cloudNativeResourceId = null, Azure.Core.ResourceIdentifier azureResourceId = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus?), string statusDetails = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResourceData HybridConnectivityInventoryResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset IngressGatewayAsset(string hostname = null, Azure.Core.ResourceIdentifier serverId = null, System.Guid? tenantId = default(System.Guid?), string namespaceName = null, string namespaceNameSuffix = null, string hybridConnectionName = null, string accessKey = null, long? expiresOn = default(long?), string serviceConfigurationToken = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset ManagedProxyAsset(string proxy = null, long expiresOn = (long)0) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent ManagedProxyContent(string service = null, string hostname = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult OperationStatusResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier resourceId = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult> operations = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.PublicCloudConnectorData PublicCloudConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorPatch PublicCloudConnectorPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> awsCloudExcludedAccounts = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties PublicCloudConnectorProperties(Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile awsCloudProfile = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType hostType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType), Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?), System.Guid? connectorPrimaryIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.ServiceConfigurationResourceData ServiceConfigurationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?), Azure.Core.ResourceIdentifier resourceId = null, long? port = default(long?), Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionConfigurationData SolutionConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch SolutionConfigurationPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties SolutionConfigurationProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?), string solutionType = null, System.Collections.Generic.IDictionary<string, string> solutionSettings = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus?), string statusDetails = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.SolutionTypeResourceData SolutionTypeResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings SolutionTypeSettings(string solutionType = null, System.Collections.Generic.IDictionary<string, string> solutionSettings = null) { throw null; }
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
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.EndpointType Custom { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.EndpointType Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.EndpointType left, Azure.ResourceManager.HybridConnectivity.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.EndpointType left, Azure.ResourceManager.HybridConnectivity.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenerateAwsTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>
    {
        public GenerateAwsTemplateContent(Azure.Core.ResourceIdentifier connectorId) { }
        public Azure.Core.ResourceIdentifier ConnectorId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings> SolutionTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridConnectivityCloudNativeType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityCloudNativeType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType Ec2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridConnectivityEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties>
    {
        public HybridConnectivityEndpointProperties(Azure.ResourceManager.HybridConnectivity.Models.EndpointType endpointType) { }
        public Azure.ResourceManager.HybridConnectivity.Models.EndpointType EndpointType { get { throw null; } set { } }
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
    public readonly partial struct HybridConnectivityHostType : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityHostType(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType AWS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HybridConnectivityInventoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>
    {
        public HybridConnectivityInventoryProperties() { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } set { } }
        public string CloudNativeResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType? CloudNativeType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? Status { get { throw null; } set { } }
        public string StatusDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HybridConnectivityResourceProvisioningState : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HybridConnectivityResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState left, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
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
        public Azure.Core.ResourceIdentifier ServerId { get { throw null; } }
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
    public partial class OperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>
    {
        internal OperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.OperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public PublicCloudConnectorProperties(Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile awsCloudProfile, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType hostType) { }
        public Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile AwsCloudProfile { get { throw null; } set { } }
        public System.Guid? ConnectorPrimaryIdentifier { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType HostType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceConfigurationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>
    {
        public ServiceConfigurationResourcePatch() { }
        public long? Port { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.ServiceConfigurationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionConfigurationPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>
    {
        public SolutionConfigurationPatch() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>
    {
        public SolutionConfigurationProperties(string solutionType) { }
        public System.DateTimeOffset? LastSyncOn { get { throw null; } }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } set { } }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionConfigurationPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>
    {
        public SolutionConfigurationPropertiesUpdate() { }
        public System.Collections.Generic.IDictionary<string, string> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SolutionConfigurationStatus : System.IEquatable<Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionConfigurationStatus(string value) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus left, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus left, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SolutionTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>
    {
        public SolutionTypeProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedAzureRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTypeSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>
    {
        public SolutionTypeSettings(string solutionType) { }
        public System.Collections.Generic.IDictionary<string, string> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTypeSettingsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>
    {
        public SolutionTypeSettingsProperties(string name, string displayName, string solutionTypeSettingsPropertiesType, string description, System.Collections.Generic.IEnumerable<string> allowedValues, string defaultValue) { }
        public System.Collections.Generic.IList<string> AllowedValues { get { throw null; } }
        public string DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string SolutionTypeSettingsPropertiesType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
