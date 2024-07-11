namespace Azure.Provisioning.AppConfiguration
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore AddAppConfigurationStore(this Azure.Provisioning.IConstruct construct, string name = "store") { throw null; }
    }
    public partial class AppConfigurationStore : Azure.Provisioning.Resource<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>
    {
        public AppConfigurationStore(Azure.Provisioning.IConstruct scope, string skuName = "free", Azure.Provisioning.ResourceManager.ResourceGroup? parent = null, string name = "store", string version = "2023-03-01", Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?)) : base (default(Azure.Provisioning.IConstruct), default(Azure.Provisioning.Resource), default(string), default(Azure.Core.ResourceType), default(string), default(System.Func<string, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>), default(bool)) { }
        public static Azure.Provisioning.AppConfiguration.AppConfigurationStore FromExisting(Azure.Provisioning.IConstruct scope, string name, Azure.Provisioning.ResourceManager.ResourceGroup? parent = null) { throw null; }
        protected override string GetAzureName(Azure.Provisioning.IConstruct scope, string resourceName) { throw null; }
    }
}
