namespace Azure.ResourceManager.ContainerServiceFleet
{
    public partial class AutoUpgradeProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>, System.Collections.IEnumerable
    {
        protected AutoUpgradeProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string autoUpgradeProfileName, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string autoUpgradeProfileName, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Get(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UpdateStrategyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult> GenerateUpdateRun(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>> GenerateUpdateRunAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource GetContainerServiceFleetMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource GetContainerServiceFleetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetCollection GetContainerServiceFleets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource GetContainerServiceFleetUpdateRunResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource GetFleetUpdateStrategyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ContainerServiceFleetMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fleetMemberName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Get(string fleetMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource> GetAutoUpgradeProfile(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource>> GetAutoUpgradeProfileAsync(string autoUpgradeProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileCollection GetAutoUpgradeProfiles() { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch patch, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>, System.Collections.IEnumerable
    {
        protected ContainerServiceFleetUpdateRunCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateRunName, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Get(string updateRunName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> StrategyStages { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UpdateStrategyId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Skip(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties body, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> SkipAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties body, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Start(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> StartAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Stop(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> StopAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FleetUpdateStrategyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>, System.Collections.IEnumerable
    {
        protected FleetUpdateStrategyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string updateStrategyName, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Get(string updateStrategyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> StrategyStages { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData data, string ifMatch = null, string ifNoneMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceFleet.Mocking
{
    public partial class MockableContainerServiceFleetArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableContainerServiceFleetArmClient() { }
        public virtual Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileResource GetAutoUpgradeProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetResource> GetContainerServiceFleetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ContainerServiceFleet.Models
{
    public static partial class ArmContainerServiceFleetModelFactory
    {
        public static Azure.ResourceManager.ContainerServiceFleet.AutoUpgradeProfileData AutoUpgradeProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState?), Azure.Core.ResourceIdentifier updateStrategyId = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel? channel = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType? selectionType = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType?), bool? disabled = default(bool?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus autoUpgradeProfileStatus = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult AutoUpgradeProfileGenerateResult(string id = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus AutoUpgradeProfileStatus(System.DateTimeOffset? lastTriggeredOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus? lastTriggerStatus = default(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus?), Azure.ResponseError lastTriggerError = null, System.Collections.Generic.IEnumerable<string> lastTriggerUpgradeVersions = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData ContainerServiceFleetData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? eTag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetData ContainerServiceFleetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState?), Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile hubProfile = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus status = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData ContainerServiceFleetMemberData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ETag? eTag, Azure.Core.ResourceIdentifier clusterResourceId, string group, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetMemberData ContainerServiceFleetMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.Core.ResourceIdentifier clusterResourceId = null, string group = null, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus status = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus ContainerServiceFleetMemberStatus(string lastOperationId = null, Azure.ResponseError lastOperationError = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus ContainerServiceFleetStatus(string lastOperationId = null, Azure.ResponseError lastOperationError = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus ContainerServiceFleetUpdateGroupStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus> members = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData ContainerServiceFleetUpdateRunData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ETag? eTag, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState? provisioningState, Azure.Core.ResourceIdentifier updateStrategyId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> strategyStages, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate managedClusterUpdate, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus status) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.ContainerServiceFleetUpdateRunData ContainerServiceFleetUpdateRunData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState?), Azure.Core.ResourceIdentifier updateStrategyId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> strategyStages = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate managedClusterUpdate = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus status = null, Azure.Core.ResourceIdentifier autoUpgradeProfileId = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus ContainerServiceFleetUpdateRunStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> selectedNodeImageVersions = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus ContainerServiceFleetUpdateStageStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus> groups = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus afterStageWaitStatus = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus ContainerServiceFleetUpdateStatus(System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState? state = default(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState?), Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus ContainerServiceFleetWaitStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, int? waitDurationInSeconds = default(int?)) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult FleetCredentialResult(string name = null, byte[] value = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResults FleetCredentialResults(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.FleetCredentialResult> kubeconfigs = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile FleetHubProfile(string dnsPrefix = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile apiServerAccessProfile = null, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile agentProfile = null, string fqdn = null, string kubernetesVersion = null, string portalFqdn = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.FleetUpdateStrategyData FleetUpdateStrategyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ETag? eTag = default(Azure.ETag?), Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState? provisioningState = default(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage> strategyStages = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus MemberUpdateStatus(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus status = null, string name = null, Azure.Core.ResourceIdentifier clusterResourceId = null, string operationId = null, string message = null) { throw null; }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion NodeImageVersion(string version = null) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeLastTriggerStatus (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeNodeImageSelectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AutoUpgradeProfileGenerateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileGenerateResult>
    {
        internal AutoUpgradeProfileGenerateResult() { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileProvisioningState (string value) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.AutoUpgradeProfileStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetAgentProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAgentProfile>
    {
        public ContainerServiceFleetAgentProfile() { }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetAPIServerAccessProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetManagedClusterUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpdate>
    {
        public ContainerServiceFleetManagedClusterUpdate(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec upgrade) { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelection NodeImageSelection { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType? SelectionType { get { throw null; } set { } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeSpec Upgrade { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetManagedClusterUpgradeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetMemberPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberPatch>
    {
        public ContainerServiceFleetMemberPatch() { }
        public string Group { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetMemberStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>
    {
        public ContainerServiceFleetPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetSkipProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipProperties>
    {
        public ContainerServiceFleetSkipProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetSkipTarget> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetTargetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>
    {
        public ContainerServiceFleetUpdateGroup(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateGroupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus>
    {
        internal ContainerServiceFleetUpdateGroupStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus> Members { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetUpdateRunStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>
    {
        internal ContainerServiceFleetUpdateRunStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion> SelectedNodeImageVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus> Stages { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateRunStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateStage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>
    {
        public ContainerServiceFleetUpdateStage(string name) { }
        public int? AfterStageWaitInSeconds { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroup> Groups { get { throw null; } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerServiceFleetUpdateStageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStageStatus>
    {
        internal ContainerServiceFleetUpdateStageStatus() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus AfterStageWaitStatus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateGroupStatus> Groups { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Running { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Skipped { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Stopped { get { throw null; } }
        public static Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateState (string value) { throw null; }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public bool Equals(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel left, Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpgradeChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerServiceFleetWaitStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetWaitStatus>
    {
        internal ContainerServiceFleetWaitStatus() { }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        public int? WaitDurationInSeconds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public byte[] Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.FleetHubProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetMemberProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState left, Azure.ResourceManager.ContainerServiceFleet.Models.FleetUpdateStrategyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemberUpdateStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.MemberUpdateStatus>
    {
        internal MemberUpdateStatus() { }
        public Azure.Core.ResourceIdentifier ClusterResourceId { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public string OperationId { get { throw null; } }
        public Azure.ResourceManager.ContainerServiceFleet.Models.ContainerServiceFleetUpdateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType left, Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageSelectionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodeImageVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>
    {
        public NodeImageVersion() { }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ContainerServiceFleet.Models.NodeImageVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
