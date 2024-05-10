namespace Azure.Provisioning.WebPubSub
{
    public partial class WebPubSubHub : Azure.Provisioning.Resource<Azure.ResourceManager.WebPubSub.WebPubSubHubData>
    {
        public WebPubSubHub(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.WebPubSub.Models.WebPubSubHubProperties properties, Azure.Provisioning.WebPubSub.WebPubSubService? parent = null, string name = "hub", string version = "2021-10-01") : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.WebPubSub.WebPubSubHubData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.WebPubSub.WebPubSubHub FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.WebPubSub.WebPubSubService? parent = null) { throw null; }
    }
    public partial class WebPubSubService : Azure.Provisioning.Resource<Azure.ResourceManager.WebPubSub.WebPubSubData>
    {
        public WebPubSubService(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.WebPubSub.Models.BillingInfoSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "webpubsub", string version = "2021-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.WebPubSub.WebPubSubData>), default(bool)) { }
        public static Azure.Provisioning.WebPubSub.WebPubSubService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
