namespace Azure.ResourceManager.HybridConnectivity
{
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
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset>> GetIngressGatewayCredentialsAsync(Azure.ResourceManager.HybridConnectivity.Models.ListIngressGatewayCredentialsContent content = null, long? expiresin = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource GetHybridConnectivityInventoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> GetHybridConnectivityPublicCloudConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource GetHybridConnectivityPublicCloudConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorCollection GetHybridConnectivityPublicCloudConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource GetHybridConnectivityServiceConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> GetHybridConnectivitySolutionConfiguration(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> GetHybridConnectivitySolutionConfigurationAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource GetHybridConnectivitySolutionConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationCollection GetHybridConnectivitySolutionConfigurations(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionType(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>> GetHybridConnectivitySolutionTypeAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource GetHybridConnectivitySolutionTypeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeCollection GetHybridConnectivitySolutionTypes(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionTypes(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionTypesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<System.BinaryData> PostGenerateAwsTemplate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> PostGenerateAwsTemplateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridConnectivityInventoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivityInventoryCollection() { }
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
    public partial class HybridConnectivityInventoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>
    {
        public HybridConnectivityInventoryData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityInventoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivityInventoryResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration, string inventoryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityPublicCloudConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivityPublicCloudConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string publicCloudConnector, Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string publicCloudConnector, Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> Get(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> GetAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetIfExists(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> GetIfExistsAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivityPublicCloudConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>
    {
        public HybridConnectivityPublicCloudConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivityPublicCloudConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivityPublicCloudConnectorResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string publicCloudConnector) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult> TestPermissions(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>> TestPermissionsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> Update(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class HybridConnectivitySolutionConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivitySolutionConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionConfiguration, Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> Get(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> GetAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> GetIfExists(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> GetIfExistsAsync(string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivitySolutionConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>
    {
        public HybridConnectivitySolutionConfigurationData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivitySolutionConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivitySolutionConfigurationResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string solutionConfiguration) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryCollection GetHybridConnectivityInventories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource> GetHybridConnectivityInventory(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource>> GetHybridConnectivityInventoryAsync(string inventoryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult> SyncNow(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>> SyncNowAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> Update(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> UpdateAsync(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HybridConnectivitySolutionTypeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>, System.Collections.IEnumerable
    {
        protected HybridConnectivitySolutionTypeCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> Get(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>> GetAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetIfExists(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>> GetIfExistsAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HybridConnectivitySolutionTypeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>
    {
        public HybridConnectivitySolutionTypeData() { }
        public Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivitySolutionTypeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HybridConnectivitySolutionTypeResource() { }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionType) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryResource GetHybridConnectivityInventoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource GetHybridConnectivityPublicCloudConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationResource GetHybridConnectivityServiceConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource> GetHybridConnectivitySolutionConfiguration(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource>> GetHybridConnectivitySolutionConfigurationAsync(Azure.Core.ResourceIdentifier scope, string solutionConfiguration, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationResource GetHybridConnectivitySolutionConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationCollection GetHybridConnectivitySolutionConfigurations(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource GetHybridConnectivitySolutionTypeResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHybridConnectivityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnector(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource>> GetHybridConnectivityPublicCloudConnectorAsync(string publicCloudConnector, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorCollection GetHybridConnectivityPublicCloudConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionType(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource>> GetHybridConnectivitySolutionTypeAsync(string solutionType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeCollection GetHybridConnectivitySolutionTypes() { throw null; }
    }
    public partial class MockableHybridConnectivitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHybridConnectivitySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorResource> GetHybridConnectivityPublicCloudConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionTypes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeResource> GetHybridConnectivitySolutionTypesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.BinaryData> PostGenerateAwsTemplate(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> PostGenerateAwsTemplateAsync(Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HybridConnectivity.Models
{
    public static partial class ArmHybridConnectivityModelFactory
    {
        public static Azure.ResourceManager.HybridConnectivity.Models.GenerateAwsTemplateContent GenerateAwsTemplateContent(Azure.Core.ResourceIdentifier connectorId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettings> solutionTypes = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityEndpointData HybridConnectivityEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointProperties HybridConnectivityEndpointProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType endpointType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityEndpointType), Azure.Core.ResourceIdentifier resourceId = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityInventoryData HybridConnectivityInventoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityInventoryProperties HybridConnectivityInventoryProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType? cloudNativeType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityCloudNativeType?), string cloudNativeResourceId = null, Azure.Core.ResourceIdentifier azureResourceId = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus?), string statusDetails = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult HybridConnectivityOperationStatusResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier resourceId = null, string name = null, string status = null, float? percentComplete = default(float?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult> operations = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityPublicCloudConnectorData HybridConnectivityPublicCloudConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch HybridConnectivityPublicCloudConnectorPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> awsCloudExcludedAccounts = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivityServiceConfigurationData HybridConnectivityServiceConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?), Azure.Core.ResourceIdentifier resourceId = null, long? port = default(long?), Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionConfigurationData HybridConnectivitySolutionConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch HybridConnectivitySolutionConfigurationPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.HybridConnectivitySolutionTypeData HybridConnectivitySolutionTypeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.IngressGatewayAsset IngressGatewayAsset(string hostname = null, System.Guid? serverId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), string namespaceName = null, string namespaceNameSuffix = null, string hybridConnectionName = null, string accessKey = null, long? expiresOn = default(long?), string serviceConfigurationToken = null) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyAsset ManagedProxyAsset(string proxy = null, long expiresOn = (long)0) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.ManagedProxyContent ManagedProxyContent(string service = null, string hostname = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName? serviceName = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityServiceName?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.PublicCloudConnectorProperties PublicCloudConnectorProperties(Azure.ResourceManager.HybridConnectivity.Models.AwsCloudProfile awsCloudProfile = null, Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType hostType = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityHostType), Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?), System.Guid? connectorPrimaryIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationProperties SolutionConfigurationProperties(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState? provisioningState = default(Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityResourceProvisioningState?), string solutionType = null, System.Collections.Generic.IDictionary<string, string> solutionSettings = null, Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus? status = default(Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationStatus?), string statusDetails = null, System.DateTimeOffset? lastSyncOn = default(System.DateTimeOffset?)) { throw null; }
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
    public partial class HybridConnectivityOperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>
    {
        internal HybridConnectivityOperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityOperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridConnectivityPublicCloudConnectorPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>
    {
        public HybridConnectivityPublicCloudConnectorPatch() { }
        public System.Collections.Generic.IList<string> AwsCloudExcludedAccounts { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivityPublicCloudConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class HybridConnectivitySolutionConfigurationPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>
    {
        public HybridConnectivitySolutionConfigurationPatch() { }
        public Azure.ResourceManager.HybridConnectivity.Models.SolutionConfigurationPropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionConfigurationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HybridConnectivitySolutionTypeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>
    {
        public HybridConnectivitySolutionTypeProperties() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.HybridConnectivity.Models.SolutionTypeSettingsProperties> SolutionSettings { get { throw null; } }
        public string SolutionType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SupportedAzureRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HybridConnectivity.Models.HybridConnectivitySolutionTypeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
