namespace Azure.ResourceManager.Healthbot
{
    public partial class HealthBotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Healthbot.HealthBotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Healthbot.HealthBotResource>, System.Collections.IEnumerable
    {
        protected HealthBotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Healthbot.HealthBotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string botName, Azure.ResourceManager.Healthbot.HealthBotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Healthbot.HealthBotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string botName, Azure.ResourceManager.Healthbot.HealthBotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> Get(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Healthbot.HealthBotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Healthbot.HealthBotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> GetAsync(string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Healthbot.HealthBotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Healthbot.HealthBotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Healthbot.HealthBotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Healthbot.HealthBotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HealthBotData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public HealthBotData(Azure.Core.AzureLocation location, Azure.ResourceManager.Healthbot.Models.HealthbotSku sku) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Healthbot.Models.HealthBotProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Healthbot.Models.HealthbotSkuName? SkuName { get { throw null; } set { } }
    }
    public static partial class HealthbotExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> GetHealthBot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> GetHealthBotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string botName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Healthbot.HealthBotResource GetHealthBotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Healthbot.HealthBotCollection GetHealthBots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Healthbot.HealthBotResource> GetHealthBots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Healthbot.HealthBotResource> GetHealthBotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class HealthBotResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HealthBotResource() { }
        public virtual Azure.ResourceManager.Healthbot.HealthBotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string botName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource> Update(Azure.ResourceManager.Healthbot.Models.HealthBotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Healthbot.HealthBotResource>> UpdateAsync(Azure.ResourceManager.Healthbot.Models.HealthBotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Healthbot.Models
{
    public partial class HealthBotPatch
    {
        public HealthBotPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Healthbot.Models.HealthBotProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Healthbot.Models.HealthbotSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class HealthBotProperties
    {
        public HealthBotProperties() { }
        public string BotManagementPortalLink { get { throw null; } }
        public Azure.ResourceManager.Healthbot.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
    }
    public partial class HealthbotSku
    {
        public HealthbotSku(Azure.ResourceManager.Healthbot.Models.HealthbotSkuName name) { }
        public Azure.ResourceManager.Healthbot.Models.HealthbotSkuName Name { get { throw null; } set { } }
    }
    public enum HealthbotSkuName
    {
        F0 = 0,
        S1 = 1,
        C0 = 2,
    }
    public partial class KeyVaultProperties
    {
        public KeyVaultProperties(string keyName, System.Uri keyVaultUri) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        public string UserIdentity { get { throw null; } set { } }
    }
}
