namespace Azure.Provisioning.ServiceBus
{
    public partial class ServiceBusNamespace : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData>
    {
        public ServiceBusNamespace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.ServiceBus.Models.ServiceBusSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "sb", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusNamespaceData>), default(bool)) { }
        public static Azure.Provisioning.ServiceBus.ServiceBusNamespace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
    public partial class ServiceBusQueue : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusQueueData>
    {
        public ServiceBusQueue(Azure.Provisioning.IConstruct scope, bool? requiresSession = default(bool?), Azure.Provisioning.ServiceBus.ServiceBusNamespace? parent = null, string name = "queue", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusQueueData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusQueue FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusNamespace parent) { throw null; }
    }
    public partial class ServiceBusSubscription : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData>
    {
        public ServiceBusSubscription(Azure.Provisioning.IConstruct scope, bool? requiresSession = default(bool?), Azure.Provisioning.ServiceBus.ServiceBusTopic? parent = null, string name = "subscription", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusSubscriptionData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusSubscription FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusTopic parent) { throw null; }
    }
    public partial class ServiceBusTopic : Azure.Provisioning.Resource<Azure.ResourceManager.ServiceBus.ServiceBusTopicData>
    {
        public ServiceBusTopic(Azure.Provisioning.IConstruct scope, Azure.Provisioning.ServiceBus.ServiceBusNamespace? parent = null, string name = "topic", string version = "2021-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ServiceBus.ServiceBusTopicData>), default(bool)) { }
        protected override Azure.Provisioning.Resource? FindParentInScope(Azure.Provisioning.IConstruct scope) { throw null; }
        public static Azure.Provisioning.ServiceBus.ServiceBusTopic FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ServiceBus.ServiceBusNamespace parent) { throw null; }
    }
}
