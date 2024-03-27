namespace Azure.Provisioning.OperationalInsights
{
    public partial class OperationalInsightsWorkspace : Azure.Provisioning.Resource<Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>
    {
        public OperationalInsightsWorkspace(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.OperationalInsights.Models.OperationalInsightsWorkspaceSku? sku = null, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "opinsights", string version = "2022-10-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.OperationalInsights.OperationalInsightsWorkspaceData>), default(bool)) { }
        public static Azure.Provisioning.OperationalInsights.OperationalInsightsWorkspace FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
