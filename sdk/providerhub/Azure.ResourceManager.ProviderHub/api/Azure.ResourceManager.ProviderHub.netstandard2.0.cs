namespace Azure.ResourceManager.ProviderHub
{
    public partial class CustomRolloutCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>, System.Collections.IEnumerable
    {
        protected CustomRolloutCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Get(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.CustomRolloutResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.CustomRolloutResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomRolloutData : Azure.ResourceManager.Models.ResourceData
    {
        public CustomRolloutData(Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties properties) { }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties Properties { get { throw null; } set { } }
    }
    public partial class CustomRolloutResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomRolloutResource() { }
        public virtual Azure.ResourceManager.ProviderHub.CustomRolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string rolloutName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultRolloutCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>, System.Collections.IEnumerable
    {
        protected DefaultRolloutCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Get(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DefaultRolloutData : Azure.ResourceManager.Models.ResourceData
    {
        public DefaultRolloutData() { }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties Properties { get { throw null; } set { } }
    }
    public partial class DefaultRolloutResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DefaultRolloutResource() { }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string rolloutName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeFirstSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeFirstSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeFirstSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeFirstSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.SkuResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeSecondSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeSecondSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeSecondSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeSecondSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.SkuResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeThirdSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeThirdSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeThirdSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeThirdSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.SkuResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>, System.Collections.IEnumerable
    {
        protected NotificationRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationRegistrationName, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationRegistrationName, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Get(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        public NotificationRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class NotificationRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.NotificationRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string notificationRegistrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ProviderHubExtensions
    {
        public static Azure.ResourceManager.ProviderHub.CustomRolloutResource GetCustomRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.DefaultRolloutResource GetDefaultRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource GetNestedResourceTypeFirstSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource GetNestedResourceTypeSecondSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource GetNestedResourceTypeThirdSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NotificationRegistrationResource GetNotificationRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetProviderRegistration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetProviderRegistrationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationResource GetProviderRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource GetResourceTypeRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource GetResourceTypeSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ProviderRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>, System.Collections.IEnumerable
    {
        protected ProviderRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerNamespace, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerNamespace, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Get(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        public ProviderRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class ProviderRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo> CheckinManifest(Azure.ResourceManager.ProviderHub.Models.CheckinManifestParams checkinManifestParams, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>> CheckinManifestAsync(Azure.ResourceManager.ProviderHub.Models.CheckinManifestParams checkinManifestParams, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction> DeleteResourcesResourceAction(Azure.WaitUntil waitUntil, string resourceActionName, Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>> DeleteResourcesResourceActionAsync(Azure.WaitUntil waitUntil, string resourceActionName, Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest> GenerateManifest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>> GenerateManifestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.Models.OperationsDefinition> GenerateOperations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.Models.OperationsDefinition> GenerateOperationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetCustomRollout(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetCustomRolloutAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.CustomRolloutCollection GetCustomRollouts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetDefaultRollout(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetDefaultRolloutAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutCollection GetDefaultRollouts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetNotificationRegistration(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetNotificationRegistrationAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NotificationRegistrationCollection GetNotificationRegistrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetResourceTypeRegistration(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetResourceTypeRegistrationAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationCollection GetResourceTypeRegistrations() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceTypeRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>, System.Collections.IEnumerable
    {
        protected ResourceTypeRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceType, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceType, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Get(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceTypeRegistrationData : Azure.ResourceManager.Models.ResourceData
    {
        public ResourceTypeRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class ResourceTypeRegistrationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceTypeRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetNestedResourceTypeFirstSku(string nestedResourceTypeFirst, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetNestedResourceTypeFirstSkuAsync(string nestedResourceTypeFirst, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuCollection GetNestedResourceTypeFirstSkus(string nestedResourceTypeFirst) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetNestedResourceTypeSecondSku(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetNestedResourceTypeSecondSkuAsync(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuCollection GetNestedResourceTypeSecondSkus(string nestedResourceTypeFirst, string nestedResourceTypeSecond) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetNestedResourceTypeThirdSku(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetNestedResourceTypeThirdSkuAsync(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuCollection GetNestedResourceTypeThirdSkus(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetResourceTypeSku(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetResourceTypeSkuAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuCollection GetResourceTypeSkus() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceTypeSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>, System.Collections.IEnumerable
    {
        protected ResourceTypeSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceTypeSkuResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceTypeSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.SkuResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.SkuResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SkuResourceData : Azure.ResourceManager.Models.ResourceData
    {
        public SkuResourceData() { }
        public Azure.ResourceManager.ProviderHub.Models.SkuResourceProperties Properties { get { throw null; } set { } }
    }
}
namespace Azure.ResourceManager.ProviderHub.Mock
{
    public partial class SubscriptionResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected SubscriptionResourceExtensionClient() { }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations() { throw null; }
    }
}
namespace Azure.ResourceManager.ProviderHub.Models
{
    public partial class AuthorizationActionMapping
    {
        public AuthorizationActionMapping() { }
        public string Desired { get { throw null; } set { } }
        public string Original { get { throw null; } set { } }
    }
    public partial class CanaryTrafficRegionRolloutConfiguration
    {
        public CanaryTrafficRegionRolloutConfiguration() { }
        public System.Collections.Generic.IList<string> Regions { get { throw null; } }
        public System.Collections.Generic.IList<string> SkipRegions { get { throw null; } }
    }
    public partial class CheckinManifestInfo
    {
        internal CheckinManifestInfo() { }
        public string CommitId { get { throw null; } }
        public bool IsCheckedIn { get { throw null; } }
        public string PullRequest { get { throw null; } }
        public string StatusMessage { get { throw null; } }
    }
    public partial class CheckinManifestParams
    {
        public CheckinManifestParams(string environment, string baselineArmManifestLocation) { }
        public string BaselineArmManifestLocation { get { throw null; } }
        public string Environment { get { throw null; } }
    }
    public partial class CheckNameAvailabilitySpecifications
    {
        public CheckNameAvailabilitySpecifications() { }
        public bool? EnableDefaultValidation { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceTypesWithCustomValidation { get { throw null; } }
    }
    public partial class CustomRolloutProperties
    {
        public CustomRolloutProperties(Azure.ResourceManager.ProviderHub.Models.CustomRolloutPropertiesSpecification specification) { }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutPropertiesSpecification Specification { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutPropertiesStatus Status { get { throw null; } set { } }
    }
    public partial class CustomRolloutPropertiesSpecification : Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification
    {
        public CustomRolloutPropertiesSpecification(Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecificationCanary canary) : base (default(Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecificationCanary)) { }
    }
    public partial class CustomRolloutPropertiesStatus : Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus
    {
        public CustomRolloutPropertiesStatus() { }
    }
    public partial class CustomRolloutSpecification
    {
        public CustomRolloutSpecification(Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecificationCanary canary) { }
        public System.Collections.Generic.IList<string> CanaryRegions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecificationProviderRegistration ProviderRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData> ResourceTypeRegistrations { get { throw null; } }
    }
    public partial class CustomRolloutSpecificationCanary : Azure.ResourceManager.ProviderHub.Models.TrafficRegions
    {
        public CustomRolloutSpecificationCanary() { }
    }
    public partial class CustomRolloutSpecificationProviderRegistration : Azure.ResourceManager.Models.ResourceData
    {
        public CustomRolloutSpecificationProviderRegistration() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class CustomRolloutStatus
    {
        public CustomRolloutStatus() { }
        public System.Collections.Generic.IList<string> CompletedRegions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> FailedOrSkippedRegions { get { throw null; } }
    }
    public partial class DefaultRolloutProperties
    {
        public DefaultRolloutProperties() { }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutPropertiesSpecification Specification { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutPropertiesStatus Status { get { throw null; } set { } }
    }
    public partial class DefaultRolloutPropertiesSpecification : Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification
    {
        public DefaultRolloutPropertiesSpecification() { }
    }
    public partial class DefaultRolloutPropertiesStatus : Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus
    {
        public DefaultRolloutPropertiesStatus() { }
    }
    public partial class DefaultRolloutSpecification
    {
        public DefaultRolloutSpecification() { }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationCanary Canary { get { throw null; } set { } }
        public bool? ExpeditedRolloutEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationHighTraffic HighTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationLowTraffic LowTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationMediumTraffic MediumTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationProviderRegistration ProviderRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData> ResourceTypeRegistrations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationRestOfTheWorldGroupOne RestOfTheWorldGroupOne { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecificationRestOfTheWorldGroupTwo RestOfTheWorldGroupTwo { get { throw null; } set { } }
    }
    public partial class DefaultRolloutSpecificationCanary : Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationCanary() { }
    }
    public partial class DefaultRolloutSpecificationHighTraffic : Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationHighTraffic() { }
    }
    public partial class DefaultRolloutSpecificationLowTraffic : Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationLowTraffic() { }
    }
    public partial class DefaultRolloutSpecificationMediumTraffic : Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationMediumTraffic() { }
    }
    public partial class DefaultRolloutSpecificationProviderRegistration : Azure.ResourceManager.Models.ResourceData
    {
        public DefaultRolloutSpecificationProviderRegistration() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties Properties { get { throw null; } set { } }
    }
    public partial class DefaultRolloutSpecificationRestOfTheWorldGroupOne : Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationRestOfTheWorldGroupOne() { }
    }
    public partial class DefaultRolloutSpecificationRestOfTheWorldGroupTwo : Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration
    {
        public DefaultRolloutSpecificationRestOfTheWorldGroupTwo() { }
    }
    public partial class DefaultRolloutStatus : Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase
    {
        public DefaultRolloutStatus() { }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory? NextTrafficRegion { get { throw null; } set { } }
        public System.DateTimeOffset? NextTrafficRegionScheduledOn { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult? SubscriptionReregistrationResult { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.EndpointType Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.EndpointType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.EndpointType Production { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.EndpointType TestInProduction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.EndpointType left, Azure.ResourceManager.ProviderHub.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.EndpointType left, Azure.ResourceManager.ProviderHub.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtendedErrorInfo
    {
        public ExtendedErrorInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> Details { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
    }
    public partial class ExtendedLocationOptions
    {
        public ExtendedLocationOptions() { }
        public string ExtendedLocationOptionsType { get { throw null; } set { } }
        public string SupportedPolicy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionCategory : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ExtensionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceCreationBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceCreationCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceCreationValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceDeletionBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceDeletionCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceDeletionValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceMoveBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceMoveCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourcePatchBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourcePatchCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourcePatchValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourcePostAction { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceReadBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory ResourceReadValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionCategory SubscriptionLifecycleNotification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ExtensionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ExtensionCategory left, Azure.ResourceManager.ProviderHub.Models.ExtensionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ExtensionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ExtensionCategory left, Azure.ResourceManager.ProviderHub.Models.ExtensionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExtensionOptions
    {
        public ExtensionOptions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType> Request { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType> Response { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionOptionType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType DoNotMergeExistingReadOnlyAndSecretProperties { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType IncludeInternalMetadata { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType left, Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType left, Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeaturesPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeaturesPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy All { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy Any { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy left, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy left, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityManagementProperties
    {
        public IdentityManagementProperties() { }
        public string ApplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? ManagementType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityManagementType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.IdentityManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityManagementType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType Actor { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType DelegatedResourceIdentity { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType left, Azure.ResourceManager.ProviderHub.Models.IdentityManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.IdentityManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType left, Azure.ResourceManager.ProviderHub.Models.IdentityManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LightHouseAuthorization
    {
        public LightHouseAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class LinkedAccessCheck
    {
        public LinkedAccessCheck() { }
        public string ActionName { get { throw null; } set { } }
        public string LinkedAction { get { throw null; } set { } }
        public string LinkedActionVerb { get { throw null; } set { } }
        public string LinkedProperty { get { throw null; } set { } }
        public string LinkedType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedAction : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LinkedAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedAction(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Blocked { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Enabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Validate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LinkedAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LinkedAction left, Azure.ResourceManager.ProviderHub.Models.LinkedAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LinkedAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LinkedAction left, Azure.ResourceManager.ProviderHub.Models.LinkedAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LinkedOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation CrossResourceGroupResourceMove { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation CrossSubscriptionResourceMove { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LinkedOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LinkedOperation left, Azure.ResourceManager.ProviderHub.Models.LinkedOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LinkedOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LinkedOperation left, Azure.ResourceManager.ProviderHub.Models.LinkedOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedOperationRule
    {
        internal LinkedOperationRule() { }
        public Azure.ResourceManager.ProviderHub.Models.LinkedAction LinkedAction { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.LinkedOperation LinkedOperation { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggingDetail : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LoggingDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggingDetail(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDetail Body { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LoggingDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LoggingDetail left, Azure.ResourceManager.ProviderHub.Models.LoggingDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LoggingDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LoggingDetail left, Azure.ResourceManager.ProviderHub.Models.LoggingDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggingDirection : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LoggingDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggingDirection(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection Request { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection Response { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LoggingDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LoggingDirection left, Azure.ResourceManager.ProviderHub.Models.LoggingDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LoggingDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LoggingDirection left, Azure.ResourceManager.ProviderHub.Models.LoggingDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoggingHiddenPropertyPath
    {
        public LoggingHiddenPropertyPath() { }
        public System.Collections.Generic.IList<string> HiddenPathsOnRequest { get { throw null; } }
        public System.Collections.Generic.IList<string> HiddenPathsOnResponse { get { throw null; } }
    }
    public partial class LoggingRule
    {
        public LoggingRule(string action, Azure.ResourceManager.ProviderHub.Models.LoggingDirection direction, Azure.ResourceManager.ProviderHub.Models.LoggingDetail detailLevel) { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingDetail DetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingRuleHiddenPropertyPaths HiddenPropertyPaths { get { throw null; } set { } }
    }
    public partial class LoggingRuleHiddenPropertyPaths : Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPath
    {
        public LoggingRuleHiddenPropertyPaths() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestResourceDeletionPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestResourceDeletionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy Cascade { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy Force { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageScope : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.MessageScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageScope(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.MessageScope NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.MessageScope RegisteredSubscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.MessageScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.MessageScope left, Azure.ResourceManager.ProviderHub.Models.MessageScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.MessageScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.MessageScope left, Azure.ResourceManager.ProviderHub.Models.MessageScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationEndpoint
    {
        public NotificationEndpoint() { }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public string NotificationDestination { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationMode : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.NotificationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationMode(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode EventHub { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode WebHook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.NotificationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.NotificationMode left, Azure.ResourceManager.ProviderHub.Models.NotificationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.NotificationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.NotificationMode left, Azure.ResourceManager.ProviderHub.Models.NotificationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationRegistrationProperties
    {
        public NotificationRegistrationProperties() { }
        public System.Collections.Generic.IList<string> IncludedEvents { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.MessageScope? MessageScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint> NotificationEndpoints { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.NotificationMode? NotificationMode { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class OperationsDefinition
    {
        internal OperationsDefinition() { }
        public Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin? Origin { get { throw null; } }
        public System.BinaryData Properties { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationsDefinitionActionType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationsDefinitionActionType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType Internal { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType left, Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType left, Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationsDefinitionDisplay : Azure.ResourceManager.ProviderHub.Models.OperationsDisplayDefinition
    {
        public OperationsDefinitionDisplay(string provider, string resource, string operation, string description) : base (default(string), default(string), default(string), default(string)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationsDefinitionOrigin : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationsDefinitionOrigin(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin System { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin left, Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin left, Azure.ResourceManager.ProviderHub.Models.OperationsDefinitionOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OperationsDisplayDefinition
    {
        public OperationsDisplayDefinition(string provider, string resource, string operation, string description) { }
        public string Description { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        public string Resource { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptInHeaderType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.OptInHeaderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptInHeaderType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType ClientGroupMembership { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType SignedAuxiliaryTokens { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType SignedUserToken { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType UnboundedClientGroupMembership { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.OptInHeaderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Policy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.Policy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Policy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.Policy NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Policy SynchronizeBeginExtension { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.Policy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.Policy left, Azure.ResourceManager.ProviderHub.Models.Policy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.Policy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.Policy left, Azure.ResourceManager.ProviderHub.Models.Policy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreflightOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.PreflightOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreflightOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption ContinueDeploymentOnFailure { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption DefaultValidationOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.PreflightOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.PreflightOption left, Azure.ResourceManager.ProviderHub.Models.PreflightOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.PreflightOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.PreflightOption left, Azure.ResourceManager.ProviderHub.Models.PreflightOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderHubMetadata
    {
        public ProviderHubMetadata() { }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadataThirdPartyProviderAuthorization ThirdPartyProviderAuthorization { get { throw null; } set { } }
    }
    public partial class ProviderHubMetadataThirdPartyProviderAuthorization : Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization
    {
        public ProviderHubMetadataThirdPartyProviderAuthorization() { }
    }
    public partial class ProviderRegistrationProperties : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties
    {
        public ProviderRegistrationProperties() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationPropertiesProviderHubMetadata ProviderHubMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
    }
    public partial class ProviderRegistrationPropertiesProviderHubMetadata : Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata
    {
        public ProviderRegistrationPropertiesProviderHubMetadata() { }
    }
    public partial class ProviderRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications : Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications
    {
        public ProviderRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState MovingResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState RolloutInProgress { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProvisioningState TransientFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProvisioningState left, Azure.ResourceManager.ProviderHub.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProvisioningState left, Azure.ResourceManager.ProviderHub.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Readiness : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.Readiness>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Readiness(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness ClosingDown { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness GA { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness InDevelopment { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness InternalOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness PrivatePreview { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness PublicPreview { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness RemovedFromARM { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Readiness Retired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.Readiness other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.Readiness left, Azure.ResourceManager.ProviderHub.Models.Readiness right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.Readiness (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.Readiness left, Azure.ResourceManager.ProviderHub.Models.Readiness right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Regionality : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.Regionality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Regionality(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.Regionality Global { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Regionality NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.Regionality Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.Regionality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.Regionality left, Azure.ResourceManager.ProviderHub.Models.Regionality right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.Regionality (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.Regionality left, Azure.ResourceManager.ProviderHub.Models.Regionality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReRegisterSubscriptionMetadata
    {
        internal ReRegisterSubscriptionMetadata() { }
        public int? ConcurrencyLimit { get { throw null; } }
        public bool Enabled { get { throw null; } }
    }
    public partial class ResourceConcurrencyControlOption
    {
        public ResourceConcurrencyControlOption() { }
        public Azure.ResourceManager.ProviderHub.Models.Policy? Policy { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceDeletionPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceDeletionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy CascadeDeleteAll { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy CascadeDeleteProxyOnlyChildren { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGraphConfiguration
    {
        public ResourceGraphConfiguration() { }
        public string ApiVersion { get { throw null; } set { } }
        public bool? Enabled { get { throw null; } set { } }
    }
    public partial class ResourceManagementAction
    {
        public ResourceManagementAction() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity> Resources { get { throw null; } }
    }
    public partial class ResourceManagementEntity
    {
        public ResourceManagementEntity(string resourceId) { }
        public string HomeTenantId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string Status { get { throw null; } }
    }
    public partial class ResourceMovePolicy
    {
        public ResourceMovePolicy() { }
        public bool? CrossResourceGroupMoveEnabled { get { throw null; } set { } }
        public bool? CrossSubscriptionMoveEnabled { get { throw null; } set { } }
        public bool? ValidationRequired { get { throw null; } set { } }
    }
    public partial class ResourceProviderAuthorization
    {
        public ResourceProviderAuthorization() { }
        public string ApplicationId { get { throw null; } set { } }
        public string ManagedByRoleDefinitionId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
    }
    public partial class ResourceProviderCapabilities
    {
        public ResourceProviderCapabilities(string quotaId, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect effect) { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Effect { get { throw null; } set { } }
        public string QuotaId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderCapabilitiesEffect : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderCapabilitiesEffect(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Allow { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Disallow { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProviderEndpoint
    {
        internal ResourceProviderEndpoint() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public bool? Enabled { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.EndpointType? EndpointType { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } }
    }
    public partial class ResourceProviderManagement
    {
        public ResourceProviderManagement() { }
        public string IncidentContactEmail { get { throw null; } set { } }
        public string IncidentRoutingService { get { throw null; } set { } }
        public string IncidentRoutingTeam { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManifestOwners { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy? ResourceAccessPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceAccessRoles { get { throw null; } }
        public System.Collections.Generic.IList<string> SchemaOwners { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderManagementResourceAccessPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderManagementResourceAccessPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy AcisActionAllowed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy AcisReadAllowed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagementResourceAccessPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProviderManifest
    {
        internal ResourceProviderManifest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> GlobalNotificationEndpoints { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestManagement Management { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } }
        public string ProviderVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestReRegisterSubscriptionMetadata ReRegisterSubscriptionMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceType> ResourceTypes { get { throw null; } }
    }
    public partial class ResourceProviderManifestManagement : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement
    {
        public ResourceProviderManifestManagement() { }
    }
    public partial class ResourceProviderManifestProperties
    {
        public ResourceProviderManifestProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestPropertiesManagement Management { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } set { } }
        public string ProviderVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestPropertiesTemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
    }
    public partial class ResourceProviderManifestPropertiesManagement : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement
    {
        public ResourceProviderManifestPropertiesManagement() { }
    }
    public partial class ResourceProviderManifestPropertiesTemplateDeploymentOptions : Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions
    {
        public ResourceProviderManifestPropertiesTemplateDeploymentOptions() { }
    }
    public partial class ResourceProviderManifestReRegisterSubscriptionMetadata : Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata
    {
        internal ResourceProviderManifestReRegisterSubscriptionMetadata() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType AuthorizationFree { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType External { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType Hidden { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType Internal { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType LegacyRegistrationRequired { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType RegistrationFree { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType TenantOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceType
    {
        internal ResourceType() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedUnauthorizedActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisallowedActionVerbs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> LinkedOperationRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? ManagementType { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType? MarketplaceType { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy? ResourceDeletionPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceValidation? ResourceValidation { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.RoutingType? RoutingType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        public string SkuLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateRule> SubscriptionStateRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeTemplateDeploymentPolicy TemplateDeploymentPolicy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> ThrottlingRules { get { throw null; } }
    }
    public partial class ResourceTypeEndpoint
    {
        public ResourceTypeEndpoint() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.EndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension> Extensions { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ResourceTypeExtension
    {
        public ResourceTypeExtension() { }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtensionCategory> ExtensionCategories { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
    }
    public partial class ResourceTypeExtensionOptionsResourceCreationBegin : Azure.ResourceManager.ProviderHub.Models.ExtensionOptions
    {
        public ResourceTypeExtensionOptionsResourceCreationBegin() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeMarketplaceType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeMarketplaceType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType AddOn { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType Bypass { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType Store { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeMarketplaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeRegistrationProperties
    {
        public ResourceTypeRegistrationProperties() { }
        public System.Collections.Generic.IList<string> AllowedUnauthorizedActions { get { throw null; } }
        public bool? AllowNoncompliantCollectionResponse { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications CheckNameAvailabilitySpecifications { get { throw null; } set { } }
        public string DefaultApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedActionVerbs { get { throw null; } }
        public bool? EnableAsyncOperation { get { throw null; } set { } }
        public bool? EnableThirdPartyS2S { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionOptionsResourceCreationBegin ExtensionOptionsResourceCreationBegin { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesIdentityManagement IdentityManagement { get { throw null; } set { } }
        public bool? IsPureProxy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesManagement Management { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType? MarketplaceType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.Regionality? Regionality { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption> ResourceConcurrencyControlOptions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy? ResourceDeletionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesResourceGraphConfiguration ResourceGraphConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesResourceMovePolicy ResourceMovePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.RoutingType? RoutingType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateRule> SubscriptionStateRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification> SwaggerSpecifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesTemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> ThrottlingRules { get { throw null; } }
    }
    public partial class ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications : Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications
    {
        public ResourceTypeRegistrationPropertiesCheckNameAvailabilitySpecifications() { }
    }
    public partial class ResourceTypeRegistrationPropertiesIdentityManagement : Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties
    {
        public ResourceTypeRegistrationPropertiesIdentityManagement() { }
    }
    public partial class ResourceTypeRegistrationPropertiesManagement : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement
    {
        public ResourceTypeRegistrationPropertiesManagement() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeRegistrationPropertiesMarketplaceType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeRegistrationPropertiesMarketplaceType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType AddOn { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType Bypass { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType Store { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationPropertiesMarketplaceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeRegistrationPropertiesResourceGraphConfiguration : Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration
    {
        public ResourceTypeRegistrationPropertiesResourceGraphConfiguration() { }
    }
    public partial class ResourceTypeRegistrationPropertiesResourceMovePolicy : Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy
    {
        public ResourceTypeRegistrationPropertiesResourceMovePolicy() { }
    }
    public partial class ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications : Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications
    {
        public ResourceTypeRegistrationPropertiesSubscriptionLifecycleNotificationSpecifications() { }
    }
    public partial class ResourceTypeRegistrationPropertiesTemplateDeploymentOptions : Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions
    {
        public ResourceTypeRegistrationPropertiesTemplateDeploymentOptions() { }
    }
    public partial class ResourceTypeSkuInfo
    {
        public ResourceTypeSkuInfo(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.SkuSetting> skuSettings) { }
        public Azure.ResourceManager.ProviderHub.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuSetting> SkuSettings { get { throw null; } }
    }
    public partial class ResourceTypeTemplateDeploymentPolicy : Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy
    {
        internal ResourceTypeTemplateDeploymentPolicy() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceValidation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceValidation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceValidation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation ProfaneWords { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation ReservedWords { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceValidation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceValidation left, Azure.ResourceManager.ProviderHub.Models.ResourceValidation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceValidation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceValidation left, Azure.ResourceManager.ProviderHub.Models.ResourceValidation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RolloutStatusBase
    {
        public RolloutStatusBase() { }
        public System.Collections.Generic.IList<string> CompletedRegions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> FailedOrSkippedRegions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RoutingType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.RoutingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RoutingType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType CascadeExtension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType Extension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType Failover { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType Fanout { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType HostBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType LocationBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType ProxyOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.RoutingType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.RoutingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.RoutingType left, Azure.ResourceManager.ProviderHub.Models.RoutingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.RoutingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.RoutingType left, Azure.ResourceManager.ProviderHub.Models.RoutingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceTreeInfo
    {
        public ServiceTreeInfo() { }
        public string ComponentId { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.Readiness? Readiness { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
    }
    public partial class SkuCapability
    {
        public SkuCapability(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class SkuCapacity
    {
        public SkuCapacity(int minimum) { }
        public int? Default { get { throw null; } set { } }
        public int? Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SkuScaleType? ScaleType { get { throw null; } set { } }
    }
    public partial class SkuCost
    {
        public SkuCost(string meterId) { }
        public string ExtendedUnit { get { throw null; } set { } }
        public string MeterId { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
    }
    public partial class SkuLocationInfo
    {
        public SkuLocationInfo(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType? InfoType { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuZoneDetail> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuLocationInfoType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuLocationInfoType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType ArcZone { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType EdgeZone { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType left, Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType left, Azure.ResourceManager.ProviderHub.Models.SkuLocationInfoType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuResourceProperties : Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuInfo
    {
        public SkuResourceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.SkuSetting> skuSettings) : base (default(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.SkuSetting>)) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuScaleType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SkuScaleType left, Azure.ResourceManager.ProviderHub.Models.SkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SkuScaleType left, Azure.ResourceManager.ProviderHub.Models.SkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuSetting
    {
        public SkuSetting(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.SkuSettingCapacity Capacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredQuotaIds { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
    }
    public partial class SkuSettingCapacity : Azure.ResourceManager.ProviderHub.Models.SkuCapacity
    {
        public SkuSettingCapacity(int minimum) : base (default(int)) { }
    }
    public partial class SkuZoneDetail
    {
        public SkuZoneDetail() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> Name { get { throw null; } }
    }
    public partial class SubscriptionLifecycleNotificationSpecifications
    {
        public SubscriptionLifecycleNotificationSpecifications() { }
        public System.TimeSpan? SoftDeleteTTL { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction> SubscriptionStateOverrideActions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionNotificationOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionNotificationOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation BillingCancellation { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation DeleteAllResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation NoOp { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation SoftDeleteAllResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation UndoSoftDelete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation left, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation left, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionReregistrationResult : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionReregistrationResult(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult ConditionalUpdate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult Failed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult ForcedUpdate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult left, Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult left, Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState PastDue { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionStateOverrideAction
    {
        public SubscriptionStateOverrideAction(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState state, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation action) { }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation Action { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState State { get { throw null; } set { } }
    }
    public partial class SubscriptionStateRule
    {
        public SubscriptionStateRule() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionState? State { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionTransitioningState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionTransitioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToDeleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToRegistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToUnregistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToWarned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Warned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToDeleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToRegistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToSuspended { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToUnregistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwaggerSpecification
    {
        public SwaggerSpecification() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public System.Uri SwaggerSpecFolderUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateDeploymentCapability : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateDeploymentCapability(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Preflight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemplateDeploymentOptions
    {
        public TemplateDeploymentOptions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.PreflightOption> PreflightOptions { get { throw null; } }
        public bool? PreflightSupported { get { throw null; } set { } }
    }
    public partial class TemplateDeploymentPolicy
    {
        internal TemplateDeploymentPolicy() { }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption PreflightOptions { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateDeploymentPreflightOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateDeploymentPreflightOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption DeploymentRequests { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption RegisteredOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption TestOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption ValidationRequests { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThirdPartyProviderAuthorization
    {
        public ThirdPartyProviderAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization> Authorizations { get { throw null; } }
        public string ManagedByTenantId { get { throw null; } set { } }
    }
    public partial class ThrottlingMetric
    {
        public ThrottlingMetric(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType metricType, long limit) { }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public long Limit { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType MetricType { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThrottlingMetricType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThrottlingMetricType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NumberOfRequests { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NumberOfResources { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType left, Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType left, Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThrottlingRule
    {
        public ThrottlingRule(string action, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric> metrics) { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficRegionCategory : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficRegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory HighTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory LowTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory MediumTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory RestOfTheWorldGroupOne { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory RestOfTheWorldGroupTwo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory left, Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory left, Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficRegionRolloutConfiguration : Azure.ResourceManager.ProviderHub.Models.TrafficRegions
    {
        public TrafficRegionRolloutConfiguration() { }
        public System.TimeSpan? WaitDuration { get { throw null; } set { } }
    }
    public partial class TrafficRegions
    {
        public TrafficRegions() { }
        public System.Collections.Generic.IList<string> Regions { get { throw null; } }
    }
    public partial class TypedErrorInfo
    {
        public TypedErrorInfo(string typedErrorInfoType) { }
        public System.BinaryData Info { get { throw null; } }
        public string TypedErrorInfoType { get { throw null; } set { } }
    }
}
