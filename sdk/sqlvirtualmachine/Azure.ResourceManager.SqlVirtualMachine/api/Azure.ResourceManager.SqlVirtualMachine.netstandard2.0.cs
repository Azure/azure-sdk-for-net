namespace Azure.ResourceManager.SqlVirtualMachine
{
    public partial class AvailabilityGroupListenerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>, System.Collections.IEnumerable
    {
        protected AvailabilityGroupListenerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string availabilityGroupListenerName, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string availabilityGroupListenerName, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Get(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetIfExists(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetIfExistsAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AvailabilityGroupListenerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>
    {
        public AvailabilityGroupListenerData() { }
        public string AvailabilityGroupName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica> AvailabilityGroupReplicas { get { throw null; } }
        public bool? CreateDefaultAvailabilityGroupIfNotExist { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration> LoadBalancerConfigurations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration> MultiSubnetIPConfigurations { get { throw null; } }
        public int? Port { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupListenerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AvailabilityGroupListenerResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVmGroupName, string availabilityGroupListenerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerSqlVirtualMachineContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSqlVirtualMachineContext() { }
        public static Azure.ResourceManager.SqlVirtualMachine.AzureResourceManagerSqlVirtualMachineContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class SqlVirtualMachineExtensions
    {
        public static Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource GetAvailabilityGroupListenerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> GetSqlVmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> GetSqlVmGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource GetSqlVmGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupCollection GetSqlVmGroups(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroups(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroupsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmResource GetSqlVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmCollection GetSqlVms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>, System.Collections.IEnumerable
    {
        protected SqlVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlVmName, Azure.ResourceManager.SqlVirtualMachine.SqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlVmName, Azure.ResourceManager.SqlVirtualMachine.SqlVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> Get(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> GetAsync(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetIfExists(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> GetIfExistsAsync(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlVmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>
    {
        public SqlVmData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings AssessmentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings AutoBackupSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings AutoPatchingSettings { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings KeyVaultCredentialSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings ServerConfigurationsManagementSettings { get { throw null; } set { } }
        public string SqlImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? SqlImageSku { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? SqlManagement { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlVmGroupResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings StorageConfigurationSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials WindowsServerFailoverClusterDomainCredentials { get { throw null; } set { } }
        public System.Net.IPAddress WindowsServerFailoverClusterStaticIP { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmGroupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>, System.Collections.IEnumerable
    {
        protected SqlVmGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sqlVmGroupName, Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sqlVmGroupName, Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> Get(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> GetAsync(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetIfExists(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> GetIfExistsAsync(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SqlVmGroupData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>
    {
        public SqlVmGroupData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration? ClusterConfiguration { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType? ClusterManagerType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType? ScaleType { get { throw null; } }
        public string SqlImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? SqlImageSku { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile WindowsServerFailoverClusterDomainProfile { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVmGroupResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVmGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource> GetAvailabilityGroupListener(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource>> GetAvailabilityGroupListenerAsync(string availabilityGroupListenerName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerCollection GetAvailabilityGroupListeners() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVmsBySqlVmGroup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVmsBySqlVmGroupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SqlVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SqlVmResource() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVmName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation StartAssessment(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAssessmentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.SqlVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.SqlVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SqlVirtualMachine.Mocking
{
    public partial class MockableSqlVirtualMachineArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSqlVirtualMachineArmClient() { }
        public virtual Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerResource GetAvailabilityGroupListenerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource GetSqlVmGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmResource GetSqlVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSqlVirtualMachineResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSqlVirtualMachineResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVm(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource>> GetSqlVmAsync(string sqlVmName, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroup(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource>> GetSqlVmGroupAsync(string sqlVmGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupCollection GetSqlVmGroups() { throw null; }
        public virtual Azure.ResourceManager.SqlVirtualMachine.SqlVmCollection GetSqlVms() { throw null; }
    }
    public partial class MockableSqlVirtualMachineSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSqlVirtualMachineSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupResource> GetSqlVmGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVms(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.SqlVmResource> GetSqlVmsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SqlVirtualMachine.Models
{
    public static partial class ArmSqlVirtualMachineModelFactory
    {
        public static Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData AvailabilityGroupListenerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string availabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration> loadBalancerConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration> multiSubnetIPConfigurations = null, bool? createDefaultAvailabilityGroupIfNotExist = default(bool?), int? port = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica> availabilityGroupReplicas = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmData SqlVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.Core.ResourceIdentifier virtualMachineResourceId = null, string provisioningState = null, string sqlImageOffer = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? sqlServerLicenseType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? sqlManagement = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? sqlImageSku = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku?), Azure.Core.ResourceIdentifier sqlVmGroupResourceId = null, Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials windowsServerFailoverClusterDomainCredentials = null, System.Net.IPAddress windowsServerFailoverClusterStaticIP = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings autoPatchingSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings autoBackupSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings keyVaultCredentialSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings serverConfigurationsManagementSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings storageConfigurationSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings assessmentSettings = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData SqlVmGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string sqlImageOffer = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? sqlImageSku = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType? scaleType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType? clusterManagerType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration? clusterConfiguration = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration?), Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile windowsServerFailoverClusterDomainProfile = null) { throw null; }
    }
    public partial class AvailabilityGroupListenerLoadBalancerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>
    {
        public AvailabilityGroupListenerLoadBalancerConfiguration() { }
        public Azure.Core.ResourceIdentifier LoadBalancerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SqlVmInstances { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupListenerPrivateIPAddress : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>
    {
        public AvailabilityGroupListenerPrivateIPAddress() { }
        public System.Net.IPAddress IPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailabilityGroupReplica : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>
    {
        public AvailabilityGroupReplica() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode? Commit { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode? Failover { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode? ReadableSecondary { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole? Role { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlVmInstanceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityGroupReplicaCommitMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityGroupReplicaCommitMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode AsynchronousCommit { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode SynchronousCommit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityGroupReplicaFailoverMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityGroupReplicaFailoverMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode Automatic { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityGroupReplicaRole : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityGroupReplicaRole(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole Primary { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultiSubnetIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>
    {
        public MultiSubnetIPConfiguration(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress privateIPAddress, string sqlVmInstance) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public string SqlVmInstance { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadableSecondaryMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadableSecondaryMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode All { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode No { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode ReadOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode left, Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode left, Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlConnectivityUpdateSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>
    {
        public SqlConnectivityUpdateSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType? ConnectivityType { get { throw null; } set { } }
        public int? Port { get { throw null; } set { } }
        public string SqlAuthUpdatePassword { get { throw null; } set { } }
        public string SqlAuthUpdateUserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlImageSku : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlImageSku(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Developer { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Enterprise { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Express { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Standard { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku Web { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlInstanceSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>
    {
        public SqlInstanceSettings() { }
        public string Collation { get { throw null; } set { } }
        public bool? IsIfiEnabled { get { throw null; } set { } }
        public bool? IsLpimEnabled { get { throw null; } set { } }
        public bool? IsOptimizeForAdHocWorkloadsEnabled { get { throw null; } set { } }
        public int? MaxDop { get { throw null; } set { } }
        public int? MaxServerMemoryInMB { get { throw null; } set { } }
        public int? MinServerMemoryInMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlManagementMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlManagementMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode Full { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode LightWeight { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode NoAgent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerConfigurationsManagementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>
    {
        public SqlServerConfigurationsManagementSettings() { }
        public bool? IsRServicesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings SqlConnectivityUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings SqlInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings SqlStorageUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType? SqlWorkloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerConnectivityType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerConnectivityType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType Local { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType Private { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType Public { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlServerLicenseType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlServerLicenseType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType Ahub { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType DR { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType Payg { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlStorageSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>
    {
        public SqlStorageSettings() { }
        public string DefaultFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Luns { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlStorageUpdateSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>
    {
        public SqlStorageUpdateSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType? DiskConfigurationType { get { throw null; } set { } }
        public int? DiskCount { get { throw null; } set { } }
        public int? StartingDeviceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlTempDBSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>
    {
        public SqlTempDBSettings() { }
        public int? DataFileCount { get { throw null; } set { } }
        public int? DataFileSize { get { throw null; } set { } }
        public int? DataGrowth { get { throw null; } set { } }
        public string DefaultFilePath { get { throw null; } set { } }
        public int? LogFileSize { get { throw null; } set { } }
        public int? LogGrowth { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> LogicalUnitNumbers { get { throw null; } }
        public bool? PersistFolder { get { throw null; } set { } }
        public string PersistFolderPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SqlVmAssessmentDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public partial class SqlVmAssessmentSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>
    {
        public SqlVmAssessmentSchedule() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MonthlyOccurrence { get { throw null; } set { } }
        public string StartTime { get { throw null; } set { } }
        public int? WeeklyInterval { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmAssessmentSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>
    {
        public SqlVmAssessmentSettings() { }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? RunImmediately { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule Schedule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmAutoBackupDayOfWeek : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmAutoBackupDayOfWeek(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Friday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Monday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Saturday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Sunday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Thursday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Tuesday { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek Wednesday { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmAutoBackupSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>
    {
        public SqlVmAutoBackupSettings() { }
        public bool? AreSystemDbsIncludedInBackup { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType? BackupScheduleType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek> DaysOfWeek { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency? FullBackupFrequency { get { throw null; } set { } }
        public int? FullBackupStartHour { get { throw null; } set { } }
        public int? FullBackupWindowHours { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsEncryptionEnabled { get { throw null; } set { } }
        public int? LogBackupFrequency { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public int? RetentionPeriodInDays { get { throw null; } set { } }
        public string StorageAccessKey { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SqlVmAutoPatchingDayOfWeek
    {
        Everyday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
    }
    public partial class SqlVmAutoPatchingSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>
    {
        public SqlVmAutoPatchingSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MaintenanceWindowDurationInMinutes { get { throw null; } set { } }
        public int? MaintenanceWindowStartingHour { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmClusterConfiguration : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmClusterConfiguration(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration Domainful { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmClusterManagerType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmClusterManagerType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType WindowsServerFailoverCluster { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmClusterSubnetType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmClusterSubnetType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType MultiSubnet { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType SingleSubnet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmDiskConfigurationType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmDiskConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType Add { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType Extend { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType New { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmFullBackupFrequency : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmFullBackupFrequency(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency Daily { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmGroupImageSku : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmGroupImageSku(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku Developer { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku Enterprise { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>
    {
        public SqlVmGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmGroupScaleType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmGroupScaleType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType HA { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmKeyVaultCredentialSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>
    {
        public SqlVmKeyVaultCredentialSettings() { }
        public System.Uri AzureKeyVaultUri { get { throw null; } set { } }
        public string CredentialName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string ServicePrincipalName { get { throw null; } set { } }
        public string ServicePrincipalSecret { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>
    {
        public SqlVmPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmStorageConfigurationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>
    {
        public SqlVmStorageConfigurationSettings() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType? DiskConfigurationType { get { throw null; } set { } }
        public bool? IsSqlSystemDBOnDataDisk { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings SqlDataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings SqlLogSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings SqlTempDBSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType? StorageWorkloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmStorageWorkloadType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmStorageWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType General { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlWorkloadType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType DW { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType General { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType Oltp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqVmBackupScheduleType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqVmBackupScheduleType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType Automated { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsServerFailoverClusterDomainCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>
    {
        public WindowsServerFailoverClusterDomainCredentials() { }
        public string ClusterBootstrapAccountPassword { get { throw null; } set { } }
        public string ClusterOperatorAccountPassword { get { throw null; } set { } }
        public string SqlServiceAccountPassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WindowsServerFailoverClusterDomainProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>
    {
        public WindowsServerFailoverClusterDomainProfile() { }
        public string ClusterBootstrapAccount { get { throw null; } set { } }
        public string ClusterOperatorAccount { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType? ClusterSubnetType { get { throw null; } set { } }
        public string DomainFqdn { get { throw null; } set { } }
        public string FileShareWitnessPath { get { throw null; } set { } }
        public string OrganizationalUnitPath { get { throw null; } set { } }
        public string SqlServiceAccount { get { throw null; } set { } }
        public string StorageAccountPrimaryKey { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
