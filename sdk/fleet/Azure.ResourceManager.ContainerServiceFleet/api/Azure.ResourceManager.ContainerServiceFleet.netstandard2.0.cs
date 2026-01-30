namespace Azure.ResourceManager.ContainerServiceFleet
{
    public partial class AutoUpgradeProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>, System.Collections.IEnumerable
    {
        protected AutoUpgradeProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string autoUpgradeProfileName, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string autoUpgradeProfileName, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Get(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetIfExists(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetIfExistsAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AutoUpgradeProfileData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>
    {
        public AutoUpgradeProfileData() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus AutoUpgradeProfileStatus { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel? Channel { get { throw null; } set { } }
        public bool? Disabled { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? LongTermSupport { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public string TargetKubernetesVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UpdateStrategyId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoUpgradeProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AutoUpgradeProfileResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string autoUpgradeProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult> GenerateUpdateRun(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>> GenerateUpdateRunAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerContainerServiceFleetContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerContainerServiceFleetContext() { }
        public static Azure.ResourceManager.ContainerServiceFleet.AzureResourceManagerContainerServiceFleetContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ContainerServiceFleetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> Get(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetIfExists(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetIfExistsAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceFleetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>
    {
        public ContainerServiceFleetData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile HubProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContainerServiceFleetExtensions
    {
        public static Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource GetAutoUpgradeProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetContainerServiceFleetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource GetContainerServiceFleetGateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource GetContainerServiceFleetManagedNamespaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource GetContainerServiceFleetMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource GetContainerServiceFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetCollection GetContainerServiceFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource GetContainerServiceFleetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource GetFleetUpdateStrategyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ContainerServiceFleetGateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetGateCollection() { }
        public virtual Azure.Response<bool> Exists(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> Get(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> GetAll(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> GetAllAsync(string filter = null, int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>> GetAsync(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> GetIfExists(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>> GetIfExistsAsync(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceFleetGateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>
    {
        public ContainerServiceFleetGateData() { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType GateType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState State { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetGateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceFleetGateResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string gateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch patch, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch patch, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceFleetManagedNamespaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetManagedNamespaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedNamespaceName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedNamespaceName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> Get(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> GetAsync(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> GetIfExists(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> GetIfExistsAsync(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceFleetManagedNamespaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>
    {
        public ContainerServiceFleetManagedNamespaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy AdoptionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy DeletePolicy { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties ManagedNamespaceProperties { get { throw null; } set { } }
        public string PortalFqdn { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy PropagationPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetManagedNamespaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceFleetManagedNamespaceResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string managedNamespaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceFleetMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Get(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetAll(int? top = default(int?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetAllAsync(int? top = default(int?), string skipToken = null, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> GetAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetIfExists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> GetIfExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceFleetMemberData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>
    {
        public ContainerServiceFleetMemberData() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public string Group { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetMemberResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceFleetMemberResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string fleetMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceFleetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceFleetResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAutoUpgradeProfile(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetAutoUpgradeProfileAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileCollection GetAutoUpgradeProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource> GetContainerServiceFleetGate(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource>> GetContainerServiceFleetGateAsync(string gateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateCollection GetContainerServiceFleetGates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource> GetContainerServiceFleetManagedNamespace(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource>> GetContainerServiceFleetManagedNamespaceAsync(string managedNamespaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceCollection GetContainerServiceFleetManagedNamespaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetContainerServiceFleetMember(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> GetContainerServiceFleetMemberAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberCollection GetContainerServiceFleetMembers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetContainerServiceFleetUpdateRun(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> GetContainerServiceFleetUpdateRunAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunCollection GetContainerServiceFleetUpdateRuns() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults> GetCredentials(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>> GetCredentialsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyCollection GetFleetUpdateStrategies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetFleetUpdateStrategy(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> GetFleetUpdateStrategyAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch patch, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetUpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> GetAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetIfExists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> GetIfExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>
    {
        public ContainerServiceFleetUpdateRunData() { }
        public Azure.Core.ResourceIdentifier AutoUpgradeProfileId { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate ManagedClusterUpdate { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> StrategyStages { get { throw null; } }
        public Azure.Core.ResourceIdentifier UpdateStrategyId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContainerServiceFleetUpdateRunResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateRunName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Skip(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties body, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> SkipAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties body, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Start(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> StartAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Stop(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> StopAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetUpdateStrategyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>, System.Collections.IEnumerable
    {
        protected FleetUpdateStrategyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Get(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetAll(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetAllAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> GetAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetIfExists(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> GetIfExistsAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FleetUpdateStrategyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>
    {
        public FleetUpdateStrategyData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> StrategyStages { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetUpdateStrategyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FleetUpdateStrategyResource() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fleetName, string updateStrategyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ETag? ifMatch = default(Azure.ETag?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, Azure.MatchConditions matchConditions = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceFleet.Mocking
{
    public partial class MockableContainerServiceFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceFleetArmClient() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource GetAutoUpgradeProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateResource GetContainerServiceFleetGateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceResource GetContainerServiceFleetManagedNamespaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource GetContainerServiceFleetMemberResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource GetContainerServiceFleetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource GetContainerServiceFleetUpdateRunResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource GetFleetUpdateStrategyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableContainerServiceFleetResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceFleetResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleet(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetContainerServiceFleetAsync(string fleetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetCollection GetContainerServiceFleets() { throw null; }
    }
    public partial class MockableContainerServiceFleetSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceFleetSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleets(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleetsAsync(int? top = default(int?), string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    public static partial class ArmContainerServiceFleetModelFactory
    {
        public static Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData AutoUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState?), Azure.Core.ResourceIdentifier updateStrategyId = null, bool? disabled = default(bool?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus autoUpgradeProfileStatus = null, string targetKubernetesVersion = null, bool? longTermSupport = default(bool?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType? selectionType = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel? channel = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult AutoUpgradeProfileGenerateResult(string id = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus AutoUpgradeProfileStatus(System.DateTimeOffset? lastTriggeredOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus? lastTriggerStatus = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus?), Azure.ResponseError lastTriggerError = null, System.Collections.Generic.IEnumerable<string> lastTriggerUpgradeVersions = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData ContainerServiceFleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState?), Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile hubProfile = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus status = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetGateData ContainerServiceFleetGateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState?), string displayName = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType? gateType = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget target = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState? state = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState?), Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch ContainerServiceFleetGatePatch(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState? gatePatchState = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetManagedNamespaceData ContainerServiceFleetManagedNamespaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState?), Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties managedNamespaceProperties = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy? adoptionPolicy = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy? deletePolicy = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy propagationPolicy = null, Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus status = null, string portalFqdn = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch ContainerServiceFleetManagedNamespacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData ContainerServiceFleetMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier clusterResourceId = null, string group = null, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState?), System.Collections.Generic.IDictionary<string, string> labels = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus status = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus ContainerServiceFleetMemberStatus(string lastOperationId = null, Azure.ResponseError lastOperationError = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch ContainerServiceFleetPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy ContainerServiceFleetPlacementPolicy(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType? placementType = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType?), System.Collections.Generic.IEnumerable<string> clusterNames = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity clusterAffinity = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration> tolerations = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement ContainerServiceFleetPropertySelectorRequirement(string name = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator @operator = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties ContainerServiceFleetSkipProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget> targets = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget ContainerServiceFleetSkipTarget(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType targetType = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType), string name = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus ContainerServiceFleetStatus(string lastOperationId = null, Azure.ResponseError lastOperationError = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup ContainerServiceFleetUpdateGroup(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> beforeGates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> afterGates = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus ContainerServiceFleetUpdateGroupStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus> members = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> beforeGates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> afterGates = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData ContainerServiceFleetUpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState?), Azure.Core.ResourceIdentifier updateStrategyId = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate managedClusterUpdate = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus status = null, Azure.Core.ResourceIdentifier autoUpgradeProfileId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> strategyStages = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus ContainerServiceFleetUpdateRunStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> selectedNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage ContainerServiceFleetUpdateStage(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup> groups = null, int? afterStageWaitInSeconds = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> beforeGates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> afterGates = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus ContainerServiceFleetUpdateStageStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus> groups = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> beforeGates = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> afterGates = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus afterStageWaitStatus = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus ContainerServiceFleetUpdateStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState? state = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus ContainerServiceFleetWaitStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, int? waitDurationInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult FleetCredentialResult(string name = null, System.Collections.Generic.IEnumerable<System.BinaryData> value = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults FleetCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile FleetHubProfile(string dnsPrefix = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile apiServerAccessProfile = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile agentProfile = null, string fqdn = null, string kubernetesVersion = null, string portalFqdn = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus FleetManagedNamespaceStatus(string lastOperationId = null, Azure.ResponseError lastOperationError = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData FleetUpdateStrategyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> strategyStages = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties GatePatchProperties(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState state = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector LabelSelector(System.Collections.Generic.IDictionary<string, string> matchLabels = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement> matchExpressions = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement LabelSelectorRequirement(string key = null, Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator @operator = default(Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator), System.Collections.Generic.IEnumerable<string> values = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties ManagedNamespaceProperties(System.Collections.Generic.IDictionary<string, string> labels = null, System.Collections.Generic.IDictionary<string, string> annotations = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota defaultResourceQuota = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy defaultNetworkPolicy = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus MemberUpdateStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, Azure.Core.ResourceIdentifier clusterResourceId = null, string operationId = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection NodeImageSelection(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType selectionType = default(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> customNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion NodeImageVersion(string version = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus UpdateRunGateStatus(string displayName = null, Azure.Core.ResourceIdentifier gateId = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties UpdateRunGateTargetProperties(string name = null, string stage = null, string group = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming timing = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpgradeLastTriggerStatus : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpgradeLastTriggerStatus(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpgradeNodeImageSelectionType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpgradeNodeImageSelectionType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType Consistent { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoUpgradeProfileGenerateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>
    {
        internal AutoUpgradeProfileGenerateResult() { }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoUpgradeProfileProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoUpgradeProfileProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoUpgradeProfileStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>
    {
        public AutoUpgradeProfileStatus() { }
        public System.DateTimeOffset? LastTriggeredOn { get { throw null; } }
        public Azure.ResponseError LastTriggerError { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus? LastTriggerStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> LastTriggerUpgradeVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetAdoptionPolicy : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetAdoptionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy Always { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy IfIdentical { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy Never { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAdoptionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetAgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>
    {
        public ContainerServiceFleetAgentProfile() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetAPIServerAccessProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>
    {
        public ContainerServiceFleetAPIServerAccessProfile() { }
        public bool? EnablePrivateCluster { get { throw null; } set { } }
        public bool? EnableVnetIntegration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetClusterAffinity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>
    {
        public ContainerServiceFleetClusterAffinity() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm> RequiredDuringSchedulingIgnoredDuringExecutionClusterSelectorTerms { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetClusterSelectorTerm : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>
    {
        public ContainerServiceFleetClusterSelectorTerm() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector LabelSelector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement> PropertySelectorMatchExpressions { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterSelectorTerm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetDeletePolicy : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetDeletePolicy(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy Delete { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy Keep { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetDeletePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetGateConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>
    {
        public ContainerServiceFleetGateConfiguration(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType type) { }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetGatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>
    {
        public ContainerServiceFleetGatePatch(Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties properties) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState? GatePatchState { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetGateProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetGateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetGateState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetGateState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState Completed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState Skipped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetGateTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>
    {
        public ContainerServiceFleetGateTarget(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties UpdateRunProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetGateTiming : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetGateTiming(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming After { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming Before { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetGateType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetGateType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType Approval { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetManagedClusterUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>
    {
        public ContainerServiceFleetManagedClusterUpdate(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec upgrade) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection NodeImageSelection { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec Upgrade { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetManagedClusterUpgradeSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>
    {
        public ContainerServiceFleetManagedClusterUpgradeSpec(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType upgradeType) { }
        public string KubernetesVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType UpgradeType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetManagedClusterUpgradeType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetManagedClusterUpgradeType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType ControlPlaneOnly { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType Full { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType NodeImageOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetManagedNamespacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>
    {
        public ContainerServiceFleetManagedNamespacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedNamespacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetMemberPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>
    {
        public ContainerServiceFleetMemberPatch() { }
        public string Group { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetMemberStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>
    {
        internal ContainerServiceFleetMemberStatus() { }
        public Azure.ResponseError LastOperationError { get { throw null; } }
        public string LastOperationId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetNetworkPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>
    {
        public ContainerServiceFleetNetworkPolicy() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule? Egress { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule? Ingress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>
    {
        public ContainerServiceFleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetPlacementPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>
    {
        public ContainerServiceFleetPlacementPolicy() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetClusterAffinity ClusterAffinity { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ClusterNames { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType? PlacementType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration> Tolerations { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetPlacementProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>
    {
        public ContainerServiceFleetPlacementProfile() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementPolicy DefaultClusterResourcePlacementPolicy { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetPlacementType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetPlacementType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType PickAll { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType PickFixed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetPolicyRule : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetPolicyRule(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule AllowAll { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule AllowSameNamespace { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule DenyAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPolicyRule right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetPropagationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>
    {
        public ContainerServiceFleetPropagationPolicy(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType type) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPlacementProfile PlacementProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetPropagationType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetPropagationType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType Placement { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropagationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetPropertySelectorOperator : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetPropertySelectorOperator(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Eq { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Ge { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Gt { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Le { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Lt { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Ne { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetPropertySelectorRequirement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>
    {
        public ContainerServiceFleetPropertySelectorRequirement(string name, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator @operator, System.Collections.Generic.IEnumerable<string> values) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPropertySelectorRequirement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetResourceQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>
    {
        public ContainerServiceFleetResourceQuota() { }
        public string CpuLimit { get { throw null; } set { } }
        public string CpuRequest { get { throw null; } set { } }
        public string MemoryLimit { get { throw null; } set { } }
        public string MemoryRequest { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetSkipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>
    {
        public ContainerServiceFleetSkipProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget> Targets { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetSkipTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>
    {
        public ContainerServiceFleetSkipTarget(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType targetType, string name) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType TargetType { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>
    {
        internal ContainerServiceFleetStatus() { }
        public Azure.ResponseError LastOperationError { get { throw null; } }
        public string LastOperationId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetTaintEffect : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetTaintEffect(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect NoSchedule { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetTargetType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetTargetType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType AfterStageWait { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType Group { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType Member { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType Stage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetToleration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>
    {
        public ContainerServiceFleetToleration() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTaintEffect? Effect { get { throw null; } set { } }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator? Operator { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetToleration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetTolerationOperator : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetTolerationOperator(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator Exists { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTolerationOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>
    {
        public ContainerServiceFleetUpdateGroup(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> AfterGates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> BeforeGates { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateGroupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>
    {
        internal ContainerServiceFleetUpdateGroupStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> AfterGates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> BeforeGates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus> Members { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetUpdateRunProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetUpdateRunProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>
    {
        internal ContainerServiceFleetUpdateRunStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> SelectedNodeImageVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus> Stages { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>
    {
        public ContainerServiceFleetUpdateStage(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> AfterGates { get { throw null; } }
        public int? AfterStageWaitInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateConfiguration> BeforeGates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup> Groups { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateStageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>
    {
        internal ContainerServiceFleetUpdateStageStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> AfterGates { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus AfterStageWaitStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus> BeforeGates { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus> Groups { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetUpdateState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetUpdateState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Completed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState NotStarted { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Pending { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Skipped { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Stopped { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>
    {
        internal ContainerServiceFleetUpdateStatus() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState? State { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerServiceFleetUpgradeChannel : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerServiceFleetUpgradeChannel(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel NodeImage { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel Rapid { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel Stable { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel TargetKubernetesVersion { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetWaitStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>
    {
        internal ContainerServiceFleetWaitStatus() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        public int? WaitDurationInSeconds { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetCredentialResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>
    {
        internal FleetCredentialResult() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.BinaryData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetCredentialResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>
    {
        internal FleetCredentialResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult> Kubeconfigs { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FleetHubProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>
    {
        public FleetHubProfile() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile AgentProfile { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile ApiServerAccessProfile { get { throw null; } set { } }
        public string DnsPrefix { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public string PortalFqdn { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetManagedNamespaceProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetManagedNamespaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FleetManagedNamespaceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>
    {
        internal FleetManagedNamespaceStatus() { }
        public Azure.ResponseError LastOperationError { get { throw null; } }
        public string LastOperationId { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetManagedNamespaceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetMemberProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetMemberProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Joining { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Leaving { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FleetUpdateStrategyProvisioningState : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FleetUpdateStrategyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GatePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>
    {
        public GatePatchProperties(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState state) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateState State { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.GatePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LabelSelector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>
    {
        public LabelSelector() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement> MatchExpressions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> MatchLabels { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LabelSelectorOperator : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LabelSelectorOperator(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator DoesNotExist { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator Exists { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator In { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator NotIn { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator left, Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LabelSelectorRequirement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>
    {
        public LabelSelectorRequirement(string key, Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator @operator) { }
        public string Key { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorOperator Operator { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.LabelSelectorRequirement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedNamespaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>
    {
        public ManagedNamespaceProperties() { }
        public System.Collections.Generic.IDictionary<string, string> Annotations { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetNetworkPolicy DefaultNetworkPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetResourceQuota DefaultResourceQuota { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Labels { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ManagedNamespaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemberUpdateStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>
    {
        internal MemberUpdateStatus() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodeImageSelection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>
    {
        public NodeImageSelection(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType selectionType) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> CustomNodeImageVersions { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType SelectionType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NodeImageSelectionType : System.IEquatable<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NodeImageSelectionType(string value) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType Consistent { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType Custom { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType Latest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeImageVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>
    {
        public NodeImageVersion() { }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRunGateStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>
    {
        internal UpdateRunGateStatus() { }
        public string DisplayName { get { throw null; } }
        public Azure.Core.ResourceIdentifier GateId { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateRunGateTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>
    {
        public UpdateRunGateTargetProperties(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming timing) { }
        public string Group { get { throw null; } }
        public string Name { get { throw null; } }
        public string Stage { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetGateTiming Timing { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.UpdateRunGateTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
