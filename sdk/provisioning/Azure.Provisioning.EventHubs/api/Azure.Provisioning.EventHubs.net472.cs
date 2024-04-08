namespace Azure.Provisioning.EventHubs
{
    public partial class EventHub : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubData>
    {
        public EventHub(Azure.Provisioning.IConstruct scope, Azure.Provisioning.EventHubs.EventHubsNamespace? parent = null, string name = "hub", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.EventHubs.EventHub FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.EventHubs.EventHubsNamespace parent) { throw null; }
    }
    public partial class EventHubsConsumerGroup : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData>
    {
        public EventHubsConsumerGroup(Azure.Provisioning.IConstruct scope, Azure.Provisioning.EventHubs.EventHub? parent = null, string name = "cg", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubsConsumerGroupData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.EventHubs.EventHubsConsumerGroup FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.EventHubs.EventHub parent) { throw null; }
    }
    public partial class EventHubsNamespace : Azure.Provisioning.Resource<Azure.ResourceManager.EventHubs.EventHubsNamespaceData>
    {
        public EventHubsNamespace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.EventHubs.Models.EventHubsSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "eh", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.EventHubs.EventHubsNamespaceData>), default(bool)) { }
        public static Azure.Provisioning.EventHubs.EventHubsNamespace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
