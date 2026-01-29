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
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineGroupName, string availabilityGroupListenerName) { throw null; }
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
        public static Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.Models.Info> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.Models.Info> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch? AdditionalVmPatch { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings AssessmentSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings AutoBackupSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings AutoPatchingSettings { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings KeyVaultCredentialSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode? LeastPrivilegeMode { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOsType? OsType { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings ServerConfigurationsManagementSettings { get { throw null; } set { } }
        public string SqlImageOffer { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? SqlImageSku { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? SqlManagement { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? SqlServerLicenseType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlVmGroupResourceId { get { throw null; } set { } }
        public string SqlVmName { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings StorageConfigurationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus TroubleshootingStatus { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity VirtualMachineIdentitySettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials WindowsServerFailoverClusterDomainCredentials { get { throw null; } set { } }
        public System.Net.IPAddress WindowsServerFailoverClusterStaticIP { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string SqlVmGroupName { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile WindowsServerFailoverClusterDomainProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineGroupName) { throw null; }
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
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string sqlVirtualMachineName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FetchDCAssessment(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent sqlVmDiskConfigAssessmentContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FetchDCAssessmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent sqlVmDiskConfigAssessmentContent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting> Troubleshoot(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting sqlVmTroubleshooting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>> TroubleshootAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting sqlVmTroubleshooting, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class MockableSqlVirtualMachineTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSqlVirtualMachineTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SqlVirtualMachine.Models.Info> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SqlVirtualMachine.Models.Info> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SqlVirtualMachine.Models
{
    public static partial class ArmSqlVirtualMachineModelFactory
    {
        public static Azure.ResourceManager.SqlVirtualMachine.AvailabilityGroupListenerData AvailabilityGroupListenerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string provisioningState = null, string availabilityGroupName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration> loadBalancerConfigurations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration> multiSubnetIPConfigurations = null, bool? createDefaultAvailabilityGroupIfNotExist = default(bool?), int? port = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica> availabilityGroupReplicas = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration AvailabilityGroupListenerLoadBalancerConfiguration(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress privateIPAddress = null, Azure.Core.ResourceIdentifier publicIPAddressResourceId = null, Azure.Core.ResourceIdentifier loadBalancerResourceId = null, int? probePort = default(int?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> sqlVmInstances = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.Info Info(string name = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay display = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin? origin = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty> properties = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings SqlStorageSettings(System.Collections.Generic.IEnumerable<int> luns = null, string defaultFilePath = null, bool? useStoragePool = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings SqlTempDBSettings(int? dataFileSize = default(int?), int? dataGrowth = default(int?), int? logFileSize = default(int?), int? logGrowth = default(int?), int? dataFileCount = default(int?), bool? persistFolder = default(bool?), string persistFolderPath = null, System.Collections.Generic.IEnumerable<int> logicalUnitNumbers = null, string defaultFilePath = null, bool? useStoragePool = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings SqlVmAutoBackupSettings(bool? isEnabled = default(bool?), bool? isEncryptionEnabled = default(bool?), int? retentionPeriodInDays = default(int?), System.Uri storageAccountUri = null, string storageContainerName = null, string storageAccessKey = null, string password = null, bool? areSystemDbsIncludedInBackup = default(bool?), Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType? backupScheduleType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency? fullBackupFrequency = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek> daysOfWeek = null, int? fullBackupStartHour = default(int?), int? fullBackupWindowHours = default(int?), int? logBackupFrequency = default(int?)) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmData SqlVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier virtualMachineResourceId = null, string provisioningState = null, string sqlImageOffer = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? sqlServerLicenseType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? sqlManagement = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode?), Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode? leastPrivilegeMode = default(Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? sqlImageSku = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku?), Azure.Core.ResourceIdentifier sqlVmGroupResourceId = null, Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials windowsServerFailoverClusterDomainCredentials = null, System.Net.IPAddress windowsServerFailoverClusterStaticIP = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings autoPatchingSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings autoBackupSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings keyVaultCredentialSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings serverConfigurationsManagementSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings storageConfigurationSettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus troubleshootingStatus = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings assessmentSettings = null, bool? enableAutomaticUpgrade = default(bool?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch? additionalVmPatch = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity virtualMachineIdentitySettings = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOsType? osType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOsType?), string sqlVmName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmData SqlVmData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.Core.ResourceIdentifier virtualMachineResourceId, string provisioningState, string sqlImageOffer, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? sqlServerLicenseType, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? sqlManagement, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? sqlImageSku, Azure.Core.ResourceIdentifier sqlVmGroupResourceId, Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials windowsServerFailoverClusterDomainCredentials, System.Net.IPAddress windowsServerFailoverClusterStaticIP, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings autoPatchingSettings, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings autoBackupSettings, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings keyVaultCredentialSettings, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings serverConfigurationsManagementSettings, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings storageConfigurationSettings, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings assessmentSettings) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData SqlVmGroupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, string provisioningState, string sqlImageOffer, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? sqlImageSku, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType? scaleType, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType? clusterManagerType, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration? clusterConfiguration, Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile windowsServerFailoverClusterDomainProfile) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.SqlVmGroupData SqlVmGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null, string sqlImageOffer = null, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? sqlImageSku = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType? scaleType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType? clusterManagerType = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration? clusterConfiguration = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration?), Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile windowsServerFailoverClusterDomainProfile = null, string sqlVmGroupName = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch SqlVmGroupPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay SqlVmOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch SqlVmPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting SqlVmTroubleshooting(System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario? troubleshootingScenario = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario?), string troubleshootingAdditionalUnhealthyReplicaInfoAvailabilityGroupName = null, string virtualMachineResourceId = null) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus SqlVmTroubleshootingStatus(string rootCause = null, System.DateTimeOffset? lastTriggerTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? startTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? endTimeUtc = default(System.DateTimeOffset?), Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario? troubleshootingScenario = default(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario?), string troubleshootingAdditionalUnhealthyReplicaInfoAvailabilityGroupName = null) { throw null; }
    }
    public partial class AvailabilityGroupListenerLoadBalancerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration>
    {
        public AvailabilityGroupListenerLoadBalancerConfiguration() { }
        public Azure.Core.ResourceIdentifier LoadBalancerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public int? ProbePort { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SqlVmInstances { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerLoadBalancerConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplica PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaCommitMode? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaFailoverMode? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole left, Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupReplicaRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Info : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>
    {
        internal Info() { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay Display { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin? Origin { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty> Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.Info JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.Info PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.Info System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.Info System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.Info>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LeastPrivilegeMode : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LeastPrivilegeMode(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode Enabled { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode NotSet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode left, Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode left, Azure.ResourceManager.SqlVirtualMachine.Models.LeastPrivilegeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MultiSubnetIPConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>
    {
        public MultiSubnetIPConfiguration(Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress privateIPAddress, string sqlVmInstance) { }
        public Azure.ResourceManager.SqlVirtualMachine.Models.AvailabilityGroupListenerPrivateIPAddress PrivateIPAddress { get { throw null; } set { } }
        public string SqlVmInstance { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.MultiSubnetIPConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>
    {
        internal OperationProperty() { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.OperationProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode left, Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.ReadableSecondaryMode? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlImageSku? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlManagementMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlServerConfigurationsManagementSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings>
    {
        public SqlServerConfigurationsManagementSettings() { }
        public string AzureAdAuthenticationClientId { get { throw null; } set { } }
        public bool? IsRServicesEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlConnectivityUpdateSettings SqlConnectivityUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlInstanceSettings SqlInstanceSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings SqlStorageUpdateSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType? SqlWorkloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConfigurationsManagementSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerConnectivityType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlServerLicenseType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlStorageSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings>
    {
        public SqlStorageSettings() { }
        public string DefaultFilePath { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> Luns { get { throw null; } }
        public bool? UseStoragePool { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageUpdateSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? UseStoragePool { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmAdditionalOsPatch : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmAdditionalOsPatch(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch WSUS { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch WU { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch WUMU { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalOsPatch right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmAdditionalVmPatch : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmAdditionalVmPatch(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch MicrosoftUpdate { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch NotSet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch right) { throw null; }
        public override string ToString() { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSchedule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAssessmentSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupDayOfWeek? (string value) { throw null; }
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
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoBackupSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAdditionalVmPatch? AdditionalVmPatch { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingDayOfWeek? DayOfWeek { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MaintenanceWindowDurationInMinutes { get { throw null; } set { } }
        public int? MaintenanceWindowStartingHour { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmAutoPatchingSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterConfiguration? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterManagerType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmClusterSubnetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmDiskConfigAssessmentContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>
    {
        public SqlVmDiskConfigAssessmentContent() { }
        public bool? RunDiskConfigRules { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigAssessmentContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmDiskConfigurationType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmFullBackupFrequency? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupImageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmGroupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch>
    {
        public SqlVmGroupPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmGroupScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>
    {
        public SqlVmIdentity() { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmKeyVaultCredentialSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>
    {
        public SqlVmKeyVaultCredentialSettings() { }
        public System.Uri AzureKeyVaultUri { get { throw null; } set { } }
        public string CredentialName { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public string ServicePrincipalName { get { throw null; } set { } }
        public string ServicePrincipalSecret { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmKeyVaultCredentialSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlVmOperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>
    {
        internal SqlVmOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmOperationOrigin : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmOperationOrigin(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin System { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmOperationOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SqlVmOsType
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class SqlVmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch>
    {
        public SqlVmPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? EnableStorageConfigBlade { get { throw null; } set { } }
        public bool? IsSqlSystemDBOnDataDisk { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings SqlDataSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlStorageSettings SqlLogSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlTempDBSettings SqlTempDBSettings { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType? StorageWorkloadType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageConfigurationSettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmStorageWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmTroubleshooting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>
    {
        public SqlVmTroubleshooting() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } set { } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } set { } }
        public string TroubleshootingAdditionalUnhealthyReplicaInfoAvailabilityGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario? TroubleshootingScenario { get { throw null; } set { } }
        public string VirtualMachineResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshooting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmTroubleshootingScenario : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmTroubleshootingScenario(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario UnhealthyReplica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlVmTroubleshootingStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>
    {
        internal SqlVmTroubleshootingStatus() { }
        public System.DateTimeOffset? EndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? LastTriggerTimeUtc { get { throw null; } }
        public string RootCause { get { throw null; } }
        public System.DateTimeOffset? StartTimeUtc { get { throw null; } }
        public string TroubleshootingAdditionalUnhealthyReplicaInfoAvailabilityGroupName { get { throw null; } }
        public Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingScenario? TroubleshootingScenario { get { throw null; } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmTroubleshootingStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlVmVmIdentityType : System.IEquatable<Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlVmVmIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlVmVmIdentityType right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqlWorkloadType? (string value) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType left, Azure.ResourceManager.SqlVirtualMachine.Models.SqVmBackupScheduleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowsServerFailoverClusterDomainCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials>
    {
        public WindowsServerFailoverClusterDomainCredentials() { }
        public string ClusterBootstrapAccountPassword { get { throw null; } set { } }
        public string ClusterOperatorAccountPassword { get { throw null; } set { } }
        public string SqlServiceAccountPassword { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public bool? IsSqlServiceAccountGmsa { get { throw null; } set { } }
        public string OrganizationalUnitPath { get { throw null; } set { } }
        public string SqlServiceAccount { get { throw null; } set { } }
        public string StorageAccountPrimaryKey { get { throw null; } set { } }
        public System.Uri StorageAccountUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SqlVirtualMachine.Models.WindowsServerFailoverClusterDomainProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
