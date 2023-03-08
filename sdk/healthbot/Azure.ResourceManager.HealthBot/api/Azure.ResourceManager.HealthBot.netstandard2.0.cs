namespace Azure.ResourceManager.HealthBot
{
    public partial class HealthBotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthBot.HealthBotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthBot.HealthBotResource>, System.Collections.IEnumerable
    {
        protected HealthBotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthBot.HealthBotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string botName, Azure.ResourceManager.HealthBot.HealthBotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HealthBot.HealthBotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string botName, Azure.ResourceManager.HealthBot.HealthBotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> Get(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> GetAsync(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HealthBot.HealthBotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HealthBot.HealthBotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HealthBot.HealthBotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HealthBot.HealthBotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthBotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HealthBotData(Azure.Core.AzureLocation location, Azure.ResourceManager.HealthBot.Models.HealthBotSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HealthBot.Models.HealthBotProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HealthBot.Models.HealthBotSkuName? SkuName { get { throw null; } set { } }
    }
    public static partial class HealthBotExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> GetHealthBot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> GetHealthBotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HealthBot.HealthBotResource GetHealthBotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HealthBot.HealthBotCollection GetHealthBots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetHealthBots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetHealthBotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthBotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthBotResource() { }
        public virtual Azure.ResourceManager.HealthBot.HealthBotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string botName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource> Update(Azure.ResourceManager.HealthBot.Models.HealthBotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HealthBot.HealthBotResource>> UpdateAsync(Azure.ResourceManager.HealthBot.Models.HealthBotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HealthBot.Mock
{
    public partial class HealthBotResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected HealthBotResourceExtensionClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetHealthBots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HealthBot.HealthBotResource> GetHealthBotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGroupResourceExtensionClient : Azure.ResourceManager.ArmResource
    {
        protected ResourceGroupResourceExtensionClient() { }
        public virtual Azure.ResourceManager.HealthBot.HealthBotCollection GetHealthBots() { throw null; }
    }
}
namespace Azure.ResourceManager.HealthBot.Models
{
    public partial class HealthBotKeyVaultProperties
    {
        public HealthBotKeyVaultProperties(string keyName, System.Uri keyVaultUri) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserIdentity { get { throw null; } set { } }
    }
    public partial class HealthBotPatch
    {
        public HealthBotPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.HealthBot.Models.HealthBotProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HealthBot.Models.HealthBotSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HealthBotProperties
    {
        public HealthBotProperties() { }
        public System.Uri BotManagementPortalLink { get { throw null; } }
        public Azure.ResourceManager.HealthBot.Models.HealthBotKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class HealthBotSku
    {
        public HealthBotSku(Azure.ResourceManager.HealthBot.Models.HealthBotSkuName name) { }
        public Azure.ResourceManager.HealthBot.Models.HealthBotSkuName Name { get { throw null; } set { } }
    }
    public enum HealthBotSkuName
    {
        F0 = 0,
        S1 = 1,
        C0 = 2,
    }
}
