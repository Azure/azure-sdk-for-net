namespace Azure.ResourceManager.PlaywrightTesting
{
    public partial class PlaywrightTestingAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>, System.Collections.IEnumerable
    {
        protected PlaywrightTestingAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightTestingAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>
    {
        public PlaywrightTestingAccountData(Azure.Core.AzureLocation location) { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightTestingAccountResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> Update(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> UpdateAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PlaywrightTestingExtensions
    {
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetPlaywrightTestingAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource GetPlaywrightTestingAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountCollection GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource GetPlaywrightTestingQuotaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class PlaywrightTestingQuotaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>, System.Collections.IEnumerable
    {
        protected PlaywrightTestingQuotaCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> Get(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetIfExists(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetIfExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlaywrightTestingQuotaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>
    {
        public PlaywrightTestingQuotaData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties FreeTrial { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlaywrightTestingQuotaResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlaywrightTestingQuotaResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Mocking
{
    public partial class MockablePlaywrightTestingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingArmClient() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource GetPlaywrightTestingAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource GetPlaywrightTestingQuotaResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlaywrightTestingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccount(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource>> GetPlaywrightTestingAccountAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountCollection GetPlaywrightTestingAccounts() { throw null; }
    }
    public partial class MockablePlaywrightTestingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingSubscriptionResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaCollection GetAllPlaywrightTestingQuota(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountResource> GetPlaywrightTestingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource> GetPlaywrightTestingQuota(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaResource>> GetPlaywrightTestingQuotaAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Models
{
    public static partial class ArmPlaywrightTestingModelFactory
    {
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingAccountData PlaywrightTestingAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri dashboardUri = null, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? regionalAffinity = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? scalableExecution = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? reporting = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.PlaywrightTestingQuotaData PlaywrightTestingQuotaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnablementStatus : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnablementStatus(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus left, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FreeTrialProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>
    {
        public FreeTrialProperties(string accountId, System.DateTimeOffset createdOn, System.DateTimeOffset expiryOn, int allocatedValue, int usedValue, decimal percentageUsed, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState state) { }
        public string AccountId { get { throw null; } }
        public int AllocatedValue { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public System.DateTimeOffset ExpiryOn { get { throw null; } }
        public decimal PercentageUsed { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState State { get { throw null; } }
        public int UsedValue { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FreeTrialState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FreeTrialState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState Active { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState Expired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState left, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlaywrightTestingAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>
    {
        public PlaywrightTestingAccountPatch() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingProvisioningState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlaywrightTestingQuotaName : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlaywrightTestingQuotaName(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName ScalableExecution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.PlaywrightTestingQuotaName right) { throw null; }
        public override string ToString() { throw null; }
    }
}
