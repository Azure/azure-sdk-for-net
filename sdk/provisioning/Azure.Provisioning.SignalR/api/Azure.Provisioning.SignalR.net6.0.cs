namespace Azure.Provisioning.SignalR
{
    public partial class SignalRService : Azure.Provisioning.Resource<Azure.ResourceManager.SignalR.SignalRData>
    {
        public SignalRService(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.SignalR.Models.SignalRResourceSku? sku = null, System.Collections.Generic.IEnumerable<string>? allowedOrigins = null, string serviceMode = "Default", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "signalr", string version = "2022-02-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.SignalR.SignalRData>), default(bool)) { }
        public static Azure.Provisioning.SignalR.SignalRService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
