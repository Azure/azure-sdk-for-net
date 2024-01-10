namespace Azure.ResourceManager.PlaywrightTesting
{
    public partial class AccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PlaywrightTesting.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlaywrightTesting.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.PlaywrightTesting.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.AccountResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountData>
    {
        public AccountData(Azure.Core.AzureLocation location) { }
        public System.Uri DashboardUri { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        Azure.ResourceManager.PlaywrightTesting.AccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.AccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.AccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.AccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> Update(Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> UpdateAsync(Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PlaywrightTestingExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> GetAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.AccountCollection GetAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.QuotumCollection GetQuota(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource> GetQuotum(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource>> GetQuotumAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.QuotumResource GetQuotumResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class QuotumCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.QuotumResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.QuotumResource>, System.Collections.IEnumerable
    {
        protected QuotumCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource> Get(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.QuotumResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.QuotumResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource>> GetAsync(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.QuotumResource> GetIfExists(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlaywrightTesting.QuotumResource>> GetIfExistsAsync(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlaywrightTesting.QuotumResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlaywrightTesting.QuotumResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlaywrightTesting.QuotumResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlaywrightTesting.QuotumResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class QuotumData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>
    {
        public QuotumData() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties FreeTrial { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.QuotumData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.QuotumData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.QuotumData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QuotumResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected QuotumResource() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.QuotumData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Mocking
{
    public partial class MockablePlaywrightTestingArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingArmClient() { }
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountResource GetAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.QuotumResource GetQuotumResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlaywrightTestingResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccount(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.AccountResource>> GetAccountAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.AccountCollection GetAccounts() { throw null; }
    }
    public partial class MockablePlaywrightTestingSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlaywrightTestingSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlaywrightTesting.AccountResource> GetAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlaywrightTesting.QuotumCollection GetQuota(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource> GetQuotum(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlaywrightTesting.QuotumResource>> GetQuotumAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlaywrightTesting.Models
{
    public partial class AccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>
    {
        public AccountPatch() { }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? RegionalAffinity { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? Reporting { get { throw null; } set { } }
        public Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? ScalableExecution { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlaywrightTesting.Models.AccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmPlaywrightTestingModelFactory
    {
        public static Azure.ResourceManager.PlaywrightTesting.AccountData AccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri dashboardUri = null, Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? regionalAffinity = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? scalableExecution = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus? reporting = default(Azure.ResourceManager.PlaywrightTesting.Models.EnablementStatus?), Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.QuotumData QuotumData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PlaywrightTesting.Models.FreeTrialProperties freeTrial = null, Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState?)) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState left, Azure.ResourceManager.PlaywrightTesting.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuotaName : System.IEquatable<Azure.ResourceManager.PlaywrightTesting.Models.QuotaName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuotaName(string value) { throw null; }
        public static Azure.ResourceManager.PlaywrightTesting.Models.QuotaName ScalableExecution { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlaywrightTesting.Models.QuotaName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlaywrightTesting.Models.QuotaName left, Azure.ResourceManager.PlaywrightTesting.Models.QuotaName right) { throw null; }
        public override string ToString() { throw null; }
    }
}
