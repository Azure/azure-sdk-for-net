namespace Azure.ResourceManager.DatabaseWatcher
{
    public partial class AlertRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AlertRuleResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string alertRuleResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AlertRuleResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>, System.Collections.IEnumerable
    {
        protected AlertRuleResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string alertRuleResourceName, Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string alertRuleResourceName, Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> Get(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> GetAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> GetIfExists(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> GetIfExistsAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AlertRuleResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>
    {
        public AlertRuleResourceData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class DatabaseWatcherExtensions
    {
        public static Azure.ResourceManager.DatabaseWatcher.AlertRuleResource GetAlertRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.HealthValidationResource GetHealthValidationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource GetSharedPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.TargetResource GetTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatcher(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> GetWatcherAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.WatcherResource GetWatcherResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.WatcherCollection GetWatchers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatchers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatchersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthValidationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>, System.Collections.IEnumerable
    {
        protected HealthValidationCollection() { }
        public virtual Azure.Response<bool> Exists(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> Get(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>> GetAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> GetIfExists(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>> GetIfExistsAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthValidationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>
    {
        internal HealthValidationData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.HealthValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.HealthValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthValidationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthValidationResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.HealthValidationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string healthValidationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> StartValidation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>> StartValidationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.HealthValidationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.HealthValidationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.HealthValidationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharedPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SharedPrivateLinkResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string sharedPrivateLinkResourceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SharedPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected SharedPrivateLinkResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sharedPrivateLinkResourceName, Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> Get(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> GetAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> GetIfExists(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> GetIfExistsAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SharedPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>
    {
        public SharedPrivateLinkResourceData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.TargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.TargetResource>, System.Collections.IEnumerable
    {
        protected TargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.TargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.DatabaseWatcher.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.TargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.DatabaseWatcher.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.TargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.TargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.TargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.TargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.TargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.TargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.TargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.TargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TargetData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>
    {
        public TargetData() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.TargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.TargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TargetResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.TargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.TargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.TargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.TargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.TargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.TargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WatcherCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.WatcherResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.WatcherResource>, System.Collections.IEnumerable
    {
        protected WatcherCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.WatcherResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.DatabaseWatcher.WatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string watcherName, Azure.ResourceManager.DatabaseWatcher.WatcherData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> Get(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> GetAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetIfExists(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> GetIfExistsAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DatabaseWatcher.WatcherResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DatabaseWatcher.WatcherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DatabaseWatcher.WatcherResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.WatcherResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WatcherData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>
    {
        public WatcherData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.WatcherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.WatcherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WatcherResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WatcherResource() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.WatcherData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string watcherName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource> GetAlertRuleResource(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.AlertRuleResource>> GetAlertRuleResourceAsync(string alertRuleResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceCollection GetAlertRuleResources() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource> GetHealthValidation(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.HealthValidationResource>> GetHealthValidationAsync(string healthValidationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.HealthValidationCollection GetHealthValidations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource> GetSharedPrivateLinkResource(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource>> GetSharedPrivateLinkResourceAsync(string sharedPrivateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceCollection GetSharedPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource> GetTarget(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.TargetResource>> GetTargetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.TargetCollection GetTargets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DatabaseWatcher.WatcherData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.WatcherData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.WatcherData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.WatcherResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseWatcher.Mocking
{
    public partial class MockableDatabaseWatcherArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherArmClient() { }
        public virtual Azure.ResourceManager.DatabaseWatcher.AlertRuleResource GetAlertRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.HealthValidationResource GetHealthValidationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResource GetSharedPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.TargetResource GetTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.WatcherResource GetWatcherResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabaseWatcherResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatcher(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DatabaseWatcher.WatcherResource>> GetWatcherAsync(string watcherName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DatabaseWatcher.WatcherCollection GetWatchers() { throw null; }
    }
    public partial class MockableDatabaseWatcherSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabaseWatcherSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatchers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DatabaseWatcher.WatcherResource> GetWatchersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DatabaseWatcher.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AlertRuleCreationProperty : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AlertRuleCreationProperty(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty CreatedWithActionGroup { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty left, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty left, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AlertRuleResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>
    {
        public AlertRuleResourceProperties(Azure.Core.ResourceIdentifier alertRuleResourceId, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty createdWithProperties, System.DateTimeOffset createdOn, string alertRuleTemplateId, string alertRuleTemplateVersion) { }
        public Azure.Core.ResourceIdentifier AlertRuleResourceId { get { throw null; } set { } }
        public string AlertRuleTemplateId { get { throw null; } set { } }
        public string AlertRuleTemplateVersion { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty CreatedWithProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDatabaseWatcherModelFactory
    {
        public static Azure.ResourceManager.DatabaseWatcher.AlertRuleResourceData AlertRuleResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleResourceProperties AlertRuleResourceProperties(Azure.Core.ResourceIdentifier alertRuleResourceId = null, Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty createdWithProperties = default(Azure.ResourceManager.DatabaseWatcher.Models.AlertRuleCreationProperty), System.DateTimeOffset createdOn = default(System.DateTimeOffset), Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?), string alertRuleTemplateId = null, string alertRuleTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.HealthValidationData HealthValidationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties HealthValidationProperties(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset endOn = default(System.DateTimeOffset), Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus status = default(Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue> issues = null, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 ManagedServiceIdentityV4(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType type = default(Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.SharedPrivateLinkResourceData SharedPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties SharedPrivateLinkResourceProperties(Azure.Core.ResourceIdentifier privateLinkResourceId = null, string groupId = null, string requestMessage = null, string dnsZone = null, Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus? status = default(Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus?), Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties SqlDbElasticPoolTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlEpResourceId = null, Azure.Core.ResourceIdentifier anchorDatabaseResourceId = null, bool? readIntent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties SqlDbSingleDatabaseTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlDbResourceId = null, bool? readIntent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties SqlMiTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?), Azure.Core.ResourceIdentifier sqlMiResourceId = null, int? connectionTcpPort = default(int?), bool? readIntent = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.TargetData TargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties TargetProperties(string targetType = null, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType = default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret targetVault = null, string connectionServerName = null, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue ValidationIssue(string errorCode = null, string errorMessage = null, string additionalDetails = null, string recommendationMessage = null, System.Uri recommendationUri = null, Azure.Core.ResourceIdentifier relatedResourceId = null, string relatedResourceType = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.WatcherData WatcherData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties properties = null, Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 identity = null) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties WatcherProperties(Azure.ResourceManager.DatabaseWatcher.Models.Datastore datastore = null, Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus? status = default(Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus?), Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState? provisioningState = default(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState?), Azure.Core.ResourceIdentifier defaultAlertRuleIdentityResourceId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabaseWatcherProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabaseWatcherProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Datastore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>
    {
        public Datastore(string kustoClusterUri, string kustoDataIngestionUri, string kustoDatabaseName, string kustoManagementUri, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType kustoOfferingType) { }
        public Azure.Core.ResourceIdentifier AdxClusterResourceId { get { throw null; } set { } }
        public string KustoClusterDisplayName { get { throw null; } set { } }
        public string KustoClusterUri { get { throw null; } set { } }
        public string KustoDatabaseName { get { throw null; } set { } }
        public string KustoDataIngestionUri { get { throw null; } set { } }
        public string KustoManagementUri { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType KustoOfferingType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.Datastore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.Datastore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.Datastore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HealthValidationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>
    {
        internal HealthValidationProperties() { }
        public System.DateTimeOffset EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue> Issues { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.HealthValidationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KustoOfferingType : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KustoOfferingType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Adx { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Fabric { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType Free { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType left, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType left, Azure.ResourceManager.DatabaseWatcher.Models.KustoOfferingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType SystemAndUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentityV4 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>
    {
        public ManagedServiceIdentityV4(Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState left, Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SharedPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>
    {
        public SharedPrivateLinkResourceProperties(Azure.Core.ResourceIdentifier privateLinkResourceId, string groupId, string requestMessage) { }
        public string DnsZone { get { throw null; } set { } }
        public string GroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SharedPrivateLinkResourceStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SharedPrivateLinkResourceStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus left, Azure.ResourceManager.DatabaseWatcher.Models.SharedPrivateLinkResourceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlDbElasticPoolTargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>
    {
        public SqlDbElasticPoolTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlEpResourceId, Azure.Core.ResourceIdentifier anchorDatabaseResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public Azure.Core.ResourceIdentifier AnchorDatabaseResourceId { get { throw null; } set { } }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlEpResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbElasticPoolTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDbSingleDatabaseTargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>
    {
        public SqlDbSingleDatabaseTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlDbResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlDbResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlDbSingleDatabaseTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlMiTargetProperties : Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>
    {
        public SqlMiTargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName, Azure.Core.ResourceIdentifier sqlMiResourceId) : base (default(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType), default(string)) { }
        public int? ConnectionTcpPort { get { throw null; } set { } }
        public bool? ReadIntent { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SqlMiResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.SqlMiTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TargetAuthenticationType : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TargetAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType Aad { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType Sql { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType left, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType left, Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>
    {
        protected TargetProperties(Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType targetAuthenticationType, string connectionServerName) { }
        public string ConnectionServerName { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.TargetAuthenticationType TargetAuthenticationType { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret TargetVault { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.TargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ValidationIssue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>
    {
        internal ValidationIssue() { }
        public string AdditionalDetails { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string RecommendationMessage { get { throw null; } }
        public System.Uri RecommendationUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier RelatedResourceId { get { throw null; } }
        public string RelatedResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.ValidationIssue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus Canceled { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus Succeeded { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus TimedOut { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus left, Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus left, Azure.ResourceManager.DatabaseWatcher.Models.ValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultSecret : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>
    {
        public VaultSecret() { }
        public Azure.Core.ResourceIdentifier AkvResourceId { get { throw null; } set { } }
        public string AkvTargetPassword { get { throw null; } set { } }
        public string AkvTargetUser { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.VaultSecret>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WatcherPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>
    {
        public WatcherPatch() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.ManagedServiceIdentityV4 Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WatcherProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>
    {
        public WatcherProperties() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.Datastore Datastore { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultAlertRuleIdentityResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DatabaseWatcher.Models.DatabaseWatcherProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WatcherStatus : System.IEquatable<Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WatcherStatus(string value) { throw null; }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus Deleting { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus Running { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus Starting { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus Stopped { get { throw null; } }
        public static Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus Stopping { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus left, Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus left, Azure.ResourceManager.DatabaseWatcher.Models.WatcherStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WatcherUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>
    {
        public WatcherUpdateProperties() { }
        public Azure.ResourceManager.DatabaseWatcher.Models.Datastore Datastore { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DefaultAlertRuleIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DatabaseWatcher.Models.WatcherUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
