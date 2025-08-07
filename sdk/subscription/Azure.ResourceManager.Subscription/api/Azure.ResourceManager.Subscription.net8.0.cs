namespace Azure.ResourceManager.Subscription
{
    public partial class AzureResourceManagerSubscriptionContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSubscriptionContext() { }
        public static Azure.ResourceManager.Subscription.AzureResourceManagerSubscriptionContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BillingAccountPolicyCollection : Azure.ResourceManager.ArmCollection
    {
        protected BillingAccountPolicyCollection() { }
        public virtual Azure.Response<bool> Exists(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> Get(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> GetIfExists(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetIfExistsAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BillingAccountPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>
    {
        internal BillingAccountPolicyData() { }
        public Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.BillingAccountPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.BillingAccountPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BillingAccountPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BillingAccountPolicyResource() { }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string billingAccountId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Subscription.BillingAccountPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.BillingAccountPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.BillingAccountPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAliasCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>, System.Collections.IEnumerable
    {
        protected SubscriptionAliasCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string aliasName, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Get(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetIfExists(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetIfExistsAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Subscription.SubscriptionAliasResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.SubscriptionAliasResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SubscriptionAliasData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>
    {
        internal SubscriptionAliasData() { }
        public Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.SubscriptionAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.SubscriptionAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAliasResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SubscriptionAliasResource() { }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string aliasName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Subscription.SubscriptionAliasData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.SubscriptionAliasData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.SubscriptionAliasData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.ResourceManager.ArmOperation AcceptSubscriptionOwnership(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AcceptSubscriptionOwnershipAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId> CancelSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>> CancelSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId> EnableSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>> EnableSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus> GetAcceptOwnershipStatus(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>> GetAcceptOwnershipStatusAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPolicyCollection GetBillingAccountPolicies(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> GetBillingAccountPolicy(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetBillingAccountPolicyAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPolicyResource GetBillingAccountPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetSubscriptionAlias(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetSubscriptionAliasAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasCollection GetSubscriptionAliases(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasResource GetSubscriptionAliasResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicy(this Azure.ResourceManager.Resources.TenantResource tenantResource) { throw null; }
        public static Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId> RenameSubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>> RenameSubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TenantPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>
    {
        internal TenantPolicyData() { }
        public Azure.ResourceManager.Subscription.Models.TenantPolicyProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.TenantPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.TenantPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TenantPolicyResource() { }
        public virtual Azure.ResourceManager.Subscription.TenantPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.TenantPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Subscription.TenantPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.TenantPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.TenantPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Subscription.TenantPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.TenantPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.TenantPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Subscription.Mocking
{
    public partial class MockableSubscriptionArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSubscriptionArmClient() { }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPolicyResource GetBillingAccountPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasResource GetSubscriptionAliasResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSubscriptionSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSubscriptionSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId> CancelSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>> CancelSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId> EnableSubscription(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>> EnableSubscriptionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId> RenameSubscription(Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>> RenameSubscriptionAsync(Azure.ResourceManager.Subscription.Models.SubscriptionName body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableSubscriptionTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSubscriptionTenantResource() { }
        public virtual Azure.ResourceManager.ArmOperation AcceptSubscriptionOwnership(Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AcceptSubscriptionOwnershipAsync(Azure.WaitUntil waitUntil, string subscriptionId, Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus> GetAcceptOwnershipStatus(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>> GetAcceptOwnershipStatusAsync(string subscriptionId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Subscription.BillingAccountPolicyCollection GetBillingAccountPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource> GetBillingAccountPolicy(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.BillingAccountPolicyResource>> GetBillingAccountPolicyAsync(string billingAccountId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource> GetSubscriptionAlias(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Subscription.SubscriptionAliasResource>> GetSubscriptionAliasAsync(string aliasName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Subscription.SubscriptionAliasCollection GetSubscriptionAliases() { throw null; }
        public virtual Azure.ResourceManager.Subscription.TenantPolicyResource GetTenantPolicy() { throw null; }
    }
}
namespace Azure.ResourceManager.Subscription.Models
{
    public partial class AcceptOwnershipContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>
    {
        public AcceptOwnershipContent() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptOwnershipProvisioningState : System.IEquatable<Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptOwnershipProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcceptOwnershipRequestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>
    {
        public AcceptOwnershipRequestProperties(string displayName) { }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptOwnershipState : System.IEquatable<Azure.ResourceManager.Subscription.Models.AcceptOwnershipState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptOwnershipState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Completed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Expired { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipState Pending { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.AcceptOwnershipState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState left, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AcceptOwnershipStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>
    {
        internal AcceptOwnershipStatus() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? AcceptOwnershipState { get { throw null; } }
        public string BillingOwner { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState? ProvisioningState { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public System.Guid? SubscriptionTenantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmSubscriptionModelFactory
    {
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipRequestProperties AcceptOwnershipRequestProperties(string displayName = null, string managementGroupId = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.AcceptOwnershipStatus AcceptOwnershipStatus(string subscriptionId = null, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? acceptOwnershipState = default(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState?), Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState? provisioningState = default(Azure.ResourceManager.Subscription.Models.AcceptOwnershipProvisioningState?), string billingOwner = null, System.Guid? subscriptionTenantId = default(System.Guid?), string displayName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Subscription.BillingAccountPolicyData BillingAccountPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties BillingAccountPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Subscription.Models.ServiceTenant> serviceTenants = null, bool? allowTransfers = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId CanceledSubscriptionId(string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId EnabledSubscriptionId(string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId RenamedSubscriptionId(string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.ServiceTenant ServiceTenant(System.Guid? tenantId = default(System.Guid?), string tenantName = null) { throw null; }
        public static Azure.ResourceManager.Subscription.SubscriptionAliasData SubscriptionAliasData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties SubscriptionAliasProperties(string subscriptionId = null, string displayName = null, Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState? provisioningState = default(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState?), System.Uri acceptOwnershipUri = null, Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? acceptOwnershipState = default(Azure.ResourceManager.Subscription.Models.AcceptOwnershipState?), string billingScope = null, Azure.ResourceManager.Subscription.Models.SubscriptionWorkload? workload = default(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload?), string resellerId = null, string subscriptionOwnerId = null, string managementGroupId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Subscription.TenantPolicyData TenantPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Subscription.Models.TenantPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.TenantPolicyProperties TenantPolicyProperties(string policyId = null, bool? blockSubscriptionsLeavingTenant = default(bool?), bool? blockSubscriptionsIntoTenant = default(bool?), System.Collections.Generic.IEnumerable<System.Guid> exemptedPrincipals = null) { throw null; }
    }
    public partial class BillingAccountPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>
    {
        internal BillingAccountPolicyProperties() { }
        public bool? AllowTransfers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Subscription.Models.ServiceTenant> ServiceTenants { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.BillingAccountPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CanceledSubscriptionId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>
    {
        internal CanceledSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.CanceledSubscriptionId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnabledSubscriptionId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>
    {
        internal EnabledSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.EnabledSubscriptionId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RenamedSubscriptionId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>
    {
        internal RenamedSubscriptionId() { }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.RenamedSubscriptionId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceTenant : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>
    {
        internal ServiceTenant() { }
        public System.Guid? TenantId { get { throw null; } }
        public string TenantName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.ServiceTenant System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.ServiceTenant System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.ServiceTenant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAliasAdditionalProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>
    {
        public SubscriptionAliasAdditionalProperties() { }
        public string ManagementGroupId { get { throw null; } set { } }
        public string SubscriptionOwnerId { get { throw null; } set { } }
        public System.Guid? SubscriptionTenantId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAliasCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>
    {
        public SubscriptionAliasCreateOrUpdateContent() { }
        public Azure.ResourceManager.Subscription.Models.SubscriptionAliasAdditionalProperties AdditionalProperties { get { throw null; } set { } }
        public string BillingScope { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string ResellerId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionWorkload? Workload { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionAliasProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>
    {
        internal SubscriptionAliasProperties() { }
        public Azure.ResourceManager.Subscription.Models.AcceptOwnershipState? AcceptOwnershipState { get { throw null; } }
        public System.Uri AcceptOwnershipUri { get { throw null; } }
        public string BillingScope { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ManagementGroupId { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState? ProvisioningState { get { throw null; } }
        public string ResellerId { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string SubscriptionOwnerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Subscription.Models.SubscriptionWorkload? Workload { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionAliasProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>
    {
        public SubscriptionName() { }
        public string SubscriptionNameValue { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.SubscriptionName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.SubscriptionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionProvisioningState : System.IEquatable<Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState left, Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState left, Azure.ResourceManager.Subscription.Models.SubscriptionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionWorkload : System.IEquatable<Azure.ResourceManager.Subscription.Models.SubscriptionWorkload>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionWorkload(string value) { throw null; }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionWorkload DevTest { get { throw null; } }
        public static Azure.ResourceManager.Subscription.Models.SubscriptionWorkload Production { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload left, Azure.ResourceManager.Subscription.Models.SubscriptionWorkload right) { throw null; }
        public static implicit operator Azure.ResourceManager.Subscription.Models.SubscriptionWorkload (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Subscription.Models.SubscriptionWorkload left, Azure.ResourceManager.Subscription.Models.SubscriptionWorkload right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TenantPolicyCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>
    {
        public TenantPolicyCreateOrUpdateContent() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } set { } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.Guid> ExemptedPrincipals { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TenantPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>
    {
        internal TenantPolicyProperties() { }
        public bool? BlockSubscriptionsIntoTenant { get { throw null; } }
        public bool? BlockSubscriptionsLeavingTenant { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<System.Guid> ExemptedPrincipals { get { throw null; } }
        public string PolicyId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.TenantPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Subscription.Models.TenantPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Subscription.Models.TenantPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
