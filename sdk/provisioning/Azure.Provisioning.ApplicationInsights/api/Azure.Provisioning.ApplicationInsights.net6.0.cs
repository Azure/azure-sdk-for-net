namespace Azure.Provisioning.ApplicationInsights
{
    public partial class ApplicationInsightsComponent : Azure.Provisioning.Resource<Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>
    {
        public ApplicationInsightsComponent(Azure.Provisioning.IConstruct scope, string kind = "web", string applicationType = "web", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "appinsights", string version = "2020-02-02", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.ApplicationInsights.ApplicationInsightsComponentData>), default(bool)) { }
        public static Azure.Provisioning.ApplicationInsights.ApplicationInsightsComponent FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
