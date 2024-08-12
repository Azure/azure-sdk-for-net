namespace Azure.Provisioning.Search
{
    public partial class SearchService : Azure.Provisioning.Resource<Azure.ResourceManager.Search.SearchServiceData>
    {
        public SearchService(Azure.Provisioning.IConstruct scope, Azure.ResourceManager.Search.Models.SearchSkuName? sku = default(Azure.ResourceManager.Search.Models.SearchSkuName?), Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "search", string version = "2023-11-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.Search.SearchServiceData>), default(bool)) { }
        public static Azure.Provisioning.Search.SearchService FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
